using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.WorkFlow;

public partial class WFApprX
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid Id { get; set; }

    [Display(Name = "Business Module")]
    public string? BusMType { get; set; }

    [Display(Name = "Business Object")]
    public string? BusObjType { get; set; }

    [Display(Name = "WF Sequence")]
    public string? WFSequence { get; set; }

    [Display(Name = "WF Position")]
    public string? WFPosition { get; set; }

    [Display(Name = "WF Level Name")]
    public string? WFLvlName { get; set; }

    [Display(Name = "Requestor")]
    public bool? REditMode { get; set; }

    [Display(Name = "Can Edit")]
    public bool? NEditMode { get; set; }

    [Display(Name = "Can Edit")]
    public bool? MEditMode { get; set; }

    [Display(Name = "Created On")]
    public DateTime? CreatedOn { get; set; }

    [Display(Name = "Modified On")]
    public DateTime? ModifiedOn { get; set; }

    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }

   
}
