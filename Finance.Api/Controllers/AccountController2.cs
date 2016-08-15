//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.Entity;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.UI;
//using Finance.Api.Models;
//using Finance.Logic.Indentity;
//using Generic.Framework.Helpers;
//using Generic.Framework.Interfaces.Entity;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.Owin.Security;

//namespace Finance.Api.Controllers
//{
//    [System.Web.Http.Authorize]
//    [System.Web.Http.RoutePrefix("api/Account")]
//    public class AccountController : Finance.Controllers.Controllers.BaseController
//    {
//        public AccountController(IPersistanceFactory persistanceFactory, /*IEmailService emailService,*/ IIdentityManager identityManager/*, IBlobStorageHelper blobStorageHelper*/) : base(persistanceFactory/*, blobStorageHelper*/)
//        {
//            //this.EmailHelper = new EmailHelper(emailService, this.CurrentUrlConfiguration);
//            this._partyService = new PartyService(persistanceFactory);
//            this._identityManager = identityManager;
//        }

//        private readonly PartyService _partyService;
//        private readonly IIdentityManager _identityManager;

//        public UserManager<PartyIdentityUser> UserManager { get { return _identityManager.UserManager; } }

//        private RoleManager<IdentityRole> RoleManager { get { return _identityManager.RoleManager; } }

//        //
//        // GET: /Account/Login
//        [AllowAnonymous]
//        [OutputCache(NoStore = true, Location = OutputCacheLocation.None)]
//        public virtual ActionResult Login(string returnUrl)
//        {
//            if (Request.IsAuthenticated)
//                if (Request.UrlReferrer == null)
//                    return RedirectToAction("Index", "Home");
//                else
//                    return RedirectToUrl(Request.UrlReferrer.AbsoluteUri);

//            ViewBag.ReturnUrl = string.IsNullOrWhiteSpace(returnUrl) ? Request.UrlReferrer == null ? null : Request.UrlReferrer.AbsoluteUri : returnUrl;
//            return View();
//        }

//        private ActionResult RedirectToUrl(string returnUrl)
//        {
//            if (string.IsNullOrEmpty(returnUrl))
//                return RedirectToAction("Index", "Home");
//            else
//                return Redirect(returnUrl);
//        }

//        //
//        // POST: /Account/Login
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public virtual async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
//        {
//            var invalidMessage = "Invalid username or password.";
//            var lockedMessage = string.Format("Your account has been locked out for" + " {0} " + "minutes due to multiple failed login attempts.", ConfigurationManager.AppSettings["DefaultAccountLockoutTimeSpan"].ToString());
            
//            if (ModelState.IsValid)
//            {
//                model.EmailAddress = model.EmailAddress.Trim();
//                var validCredentials = await UserManager.FindAsync(model.EmailAddress, model.Password);

//                if (validCredentials == null) //The username and password did not match an existing user
//                {
//                    var userRecord = await UserManager.Users.FirstOrDefaultAsync(i => i.UserName == model.EmailAddress);

//                    if (userRecord != null) //There is a user with that email address as a useraname
//                    {
//                        if (await UserManager.IsLockedOutAsync(userRecord.Id))
//                        {
//                            //The user is locked out - tell them
//                            ModelState.AddModelError("", lockedMessage);
//                        }
//                        else
//                        {
//                            //Record the failure which also may cause the user to be locked out
//                            await UserManager.AccessFailedAsync(userRecord.Id);
//                            ModelState.AddModelError("", invalidMessage);
//                        }
//                    }
//                    else
//                    {
//                        ModelState.AddModelError("", invalidMessage);
//                    }
//                }
//                else
//                {
//                    //Ensure that the user is not locked out
//                    if (await UserManager.IsLockedOutAsync(validCredentials.Id))
//                    {
//                        ModelState.AddModelError("", lockedMessage);
//                    }
//                    else
//                    {
//                        //Sign in and continue on our merry way
//                        await SignInAsync(validCredentials, model.RememberMe);

//                        //When token is verified correctly, clear the access failed count used for lockout
//                        await UserManager.ResetAccessFailedCountAsync(validCredentials.Id);
                        
//                        return RedirectToUrl(returnUrl);
//                    }
//                }
//            }

//            //If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        private IAuthenticationManager AuthenticationManager
//        {
//            get
//            {
//                return HttpContext.GetOwinContext().Authentication;
//            }
//        }

//        private async Task SignInAsync(PartyIdentityUser user, bool isPersistent)
//        {
//            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
//            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
//            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
//        }


//        //
//        // GET: /Account/Register
//        [AllowAnonymous]
//        public virtual ActionResult Register()
//        {
//            ViewBag.ReturnUrl = Request.UrlReferrer == null ? null : Request.UrlReferrer.AbsoluteUri;
//            return View();
//        }

//        //POST: /Account/Register
//        [HttpPost]
//        [AllowAnonymous]
//        [ValidateAntiForgeryToken]
//        public virtual async Task<ActionResult> Register(RegisterViewModel model, string returnUrl)
//        {
//            if (ModelState.IsValid)
//            {
//                model.EmailAddress = model.EmailAddress.Trim();

//                var partyIdentityUser = PartyService.BuildNewIdentityUser(model.EmailAddress);
                
//                var result = await UserManager.CreateAsync(partyIdentityUser, model.Password);

//                if (result.Succeeded)
//                {
//                    await SignInAsync(partyIdentityUser, isPersistent: true);
//                    return RedirectToUrl(returnUrl);
//                }
//                else
//                {
//                    AddErrors(result);
//                }
//            }

//            // If we got this far, something failed, redisplay form
//            return View(model);
//        }

//        private void AddErrors(IdentityResult result)
//        {
//            foreach (var error in result.Errors)
//            {
//                ModelState.AddModelError("", error);
//            }
//        }

//        private void AddErrors(CommitResult result)
//        {
//            ModelState.AddModelError("", result.ErrorMessage);
//        }

//        //
//        // GET: /Account/ForgottenPassword
//        //[AllowAnonymous]
//        //public virtual ActionResult ForgottenPassword()
//        //{
//        //    var vm = new ForgottenPasswordViewModel
//        //    {
//        //        EmailSent = false
//        //    };
//        //    return View(vm);
//        //}

//        ////POST: /Account/ForgottenPassword
//        //[HttpPost]
//        //[AllowAnonymous]
//        //[ValidateAntiForgeryToken]
//        //public virtual async Task<ActionResult> ForgottenPassword(ForgottenPasswordViewModel model)
//        //{
//        //    if (ModelState.IsValid)
//        //    {
//        //        var user = UserManager.FindByName(model.EmailAddress);
//        //        if (user == null)
//        //        {
//        //            this.ModelState.AddModelError("EmailAddress", "Email Address Not Found");
//        //        }
//        //        else
//        //        {
//        //            var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);

//        //            var message = UserMailer.PasswordReset(user, code, LoginDestination.Planner, Request.Url.Scheme);
//        //            EmailHelper.Deliver(message);

//        //            var emailTrackerService = new EmailTrackerService(this.PersistanceFactory);
//        //            var commitResult = emailTrackerService.SaveEmailTracker(message.To.ToString(), message.CC.ToString(),
//        //                message.Subject, message.Body);
//        //            if (commitResult.HasError) throw commitResult.Error;

//        //            model.EmailSent = true;
//        //        }
//        //    }

//        //    // Model has been updated with results, so redisplay form
//        //    return View(model);
//        //}

//        //
//        // GET: /Account/ResetPassword
//        //[AllowAnonymous]
//        //public virtual ActionResult ResetPassword(string userId, string code, LoginDestination destination = LoginDestination.Planner)
//        //{
//        //    var user = UserManager.FindById(userId);
//        //    if (user != null & !string.IsNullOrEmpty(code))
//        //    {
//        //        var vm = new ResetPasswordViewModel
//        //        {
//        //            EmailAddress = user.UserName,
//        //            UserId = userId,
//        //            Code = code,
//        //            LoginDestination = destination
//        //        };
//        //        return View(vm);

//        //    }

//        //    var errors = new List<string>();
//        //    if (string.IsNullOrEmpty(code))
//        //        errors.Add("Code is missing");
//        //    if (user == null)
//        //        errors.Add("User ID is not found");

//        //    var evm = new ResetPasswordErrorViewModel
//        //    {
//        //        Errors = errors
//        //    };
//        //    return System.Web.UI.WebControls.View("ResetPasswordError", evm);
//        //}

//        ////POST: /Account/ForgottenPassword
//        //[HttpPost]
//        //[AllowAnonymous]
//        //[ValidateAntiForgeryToken]
//        //public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
//        //{
//        //    if (!ModelState.IsValid) return View(model);

//        //    var result = UserManager.ResetPassword(model.UserId, model.Code, model.Password);
//        //    if (result.Succeeded)
//        //    {
//        //        var user = UserManager.FindByName(model.EmailAddress);
//        //        await SignInAsync(user, isPersistent: true);
//        //        var destination = DestinationHelper.GetDestinationAction(model.LoginDestination);
//        //        return RedirectToAction(destination);
//        //    }
//        //    else
//        //    {
//        //        foreach (var error in result.Errors)
//        //        {
//        //            if (error == "Invalid token.")
//        //                this.ModelState.AddModelError("", "Cannot reset password using this link.  Either the link is incorrect, you have already reset your password using this link, or the link has expired.");
//        //            else
//        //                this.ModelState.AddModelError("", error);
//        //        }
//        //    }

//        //    return View(model);
//        //}


//        // Change password functionality for already logged in users
//        // GET: /Account/ChangePassword
//        //public virtual ActionResult ChangePassword()
//        //{
//        //    var user = this.CurrentParty.PartyIdentityUser;
//        //    var code = UserManager.GeneratePasswordResetToken(user.Id);
//        //    var vm = new ResetPasswordViewModel
//        //    {
//        //        EmailAddress = user.UserName,
//        //        UserId = user.Id,
//        //        Code = code

//        //    };
//        //    return System.Web.UI.WebControls.View(MVC.Account.Views.ResetPassword, vm);
//        //}

//        ////POST: /Account/ForgottenPassword
//        //[HttpPost]
//        //public virtual async Task<ActionResult> ChangePassword(ResetPasswordViewModel model)
//        //{
//        //    if (!ModelState.IsValid) return System.Web.UI.WebControls.View(MVC.Account.Views.ForgottenPassword, model);

//        //    var result = UserManager.ResetPassword(model.UserId, model.Code, model.Password);
//        //    if (result.Succeeded)
//        //    {
//        //        var user = UserManager.FindByName(model.EmailAddress);
//        //        await SignInAsync(user, isPersistent: true);
//        //        return RedirectToUrl("/Profile");
//        //    }
//        //    else
//        //    {
//        //        foreach (var error in result.Errors)
//        //        {
//        //            if (error == "Invalid token.")
//        //                this.ModelState.AddModelError("", "Cannot reset password using this link.  Either the link is incorrect, you have already reset your password using this link, or the link has expired.");
//        //            else
//        //                this.ModelState.AddModelError("", error);
//        //        }
//        //    }

//        //    return System.Web.UI.WebControls.View(MVC.Account.Views.ResetPassword, model);
//        //}

//    }
//}
