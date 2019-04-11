using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_centro_de_custos : _Herdar
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
            List<CentroDeCustos> Lst = CentroDeCustos.Pesquisar();
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
                        Response.Redirect("~/CadastroDeCentroDeCustos?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        int i = int.Parse(e.CommandArgument.ToString());
                        CentroDeCustos o = new CentroDeCustos(i);
                        o.Excluir();
                        Type tipo = o.GetType();
                        GravarLog(3, " O CENTRO DE CUSTOS CODIGO " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeCentroDeCustos");
        }
    }
}