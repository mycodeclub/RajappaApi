using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.WorkFlow;

public partial class WFGeneral
{
    [Key]
    [Display(Name = "Unique ID")]
    public Guid Id { get; set; }

    [Display(Name = "Organization ID")]
    public string? OrgId { get; set; }
  
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

    [Display(Name = "Escalation")]
    public bool? WFEsct { get; set; }

    [Display(Name = "Reminder")]
    public bool? WFRemd { get; set; }

    [Display(Name = "Target SLA Days")] 
    public float? WFTSla { get; set; }

    [Display(Name = "Reminder Days")]
    public float? WFTRmd { get; set; }

    [Display(Name = "Outlook Email")]
    public bool? Outlook { get; set; }

    [Display(Name = "Inbox")]
    public bool? Inbox { get; set; }

    [Display(Name = "Created On")]
    public DateTime? CreatedOn { get; set; }

    [Display(Name = "Modified On")]
    public DateTime? ModifiedOn { get; set; }

    [Display(Name = "Created By")]
    public string? CreatedBy { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }
       
}
