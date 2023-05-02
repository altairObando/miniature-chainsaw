namespace ApiCore.Dto
{
    /// <summary>
    ///     Dto for loggin request
    /// </summary>
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class PasswordChangeRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
