using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.OpenCart
{
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
        ISetPassword SetPhone(string phone);
    }

    public interface ISetPassword
    {
        ISetSubscribe SetPassword(string password);
    }

    public interface ISetSubscribe
    {
        ISetSubscribe SetSubscribe(bool subscribe);
        IUser Build();
    }
    public interface IUser
    {
        string GetFirstname();
        string GetLastname();
        string GetEmail();
        string GetPhone();
        string GetPassword();
    }
    class Users : ISetFirstname, ISetLastname, ISetEmail,
        ISetPhone, ISetPassword, ISetSubscribe, IUser
    {
        private string firstname;
        private string lastname;
        private string email;
        private string phone;
        private string password;
        private bool subscribe;
        private string FULL_PATH_TO_FILE = "C:\\Users\\Den25\\Documents\\GitHub\\CrashCourseAT\\Projects\\Team1\\TestFrameworkForOpenCart\\TestFramework.OpenCart\\Data\\Users.csv";

        public IUser Build()
        {
            return this;
        }
        public static ISetFirstname Get()
        {
            return new Users();
        }

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
        public ISetPassword SetPhone(string phone)
        {
            this.phone = phone;
            return this;
        }

        public ISetSubscribe SetPassword(string password)
        {
            this.password = password;
            return this;
        }
        
        public ISetSubscribe SetSubscribe(bool subscribe)
        {
            this.subscribe = subscribe;
            return this;
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
        public string GetPassword()
        {
            return password;
        }

        public bool GetSubscribe()
        {
            return subscribe;
        }

        public IUser Invalid()
        {
            return Users.Get()
                .SetFirstname("Firstname")
                .SetLastname("Lastname")
                .SetEmail("Email")
                .SetPhone("123456789")
                .SetPassword("qwerty")
                .SetSubscribe(false)
                .Build();
        }
        public IUser Valid()
        {
            var userCollection = new Reader(FULL_PATH_TO_FILE).ReadUsers();
            return Users.Get()
                .SetFirstname(userCollection[0].FName)
                .SetLastname(userCollection[0].SName)
                .SetEmail(userCollection[0].Email)
                .SetPhone(userCollection[0].Phone)
                .SetPassword(userCollection[0].Password)
                .SetSubscribe(false)
                .Build();
        }
        public IUser ValidForLoginV1()
        {
            var userCollection = new Reader(FULL_PATH_TO_FILE).ReadUsers();
            return Users.Get()
                .SetFirstname(userCollection[1].FName)
                .SetLastname(userCollection[1].SName)
                .SetEmail(userCollection[1].Email)
                .SetPhone(userCollection[1].Phone)
                .SetPassword(userCollection[1].Password)
                .SetSubscribe(false)
                .Build();
        }
    }
}
