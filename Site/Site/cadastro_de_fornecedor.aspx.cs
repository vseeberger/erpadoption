using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_fornecedor : _Herdar
    {
        private static Empresa _Origem;
        private Empresa _Fornecedor
        {
            get
            {
                long l;
                Empresa item = new Empresa()
                {
                    Id = long.TryParse(txtCodigo.Text, out l) ? l : 0,
                    SRazaoSocial = txtRazaoSocial.Text,
                    SNomeFantasia = txtNomeFantasia.Text,
                    SCnpjCpf = txtCnpj.Text,
                    ITipoPessoa = 1,
                    SEmail = txtEmail.Text,
                    SSite = txtSite.Text,
                    STipoCadastro = "F"
                };
                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtCnpj.Text = value.SCnpjCpf;
                    txtEmail.Text = value.SEmail;
                    txtNomeFantasia.Text = value.SNomeFantasia;
                    txtRazaoSocial.Text = value.SRazaoSocial;
                    txtSite.Text = value.SSite;
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtCnpj.Text = "";
                    txtEmail.Text = "";
                    txtNomeFantasia.Text = "";
                    txtRazaoSocial.Text = "";
                    txtSite.Text = "";
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
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    Empresa __item = Empresa.Obter(i, "F");
                    _Fornecedor = __item;
                    _Origem = __item;
                }
                else
                    _Fornecedor = null;
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsFornecedores");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Empresa o = _Fornecedor;
                o.Salvar();
                Type tipo = o.GetType();
                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O FORNECEDOR CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, tipo), Util.serializarObjetos(o, tipo), tipo);

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsFornecedores", "/CadastroDeFornecedor");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}