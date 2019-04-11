using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_marca : _Herdar
    {
        private static ProdutoMarca _Origem;
        private ProdutoMarca item
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar a descrição.");

                int i;
                ProdutoMarca item = new ProdutoMarca()
                {
                    Id = int.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SDescricao = txtNome.Text,
                    Status = true,
                    STipo = "M",
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
                    txtNome.Text = value.SDescricao;
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
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
                        ProdutoMarca raca = ProdutoMarca.Obter(i);
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
                Redirecionar("TodasAsMarcas");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoMarca o = item;
                o.Salvar();
                Type tipo = o.GetType();
                int l;
                int.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " A MARCA CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodasAsMarcas", "/CadastroDeMarca");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}