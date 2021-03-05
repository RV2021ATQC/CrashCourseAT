using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.OpenCart
{
    class ApiClass
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
            IOpencartAPI Build();
        }
        public interface IOpencartAPI
        {
            string GetFirstname();
            string GetLastname();
            string GetEmail();
            string GetPhone();
            string GetPassword();
        }
        class Users : ISetFirstname, ISetLastname, ISetEmail,
            ISetPhone, ISetPassword, ISetSubscribe, IOpencartAPI
        {
            private Method method;
            private IRestClient client;
            private string email;
            private string phone;
            private string password;
            private bool subscribe;

            public IOpencartAPI Build()
            {
                return this;
            }
            public static ISetFirstname Get()
            {
                return new Users();
            }

            public ISetPhone SetEmail(string email)
            {
                this.email = email;
                return this;
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

            public ISetSubscribe SetPassword(string password)
            {
                this.password = password;
                return this;
            }

            public ISetPassword SetPhone(string phone)
            {
                this.phone = phone;
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
        }
    }
}
