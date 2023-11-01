using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class Department
{

    [Key]
    [Display(Name = "Department ID")]
    public Guid Id { get; set; }

    [Display(Name = "Division ID")]
    public Guid DivisionId { get; set; }

    [Display(Name = "Department Name")]
    public string? DepName { get; set; }

    [Display(Name = "Department Description")]
    public string? DepDescription { get; set; }

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
