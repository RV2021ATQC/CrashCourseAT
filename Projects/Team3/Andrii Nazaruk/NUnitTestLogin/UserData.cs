namespace NUnitTestLogin
{
    public class UserData
    {
        public UserData(string _userEmail, string _userPassword)
        {
            this.userEmail = _userEmail;
            this.userPassword = _userPassword;
        }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
    }
}
