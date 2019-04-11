using FWPet.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_escala_lote : _Herdar
    {
        public static int Percent { get; set; }
        public static List<Colaborador> LstColaboradores;
        public static List<Dias> LstDiasMes;
        public List<Dias> RetornaListaDiasMes(long _Colab)
        {
            List<Dias> Lista = new List<Dias>();
            if (LstDiasMes != null)
            {
                Colaborador _Colaborador = LstColaboradores.FirstOrDefault(w => w.Id == _Colab);
                for (int i = 0; i < LstDiasMes.Count; i++)
                {
                    Lista.Add(new Dias()
                    {
                        Colab = _Colaborador,
                        Dia = LstDiasMes[i].Dia,
                        Dtm = LstDiasMes[i].Dtm,
                        FimDeSemana = LstDiasMes[i].FimDeSemana,
                        Trabalha = TrabalhaDia(LstDiasMes[i].Dtm, LstColaboradores.FirstOrDefault(w => w.Id == _Colab))
                    });
                }
            }
            return Lista;
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                txtPeriodo.Text = DateTime.Today.ToString("MM/yyyy");
                //txtPeriodo_TextChanged(null, null);
            }
            txtPeriodo_TextChanged(null, null);
        }

        protected void txtPeriodo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                List<Colaborador> LstColab = Colaborador.Pesquisar();
                LstColaboradores = LstColab;
                rpt.DataSource = LstColab;
                rpt.DataBind();

                DateTime dtm;
                if (DateTime.TryParse("01/" + txtPeriodo.Text, out dtm) && dtm != new DateTime())
                {
                    DateTime dtmInicio = dtm;
                    DateTime dtmFinal = dtmInicio.AddMonths(1).AddDays(-1);
                    LstDiasMes = new List<Dias>();
                    while (dtmInicio <= dtmFinal)
                    {
                        LstDiasMes.Add(new Dias() { Dtm = dtmInicio, Dia = dtmInicio.Day, FimDeSemana = (dtmInicio.DayOfWeek == DayOfWeek.Sunday || dtmInicio.DayOfWeek == DayOfWeek.Saturday) });
                        dtmInicio = dtmInicio.AddDays(1);
                    }
                }

            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            ((LinkButton)sender).Enabled = false;
            
            String sBarra = "<div class=\"progress-bar progress-bar-striped active\" role=\"progressbar\" aria-valuenow=\"{0}\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width:{0}%\">{0}%</div>";
            decimal dAndamento = 0;
            try
            {
                long cod;
                DateTime dtm;
                List<Dias> LstTrabalharDia = new List<Dias>();
                if (rpt.Controls.Count > 0)
                {
                    #region Monta a lista de dias por colaborador
                    for (int i = 0; i < rpt.Controls.Count; i++)
                    {
                        if (rpt.Controls[i].Controls.Count > 0)
                        {
                            for (int j = 0; j < rpt.Controls[i].Controls.Count; j++)
                            {
                                if (rpt.Controls[i].Controls[j].GetType() == typeof(Repeater))
                                {
                                    Repeater _rpt2 = rpt.Controls[i].Controls[j] as Repeater;
                                    if (_rpt2.Controls.Count > 0)
                                    {
                                        for (int k = 0; k < _rpt2.Controls.Count; k++)
                                        {
                                            if (_rpt2.Controls[k].Controls.Count > 0)
                                            {
                                                String _Colab = "";
                                                String _Dtm = "";
                                                bool _Trabalha = false;
                                                for (int l = 0; l < _rpt2.Controls[k].Controls.Count; l++)
                                                {
                                                    if (_rpt2.Controls[k].Controls[l].GetType() == typeof(HiddenField))
                                                        _Dtm = (_rpt2.Controls[k].Controls[l] as HiddenField).Value;

                                                    if (_rpt2.Controls[k].Controls[l].GetType() == typeof(TextBox))
                                                        _Colab = (_rpt2.Controls[k].Controls[l] as TextBox).Text;


                                                    if (_rpt2.Controls[k].Controls[l].GetType() == typeof(CheckBox))
                                                        _Trabalha = (_rpt2.Controls[k].Controls[l] as CheckBox).Checked;
                                                }

                                                if (_Trabalha)
                                                {
                                                    LstTrabalharDia.Add(new Dias()
                                                    {
                                                        Colab = new Colaborador(long.TryParse(_Colab, out cod) ? cod : 0),
                                                        Trabalha = _Trabalha,
                                                        Dtm = DateTime.TryParse(_Dtm, out dtm) ? dtm : new DateTime(),
                                                    });
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    if (LstTrabalharDia.Count > 0)
                    {
                        int iTotalReg = LstTrabalharDia.Count;
                        ColaboradorEscala _Escala = null;
                        for (int i = 0; i < LstTrabalharDia.Count; i++)
                        {
                            //System.Threading.Thread.Sleep(1000);
                            Dias __dia = LstTrabalharDia[i];
                            if(__dia != null && __dia.Trabalha)
                            {
                                _Escala = new ColaboradorEscala()
                                {
                                    DtmInicio = Convert.ToDateTime(__dia.Dtm.ToString("dd/MM/yyyy") + " " + __dia.Colab.SHoraTrabalhoInicio),
                                    DtmFinal = Convert.ToDateTime(__dia.Dtm.ToString("dd/MM/yyyy") + " " + __dia.Colab.SHoraTrabalhoTermino),
                                    IdColaborador = __dia.Colab.Id,
                                    SNomeColaborador = __dia.Colab.SNome,
                                    SDescricao = "Escala de trabalho",
                                    Status = true
                                };
                                Percent = int.Parse(dAndamento.ToString());

                                dAndamento = (100 * (i+1)) / iTotalReg;
                                StringBuilder stb = new StringBuilder();
                                
                            }
                        }
                        dAndamento = 100;
                        Redirecionar("/Escalas");
                    }
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("Escalas");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        public bool TrabalhaDia(DateTime dtm, Colaborador colab)
        {
            try
            {
                if (colab != null)
                {
                    if (dtm.DayOfWeek == DayOfWeek.Sunday && colab.EscalaDomingo) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Monday && colab.EscalaSegunda) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Tuesday && colab.EscalaTerca) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Wednesday && colab.EscalaQuarta) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Thursday && colab.EscalaQuinta) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Friday && colab.EscalaSexta) return true;
                    else if (dtm.DayOfWeek == DayOfWeek.Saturday && colab.EscalaSabado) return true;
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            return false;
        }

        public class Dias
        {
            private int dia;
            private bool fimDeSemana;
            private DateTime dtm;
            private Colaborador colab;
            private bool trabalha;
            public int Dia
            {
                get { return dia; }
                set { dia = value; }
            }
            public bool FimDeSemana
            {
                get { return fimDeSemana; }
                set { fimDeSemana = value; }
            }
            public DateTime Dtm
            {
                get { return dtm; }
                set { dtm = value; }
            }
            public Colaborador Colab
            {
                get { return colab; }
                set { colab = value; }
            }
            public bool Trabalha
            {
                get { return trabalha; }
                set { trabalha = value; }
            }
        }
    }
}