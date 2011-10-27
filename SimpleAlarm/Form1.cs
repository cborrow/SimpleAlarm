#region License
/*
* Copyright (c) 2011 Cory Borrow
*
* Permission is hereby granted, free of charge, to any person obtaining 
* a copy of this software and associated documentation files (the "Software"), 
* to deal in the Software without restriction, including without limitation 
* the rights to use, copy, modify, merge, publish, distribute, sublicense, 
* and/or sell copies of the Software, and to permit persons to whom the 
* Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included 
* in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS 
* OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
* THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
* THE SOFTWARE.
*/
#endregion

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
