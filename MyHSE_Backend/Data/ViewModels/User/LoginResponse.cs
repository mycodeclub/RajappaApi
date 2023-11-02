using MyHSE_Backend.Data.DbModels.User;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.ViewModels.User
{
    public class LoginResponse
    {
        public bool IsLoginSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<string>? ErrorMessages { get; set; }
        public string FName { get; set; } = string.Empty;
        public string LName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;

        public List<UserGroup> UserGroups = new List<UserGroup>() { };
        //{
        //    new UserGroup() { Name = "Admin", isActive = true },
        //    new UserGroup() { Name = "Accounts", isActive = true },
        //    new UserGroup() { Name = "HR", isActive = false },
        //    new UserGroup() { Name = "Dev", isActive = true },
        //    new UserGroup() { Name = "Sales", isActive = false },
        //}; 
        public List<string> ActiveRoles { get; set; } = new List<string>() { };// = new List<string>() { "Admin", "Accounts" };



    }
    public class UserGroup
    {
        [Display(Name = "User Group")]
        public string USGRP { get; set; }

        [Display(Name = "Description")]
        public string NAME { get; set; }

        [Display(Name = "Active [Yes/No]")]
        public bool ACTIVE { get; set; }
    }

}
