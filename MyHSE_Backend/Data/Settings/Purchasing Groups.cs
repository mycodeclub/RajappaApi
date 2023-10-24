using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.Settings
{
    public class Purchasing_Groups
    {


        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }


        [Display(Name = "Purchasing Group")]
        public string PDGRP { get; set; } = string.Empty;

        [Display(Name = "Name")]
        public string NAME { get; set; } = string.Empty;
    }
}
