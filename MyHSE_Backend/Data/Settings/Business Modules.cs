using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.Settings
{
    public class Business_Modules
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "Business Module")]
        public string BUSMTYPE { get; set; } = string.Empty;

        [Display(Name = "Active")]
        public Boolean ACTIVE { get; set; } 

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
