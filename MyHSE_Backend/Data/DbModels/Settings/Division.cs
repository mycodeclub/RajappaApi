using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class Division
    {
        [Key]
        [Display(Name = "Division ID")]
        public Guid Id { get; set; }

        [Display(Name = "Division Name")]
        public string? DivisionName { get; set; }

        [Display(Name = "Division Description")]
        public string? DivisionDescription { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

        [Display(Name = "Active")]
        public bool? Active { get; set; }

    }
}
