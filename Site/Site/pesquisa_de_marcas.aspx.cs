using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_marcas : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                CarregarLista();
            }
        }

        private void CarregarLista()
        {
            List<ProdutoMarca> Lst = ProdutoMarca.Pesquisar();
            rptResultado.DataSource = Lst;
            rptResultado.DataBind();
            pnlVazio.Visible = Lst == null || Lst.Count == 0;
        }

        protected void rptResultado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Alterar":
                        Response.Redirect("~/CadastroDeMarca?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        int i = int.Parse(e.CommandArgument.ToString());
                        ProdutoMarca _item = new ProdutoMarca(i);
                        _item.Excluir();
                        GravarLog(3, " A MARCA, CÓDIGO" + i, null, Util.serializarObjetos(_item, _item.GetType()), _item.GetType());
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeMarca");
        }
    }
}