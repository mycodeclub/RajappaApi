using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class Plants
    {


        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }


        [Display(Name = "Plant")]
        public string PLANT { get; set; } = string.Empty;


        [Display(Name = "Organization ID")]
        public string ORGID { get; set; } = string.Empty;


        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;


        [Display(Name = "Name 1")]
        public string NAME1 { get; set; } = string.Empty;



        [Display(Name = "Name 2")]
        public string NAME2 { get; set; } = string.Empty;


        [Display(Name = "House Number")]
        public string HOUSENUM { get; set; } = string.Empty;


        [Display(Name = "Street")]
        public string STREET { get; set; } = string.Empty;


        [Display(Name = "City")]
        public string CITY { get; set; } = string.Empty;


        [Display(Name = "Postal Code")]
        public string ZIPCODE { get; set; } = string.Empty;


        [Display(Name = "Region ")]
        public string REGION { get; set; } = string.Empty;


        [Display(Name = "Country")]
        public string COUNTRY { get; set; } = string.Empty;



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
