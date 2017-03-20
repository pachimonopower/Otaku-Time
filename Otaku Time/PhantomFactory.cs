using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;

namespace Otaku_Time
{
    public static class PhantomFactory
    {
        private static PhantomJSDriver MyPhantomObject;

        public static PhantomJSDriver ReturnDriver()
        {
            if(MyPhantomObject == null)
            {
                string UA = "Mozilla/5.0 (iPhone; CPU iPhone OS 10_0_1 like Mac OS X) AppleWebKit/601.1 (KHTML, like Gecko) CriOS/53.0.2785.109 Mobile/14A403 Safari/601.1.46";
                var driverService = PhantomJSDriverService.CreateDefaultService();
                var options = new PhantomJSOptions();
                options.AddAdditionalCapability("phantomjs.page.settings.userAgent", UA);
                driverService.HideCommandPromptWindow = true;
                
                MyPhantomObject = new PhantomJSDriver(driverService,options);
            }
            return MyPhantomObject;
        }


    }
}
