using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using Newtonsoft.Json;
using Okta.Sdk;
using Okta.Sdk.Configuration;

#pragma warning disable SA1300 // Element should begin with upper-case letter
namespace okta_aspnet_webforms_example
#pragma warning disable SA1300 // Element should begin with upper-case letter
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private class LegacyUser
        {
            public string UserName;
            public string Password;
            public string FirstName;
            public string LastName;
            public string IkonMemberId;
        }

        private static async Task<string[]> GetTokens(string u, string p)
        {
            var domain = ConfigurationManager.AppSettings["okta:OktaDomain"];
            var redirectUrl = ConfigurationManager.AppSettings["okta:RedirectUri"];
            var oktaAuthorizationServer = ConfigurationManager.AppSettings["alterra:AuthZserver"];
            var clientId = ConfigurationManager.AppSettings["alterra:ClientId"];
            var redirectUrlEncoded = System.Net.WebUtility.UrlEncode(redirectUrl);
            var responseType = System.Net.WebUtility.UrlEncode("id_token token");
            var state = "testing";
            var nonce = "testing nonce";
            var scope = System.Net.WebUtility.UrlEncode("openid profile");
            var authnUri = $"{domain}/api/v1/authn";
            var username = u;
            var password = p;

            dynamic bodyOfRequest = new
            {
                username,
                password,
                options = new
                {
                    multiOptionalFactorEnroll = true,
                    warnBeforePasswordExpired = true,
                },
            };

            var body = JsonConvert.SerializeObject(bodyOfRequest);

            var stringContent = new StringContent(body, Encoding.UTF8, "application/json");

            string sessionToken;

            HttpClientHandler httpClientHandler = new HttpClientHandler();
            httpClientHandler.AllowAutoRedirect = false;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage authnResponse = await httpClient.PostAsync(authnUri, stringContent);

                if (authnResponse.IsSuccessStatusCode)
                {
                    var authnResponseContent = await authnResponse.Content.ReadAsStringAsync();
                    dynamic authnObject = JsonConvert.DeserializeObject(authnResponseContent);
                    sessionToken = authnObject.sessionToken;

                    var authorizeUri = $"{domain}/oauth2/{oktaAuthorizationServer}/v1/authorize?client_id={clientId}&redirect_uri={redirectUrlEncoded}" +
                        $"&response_type={responseType}&sessionToken={sessionToken}&state={state}&nonce={nonce}&scope={scope}";

                    HttpResponseMessage authorizeResponse = await httpClient.GetAsync(authorizeUri);
                    var statusCode = (int)authorizeResponse.StatusCode;

                    if (statusCode == (int)HttpStatusCode.Found)
                    {
                        var redirectUri = authorizeResponse.Headers.Location;
                        var queryDictionary = HttpUtility.ParseQueryString(redirectUri.AbsoluteUri);
                        int i;
                        {
                            for (i = 0; i < queryDictionary.Count - 1; i++)
                            {
                                if (queryDictionary.AllKeys[i].Contains("id_token"))
                                {
                                    break;
                                }
                            }
                        }

                        var retArray = new string[]
                        {
                            queryDictionary[i],
                            queryDictionary["access_token"],
                        };

                        return retArray;
                    }
                }
            }

            return null;
        }

        private List<LegacyUser> ReadCSV()
        {
            var userList = new List<LegacyUser>();
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\tommy.wu\source\repos\samples-aspnet-webforms\self-hosted-login\okta-aspnet-webforms-example\data.csv"))
                {
                    do
                    {
                        string s = sr.ReadLine();
                        string[] arrData = s.Split(',');

                        LegacyUser aUser = new LegacyUser();
                        aUser.FirstName = arrData[0];
                        aUser.LastName = arrData[1];
                        aUser.UserName = arrData[2];
                        aUser.Password = arrData[3];
                        aUser.IkonMemberId = arrData[4];
                        userList.Add(aUser);
                    }
                    while (!sr.EndOfStream);
                }

                return userList;
            }
            catch
            {
                LegacyUser aUser = new LegacyUser();
                aUser.FirstName = "Legacy";
                aUser.LastName = "One";
                aUser.UserName = "Legacy.One@mailinator.com";
                aUser.Password = "Bingo!1";
                aUser.IkonMemberId = "1111";
                userList.Add(aUser);
                return userList;
            }

        }

        private bool LegacyCreds(string u, string p, ref string f, ref string l, ref string m)
        {
            var userList = ReadCSV();

            if ((u.Length > 5) && (p.Length > 5))
            {
                for (int i = 0; i < userList.Count - 1; i++)
                {
                    if (userList[i].UserName.ToLower() == u.ToLower())
                    {
                        f = userList[i].FirstName;
                        l = userList[i].LastName;
                        m = userList[i].IkonMemberId;
                        return true;
                    }
                }
            }

            return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"] != null)
            {
                Label4.Text = "User/Password is invalid";
            }
        }

        protected async void Button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                string[] getArray = new string[2];
                //check against okta db
                getArray = await GetTokens(TextBox1.Text, TextBox2.Text);
                if (getArray != null) //if user is there take the session token access token to the next step
                {
                    string userStr = TextBox1.Text;
                    Application["utoken"] = userStr;
                    Application["itoken"] = getArray[0];
                    Application["atoken"] = getArray[1];
                    Response.Redirect("/authorize/callback.aspx");
                }
                else //create the user
                {
                    string fName = string.Empty;
                    string lName = string.Empty;
                    string ikonId = string.Empty;

                    if (LegacyCreds(TextBox1.Text, TextBox2.Text, ref fName, ref lName, ref ikonId)) //check against db for valid credentials
                    {
                        var client = new OktaClient(new OktaClientConfiguration
                        {
                            OktaDomain = ConfigurationManager.AppSettings["okta:OktaDomain"].ToString(),
                            Token = ConfigurationManager.AppSettings["okta:APIkey"].ToString(),
                        });

                        var results = await client.Users.CreateUserAsync(new CreateUserWithPasswordOptions
                        {
                            Profile = new UserProfile
                            {
                                FirstName = fName,
                                LastName = lName,
                                Email = TextBox1.Text,
                                Login = TextBox1.Text,
                            },
                            Password = TextBox2.Text,
                            Activate = true,
                        });

                        var userUpdate = client.Users.GetUserAsync(TextBox1.Text);
                        userUpdate.Result.Profile["ikonMemberId"] = ikonId;
                        var updResults = await userUpdate.Result.UpdateAsync();

                        getArray = await GetTokens(TextBox1.Text, TextBox2.Text);
                        string userStr = TextBox1.Text;
                        Application["utoken"] = userStr;
                        Application["itoken"] = getArray[0];
                        Application["atoken"] = getArray[1];
                        Response.Redirect("/authorize/callback.aspx");
                    }
                    else
                    {
                        Label4.Text = "User/Password is invalid";
                    }
                }
            }
            catch (Exception ex)
            {
                _ = ex;
                Label4.Text = "User/Password is invalid";
            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("https://twu.oktapreview.com/oauth2/v1/authorize?idp=0oau0jrldpmnd6z2s0h7&client_id=0oatxinjpsnnXRTia0h7&response_type=id_token&response_mode=fragment&scope=openid%20email&redirect_uri=http%3A%2F%2Flocalhost%3A8080%2Fauthorize%2Fcallback&state=state&nonce=nonce");
        }
    }
}