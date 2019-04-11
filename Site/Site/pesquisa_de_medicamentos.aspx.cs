using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_medicamentos : _Herdar
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
            List<Medicamento> Lst = Medicamento.Pesquisar();
            pnlVazio.Visible = Lst == null || Lst.Count == 0;
            rptResultado.DataSource = Lst;
            rptResultado.DataBind();
        }

        protected void rptResultado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Alterar":
                        Response.Redirect("~/CadastroDeMedicamento?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        long l = long.Parse(e.CommandArgument.ToString());
                        Medicamento _med = new Medicamento(l);
                        _med.Excluir();
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeMedicamento");
        }
    }
}