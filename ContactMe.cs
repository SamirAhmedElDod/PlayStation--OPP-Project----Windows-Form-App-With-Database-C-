using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Playstation
{
    public partial class ContactMe : Form
    {
        public ContactMe()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }
        private void GoToLink(string Url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = Url,
                UseShellExecute = true
            });
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            string url = "https://api.whatsapp.com/send?phone=201277040276&text=Hello%20Samir%20%2C%20I%27m%20From%20Your%20Desktop%20Application%20..%20%0A%F0%9F%A5%B0";
            GoToLink(url);
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            string url = "https://www.facebook.com/samir.elboss.33";
            GoToLink(url);
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/samir-ahmed-38943a325";
            GoToLink(url);
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            string url = "mailto:example@gmail.com";
            GoToLink(url);
        }
    }
}
