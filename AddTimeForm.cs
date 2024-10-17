using System;
using System.Windows.Forms;

namespace Playstation
{
    public partial class AddTimeForm : Form
    {
        private Form1 RecievedForm;
        private int RecievedID;

        public AddTimeForm(Form1 Home_Form, int DeviceID)
        {
            InitializeComponent();
            RecievedForm = Home_Form;
            RecievedID = DeviceID;
            this.MaximizeBox = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(guna2TextBox1.Text, out int Hours) &&
                int.TryParse(guna2TextBox2.Text, out int Minutes) &&
                int.TryParse(guna2TextBox3.Text, out int Seconds))
            {
                if (Hours >= 0 && Minutes >= 0 && Minutes < 60 && Seconds >= 0 && Seconds < 60)
                {
                    var selectedDevice = RecievedForm.Devices[RecievedID];
                    selectedDevice.RecievedHours = Hours;
                    selectedDevice.RecievedMinutes = Minutes;
                    selectedDevice.RecievedSeconds = Seconds;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter valid time values (Minutes and Seconds should be between 0 and 59).");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numeric values.");
            }
        }
    }
}
