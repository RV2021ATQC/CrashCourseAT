namespace NUnitTestLogin
{
    public class UserData
    {
        public UserData(string _userName, string _userPassword)
        {
            this.userName = _userName;
            this.userPassword = _userPassword;
        }
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}
