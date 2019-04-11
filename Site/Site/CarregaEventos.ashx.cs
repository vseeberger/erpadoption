using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Site
{
    /// <summary>
    /// Summary description for CarregaEventos
    /// </summary>
    public class CarregaEventos : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s1 = context.Request.QueryString["start"];
            string s2 = context.Request.QueryString["end"];

            //String sprint = @" [{ 'Teste': " + s1 + ", 'Teste2': " + s2 + "}] ";
            //DateTime dtmInicio = Convert.ToDateTime(s1);
            //DateTime dtmFinal = Convert.ToDateTime(s2);
            context.Response.Write(FWPet.Model.ColaboradorEscala.JsonEscalas(s1, s2, 0));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}