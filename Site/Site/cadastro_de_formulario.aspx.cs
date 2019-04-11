using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_formulario : _Herdar
    {
        private Formulario _Formulario
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar o nome da Raça!");
                Formulario item = new Formulario();
                int i;
                item.Id = int.TryParse(txtCodigo.Text, out i) ? i : 0;
                item.SNome = txtNome.Text;
                item.SPath = txtURL.Text;
                item.Status = true;
                item.IdPai = int.TryParse(ddlMenuPai.SelectedValue, out i) ? i : 0;
                item.EhMenu = cbxEhMenu.Checked;
                item.SClass = txtCssMenu.Text;
                item.SIcone = txtIconeMenu.Text;
                item.IAgrupador = int.TryParse(txtAgrupador.Text, out i) ? i : 0;
                item.ISequenciaMenu = int.TryParse(txtSequenciaMenu.Text, out i) ? i : 0;
                item.SUrlCurta = txtURLCurta.Text;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                List<Formulario> LstForms = new List<Formulario>();
                LstForms.Add(new Formulario(0, "selecione"));
                LstForms.AddRange(Formulario.Pesquisar());
                ddlMenuPai.DataSource = LstForms;
                ddlMenuPai.DataValueField = "Id";
                ddlMenuPai.DataTextField = "CodNome";
                ddlMenuPai.DataBind();

                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SNome;
                    txtURL.Text = value.SPath;
                    cbxEhMenu.Checked = value.EhMenu;
                    if (value.IdPai != null)
                        ddlMenuPai.SelectedValue = value.IdPai.Value.ToString();
                    else
                        ddlMenuPai.SelectedIndex = 0;

                    txtCssMenu.Text = value.SClass;
                    txtIconeMenu.Text = value.SIcone;
                    txtAgrupador.Text = value.IAgrupador.ToString();
                    txtSequenciaMenu.Text = value.ISequenciaMenu.ToString();
                    txtURLCurta.Text = value.SUrlCurta;
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtNome.Text = "";
                    txtURL.Text = "";
                    ddlMenuPai.SelectedIndex = 0;
                    cbxEhMenu.Checked = false;

                    txtCssMenu.Text = "";
                    txtIconeMenu.Text = "";

                    txtAgrupador.Text = Util.ProximoAgrupadorFormulario();
                    txtSequenciaMenu.Text = "0";
                    txtURLCurta.Text = "";
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    String id = Request.QueryString.ToString();
                    int i;
                    if (int.TryParse(id, out i) && i > 0)
                    {
                        Formulario itm = Formulario.Obter(i);
                        _Formulario = itm;
                    }
                    else
                        _Formulario = null;
                }
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsFormularios");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Formulario o = _Formulario;
                o.Salvar();
                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsFormularios", "/CadastroDeFormulario");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }
    }
}