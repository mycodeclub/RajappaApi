using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Extensions;
using MyHSE_Backend.Common;

namespace MyHSE_Backend.Data.DbModels.LK01
{
    public partial class LK01Header
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Request Id")]
        [ReadOnly(true)]
        public string RequestId { get; set; } 

        [Display(Name = "Financial Year")]
        public int? FYear { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Request Status")]
        public string? RStatus { get; set; }

        [Display(Name = "Request Type")]
        public string? RequestType { get; set; }

        [Display(Name = "Incident Type")]
        public string? IncidentType { get; set; }

        [Display(Name = "Incident Date")]
        public DateTime? IncDate { get; set; }

        [Display(Name = "Incident Time")]
        public string? IncTime { get; set; } 

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

        [Display(Name = "Department Id")]
        public Guid? DeptId { get; set; }

        [Display(Name = "LTI")]
        public bool? LTI { get; set; }

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
