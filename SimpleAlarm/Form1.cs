using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace SimpleAlarm
{
    public partial class Form1 : Form
    {
        SoundPlayer soundPlayer;
        DateTime alarmTime;
        Timer timer;

        bool playingAlarm = false;

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            soundPlayer = new SoundPlayer("Sounds\\alarm.wav");

            timeUpDownControl1.TimeChanged += new EventHandler(timeUpDownControl1_TimeChanged);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (playingAlarm)
            {
                soundPlayer.Stop();
            }

            base.OnClosing(e);
        }

        void timeUpDownControl1_TimeChanged(object sender, EventArgs e)
        {
            alarmTime = timeUpDownControl1.Time;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (playingAlarm)
                return;

            DateTime now = DateTime.Now;
            TimeSpan timeLeft = alarmTime.Subtract(now);

            if (timeLeft.Hours == 0)
            {
                if (timeLeft.Minutes == 0 && timeLeft.Seconds <= 10)
                {
                    playingAlarm = true;
                    button1.Enabled = true;
                    soundPlayer.PlayLooping();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timeUpDownControl1.Minutes += 5;
            soundPlayer.Stop();
            playingAlarm = false;
            button1.Enabled = false;
        }
    }
}
