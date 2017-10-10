using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Otaku_Time;

namespace OtakuTimeTests
{
    [TestClass]
    public class OtakuTimeMainTests
    {
        [TestMethod]
        public void GetPhantomObjectTest()
        {
            var phantomObject = WebDriverClass.PhantomJSInstance;
            Assert.AreNotEqual(null, phantomObject);
        }

        [TestMethod]
        public void ConnectToMasterTest()
        {
            var phantomObject = WebDriverClass.PhantomJSInstance;
            phantomObject.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/M");
            Thread.Sleep(6000); //bypass cloudflare
            Assert.IsTrue(phantomObject.Url.Contains(VariablesClass.MasterURL)); // test to make sure it goes through. AppVeyor is banned apparently.
            phantomObject.Quit();
        }

        [TestMethod]
        public async void GetRapidVideoLink()
        {
            string rapidvideourl = await WebDriverClass.GetRapidVideoLink("https://www.rapidvideo.com/e/FF97ATLLGB");
            Assert.AreNotEqual("no", rapidvideourl);
        }

    }
}
