using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyHSE_Backend.Data.DbModels.User;
using MyHSE_Backend.Data.EF_Core;
using MyHSE_Backend.Data.ViewModels.User;
using MyHSE_Backend.DataRepository.Interfaces;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyHSE_Backend.DataRepository.Implementation
{
    public class UserAccountDR : IUserAccountDR
    {
        private AppDbContext _context;
        private IConfiguration _config;


        public UserAccountDR(AppDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;

        } 
        public async Task<LoginResponse> Login(string LoginName, string Password)
        {
            var response = new LoginResponse() { };
            if (await ValidateCredentials(LoginName, Password))
            {
                response.Token = await CreateJwtToken(LoginName);
                response.IsLoginSuccess = true;
            }
            else response.ErrorMessages = new List<string>() { "Invalid Credentials " };
            return response;
        }
        public async Task<IEnumerable<Data.DbModels.User.Users>> GetAllUsers()
        {
            IEnumerable<Users> users;
            users = await _context.AppUsers.ToListAsync();
            return users;
        }



        public async Task<bool> IfUserExists(string email)
        {
            return await _context.AppUsers.AnyAsync(u => u.EMAILID.Equals(email));
        }
        private async Task<bool> ValidateCredentials(string email, string password)
        {
            var _appUser = await GetUserByEmail(email);
            return _appUser == null ? false
                : BCrypt.Net.BCrypt.Verify(password, _appUser.PasswordHash);
        }
        private async Task<Users> GetUserByEmail(string email)
        {
            Users appUser = null;
            try
            {
                var result = await _context.AppUsers.Where(u => u.EMAILID.Equals(email)).FirstOrDefaultAsync();
                appUser = result;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;

            }
            return appUser;
        }
        private async Task<string> CreateJwtToken(string email)
        {

            var secretKey = _config["JwtSettings:Key"];
            var validIssuer = _config["JwtSettings:Issuer"];
            var validAudience = _config["JwtSettings:Audience"];

            var _appUser = await GetUserByEmail(email);
            var userClaims = _appUser.Roles.Split(",").Select(r => new Claim(ClaimTypes.Role, r)).ToList();
            userClaims.Add(new Claim(ClaimTypes.Name, _appUser.EMAILID));
            userClaims.Add(new Claim(ClaimTypes.Email, _appUser.EMAILID));
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, _appUser.Id.ToString()));
            userClaims.Add(new Claim(ClaimTypes.Sid, _appUser.Login));

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: userClaims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred,
                issuer: validIssuer,
                audience: validAudience
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public async Task<UserRegistrationResponse> RegisterNewUser(UserRegistrationVM user)
        {
            var response = new UserRegistrationResponse();

            if (await IfUserExists(user.Email))
            {
                response.ErrorMessages = new List<string>() { "User already exist with given Id, please try with different email" };
                return response;
            }
            else
            {
                var appUser = new Users()
                {
                    CREATEDON = DateTime.Now,
                    Login = user.Email,
                    EMAILID = user.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password),
                };
                _context.AppUsers.Add(appUser);
                try { await _context.SaveChangesAsync(); }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    if (response.ErrorMessages == null)
                        response.ErrorMessages = new List<string>();
                    response.ErrorMessages.Add(ex.Message);
                    response.ErrorMessages.Add(ex.InnerException.Message);
                    response.ErrorMessages.Add(ex.StackTrace);
                    return response;
                }
                response.UniqueId = appUser.Id;
                response.IsCreated = true;
                return response;
            }
        }

        public async Task<UserRegistrationResponse> UserRegistrationWithFullDetail(Users user)
        {
            var response = new UserRegistrationResponse();

            if (await IfUserExists(user.EMAILID))
            {
                response.ErrorMessages = new List<string>() { "User already exist with given Id, please try with different email" };
                return response;
            }
            else
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PASSWORD);
                _context.AppUsers.Add(user);
                try { await _context.SaveChangesAsync(); }
                catch (Exception ex) { var msg = ex.Message; }
                response.UniqueId = user.Id;
                response.IsCreated = true;
                return response;


            }
        }
    }
}
