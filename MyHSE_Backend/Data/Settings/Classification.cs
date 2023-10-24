using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.Settings
{
    public class Classification
    {


        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }



        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;



        [Display(Name = "Object ID")]
        public string OBJID { get; set; } = string.Empty;



        [Display(Name = "Class")]
        public string CLASS { get; set; } = string.Empty;



        [Display(Name = "Characteristic ID)]
        public string CHARID { get; set; } = string.Empty;



        [Display(Name = "Characteristic Name")]
        public string CHARNAME { get; set; } = string.Empty;



        [Display(Name = "Counter")]
        public string COUNTER { get; set; } = string.Empty;



        [Display(Name = "Characteristic Value")]
        public string VALUE { get; set; } = string.Empty;




        [Display(Name = "Unit")]
        public string UNIT { get; set; } = string.Empty;



        [Display(Name = "Class Name")]
        public string CLASSNAME { get; set; } = string.Empty;



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
