using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class Organizations
    {

        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

       
        [Display(Name = "Organization ID")]
        public Guid ORGID { get; set; }


        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;



        [Display(Name = "Country")]
        public string COUNTRY { get; set; } = string.Empty;



        [Display(Name = "Currency ")]
        public string CURRENCY { get; set; } = string.Empty;



        [Display(Name = "Language")]
        public string LANG { get; set; } = string.Empty;


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
