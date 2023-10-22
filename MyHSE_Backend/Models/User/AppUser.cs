using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Models.User
{
    public class AppUser
    {
        public AppUser() { }
        [Key]
        [Display(Name = "Unique ID")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "User ID")]
        public string LoginId { get; set; } = string.Empty;

        [Required]
        [Display(Name = "E-Mail Address")]
        public string EmailId { get; set; } = string.Empty;

        [Display(Name = "Mobile#")]
        public string Telmb { get; set; } = string.Empty;

        [NotMapped]
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string LPassword { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime ModifiedOn { get; set; } = DateTime.Now;
        public string? Roles { get; set; } = string.Empty;

        //public AppUser(UserRegistrationVM _userVm)
        //{
        //    Email = _userVm.Email;
        //    Password = _userVm.Password;
        //    PasswordHash = BCrypt.Net.BCrypt.HashPassword(_userVm.Password);
        //}
    }
}
