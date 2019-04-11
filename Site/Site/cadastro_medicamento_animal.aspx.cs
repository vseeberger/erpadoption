using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_medicamento_animal : _Herdar
    {
        private static List<AnimalMedicamento> _LstMedicamentosDoAnimal;
        private static AnimalMedicamento _Origem;
        private AnimalMedicamento _AnimalMedicamento
        {
            get
            {
                long l; int i; DateTime dtm;

                AnimalMedicamento item = new AnimalMedicamento()
                {
                    AnimalMedicado = new Animal(long.TryParse(ddlAnimal.SelectedValue.ToString(), out l) ? l : 0, ddlAnimal.SelectedItem.Text),
                    SCodAgrupamento = l + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    SPosologia = txtDosagem.Text,
                    Medicamento = new Produto(long.TryParse(ddlMedicamento.SelectedValue.ToString(), out l) ? l : 0, ddlMedicamento.SelectedItem.Text),
                    ITotalDose = int.TryParse(txtDosesPorDia.Text, out i) ? i : 0,
                    IQuantidadeDias = int.TryParse(txtQuantidadeDeDias.Text, out i) ? i : 0,
                    DtmInicio = DateTime.TryParse(txtDataInicio.Text, out dtm) ? (DateTime?)dtm : null,
                    SObservacao = txtObservacao.Text,
                    Tratamento = new AnimalMedicamentoTratamento(int.TryParse(ddlTratamento.SelectedValue, out i) ? i : 0, ddlTratamento.SelectedItem.Text)
                };

                if (item.AnimalMedicado == null || item.AnimalMedicado.Id <= 0) throw new Exception("Você deve escolher o ANIMAL que será medicado.");
                if (item.Medicamento == null || item.Medicamento.Id <= 0) throw new Exception("Você deve escolher o MEDICAMENTO que será utilizado.");
                if (item.IQuantidadeDias <= 0) throw new Exception("A quantidade de dias não é válida (deve ser maior do que zero).");

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");

                return item;
            }
            set
            {
                _LstMedicamentosDoAnimal = new List<AnimalMedicamento>();

                //limpa os campos e carrega os dados de combobox.
                ddlAnimal.DataSource = Animal.Pesquisar(_Status: true);
                ddlAnimal.DataTextField = "SNome";
                ddlAnimal.DataValueField = "Id";
                ddlAnimal.DataBind();

                ddlMedicamento.DataSource = Produto.Pesquisar(null, true, null, null);
                ddlMedicamento.DataTextField = "SNome";
                ddlMedicamento.DataValueField = "Id";
                ddlMedicamento.DataBind();

                ddlTratamento.DataSource = AnimalMedicamentoTratamento.Pesquisar();
                ddlTratamento.DataTextField = "SNome";
                ddlTratamento.DataValueField = "Id";
                ddlTratamento.DataBind();

                if (value == null)
                {
                    ddlAnimal.SelectedIndex = 0;
                    ddlMedicamento.SelectedIndex = 0;
                    ddlTratamento.SelectedIndex = 0;

                    txtCodigo.Text = "AUTOMATICO";
                    txtDataInicio.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtDosagem.Text = "";
                    txtDosesPorDia.Text = "1";
                    txtQuantidadeDeDias.Text = "1";

                    txtCodigo.ReadOnly = false;
                    txtDataInicio.ReadOnly = false;
                    txtDosagem.ReadOnly = false;
                    txtDosesPorDia.ReadOnly = false;
                    txtQuantidadeDeDias.ReadOnly = false;
                }
                else
                {
                    ddlAnimal.SelectedValue = value.AnimalMedicado.Id.ToString();
                    ddlMedicamento.SelectedValue = value.Medicamento.Id.ToString();
                    ddlTratamento.SelectedValue = value.Tratamento == null ? "0" : value.Tratamento.Id.ToString();
                    txtCodigo.Text = value.SCodAgrupamento;
                    txtDataInicio.Text = value.DtmInicio.Value.ToString("dd/MM/yyyy");
                    txtDosagem.Text = value.SPosologia;
                    txtDosesPorDia.Text = value.ITotalDose.ToString();
                    txtQuantidadeDeDias.Text = value.IQuantidadeDias.ToString();

                    txtCodigo.ReadOnly = true;
                    txtDataInicio.ReadOnly = true;
                    txtDosagem.ReadOnly = true;
                    txtDosesPorDia.ReadOnly = true;
                    txtQuantidadeDeDias.ReadOnly = true;
                    lnkSalvar.Enabled = false;
                    lnkSalvar.Visible = false;
                    
                    _LstMedicamentosDoAnimal = value.LstMedicacao == null ? new List<AnimalMedicamento>() : value.LstMedicacao;
                }

                AtualizarListaMedicamentos();
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = Request.QueryString.ToString();
                _Origem = null;
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    AnimalMedicamento itm = AnimalMedicamento.ObterAgrupamento(i);
                    _AnimalMedicamento = itm;
                    _Origem = itm;
                }
                else
                    _AnimalMedicamento = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                List<AnimalMedicamento> Lst = new List<AnimalMedicamento>();
                if (_LstMedicamentosDoAnimal != null && _LstMedicamentosDoAnimal.Count > 0)
                {
                    for (int m = 0; m < _LstMedicamentosDoAnimal.Count; m++)
                    {
                        AnimalMedicamento _Default = _LstMedicamentosDoAnimal[m];

                        int iDiaAtual = 1;
                        int iDoseAtual = 1;
                        for (int i = 0; i < _Default.IQuantidadeDias; i++)
                        {
                            iDoseAtual = 1;
                            for (int j = 0; j < _Default.ITotalDose; j++)
                            {
                                AnimalMedicamento _Novo = new AnimalMedicamento()
                                {
                                    IDose = iDoseAtual,
                                    IDiaAtual = iDiaAtual,
                                    DtmPrevisao = _Default.DtmInicio.Value.AddDays(i),
                                    AnimalMedicado = _Default.AnimalMedicado,
                                    DtmInicio = _Default.DtmInicio,
                                    IQuantidadeDias = _Default.IQuantidadeDias,
                                    ITotalDose = _Default.ITotalDose,
                                    Medicamento = _Default.Medicamento,
                                    SCodAgrupamento = _Default.SCodAgrupamento,
                                    SPosologia = _Default.SPosologia,
                                    Tratamento = _Default.Tratamento,
                                    SObservacao = _Default.SObservacao
                                };

                                Lst.Add(_Novo);
                                iDoseAtual++;
                            }

                            iDiaAtual++;
                        }
                    }
                }
                if (Lst != null && Lst.Count > 0)
                {
                    AnimalMedicamento.Salvar(Lst);
                    for (int i = 0; i < Lst.Count; i++)
                    {
                        Type tipo = Lst[i].GetType();
                        GravarLog(99, "SALVOU O AGENDAMENTO DE MEDICAMENTO (" + Lst[i].Medicamento.SNome + " - " + Lst[i].AnimalMedicado.SNome + "), NO AGRUPAMENTO CÓDIGO: " + Lst[i].SCodAgrupamento, null, Util.serializarObjetos(Lst[i], tipo), tipo);
                    }
                }
                MensagemAlertaPopup("Agendamentos cadastrados com sucesso!", Mensagens.Sucesso, this, "/AgendarMedicamento");
            }
            //catch(ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Pergunta, this, "/TodosOsAgendamentos", "/AgendarMedicamento"); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Redirecionar("TodosOsAgendamentos");
        }

        protected void btnAddMedicamento_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalMedicamento _Default = _AnimalMedicamento;
                _LstMedicamentosDoAnimal.Add(_Default);
                ddlMedicamento.SelectedIndex = 0;
                AtualizarListaMedicamentos();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { _Herdar.RegistrarJavascripts(this); }
        }

        private void AtualizarListaMedicamentos()
        {
            if (_LstMedicamentosDoAnimal.Count > 0) ddlAnimal.Enabled = false;
            else ddlAnimal.Enabled = true;

            rptAgendamentos.DataSource = _LstMedicamentosDoAnimal;
            rptAgendamentos.DataBind();
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            Redirecionar("AgendarMedicamento");
        }
    }
}