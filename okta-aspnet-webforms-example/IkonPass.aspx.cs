﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Owin.Security.Cookies;
using Newtonsoft.Json;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace okta_aspnet_webforms_example
#pragma warning disable SA1300 // Element should begin with upper-case letter
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public class OktaToken
        {
            [JsonProperty(PropertyName = "access_token")]
            public string AccessToken { get; set; }

            [JsonProperty(PropertyName = "expires_in")]
            public int ExpiresIn { get; set; }

            public DateTime ExpiresAt { get; set; }

            public string Scope { get; set; }

            [JsonProperty(PropertyName = "token_type")]
            public string TokenType { get; set; }

            public bool IsValidAndNotExpiring
            {
                get
                {
                    return !string.IsNullOrEmpty(this.AccessToken) && this.ExpiresAt > DateTime.UtcNow.AddSeconds(30);
                }
            }
        }

        private async Task<OktaToken> GetTokens()
        {
            string retJson = string.Empty;
            var token = new OktaToken();
            var client = new HttpClient();
            var client_id = ConfigurationManager.AppSettings["ikon:ClientId"].ToString();
            var client_secret = ConfigurationManager.AppSettings["ikon:ClientSecret"].ToString();
            var clientCreds = System.Text.Encoding.UTF8.GetBytes($"{client_id}:{client_secret}");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(clientCreds));
            var token_url = ConfigurationManager.AppSettings["ikon:TokenUrl"].ToString();
            var postMessage = new Dictionary<string, string>();
            postMessage.Add("grant_type", "client_credentials");
            postMessage.Add("scope", "daysleft");
            var request = new HttpRequestMessage(HttpMethod.Post, token_url)
            {
                Content = new FormUrlEncodedContent(postMessage),
            };
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                token = JsonConvert.DeserializeObject<OktaToken>(json);
                token.ExpiresAt = DateTime.UtcNow.AddSeconds(token.ExpiresIn);
            }
            else
            {
                throw new ApplicationException("Unable to retrieve access token from Okta");
            }

            return token;
        }

        //private async Task<string> GetDaysLeft(string atoken, string rfid)
        private string GetDaysLeft(string atoken, string rfid)
        {
            try
            {
                var daysleft_url = ConfigurationManager.AppSettings["ikon:ApiUrl"].ToString();
                List<string> values = new List<string>();
                var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", atoken);
                //var res = await client.GetAsync(daysleft_url + rfid);
                var res = client.GetAsync(daysleft_url).Result;
                if (res.IsSuccessStatusCode)
                {
                    return res.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    _ = res.StatusCode.ToString() + res.ReasonPhrase;
                    return "0";
                }

            }
            catch (Exception e)
            {
                _ = e;
                return "0";
            }
        }

        private static string RandomString(int length)
        {
            Random random = new Random();
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var builder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                var c = pool[random.Next(0, pool.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void ImageButton1_ClickAsync(object sender, ImageClickEventArgs e)
        {
            Random ranDays = new Random();
            var intDays = ranDays.Next(1, 5);
            var token = await GetTokens();
            var atoken = token.AccessToken;

            if (atoken.Length > 1)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(atoken);
                var tokenS = handler.ReadToken(atoken) as JwtSecurityToken;

                GridViewAccess.DataSource = tokenS.Claims.Select(x => new { Name = x.Type, Value = x.Value });
                GridViewAccess.DataBind();
                Label3.Visible = true;
            }

            var daysLeft = "0";
            daysLeft = GetDaysLeft(token.AccessToken, intDays.ToString());
            Label1.Text = "You have " + daysLeft + " day(s) left on your pass.";
            var passId = RandomString(5);
            Label4.Text = "Pass Id: " + passId;
            Application["passId"] = passId;
            Button1.Visible = true;
        }

        protected void GridViewClaims_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow row in GridViewAccess.Rows)
            {
                row.Cells[1].Attributes.Add("id", $"claim-{row.Cells[0].Text}");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string url = "Popup.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=700,height=500,left=300,top=300,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
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