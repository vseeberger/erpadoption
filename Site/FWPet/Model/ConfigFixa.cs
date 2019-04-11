using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace FWPet.Model
{
    public class ConfigFixa
    {
        public static string PastaProdutos = ConfigurationManager.AppSettings["PastaProdutos"].ToString();
        public static string PastaFotos = ConfigurationManager.AppSettings["PastaFotos"].ToString();
        public static string PastaExames = ConfigurationManager.AppSettings["PastaExames"].ToString();
        
        //PARAMETROS DE E-MAIL
        public static string EmailServidor = ConfigurationManager.AppSettings["MHost"].ToString();
        public static string EmailEndereco = ConfigurationManager.AppSettings["MUser"].ToString();
        public static string EmailSenha = ConfigurationManager.AppSettings["MPass"].ToString();
        public static int EmailPorta = int.Parse(ConfigurationManager.AppSettings["MPort"].ToString());
        public static string EmailNome = ConfigurationManager.AppSettings["MName"].ToString();
        public static bool EmailSSL = bool.Parse(ConfigurationManager.AppSettings["MSSL"].ToString());
        public static string EmailEnderecoErros = ConfigurationManager.AppSettings["EmailDestinoErros"].ToString();
    }
}
