using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.Settings
{
    /// <summary>
    ///  this table is from Table3 Sheet from provided excell file. 
    /// </summary>
    public class Partners
    {

        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }


        [Display(Name = "Business Object")]
        public string BUSOBJTYPE { get; set; } = string.Empty;


        [Display(Name = "Object ID")]
        public string OBJID { get; set; } = string.Empty;


        [Display(Name = "Partner ID")]
        public string PARNRID { get; set; } = string.Empty;

        [Display(Name = "Counter ")]
        public string COUNTER { get; set; } = string.Empty;

        [Display(Name = "Partner Type")]
        public string PARTYPE { get; set; } = string.Empty;


        [Display(Name = "Partner Function")]
        public string PARFUNC { get; set; } = string.Empty;

        

        [Display(Name = "Partner Function Name")]
        public string BPARFUNCT { get; set; } = string.Empty;


       

        [Display(Name = "Custodian?")]
        public string CUSTODIAN { get; set; } = string.Empty;


        [Display(Name = "Name1")]
        public string NAME1 { get; set; } = string.Empty;


        [Display(Name = "Name2")]
        public string NAME2 { get; set; } = string.Empty;



        [Display(Name = "City")]
        public string CITY { get; set; } = string.Empty;


        [Display(Name = "Street")]
        public string STREET { get; set; } = string.Empty;


        [Display(Name = "House Number 1")]
        public string HOUSE_NUM1 { get; set; } = string.Empty;

        [Display(Name = "House Number 2")]
        public string HOUSE_NUM2 { get; set; } = string.Empty;



        [Display(Name = "Street")]
        public string STREET { get; set; } = string.Empty;


        [Display(Name = "Street 2")]
        public string STREET2 { get; set; } = string.Empty;

        
        [Display(Name = "Street 3")]
        public string STREET3 { get; set; } = string.Empty;



        [Display(Name = "Street 4")]
        public string STREET4 { get; set; } = string.Empty;


        [Display(Name = "Street 4")]
        public string STREET4 { get; set; } = string.Empty;



        [Display(Name = "Landmark")]
        public string LANDMARK { get; set; } = string.Empty;


        [Display(Name = "Floor")]
        public string FLOOR { get; set; } = string.Empty;


        [Display(Name = "Building")]
        public string BUILDING { get; set; } = string.Empty;



        [Display(Name = " Region ")]
        public string REGION { get; set; } = string.Empty;





        [Display(Name = " Country ")]
        public string COUNTRY { get; set; } = string.Empty;



        [Display(Name = " PostalCcode ")]
        public string ZIPCODE { get; set; } = string.Empty;



        [Display(Name = " Telephone no ")]
        public string TELNUMBER { get; set; } = string.Empty;



        [Display(Name = " Mobile no ")]
        public string MOBNUMBER { get; set; } = string.Empty;



        [Display(Name = " E-Mail Address ")]
        public string EMAILADDR { get; set; } = string.Empty;




        [Display(Name = " Text Field ")]
        public string USR01 { get; set; } = string.Empty;


        [Display(Name = " Text Field ")]
        public string USR02 { get; set; } = string.Empty;

        [Display(Name = " Text Field ")]
        public string USR03 { get; set; } = string.Empty;


        [Display(Name = " Text Field ")]
        public string USR04 { get; set; } = string.Empty;



        [Display(Name = " Text Field ")]
        public string USR05 { get; set; } = string.Empty;



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
