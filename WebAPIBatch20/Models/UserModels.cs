using WebAPIBatch20.Entities;

namespace WebAPIBatch20.Models
{
    public class UserModels
    {
        public class CreateUserRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class UserModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public ICollection<string> Roles { get; set; }
        }

        public class UserResponse : BaseResponse
        {
            public UserModel Data { get; set; }
        }
    }
}
