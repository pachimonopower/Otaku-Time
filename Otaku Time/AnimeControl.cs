using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Xml;
using System.Security.Policy;

namespace Otaku_Time
{
    public partial class AnimeControl : UserControl
    {
        private MainFrm MainForm;
        public string AnimeSynposis = "";
        public string AnimeURL = "";

        public AnimeControl()
        {
            InitializeComponent();
        }

        private void AnimeControl_Load(object sender, EventArgs e)
        {
            AnimeName.Location = new Point(this.Width / 2, 0);
            MainForm = (MainFrm)Parent.Parent;
            AnimeImage.LoadCompleted += AnimeImage_LoadCompleted;
        }

        private async void AnimeImage_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                await Task.Run(() =>
                {
                    string newimage = GetNewImageUrl(AnimeName.Text);
                    if (newimage != "")
                    {
                        AnimeImage.ImageLocation = GetNewImageUrl(AnimeName.Text); // new image
                    }
                    else
                    {
                        AnimeImage.Image = Properties.Resources._404;
                    }
                });
            }
        }

        private string GetNewImageUrl(string animename)
        {
            using (CustomWebClient WC = new CustomWebClient())
            {
                string searchqry = animename.ToLower().Replace("(sub)", "").Replace("(dub)", "").Trim().Replace(" ", "+");
                string endpoint = "https://myanimelist.net/api/anime/search.xml?q=" + searchqry;
                WC.Headers["Authorization"] = "Basic " + Statics.AuthToken;
                string res = WC.DownloadString(endpoint);
                if (res.Trim() != "")
                {
                    XmlDocument XMLDoc = new XmlDocument();
                    XMLDoc.LoadXml(res);
                    string retval = XMLDoc.GetElementsByTagName("image")[0].InnerText;
                    XMLDoc = null;
                    return retval;
                }
                else
                {
                    return "";
                }
            }
        }

        private void SendSelfToGrandParent(object sender, EventArgs e)
        {
            MainForm.startLoadingAnimeInformation(this);
        }
    }
    class CustomWebClient : WebClient
    {
        /// <summary>
        /// Returns a <see cref="T:System.Net.WebRequest" /> object for the specified resource.
        /// </summary>
        /// <param name="address">A <see cref="T:System.Uri" /> that identifies the resource to request.</param>
        /// <returns>
        /// A new <see cref="T:System.Net.WebRequest" /> object for the specified resource.
        /// </returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).KeepAlive = false;
            }
            return request;
        }
    }
}
