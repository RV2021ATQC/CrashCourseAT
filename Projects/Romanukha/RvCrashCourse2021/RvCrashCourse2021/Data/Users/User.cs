using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crashCourse2021.Tools;

namespace crashCourse2021.Data.Users
{
    public interface ISetLogin
    {
        ISetFirstname SetLogin(string login);
    }

    public interface ISetFirstname
    {
        ISetLastname SetFirstname(string firstname);
    }

    public interface ISetLastname
    {
        ISetEmail SetLastname(string lastname);
    }

    public interface ISetEmail
    {
        ISetPhone SetEmail(string email);
    }

    public interface ISetPhone
    {
        ISetAddressMain SetPhone(string phone);
    }

    public interface ISetAddressMain
    {
        ISetCity SetAddressMain(string addressMain);
    }

    public interface ISetCity
    {
        ISetPostcode SetCity(string city);
    }
    public interface ISetPostcode
    {
        ISetCoutry SetPostcode(string postcode);
    }

    public interface ISetCoutry
    {
        ISetRegionState SetCoutry(string coutry);
    }

    public interface ISetRegionState
    {
        ISetPassword SetRegionState(string regionState);
    }

    public interface ISetPassword
    {
        ISetSubscribe SetPassword(string password);
    }

    public interface ISetSubscribe
    {
        IUserBuild SetSubscribe(bool subscribe);
    }

    public interface IUserBuild
    {
        IUserBuild SetFax(string fax);
        IUserBuild SetCompany(string company);
        IUserBuild SetAddressAdd(string addressAdd);
        // 6. Builder
        //User build();
        // 7. Dependency Inversion
        IUser Build();
    }

    public interface IUser
    {
        string GetLogin();
        string GetFirstname();
        string GetLastname();
        string GetEmail();
        string GetPhone();
        string GetAddressMain();
        string GetCity();
        string GetPostcode();
        string GetCoutry();
        string GetRegionState();
        string GetPassword();
        bool GetSubscribe();
        string GetFax();
        string GetCompany();
        string GetAddressAdd();
    }

    public class User : ISetLogin, ISetFirstname, ISetLastname, ISetEmail,
        ISetPhone, ISetAddressMain, ISetCity, ISetPostcode,
        ISetCoutry, ISetRegionState, ISetPassword, ISetSubscribe, IUserBuild, IUser
    {
        // Required
        // 1. public string Firstname { get; private set; }
        // 2. Default public Constructor
        //public string Firstname { get; set; }
        //public string Lastname { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public string AddressMain { get; set; }
        //public string City { get; set; }
        //public string Postcode { get; set; }
        //public string Coutry { get; set; }
        //public string RegionState { get; set; }
        //public string Password { get; set; }
        //public bool Subscribe { get; set; }
        // Advanced
        //public string Fax { get; set; }
        //public string Company { get; set; }
        //public string AddressAdd { get; set; }

        // Required
        private string login;
        private string firstname;
        private string lastname;
        private string email;
        private string phone;
        private string addressMain;
        private string city;
        private string postcode;
        private string coutry;
        private string regionState;
        private string password;
        private bool subscribe;
        // Advanced
        private string fax;
        private string company;
        private string addressAdd;

        //// 1. Classic Constructor
        //public User(string firstname, string lastname, string email,
        //    string phone, string addressMain, string city,
        //    string postcode, string coutry, string regionState,
        //    string password, bool subscribe)
        //{
        //    // Required
        //    this.Firstname = firstname;
        //    this.Lastname = lastname;
        //    this.Email = email;
        //    this.Phone = phone;
        //    this.AddressMain = addressMain;
        //    this.City = city;
        //    this.Postcode = postcode;
        //    this.Coutry = coutry;
        //    this.RegionState = regionState;
        //    this.Password = password;
        //    this.Subscribe = subscribe;
        //    // Advanced
        //    this.Fax = string.Empty;
        //    this.Company = string.Empty;
        //    this.AddressAdd = string.Empty;
        //}

        //// 1. Classic Constructor
        //public User(string firstname, string lastname, string email,
        //    string phone, string addressMain, string city,
        //    string postcode, string coutry, string regionState,
        //    string password, bool subscribe,
        //    string fax, string company, string addressAdd)
        //{
        //    // Required
        //    this.Firstname = firstname;
        //    this.Lastname = lastname;
        //    this.Email = email;
        //    this.Phone = phone;
        //    this.AddressMain = addressMain;
        //    this.City = city;
        //    this.Postcode = postcode;
        //    this.Coutry = coutry;
        //    this.RegionState = regionState;
        //    this.Password = password;
        //    this.Subscribe = subscribe;
        //    // Advanced
        //    this.Fax = fax;
        //    this.Company = company;
        //    this.AddressAdd = addressAdd;
        //}

        // 2. Default public Constructor
        //public User() { }
        
        // 5. Static Factory
        private User() { }

        //public static User Get()
        //{
        //    return new User();
        //}

        // 6. Builder
        //public static ISetFirstname Get()
        public static ISetLogin Get()
        {
            return new User();
        }

        // 3. Add Setters, Getters
        // Setters

        public ISetFirstname SetLogin(string login)
        {
            this.login = login;
            return this;
        }

        //public void SetFirstname(string firstname)

        // 4. Fluent Interface
        //public User SetFirstname(string firstname)

        // 6. Builder
        public ISetLastname SetFirstname(string firstname)
        {
            this.firstname = firstname;
            return this;
        }

        public ISetEmail SetLastname(string lastname)
        {
            this.lastname = lastname;
            return this;
        }

        public ISetPhone SetEmail(string email)
        {
            this.email = email;
            return this;
        }

        public ISetAddressMain SetPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public ISetCity SetAddressMain(string addressMain)
        {
            this.addressMain = addressMain;
            return this;
        }

        public ISetPostcode SetCity(string city)
        {
            this.city = city;
            return this;
        }

        public ISetCoutry SetPostcode(string postcode)
        {
            this.postcode = postcode;
            return this;
        }

        public ISetRegionState SetCoutry(string coutry)
        {
            this.coutry = coutry;
            return this;
        }

        public ISetPassword SetRegionState(string regionState)
        {
            this.regionState = regionState;
            return this;
        }

        public ISetSubscribe SetPassword(string password)
        {
            this.password = password;
            return this;
        }

        public IUserBuild SetSubscribe(bool subscribe)
        {
            this.subscribe = subscribe;
            return this;
        }

        public IUserBuild SetFax(string fax)
        {
            this.fax = fax;
            return this;
        }

        public IUserBuild SetCompany(string company)
        {
            this.company = company;
            return this;
        }

        public IUserBuild SetAddressAdd(string addressAdd)
        {
            this.addressAdd = addressAdd;
            return this;
        }

        // 6. Builder
        //public User build()
        // 7. Dependency Inversion
        public IUser Build()
        {
            return this;
        }

        // Getters

        public string GetLogin()
        {
            return login;
        }

        public string GetFirstname()
        {
            return firstname;
        }

        public string GetLastname()
        {
            return lastname;
        }
        public string GetEmail()
        {
            return email;
        }

        public string GetPhone()
        {
            return phone;
        }

        public string GetAddressMain()
        {
            return addressMain;
        }

        public string GetCity()
        {
            return city;
        }

        public string GetPostcode()
        {
            return postcode;
        }

        public string GetCoutry()
        {
            return coutry;
        }

        public string GetRegionState()
        {
            return regionState;
        }

        public string GetPassword()
        {
            return password;
        }

        public bool GetSubscribe()
        {
            return subscribe;
        }

        public string GetFax()
        {
            return fax;
        }

        public string GetCompany()
        {
            return company;
        }

        public string GetAddressAdd()
        {
            return addressAdd;
        }

        // Static Factory

        public static List<IUser> GetAllUsers(AExternalReader externalData)
        {
            //logger.Debug("Start GetAllUsers, path = " + path);
            List<IUser> users = new List<IUser>();
            foreach (IList<string> row in externalData.GetAllCells())
            {
                if (row[3].ToLower().Equals("email")
                        && row[10].ToLower().Equals("password"))
                {
                    continue;
                }
                users.Add(Get()
                        .SetLogin(row[0])
                        .SetFirstname(row[1])
                        .SetLastname(row[2])
                        .SetEmail(row[3])
                        .SetPhone(row[4])
                        .SetAddressMain(row[5])
                        .SetCity(row[6])
                        .SetPostcode(row[7])
                        .SetCoutry(row[8])
                        .SetRegionState(row[9])
                        .SetPassword(row[10])
                        .SetSubscribe(row[11].ToLower().Equals("true"))
                        .Build());
                //logger.Debug("Add User Firstname= " + row[1] + " Lastname = " + row[2] + " Email = " + row[3]);
            }
            //logger.Debug("Done GetAllUsers, path = " + externalData.GetConnection());
            return users;
        }

    }
}
