using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.User
{

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
        public string Role { get; set; } = string.Empty;

        [Display(Name = "Business Module")]
        public string BUSMTYPE { get; set; } = string.Empty;

        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;

        [Display(Name = "Business Function")]
        public string BUSFTYPE { get; set; } = string.Empty;


        [Display(Name = "Active [Yes/No]")]
        public string ACTIVE { get; set; } = string.Empty;

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
