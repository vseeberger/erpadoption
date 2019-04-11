using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Instalador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptAndamento.DataSource = null;
                rptAndamento.DataBind();

                string[] sArquivoTables = File.ReadAllLines(Server.MapPath("~/script_table.txt"));
                StringBuilder stb = null;

                List<Andamento> LstAndamentos = new List<Andamento>();

                for (int i = 0; i < sArquivoTables.Length; i++)
                {
                    if (sArquivoTables.Contains("--Criar:") || sArquivoTables.Contains("--Alterar:"))
                    {
                        
                    }
                }
            }
        }

        public partial class Andamento
        {
            private string sTitulo;
            private string sExecutar;
            private DateTime dataHora;
            private bool executado;
            public string STitulo
            {
                get
                {
                    return sTitulo;
                }

                set
                {
                    sTitulo = value;
                }
            }

            public string SExecutar
            {
                get
                {
                    return sExecutar;
                }

                set
                {
                    sExecutar = value;
                }
            }

            public DateTime DataHora
            {
                get
                {
                    return dataHora;
                }

                set
                {
                    dataHora = value;
                }
            }

            public bool Executado
            {
                get
                {
                    return executado;
                }

                set
                {
                    executado = value;
                }
            }
        }
    }
}