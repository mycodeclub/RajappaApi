using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class Purchasing_Organizations
    {


        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }



        [Display(Name = "Purchasing Organization")]
        public string PDORG { get; set; } = string.Empty;


        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;

        [Display(Name = "Company Code")]
        public string ORGID { get; set; } = string.Empty;
    }
}
