using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class LK01Victim
{
    [Key]
    [Display(Name = "Victim ID")]
    public Guid VictId { get; set; }

    [Required]
    [Display(Name = "Request Id")]
    public string RequestId { get; set; }

    [Display(Name = "Financial Year")]
    public int? FYear { get; set; }

    [Display(Name = "Victim Name")]
    public string? VictName { get; set; }

    [Display(Name = "Victim Emp No")]
    public int? VictEmpNo { get; set; }

    [Display(Name = "Victim Category Id")]
    public int? VictCategoryId { get; set; }

    [Display(Name = "Victim Details")]
    public string? VictDetails { get; set; }

    [Display(Name ="Name of Contractor")]
    public string? VictContractor { get; set; }
    
    [Display(Name = "Number of Sick Leaves")]
    public int? NoSickLeaves { get; set; }

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
