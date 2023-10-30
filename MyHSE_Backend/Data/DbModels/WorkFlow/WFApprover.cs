using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.WorkFlow;

public partial class WFApprover
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid Id { get; set; }

    [Display(Name = "Organization ID")]
    public string? OrgId { get; set; }

    [Display(Name = "Requestor ID")]
    public string? RUserId { get; set; }

    [Display(Name = "Plant")]
    public string? Plant { get; set; }

    [Display(Name = "Cost Center")]
    public string? Kostl { get; set; }

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

    [Display(Name = "User ID")]
    public string? UserId { get; set; }

    [Display(Name = "Edit Mode")]
    public string? EditMode { get; set; }

    [Display(Name = "Posting")]
    public string? SPost { get; set; }
    
    [Display(Name = "First Name")]
    public string? FName { get; set; }

    [Display(Name = "Last Name")]
    public string? LName { get; set; }

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
