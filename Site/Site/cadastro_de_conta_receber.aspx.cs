using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_conta_receber : _Herdar
    {
        private static ContaPagarReceber _Origem;
        private ContaPagarReceber _ContaReceber
        {
            get
            {
                decimal d; DateTime dtm; long l; int i;
                ContaPagarReceber item = new ContaPagarReceber()
                {
                    Id = long.TryParse(hdfContaReceberID.Value.ToString(), out l) ? l : 0,
                    SNumeroDocumento = txtContaReceberNumDoc.Text,
                    SCustoOuLucro = "L",
                    SDescricaoReferencia = txtContaReceberDescricao.Text,
                    SMaisDetalhes = txtContaReceberDetalhes.Text,
                    SNomeDeQuemPagou = txtContaReceberRecebidoDe.Text,
                    //DValor = decimal.TryParse(txtContaReceberValor.Text.Replace(".", "").Replace(",", "."), out d) ? d : 0,
                    DValor = decimal.TryParse(txtContaReceberValor.Text, out d) ? d : 0,
                    DtmCompetencia = DateTime.TryParse(txtContaReceberCompetencia.Text, out dtm) ? (DateTime?)dtm : null,
                    DtmPrevisao = DateTime.TryParse(txtContaReceberDataPrevisao.Text, out dtm) ? dtm : DateTime.Today,
                    DtmPagamentoRecebimento = rdSim.Checked ? (DateTime?)DateTime.Now : null,
                    Situacao = rdSim.Checked ? 1 : 0,
                    Status = true,
                    Conta = int.TryParse(ddlContaReceberContaBancaria.SelectedValue.ToString(), out i) && i > 0 ? new ContaBancaria(i) : null,
                };

                if (!String.IsNullOrEmpty(hdfContaReceberDataPagamento.Value.ToString())) item.DtmPagamentoRecebimento = DateTime.TryParse(hdfContaReceberDataPagamento.Value.ToString(), out dtm) ? (DateTime?)dtm : item.DtmPagamentoRecebimento;

                if (int.TryParse(ddlContaReceberFormaPagamento.SelectedValue.ToString(), out i) && i > 0) item.FormaPagRec = new FormaPagamentoRecebimento(i);
                else throw new Exception("Selecione a forma de pagamento.");

                if (int.TryParse(ddlContaReceberOrigem.SelectedValue.ToString(), out i) && i > 0) item.Classificacao = new OrigemCustos(i);
                else throw new Exception("Selecione a classificação.");

                return item;
            }
            set
            {
                rdNao.Checked = true;
                rdSim.Checked = false;

                List<OrigemCustos> LstOrigem;
                List<ContaBancaria> LstContas;
                List<FormaPagamentoRecebimento> LstFormas;

                LstFormas = new List<FormaPagamentoRecebimento>();
                LstFormas.Add(new FormaPagamentoRecebimento(0, "selecione uma forma de recebimento"));
                LstFormas.AddRange(FormaPagamentoRecebimento.Pesquisar());

                LstContas = new List<ContaBancaria>();
                LstContas.Add(new ContaBancaria(0, "selecione uma conta relacionada"));
                LstContas.AddRange(ContaBancaria.Pesquisar());

                LstOrigem = new List<OrigemCustos>();
                LstOrigem.Add(new OrigemCustos(0, "selecione a classificação", ""));
                LstOrigem.AddRange(OrigemCustos.Pesquisar());

                ddlContaReceberFormaPagamento.DataSource = LstFormas;
                ddlContaReceberFormaPagamento.DataValueField = "Id";
                ddlContaReceberFormaPagamento.DataTextField = "SDescricao";
                ddlContaReceberFormaPagamento.DataBind();

                ddlContaReceberContaBancaria.DataSource = LstContas;
                ddlContaReceberContaBancaria.DataValueField = "Id";
                ddlContaReceberContaBancaria.DataTextField = "SDescricao";
                ddlContaReceberContaBancaria.DataBind();

                ddlContaReceberOrigem.DataSource = LstOrigem.Where(w => w.SEntradaSaida == "E");
                ddlContaReceberOrigem.DataTextField = "SDescricao";
                ddlContaReceberOrigem.DataValueField = "Id";
                ddlContaReceberOrigem.DataBind();

                if (value == null)
                {
                    lblSim.Attributes.Add("class", "btn");
                    lblNao.Attributes.Add("class", "btn active");

                    ddlContaReceberFormaPagamento.SelectedValue = "0";
                    ddlContaReceberContaBancaria.SelectedValue = "0";
                    ddlContaReceberOrigem.SelectedValue = "0";

                    hdfContaReceberID.Value = "";
                    txtContaReceberNumDoc.Text = "";
                    txtContaReceberDescricao.Text = "";
                    txtContaReceberDetalhes.Text = "";
                    txtContaReceberRecebidoDe.Text = "";
                    txtContaReceberValor.Text = "0,00";
                    txtContaReceberCompetencia.Text = "";
                    txtContaReceberDataPrevisao.Text = "";
                    hdfContaReceberDataPagamento.Value = "";

                    txtContaReceberDataPrevisao.ReadOnly = false;
                    txtContaReceberDataPrevisao.Enabled = true;
                }
                else
                {
                    lblSim.Attributes.Add("class", "btn");
                    lblNao.Attributes.Add("class", "btn");
                    if (value.Situacao == 1) { rdSim.Checked = true; lblSim.Attributes.Add("class", "btn active"); }
                    if (value.Situacao == 0) { rdNao.Checked = true; lblNao.Attributes.Add("class", "btn active"); }

                    ddlContaReceberFormaPagamento.SelectedValue = value.FormaPagRec == null ? "0" : value.FormaPagRec.Id.ToString();
                    ddlContaReceberContaBancaria.SelectedValue = value.Conta == null ? "0" : value.Conta.Id.ToString();
                    ddlContaReceberOrigem.SelectedValue = value.Classificacao == null ? "0" : value.Classificacao.Id.ToString();

                    hdfContaReceberID.Value = value.Id.ToString();
                    txtContaReceberNumDoc.Text = value.SNumeroDocumento;
                    txtContaReceberDescricao.Text = value.SDescricaoReferencia;
                    txtContaReceberDetalhes.Text = value.SMaisDetalhes;
                    txtContaReceberRecebidoDe.Text = value.SNomeDeQuemPagou;
                    txtContaReceberValor.Text = value.DValor.ToString("#,#0.00");
                    txtContaReceberCompetencia.Text = value.DtmCompetencia == null ? "" : value.DtmCompetencia.Value.ToString("dd/MM/yyyy");
                    txtContaReceberDataPrevisao.Text = value.DtmPrevisao.ToString("dd/MM/yyyy");
                    hdfContaReceberDataPagamento.Value = value.DtmPagamentoRecebimento == null ? "" : value.DtmPagamentoRecebimento.Value.ToString("dd/MM/yyyy");

                    txtContaReceberDataPrevisao.ReadOnly = true;
                    txtContaReceberDataPrevisao.Enabled = false;
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
                    _ContaReceber = __item;
                    _Origem = __item;
                }
                else
                    _ContaReceber = null;

                if (!String.IsNullOrEmpty(Request.QueryString["p"]))
                {
                    hdfPeriodoHerdado.Value = Request.QueryString["p"];
                }
            }
        }

        protected void btnContaReceberSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaPagarReceber o = _ContaReceber;
                o.Salvar();

                long l;
                long.TryParse(hdfContaReceberID.Value, out l);
                GravarLog(l == 0 ? 1 : 2, " A CONTA A RECEBER (NUM.DOCUMENTO: " + o.SNumeroDocumento + ") CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodasAsMovimentacoes?" + hdfPeriodoHerdado.Value, "/ContaAReceber?p=" + hdfPeriodoHerdado.Value);
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
    }
}