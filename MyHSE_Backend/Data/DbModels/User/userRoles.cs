using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.User
{/// <summary>
 /// User Roles
 /// </summary>
    public class UserRoles
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "User ID")]
        public string Login { get; set; } = string.Empty;

        [Display(Name = "Role Unique ID")]
        public string ROLEID { get; set; } = string.Empty;



        [Display(Name = "Role ID")]
        public string ROLE { get; set; } = string.Empty;


        [Display(Name = "Valid From Date")]
        public string VALIDFROM { get; set; } = string.Empty;


        [Display(Name = "Valid To Date")]
        public string VALIDTO { get; set; } = string.Empty;




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
