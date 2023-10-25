
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyHSE_Backend.Data.DbModels.User
{/// <summary>
/// Roles
/// </summary>
    public class Roles
    {
        [Key]
        
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }


        [Display(Name = "Role ID")]
        public string Role { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string NAME  { get; set; } = string.Empty;

        [Display(Name = "Active [Yes/No]")]
        public string ACTIVE  { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        public string CREATEDDATE { get; set; } = string.Empty;

        [Display(Name = "Created Time")]
        public string CREATEDTIME  { get; set; } = string.Empty;


        [Display(Name = "Changed By")]
        public string CHANGEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date")]
        public string CHANGEDDATE { get; set; } = string.Empty;

        [Display(Name = "Changed Time")]
        public string CHANGEDTIME  { get; set; } = string.Empty;


       

     




















    }
}
