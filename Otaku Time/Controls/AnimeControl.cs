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
        public AnimeInfoClass AnimeInfo
        {
            get;
        }

        public delegate void LoadAnimeDelegate(AnimeControl AnimeControl);
        public event LoadAnimeDelegate LoadAnime;


        public AnimeControl()
        {
            InitializeComponent();
        }

        public AnimeControl(AnimeInfoClass AnimeInfo)
        {
            InitializeComponent();
            this.AnimeInfo = AnimeInfo;
            this.AnimeName.Text = AnimeInfo.AnimeName.Replace("&", "&&");
        }

        private void SendSelfToGrandParent(object sender, EventArgs e)
        {
            LoadAnime(this);
        }

        private void AnimeControl_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.White, ButtonBorderStyle.Dashed);
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
