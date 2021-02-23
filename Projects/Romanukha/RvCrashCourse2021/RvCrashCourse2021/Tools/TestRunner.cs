﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using crashCourse2021.Pages;
using crashCourse2021.Data.Users;
using crashCourse2021.Tools;
using crashCourse2021.Data.Application;
using NUnit.Framework.Interfaces;
using NLog;

namespace crashCourse2021.Tools
{
    [TestFixture]
    public abstract class TestRunner
    {
        public Logger log = LogManager.GetCurrentClassLogger(); // for NLog
        //
        protected readonly double DOUBLE_PRECISE = 0.01;
        //
        //protected bool isTestSuccess = false;

        [OneTimeSetUp]
        public void BeforeAllMethods()
        {
            //Application.Get(ApplicationSourceRepository.ChromeTemporaryHeroku());
            Application.Get(); // Default
        }

        [OneTimeTearDown]
        public void AfterAllMethods()
        {
            Application.Remove();
        }

        [SetUp]
        public void SetUp()
        {
            //Application.Get().LoadLoginPage();
            //isTestSuccess = false;
        }

        [TearDown]
        public void TearDown()
        {
            //if (!isTestSuccess)
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                Application.Get().SaveCurrentState();
                log.Error("Test Failed");
            }
            // Logout
            Application.Get().LogoutAction();
        }

        protected LoginPage StartApplication()
        {
            return Application.Get().LoadLoginPage();
        }
    }
}
