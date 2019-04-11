using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_beneficio : _Herdar
    {
        private static BeneficioDesconto _Origem;
        private BeneficioDesconto item
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar a descrição.");
                BeneficioDesconto item = new BeneficioDesconto();
                int i; decimal d;
                item.Id = int.TryParse(txtCodigo.Text, out i) ? i : 0;
                item.SDescricao = txtNome.Text;
                item.DPercentualDesconto = decimal.TryParse(txtPercentualDesconto.Text, out d) ? d : 0;
                item.DValorMaximo = decimal.TryParse(txtDescontoMaximo.Text, out d) ? d : 0;
                
                
                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SDescricao;
                    txtDescontoMaximo.Text = value.DValorMaximo.ToString("#,#0.00");
                    txtPercentualDesconto.Text = value.DPercentualDesconto.ToString("#0.00");
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtNome.Text = "";
                    txtDescontoMaximo.Text = "";
                    txtPercentualDesconto.Text = "";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    String id = Request.QueryString.ToString();
                    _Origem = null;
                    int i;
                    if (int.TryParse(id, out i) && i > 0)
                    {
                        BeneficioDesconto raca = BeneficioDesconto.Obter(i);
                        item = raca;
                        _Origem = raca;
                    }
                    else
                        item = null;
                }
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsBeneficios");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                BeneficioDesconto o = item;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O BENEFÍCIO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsBeneficios", "/CadastroDeBeneficio");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}