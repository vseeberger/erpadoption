using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_usuario : _Herdar
    {
        private static Usuario _Origem;
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
                    Perfil = new Perfil() { Id = Convert.ToInt32(ddlPerfil.SelectedValue) },
                    SLogin = txtLogin.Text,
                    SSenha = sSenha,
                };

                if (long.TryParse(ddlPessoaVincular.SelectedValue.ToString(), out i) && i > 0)
                    item.IdPessoa = i;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
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
                    txtCodigo.Text = "AUTOMATICO";
                    hdfID.Value = "";
                    txtEmail.Text = "";
                    txtNome.Text = "";
                    txtLogin.Text = "";
                    hdfSenha.Value = "";
                    txtSenha.Text = "";
                    ddlPerfil.SelectedValue = "0";
                    ddlPessoaVincular.SelectedValue = "0";
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
                    Usuario itm = Usuario.Obter(i);
                    _Usuario = itm;
                    _Origem = itm;
                }
                else
                    _Usuario = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario o = _Usuario;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O USUARIO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsUsuarios", "/CadastroDeUsuario");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodosOsUsuarios");
        }
    }
}