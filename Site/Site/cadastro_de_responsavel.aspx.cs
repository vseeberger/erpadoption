using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_responsavel : _Herdar
    {
        private static Responsavel _Origem;
        private Responsavel _Responsavel
        {
            get
            {
                long i;
                DateTime t;
                Responsavel item = new Responsavel()
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
                    Endereco = _Endereco
                };
                object o = rdMasc.Checked;
                o = rdFem.Checked;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
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
                    //_Endereco = null;
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
                }
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
                    Responsavel itm = Responsavel.Obter(i);
                    _Responsavel = itm;
                    _Origem = itm;
                }
                else
                    _Responsavel = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Responsavel o = _Responsavel;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O RESPONSÁVEL CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsPadrinhos", "/CadastroDePadrinho");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodosOsPadrinhos");
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
    }
}