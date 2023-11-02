using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Docs
{/// <summary>
/// Workflow Log
/// </summary>
    public class WorkflowLog
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Request ID")]
        public string RequestId { get; set; } 

        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;

        [Display(Name = "Object ID")]
        public string OBJID { get; set; } = string.Empty;

        [Display(Name = "Reported Date")]
        public string RDATE  { get; set; } = string.Empty;

        [Display(Name = "Reported Time")]
        public string RTIME  { get; set; } = string.Empty;

        [Display(Name = "Reported User")]
        public string RUSER  { get; set; } = string.Empty;

        [Display(Name = "Sequence")]
        public string SEQUENCE { get; set; } = string.Empty;

        [Display(Name = "Position")]
        public string POSITION { get; set; } = string.Empty;

        [Display(Name = "WF Status [List Box]")]
        public string WFSTATUS { get; set; } = string.Empty;

        [Display(Name = "WF Approver")]
        public string WFAPPR { get; set; } = string.Empty;

        [Display(Name = "WF Substitute")]
        public string Remarks { get; set; } = string.Empty;

        [Display(Name = "Action Date")]
        public string ADATE { get; set; } = string.Empty;

        [Display(Name = "Action Time")]
        public string ATIME { get; set; } = string.Empty;

        [Display(Name = "Action User")]
        public string AUSER { get; set; } = string.Empty;

        [Display(Name = "Action User Name")]
        public string AUSERNAME { get; set; } = string.Empty;

        [Display(Name = "Reported User Name")]
        public string RUSERNAME { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        public string CREATEDDATE { get; set; } = string.Empty;

        [Display(Name = "Created Time")]
        public string CREATEDTIME { get; set; } = string.Empty;

        [Display(Name = "Changed By")]
        public string CHANGEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date")]
        public string CHANGEDDATE { get; set; } = string.Empty;

        [Display(Name = "Changed Time")]
        public string CHANGEDTIME { get; set; } = string.Empty;


    }
}
