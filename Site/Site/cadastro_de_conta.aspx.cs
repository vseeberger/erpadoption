using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_conta :_Herdar
    {
        private static ContaBancaria _Origem;
        private ContaBancaria _Conta
        {
            get
            {
                int i;
                decimal d;
                ContaBancaria item = new ContaBancaria()
                {
                    Id = int.TryParse(txtCodigo.Text, out i) ? i : 0,
                    Principal = cbxPrincipal.Checked,
                    SAgencia = txtAgencia.Text,
                    SConta = txtConta.Text,
                    SDescricao = txtDescricao.Text,
                    Status = true,
                    STitularDocumento = txtTitularDocumento.Text,
                    STitularNome = txtTitularNome.Text,
                    Tipo = new ContaBancariaTipo(int.Parse(ddlTipo.SelectedValue.ToString()), ddlTipo.SelectedItem.Text),
                    DSaldoInicial = decimal.TryParse(txtSaldoinicial.Text, out d) ? d : 0
                };

                if (String.IsNullOrEmpty(item.SDescricao)) throw new Exception("Informe a descrição da conta.");
                if (item.Tipo == null || item.Tipo.Id == 0) throw new Exception("Selecione o tipo.");

                return item;
            }
            set
            {
                List<ContaBancariaTipo> LstTiposConta = new List<ContaBancariaTipo>();
                LstTiposConta.Add(new ContaBancariaTipo(0, "selecione um tipo"));
                LstTiposConta.AddRange(ContaBancariaTipo.Pesquisar());
                ddlTipo.DataSource = LstTiposConta;
                ddlTipo.DataValueField = "Id";
                ddlTipo.DataTextField = "SDescricao";
                ddlTipo.DataBind();

                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtAgencia.Text = "";
                    txtConta.Text = "";
                    txtDescricao.Text = "";
                    txtTitularDocumento.Text = "";
                    txtTitularNome.Text = "";
                    cbxPrincipal.Checked = false;
                    ddlTipo.SelectedValue = "0";
                    txtSaldoinicial.Text = "";
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtAgencia.Text = value.SAgencia;
                    txtConta.Text = value.SConta;
                    txtDescricao.Text = value.SDescricao;
                    txtTitularDocumento.Text = value.STitularDocumento;
                    txtTitularNome.Text = value.STitularNome;
                    ddlTipo.SelectedValue = value.Tipo == null ? "0" : value.Tipo.Id.ToString();
                    cbxPrincipal.Checked = value.Principal;
                    txtSaldoinicial.Text = value.DSaldoInicial.ToString("0.00");
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
                    ContaBancaria itm = ContaBancaria.Obter(i);
                    _Conta = itm;
                    _Origem = itm;
                }
                else
                    _Conta = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBancaria o = _Conta;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " A CONTA CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodasAsContas", "/CadastroDeConta");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodasAsContas");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}