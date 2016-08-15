using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Finance.Controllers.Controllers;
using Finance.Logic.Indentity;
using Generic.Framework.Interfaces.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace Finance.Api.Controllers
{
    /// <summary>
    /// Don't delete me, I am used for testing
    /// </summary>
    /// <remarks>http://cdn.wegotthiscovered.com/wp-content/uploads/PussInBoots1.gif</remarks>

    public partial class TokenTestingController : BaseController
    {
        public TokenTestingController()
        {
            
        }

        public TokenTestingController(IPersistanceFactory persistanceFactory, ApplicationUserManager userManager)
            : base(persistanceFactory)
        {
            UserManager = userManager;
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private string userName = "marcsstevenson@hotmail.com";
        private string password = "go4somebeer";
        private string url = "http://localhost:1319/";

        [HttpGet]
        public virtual JsonResult Register()
        {
            string responseValue = null;
            var urlRegister = url + "api/Account/Register";
            var registerModel = new

            {
                Email = userName,
                Password = password,
                ConfirmPassword = password
            };
            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsJsonAsync(
                    urlRegister,
                    registerModel).Result;
                responseValue = response.StatusCode.ToString();
            }

            return Json(responseValue, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public virtual ActionResult GetToken()
        {
            string responseValue = null;
            var pairs = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "grant_type", "password" ),
                            new KeyValuePair<string, string>( "username", userName ),
                            new KeyValuePair<string, string> ( "Password", password )
                        };
            //var content = new FormUrlEncodedContent(pairs);
            var json = JsonConvert.SerializeObject(pairs, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(url + "Token", content).Result;
                responseValue = response.Content.ReadAsStringAsync().Result;
            }

            return View(new Tuple<bool, string>(false, responseValue));
        }

        public string GetTokenResponse()
        {
            string responseValue = null;
            var tokenUrl = "http://" + Request.Url.Authority + "/Token";

            var pairs = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "grant_type", "password" ),
                            new KeyValuePair<string, string>( "username", userName ),
                            new KeyValuePair<string, string> ( "Password", password )
                        };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(tokenUrl, content).Result;
                responseValue = response.Content.ReadAsStringAsync().Result;
            }

            return responseValue;
        }

        [HttpGet]
        public virtual JsonResult TestAuthentication()
        {
            var tokenResponse = this.GetTokenResponse();
            // Deserialize the JSON into a Dictionary<string, string>
            Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(tokenResponse);

            string token = tokenDictionary["access_token"];

            string responseValue = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var response =
                    client.GetAsync(url + "api/TokenTestingApi/TestAuthentication").Result;
                responseValue = response.Content.ReadAsStringAsync().Result;
            }

            return Json(responseValue, JsonRequestBehavior.AllowGet);
        }
    }
}
