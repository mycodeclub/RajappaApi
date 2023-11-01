using MyHSE_Backend.Data.DbModels.User;

namespace MyHSE_Backend.Data.ViewModels.User
{
    public class LoginResponse
    {
        public bool IsLoginSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<string>? ErrorMessages { get; set; }
        public string FName { get; set; } = "Muskan";
        public string LName { get; set; } = "Srivastava";
        public string Email { get; set; } = "muskan@bpst.com";
        public string Mobile { get; set; } = "9999999999";

        public List<UserGroup> UserGroups = new List<UserGroup>()
        {
            new UserGroup() { Name = "Admin", isActive = true },
            new UserGroup() { Name = "Accounts", isActive = true },
            new UserGroup() { Name = "HR", isActive = false },
            new UserGroup() { Name = "Dev", isActive = true },
            new UserGroup() { Name = "Sales", isActive = false },
        };

        public List<string> ActiveRoles { get; set; } = new List<string>() { "Admin", "Accounts" };



    }
    public class UserGroup
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }

}
