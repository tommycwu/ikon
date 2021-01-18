using Microsoft.Owin.Security.Cookies;
using Okta.Sdk;
using Okta.Sdk.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace okta_aspnet_webforms_example.authorize
#pragma warning restore SA1300 // Element should begin with upper-case letter
{
    public partial class Callback : System.Web.UI.Page
    {
        private OktaClient client;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Application["utoken"] != null)
            {
                var userStr = Application["utoken"].ToString();
                Label1.Text = userStr.Substring(0, userStr.IndexOf('@'));

                client = new OktaClient(new OktaClientConfiguration
                {
                    OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"].ToString(),
                    Token = ConfigurationManager.AppSettings["okta:APIkey"].ToString(),
                });

                var userUpdate = client.Users.GetUserAsync(userStr);
                if (userUpdate.Result.Profile["ikonPass"] != null)
                {
                    Label6.Text = "Pass Registered: " + userUpdate.Result.Profile["ikonPass"].ToString();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string fullUrl = hdnResultValue.Value;
            if (fullUrl.IndexOf('#') > 1)
            {
                string hashUrl = fullUrl.Substring(fullUrl.IndexOf('#') + 1);
                string minusState = hashUrl.Substring(0, hashUrl.IndexOf('&'));
                string idToken = minusState.Substring(minusState.IndexOf('=') + 1);
                Application["stoken"] = idToken;
            }
            //var ahandler = new JwtSecurityTokenHandler();
            //var ajsonToken = ahandler.ReadToken(idToken);
            //var idtokenS = ahandler.ReadToken(idToken) as JwtSecurityToken;

            //GridViewID.DataSource = idtokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
            //GridViewID.DataBind();
            Response.Redirect("../usertokens.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            Application["atoken"] = null;
            Application["itoken"] = null;
            Application["stoken"] = null;
            Application["utoken"] = null;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.SignOut(
                    CookieAuthenticationDefaults.AuthenticationType);
            }

            Response.Redirect("../Welcome.aspx");
        }
    }

}
