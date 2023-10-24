using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.profile
{
    public class Security
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Login Type")]
        public string LGTYPE { get; set; } = string.Empty;

        [Display(Name = "OTP ")]
         public string LGOTP { get; set; } = string.Empty;
        
        [Display(Name = "Domain Name")]
        public string LGDOMAIN { get;  set; } = string.Empty;

        [Display(Name = "Session Timeout")]
        public string TIMEOUT { get; set; } = string.Empty;

        [Display(Name = "Login Attempts")]
        public string LGCOUNT { get; set; } = string.Empty;

        [Display(Name = "Captcha?")]
        public string CAPTCHA { get; set; } = string.Empty;

       [Display(Name = "Password Length")]
       public string PWLENGTH { get; set; } = string.Empty;

       [Display(Name = "Upper Case?")]
       public string PWUPPERCASE { get; set; } = string.Empty;

       [Display(Name = "Special Character?")]
       public string PWSPCHAR { get; set; } = string.Empty;

        [Display(Name = "Number?")]
        public string PWNUMBER { get; set; } = string.Empty;

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
