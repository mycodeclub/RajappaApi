using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class BusinessObjects
    {

        [Key]
        [Display(Name = "Unique ID")]
        public Guid ID { get; set; }

        [Display(Name = "Business Module")]
        public string BUSMTYPE { get; set; } = string.Empty;


        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;




        [Display(Name = "Active")]
        public bool ACTIVE { get; set; }




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
