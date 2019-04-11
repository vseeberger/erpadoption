using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_conta_pagar : _Herdar
    {
        private static ContaPagarReceber _Origem;
        private ContaPagarReceber _ContaPagar
        {
            get
            {
                decimal d; DateTime dtm; long l; int i;
                ContaPagarReceber item = new ContaPagarReceber()
                {
                    Id = long.TryParse(hdfContaPagarID.Value.ToString(), out l) ? l : 0,
                    SNumeroDocumento = txtContaPagarNumDoc.Text,
                    SCustoOuLucro = "C",
                    SDescricaoReferencia = txtContaPagarDescricao.Text,
                    SMaisDetalhes = txtContaPagarOutrasInformacoes.Text,
                    SNomeDeQuemPagou = txtContaPagarRecebidoDe.Text,
                    DValor = decimal.TryParse(txtContaPagarValor.Text, out d) ? d : 0,
                    DtmCompetencia = DateTime.TryParse(txtContaPagarCompetencia.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmPrevisao = DateTime.TryParse(txtContaPagarDataVencimento.Text, out dtm) ? dtm : DateTime.Today,
                    DtmPagamentoRecebimento = rbContaPagarSim.Checked ? (DateTime?)DateTime.Now : null,
                    Situacao = rbContaPagarSim.Checked ? 1 : 0,
                    Status = true,
                    Conta = int.TryParse(ddlContaPagarConta.SelectedValue.ToString(), out i) && i > 0 ? new ContaBancaria(i) : null,
                    STipoQuemRecebeuPagou = ddlTipoPagamento.SelectedValue.ToString(),
                    IdQuemRecebeuPagou = long.TryParse(ddlPagoPara.SelectedValue.ToString(), out l) ? (long?)l : null,
                };

                if (!String.IsNullOrEmpty(hdfContaPagarDataPagamento.Value.ToString()))
                    item.DtmPagamentoRecebimento = DateTime.TryParse(hdfContaPagarDataPagamento.Value.ToString(), out dtm) ? (DateTime?)dtm : item.DtmPagamentoRecebimento;

                if (int.TryParse(ddlContaPagarFormaPagamento.SelectedValue.ToString(), out i) && i > 0) item.FormaPagRec = new FormaPagamentoRecebimento(i);
                else throw new Exception("Selecione a forma de pagamento.");

                if (int.TryParse(ddlContaPagarClassificacao.SelectedValue.ToString(), out i) && i > 0) item.Classificacao = new OrigemCustos(i);
                else throw new Exception("Selecione a classificação.");

                if (int.TryParse(ddlContaPagarCentroDeCustos.SelectedValue.ToString(), out i) && i > 0) item.CentroDeCustos = new CentroDeCustos(i);

                return item;
            }
            set
            {
                rbContaPagarNao.Checked = true;
                rbContaPagarSim.Checked = false;

                List<CentroDeCustos> LstCentrodecusto;
                List<OrigemCustos> LstOrigem;
                List<ContaBancaria> LstContas;
                List<FormaPagamentoRecebimento> LstFormas;

                LstFormas = new List<FormaPagamentoRecebimento>();
                LstFormas.Add(new FormaPagamentoRecebimento(0, "selecione uma forma de pagamento"));
                LstFormas.AddRange(FormaPagamentoRecebimento.Pesquisar());

                LstContas = new List<ContaBancaria>();
                LstContas.Add(new ContaBancaria(0, "selecione uma conta relacionada"));
                LstContas.AddRange(ContaBancaria.Pesquisar());

                LstOrigem = new List<OrigemCustos>();
                LstOrigem.Add(new OrigemCustos(0, "selecione a classificação", ""));
                LstOrigem.AddRange(OrigemCustos.Pesquisar());

                LstCentrodecusto = new List<CentroDeCustos>();
                LstCentrodecusto.Add(new CentroDeCustos(0, "selecione um centro de custos"));
                LstCentrodecusto.AddRange(CentroDeCustos.Pesquisar());

                ddlContaPagarFormaPagamento.DataSource = LstFormas;
                ddlContaPagarFormaPagamento.DataValueField = "Id";
                ddlContaPagarFormaPagamento.DataTextField = "SDescricao";
                ddlContaPagarFormaPagamento.DataBind();

                ddlContaPagarConta.DataSource = LstContas;
                ddlContaPagarConta.DataValueField = "Id";
                ddlContaPagarConta.DataTextField = "SDescricao";
                ddlContaPagarConta.DataBind();

                ddlContaPagarClassificacao.DataSource = LstOrigem.Where(w => w.SEntradaSaida == "S");
                ddlContaPagarClassificacao.DataTextField = "SDescricao";
                ddlContaPagarClassificacao.DataValueField = "Id";
                ddlContaPagarClassificacao.DataBind();

                ddlContaPagarCentroDeCustos.DataSource = LstCentrodecusto;
                ddlContaPagarCentroDeCustos.DataValueField = "Id";
                ddlContaPagarCentroDeCustos.DataTextField = "SDescricao";
                ddlContaPagarCentroDeCustos.DataBind();

                if (value == null)
                {
                    lblContaPagarsim.Attributes.Add("class", "btn");
                    lblContaPagarNao.Attributes.Add("class", "btn active");

                    ddlContaPagarFormaPagamento.SelectedValue = "0";
                    ddlContaPagarConta.SelectedValue = "0";
                    ddlContaPagarClassificacao.SelectedValue = "0";

                    hdfContaPagarID.Value = "";
                    txtContaPagarNumDoc.Text = "";
                    txtContaPagarDescricao.Text = "";
                    txtContaPagarOutrasInformacoes.Text = "";
                    txtContaPagarRecebidoDe.Text = "";
                    txtContaPagarValor.Text = "0,00";
                    txtContaPagarCompetencia.Text = "";
                    txtContaPagarDataVencimento.Text = "";
                    hdfContaPagarDataPagamento.Value = "";

                    txtContaPagarDataVencimento.ReadOnly = false;
                    txtContaPagarDataVencimento.Enabled = true;

                    ddlTipoPagamento.SelectedIndex = 0;
                    ddlTipoPagamento_SelectedIndexChanged(null, null);
                }
                else
                {
                    lblContaPagarsim.Attributes.Add("class", "btn");
                    lblContaPagarNao.Attributes.Add("class", "btn");

                    if (value.Situacao == 1) { rbContaPagarSim.Checked = true; lblContaPagarsim.Attributes.Add("class", "btn active"); }
                    if (value.Situacao == 0) { rbContaPagarNao.Checked = true; lblContaPagarNao.Attributes.Add("class", "btn active"); }

                    ddlContaPagarFormaPagamento.SelectedValue = value.FormaPagRec == null ? "0" : value.FormaPagRec.Id.ToString();
                    ddlContaPagarConta.SelectedValue = value.Conta == null ? "0" : value.Conta.Id.ToString();
                    ddlContaPagarClassificacao.SelectedValue = value.Classificacao == null ? "0" : value.Classificacao.Id.ToString();

                    hdfContaPagarID.Value = value.Id.ToString();
                    txtContaPagarNumDoc.Text = value.SNumeroDocumento;
                    txtContaPagarDescricao.Text = value.SDescricaoReferencia;
                    txtContaPagarOutrasInformacoes.Text = value.SMaisDetalhes;
                    txtContaPagarRecebidoDe.Text = value.SNomeDeQuemPagou;
                    txtContaPagarValor.Text = value.DValor.ToString("#,#0.00");
                    txtContaPagarCompetencia.Text = value.DtmCompetencia == null ? "" : value.DtmCompetencia.Value.ToString("dd/MM/yyyy");
                    txtContaPagarDataVencimento.Text = value.DtmPrevisao.ToString("dd/MM/yyyy");
                    hdfContaPagarDataPagamento.Value = value.DtmPagamentoRecebimento == null ? "" : value.DtmPagamentoRecebimento.Value.ToString("dd/MM/yyyy");

                    txtContaPagarDataVencimento.ReadOnly = true;
                    txtContaPagarDataVencimento.Enabled = false;
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                String id = Request.QueryString[0].ToString();
                _Origem = null;
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    ContaPagarReceber __item = ContaPagarReceber.Obter(i);
                    _ContaPagar = __item;
                    _Origem = __item;
                }
                else
                    _ContaPagar = null;

                if (!String.IsNullOrEmpty(Request.QueryString["p"]))
                {
                    hdfPeriodoHerdado.Value = Request.QueryString["p"];
                }
            }
        }

        protected void btnContaPagarSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaPagarReceber o = _ContaPagar;
                o.Salvar();

                long l;
                long.TryParse(hdfContaPagarID.Value, out l);
                GravarLog(l == 0 ? 1 : 2, " A CONTA A PAGAR (NUM. DOCUMENTO: " + o.SNumeroDocumento + ") CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodasAsMovimentacoes?" + hdfPeriodoHerdado.Value, "/ContaAPagar?p=" + hdfPeriodoHerdado.Value);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodasAsMovimentacoes?" + hdfPeriodoHerdado.Value);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void ddlTipoPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var _ListaDropdown = sender;
                if (ddlTipoPagamento.SelectedValue.ToString() == "1")
                {
                    List<Empresa> Lst = new List<Empresa>();
                    Lst.Add(new Empresa(0, "selecione um fornecedor"));
                    Lst.AddRange(Empresa.Pesquisar("F"));
                    _ListaDropdown = Lst.ToList();
                }
                else if (ddlTipoPagamento.SelectedValue.ToString() == "4")
                {
                    List<LaboratorioClinico> Lst = new List<LaboratorioClinico>();
                    Lst.Add(new LaboratorioClinico(0, "selecione uma clínica"));
                    Lst.AddRange(LaboratorioClinico.Pesquisar());
                    _ListaDropdown = Lst.ToList();
                }
                else if (ddlTipoPagamento.SelectedValue.ToString() == "5")
                {
                    List<Laboratorio> Lst = new List<Laboratorio>();
                    Lst.Add(new Laboratorio(0, "selecione um laboratório/fabricante"));
                    Lst.AddRange(Laboratorio.Pesquisar());
                    _ListaDropdown = Lst.ToList();
                }
                else if (ddlTipoPagamento.SelectedValue.ToString() == "2")
                {
                    List<Colaborador> Lst = new List<Colaborador>();
                    Lst.Add(new Colaborador(0, "selecione um colaborador"));
                    Lst.AddRange(Colaborador.Pesquisar());
                    _ListaDropdown = Lst.ToList();
                }
                else if (ddlTipoPagamento.SelectedValue.ToString() == "3")
                {
                    List<Responsavel> Lst = new List<Responsavel>();
                    Lst.Add(new Responsavel(0, "selecione um responsavel"));
                    Lst.AddRange(Responsavel.Pesquisar());
                    _ListaDropdown = Lst.ToList();
                }

                RegistrarJavascripts(this);
                //ddlPagoPara.Attributes.Add("class", "form-control select2");
                ddlPagoPara.DataSource = _ListaDropdown;
                ddlPagoPara.DataValueField = "Id";
                ddlPagoPara.DataTextField = "SNome";
                ddlPagoPara.DataBind();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}