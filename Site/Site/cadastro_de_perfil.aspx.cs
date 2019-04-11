using FWPet.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class cadastro_de_perfil : _Herdar
    {
        private static Perfil _Origem;
        private static List<PerfilPermissao> _PermissoesCarregadas;
        private Perfil _Perfil
        {
            get
            {
                if (String.IsNullOrEmpty(txtNome.Text.Trim())) throw new Exception("Você deve informar o nome do perfil!");
                Perfil item = new Perfil();
                int i;
                item.Id = int.TryParse(txtCodigo.Text, out i) ? i : 0;
                item.SNome = txtNome.Text;
                item.Status = true;
                item.LstPermissao = _PermissoesRetorno;

                if (item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return item;
            }
            set
            {
                _PermissoesCarregadas = null;
                if (value != null)
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtNome.Text = value.SNome;
                    _PermissoesCarregadas = value.LstPermissao;
                }
                else
                {
                    //limpa os campos
                    txtCodigo.Text = "AUTOMATICO";
                    txtNome.Text = "";
                    _PermissoesCarregadas = PerfilPermissao.Listar(0);
                }

                gdvFormularios.DataSource = _PermissoesCarregadas;//.Where(w => !String.IsNullOrEmpty(w.Formulario.SUrlCurta));
                gdvFormularios.DataBind();
            }
        }

        private List<PerfilPermissao> _PermissoesRetorno
        {
            get
            {
                List<PerfilPermissao> Lst = new List<PerfilPermissao>();
                
                if(gdvFormularios.Rows != null && gdvFormularios.Rows.Count > 0)
                {
                    CheckBox cbxAbrir;
                    CheckBox cbxAlterar;
                    CheckBox cbxEspecial;
                    CheckBox cbxExcluir;
                    CheckBox cbxInserir;
                    CheckBox cbxPesquisar;
                    HiddenField hdf;
                    for (int i = 0; i < gdvFormularios.Rows.Count; i++)
                    {
                        if(gdvFormularios.Rows[i].FindControl("hdfFormulario") != null)
                        {
                            cbxAbrir = gdvFormularios.Rows[i].FindControl("cbxAbrir") as CheckBox;
                            cbxAlterar = gdvFormularios.Rows[i].FindControl("cbxAlterar") as CheckBox;
                            cbxEspecial = gdvFormularios.Rows[i].FindControl("cbxEspecial") as CheckBox;
                            cbxExcluir = gdvFormularios.Rows[i].FindControl("cbxExcluir") as CheckBox;
                            cbxInserir = gdvFormularios.Rows[i].FindControl("cbxInserir") as CheckBox;
                            cbxPesquisar = gdvFormularios.Rows[i].FindControl("cbxPesquisar") as CheckBox;

                            hdf = gdvFormularios.Rows[i].FindControl("hdfFormulario") as HiddenField;
                            int k;
                            PerfilPermissao itm = new PerfilPermissao()
                            {
                                Formulario = new Formulario(int.TryParse(hdf.Value.ToString(), out k) ? k : 0),
                                Abrir = cbxAbrir == null ? false : cbxAbrir.Checked,
                                Alterar = cbxAlterar == null ? false : cbxAlterar.Checked,
                                Especial = cbxEspecial == null ? false : cbxEspecial.Checked,
                                Excluir = cbxExcluir == null ? false : cbxExcluir.Checked,
                                Inserir = cbxInserir == null ? false : cbxInserir.Checked,
                                Pesquisar = cbxPesquisar == null ? false : cbxPesquisar.Checked,
                            };
                            Lst.Add(itm);
                        }
                    }
                }

                return Lst;
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
                    _Origem = null;
                    long i;
                    if (long.TryParse(id, out i) && i > 0)
                    {
                        Perfil itm = Perfil.Obter(i);
                        _Perfil = itm;
                        _Origem = itm;
                    }
                    else
                        _Perfil = null;
                }
            }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsPerfis");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Perfil o = _Perfil;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O PERFIL CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsPerfis", "/CadastroDePerfil");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void gdvFormularios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "ChecarTodosAbrir")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Abrir = true; }
                else if (e.CommandName == "ChecarTodosPesquisar")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Pesquisar = true; }
                else if (e.CommandName == "ChecarTodosInserir")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Inserir = true; }
                else if (e.CommandName == "ChecarTodosAlterar")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Alterar = true; }
                else if (e.CommandName == "ChecarTodosExcluir")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Excluir = true; }
                else if (e.CommandName == "ChecarTodosEspecial")
                    for (int i = 0; i < _PermissoesCarregadas.Count; i++) { _PermissoesCarregadas[i].Especial = true; }

                gdvFormularios.DataSource = _PermissoesCarregadas;
                gdvFormularios.DataBind();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
            //finally { RegistrarJavascripts(this); }
        }
    }
}