using System;
using System.Configuration;
using Okta.Sdk;
using Okta.Sdk.Configuration;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace okta_aspnet_webforms_example
#pragma warning disable SA1300 // Element should begin with upper-case letter

{
    public partial class Popup : System.Web.UI.Page
    {
        private OktaClient client;


        protected void Page_Load(object sender, EventArgs e)
        {
            client = new OktaClient(new OktaClientConfiguration
            {
                OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"].ToString(),
                Token = ConfigurationManager.AppSettings["okta:APIkey"].ToString(),
            });
        }

        protected async void Button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Length > 5)
                {
                    var userUpdate = client.Users.GetUserAsync(TextBox1.Text);
                    userUpdate.Result.Profile["ikonPass"] = Application["passId"].ToString();
                    var updResults = await userUpdate.Result.UpdateAsync();
                    Label4.Text = "Your ikon Pass has been registered please close pop-up.";
                }
            }
            catch
            {
                Label4.Text = "Error registering pass... please cose the window and rescan your pass.";
            }
        }

    }
}