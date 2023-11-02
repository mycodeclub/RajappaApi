using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.User
{/// <summary>
 /// UserRoles
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
        public DateTime VALIDFROM { get; set; }


        [Display(Name = "Valid To Date")]
        public string VALIDTO { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        public DateTime CREATEDDATE { get; set; }

        [Display(Name = "Created Time")]
        public DateTime CREATEDTIME { get; set; }


        [Display(Name = "Changed By")]
        public string CHANGEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date")]
        public DateTime CHANGEDDATE { get; set; }

        [Display(Name = "Changed Time")]
        public DateTime CHANGEDTIME { get; set; }
    }
}
