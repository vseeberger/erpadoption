using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class pesquisa_de_adocoes : _Herdar
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
            int _Tipo = 0;
            if (rbtAdotado.Checked) _Tipo = 3;
            if (rbtDisponivel.Checked) _Tipo = 1;
            if (rbtEmAdocao.Checked) _Tipo = 2;
            if (rbtIndisponivel.Checked) _Tipo =4;

            List<AnimalAdotado> Lst = AnimalAdotado.Pesquisar(null, null, _Tipo);
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
                        Response.Redirect("~/CadastroDeAdocao?" + e.CommandArgument);
                        break;
                    case "Remover":
                        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                        string[] sChaves = e.CommandArgument.ToString().Split(new char[] { ',' });

                        long lId = 0;
                        long lAnimal = 0;

                        if (sChaves.Length > 0) long.TryParse(sChaves[0], out lId);
                        if (sChaves.Length > 1) long.TryParse(sChaves[1], out lAnimal);
                        if (lId == 0) throw new Exception("Adoção NÃO identificada.");
                        if (lAnimal == 0) throw new Exception("Animal NÃO identificado.");

                        AnimalAdotado o = new AnimalAdotado() { Id = lId, Animal = new Animal(lAnimal) };
                        o.Desistir();

                        Type tipo = o.GetType();
                        GravarLog(0, "CANCELOU A ADOÇÃO DO ANIMAL " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        CarregarLista();
                        break;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeAdocao");
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