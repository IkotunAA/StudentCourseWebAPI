

using WebAPIBatch20.Entities;
using WebAPIBatch20.Models;
using WebAPIBatch20.Repositories.Interfaces;
using WebAPIBatch20.Services.Interfaces;
using static WebAPIBatch20.Models.LoginModels;
using static WebAPIBatch20.Models.UserModels;

namespace WebAPIBatch20.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public UserService(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }
        public LoginResponseModel Login(LoginRequest request)
        {
            var user = _userRepository.GetByEmail(request.Email);
            if(user == null)
            {
                return new LoginResponseModel
                {
                    Message = "Invalid email or password"
                };
            }

            if(user.Password != request.Password)
            {
                return new LoginResponseModel
                {
                    Message = "Invalid email or password"
                };
            }

            var token = _authService.GenerateToken(user);

            return new LoginResponseModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.UserRoles.Select(x => x.Role.Name).ToList(),
                Message = "Login successful",
                Token = token
            };
        }

        public UserResponse Register(CreateUserRequest request)
        {
            var userExist = _userRepository.GetByEmail(request.Email);
            if(userExist != null)
            {
                return new UserResponse
                {
                    Message = $"User with email {request.Email} already exist"
                };
            }

            var role = _userRepository.GetRoleByName("user");
            if (role == null)
            {
                return new UserResponse
                {
                    Message = $"Role Not found"
                };
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            user.UserRoles = new List<UserRole> { new UserRole { RoleId = role.Id, UserId = user.Id } };

            _userRepository.Create(user);
            return new UserResponse
            {
                Data = new UserModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email
                }

            };

            
        }
    }
}
