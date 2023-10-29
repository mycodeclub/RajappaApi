using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public class IncidentClassification
{
    [Key]
    [Display(Name = "Incident Classification ID")]
    public Guid IncClassificId { get; set; }

    [Display(Name = "Incident Classification Name")]
    public string? IncClassificName { get; set; }

    [Display(Name = "Incident Classification Description")]
    public string? IncClassificDescription { get; set; }

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
