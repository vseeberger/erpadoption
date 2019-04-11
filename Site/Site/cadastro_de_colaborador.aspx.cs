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
    public partial class cadastro_de_colaborador : _Herdar
    {
        private static Colaborador _Origem;
        private Colaborador _Colaborador
        {
            get
            {
                long i; int ii; decimal d;
                DateTime t;
                Colaborador item = new Colaborador()
                {
                    Id = long.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SCelular = txtCelular.Text,
                    SCPF = txtCPF.Text,
                    SEmail = txtEmail.Text,
                    SNome = txtNome.Text,
                    SOutroContato = txtOutroContato.Text,
                    SRG = txtRG.Text,
                    SSexo = rdFem.Checked ? "F" : "M",
                    STelefone = txtTelefone.Text,
                    CTipo = 'R',
                    DtmNascimento = DateTime.TryParse(txtDataNascimento.Text, out t) ? t == new DateTime() ? null : (DateTime?)t : null,
                    Endereco = _Endereco,
                    EscalaDomingo = cbxDomingo.Checked,
                    EscalaSegunda = cbxSegunda.Checked,
                    EscalaTerca = cbxTerca.Checked,
                    EscalaQuarta = cbxQuarta.Checked,
                    EscalaQuinta = cbxQuinta.Checked,
                    EscalaSexta = cbxSexta.Checked,
                    EscalaSabado = cbxSabado.Checked,
                    SHoraTrabalhoInicio = txtDahoraEntrada.Text,
                    SHoraTrabalhoTermino = txtDahoraSaida.Text,
                    BDiarista = cbxDiarista.Checked,
                    BDiaristaRecebeNaDiaria = cbxRecebePagamentoNaDiaria.Checked,
                    DiaPagamento = int.TryParse(txtDiaPagto.Text, out ii) ? ii : Logado().ConfigSis.DiaPagamento,
                    DValor = decimal.TryParse(txtSalario.Text, out d) ? d : Logado().ConfigSis.DValorDiaria,
                    //Add em 06.03.2017
                    DtmAdmissao = DateTime.TryParse(txtDataAdmissao.Text, out t) ? t == new DateTime() ? null : (DateTime?)t : null,
                    DtmDemissao = DateTime.TryParse(txtDataDemissao.Text, out t) ? t == new DateTime() ? null : (DateTime?)t : null,
                    DtmRGExpedicao = DateTime.TryParse(txtRGData.Text, out t) ? t == new DateTime() ? null : (DateTime?)t : null,
                    SRGOrgao = txtRGOrgao.Text,
                    SRGUF = txtRGUF.Text,
                    SCTPS = txtCTPS.Text,
                    SCTPSSerie = txtCTPSSerie.Text,
                    SCTPSUF = txtCTPSUF.Text,
                    SPISPASEP = txtPISPASEP.Text,
                    STitEleitor = txtTitEleitor.Text,
                    STitEleitorSecao = txtTitEleitorSecao.Text,
                    STitEleitorZona = txtTitEleitorZona.Text,
                    Estrangeiro = cbxEstrangeiro.Checked,
                    INumeroFilhos = int.TryParse(txtQtdFilhos.Text, out ii) ? ii : 0,
                    SEstadoCivil = ddlEstadoCivil.SelectedValue,
                    SNacionalidade = txtNacionalidade.Text,
                    SNaturalidade = txtNaturalidade.Text,
                    SNomeMae = txtNomeMae.Text,
                    SNomePai = txtNomePai.Text,
                    SPassaporte = txtPassaporte.Text,
                    STipoSanguineo = txtTipoSanguineo.Text,
                    SUFNascimento = txtNaturalidadeUF.Text,

                };

                item.LstFerias = _LstFerias;
                item.LstDependentes = _LstDependentes;
                item.LstBeneficios = _LstBeneficios;

                object o = rdMasc.Checked;
                o = rdFem.Checked;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                List<PessoaGrauParentesco> _LstParentesco = new List<PessoaGrauParentesco>();
                _LstParentesco.Add(new PessoaGrauParentesco(0, "selecione"));
                _LstParentesco.AddRange(PessoaGrauParentesco.Pesquisar());

                _LstFerias = new List<ColaboradorFerias>();
                _LstDependentes = new List<PessoasDependentes>();

                _LstBeneficios = new List<ColaboradorBeneficioDesconto>();

                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtCelular.Text = "";
                    txtCPF.Text = "";
                    txtEmail.Text = "";
                    txtNome.Text = "";
                    txtOutroContato.Text = "";
                    txtRG.Text = "";

                    rdFem.Checked = false;
                    rdMasc.Checked = true;
                    lblSMasc.Attributes.Add("class", "btn active");
                    lblSFemi.Attributes.Add("class", "btn");

                    txtTelefone.Text = "";
                    txtDataNascimento.Text = "";

                    cbxDomingo.Checked = false;
                    cbxSegunda.Checked = false;
                    cbxTerca.Checked = false;
                    cbxQuarta.Checked = false;
                    cbxQuinta.Checked = false;
                    cbxSexta.Checked = false;
                    cbxSabado.Checked = false;
                    txtDahoraEntrada.Text = "";
                    txtDahoraSaida.Text = "";

                    //_Endereco = null;

                    cbxDiarista.Checked = false;
                    cbxRecebePagamentoNaDiaria.Checked = false;
                    txtDiaPagto.Text = "";
                    txtSalario.Text = "";

                    //Add em 06.03.2017
                    txtDataAdmissao.Text = "";
                    txtDataDemissao.Text = "";
                    txtRGData.Text = "";
                    txtRGOrgao.Text = "";
                    txtRGUF.Text = "";
                    txtCTPS.Text = "";
                    txtCTPSSerie.Text = "";
                    txtCTPSUF.Text = "";
                    txtPISPASEP.Text = "";
                    txtTitEleitor.Text = "";
                    txtTitEleitorSecao.Text = "";
                    txtTitEleitorZona.Text = "";

                    cbxEstrangeiro.Checked = false;
                    txtQtdFilhos.Text = "";
                    ddlEstadoCivil.SelectedValue = "";
                    txtNacionalidade.Text = "";
                    txtNaturalidade.Text = "";
                    txtNomeMae.Text = "";
                    txtNomePai.Text = "";
                    txtPassaporte.Text = "";
                    txtTipoSanguineo.Text = "";
                    txtNaturalidadeUF.Text = "";
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtCelular.Text = value.SCelular;
                    txtCPF.Text = value.SCPF;
                    txtEmail.Text = value.SEmail;
                    txtNome.Text = value.SNome;
                    txtOutroContato.Text = value.SOutroContato;
                    txtRG.Text = value.SRG;

                    if (value.SSexo == "F")
                    {
                        rdFem.Checked = true;
                        lblSMasc.Attributes.Add("class", "btn");
                        lblSFemi.Attributes.Add("class", "btn active");
                    }

                    if (value.SSexo == "M")
                    {
                        rdMasc.Checked = true;
                        lblSMasc.Attributes.Add("class", "btn active");
                        lblSFemi.Attributes.Add("class", "btn");
                    }

                    txtTelefone.Text = value.STelefone;
                    txtDataNascimento.Text = value.DtmNascimento == null || value.DtmNascimento == new DateTime() ? "" : value.DtmNascimento.Value.ToString("dd/MM/yyyy");

                    _Endereco = value.Endereco;

                    cbxDomingo.Checked = value.EscalaDomingo;
                    cbxSegunda.Checked = value.EscalaSegunda;
                    cbxTerca.Checked = value.EscalaTerca;
                    cbxQuarta.Checked = value.EscalaQuarta;
                    cbxQuinta.Checked = value.EscalaQuinta;
                    cbxSexta.Checked = value.EscalaSexta;
                    cbxSabado.Checked = value.EscalaSabado;
                    txtDahoraEntrada.Text = value.SHoraTrabalhoInicio;
                    txtDahoraSaida.Text = value.SHoraTrabalhoTermino;

                    cbxDiarista.Checked = value.BDiarista;
                    cbxRecebePagamentoNaDiaria.Checked = value.BDiaristaRecebeNaDiaria;
                    txtDiaPagto.Text = value.DiaPagamento.ToString();
                    txtSalario.Text = value.DValor.ToString("#,#0.00");

                    //Add em 06.03.2017
                    txtDataAdmissao.Text = value.DtmAdmissao == new DateTime() ? "" : value.DtmAdmissao == null ? "" : value.DtmAdmissao.Value.ToString("dd/MM/yyyy");
                    txtDataDemissao.Text = value.DtmDemissao == new DateTime() ? "" : value.DtmDemissao == null ? "" : value.DtmDemissao.Value.ToString("dd/MM/yyyy");
                    txtRGData.Text = value.DtmRGExpedicao == new DateTime() ? "" : value.DtmRGExpedicao == null ? "" : value.DtmRGExpedicao.Value.ToString("dd/MM/yyyy");
                    txtRGOrgao.Text = value.SRGOrgao;
                    txtRGUF.Text = value.SRGUF;
                    txtCTPS.Text = value.SCTPS;
                    txtCTPSSerie.Text = value.SCTPSSerie;
                    txtCTPSUF.Text = value.SCTPSUF;
                    txtPISPASEP.Text = value.SPISPASEP;
                    txtTitEleitor.Text = value.STitEleitor;
                    txtTitEleitorSecao.Text = value.STitEleitorSecao;
                    txtTitEleitorZona.Text = value.STitEleitorZona;

                    _LstFerias = value.LstFerias;
                    _LstDependentes = value.LstDependentes;
                    _LstBeneficios = value.LstBeneficios;
                    cbxEstrangeiro.Checked = value.Estrangeiro;
                    txtQtdFilhos.Text = value.INumeroFilhos.ToString();
                    ddlEstadoCivil.SelectedValue = value.SEstadoCivil;
                    txtNacionalidade.Text = value.SNacionalidade;
                    txtNaturalidade.Text = value.SNaturalidade;
                    txtNomeMae.Text = value.SNomeMae;
                    txtNomePai.Text = value.SNomePai;
                    txtPassaporte.Text = value.SPassaporte;
                    txtTipoSanguineo.Text = value.STipoSanguineo;
                    txtNaturalidadeUF.Text = value.SUFNascimento;
                }

                ddlDependenteGrauParentesco.DataSource = _LstParentesco;
                ddlDependenteGrauParentesco.DataValueField = "Id";
                ddlDependenteGrauParentesco.DataTextField = "SDescricao";
                ddlDependenteGrauParentesco.DataBind();

                List<BeneficioDesconto> LstBeneficiosDescontos = new List<BeneficioDesconto>();
                LstBeneficiosDescontos.Add(new BeneficioDesconto() { Id = 0, SDescricao = "0" });
                LstBeneficiosDescontos.AddRange(BeneficioDesconto.Pesquisar());
                ddlBeneficios.DataSource = LstBeneficiosDescontos;
                ddlBeneficios.DataValueField = "Id";
                ddlBeneficios.DataTextField = "SDescricao";
                ddlBeneficios.DataBind();

                AtualizaBeneficios();
                AtualizaFerias();
                AtualizaDependente();
            }
        }
        private Endereco _Endereco
        {
            get
            {
                long i;
                Endereco item = new Endereco()
                {
                    Id = long.TryParse(txtEnderecoCodigo.Text, out i) ? i : 0,
                    SBairro = txtEnderecoBairro.Text,
                    SCidade = txtEnderecoCidade.Text,
                    SCEP = txtEnderecoCEP.Text,
                    SComplemento = txtEnderecoComplemento.Text,
                    SEndereco = txtEnderecoLogradouro.Text,
                    SNumero = txtEnderecoNumero.Text,
                    SUF = txtEnderecoUF.Text,
                };

                return item;
            }
            set
            {
                txtEnderecoBairro.ReadOnly = true;
                txtEnderecoCEP.ReadOnly = true;
                txtEnderecoCidade.ReadOnly = true;
                txtEnderecoComplemento.ReadOnly = true;
                txtEnderecoLogradouro.ReadOnly = true;
                txtEnderecoNumero.ReadOnly = true;
                txtEnderecoUF.ReadOnly = true;

                if (value == null)
                {
                    txtEnderecoBairro.Text = "";
                    txtEnderecoCEP.Text = "";
                    txtEnderecoCidade.Text = "";
                    txtEnderecoCodigo.Text = "AUTOMATICO";
                    txtEnderecoComplemento.Text = "";
                    txtEnderecoLogradouro.Text = "";
                    txtEnderecoNumero.Text = "";
                    txtEnderecoUF.Text = "";
                }
                else
                {
                    txtEnderecoBairro.Text = value.SBairro;
                    txtEnderecoCEP.Text = value.SCEP;
                    txtEnderecoCidade.Text = value.SCidade;
                    txtEnderecoCodigo.Text = value.Id.ToString();
                    txtEnderecoComplemento.Text = value.SComplemento;
                    txtEnderecoLogradouro.Text = value.SEndereco;
                    txtEnderecoNumero.Text = value.SNumero;
                    txtEnderecoUF.Text = value.SUF;
                    lnkCarregaCEP.Enabled = false;
                }
            }
        }

        private static List<ColaboradorFerias> _LstFerias;
        private static List<PessoasDependentes> _LstDependentes;
        private static List<ColaboradorBeneficioDesconto> _LstBeneficios;

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = Request.QueryString.ToString();
                _Origem = null;
                int i;
                if (int.TryParse(id, out i) && i > 0)
                {
                    Colaborador itm = Colaborador.Obter(i);
                    _Colaborador = itm;
                    _Origem = itm;
                }
                else
                    _Colaborador = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Colaborador o = _Colaborador;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O COLABORADOR CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsColaboradores", "/CadastroDeColaborador");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodosOsColaboradores");
        }

        protected void btnNovoEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                _Endereco = null;

                txtEnderecoBairro.ReadOnly = false;
                txtEnderecoCEP.ReadOnly = false;
                txtEnderecoCidade.ReadOnly = false;
                txtEnderecoComplemento.ReadOnly = false;
                txtEnderecoLogradouro.ReadOnly = false;
                txtEnderecoNumero.ReadOnly = false;
                txtEnderecoUF.ReadOnly = false;
                lnkCarregaCEP.Enabled = true;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCarregaCEP_Click(object sender, EventArgs e)
        {
            try
            {
                Correios.Net.Address enderecos = Correios.Net.SearchZip.GetAddress(txtEnderecoCEP.Text.Trim().Replace("-", "").Replace(".", ""));
                if (enderecos == null) throw new Exception("Atenção! Endereço não localizado com o CEP informado.");

                txtEnderecoBairro.Text = enderecos.District;
                txtEnderecoCidade.Text = enderecos.City;
                txtEnderecoLogradouro.Text = enderecos.Street;
                txtEnderecoUF.Text = enderecos.State;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        #region Ferias do colaborador
        protected void rptFerias_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Apagar" && !String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    long l;
                    if(long.TryParse(e.CommandArgument.ToString(), out l))
                    {
                        if(_LstFerias != null && _LstFerias.Count > 0)
                        {
                            ColaboradorFerias _Ferias = _LstFerias.FirstOrDefault(w => w.sequencia == l);
                            _Ferias.Status = false;
                            _Ferias.Alterou = true;
                        }
                    }

                    AtualizaFerias();
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void btnFeriasAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtm;
                ColaboradorFerias _Ferias = new ColaboradorFerias()
                {
                    Agendado = true,
                    Status = true,
                    Realizou = false,
                    DtmCompetenciaDe = DateTime.TryParse(txtFeriasCompetenciaDe.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmCompetenciaAte = DateTime.TryParse(txtFeriasCompetenciaAte.Text, out dtm) ? (DateTime?)dtm : null,

                    DtmPeriodoDe = DateTime.TryParse(txtFeriasPeriodoDe.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmPeriodoAte = DateTime.TryParse(txtFeriasPeriodoAte.Text, out dtm) ? (DateTime?)dtm : null,
                    SObservacoes = txtFeriasObservacoes.Text,
                    Alterou = true
                };

                long l = _LstFerias == null || _LstFerias.Count == 0 ? 1 : _LstFerias.Max(w => w.sequencia) + 1;
                _Ferias.sequencia = l;
                StringBuilder stb = new StringBuilder();
                if (_Ferias.DtmPeriodoDe == null || _Ferias.DtmPeriodoDe == new DateTime()) stb.AppendLine("Campo Período DE, não foi informado.");
                if (_Ferias.DtmPeriodoAte == null || _Ferias.DtmPeriodoAte == new DateTime()) stb.AppendLine("Campo Período ATÉ, não foi informado.");
                if (_Ferias.DtmCompetenciaDe == null || _Ferias.DtmCompetenciaDe == new DateTime()) stb.AppendLine("Campo Competência DE, não foi informado.");
                if (_Ferias.DtmCompetenciaAte == null || _Ferias.DtmCompetenciaAte == new DateTime()) stb.AppendLine("Campo Competência ATÉ, não foi informado.");

                if (!String.IsNullOrEmpty(stb.ToString())) { throw new Exception("Os campos são de preenchimento obrigatório:" + stb.ToString()); }

                if (_LstFerias == null) _LstFerias = new List<ColaboradorFerias>();

                _LstFerias.Add(_Ferias);

                txtFeriasCompetenciaDe.Text = "";
                txtFeriasCompetenciaAte.Text = "";
                txtFeriasCompetenciaDe.Text = "";
                txtFeriasCompetenciaAte.Text = "";
                txtFeriasObservacoes.Text = "";

                AtualizaFerias();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void AtualizaFerias()
        {
            List<ColaboradorFerias> _FeriasAux = _LstFerias;
            _FeriasAux = _FeriasAux.Where(w => w.Status == true).ToList();
            pnlFerias.Visible = _FeriasAux == null || _FeriasAux.Count == 0;
            rptFerias.DataSource = _FeriasAux;
            rptFerias.DataBind();
        }

        public static String ContaDiasFerias(DateTime dtmInicio, DateTime dtmFinal)
        {
            TimeSpan ts = new TimeSpan();
            ts = dtmFinal - dtmInicio;
            return ts.Days.ToString();
        }
        #endregion

        #region Dependentes
        protected void btnDependenteAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtm;
                PessoasDependentes _Dependente = new PessoasDependentes()
                {
                    Status = true,
                    Alterou = true,
                    SNome = txtDependenteNome.Text,
                    DtmNascimento = DateTime.TryParse(txtDependenteDataNascimento.Text, out dtm) ? (DateTime?)dtm : null,
                };

                _Dependente.GrauParentesco = new PessoaGrauParentesco(int.Parse(ddlDependenteGrauParentesco.SelectedValue), ddlDependenteGrauParentesco.SelectedItem.Text);

                long l = _LstDependentes == null || _LstDependentes.Count == 0 ? 1 : _LstDependentes.Max(w => w.Sequencia) + 1;
                _Dependente.Sequencia = l;

                StringBuilder stb = new StringBuilder();
                if (String.IsNullOrEmpty(_Dependente.SNome)) stb.AppendLine("Campo Nome não foi informado.");
                if (_Dependente.GrauParentesco == null || _Dependente.GrauParentesco.Id == 0) stb.AppendLine("Campo Parentesco não foi informado.");
                if (!String.IsNullOrEmpty(stb.ToString())) { throw new Exception("Os campos são de preenchimento obrigatório:" + stb.ToString()); }

                if (_LstDependentes == null) _LstDependentes = new List<PessoasDependentes>();
                _LstDependentes.Add(_Dependente);

                txtDependenteNome.Text = "";
                txtDependenteDataNascimento.Text = "";
                ddlDependenteGrauParentesco.SelectedIndex = 0;
                
                AtualizaDependente();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected void AtualizaDependente()
        {
            ddlDependenteGrauParentesco.SelectedIndex = 0;
            List<PessoasDependentes> _LstAux = _LstDependentes;
            _LstAux = _LstAux.Where(w => w.Status == true).ToList();
            pnlDependentes.Visible = _LstAux == null || _LstAux.Count == 0;
            rptDependentes.DataSource = _LstAux;
            rptDependentes.DataBind();
            RegistrarJavascripts(this);
        }

        protected void rptDependentes_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Apagar" && !String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    long l;
                    if (long.TryParse(e.CommandArgument.ToString(), out l))
                    {
                        if (_LstDependentes != null && _LstDependentes.Count > 0)
                        {
                            PessoasDependentes _item = _LstDependentes.FirstOrDefault(w => w.Sequencia == l);
                            _item.Status = false;
                            _item.Alterou = true;
                        }
                    }

                    AtualizaDependente();
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }
        #endregion

        #region Beneficios
        protected void AtualizaBeneficios()
        {
            ddlBeneficios.SelectedIndex = 0;
            List<ColaboradorBeneficioDesconto> _LstAux = _LstBeneficios;
            _LstAux = _LstAux.Where(w => w.Status == true).ToList();
            pnlBeneficios.Visible = _LstAux == null || _LstAux.Count == 0;
            rptBeneficios.DataSource = _LstAux;
            rptBeneficios.DataBind();
            RegistrarJavascripts(this);
        }

        protected void btnBeneficioAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                decimal d;
                ColaboradorBeneficioDesconto item = new ColaboradorBeneficioDesconto()
                {
                    STipo = ddlBeneficioTipo.SelectedValue.ToString(),
                    Id = 0,
                    DValor = decimal.TryParse(txtBeneficioValor.Text, out d) ? d : 0,
                    Status = true,
                    Alterou = true,
                    Beneficio = new BeneficioDesconto(int.TryParse(ddlBeneficios.SelectedValue.ToString(), out i) ? i : 0),
                };

                txtBeneficioValor.Text = "";

                _LstBeneficios.Add(item);
                AtualizaBeneficios();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void rptBeneficios_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Apagar" && !String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    long l;
                    if (long.TryParse(e.CommandArgument.ToString(), out l))
                    {
                        if (_LstDependentes != null && _LstDependentes.Count > 0)
                        {
                            ColaboradorBeneficioDesconto _item = _LstBeneficios.FirstOrDefault(w => w.Sequencia == l);
                            _item.Status = false;
                            _item.Alterou = true;
                        }
                    }

                    AtualizaBeneficios();
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        } 
        #endregion
    }
}