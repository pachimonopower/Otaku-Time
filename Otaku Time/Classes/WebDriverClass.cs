﻿using System;
using OpenQA.Selenium.PhantomJS;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using OpenQA.Selenium;
using System.Threading.Tasks;
using System.Net;

namespace Otaku_Time
{
    public class WebDriverClass
    {
        private static PhantomJSDriver _myPhantomObject;

        public static PhantomJSDriver PhantomJSInstance
        {
            get
            {
                if (_myPhantomObject == null)
                {
                    const string path = @".\Resources\"; // used to make the designer work. If you can't access MainFrm designer change this to your phantomjs location.
                    var driverService = PhantomJSDriverService.CreateDefaultService(path);
                    var options = new PhantomJSOptions();
                    options.AddAdditionalCapability("phantomjs.page.settings.userAgent", VariablesClass.UserAgentString);
                    driverService.HideCommandPromptWindow = true;

                    _myPhantomObject = new PhantomJSDriver(driverService, options);
                }
                return _myPhantomObject;
            }
        }

        public static byte[] GetImageBytes(string imageUrl)
        {
            using (var wc = new CustomWebClient())
            {
                wc.Headers.Add(System.Net.HttpRequestHeader.UserAgent, VariablesClass.UserAgentString);
                wc.Headers.Add(System.Net.HttpRequestHeader.Cookie, "cf_clearance=" + PhantomJSInstance.Manage().Cookies.GetCookieNamed("cf_clearance").Value);
                return wc.DownloadData(imageUrl);
            }
        }

        /// <summary>
        /// Scrapes the desktop site for web info. Currently only supports the lewd URL
        /// </summary>
        /// <param name="animeurlname"></param>
        /// <param name="name"></param>
        /// <param name="attributeName"></param>
        /// <returns></returns>
        public static string RunViaDesktop(string animeUrl, string animeurlname, string name, string attributeName)
        {
            var endpoint = $"http://{VariablesClass.MasterURL}{(VariablesClass.MasterURL == VariablesClass.KissLewdURL ? "/Hentai/" : "/Anime/")}{animeurlname}/{name.Replace(" ", "-")}?id={attributeName}&s=beta";
            var value = "";
            PhantomJSInstance.Navigate().GoToUrl(endpoint);
            if (PhantomJSInstance.Title == "Are You Human") // Robot can't do this, YET! :P
            {
                AreYouHumanHelpFrm HelpFrm = new AreYouHumanHelpFrm(PhantomJSInstance);
                HelpFrm.ShowDialog();
            }
            if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
            {
                PhantomJSInstance.ExecuteScript("$('#selectServer').val('openload').change();");
                //PhantomJSInstance.ExecuteScript("$(\"#selectServer\").find(\"option[text=\"Beta Server\"]\").attr(\"selected\", true);");
                Thread.Sleep(1000);
            }
            var xo = PhantomJSInstance.FindElementsByTagName("a").FirstOrDefault(x => x.Text.Contains("CLICK HERE"));
            if (xo != null)
            {
                if (VariablesClass.MasterURL == VariablesClass.KissLewdURL)
                    value = StaticsClass.GetOpenloadLink(xo.GetAttribute("href"));
                else
                    value = xo.GetAttribute("href");
            }
            PhantomJSInstance.Navigate().GoToUrl(animeUrl);
            return value;
        }
        public static async Task<string> GetRapidVideoLink(string rapidVideoUrl)
        {
            PhantomJSInstance.Navigate().GoToUrl(rapidVideoUrl);
            do
            {
                await Task.Delay(1000);
            }
            while (PhantomJSInstance.Title.Contains("Just a moment") || PhantomJSInstance.Title.Contains("www.rapidvideo.com"));
            string value;
            try
            {
                var matches = System.Text.RegularExpressions.Regex.Matches(PhantomJSInstance.PageSource, @"<source src\s*=\s*""(.+?)""");
                var jsonVals = matches[0].Groups[1].Value;  // first match, second group.
                value = jsonVals;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                value = "no";
            }
            return value;
        }

        public static IEnumerable<AnimeInfoClass> GetAnimeViaMobile(string searchQuery)
        {
            var encodedForUrlSearchQuery = HttpUtility.UrlEncode(searchQuery);
            PhantomJSInstance.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/M?key=" + encodedForUrlSearchQuery + "&sort=search");
            foreach (var x in PhantomJSInstance.FindElementsByTagName("article"))
            {
                yield return new AnimeInfoClass
                {
                    AnimeName = x.FindElement(By.ClassName("post-content"))
                        .FindElement(By.TagName("h2"))
                        .FindElement(By.TagName("a"))
                        .Text,
                    AnimeThumbnailURL = x.FindElement(By.TagName("img"))
                        .GetAttribute("src"),
                    AnimeSeriesURL = x.GetAttribute("alink")
                };
            }
        }

        public static IEnumerable<AnimeInfoClass> MainMobileUpdates()
        {
            if (PhantomJSInstance.Title.Contains("KissAnime Mobile") == false)
                PhantomJSInstance.Navigate().GoToUrl($"http://{VariablesClass.MasterURL}/m");

            foreach (var x in PhantomJSInstance.FindElementsByTagName("article"))
            {
                yield return new AnimeInfoClass
                {
                    AnimeName = x.FindElement(By.ClassName("post-content")).FindElement(By.TagName("h2")).FindElement(By.TagName("a")).Text,
                    AnimeThumbnailURL = x.FindElement(By.TagName("img")).GetAttribute("src"),
                    AnimeSeriesURL = x.GetAttribute("alink")
                };
            }
        }

        public static bool FileDoesNotExist(string redirectorLink)
        {
            if (redirectorLink == "") return true;
            try
            {
                HttpWebRequest request = WebRequest.Create(redirectorLink) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Dispose();
                return false;
            }
            catch (WebException exc)
            {
                return exc.Status != WebExceptionStatus.Timeout; //timeout usually means it might be active, untrusted test so return false
            }
        }
    }
}
