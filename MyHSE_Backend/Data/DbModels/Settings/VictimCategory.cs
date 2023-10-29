using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class VictimCategory
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid VictCategoryId { get; set; }

    [Display(Name = "Victim Category Name")]
    public string? VictCategoryName { get; set; }

    [Display(Name = "Victim Category Description")]
    public string? VictCategoryDescription { get; set; }

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
