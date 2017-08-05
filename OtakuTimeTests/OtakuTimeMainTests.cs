using System;
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
            var PhantomObject = Statics.PhantomObject();
            Assert.AreNotEqual(null, PhantomObject);
        }

        [TestMethod]
        public void ConnectToMasterTest()
        {
            var PhantomObject = Statics.PhantomObject();
            PhantomObject.Navigate().GoToUrl($"http://{Statics.MasterURL}/M");
            System.Threading.Thread.Sleep(6000); //bypass cloudflare
            Assert.IsTrue(PhantomObject.Url.Contains(Statics.MasterURL)); // test to make sure it goes through. AppVeyor is banned apparently.
            PhantomObject.Close();
        }
    }
}
