using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_escala : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                RegistrarJS(this, "/js/lib/eonasdan-bootstrap-datetimepicker/bootstrap-datetimepicker.min.js");
                RegistrarJS(this, "/js/lib/fullcalendar/fullcalendar.min.js");
                RegistrarJS(this, "/js/lib/fullcalendar/locale-all.js");

                txtData.Text = "";
                txtHoraAte.Text = "";
                txtHoraDe.Text = "";

                List<Colaborador> LstColaboradores = new List<Colaborador>();
                LstColaboradores.Add(new Colaborador(0, "selecione o colaborador"));
                LstColaboradores.AddRange(Colaborador.Pesquisar());
                ddlColaborador.DataSource = LstColaboradores;
                ddlColaborador.DataValueField = "Id";
                ddlColaborador.DataTextField = "SNome";
                ddlColaborador.DataBind();

                string sCod = Request.QueryString.ToString();
                long l;
                if(long.TryParse(sCod, out l) && l > 0)
                {
                    ColaboradorEscala escala = ColaboradorEscala.Obter(l);
                    _Escala = escala;
                }
            }
        }

        private ColaboradorEscala _Escala
        {
            get
            {
                if (String.IsNullOrEmpty(txtHoraDe.Text)) throw new Exception("Você não informou a hora de início da escala");
                if (String.IsNullOrEmpty(txtHoraDe.Text)) throw new Exception("Você não informou a hora de término da escala");

                long l;
                DateTime dtm;
                ColaboradorEscala item = new ColaboradorEscala()
                {
                    Id = long.TryParse(txtCodigoEscala.Text, out l) ? l : 0,
                    DtmInicio = DateTime.TryParse(txtData.Text + " " + txtHoraDe.Text, out dtm) ? dtm : new DateTime(),
                    DtmFinal = DateTime.TryParse(txtData.Text + " " + txtHoraAte.Text, out dtm) ? (DateTime?)dtm : null,
                    IdColaborador = long.TryParse(ddlColaborador.SelectedValue, out l) ? l : 0,
                    SNomeColaborador = ddlColaborador.SelectedItem.Text,
                    Status = true
                };

                if (item.DtmInicio == new DateTime()) throw new Exception("Você não informou a data da escala.");
                if (item.IdColaborador == 0) throw new Exception("Você não selecionou o colaborador.");

                return item;
            }
            set
            {
                if (value == null)
                {
                    txtCodigoEscala.Text = "AUTOMATICO";
                    txtData.Text = "";
                    txtHoraDe.Text = "";
                    txtHoraAte.Text = "";
                    ddlColaborador.SelectedValue = "0";
                }
                else
                {
                    txtCodigoEscala.Text = value.Id.ToString();
                    txtData.Text = value.DtmInicio == null ? "" : value.DtmFinal.Value.ToString("dd/MM/YYYY");
                    txtHoraDe.Text = value.DtmInicio.ToString("HH:mm");
                    txtHoraAte.Text = value.DtmFinal == null ? "" : value.DtmFinal.Value.ToString("HH:mm");
                    ddlColaborador.SelectedValue = value.IdColaborador == null ? "0" : value.IdColaborador.Value.ToString();
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ColaboradorEscala o = _Escala;
                o.Salvar();
                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Sucesso, this, "/Escalas");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                _Escala = null;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
        
        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ColaboradorEscala o = _Escala;
                if (o.Id > 0) o.Excluir();
                else _Escala = null;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("EscalaLote");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}