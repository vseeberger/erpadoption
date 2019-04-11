using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Site
{
    public class Util
    {
        public static String serializarObjetos(object objeto, Type tipoDoObjeto)
        {
            String str = "";
            try
            {
                System.IO.StringWriter writer = new System.IO.StringWriter();
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(tipoDoObjeto);
                serializer.Serialize(writer, objeto);

                str = writer.ToString();
                writer.Dispose();
                writer.Close();
            }
            catch { str = ""; }
            return str;
        }

        public static object deserializarObjetos(string objeto, Type tipoDoObjeto)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(tipoDoObjeto);
            using (System.IO.TextReader reader = new System.IO.StringReader(objeto))
            {
                return serializer.Deserialize(reader);
            }
        }

        public static string RetornaSID()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Token.ToString() + "." + DateTime.Now.Ticks;
        }

        public static string SenhaAleatoria(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789{[(/*&%$#@!)]}";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public static string ProximoAgrupadorFormulario()
        {
            String ultimoAgrupador = FWPet.Dao.Conexao.BuscaGenerica("select max(grupo) ultimo from formularios", "ultimo");
            int iProxAgrupador = 0;
            int.TryParse(ultimoAgrupador, out iProxAgrupador);
            return (iProxAgrupador + 1).ToString();
        }

        public static void ReenvioDeSenha(String _LoginDoUsuario, String _EmailDoUsuario, String _NovaSenha)
        {
            try
            {
                Email EmailSuporte = new Email();
                StringBuilder sEmail = new StringBuilder();
                sEmail.AppendLine(" <span style=\"font-family:arial;color:#6B6B6B;\">");
                sEmail.AppendLine(" Nova Senha de acesso <br><br> ");
                sEmail.AppendLine(" <b>Login:</b> " + _LoginDoUsuario + " (" + _EmailDoUsuario + ")<br>");
                sEmail.AppendLine(" <b>Mensagem:</b> " + _NovaSenha + "<br>&nbsp;<br>&nbsp;<br>");
                sEmail.AppendLine(" </span>");

                EmailSuporte.Message.Body = sEmail.ToString();

                EmailSuporte.Message.To.Add(_EmailDoUsuario);
                EmailSuporte.Client.Send(EmailSuporte.Message);
            }
            catch(Exception ex) { throw new Exception("Erro ao enviar e-mail!"); }
        }
    }
}