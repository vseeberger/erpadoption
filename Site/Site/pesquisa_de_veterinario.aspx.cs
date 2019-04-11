using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_veterinario : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                AtualizaLista();        
            }
        }

        protected void AtualizaLista()
        {
            List<Veterinario> Lst = Veterinario.Pesquisar();
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
                        Response.Redirect("~/CadastroDeVeterinario?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        Veterinario o = new Veterinario(long.Parse(e.CommandArgument.ToString()));
                        o.Excluir();
                        Type tipo = o.GetType();
                        GravarLog(3, " O VETERINARIO CODIGO " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        AtualizaLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeVeterinario");
        }
    }
}