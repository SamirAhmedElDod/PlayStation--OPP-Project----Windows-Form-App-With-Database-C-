using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Playstation
{
    public partial class Form1 : Form
    {

        public class Device
        {
            public int RecievedHours { get; set; }
            public int RecievedMinutes { get; set; }
            public int RecievedSeconds { get; set; }
            public TimeSpan AllTimes { get; set; }
            public bool IsTimeStart { get; set; } = false;
            public Label DisplayLabel { get; set; }
            public Guna2Button ControlButton { get; set; }
            public Timer DeviceTimer { get; set; }
        }


        public List<Device> Devices = new List<Device>();

        public Form1()
        {
            InitializeComponent();

            Devices.Add(new Device { DisplayLabel = Device1Label, ControlButton = Device1btn, DeviceTimer = new Timer() });
            Devices.Add(new Device { DisplayLabel = Device2Label, ControlButton = Device2btn, DeviceTimer = new Timer() });
            Devices.Add(new Device { DisplayLabel = Device3Label, ControlButton = Device3btn, DeviceTimer = new Timer() });
            Devices.Add(new Device { DisplayLabel = Device4Label, ControlButton = Device4btn, DeviceTimer = new Timer() });
            Devices.Add(new Device { DisplayLabel = Device5Label, ControlButton = Device5btn, DeviceTimer = new Timer() });
            Devices.Add(new Device { DisplayLabel = Device6Label, ControlButton = Device6btn, DeviceTimer = new Timer() });


            foreach (var device in Devices)
            {
                device.DeviceTimer.Interval = 1000;
                device.DeviceTimer.Tick += (s, e) => Timer_Tick(device);
            }
        }

        private void DeviceButton_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            Device device = Devices.Find(d => d.ControlButton == clickedButton);

            if (device.IsTimeStart == false)
            {
                device.DeviceTimer.Start();
                device.IsTimeStart = true;
                clickedButton.Text = "Stop Play";
            }
            else
            {
                device.DeviceTimer.Stop();
                device.IsTimeStart = false;
                clickedButton.Text = "Start Play";
            }
        }

        private void Timer_Tick(Device device)
        {
            if (device.IsTimeStart)
            {
                device.AllTimes = device.AllTimes.Subtract(TimeSpan.FromSeconds(1));
                device.DisplayLabel.Text = device.AllTimes.ToString(@"hh\:mm\:ss");

                if (device.AllTimes.TotalSeconds <= 0)
                {
                    device.DeviceTimer.Stop();
                    device.DisplayLabel.Text = "Time's up!";
                    device.IsTimeStart = false;
                }
            }
        }

        private void OpenAddTimeForm(int deviceIndex)
        {
            AddTimeForm addTimeForm = new AddTimeForm(this, deviceIndex);
            addTimeForm.Show();
            addTimeForm.FormClosed += (s, args) => RefreshDeviceTime(deviceIndex);
        }

        private void RefreshDeviceTime(int deviceIndex)
        {
            Device device = Devices[deviceIndex];
            device.AllTimes = new TimeSpan(device.RecievedHours, device.RecievedMinutes, device.RecievedSeconds);
            device.DisplayLabel.Text = device.AllTimes.ToString(@"hh\:mm\:ss");
        }

        // Device 1 Button
        private void Device1btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);
        }

        // Plus Button To Add Time for Device 1
        private void Plus1_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(0);
        }

        // Device 2 Button
        private void Device2btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);
        }

        // Plus Button To Add Time for Device 2
        private void Plus2_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(1);
        }

        // Device 3 Button
        private void Device3btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);

        }

        // Plus Button To Add Time for Device 3
        private void Plus3_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(2);

        }

        // Plus Button To Add Time for Device 4
        private void Plus4_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(3);
        }

        // Device 4 Button
        private void Device4btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);
        }

        // Plus Button To Add Time for Device 5
        private void Plus5_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(4);
        }

        // Device 5 Button
        private void Device5btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);
        }

        // Plus Button To Add Time for Device 6
        private void Plus6_Click(object sender, EventArgs e)
        {
            OpenAddTimeForm(5);
        }

        // Device 6 Button
        private void Device6btn_Click(object sender, EventArgs e)
        {
            DeviceButton_Click(sender, e);
        }


        // Games Form Open Button
        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            GamesForm gamesForm = new GamesForm();
            gamesForm.ShowDialog();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            ContactMe contactMe = new ContactMe();
            contactMe.Show();
        }
    }
}
