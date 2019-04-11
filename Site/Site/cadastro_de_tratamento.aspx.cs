using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_tratamento : _Herdar
    {
        private static AnimalMedicamentoTratamento _Origem;
        private AnimalMedicamentoTratamento item
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar a descrição.");

                int i; decimal d;
                AnimalMedicamentoTratamento item = new AnimalMedicamentoTratamento()
                {
                    Id = int.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SDescricao = txtDescricao.Text,
                    SNome = txtNome.Text,
                    Status = true,
                };

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SNome;
                    txtDescricao.Text = value.SDescricao;
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtDescricao.Text = "";
                    txtNome.Text = "";
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
                        AnimalMedicamentoTratamento ori = AnimalMedicamentoTratamento.Obter(i);
                        item = ori;
                        _Origem = ori;
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
                Redirecionar("TodosOsTratamentos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalMedicamentoTratamento o = item;
                o.Salvar();
                Type tipo = o.GetType();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O TRATAMENTO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);
                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Sucesso, this);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("CadastroDeTratamento");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}