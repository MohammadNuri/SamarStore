namespace EndPoint.Site.Models.AuthenticationViewModel
{
    public class SignupViewModel
    {
        public string FullName { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string RePassword { get; set; } = string.Empty;
    }
}
