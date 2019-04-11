using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Log : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                txtDataInicio.Text = DateTime.Today.ToString("dd/MM/yyyy");
                txtDataFinal.Text = DateTime.Today.ToString("dd/MM/yyyy");
                txtQuantidadeRegistros.Text = "10";
                CarregarDados();
            }
        }
        
        protected void lnkCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                CarregarDados();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        private void CarregarDados()
        {
            try
            {
                DateTime dtmPeriodoInicio = new DateTime();
                DateTime dtmPeriodoFinal = new DateTime();
                int _Registros = 0;
                int.TryParse(txtQuantidadeRegistros.Text, out _Registros);

                if (cbxPeriodo.Checked)
                {
                    DateTime.TryParse(txtDataInicio.Text, out dtmPeriodoInicio);
                    DateTime.TryParse(txtDataFinal.Text, out dtmPeriodoFinal);
                }

                List<Logs> Lst = new List<Logs>();
                Lst.AddRange(Logs.Pesquisar(dtmPeriodoInicio, dtmPeriodoFinal, null, null, null, _Registros));

                pnlVazio.Visible = Lst.Count == 0;

                rptResultado.DataSource = Lst;
                rptResultado.DataBind();
            }
            finally
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString("ddMMyyyyHHmmss"), "<script> $('.tabelasdinamicas').DataTable();</script>", false);
            }
        }
    }
}