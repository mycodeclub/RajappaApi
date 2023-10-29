using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class Comment
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid CommentId { get; set; }

    [Display(Name = "Comment Description")]
    public string? CommentDescription { get; set; }

    [Display(Name = "Comment Category")]
    public Guid? CommentCategory { get; set; }

    [Display(Name = "Request Id")]
    public string? RequestId { get; set; }

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
