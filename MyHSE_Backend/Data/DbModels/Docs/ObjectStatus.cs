using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Docs
{/// <summary>
/// Object Status
/// </summary>
    public class Object_Status
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;

        [Display(Name = "Object ID")]
        public string OBJID { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string STATUS { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;

        [Display(Name = "Active")]
        public bool ACTIVE { get; set; } 

        [Display(Name = "System")]
        public bool SYST { get; set; } 

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
