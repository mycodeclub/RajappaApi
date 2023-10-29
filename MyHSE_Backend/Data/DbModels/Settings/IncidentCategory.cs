using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public class IncidentCategory
{
    [Key]
    [Display(Name = "Incident Category ID")]
    public Guid IncCategoryId { get; set; }

    [Display(Name = "Incident Category Name")]
    public string? IncCategoryName { get; set; }

    [Display(Name = "Incident Category Description")]
    public string? IncCategoryDescription { get; set; }

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
