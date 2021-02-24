using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;


namespace crashCourse2021.Pages
{

    public partial class LoginPage : ATopComponent
    {
        public const string IMAGE_NAME = "ukraine_logo2.gif";

        public IWebElement LoginLabel => Search.XPath("//label[contains(@for,'inputEmail')]");
        public IWebElement LoginInput => Search.Id("login");
        public IWebElement PasswordLabel => Search.XPath("//label[contains(@for,'inputPassword')]");
        public IWebElement PasswordInput => Search.Id("password");
        public IWebElement SigninButton => Search.CssSelector("button.btn.btn-primary");
        public IWebElement LogoPicture => Search.CssSelector("img.login_logo.col-md-8.col-xs-12");

    }
}
