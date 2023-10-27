using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.Settings
{
    public class PurchasingGroups
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
