using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Profile
{
    public class Profilesettings
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Company ID ")]
        public string CUID { get; set; } = string.Empty;

        [Display(Name = " Company Name")]
        public string CPNAME { get; set; } = string.Empty;

        [Display(Name = "Company Logo ")]
        public string CPLOGO { get; set; } = string.Empty;

        [Display(Name = "Website ")]
        public string WEBSITE { get; set; } = string.Empty;

        [Display(Name = "Time Zone ")]
        public string TIMEZONE { get; set; } = string.Empty;

        [Display(Name = "Portal Title ")]
        public string PTITLE { get; set; } = string.Empty;

        [Display(Name = "Portal Logo ")]
        public string PLOGO { get; set; } = string.Empty;

        [Display(Name = "Sub Domain ")]
        public string SubDomain  { get; set; } = string.Empty;

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
