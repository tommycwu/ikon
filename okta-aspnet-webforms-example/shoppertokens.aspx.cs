using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace okta_aspnet_webforms_example
#pragma warning disable SA1300 // Element should begin with upper-case letter
{
public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string itokenStr = string.Empty;
            string atokenStr = string.Empty;

            if ((Application["atoken"] != null) && (Application["itoken"] != null))
            {
                itokenStr = Application["itoken"].ToString();
                atokenStr = Application["atoken"].ToString();
            }
            else if (Request.IsAuthenticated)
            {
                var claimsList = HttpContext.Current.GetOwinContext().Authentication.User.Claims.ToList();
                foreach (var claimItem in claimsList)
                {
                    if (claimItem.Type == "id_token")
                    {
                        itokenStr = claimItem.Value;
                    }

                    if (itokenStr.Length > 0)
                    {
                        break;
                    }
                }
            }

            if (itokenStr != string.Empty)
            {
                var ihandler = new JwtSecurityTokenHandler();
                var ijsonToken = ihandler.ReadToken(itokenStr);
                var itokenS = ihandler.ReadToken(itokenStr) as JwtSecurityToken;

                GridViewID.DataSource = itokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
                GridViewID.DataBind();
            }
            else
            {
                Response.Redirect("login.aspx?user=invalid");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void GridViewID_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridViewID.Rows)
            {
                row.Cells[1].Attributes.Add("id", $"claim-{row.Cells[0].Text}");
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Application["passId"] = null;
            Application["atoken"] = null;
            Application["itoken"] = null;
            Application["utoken"] = null;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.GetOwinContext().Authentication.SignOut(
                    CookieAuthenticationDefaults.AuthenticationType);
            }

            Response.Redirect("Welcome.aspx");
        }
    }
}