using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.DbModels.User
{
    public class AppUser
    {
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Display(Name = "User ID")]
        public string Login { get; set; } = string.Empty;

        [Display(Name = "E-Mail Address")]
        public string EMAILID { get; set; } = string.Empty;

        [Display(Name = "Mobile#")]
        public string TELMB { get; set; } = string.Empty;

        [Display(Name = "First Name")]
        public string FNAME { get; set; } = string.Empty;

        [Display(Name = "Last Name")]
        public string LNAME { get; set; } = string.Empty;

        [Display(Name = "User Type [Lookup]")]
        public string USTYP { get; set; } = string.Empty;

        [Display(Name = "User Group")]
        public string USGRP { get; set; } = string.Empty;


        [Display(Name = "User Roles")]
        public string AUTHORITIES { get; set; } = string.Empty;


        [Display(Name = "External User")]
        public string EXTERNAL { get; set; } = string.Empty;

        [Display(Name = "Register")]
        public string REGISTER { get; set; } = string.Empty;

        [Display(Name = "Lock")]
        public string LOCK { get; set; } = string.Empty;

        [Display(Name = "App Logs")]
        public string APPLOGS { get; set; } = string.Empty;

        [Display(Name = "Password ")]
        public string PASSWORD { get; set; } = string.Empty;

        [Display(Name = "Last Password")]
        public string LPASSWORD { get; set; } = string.Empty;

        [Display(Name = "Country")]
        public string COUNTRY { get; set; } = string.Empty;

        [Display(Name = "Language")]
        public string LANGUAGE { get; set; } = string.Empty;

        [Display(Name = "Time Zone")]
        public string TIMEZONE { get; set; } = string.Empty;

        [Display(Name = "Decimal Format [Lookup]")]
        public string DCPFM { get; set; } = string.Empty;


        [Display(Name = "Date Format [Lookup]")]
        public string DATFM { get; set; } = string.Empty;

        [Display(Name = "Time Format[Lookup]")]
        public string TIMEFM { get; set; } = string.Empty;

        [Display(Name = "Organization ID")]
        public string ORGID { get; set; } = string.Empty;

        [Display(Name = "Plant/Site")]
        public string PLANT { get; set; } = string.Empty;

        [Display(Name = "Work Center ")]
        public string WKCTR { get; set; } = string.Empty;

        [Display(Name = "Planning Plant")]
        public string PPLANT { get; set; } = string.Empty;

        [Display(Name = "Person ID")]
        public string PERSONID { get; set; } = string.Empty;

        [Display(Name = "Planner Group")]
        public string PGROUP { get; set; } = string.Empty;

        [Display(Name = "Partner Function")]
        public string PARVW { get; set; } = string.Empty;

        [Display(Name = "Approval Value")]
        public string AVALUE { get; set; } = string.Empty;

        [Display(Name = "Land Telephone#")]
        public string TELNR { get; set; } = string.Empty;

        [Display(Name = "Device Platform [Lookup]")]
        public string DEVICEPF { get; set; } = string.Empty;

        [Display(Name = "Device Type [Lookup]")]
        public string DEVICETYPE { get; set; } = string.Empty;

        [Display(Name = "Device ID")]
        public string DEVICEID { get; set; } = string.Empty;

        [Display(Name = "Device Serial No")]
        public string DEVICESNO { get; set; } = string.Empty;

        [Display(Name = "Device UDID")]
        public string UDID { get; set; } = string.Empty;

        [Display(Name = "Token ID")]
        public string TOKENID { get; set; } = string.Empty;

        [Display(Name = "Check at Device ID")]
        public string CHKDEVICEID { get; set; } = string.Empty;

        [Display(Name = "Created By")]
        public string CREATEDBY { get; set; } = string.Empty;

        [Display(Name = "Created Date/Time")]
        public DateTime CREATEDON { get; set; }

        //[Display(Name = "Created Time")]
        //public string CREATEDTIME { get; set; } = string.Empty;

        [Display(Name = "Changed By")]
        public string MODIFIEDBY { get; set; } = string.Empty;

        [Display(Name = "Changed Date/Time")]
        public string MODIFIEDON { get; set; } = string.Empty;

        [Display(Name = "Changed Time")]
        public string CHANGEDTIME { get; set; } = string.Empty;

        [Display(Name = "Division")]
        public string DIVISION { get; set; } = string.Empty;

        [Display(Name = "Designation")]
        public string DESIGNATION { get; set; } = string.Empty;

        [Display(Name = "Department")]
        public string DEPARTMENT { get; set; } = string.Empty;


        [Display(Name = "Grade")]
        public string GRADE { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;
        public string Roles { get; set; }
    }
}
