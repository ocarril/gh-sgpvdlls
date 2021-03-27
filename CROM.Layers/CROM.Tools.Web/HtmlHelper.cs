using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CROM.Tools.Web
{

    public static class HtmlHelperMenu
    {
        public static bool IsValidMenu(this HtmlHelper helper)
        {
            var menuJson = HttpContext.Current.Session["mainMenu"] as string;

            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) return false;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var usuario = JsonConvert.DeserializeObject<dynamic>(ticket.UserData);
                var token = usuario.Token.ToString();
                menuJson = GeoToken.GetMenuJson(token);
                HttpContext.Current.Session["mainMenu"] = menuJson;
            }


            return !string.IsNullOrWhiteSpace(menuJson) && !menuJson.Contains("errorDescription");
        }

        public static IEnumerable<ItemMenu> GetMenu(this HtmlHelper helper)
        {
            var menuJson = HttpContext.Current.Session["mainMenu"] as string;

            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) return null;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                var usuario = JsonConvert.DeserializeObject<dynamic>(ticket.UserData);
                var token = usuario.Token.ToString();
                menuJson = GeoToken.GetMenuJson(token);
                HttpContext.Current.Session["mainMenu"] = menuJson;
            }
            if (string.IsNullOrWhiteSpace(menuJson))
            {
                HttpContext.Current.Response.RedirectLocation = "http://google.com.pe";
            }
            var menus = JsonConvert.DeserializeObject<IEnumerable<ItemMenu>>(menuJson);

            return menus;
        }

        public static void RedirectToSysgis(this HtmlHelper helper)
        {
            UrlHelper urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = urlHelper.Action("Index", "Account");

            var HttpEquiv = "Refresh";
            var Content = "2,url=" + FormsAuthentication.LoginUrl;
            HttpContext.Current.Response.Headers.Add(HttpEquiv, Content);
        }

        public static MvcHtmlString SetTokenSessionStorage(this HtmlHelper helper)
        {
            var sb = new StringBuilder();
            sb.Append("<script type=\"text/javascript\"> ");
            sb.AppendLine(" var tokenKey = 'geoToken'; var tokenValue =''; var menuKey = 'menuKey'");
            var showToken = helper.ViewContext.Controller.TempData["showToken"];
            if (showToken != null && (bool)showToken)
            {
                var token = helper.ViewContext.Controller.TempData["token"];
                var menu = helper.ViewContext.Controller.TempData["menu"];
                sb.AppendLine("tokenValue = '" + token + "'");
                sb.AppendLine("sessionStorage.setItem(tokenKey, tokenValue ); ");
                sb.AppendLine("menuValue = '" + menu + "'");
                sb.AppendLine("sessionStorage.setItem(menuKey, menuValue ); ");
            }
            sb.Append("</script>");
            return MvcHtmlString.Create(sb.ToString());
        }
    }

}
