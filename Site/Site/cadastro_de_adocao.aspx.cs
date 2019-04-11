using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_adocao : _Herdar
    {
        private static AnimalAdotado _original;
        private AnimalAdotado _Adocao
        {
            get
            {
                AnimalAdotado _item = new AnimalAdotado();

                return _item;
            }
            set
            {
                List<Adotante> LstAdotantes = Adotante.Pesquisar();
                ddlAdotante.DataSource = LstAdotantes;
                ddlAdotante.DataValueField = "Id";
                ddlAdotante.DataTextField = "SNome";
                ddlAdotante.DataBind();

                long lAnimal = value == null ? 0 : value.Animal == null ? 0 : value.Animal.Id;
                List<Animal> LstAnimais = Animal.Disponiveis(lAnimal);
                ddlAnimal.DataSource = LstAnimais;
                ddlAnimal.DataValueField = "Id";
                ddlAnimal.DataTextField = "SNome";
                ddlAnimal.DataBind();

                if (value == null)
                {
                    //limpa os campos
                    ddlAnimal.SelectedIndex = 0;
                    ddlAdotante.SelectedIndex = 0;

                    txtCodigo.Text = "AUTOMATICO";
                    txtAdotarDataAdocao.Text = "";
                    hdfAdotarEnderecoID.Value = "";
                    txtAdotarCEP.Text = "";
                    txtAdotarEndereco.Text = "";
                    txtAdotarNumero.Text = "";
                    txtAdotarBairro.Text = "";
                    txtAdotarCidade.Text = "";
                    txtAdotarUF.Text = "";
                    txtAdotarComplemento.Text = "";
                }
                else
                {
                    cbxAdotarEndereco.Enabled = false;

                    ddlAnimal.SelectedValue = value.Animal.Id.ToString();
                    ddlAdotante.SelectedValue = value.Adotante.Id.ToString();
                    txtCodigo.Text = value.Id.ToString();
                    txtAdotarDataAdocao.Text = value.DtmAdocao.ToString("dd/MM/yyyy");

                    hdfAdotarEnderecoID.Value = value.EnderecoOndeFicaOAnimal.Id.ToString();
                    txtAdotarCEP.Text = value.EnderecoOndeFicaOAnimal.SCEP;
                    txtAdotarEndereco.Text = value.EnderecoOndeFicaOAnimal.SEndereco;
                    txtAdotarNumero.Text = value.EnderecoOndeFicaOAnimal.SNumero;
                    txtAdotarBairro.Text = value.EnderecoOndeFicaOAnimal.SBairro;
                    txtAdotarCidade.Text = value.EnderecoOndeFicaOAnimal.SCidade;
                    txtAdotarUF.Text = value.EnderecoOndeFicaOAnimal.SUF;
                    txtAdotarComplemento.Text = value.EnderecoOndeFicaOAnimal.SComplemento;

                    if(value.DtmDevolucao != null && value.DtmDevolucao.Value != new DateTime())
                    {
                        ddlAnimal.Enabled = false;
                        ddlAdotante.Enabled = false;
                        txtAdotarDataAdocao.Enabled = false;

                        txtAdotarCEP.Enabled = false;
                        txtAdotarEndereco.Enabled = false;
                        txtAdotarNumero.Enabled = false;
                        txtAdotarBairro.Enabled = false;
                        txtAdotarCidade.Enabled = false;
                        txtAdotarUF.Enabled = false;
                        txtAdotarComplemento.Enabled = false;
                        lnkSalvar.Enabled = false;
                        lnkSalvar.Visible = false;
                    }
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                _original = null;
                String id = Request.QueryString.ToString();
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    AnimalAdotado _adotado = AnimalAdotado.Obter(i);
                    _Adocao = _adotado;
                    _original = _adotado;
                }
                else _Adocao = null;
            }
        }

        protected void cbxAdotarEndereco_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cbxAdotarEndereco.AutoPostBack = false;

                if (cbxAdotarEndereco.Checked)
                {
                    hdfAdotarEnderecoID.Value = "";
                    txtAdotarCEP.Text = "";
                    txtAdotarEndereco.Text = "";
                    txtAdotarNumero.Text = "";
                    txtAdotarBairro.Text = "";
                    txtAdotarCidade.Text = "";
                    txtAdotarUF.Text = "";
                    txtAdotarComplemento.Text = "";

                    //Endereco endereAdotante = _Endereco;
                    //if (String.IsNullOrEmpty(endereAdotante.SEndereco) || String.IsNullOrEmpty(endereAdotante.SUF) ||
                    //    String.IsNullOrEmpty(endereAdotante.SBairro) || String.IsNullOrEmpty(endereAdotante.SCidade))
                    //{
                    //    txtAdotarComplemento.ReadOnly = false;
                    //    txtAdotarUF.ReadOnly = false;
                    //    txtAdotarCidade.ReadOnly = false;
                    //    txtAdotarBairro.ReadOnly = false;
                    //    txtAdotarNumero.ReadOnly = false;
                    //    txtAdotarEndereco.ReadOnly = false;
                    //    txtAdotarCEP.ReadOnly = false;
                    //    cbxAdotarEndereco.Checked = false;
                    //    throw new Exception("Os dados do endereço do adotante estão incompletos!");
                    //}
                }
                else
                {
                    hdfAdotarEnderecoID.Value = "";
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { cbxAdotarEndereco.AutoPostBack = true; RegistrarJavascripts(this); }
        }

        protected void lnkAdotarCarregarCEP_Click(object sender, EventArgs e)
        {
            try
            {
                Correios.Net.Address enderecos = Correios.Net.SearchZip.GetAddress(txtAdotarCEP.Text.Trim().Replace("-", "").Replace(".", ""));
                if (enderecos == null) throw new Exception("Atenção! Endereço não localizado com o CEP informado.");

                txtAdotarBairro.Text = enderecos.District;
                txtAdotarCidade.Text = enderecos.City;
                txtAdotarEndereco.Text = enderecos.Street;
                txtAdotarUF.Text = enderecos.State;
                txtAdotarNumero.Focus();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void lnkIncluirAdocao_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {


                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: ", Mensagens.Sucesso, this);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodasAsAdocoes");
        }
        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeAdocao");
        }
        protected void lnkImprimeContrato_Click(object sender, EventArgs e)
        {
            try
            {
                
                //PedidoCompra _Compra = PedidoCompra.ObterAberto();
                //if (_Compra != null && _Compra.Id > 0)
                //    Imprimir(_Compra, _Compra.GetType(), "~/Relatorios/ListaDeComprasDashboard.xslt", this);

            }
            catch (ExceptionSucesso ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Sucesso, this); }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}