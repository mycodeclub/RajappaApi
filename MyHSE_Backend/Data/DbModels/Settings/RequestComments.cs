using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class RequestComments
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid CommentId { get; set; }

    [Required]
    [Display(Name = "Request Id")]
    public string RequestId { get; set; } 

    [Display(Name = "Financial Year")]
    public int? FYear { get; set; }

    [Display(Name = "Business Module")]
    public string? BusMType { get; set; }

    [Display(Name = "Business Object")]
    public string? BusObjType { get; set; }


    [Display(Name = "Comment Description")]
    public string? CommentDescription { get; set; }

    [Display(Name = "Comment Category")]
    public Guid? CommentCategory { get; set; }

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
