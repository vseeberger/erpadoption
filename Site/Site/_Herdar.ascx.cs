using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FWPet.Model;
using System.IO;
using System.Xml.Xsl;
using System.Xml;

namespace Site
{
    public partial class _Herdar : System.Web.UI.Page
    {
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public static void RegistrarJS(Page ote, String _Path)
        {
            String _URL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + _Path), false);
        }

        public static void RegistrarJavascripts(Page ote)
        {
            string sT = DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss");
            String _URL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/jquery/jquery.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/tether/tether.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/bootstrap/bootstrap.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/plugins.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/bootstrap-sweetalert/sweetalert.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/datatables-net/datatables.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/input-mask/jquery.mask.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/input-mask/input-mask-init.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.caret.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.tag-editor.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/bootstrap-select/bootstrap-select.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/select2/select2.full.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/moment/moment.min.js"), false);
            //ADD 21.02.2017
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/moment/moment-with-locales.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/eonasdan-bootstrap-datetimepicker/bootstrap-datetimepicker.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/clockpicker/bootstrap-clockpicker.min.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/clockpicker/bootstrap-clockpicker-init.js"), false);
            //FIM 21.02.2017
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/bootstrap-daterangepicker/daterangepicker.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/lib/fancybox/jquery.fancybox.pack.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/carrega.js"), false);
            ScriptManager.RegisterStartupScript(ote, ote.GetType(), Guid.NewGuid().ToString(), String.Format("<script type=\"text/javascript\" src=\"{0}?dt=" + sT + "\"></script>", _URL + "/js/app.js"), false);
        }

        /// <summary>
        /// Faz o redirect
        /// OBS: NÃO PRECISA INFORMAR ~/ pois é passado automático.
        /// </summary>
        /// <param name="_endereco"></param>
        public static void Redirecionar(string _endereco)
        {
            HttpContext.Current.Response.Redirect("~/" + _endereco);
        }

        public static PerfilPermissao AcessoTela()
        {
            PerfilPermissao _Permite = null;
            Usuario uLogado = (Usuario)HttpContext.Current.Session["uLogado"];

            if (!HttpContext.Current.Request.Url.ToString().Contains("Erros"))
            {
                String _URL = HttpContext.Current.Request.Url.AbsolutePath.Replace("/", "");//.PathAndQuery.Replace("/", "");
                if (_URL.ToUpper() != "DEFAULT.ASPX")
                    _Permite = uLogado.Perfil.LstPermissao.FirstOrDefault(w => w.Formulario.SPath == _URL);

                if (_Permite == null) _Permite = new PerfilPermissao();

                if (Logado().IgnoraPermissoes)
                {
                    _Permite.Abrir = true;
                    _Permite.Alterar = true;
                    _Permite.Especial = true;
                    _Permite.Excluir = true;
                    _Permite.Inserir = true;
                    _Permite.Pesquisar = true;
                }
            }
            return _Permite;
        }

        public static Usuario Logado()
        {
            Usuario uLogado = (Usuario)HttpContext.Current.Session["uLogado"];
            return uLogado;
        }

        /// <summary>
        /// Utilizando controles da tela (PANEL e LITERAL)
        /// </summary>
        /// <param name="_Mensagem"></param>
        /// <param name="_tipoM"></param>
        /// <param name="_Painel"></param>
        /// <param name="_Controle"></param>
        public static void MensagemAlerta(String _Mensagem, Mensagens _tipoM, Panel _Painel, Literal _Controle)
        {
            _Painel.Visible = false;
            _Painel.Attributes.Remove("class");
            _Controle.Text = _Mensagem;
            switch (_tipoM)
            {
                case Mensagens.Erro:
                    _Painel.Attributes.Add("class", "alert alert-danger");
                    _Painel.Visible = true;
                    _Painel.Focus();
                    break;
                case Mensagens.Sucesso:
                    _Painel.Attributes.Add("class", "alert alert-success");
                    _Painel.Visible = true;
                    _Painel.Focus();
                    break;
                case Mensagens.Atencao:
                    _Painel.Attributes.Add("class", "alert alert-warning");
                    _Painel.Visible = true;
                    _Painel.Focus();
                    break;
                case Mensagens.Informacao:
                    _Painel.Attributes.Add("class", "alert alert-info");
                    _Painel.Visible = true;
                    _Painel.Focus();
                    break;
            }
        }

        /// <summary>
        /// Utilizando o Sweet Alert (popup que não permite fechar sem clicar no botão de fechar)
        /// e que possui um visual muito bonito.
        /// </summary>
        /// <param name="_Mensagem"></param>
        /// <param name="_tipoM"></param>
        /// <param name="_RedirectConcluido">não é necessário passar "til: ~", apenas a barra "/"</param>
        public static void MensagemAlertaPopup(String _Mensagem, Mensagens _tipoM, Control _Controle, string _RedirectConcluido = null, string _RedirectInserirMais = null)
        {
            String _Alerta = "";
            if (!String.IsNullOrEmpty(_RedirectConcluido))
                _RedirectConcluido = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "") + _RedirectConcluido;
            else _RedirectConcluido = "";

            switch (_tipoM)
            {
                case Mensagens.Erro:
                    _Alerta = "AlertaErro(\"" + _Mensagem + "\",\"" + _RedirectConcluido + "\");";
                    break;
                case Mensagens.Sucesso:
                    _Alerta = "AlertaSucesso(\"" + _Mensagem + "\",\"" + _RedirectConcluido + "\");";
                    break;
                case Mensagens.Atencao:
                    _Alerta = "AlertaAtencao(\"" + _Mensagem + "\",\"" + _RedirectConcluido + "\");";
                    break;
                case Mensagens.Informacao:
                    _Alerta = "Alerta(\"" + _Mensagem + "\",\"" + _RedirectConcluido + "\");";
                    break;
                case Mensagens.Pergunta:
                    _Alerta = "AlertaContinuar(\"" + _Mensagem + "\",\"" + _RedirectConcluido + "\",\"" + _RedirectInserirMais + "\");";
                    break;
            }

            ScriptManager.RegisterStartupScript(_Controle, _Controle.GetType(), Guid.NewGuid().ToString(), _Alerta, true);
        }

        public enum Mensagens { Erro = 1, Sucesso = 2, Atencao = 3, Informacao = 4, Pergunta = 5 };

        public static void Imprimir(Object _Objeto, Type _Tipo, String _Relatorio, Control _Controle)
        {
            String _XSLT = HttpContext.Current.Server.MapPath(_Relatorio);// "~/Relatorios/relEventos.xslt");
            String _RELATORIO = "";
            if (_Relatorio.Contains("/Relatorios/"))
                _RELATORIO = "/Imprimir.aspx";
            else
                _RELATORIO = "/Imprimir.aspx";

            StringWriter htmlGerado = new StringWriter();
            XslCompiledTransform xslt = new XslCompiledTransform();
            XsltSettings xs = new XsltSettings(true, true);
            //xslt.Load(_XSLT);//, xs);//, new System.Xml.XmlUrlResolver());
            //xslt.Transform(System.Xml.XmlReader.Create(new System.IO.StringReader(Util.serializarObjetos(_Objeto, _Tipo))), null, htmlGerado);
            XmlResolver secureResolver = new XmlSecureResolver(new XmlUrlResolver(), _XSLT);
            //xslt.Load(_XSLT, XsltSettings.Default, secureResolver);
            xslt.Load(_XSLT, XsltSettings.TrustedXslt, secureResolver);
            xslt.Transform(System.Xml.XmlReader.Create(new System.IO.StringReader(Util.serializarObjetos(_Objeto, _Tipo))), null, htmlGerado);

            String sCODIGO = "S" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            HttpContext.Current.Session[sCODIGO] = htmlGerado.ToString();
            ScriptManager.RegisterClientScriptBlock(_Controle, _Controle.GetType(), Guid.NewGuid().ToString(), "window.open('" + _RELATORIO + "?id=" + sCODIGO + "');", true);
        }

        /// <summary>
        /// 1 - INSERIR - INSERIU
	    /// || 2 - ALTERAR - ALTEROU
	    /// || 3 - EXCLUIR - EXCLUIU
	    /// || 4 - ACESSAR - ACESSOU
	    /// || 5 - ESPECIAL- PERMISSÃO ESPECIAL
        /// </summary>
        /// <param name="_Acao"></param>
        public static void GravarLog(int _Acao, string _Texto, object _ObjetoAntes, object _ObjetoDepois, Type _TipoObjeto)
        {
            Usuario uLogado = (Usuario)HttpContext.Current.Session["uLogado"];
            if (uLogado != null)
            {
                LogAcao logAcoes = LogAcao.Obter(_Acao);
                String _URL = HttpContext.Current.Request.Url.PathAndQuery.Replace("/", "");
                PerfilPermissao _Forms = uLogado.Perfil.LstPermissao.FirstOrDefault(w => w.Formulario.SPath == _URL);
                if (_Forms != null)
                {
                    Formulario _Tela = _Forms.Formulario;
                    if (logAcoes != null) _Texto = logAcoes.STexto + " " + _Texto;

                    //Logs.Salvar(new Logs(_Texto, uLogado.Id, (_Tela == null ? 0 : _Tela.Id), _Acao, _ObjetoAntes.ToString(), _ObjetoDepois.ToString()));
                    Logs.Salvar(new Logs()
                    {
                        SDescricao = _Texto,
                        Usuario = uLogado,
                        SObjetoAntes = _ObjetoAntes == null ? "" : _ObjetoAntes.ToString(),
                        SObjetoDepois = _ObjetoDepois == null ? "" : _ObjetoDepois.ToString(),
                        Acao = new LogAcao() { Id = _Acao },
                        Tela = _Tela == null ? new Formulario(0) : _Tela,
                        TipoDoObjeto = _TipoObjeto
                    });
                }
                else
                    Logs.Salvar(new Logs((logAcoes != null ? logAcoes.STexto : "") + _Texto, uLogado.Id, 0, _Acao, _ObjetoAntes == null ? "" : _ObjetoAntes.ToString(), _ObjetoDepois == null ? "" : _ObjetoDepois.ToString(), _TipoObjeto));
            }
        }
    }
}