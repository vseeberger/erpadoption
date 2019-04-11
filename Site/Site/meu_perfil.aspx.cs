using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class meu_perfil : _Herdar
    {
        private Usuario _Origem;
        private Usuario _Usuario
        {
            get
            {
                String sSenha = String.IsNullOrEmpty(txtSenha.Text) ? String.IsNullOrEmpty(hdfSenha.Value.ToString()) ? "" : FWPet.Crypt.Decriptografa(hdfSenha.Value.ToString(), txtCodigo.Text) : txtSenha.Text;
                if (String.IsNullOrEmpty(sSenha)) throw new Exception("Você deve informar uma senha de acesso!");
                if (ddlPerfil.SelectedValue == "0") throw new Exception("Você deve selecionar o perfil de acesso!");

                long i;
                Usuario item = new Usuario()
                {
                    Id = long.TryParse(hdfID.Value, out i) ? i : 0,
                    SEmail = txtEmail.Text,
                    SNome = txtNome.Text,
                    SId = String.IsNullOrEmpty(txtCodigo.Text) || txtCodigo.Text == "AUTOMATICO" ? Util.RetornaSID() : txtCodigo.Text,
                    SLogin = txtLogin.Text,
                    SSenha = sSenha,
                };

                if (long.TryParse(ddlPessoaVincular.SelectedValue.ToString(), out i) && i > 0)
                    item.IdPessoa = i;

                //if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                //if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                List<Pessoas> LstPessoas = new List<Pessoas>();
                LstPessoas.Add(new Pessoas() { Id = 0, SNome = "selecione uma pessoa para vincular ao usuário" });
                LstPessoas.AddRange(Pessoas.Pesquisar());
                ddlPessoaVincular.DataSource = LstPessoas;
                ddlPessoaVincular.DataValueField = "Id";
                ddlPessoaVincular.DataTextField = "SNome";
                ddlPessoaVincular.DataBind();

                List<Perfil> LstPerfil = new List<Perfil>();
                LstPerfil.Add(new Perfil(0, "selecione um perfil de acesso"));
                LstPerfil.AddRange(Perfil.Pesquisar());
                ddlPerfil.DataSource = LstPerfil;
                ddlPerfil.DataTextField = "SNome";
                ddlPerfil.DataValueField = "Id";
                ddlPerfil.DataBind();

                if (value == null)
                {
                    throw new Exception("Usuário não identificado.");
                }
                else
                {
                    txtCodigo.Text = value.SId;
                    hdfID.Value = value.Id.ToString();
                    txtEmail.Text = value.SEmail;
                    txtNome.Text = value.SNome;
                    txtLogin.Text = value.SLogin;
                    hdfSenha.Value = value.SSenha;
                    txtSenha.Text = "";
                    ddlPerfil.SelectedValue = value.Perfil == null ? "0" : value.Perfil.Id.ToString();
                    ddlPessoaVincular.SelectedValue = value.IdPessoa != null ? value.IdPessoa.ToString() : "0";

                    if (value.Pessoa != null)
                    {
                        pnlEnderecos.Visible = true;
                        _Endereco = value.Pessoa == null ? null : value.Pessoa.Endereco;
                    }
                    else
                        pnlEnderecos.Visible = false;
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
                Usuario itm = Usuario.Obter(Logado().Id);
                _Origem = itm;
                _Usuario = itm;
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard");
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario o = _Usuario;
                o.SalvarPerfil();
                Session["uLogado"] = o;
                Type tipo = o.GetType();
                GravarLog(_Origem == null || _Origem.Id == 0 ? 1 : 2, " O USUÁRIO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);
                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Entre novamente no sistema para que as atualizações tenham efeito!", Mensagens.Sucesso, this, "/Dashboard");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
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