

using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.ViewModels.User;

namespace MyHSE_Backend.DataRepository.Interfaces
{
    public interface IUserAccountDR
    {
        public Task<LoginResponse> Login(string LoginName, string Password);
        public Task<bool> IfUserExists(string email);
        public Task<IEnumerable<Users>> GetAllUsers();
        public Task<UserRegistrationResponse> RegisterNewUser(UserRegistrationVM user);
        public Task<UserRegistrationResponse> UserRegistrationWithFullDetail(Users user);
    }
}
