using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class estoque_almoxarifado : _Herdar
    {
        private EstoqueItem _Item
        {
            get
            {
                EstoqueItem item = new EstoqueItem();

                return item;
            }
            set
            {
                //Carrega os produtos
                List<Produto> _Produtos = Produto.Pesquisar(null, null, null, null);
                ddlMovimentacaoProduto.DataSource = _Produtos;
                ddlMovimentacaoProduto.DataTextField = "TextoDashboard";
                ddlMovimentacaoProduto.DataValueField = "Id";
                ddlMovimentacaoProduto.DataBind();

                hdfMovimentacaoItemID.Value = "0";
                ddlMovimentacaoTipo.SelectedIndex = 0;
                ddlMovimentacaoProduto.SelectedIndex = 0;
                txtMovimentacaoValor.Text = "0.00";
                txtMovimentacaoQtd.Text = "0";
                txtMovimentacaoTotal.Text = 0.ToString("0.00");
                txtMovimentacaoEndereco.Text = "";
                
                if (value != null)
                {
                    
                }
            }
        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                _Item = null;
                //CarregarLista();
            }
        }

        private void CarregarLista()
        {
            //int iQuantidade;
            //int.TryParse(txtQuantidadeRegistros.Text, out iQuantidade);
            ////-----------------------------------------------//
            //String sTipo = "";
            //if (rbtTiposConsumo.Checked) sTipo = "C";
            //if (rbtTiposMercadoria.Checked) sTipo = "M";
            //if (rbtTiposServico.Checked) sTipo = "S";
            //if (rbtTiposImobilizado.Checked) sTipo = "I";
            ////-----------------------------------------------//
            //bool? _Medicamento = null;
            //bool? _Vacina = null;
            //bool? _PesquisarOU = null;
            //if (rbtTipos2Medicamento.Checked) { _Medicamento = true; _PesquisarOU = null; }
            //if (rbtTipos2NaoMedicamento.Checked) { _Vacina = true; _PesquisarOU = true; }
            //if (rbtTipos2Vacina.Checked) { _Vacina = true; _PesquisarOU = null; }
            //if (rbtTipos2NaoVacina.Checked) { _Medicamento = true; _PesquisarOU = true; }
            ////-----------------------------------------------//
            //bool? _Status = null;
            //if (rbtStatusAtivo.Checked) _Status = true;
            //if (rbtStatusInativo.Checked) _Status = false;
            ////-----------------------------------------------//
            //List<EstoqueItem> Lst = EstoqueItem.BuscarEstoque(sTipo, _Medicamento, _Vacina, _PesquisarOU, _Status, iQuantidade);
            //rptResultado.DataSource = Lst;
            //rptResultado.DataBind();
            //pnlVazio.Visible = Lst == null || Lst.Count == 0;
        }

        protected void rptResultado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                throw new Exception("Atenção! Operação não implementada.");
                //switch (e.CommandName)
                //{
                //    case "Alterar":
                //        Response.Redirect("~/CadastroDeAnimal?" + e.CommandArgument);
                //        break;
                //    case "Remover":
                //        if (!AcessoTela().Excluir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                //        long l = long.Parse(e.CommandArgument.ToString());
                //        Animal _an = new Animal(l);
                //        _an.Excluir();
                //        CarregarLista();
                //        break;
                //}
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnAddMedicamento_Click(object sender, EventArgs e)
        {

        }
    }
}