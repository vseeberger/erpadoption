using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class Default : _Herdar
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                CarregaDashboard();
            }
        }

        protected void CarregaDashboard()
        {
            try
            {
                List<AnimalMedicamento> LstAgendamento = AnimalMedicamento.Dashboard();
                rptMedicamentosPendentes.DataSource = LstAgendamento;
                rptMedicamentosPendentes.DataBind();

                ltrMedicamentosDoDia.Text = LstAgendamento == null ? "0" : LstAgendamento.Count().ToString();

                int iTotalAnimais = Animal.DashboardTotal();
                int iTotalAnimaisTratamento = Animal.DashboardTotalTratamento();
                double dPercAnimaisTratamento = iTotalAnimaisTratamento == 0 ? 0 : (iTotalAnimaisTratamento * 100) / iTotalAnimais;
                int iTotalNovosAnimais = Animal.DashboardNovosAnimais(7);

                ltrTotalAnimais.Text = iTotalAnimais.ToString();
                ltrTotalAnimaisTratamento.Text = iTotalAnimaisTratamento.ToString();
                ltrPercAnimaisTratamento.Text = dPercAnimaisTratamento.ToString("0");
                ltrUltimosAnimaisCadastrados.Text = iTotalNovosAnimais.ToString();

                List<Agenda> LstContatos = Agenda.Pesquisar(Logado().Id);
                rptContatos.DataSource = LstContatos;
                rptContatos.DataBind();

                CarregaListaCompras();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        private void CarregaListaCompras()
        {
            List<Produto> LstProdutos = Produto.Pesquisar(null, null, null, null);
            ddlProduto.DataSource = LstProdutos;
            ddlProduto.DataValueField = "Id";
            ddlProduto.DataTextField = "TextoDashboard";
            ddlProduto.DataBind();

            if (LstProdutos != null && LstProdutos.Count > 0) ddlProduto.SelectedIndex = 0;
            txtProdutoQuantidade.Text = "1";

            PedidoCompra _EmAberto = PedidoCompra.ObterAberto();
            if (_EmAberto != null)
            {
                txtPedidoCompraAtivo.Value = _EmAberto.Id.ToString();
                rptComprar.DataSource = _EmAberto.LstProdutos;
                rptComprar.DataBind();
                pnlListaCompra.Visible = _EmAberto.LstProdutos == null || _EmAberto.LstProdutos.Count <= 0;
            }
            else
            {
                pnlListaCompra.Visible = true;
                txtPedidoCompraAtivo.Value = "0";
                rptComprar.DataSource = null;
                rptComprar.DataBind();
            }
        }

        protected void lnkConfirmar_Command(object sender, CommandEventArgs e)
        {
            try
            {
                if(e.CommandName.ToString() == "ConfirmarMedicamento")
                {
                    long l;
                    long.TryParse(e.CommandArgument.ToString(), out l);
                    AnimalMedicamento _AniMed = new AnimalMedicamento(l);
                    _AniMed.QuemMedicou = new Usuario(Logado().Id);
                    _AniMed.ConfirmarMedicacao();

                    CarregaDashboard();
                    throw new ExceptionSucesso("Dados salvos com sucesso!");
                }
            }
            catch(ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected void lnkImprimirAgenda_Click(object sender, EventArgs e)
        {
            try
            {
                List<AnimalMedicamento> LstAgendamento = AnimalMedicamento.Dashboard();
                if (LstAgendamento != null && LstAgendamento.Count > 0)
                    Imprimir(LstAgendamento, LstAgendamento.GetType(), "~/Relatorios/AgendamentosDoDia.xslt", this);
                else
                    throw new Exception("Nenhum agendamento pendente para hoje!");
            }
            catch (ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected void btnIncluirProduto_Click(object sender, EventArgs e)
        {
            try
            {
                long l; int i;
                PedidoCompraItens _ItemCompra = new PedidoCompraItens()
                {
                    Produto = new Produto(long.TryParse(ddlProduto.SelectedValue.ToString(), out l) ? l : 0),
                    IdPedido = long.TryParse(txtPedidoCompraAtivo.Value.ToString(), out l) ? l : 0,
                    IQuantidade = int.TryParse(txtProdutoQuantidade.Text, out i) ? i : 0,
                    Status = true,
                    UsuarioSolicitante = Logado(),
                };

                _ItemCompra.Inserir();
                
                CarregaListaCompras();
            }
            catch (ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void lnkImprimirListaCompras_Click(object sender, EventArgs e)
        {
            try
            {
                PedidoCompra _Compra = PedidoCompra.ObterAberto();
                if (_Compra != null && _Compra.Id > 0)
                    Imprimir(_Compra, _Compra.GetType(), "~/Relatorios/ListaDeComprasDashboard.xslt", this);
                else
                    throw new Exception("Nenhuma lista de compras para impressão!");
            }
            catch (ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}