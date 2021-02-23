using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crashCourse2021.Data.Application
{
    public sealed class ApplicationSourceRepository
    {
        public const string FIREFOX_TEMPORARY_WHITH_UI = "FirefoxTemporaryWhithUI";
        public const string CHROME_TEMPORARY_WHITH_UI = "ChromeTemporaryWhithUI";
        public const string CHROME_TEMPORARY_MAXIMIZED_WHITH_UI = "ChromeTemporaryMaximizedWhithUI";
        public const string CHROME_TEMPORARY_WITHOUT_UI = "ChromeTemporaryWithoutUI";


        private ApplicationSourceRepository() { }

        public static ApplicationSource Default()
        {
            return ChromeTemporaryHeroku();
        }

        public static ApplicationSource FirefoxTemporaryHeroku()
        {
            return new ApplicationSource(FIREFOX_TEMPORARY_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeTemporaryHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeMaximizedHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_MAXIMIZED_WHITH_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

        public static ApplicationSource ChromeWithoutUIHeroku()
        {
            return new ApplicationSource(CHROME_TEMPORARY_WITHOUT_UI, 10L, 10L,
                "http://regres.herokuapp.com/login",
                "http://regres.herokuapp.com/logout");
        }

    }

}
