using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWPet.Model;

namespace Site
{
    public partial class cadastro_de_medicamento : _Herdar
    {
        private static ProdutoMedicamento _Origem;
        private MedicamentoGenerico _Genericos
        {
            get
            {
                MedicamentoGenerico __item = new MedicamentoGenerico();
                __item.SDescricao = txtGenericoDescricao.Text;
                return __item;
            }
        }

        private ProdutoMedicamento _Medicamento
        {
            get
            {
                int i = 0;
                long l = 0;

                ProdutoMedicamento __item = new ProdutoMedicamento()
                {
                    Id = long.TryParse(txtCodigo.Text, out l) ? l : 0,
                    SNome = txtNomeDoProduto.Text,
                    SNomeComercial = txtNomeComercial.Text,
                    SReferencia = txtReferencia.Text,
                    Status = true,
                    SObservacoes = txtObservacoes.Text,
                    
                };

                #region Genérico
                if (long.TryParse(ddlGenerico.SelectedValue, out l) && l > 0)
                {
                    __item.Generico = new MedicamentoGenerico()
                    {
                        Id = l,
                        SDescricao = ddlGenerico.SelectedItem.Text
                    };
                }
                #endregion

                #region Princípio Ativo
                if (int.TryParse(ddlPrincipioAtivo.SelectedValue, out i) && i > 0)
                {
                    __item.PrincipioAtivo = new MedicamentoPrincipioAtivo()
                    {
                        Id = i,
                        SDescricao = ddlPrincipioAtivo.SelectedItem.Text
                    };
                }
                #endregion

                #region Grupo
                if (int.TryParse(ddlGrupo.SelectedValue, out i) && i > 0)
                {
                    __item.Grupo = new MedicamentoGrupo()
                    {
                        Id = i,
                        SDescricao = ddlGrupo.SelectedItem.Text,
                    };
                }
                #endregion

                #region Laboratório
                if (long.TryParse(ddlFornecedor.SelectedValue, out l) && l > 0)
                {
                    __item.FabricantePrincipal = new Empresa()
                    {
                        Id = l,
                        SRazaoSocial = ddlFornecedor.SelectedItem.Text
                    };
                }
                #endregion
                if (__item.Id > 0 && !AcessoTela().Alterar) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                if (__item.Id <= 0 && !AcessoTela().Inserir) throw new Exception("Atenção! Você <b>NÃO</b> tem permissão.");
                return __item;
            }
            set
            {
                List<MedicamentoGrupo> LstGrupo = new List<MedicamentoGrupo>();
                LstGrupo.Add(new MedicamentoGrupo() { Id = -1, SDescricao = "Escolha um grupo" });
                LstGrupo.AddRange(MedicamentoGrupo.Pesquisar());
                ddlGrupo.DataSource = LstGrupo;
                ddlGrupo.DataValueField = "Id";
                ddlGrupo.DataTextField = "SDescricao";
                ddlGrupo.DataBind();

                //Limpa os campos do medicamento generico
                txtGenericoCodigo.Text = "AUTOMATICO";
                txtGenericoDescricao.Text = "";

                //Carrega os genericos na dropdown
                CarregaGenericos(value == null || value.Generico == null ? null : (long?)value.Generico.Id);

                //Carrega os Laboratórios
                List<Laboratorio> LstFornecedor = new List<Laboratorio>();
                LstFornecedor.Add(new Laboratorio() { Id = -1, SRazaoSocial = "Selecione um laboratório" });
                LstFornecedor.AddRange(Laboratorio.Pesquisar());
                ddlFornecedor.DataSource = LstFornecedor;
                ddlFornecedor.DataValueField = "Id";
                ddlFornecedor.DataTextField = "SRazaoSocial";
                ddlFornecedor.DataBind();

                //Carrega o principio ativo
                List<MedicamentoPrincipioAtivo> LstPAtivo = new List<MedicamentoPrincipioAtivo>();
                LstPAtivo.Add(new MedicamentoPrincipioAtivo() { Id = 0, SDescricao = "Selecione um princípio ativo" });
                LstPAtivo.AddRange(MedicamentoPrincipioAtivo.Pesquisar());
                ddlPrincipioAtivo.DataSource = LstPAtivo;
                ddlPrincipioAtivo.DataValueField = "Id";
                ddlPrincipioAtivo.DataTextField = "SDescricao";
                ddlPrincipioAtivo.DataBind();

                if (value == null)
                {
                    txtCodigo.Text = "AUTOMATICO";
                    txtReferencia.Text = "";
                    txtNomeDoProduto.Text = "";
                    txtNomeComercial.Text = "";
                    ddlGrupo.SelectedIndex = 0;
                    ddlFornecedor.SelectedIndex = 0;
                    ddlPrincipioAtivo.SelectedIndex = 0;
                    txtObservacoes.Text = "";
                }
                else
                {
                    txtCodigo.Text = value.Id.ToString();
                    txtReferencia.Text = value.SReferencia;
                    txtNomeDoProduto.Text = value.SNome;
                    txtNomeComercial.Text = value.SNomeComercial;
                    ddlGrupo.SelectedValue = (value.Grupo == null ? 0 : value.Grupo.Id).ToString();
                    ddlFornecedor.SelectedValue = (value.FabricantePrincipal == null ? 0 : value.FabricantePrincipal.Id).ToString();
                    ddlPrincipioAtivo.SelectedValue = (value.PrincipioAtivo == null ? 0 : value.PrincipioAtivo.Id).ToString();
                    txtObservacoes.Text = value.SObservacoes;
                }
            }
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            if (!IsPostBack)
            {
                String id = String.IsNullOrEmpty(Request.QueryString.ToString()) ? "" : Request.QueryString[0];
                _Origem = null;
                long i;
                if (long.TryParse(id, out i) && i > 0)
                {
                    ProdutoMedicamento item = ProdutoMedicamento.Obter(i);
                    _Medicamento = item;
                    _Origem = item;
                }
                else
                    _Medicamento = null;
            }
        }

        protected void CarregaGenericos(long? _codigo = null)
        {
            try
            {
                List<MedicamentoGenerico> Lst = new List<MedicamentoGenerico>();
                Lst.Add(new MedicamentoGenerico() { Id = -1, SDescricao = "Selecione um genérico" });
                Lst.AddRange(MedicamentoGenerico.Pesquisar());
                ddlGenerico.DataSource = Lst;
                ddlGenerico.DataValueField = "Id";
                ddlGenerico.DataTextField = "SDescricao";
                ddlGenerico.DataBind();
                if (_codigo != null) ddlGenerico.SelectedValue = _codigo.ToString();
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnCancelarGenerico_Click(object sender, EventArgs e)
        {
            try
            {
                txtGenericoCodigo.Text = "AUTOMATICO";
                txtGenericoDescricao.Text = "";
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "fnFechar(); fnSelect();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void btnSalvarGenerico_Click(object sender, EventArgs e)
        {
            try
            {
                //Salva o genérico
                MedicamentoGenerico _item = _Genericos;
                _item.Salvar();

                //Atualiza o ddlGenericos
                CarregaGenericos(_item.Id);

                //Limpa os campos
                txtGenericoCodigo.Text = "AUTOMATICO";
                txtGenericoDescricao.Text = "";
                
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), Guid.NewGuid().ToString(), "fnFechar(); fnSelect();", true);
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoMedicamento o = _Medicamento;
                o.Salvar();

                long l;
                long.TryParse(txtCodigo.Text, out l);
                GravarLog(l == 0 ? 1 : 2, " O MEDICAMENTO CÓDIGO: " + o.Id, Util.serializarObjetos(_Origem, _Origem.GetType()), Util.serializarObjetos(o, o.GetType()), o.GetType());

                MensagemAlertaPopup("Os dados foram gravados com sucesso.<br/>Código: " + o.Id.ToString("0000"), Mensagens.Pergunta, this, "/TodosOsMedicamentos", "/CadastroDeMedicamento");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void lnkCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Redirecionar("TodosOsMedicamentos");
            }
            catch (Exception ex) { MensagemAlertaPopup(ex.Message.ToString(), Mensagens.Erro, this); }
        }

        protected void upnlGenericos_Load(object sender, EventArgs e)
        {
            String _URL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery/jquery.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/tether/tether.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap/bootstrap.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/plugins.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap-sweetalert/sweetalert.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/datatables-net/datatables.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/input-mask/jquery.mask.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/input-mask/input-mask-init.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.caret.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.tag-editor.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap-select/bootstrap-select.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/select2/select2.full.min.js"), false);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/app.js"), false);
        }
    }
}