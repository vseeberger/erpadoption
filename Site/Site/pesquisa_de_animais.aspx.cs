using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_animais : _Herdar
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
            String _Nome = null;
            bool? _Status = null;
            int? _Situacao = null;
            if (rbtStatusAtivos.Checked) _Status = true;
            else if (rbtStatusInativos.Checked) _Status = false;

            if (rbtSituacaoDisponiveis.Checked) _Situacao = 1;
            else if (rbtSituacaoAdotados.Checked) _Situacao = 3;
            else if (rbtSituacaoIndisponiveis.Checked) _Situacao = 4;

            long _Padrinhos;
            if (!long.TryParse(ddlPadrinhos.SelectedValue, out _Padrinhos)) { _Padrinhos = 0; }

            List<Animal> Lst = Animal.Pesquisar(_Nome, _Situacao, _Status);
            rptResultado.DataSource = Lst;
            rptResultado.DataBind();
            pnlVazio.Visible = Lst == null || Lst.Count == 0;
        }

        protected void rptResultado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            long l = long.Parse(e.CommandArgument.ToString());
            Animal o = new Animal(l);
            Type tipo = o.GetType();
            try
            {
                switch (e.CommandName)
                {
                    case "Alterar":
                        Response.Redirect("~/CadastroDeAnimal?" + o.Id);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        o.Excluir();
                        GravarLog(3, " O ANIMAL CODIGO " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeAnimal");
        }

        protected void lnkCarregar_Click(object sender, EventArgs e)
        {
            CarregarLista();
        }
    }
}