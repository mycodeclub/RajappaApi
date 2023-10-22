namespace MyHSE_Backend.Data.ViewModels.User
{
    public class LoginResponse
    { 
        public bool IsLoginSuccess { get; set; }
        public string Token { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<string>? ErrorMessages { get; set; }
    }
}
