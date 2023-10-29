using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings;

public partial class Victim
{
    [Key]
    [Display(Name = "Victim ID")]
    public Guid VictId { get; set; }

    [Display(Name = "Victim Name")]
    public string? VictName { get; set; }

    [Display(Name = "Victim Emp No")]
    public int? VictEmpNo { get; set; }

    [Display(Name = "Victim Category Id")]
    public int? VictCategoryId { get; set; }

    [Display(Name = "Victim Details")]
    public string? VictDetails { get; set; }
    
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
