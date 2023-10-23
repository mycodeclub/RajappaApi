using System.ComponentModel.DataAnnotations;
using static Azure.Core.HttpHeader;

namespace MyHSE_Backend.Data.DbModels.User
{
    public class userGroups
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "User Group")]
        public string USGRP { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string NAME { get; set; } = string.Empty;

        [Display(Name = "Active [Yes/No]")]
        public string ACTIVE { get; set; } = string.Empty;



        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;


        [Display(Name = "Created Date")]
        public string CREATEDON  { get; set; } = string.Empty;


        [Display(Name = "Changed By")]
        public string MODIFIEDBY  { get; set; } = string.Empty;


        [Display(Name = "Changed Date")]
        public string MODIFIEDON  { get; set; } = string.Empty;


        
























    }
}
