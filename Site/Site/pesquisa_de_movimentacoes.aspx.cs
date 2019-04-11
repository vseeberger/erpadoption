using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWPet.Model;

namespace Site
{
    public partial class pesquisa_de_movimentacoes : _Herdar
    {
        protected void txtPeriodoBusca_TextChanged(object sender, EventArgs e)
        {
            try { AtualizarContas(); RegistrarJavascripts(this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(Request.QueryString["p"]))
                    txtPeriodoBusca.Text = DateTime.Today.ToString("MM/yyyy");
                else
                {
                    DateTime dtm = Convert.ToDateTime("01/" + Request.QueryString["p"]);
                    if (dtm != new DateTime())
                        txtPeriodoBusca.Text = dtm.ToString("MM/yyyy");
                    else
                        txtPeriodoBusca.Text = DateTime.Today.ToString("MM/yyyy");
                }
                AtualizarContas();
            }
        }

        private void AtualizarContas()
        {
            try
            {
                DateTime dtmAtual = Convert.ToDateTime("01/" + txtPeriodoBusca.Text);
                DateTime dtmAnterior = dtmAtual.AddMonths(-1);

                /*
                "DR" - Despesa E Receita
                "R", "D" - Receita / Despesa
                "DV" - Despesa Variavel                
                "DP" - Despesa Com Pessoal
                "DF" - Despesa Fixa
                 */
                String sModelo = "<span class='label label-pill label-success'>{0}</span>";
                List<ContaPagarReceber> LstTodasAsContas = ContaPagarReceber.Pesquisar(null, dtmAtual, 1);
                LstTodasAsContas = LstTodasAsContas.OrderBy(w => w.DtmPrevisao).ToList();

                List<ContaPagarReceber> LstContaAtual = LstTodasAsContas.Where(w => w.SCustoOuLucro == "L").ToList();
                ltrQntRecebimentos.Text = String.Format(sModelo, (LstContaAtual == null ? 0 : LstContaAtual.Count()).ToString());
                gdvReceitas.DataSource = LstContaAtual;
                gdvReceitas.DataBind();

                sModelo = "<span class='label label-pill label-danger'>{0}</span>";
                LstContaAtual = LstTodasAsContas.Where(w => w.SCustoOuLucro == "C" && (w.Classificacao != null && w.Classificacao.SClassificacao == "DF")).ToList();
                ltrQtdDespesaFixa.Text = String.Format(sModelo, (LstContaAtual == null ? 0 : LstContaAtual.Count()).ToString());
                gdvDespesaFixa.DataSource = LstContaAtual;
                gdvDespesaFixa.DataBind();

                LstContaAtual = LstTodasAsContas.Where(w => w.SCustoOuLucro == "C" && (w.Classificacao != null && w.Classificacao.SClassificacao == "DV")).ToList();
                ltrQtdDespesaVariavel.Text = String.Format(sModelo, (LstContaAtual == null ? 0 : LstContaAtual.Count()).ToString());
                gdvDespesaVariavel.DataSource = LstContaAtual;
                gdvDespesaVariavel.DataBind();

                LstContaAtual = LstTodasAsContas.Where(w => w.SCustoOuLucro == "C" && (w.Classificacao != null && w.Classificacao.SClassificacao != "DF" && w.Classificacao.SClassificacao != "DV")).ToList();
                ltrQtdDespesas.Text = String.Format(sModelo, (LstContaAtual == null ? 0 : LstContaAtual.Count()).ToString());
                gdvDespesaComPessoal.DataSource = LstContaAtual;
                gdvDespesaComPessoal.DataBind();

                ltrPeriodoMesAtual.Text = dtmAtual.ToString("MMMM") + " / " + dtmAtual.ToString("yyyy");

                if (LstTodasAsContas == null)
                {
                    ltrMesAtual.Text = 0.ToString("#0.00");
                }
                else
                {
                    //Saldo do mês atual - APENAS O PREVISTO para o mês (ou seja, a soma de tudo que está previsto para o mês, não inclui o realizado).
                    ltrMesAtual.Text = (LstTodasAsContas.Where(w => w.SCustoOuLucro == "L" && w.DtmPrevisao.Month == dtmAtual.Month && w.DtmPrevisao.Year == dtmAtual.Year).Sum(w => w.DValor) - LstTodasAsContas.Where(w => w.SCustoOuLucro == "C" && w.DtmPrevisao.Month == dtmAtual.Month && w.DtmPrevisao.Year == dtmAtual.Year).Sum(w => w.DValor)).ToString("#0.00");

                    //Separa as contas
                    List<ContaPagarReceber> LstContasRealizadas = LstTodasAsContas.Where(w => w.DtmPagamentoRecebimento != null && w.Situacao == 1).ToList();
                    List<ContaPagarReceber> LstContasPrevistas = LstTodasAsContas.Where(w => (w.DtmPrevisao.Month == dtmAtual.Month && w.DtmPrevisao.Year == dtmAtual.Year) || (w.DtmPagamentoRecebimento != null && (w.DtmPagamentoRecebimento.Value.Month == dtmAtual.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAtual.Year))).ToList();

                    //Carrega as entradas
                    ltrRecebimentoRealizado.Text = LstContasRealizadas.Where(w => w.DtmPagamentoRecebimento.Value.Month == dtmAtual.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAtual.Year && w.SCustoOuLucro == "L").Sum(w => w.DValor).ToString("#0.00");
                    ltrRecebimentoPrevisto.Text = LstContasPrevistas.Where(w => w.SCustoOuLucro == "L").Sum(w => w.DValor).ToString("#0.00");

                    //Carrega TODAS as saídas
                    ltrSaidasRealizado.Text = LstContasRealizadas.Where(w => w.DtmPagamentoRecebimento.Value.Month == dtmAtual.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAtual.Year && w.SCustoOuLucro == "C").Sum(w => w.DValor).ToString("#0.00");
                    ltrSaidasPrevisto.Text = LstContasPrevistas.Where(w => w.SCustoOuLucro == "C").Sum(w => w.DValor).ToString("#0.00");

                    //Carrega as despesas de forma separada por classificação
                    ltrTotalDespesaPessoalRealizado.Text = LstContasRealizadas.Where(w => w.DtmPagamentoRecebimento.Value != null && w.DtmPagamentoRecebimento.Value.Month == dtmAtual.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAtual.Year && w.SCustoOuLucro == "C" && w.Situacao == 1 && w.Classificacao != null && w.Classificacao.SClassificacao == "DP").Sum(w => w.DValor).ToString("#0.00");
                    ltrTotalDespesaPessoalPrevisto.Text = LstContasPrevistas.Where(w => w.SCustoOuLucro == "C" && w.Classificacao != null && w.Classificacao.SClassificacao == "DP").Sum(w => w.DValor).ToString("#0.00");

                    ltrTotalDespesaVariavelRealizado.Text = LstContasRealizadas.Where(w => w.SCustoOuLucro == "C" && w.Classificacao != null && w.Classificacao.SClassificacao == "DV").Sum(w => w.DValor).ToString("#0.00");
                    ltrTotalDespesaVariavelPrevisto.Text = LstContasPrevistas.Where(w => w.SCustoOuLucro == "C" && w.Classificacao != null && w.Classificacao.SClassificacao == "DV").Sum(w => w.DValor).ToString("#0.00");

                    ltrTotalDespesaFixaRealizado.Text = LstContasRealizadas.Where(w => w.SCustoOuLucro == "C" && w.Classificacao != null && w.Classificacao.SClassificacao == "DF").Sum(w => w.DValor).ToString("#0.00");
                    ltrTotalDespesaFixaPrevisto.Text = LstContasPrevistas.Where(w => w.SCustoOuLucro == "C" && w.Classificacao != null && w.Classificacao.SClassificacao == "DF").Sum(w => w.DValor).ToString("#0.00");
                }

                List<ContaPagarReceber> LstMesAnterior = ContaPagarReceber.Pesquisar(null, dtmAnterior, 0);
                if (LstMesAnterior == null)
                {
                    ltrMesAnterior.Text = 0.ToString("#0.00");
                }
                else
                {
                    ltrMesAnterior.Text = (LstMesAnterior.Where(w => w.SCustoOuLucro == "L" && w.Situacao == 1 && w.DtmPagamentoRecebimento != null && w.DtmPagamentoRecebimento.Value.Month == dtmAnterior.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAnterior.Year).Sum(w => w.DValor) - LstMesAnterior.Where(w => w.SCustoOuLucro == "C" && w.Situacao == 1 && w.DtmPagamentoRecebimento != null && w.DtmPagamentoRecebimento.Value.Month == dtmAnterior.Month && w.DtmPagamentoRecebimento.Value.Year == dtmAnterior.Year).Sum(w => w.DValor)).ToString("#0.00");
                }

            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnContaAReceber_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("ContaAReceber?p=" + txtPeriodoBusca.Text);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnLancarDespesa_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("ContaAPagar?p=" + txtPeriodoBusca.Text);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void _RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.CommandArgument.ToString()))
                {
                    long l;
                    long.TryParse(e.CommandArgument.ToString(), out l);

                    if (l > 0)
                    {
                        if (e.CommandName.ToString() == "AlterarSaida")
                            Redirecionar("ContaAPagar?" + l + "&p=" + txtPeriodoBusca.Text);
                        else if (e.CommandName.ToString() == "AlterarEntrada")
                            Redirecionar("ContaAReceber?" + l + "&p=" + txtPeriodoBusca.Text);
                        else if (e.CommandName.ToString() == "RemoverConta")
                        {
                            if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                            ContaPagarReceber o = new ContaPagarReceber(l);
                            o.Excluir();
                            Type tipo = o.GetType();
                            GravarLog(3, " A CONTA A PAGAR/RECEBER CODIGO " + o.Id, null, Util.serializarObjetos(o, tipo), tipo);
                        }
                    }
                    else
                        throw new Exception("Não foi possível localizar o código identificador.");
                }
                else
                    throw new Exception("Não foi possível localizar o código identificador.");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}