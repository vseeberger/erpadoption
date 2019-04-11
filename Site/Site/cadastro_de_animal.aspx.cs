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
    public partial class cadastro_de_animal : _Herdar
    {
        private static Animal _Origem;
        private Animal _Animal
        {
            get
            {
                long l;
                int i;
                DateTime dtm;
                Animal item = new Animal()
                {
                    Id = long.TryParse(txtCodigo.Text, out l) ? l : 0,
                    SNome = txtNome.Text,
                    Especie = new Especie(int.TryParse(ddlEspecie.SelectedValue.ToString(), out i) ? i : 0),
                    Raca = new Raca(int.TryParse(ddlRaca.SelectedValue.ToString(), out i) ? i : 0),
                    CSexo = rdFem.Checked ? 'F' : 'M',
                    Responsavel = new Responsavel(long.TryParse(ddlResponsavel.SelectedValue.ToString(), out l) ? l : 0),
                    SObservacoes = txtObservacoes.Text,

                    SNumeroChip = txtNumeroChip.Text,
                    SCor = txtCorDoAnimal.Text,
                    DtmChegou = DateTime.TryParse(txtDataChegou.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmResgate = DateTime.TryParse(txtDataResgate.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmNascimento = DateTime.TryParse(txtDataNascimento.Text, out dtm) ? (DateTime?)dtm : null,
                    Porte = new Porte(int.TryParse(ddlPorte.SelectedValue.ToString(), out i) ? i : 0),
                    Situacao = new Disponibilidade(int.TryParse(ddlSituacao.SelectedValue.ToString(), out i) ? i : 0),
                    Castrado = cbxCastrado.Checked,
                    Status = int.TryParse(ddlStatus.SelectedValue.ToString(), out i) ? i == 1 : false,
                };

                if (item.Especie == null || item.Especie.Id <= 0) throw new Exception("Atenção! Você deve informar uma espécie.");
                if (item.Raca == null || item.Raca.Id <= 0) throw new Exception("Atenção! Você deve informar uma raça.");
                //if (item.Responsavel == null || item.Responsavel.Id <= 0) throw new Exception("Atenção! Você deve informar um padrinho/responsável.");

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");

                return item;
            }
            set
            {
                List<Especie> LstEspecie = new List<Especie>();
                LstEspecie.Add(new Especie(-1, "Selecione uma Especie"));
                LstEspecie.AddRange(Especie.Pesquisar());
                ddlEspecie.DataSource = LstEspecie;
                ddlEspecie.DataValueField = "Id";
                ddlEspecie.DataTextField = "SDescricao";
                ddlEspecie.DataBind();

                List<Raca> LstRaca = new List<Raca>();
                LstRaca.Add(new Raca(-1, "Selecione uma Raça"));
                LstRaca.AddRange(Raca.Pesquisar());
                ddlRaca.DataSource = LstRaca;
                ddlRaca.DataTextField = "SDescricao";
                ddlRaca.DataValueField = "Id";
                ddlRaca.DataBind();

                List<Porte> LstPorte = new List<Porte>();
                LstPorte.Add(new Porte(-1, "Selecione o Porte"));
                LstPorte.AddRange(Porte.Pesquisar());
                ddlPorte.DataSource = LstPorte;
                ddlPorte.DataValueField = "Id";
                ddlPorte.DataTextField = "SDescricao";
                ddlPorte.DataBind();

                List<Responsavel> LstResponsavel = new List<Responsavel>();
                LstResponsavel.Add(new Responsavel(-1, "Selecione o Padrinho/Responsavel"));
                LstResponsavel.AddRange(Responsavel.Pesquisar());
                ddlResponsavel.DataSource = LstResponsavel;
                ddlResponsavel.DataValueField = "Id";
                ddlResponsavel.DataTextField = "SNome";
                ddlResponsavel.DataBind();

                ddlSituacao.DataSource = Disponibilidade.Lista();
                ddlSituacao.DataValueField = "Id";
                ddlSituacao.DataTextField = "SDescricao";
                ddlSituacao.DataBind();

                _Anamnese = null;
                _Vacina = null;
                _Exame = null;

                List<Anamnese> LstAnamnese = null;
                List<AnimalVacina> LstVacinas = null;
                List<Exame> LstExames = null;
                List<AnimalFotos> LstFotos = null;
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SNome;
                    ddlEspecie.SelectedValue = value.Especie.Id.ToString();
                    ddlRaca.SelectedValue = value.Raca == null ? "" : value.Raca.Id.ToString();

                    #region Sexo
                    if (value.CSexo == 'F')
                    {
                        rdFem.Checked = true;
                        lblSMasc.Attributes.Add("class", "btn");
                        lblSFemi.Attributes.Add("class", "btn active");
                    }
                    else if (value.CSexo == 'M')
                    {
                        rdMasc.Checked = true;
                        lblSMasc.Attributes.Add("class", "btn active");
                        lblSFemi.Attributes.Add("class", "btn");
                    }
                    else
                    {
                        lblSMasc.Attributes.Add("class", "btn");
                        lblSFemi.Attributes.Add("class", "btn");
                    }
                    #endregion

                    if (value.Responsavel != null) ddlResponsavel.SelectedValue = value.Responsavel.Id.ToString();
                    txtObservacoes.Text = value.SObservacoes;
                    txtNumeroChip.Text = value.SNumeroChip;
                    txtCorDoAnimal.Text = value.SCor;
                    txtDataChegou.Text = value.DtmChegou == null ? "" : value.DtmChegou.Value.ToString("dd/MM/yyyy");
                    txtDataResgate.Text = value.DtmResgate == null ? "" : value.DtmResgate.Value.ToString("dd/MM/yyyy");
                    txtDataNascimento.Text = value.DtmNascimento == null ? "" : value.DtmNascimento.Value.ToString("dd/MM/yyyy");
                    ddlPorte.SelectedValue = value.Porte == null ? "" : value.Porte.Id.ToString();
                    ddlSituacao.SelectedValue = value.Situacao == null ? "" : value.Situacao.Id.ToString();
                    cbxCastrado.Checked = value.Castrado;
                    ddlStatus.SelectedValue = value.Status ? "1" : "0";

                    LstAnamnese = Anamnese.Pesquisar(value.Id);
                    LstVacinas = AnimalVacina.Pesquisar(value.Id);
                    LstExames = Exame.Pesquisar(value.Id);
                    LstFotos = AnimalFotos.Pesquisar(value.Id);
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    cbxCastrado.Checked = false;
                    txtCorDoAnimal.Text = "";
                    txtNome.Text = "";
                    txtNumeroChip.Text = "";
                    txtObservacoes.Text = "";

                    #region Sexo
                    rdFem.Checked = false;
                    rdMasc.Checked = true;
                    lblSMasc.Attributes.Add("class", "btn active");
                    lblSFemi.Attributes.Add("class", "btn");
                    #endregion

                    ddlResponsavel.SelectedIndex = 0;
                    txtObservacoes.Text = "";
                    txtNumeroChip.Text = "";
                    txtCorDoAnimal.Text = "";
                    txtDataChegou.Text = "";
                    txtDataResgate.Text = "";
                    txtDataNascimento.Text = "";
                    ddlPorte.SelectedIndex = 0;
                    ddlSituacao.SelectedIndex = 0;
                    cbxCastrado.Checked = false;
                    ddlStatus.SelectedValue = "1";

                    aAnamnese.Visible = false;
                    aExames.Visible = false;
                    aVacinas.Visible = false;
                    aFotos.Visible = false;
                }

                rptAnamneses.DataSource = LstAnamnese;
                rptAnamneses.DataBind();

                rptVacinas.DataSource = LstVacinas;
                rptVacinas.DataBind();

                rptExames.DataSource = LstExames;
                rptExames.DataBind();

                rptFotos.DataSource = LstFotos;
                rptFotos.DataBind();
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = Request.QueryString.ToString();
                _Anamnese = null;
                _Origem = null;
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    Animal __item = Animal.Obter(i);
                    _Animal = __item;
                    _Origem = __item;
                }
                else
                    _Animal = null;
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsAnimais");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Animal o = _Animal;
                o.Salvar();
                Type tipo = o.GetType();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O REGISTRO DO ANIMAL, CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);

                //MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsAnimais", "/CadastroDeAnimal");
                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Sucesso, this);
                _Animal = o;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("CadastroDeAnimal");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        #region Anamnese
        private Anamnese _Anamnese
        {
            get
            {
                long l; int i; decimal dc; DateTime d;

                if (!DateTime.TryParse(txtAnamneseData.Text, out d) || d == new DateTime()) throw new Exception("Data de realização da ANAMNESE incorreta ou não preenchida.");
                if (!long.TryParse(ddlAnamneseVeterinario.SelectedValue.ToString(), out l) || l <= 0) throw new Exception("Informe o Veterinário que realizou a ANAMNESE.");
                Anamnese item = new Anamnese()
                {
                    Id = long.TryParse(txtAnamneseCodigo.Text, out l) ? l : 0,
                    DtmRealizacao = d,
                    SAnamnese = txtAnamnese.Text,
                    SDescricao = txtAnamneseDescricao.Text,
                    DPeso = decimal.TryParse(txtAnamnesePeso.Text, out dc) ? dc : 0,
                    Veterinario = new Veterinario(long.TryParse(ddlAnamneseVeterinario.SelectedValue.ToString(), out l) ? l : 0, ddlAnamneseVeterinario.SelectedItem.Text)
                };
                return item;
            }
            set
            {
                List<Veterinario> LstVet = new List<Veterinario>();
                LstVet.Add(new Veterinario(-1, "Selecione um veterinário"));
                LstVet.AddRange(Veterinario.Pesquisar());
                ddlAnamneseVeterinario.DataSource = LstVet;
                ddlAnamneseVeterinario.DataValueField = "Id";
                ddlAnamneseVeterinario.DataTextField = "SNome";
                ddlAnamneseVeterinario.DataBind();

                if (value == null)
                {
                    txtAnamneseCodigo.Text = "AUTOMÁTICO";
                    txtAnamnese.Text = "";
                    txtAnamneseDescricao.Text = "";
                    txtAnamnesePeso.Text = "";
                    txtAnamneseData.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    ddlAnamneseVeterinario.SelectedIndex = 0;
                    btnAnamneseSalvar.Enabled = true;
                    btnAnamneseSalvar.Visible = true;
                }
                else
                {
                    txtAnamneseCodigo.Text = value.Id.ToString();
                    txtAnamnese.Text = value.SAnamnese;
                    txtAnamneseDescricao.Text = value.SDescricao;
                    txtAnamnesePeso.Text = value.DPeso == null ? "" : value.DPeso.Value.ToString("#0.000");
                    txtAnamneseData.Text = value.DtmRealizacao.ToString("dd/MM/yyyy");
                    ddlAnamneseVeterinario.SelectedValue = value.Veterinario.Id.ToString();

                    btnAnamneseSalvar.Enabled = false;
                    btnAnamneseSalvar.Visible = false;
                }
            }
        }
        protected void btnAnamneseSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Anamnese __o = _Anamnese;
                __o.Animal = _Animal;
                __o.Salvar();

                long l;
                long.TryParse(txtAnamneseCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " A ANAMNESE " + __o.Id + " AO REGISTRO DO ANIMAL CÓDIGO: " + __o.Animal.Id, "", Util.serializarObjetos(__o, __o.GetType()), __o.GetType());

                _Anamnese = null;

                rptAnamneses.DataSource = Anamnese.Pesquisar(_Animal.Id);
                rptAnamneses.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "$('#" + aAnamnese.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlerta(ex.Message.ToString(), Mensagens.Erro, pnlAnamneseErro, ltrAnamnese); }
        }
        protected void rptAnamneses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                long l;
                switch (e.CommandName)
                {
                    case "Visualizar":
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        Anamnese _anamneseVer = Anamnese.Obter(l);
                        _Anamnese = _anamneseVer;
                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "$('#MAnamnese').modal('show');", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " fnAbrir('botaoAbreAnamnese');", true);
                        break;

                    case "Apagar":
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        Anamnese __o = new Anamnese(l);
                        __o.Excluir();

                        GravarLog(3, " A ANAMNESE " + __o.Id + " DO REGISTRO DO ANIMAL CÓDIGO: " + txtCodigo.Text, "", "", __o.GetType());


                        long.TryParse(txtCodigo.Text, out l);
                        rptAnamneses.DataSource = Anamnese.Pesquisar(l);
                        rptAnamneses.DataBind();
                        break;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " $('#" + aAnamnese.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
        protected void btnInserirAnamnese_Click(object sender, EventArgs e)
        {
            try
            {
                _Anamnese = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "fnAbrir('botaoAbreAnamnese'); $('#" + aAnamnese.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }
        #endregion

        #region Vacina
        private AnimalVacina _Vacina
        {
            get
            {
                long l; DateTime dtm;
                int i = 0;
                if (!DateTime.TryParse(txtVacinaDataAgendada.Text, out dtm)) i++;
                if (!DateTime.TryParse(txtVacinaDataAplicacao.Text, out dtm)) i++;

                if (i > 1) throw new Exception("A vacina deve ter a data de APLICAÇÃO ou AGENDAMENTO informada.");
                if (!int.TryParse(ddlVacinas.SelectedValue.ToString(), out i) || i <= 0) throw new Exception("Você deve informar a vacina que será aplicada.");

                AnimalVacina item = new AnimalVacina()
                {
                    Id = long.TryParse(txtVacinaCodigo.Text, out l) ? l : 0,
                    AnimvalVacinado = _Animal,
                    IdAnimal = _Animal.Id,
                    Aplicado = cbxVacinaAplicada.Checked,
                    IDoseAplicada = int.Parse(txtVacinaDose.Text.Trim()),
                    ITotalDoses = int.Parse(txtVacinaTotalDeDoses.Text.Trim()),
                    Vacina = new Produto(int.Parse(ddlVacinas.SelectedValue.ToString()), ddlVacinas.SelectedItem.Text),
                    DtmAgendamento = DateTime.TryParse(txtVacinaDataAgendada.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmAplicacao = DateTime.TryParse(txtVacinaDataAplicacao.Text, out dtm) ? (DateTime?)dtm : null,
                    Status = true
                };

                if (item.DtmAplicacao != null && item.DtmAplicacao != new DateTime()) item.Aplicado = true;
                if (item.Aplicado && (item.DtmAplicacao == null || item.DtmAplicacao == new DateTime())) item.Aplicado = false;


                return item;
            }
            set
            {
                List<Produto> LstVacinas = new List<Produto>();
                LstVacinas.Add(new Produto(0, "selecione uma vacina"));
                LstVacinas.AddRange(Produto.Pesquisar(null, null, true, null));
                ddlVacinas.DataSource = LstVacinas;
                ddlVacinas.DataTextField = "SNome";
                ddlVacinas.DataValueField = "Id";
                ddlVacinas.DataBind();

                if (value == null)
                {
                    txtVacinaCodigo.Text = "AUTOMATICO";
                    txtVacinaDataAgendada.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    //txtVacinaDataAplicacao.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtVacinaDose.Text = "1";
                    txtVacinaTotalDeDoses.Text = "1";
                    ddlVacinas.SelectedIndex = 0;
                    cbxVacinaAplicada.Checked = false;
                }
                else
                {
                    txtVacinaCodigo.Text = value.Id.ToString();
                    txtVacinaDataAgendada.Text = value.DtmAgendamento == null || value.DtmAgendamento == new DateTime() ? "" : value.DtmAgendamento.Value.ToString("dd/MM/yyyy");
                    txtVacinaDataAplicacao.Text = value.DtmAplicacao == null || value.DtmAplicacao == new DateTime() ? "" : value.DtmAplicacao.Value.ToString("dd/MM/yyyy");
                    txtVacinaDose.Text = value.IDoseAplicada.ToString();
                    txtVacinaTotalDeDoses.Text = value.ITotalDoses.ToString();
                    ddlVacinas.SelectedValue = value.Vacina.Id.ToString();
                    cbxVacinaAplicada.Checked = value.Aplicado;
                }
            }
        }

        protected void btnVacinaSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalVacina _vacinaItem = _Vacina;
                _vacinaItem.Salvar();
                
                long l;
                long.TryParse(txtVacinaCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " A VACINA " + _vacinaItem.Id + " AO REGISTRO DO ANIMAL CÓDIGO: " + _vacinaItem.IdAnimal, "", Util.serializarObjetos(_vacinaItem, _vacinaItem.GetType()), _vacinaItem.GetType());
                
                _Vacina = null;

                rptVacinas.DataSource = AnimalVacina.Pesquisar(_Animal.Id);
                rptVacinas.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "$('#" + aVacinas.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnInserirVacina_Click(object sender, EventArgs e)
        {
            try
            {
                _Vacina = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "fnAbrir('botaoAbreVacina'); $('#" + aVacinas.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void rptVacinas_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Visualizar":
                        long l;
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        AnimalVacina _animVac = AnimalVacina.Obter(l);
                        _Vacina = _animVac;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " fnAbrir('botaoAbreVacina');", true);
                        break;

                    case "Apagar":
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        AnimalVacina _anamV = new AnimalVacina(l);
                        _anamV.Excluir();
                        
                        GravarLog(3, " A VACINA " + _anamV.Id + " DO REGISTRO DO ANIMAL CÓDIGO: " + txtCodigo.Text, "", "",_anamV.GetType());
                        
                        long.TryParse(txtCodigo.Text, out l);
                        rptVacinas.DataSource = AnimalVacina.Pesquisar(l);
                        rptVacinas.DataBind();
                        break;
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " $('#" + aVacinas.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void ddlVacinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                long i;
                if (long.TryParse(ddlVacinas.SelectedValue.ToString(), out i))
                {
                    int k;
                    Produto _vacinaItem = Produto.Obter(i);
                    int.TryParse(txtVacinaDose.Text, out k);
                    if (k > _vacinaItem.IQuantidadeDoses) txtVacinaDose.Text = _vacinaItem.IQuantidadeDoses.ToString();

                    txtVacinaTotalDeDoses.Text = _vacinaItem.IQuantidadeDoses.ToString();
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void cbxVacinaAplicada_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxVacinaAplicada.Checked)
            {
                if (String.IsNullOrEmpty(txtVacinaDataAplicacao.Text)) txtVacinaDataAplicacao.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
            else txtVacinaDataAplicacao.Text = "";
        }

        protected void txtVacinaDataAplicacao_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtVacinaDataAplicacao.Text)) cbxVacinaAplicada.Checked = false;
            else cbxVacinaAplicada.Checked = true;
        }
        #endregion

        #region Exame
        private Exame _Exame
        {
            get
            {
                long l; DateTime dtm;
                int i = 0;
                if (!DateTime.TryParse(txtExameDataAgendada.Text, out dtm)) i++;
                if (!DateTime.TryParse(txtExameDataRealizada.Text, out dtm)) i++;

                if (i > 1) throw new Exception("O exame deve ter a data de REALIZAÇÃO ou AGENDAMENTO informada.");
                if (!int.TryParse(ddlExameLaboratorios.SelectedValue.ToString(), out i) || i <= 0) throw new Exception("Você deve informar o LABORATÓRIO.");
                if (String.IsNullOrEmpty(txtExameDescricao.Text.Trim())) throw new Exception("Informe a descrição do exame.");
                if (String.IsNullOrEmpty(txtExameTecnicoAssinou.Text.Trim())) throw new Exception("Informe o téncico que assina o exame.");

                Exame item = new Exame()
                {
                    Id = long.TryParse(txtAnamneseCodigo.Text, out l) ? l : 0,
                    SCorpoExame = txtExameCorpo.Text,
                    SDescricao = txtExameDescricao.Text,
                    SProfissionalQueAssinou = txtExameTecnicoAssinou.Text,
                    Status = true,
                    Animal = _Animal,
                    DtmAgendamento = DateTime.TryParse(txtExameDataAgendada.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmRealizacao = DateTime.TryParse(txtExameDataRealizada.Text, out dtm) ? (DateTime?)dtm : null,
                    Tipo = new ExameTipo() { Id = int.Parse(ddlExameTipo.SelectedValue.ToString()) },
                    Laboratorio = new LaboratorioClinico(long.Parse(ddlExameLaboratorios.SelectedValue.ToString()), ddlExameLaboratorios.SelectedItem.Text),
                };

                if (int.Parse(ddlExameVeterinario.SelectedValue.ToString()) == 0)
                    item.ProfissionalQueRequisitou = new Veterinario(long.Parse(ddlExameVeterinario.SelectedValue.ToString()), ddlExameVeterinario.SelectedItem.Text);

                return item;
            }
            set
            {
                List<ExameTipo> LstTipos = ExameTipo.Lista();
                ddlExameTipo.DataSource = LstTipos;
                ddlExameTipo.DataValueField = "Id";
                ddlExameTipo.DataTextField = "SDescricao";
                ddlExameTipo.DataBind();

                List<LaboratorioClinico> LstClinicas = new List<LaboratorioClinico>();
                LstClinicas.Add(new LaboratorioClinico(0, "selecione um laboratório"));
                LstClinicas.AddRange(LaboratorioClinico.Pesquisar());
                ddlExameLaboratorios.DataSource = LstClinicas;
                ddlExameLaboratorios.DataValueField = "Id";
                ddlExameLaboratorios.DataTextField = "SNomeFantasia";
                ddlExameLaboratorios.DataBind();

                List<Veterinario> LstVet = new List<Veterinario>();
                LstVet.Add(new Veterinario(0, "selecione um veterinário"));
                LstVet.AddRange(Veterinario.Pesquisar());
                ddlExameVeterinario.DataSource = LstVet;
                ddlExameVeterinario.DataValueField = "Id";
                ddlExameVeterinario.DataTextField = "SNome";
                ddlExameVeterinario.DataBind();

                if (value == null)
                {
                    txtExameCodigo.Text = "AUTOMATICO";
                    ddlExameTipo.SelectedIndex = 0;
                    ddlExameLaboratorios.SelectedIndex = 0;
                    ddlExameVeterinario.SelectedIndex = 0;
                    txtExameDataAgendada.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtExameDataRealizada.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    txtExameDescricao.Text = "";
                    txtExameTecnicoAssinou.Text = "";
                    txtExameCorpo.Text = "";
                    ltrExameAnexo.Text = "";
                }
                else
                {
                    txtExameCodigo.Text = value.Id.ToString();
                    ddlExameTipo.SelectedValue = value.Tipo == null ? "0" : value.Tipo.Id.ToString();
                    ddlExameLaboratorios.SelectedValue = value.Laboratorio == null ? "0" : value.Laboratorio.Id.ToString();
                    ddlExameVeterinario.SelectedValue = value.ProfissionalQueRequisitou == null ? "0" : value.ProfissionalQueRequisitou.Id.ToString();
                    txtExameDataAgendada.Text = value.DtmAgendamento == null || value.DtmAgendamento == new DateTime() ? "" : value.DtmAgendamento.Value.ToString("dd/MM/yyyy");
                    txtExameDataRealizada.Text = value.DtmRealizacao == null || value.DtmRealizacao == new DateTime() ? "" : value.DtmRealizacao.Value.ToString("dd/MM/yyyy");
                    txtExameDescricao.Text = value.SDescricao;
                    txtExameTecnicoAssinou.Text = value.SProfissionalQueAssinou;
                    txtExameCorpo.Text = value.SCorpoExame;
                    //value.Anexo
                    hdfExaneAnexo.Value = value.SPathAnexo;
                    if (!String.IsNullOrEmpty(value.SPathAnexo)) ltrExameAnexo.Text = "<a href='" + value.SPathAnexo + "'>Abrir Anexo</a>";
                }
            }
        }
        protected void rptExames_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                long l;
                switch (e.CommandName)
                {
                    case "Visualizar":
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        Exame _animEx = Exame.Obter(l);
                        _Exame = _animEx;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " fnAbrir('botaoAbreExame');", true);
                        break;

                    case "Apagar":
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        Exame _anamV = new Exame(l);
                        _anamV.Excluir();

                        GravarLog(3, " O EXAME " + _anamV.Id + " DO REGISTRO DO ANIMAL CÓDIGO: " + _anamV.Animal.Id, "", "",_anamV.GetType());

                        long.TryParse(txtCodigo.Text, out l);
                        rptExames.DataSource = Exame.Pesquisar(l);
                        rptExames.DataBind();
                        break;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " $('#" + aExames.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { _Herdar.RegistrarJavascripts(this); }
        }

        protected void btnInserirExame_Click(object sender, EventArgs e)
        {
            try
            {
                _Exame = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "fnAbrir('botaoAbreExame'); $('#" + aExames.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { _Herdar.RegistrarJavascripts(this); }
        }
        protected void btnExameSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Exame _ExameItem = _Exame;

                if (fupExameAnexo.HasFile)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(fupExameAnexo.FileName);

                    String _NovoNomeDoArquivo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String _NovoNomeCheck = _NovoNomeDoArquivo;
                    String _DestinoDoArquivo = Server.MapPath("~/Arquivos/Exames");

                    int conta = 0;
                    while (System.IO.File.Exists(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension))
                    {
                        conta++;
                        _NovoNomeCheck = _NovoNomeDoArquivo + "_" + conta;
                    }

                    fupExameAnexo.SaveAs(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension);
                    _ExameItem.SPathAnexo = _DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension;
                }
                else
                    _ExameItem.SPathAnexo = hdfExaneAnexo.Value;

                _ExameItem.Salvar();

                long l;
                long.TryParse(txtExameCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O EXAME " + _ExameItem.Id + " AO REGISTRO DO ANIMAL CÓDIGO: " + _ExameItem.Animal.Id, "", Util.serializarObjetos(_ExameItem, _ExameItem.GetType()), _ExameItem.GetType());

                _Exame = null;

                rptExames.DataSource = Exame.Pesquisar(_Animal.Id);
                rptExames.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "$('#" + aExames.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { _Herdar.RegistrarJavascripts(this); }
        }
        #endregion

        #region Fotos
        protected void lnkInserirFoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(FileUpload1.FileName);

                    String _NovoNomeDoArquivo = DateTime.Now.ToString("yyyyMMddHHmmss");
                    String _NovoNomeCheck = _NovoNomeDoArquivo;
                    String _DestinoDoArquivo = Server.MapPath("~/Arquivos/Fotos");

                    int conta = 0;
                    while (System.IO.File.Exists(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension))
                    {
                        conta++;
                        _NovoNomeCheck = _NovoNomeDoArquivo + "_" + conta;
                    }

                    FileUpload1.SaveAs(_DestinoDoArquivo + "/" + _NovoNomeCheck + fi.Extension);
                    AnimalFotos _Foto = new AnimalFotos()
                    {
                        Animal = _Animal,
                        SExtensao = fi.Extension,
                        SNome_novo_arquivo = _NovoNomeCheck,
                        SNome_original_arquivo = FileUpload1.FileName,
                    };



                    _Foto.BArquivo = FileUpload1.FileBytes;

                    _Foto.Salvar();

                    GravarLog(1, " A FOTO " + _Foto.Id + " AO REGISTRO DO ANIMAL CÓDIGO: " + _Foto.Animal.Id, "", Util.serializarObjetos(_Foto, _Foto.GetType()), _Foto.GetType());

                    rptFotos.DataSource = AnimalFotos.Pesquisar(_Foto.Animal.Id);
                    rptFotos.DataBind();
                }
                else throw new Exception("Nenhum arquivo de foto foi escolhido.");

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " $('#" + aVacinas.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { _Herdar.RegistrarJavascripts(this); }
        }

        protected void rptFotos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                switch (e.CommandName)
                {
                    case "Apagar":
                        long l;
                        long.TryParse(e.CommandArgument.ToString(), out l);
                        AnimalFotos _anamV = new AnimalFotos(l);
                        _anamV.Excluir();

                        GravarLog(3, " A FOTO " + _anamV.Id + " DO REGISTRO DO ANIMAL CÓDIGO: " + _anamV.Animal.Id, "", "", _anamV.GetType());

                        long.TryParse(txtCodigo.Text, out l);
                        rptVacinas.DataSource = AnimalFotos.Pesquisar(l);
                        rptVacinas.DataBind();
                        break;
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), " $('#" + aFotos.ClientID + "').click();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { _Herdar.RegistrarJavascripts(this); }
        }
        #endregion
    }
}