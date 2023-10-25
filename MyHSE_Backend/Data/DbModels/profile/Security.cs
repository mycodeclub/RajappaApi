using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyHSE_Backend.Data.DbModels.profile
{/// <summary>
/// Security
/// </summary>
    public class Security
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        //[Display(Name = "Login Type")]
        //public Drop Down  { get; set; } 

        [Display(Name = "OTP ")]
         public bool LGOTP { get; set; }
        
        [Display(Name = "Domain Name")]
        public string LGDOMAIN  { get;  set; } = string.Empty;

        [Display(Name = "Session Timeout")]
        public int TIMEOUT  { get; set; }

        [Display(Name = "Login Attempts")]
        public int LGCOUNT  { get; set; }

        [Display(Name = "Captcha?")]
        public bool CAPTCHA { get; set; }

       [Display(Name = "Password Length")]
        public int PWLENGTH { get; set; } 

       [Display(Name = "Upper Case?")]
       public bool PWUPPERCASE { get; set; }

       [Display(Name = "Special Character?")]
       public bool PWSPCHAR { get; set; }

        [Display(Name = "Number?")]
        public bool PWNUMBER { get; set; }

        [Display(Name = "Initial Password")]
        public string IPASSWORD { get; set; } = string.Empty;

        [Display(Name = "SSO URL")]
        public string SSOURL { get; set; } = string.Empty;

        [Display(Name = "SAP URL")]
        public string p { get; set; } = string.Empty;

        [Display(Name = "SAP User")]
        public string SAPUSER { get; set; } = string.Empty;

        [Display(Name = "SAP Password")]
        public string SAPPW { get; set; } = string.Empty;

        [Display(Name = "SMTP URL")]
        public string SMTP  { get; set; } = string.Empty;

        [Display(Name = "SMS API")]
        public string SMSAPI { get; set; } = string.Empty;

        [Display(Name = "WhatsApp API")]
        public string WHATSAPPAPI { get; set; } = string.Empty;

        [Display(Name = "Google FCM Key")]
        public string GFCMKEY { get; set; } = string.Empty;

        [Display(Name = "Apple FCM Key")]
        public string AFCMKEY { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        public string CREATEDDATE { get; set; } = string.Empty;

        [Display(Name = "Created Time")]
        public string CREATEDTIME { get; set; } = string.Empty;


        [Display(Name = "Changed By")]
        public string CHANGEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date")]
        public string CHANGEDDATE { get; set; } = string.Empty;

        [Display(Name = "Changed Time")]
        public string CHANGEDTIME { get; set; } = string.Empty;







    }
}
