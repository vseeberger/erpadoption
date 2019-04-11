using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Executar : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!Logado().IgnoraPermissoes) Redirecionar("/Cade");
        }

        protected void lnkExecutar_Click(object sender, EventArgs e)
        {
            try
            {
                //FWPet.Dao.Conexao.Executar(txtComando.Text);
                gdv.DataSource = FWPet.Dao.Conexao.ExecutaRetorno(txtComando.Text);
                gdv.DataBind();
                //MensagemAlertaPopup("Comando executado com sucesso! ", Mensagens.Informacao, this);
                //txtComando.Text = "";
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}