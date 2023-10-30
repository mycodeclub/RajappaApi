using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.WorkFlow;

public partial class WFContent
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid Id { get; set; }

    [Display(Name = "Organization ID")]
    public string? OrgId { get; set; }

    [Display(Name = "Business Module")]
    public string? BusMType { get; set; }

    [Display(Name = "Business Object")]
    public string? BusObjType { get; set; }

    [Display(Name = "Table Name")]
    public string? TableName { get; set; }

    [Display(Name = "Sequence")]
    public string? FSequence { get; set; }

    [Display(Name = "Field Name")]
    public string? FieldName { get; set; }

    [Display(Name = "Field Text")]
    public string? FieldText { get; set; }

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
