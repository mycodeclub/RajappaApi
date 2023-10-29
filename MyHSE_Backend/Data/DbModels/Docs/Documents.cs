using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Docs
{  /// <summary>
/// Documents
/// </summary>
    public class Documents
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;

        [Display(Name = "Document ID")]
        public string DOCID { get; set; } = string.Empty;

        [Display(Name = "Object ID")]
        public string OBJID  { get; set; } = string.Empty;

        [Display(Name = "Request ID")]
        public string RequestID { get; set; } = string.Empty;

        [Display(Name = "File Name")]
        public string FILENAME  { get; set; } = string.Empty;

        [Display(Name = "File Type")]
        public string FILETYPE  { get; set; } = string.Empty;

        [Display(Name = "File Size MB")]
        public string FILESIZE { get; set; } = string.Empty;

        [Display(Name = "File Path")]
        public string FILEPATH  { get; set; } = string.Empty;

        [Display(Name = "Content")]
        public string CONTENT  { get; set; } = string.Empty;

        [Display(Name = "URL")]
        public string URL { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date")]
        public DateTime CREATEDDATE { get; set; } 

        [Display(Name = "Created Time")]
        public DateTime CREATEDTIME { get; set; } 

        [Display(Name = "Changed By")]
        public string CHANGEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date")]
        public DateTime CHANGEDDATE { get; set; } 

        [Display(Name = "Changed Time")]
        public DateTime CHANGEDTIME { get; set; }

    }
}
