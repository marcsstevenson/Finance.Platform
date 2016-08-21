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

    public class TokenTestingController : BaseController
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
        //private string url = "http://localhost:1319/";

        private string GetHomeUrl()
        {
            return "http://" + Request.Url.Authority + "/";
        }

        [HttpGet]
        public virtual JsonResult Register()
        {
            string responseValue = null;
            var urlRegister = GetHomeUrl() + "api/Account/Register";
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

            //NOTE: We must form encode the content. Posting JSON will return "error" : "unsupported_grant_type"
            //In angular 1.x:
            /*
             $http({
                    url: 'http://financeplatform.azurewebsites.net/Token',
                    method: 'POST',
                    data: "userName=" + $scope.username + "&password=" + $scope.password + 
                          "&grant_type=password"
            })
             */
            var content = new StringContent($"grant_type=password&username={userName}&password={password}", Encoding.UTF8, "application/x-www-form-urlencoded");

            using (var client = new HttpClient())
            {
                var response =
                    client.PostAsync(GetHomeUrl() + "Token", content).Result;
                responseValue = response.Content.ReadAsStringAsync().Result;
            }

            return View(new Tuple<bool, string>(false, responseValue));
        }

        public string GetTokenResponse()
        {
            string responseValue = null;
            var tokenUrl = GetHomeUrl() + "Token";

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
                    client.GetAsync(GetHomeUrl() + "api/TokenTestingApi/TestAuthentication").Result;
                responseValue = response.Content.ReadAsStringAsync().Result;
            }

            return Json(responseValue, JsonRequestBehavior.AllowGet);
        }
    }
}
