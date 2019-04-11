using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_contato : _Herdar
    {
        private static Agenda _Origem;
        private static List<AgendaContato> _Contatos;
        private Agenda _Agenda
        {
            get
            {
                long i;
                Agenda item = new Agenda()
                {
                    Id = long.TryParse(txtCodigo.Text, out i) ? i : 0,
                    SNome = txtNome.Text,
                    Id_usuario = Logado().Id,
                    Privado = cbxPrivado.Checked
                };

                item.Contatos = _Contatos;
                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                ddlTipoContato.DataSource = AgendaTipoContato.Pesquisar();
                ddlTipoContato.DataValueField = "STipo";
                ddlTipoContato.DataTextField = "STipo";
                ddlTipoContato.DataBind();
                ddlTipoContato.SelectedIndex = 0;
                ddlTipoContato_SelectedIndexChanged(null, null);

                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtNome.Text = "";
                    cbxPrivado.Checked = false;
                    _Contatos = new List<AgendaContato>();
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SNome;
                    cbxPrivado.Checked = value.Privado;
                    _Contatos = value.Contatos;
                }

                gdvContatos.DataSource = _Contatos.Where(w => w.Status);
                gdvContatos.DataBind();
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
                    Agenda itm = Agenda.Obter(i);
                    _Agenda = itm;
                    _Origem = itm;
                }
                else
                    _Agenda = null;
            }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Agenda o = _Agenda;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O CONTATO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsContatos", "/CadastroDeContato");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TodosOsContatos");
        }

        protected void gdvContatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Remover")
                {
                    long l;
                    if (long.TryParse(e.CommandArgument.ToString(), out l) && l > 0)
                    {
                        AgendaContato _desativa = _Contatos.FirstOrDefault(w => w.Id == l);
                        if (_desativa != null) _desativa.Status = false;
                    }
                    else if (l < 0)
                    {
                        AgendaContato _desativa = _Contatos.FirstOrDefault(w => w.Id == l);
                        if (_desativa != null) _Contatos.Remove(_desativa);
                    }

                    gdvContatos.DataSource = _Contatos.Where(w => w.Status);
                    gdvContatos.DataBind();
                }
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected void btnInserirContato_Click(object sender, EventArgs e)
        {
            try
            {
                long l;
                long.TryParse(DateTime.Now.ToString("yyyyMMddHHmmss"), out l);
                AgendaContato _item = new AgendaContato()
                {
                    Id = (l * -1),
                    SNome = txtContato.Text,
                    STipoContato = ddlTipoContato.SelectedValue.ToString(),
                    Status = true
                };

                _Contatos.Add(_item);
                gdvContatos.DataSource = _Contatos.Where(w => w.Status);
                gdvContatos.DataBind();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }

        protected void ddlTipoContato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtContato.Attributes.Remove("class");
                AgendaTipoContato atc = AgendaTipoContato.Obter(ddlTipoContato.SelectedItem.Value);
                if (atc != null && !String.IsNullOrEmpty(atc.SMascara))
                    txtContato.Attributes.Add("class", "form-control " + atc.SMascara);
                else
                    txtContato.Attributes.Add("class", "form-control ");

                txtContato.Focus();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}