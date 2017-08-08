using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otaku_Time
{
    public class WebDriverClass
    {
        private static PhantomJSDriver MyPhantomObject;

        public static PhantomJSDriver GetPhantomJSInstance()
        {
            if (MyPhantomObject == null)
            {
                string path = @".\Resources"; // used to make the designer work. If you can't access MainFrm designer change this to your phantomjs location.
                var driverService = PhantomJSDriverService.CreateDefaultService(path);
                var options = new PhantomJSOptions();
                options.AddAdditionalCapability("phantomjs.page.settings.userAgent", VariablesClass.UserAgentString);
                driverService.HideCommandPromptWindow = true;

                MyPhantomObject = new PhantomJSDriver(driverService, options);
            }
            return MyPhantomObject;
        }
    }
}
