using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_produtos : _Herdar
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
            string _Tipo = "";
            bool? _Medicamento = null;
            bool? _Vacina = null;
            bool? _PesquisarOU = null;

            if (rbtTiposConsumo.Checked) _Tipo = "C";
            if (rbtTiposMercadoria.Checked) _Tipo = "M";
            if (rbtTiposServico.Checked) _Tipo = "S";
            if (rbtTiposImobilizado.Checked) _Tipo = "I";

            if (rbtTipos2Medicamento.Checked) { _Medicamento = true; _PesquisarOU = null; }
            if (rbtTipos2NaoMedicamento.Checked) { _Vacina = true; _PesquisarOU = true; }
            if (rbtTipos2Vacina.Checked) { _Vacina = true; _PesquisarOU = null; }
            if (rbtTipos2NaoVacina.Checked) { _Medicamento = true; _PesquisarOU = true; }

            List<Produto> Lst = Produto.Pesquisar(_Tipo, _Medicamento, _Vacina, _PesquisarOU);
            pnlVazio.Visible = Lst == null || Lst.Count == 0;

            rptResultado.DataSource = null;
            rptResultado.DataBind();

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
                        Response.Redirect("~/CadastroDeProduto?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        long l = long.Parse(e.CommandArgument.ToString());
                        Produto o = new Produto(l);
                        o.Excluir();
                        Type tipo = o.GetType();
                        GravarLog(3, " O PRODUTO CODIGO " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeProduto");
        }

        protected void lnkCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarLista();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}