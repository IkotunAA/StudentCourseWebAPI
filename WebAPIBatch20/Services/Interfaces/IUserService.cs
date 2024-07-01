using WebAPIBatch20.Models;
using static WebAPIBatch20.Models.LoginModels;
using static WebAPIBatch20.Models.UserModels;

namespace WebAPIBatch20.Services.Interfaces
{
    public interface IUserService
    {
        UserResponse Register(CreateUserRequest request);

        LoginResponseModel Login(LoginRequest request);
    }
}
