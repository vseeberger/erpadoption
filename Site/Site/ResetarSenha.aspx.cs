using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class ResetarSenha : _Herdar
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtLogin.Text = "";
            }
        }

        protected void btnResetar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario _Resetar = new Usuario() { SLogin = txtLogin.Text };
                String sSenhaN = Util.SenhaAleatoria(6);
                _Resetar.SSenha = sSenhaN;
                _Resetar.ResetarSenha();

                ReenvioDeSenha(_Resetar.SLogin, _Resetar.SEmail, sSenhaN);

                MensagemAlertaPopup("Os dados foram enviados com sucesso.", Mensagens.Sucesso, this, "/entrar");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        private void ReenvioDeSenha(string sLogin, string sEmail, string sSenhaN)
        {
            try
            {
                MailMessage oEmail = new MailMessage();
                string EmailServidor = System.Configuration.ConfigurationManager.AppSettings["MHost"].ToString();
                string EmailEndereco = System.Configuration.ConfigurationManager.AppSettings["MUser"].ToString();
                string EmailSenha = System.Configuration.ConfigurationManager.AppSettings["MPass"].ToString();
                int EmailPorta = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MPort"].ToString());
                string EmailNome = System.Configuration.ConfigurationManager.AppSettings["MName"].ToString();
                bool EmailSSL = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["MSSL"].ToString());


                MailAddress sDe = new MailAddress(EmailEndereco + "", EmailNome + ""); /*COLOQUE AQUI UMA CAIXA VALIDA @seudomínio PARA QUE O ENVIO SEJA REALIZADO DE MODO NORMALIZADO*/
                MailAddress sRpt = new MailAddress(EmailEndereco, EmailNome);

                oEmail.To.Add(new MailAddress(sEmail, sLogin)); //DIGITE AQUI O E-MAIL PARA O QUAL SERÁ ENCAMINHADO O FORMULARIO
                oEmail.From = sDe;
                oEmail.ReplyTo = sRpt;
                oEmail.Priority = MailPriority.Normal;
                oEmail.IsBodyHtml = true;
                oEmail.Subject = "Ame Um Pet: Senha de acesso resetada com sucesso!";

                // Monta o corpo da mensagem a ser enviada
                StringBuilder mensagem = new StringBuilder();
                mensagem.AppendLine("E-mail: " + sEmail);
                mensagem.AppendLine("Login: " + sLogin);
                mensagem.AppendLine("Nova Senha: " + sSenhaN);

                oEmail.Body = mensagem.ToString();

                SmtpClient oEnviar = new SmtpClient();
                oEnviar.Host = EmailServidor; //DIGITE AQUI O NOME DO SERVIDOR DE SMTP QUE VOCÊ IRA UTILIZAR
                oEnviar.Credentials = new System.Net.NetworkCredential(EmailEndereco, EmailSenha); // DIGITE UM E-MAIL VÁLIDO E UMA SENHA PARA AUTENTICACAO NO SERVIDOR SMTP
                oEnviar.Send(oEmail);
                oEmail.Dispose();
            }
            catch (SmtpException ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}