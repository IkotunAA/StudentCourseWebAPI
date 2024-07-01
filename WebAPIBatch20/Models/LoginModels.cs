namespace WebAPIBatch20.Models
{
    public class LoginModels
    {
        public class LoginRequest
        {
            public string Email { get; set;}
            public string Password { get; set;}
        }

        public class LoginResponseModel : BaseResponse
        {
            public string LastName {  get; set;}     
            public string FirstName {  get; set;}     
            public string Email {  get; set;}     
            public string Token { get; set;}
            public List<string> Roles { get; set;}
        }
    }
}
