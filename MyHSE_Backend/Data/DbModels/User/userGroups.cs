using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

namespace MyHSE_Backend.Data.DbModels.User
{/// <summary>
/// User Groups
/// 
/// </summary>
    public class UserGroups
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "User Group")]
        public string USGRP { get; set; }

        [Display(Name = "Description")]
        public string NAME { get; set; }

        [Display(Name = "Active [Yes/No]")]
        public bool ACTIVE { get; set; }



        [Display(Name = "Created By")]
        public DateTime CREATEDBY { get; set; }


        [Display(Name = "Created Date")]

        public DateTime CREATEDON { get; set; }



        [Display(Name = "Changed By")]
        public DateTime MODIFIEDBY { get; set; }


        [Display(Name = "Changed Date")]
        public DateTime MODIFIEDON { get; set; }

    }
}
