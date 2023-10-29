using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.LK01
{
    public partial class Incident
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Request Id")]
        public string RequestId { get; set; }

        [Display(Name = "Request Type")]
        public string RequestType { get; set; }

        [Display(Name = "Incident Number")]
        public string IncNumber { get; set; }

        [Display(Name = "Incident Date")]
        public DateTime? IncDate { get; set; }

        [Display(Name = "Incident Time")]
        public TimeSpan? IncTime { get; set; }

        [Display(Name = "Summary During Incident")]
        public string? SumDuringInc { get; set; }

        [Display(Name = "Summary Before Incident")]
        public string? SumBeforeInc { get; set; }

        [Display(Name = "Summary After Incident")]
        public string? SumAfterInc { get; set; }

        [Display(Name = "Incident Classification Id")]
        public int? IncClassificationId { get; set; }

        [Display(Name = "Incident Category Id")]
        public int? IncCategoryId { get; set; }

        [Display(Name = "Comments")]
        public string? Comments { get; set; }

        [Display(Name = "Victim Number")]
        public int? VictNumber { get; set; }

        [Display(Name = "Number of Sick Leaves")]
        public int? NoSickLeaves { get; set; }

        [Display(Name = "Department Id")]
        public Guid? DepId { get; set; }

        [Display(Name = "Financial Year")]
        public int? Financial { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }
        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }
        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }
        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }
    }

}
