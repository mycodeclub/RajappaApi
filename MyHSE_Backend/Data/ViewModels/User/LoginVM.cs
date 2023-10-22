using System.ComponentModel.DataAnnotations;

namespace MyHSE_Backend.Data.ViewModels.User
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
