using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_adotante : _Herdar
    {
        private static Adotante _Origem;
        private Adotante _Adotante
        {
            get
            {
                long i;
                DateTime t;
                Adotante item = new Adotante()
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
                    DtmNascimento = DateTime.TryParse(txtDataNascimento.Text, out t) ? t == new DateTime() ? null : (DateTime?)t : null,
                    Endereco = _Endereco,
                    SProfissao = txtProfissao.Text,
                    Status = 1,
                    AnimaisAdotados = _Adotados
                };

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
                    txtProfissao.Text = "";
                    _Adotados = new List<AnimalAdotado>();
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
                    txtProfissao.Text = value.SProfissao;
                    _Endereco = value.Endereco;
                    _Adotados = value.AnimaisAdotados;
                }

                //coloca na grid view
                AtualizaAdotados();
            }
        }

        private static List<AnimalAdotado> _Adotados;

        private void AtualizaAdotados()
        {
            List<Animal> _AnimaisAdotadosAgora = new List<Animal>();
            if (_Adotados != null && _Adotados.Count > 0) for (int i = 0; i < _Adotados.Count; i++) _AnimaisAdotadosAgora.Add(_Adotados[i].Animal);

            //carrega a lista de animais disponíveis removendo os animais adotados na tela
            List<Animal> _Animais = Animal.Disponiveis();
            _Animais.RemoveAll(Animal => _AnimaisAdotadosAgora.Contains(Animal));

            ddlAdotarAnimais.DataSource = _Animais;
            ddlAdotarAnimais.DataValueField = "Id";
            ddlAdotarAnimais.DataTextField = "SNome";
            ddlAdotarAnimais.DataBind();

            rptAnimaisAdotados.DataSource = _Adotados;
            rptAnimaisAdotados.DataBind();

            //RegistrarJavascripts(this);
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
                    Adotante itm = Adotante.Obter(i);
                    _Adotante = itm;
                    _Origem = itm;
                }
                else
                    _Adotante = null;
            }
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

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Adotante o = _Adotante;
                o.Salvar();
                Type tipo = o.GetType();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O ADOTANTE CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Sucesso, this);
                _Adotante = o;
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodosOsAdotantes");
        }
        protected void lnkNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CadastroDeAdotante");
        }

        #region Realizar adoção
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

                    txtAdotarComplemento.ReadOnly = true;
                    txtAdotarUF.ReadOnly = true;
                    txtAdotarCidade.ReadOnly = true;
                    txtAdotarBairro.ReadOnly = true;
                    txtAdotarNumero.ReadOnly = true;
                    txtAdotarEndereco.ReadOnly = true;
                    txtAdotarCEP.ReadOnly = true;

                    Endereco endereAdotante = _Endereco;
                    if(String.IsNullOrEmpty(endereAdotante.SEndereco) || String.IsNullOrEmpty(endereAdotante.SUF)|| 
                        String.IsNullOrEmpty(endereAdotante.SBairro)|| String.IsNullOrEmpty(endereAdotante.SCidade))
                    {
                        txtAdotarComplemento.ReadOnly = false;
                        txtAdotarUF.ReadOnly = false;
                        txtAdotarCidade.ReadOnly = false;
                        txtAdotarBairro.ReadOnly = false;
                        txtAdotarNumero.ReadOnly = false;
                        txtAdotarEndereco.ReadOnly = false;
                        txtAdotarCEP.ReadOnly = false;
                        cbxAdotarEndereco.Checked = false;
                        throw new Exception("Os dados do endereço do adotante estão incompletos!");
                    }
                }
                else
                {
                    hdfAdotarEnderecoID.Value = "";
                    txtAdotarComplemento.ReadOnly = false;
                    txtAdotarUF.ReadOnly = false;
                    txtAdotarCidade.ReadOnly = false;
                    txtAdotarBairro.ReadOnly = false;
                    txtAdotarNumero.ReadOnly = false;
                    txtAdotarEndereco.ReadOnly = false;
                    txtAdotarCEP.ReadOnly = false;
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
                long id;
                long.TryParse(hdfIDAdocao.Value, out id);

                AnimalAdotado o = new AnimalAdotado()
                {
                    Alterado = true,
                    Id = id == 0 ? long.TryParse(DateTime.Now.ToString("yyyyMMddHHmmss"), out id) ? id : 0 : id,
                    Animal = new Animal(long.TryParse(ddlAdotarAnimais.SelectedValue, out id) ? id : 0, ddlAdotarAnimais.SelectedItem.Text),
                    DtmAdocao = Convert.ToDateTime(txtAdotarDataAdocao.Text),
                    EnderecoDoAdotante = cbxAdotarEndereco.Checked,
                    Status = true
                };

                if (o.Animal == null || o.Animal.Id <= 0) throw new Exception("Você NÃO selecionou um animal para ser adotado!");
                if (!o.EnderecoDoAdotante)
                {
                    //checar dados do endereço
                    long i;
                    Endereco _enderecoNovo = new Endereco()
                    {
                        Id = long.TryParse(hdfAdotarEnderecoID.Value, out i) ? i : long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss")),
                        SBairro = txtAdotarBairro.Text,
                        SCidade = txtAdotarCidade.Text,
                        SCEP = txtAdotarCEP.Text,
                        SComplemento = txtAdotarComplemento.Text,
                        SEndereco = txtAdotarEndereco.Text,
                        SNumero = txtAdotarNumero.Text,
                        SUF = txtAdotarUF.Text,
                        Alterou = true
                    };

                    //verifica os dados do endereço do animal
                    if (String.IsNullOrEmpty(_enderecoNovo.SEndereco) || String.IsNullOrEmpty(_enderecoNovo.SUF) ||
                        String.IsNullOrEmpty(_enderecoNovo.SBairro) || String.IsNullOrEmpty(_enderecoNovo.SCidade))
                        throw new Exception("Os dados do endereço do estão incompletos!");

                    o.EnderecoOndeFicaOAnimal = _enderecoNovo;
                }
                else o.EnderecoOndeFicaOAnimal = _Endereco;

                _Adotados.Add(o);

                //Limpa os campos
                hdfIDAdocao.Value = "";
                hdfAdotarEnderecoID.Value = "";
                txtAdotarBairro.Text = "";
                txtAdotarCidade.Text = "";
                txtAdotarCEP.Text = "";
                txtAdotarComplemento.Text = "";
                txtAdotarEndereco.Text = "";
                txtAdotarNumero.Text = "";
                txtAdotarUF.Text = "";
                txtAdotarDataAdocao.Text = DateTime.Today.ToString("dd/MM/yyyy");

                AtualizaAdotados();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            finally { RegistrarJavascripts(this); }
        }
        #endregion
    }
}