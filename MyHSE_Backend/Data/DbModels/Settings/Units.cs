using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class Units
    {


        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }



        [Display(Name = "Unit Of Measurement")]
        public string UOMID { get; set; } = string.Empty;


        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;
    }
}
