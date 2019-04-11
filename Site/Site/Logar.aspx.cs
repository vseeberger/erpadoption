using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Logar : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                //Pingar();
            }
        }

        private void Pingar()
        {
            //<i class='fa fa-dot-circle-o'></i>
            System.Net.NetworkInformation.Ping p = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply r;
            String s = System.Configuration.ConfigurationSettings.AppSettings["DBServer"]; //Replace input from your text box for IP address here
            r = p.Send(s);
            Response.Buffer = false;
            if (r.Status == System.Net.NetworkInformation.IPStatus.Success)
                ltrPing.Text = "<i class='fa fa-dot-circle-o' style='color:green!important;'> </i> " + r.Address + " - ATIVO - " + r.Buffer.Length.ToString() + " bytes in " + r.RoundtripTime.ToString() + " ms.";
            else
                ltrPing.Text = "<i class='fa fa-dot-circle-o' style='color:red!important;'></i> " + r.Address + " - INATIVO - " + r.Buffer.Length.ToString() + " bytes in " + r.RoundtripTime.ToString() + " ms.";

            try
            {
                string retorno = FWPet.Crypt.ProcuraGenerica("SELECT sid FROM usuario LIMIT 1", "sid");
                if (retorno == null || String.IsNullOrEmpty(retorno)) ltrAcessibilidade.Text = "<span style='color:red;'>O Banco de dados está <b>INACESSÍVEL</b>.</span>";
                else ltrAcessibilidade.Text = "<span style='color:green;'>Sistema ativo e <b>DISPONÍVEL</b>!.</span>";
            }
            catch { ltrAcessibilidade.Text = "<span style='color:red;'>O Banco de dados está <b>INACESSÍVEL</b>.</span>"; }
        }

        protected void btnLogar_Click(object sender, EventArgs e)
        {
            bool deuErro = false;
            string _Mensagem = "";
            try
            {
                StringBuilder sErr = new StringBuilder();
                if (String.IsNullOrEmpty(txtLogin.Text))
                    sErr.Append("Informe o Login.\\r\\n");
                if (String.IsNullOrEmpty(txtSenha.Text))
                    sErr.Append("Informe a Senha.");
                if (String.IsNullOrEmpty(sErr.ToString()))
                {
                    Usuario uLogado = new Usuario();
                    uLogado.SLogin = txtLogin.Text;
                    uLogado.SSenha = txtSenha.Text;
                    uLogado.Logar();
                    Session["uLogado"] = uLogado;
                    _Mensagem = "USUARIO LOGOU NO SISTEMA, USUÁRIO: " + uLogado.SLogin + " / " + uLogado.SNome;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "AlertaSucesso('Você efetuou o login, aguarde enquanto o sistema carrega!');", true);
                }
                else
                    throw new Exception(sErr.ToString());
            }
            catch (Exception ex)
            {
                _Mensagem = "TENTATIVA DE ACESSO INVÁLIDA PARA O USUÁRIO: " + txtLogin.Text + " (" + ex.Message + ").";
                MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this);
                deuErro = true;
            }
            finally
            {
                if (!deuErro)
                {
                    Usuario uLogado = new Usuario();
                    uLogado = Session["uLogado"] as Usuario;
                    if (uLogado != null) GravarLog(0, _Mensagem, "", Util.serializarObjetos(uLogado, uLogado.GetType()), uLogado.GetType());
                    Response.Redirect("~/dashboard");
                }
            }
        }


    }
}