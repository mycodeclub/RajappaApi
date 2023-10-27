using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.User
{/// <summary>

    /// <summary>
    ///  Permissions
    /// </summary>
    public class RolePermission
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Role Unique ID")]
        public string ROLEID { get; set; } = string.Empty;


        [Display(Name = "Role ID")]
        public char Role { get; set; }

        [Display(Name = "Business Module")]
        public string BUSMTYPE { get; set; } = string.Empty;

        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;

        [Display(Name = "Business Function")]
        public string BUSFTYPE { get; set; } = string.Empty;


        [Display(Name = "Active [Yes/No]")]
        public bool ACTIVE { get; set; } 

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
