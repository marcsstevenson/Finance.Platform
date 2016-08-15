//using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;

//namespace Finance.Api.Models
//{
//    // Models returned by AccountController actions.

//    public class ExternalLoginConfirmationViewModel
//    {
//        [Required]
//        [EmailAddress]
//        [DisplayName("Email Address")]
//        public string EmailAddress { get; set; }
//    }

//    public class ManageUserViewModel
//    {
//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Current password")]
//        public string OldPassword { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "New password")]
//        public string NewPassword { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm new password")]
//        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }

//    public class LoginViewModel
//    {
//        [Required]
//        //[EmailAddress]
//        [DisplayName("Email Address")]
//        public string EmailAddress { get; set; }

//        [Required]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [Display(Name = "Remember me?")]
//        public bool RememberMe { get; set; }
//    }
    
//    public class RegisterViewModel
//    {
//        [Required]
//        [EmailAddress]
//        [DisplayName("Email Address")]
//        public string EmailAddress { get; set; }

//        //[Required]
//        //[Compare("EmailAddress", ErrorMessage = "Your email addresses do not match")]
//        //[DisplayName("Email Address Confirm")]
//        //public string EmailAddressConfirm { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }

//        [DataType(DataType.Password)]
//        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
//        public string ConfirmPassword { get; set; }
//    }
//    public class ExternalLoginViewModel
//    {
//        public string Name { get; set; }

//        public string Url { get; set; }

//        public string State { get; set; }
//    }

//    public class ManageInfoViewModel
//    {
//        public string LocalLoginProvider { get; set; }

//        public string UserName { get; set; }

//        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

//        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
//    }

//    public class UserInfoViewModel
//    {
//        public string UserName { get; set; }

//        public bool HasRegistered { get; set; }

//        public string LoginProvider { get; set; }
//    }

//    public class UserLoginInfoViewModel
//    {
//        public string LoginProvider { get; set; }

//        public string ProviderKey { get; set; }
//    }

//    public class ForgottenPasswordViewModel
//    {
//        [Required]
//        [EmailAddress]
//        [DisplayName("Email Address")]
//        public string EmailAddress { get; set; }

//        public bool EmailSent { get; set; }

//        [DefaultValue(LoginDestination.Planner)]
//        public LoginDestination LoginDestination { get; set; }
//    }

//    public class ResetPasswordViewModel
//    {
//        [EmailAddress]
//        [DisplayName("Email Address")]
//        public string EmailAddress { get; set; }

//        [Required]
//        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
//        [DataType(DataType.Password)]
//        [Display(Name = "Password")]
//        public string Password { get; set; }
//;
//   ; }  [Dat}Type(DataType.Password)]
//        [Display(Nam{ = "Confirm password")]
//        [Compare("Password",;E}rorMessage = "The password and confirmation password do not match.")]
//    <   public string Confi>mPasswor{ { g;t; s;t} }

//        public string Us<rId { get; set; }

// >      public string Code{{ ge;; se;;}}

// }      [DefaultValue(LoginDestination.Planner{]
//        public LoginDestina{ion ;ogin;e}tination { get; set; }
//    }

//    p{blic;clas; }esetPasswordErrorViewModel
//    {
//     {  pu;lic ;E}umerab}e<string> Errors { get; set; }

//    }
//    publ{c class ConfirmEmailErrorViewModel
//  { {
//;    ; }public IEnumerable<string> Errors { ge{; se;; }//;//}    }//}
//}
