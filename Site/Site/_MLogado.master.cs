using FWPet.Model;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Site
{
    public partial class _MLogado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario uLogado = (Usuario)Session["uLogado"];
            if (uLogado == null)
                Response.Redirect("~/entrar");

            //String _URL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery/jquery.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/tether/tether.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap/bootstrap.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/plugins.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap-sweetalert/sweetalert.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/datatables-net/datatables.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/input-mask/jquery.mask.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/input-mask/input-mask-init.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.caret.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/jquery-tag-editor/jquery.tag-editor.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap-select/bootstrap-select.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/select2/select2.full.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/moment/moment.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/bootstrap-daterangepicker/daterangepicker.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/daterangepicker/daterangepicker.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/lib/fancybox/jquery.fancybox.pack.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/carrega.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script  type=\"text/javascript\" src=\"{0}?dt=" + DateTime.Now.ToString("dd_MM_yyyy__hh_mm_ss") + "\"></script>", _URL + "/js/app.js"), false);

            //var MenuMontar = uLogado.Perfil.LstPermissao.Where(w => w.Formulario.EhMenu).ToList();

            rptMenu.DataSource = uLogado.Menu.OrderBy(w => w.ISequenciaMenu);
            rptMenu.DataBind();

            if (!uLogado.IgnoraPermissoes && !HttpContext.Current.Request.Url.ToString().Contains("Erros"))
            {
                String _URL2 = HttpContext.Current.Request.Url.PathAndQuery.Replace("/", "");
                PerfilPermissao _Permite = uLogado.Perfil.LstPermissao.FirstOrDefault(w => w.Formulario.SPath == _URL2);
                if (_Permite != null && !_Permite.Abrir)
                    Response.Redirect("~/cade");
            }
        }

        protected void lnkSair_Click(object sender, EventArgs e)
        {
            Usuario uLogado = new Usuario();
            uLogado = Session["uLogado"] as Usuario;
            _Herdar.GravarLog(0, "O USUÁRIO CLICOU EM SAIR DO SISTEMA.", "", Util.serializarObjetos(uLogado, uLogado.GetType()), uLogado.GetType());

            Session.Abandon();
            Response.Redirect("~/entrar");
        }
    }
}