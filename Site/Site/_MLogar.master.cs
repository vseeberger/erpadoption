using FWPet.Model;
using System;
using System.Web;
using System.Web.UI;

namespace Site
{
    public partial class _MLogar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String _URL = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "");
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/lib/jquery/jquery.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/lib/bootstrap/bootstrap.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/lib/tether/tether.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/plugins.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/lib/bootstrap-sweetalert/sweetalert.min.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), String.Format("<script src=\"{0}\"></script>", _URL + "/js/app.js"), false);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "$('.primeiro').focus();", true);
            if (!IsPostBack)
            {
                Usuario uLogado = Session["uLogado"] as Usuario;
                if (uLogado != null)
                    Response.Redirect("~/dashboard");
            }
        }
    }
}