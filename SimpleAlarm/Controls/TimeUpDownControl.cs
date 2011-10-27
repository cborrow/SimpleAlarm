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
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SimpleAlarm.Controls
{
    public class TimeUpDownControl : Control
    {
        TimeUpDownControlButton hourUpButton;
        TimeUpDownControlButton hourDownButton;
        TimeUpDownControlButton minuteUpButton;
        TimeUpDownControlButton minuteDownButton;

        Point hourTextLocation;
        Point minuteTextLocation;
        Point seperatorPosition;

        Timer mouseDownTimer;
        TimeToUpdate timeToUpdate;

        public event EventHandler TimeChanged;

        public DateTime Time
        {
            get
            {
                return DateTime.Parse(string.Format("{0}:{1}", this.Hours, this.Minutes));
            }
        }

        int hours = 0;
        public int Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                hours = Math.Min(23, hours);
                hours = Math.Max(0, hours);
                TimeChanged(this, EventArgs.Empty);
            }
        }

        int minutes = 0;
        public int Minutes
        {
            get { return minutes; }
            set
            {
                minutes = value;
                minutes = Math.Min(59, minutes);
                minutes = Math.Max(0, minutes);
                TimeChanged(this, EventArgs.Empty);
            }
        }

        public TimeUpDownControl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            TimeChanged += new EventHandler(OnTimeChanged);

            mouseDownTimer = new Timer();
            mouseDownTimer.Interval = 250;
            mouseDownTimer.Tick += new EventHandler(mouseDownTimer_Tick);

            hourUpButton = new TimeUpDownControlButton();
            hourUpButton.MouseDown += new MouseEventHandler(hourUpButton_MouseDown);
            hourUpButton.MouseUp += new MouseEventHandler(generic_MouseUp);
            hourUpButton.Location = new Point(5, 5);
            this.Controls.Add(hourUpButton);

            hourDownButton = new TimeUpDownControlButton();
            hourDownButton.MouseDown += new MouseEventHandler(hourDownButton_MouseDown);
            hourDownButton.MouseUp += new MouseEventHandler(generic_MouseUp);
            hourDownButton.Location = new Point(40, this.Height - 12);
            hourDownButton.FacingDown = true;
            this.Controls.Add(hourDownButton);

            minuteUpButton = new TimeUpDownControlButton();
            minuteUpButton.MouseDown += new MouseEventHandler(minuteUpButton_MouseDown);
            minuteUpButton.MouseUp +=new MouseEventHandler(generic_MouseUp);
            minuteUpButton.Location = new Point(this.Width - 40, 2);
            this.Controls.Add(minuteUpButton);

            minuteDownButton = new TimeUpDownControlButton();
            minuteDownButton.MouseDown += new MouseEventHandler(minuteDownButton_MouseDown);
            minuteDownButton.MouseUp += new MouseEventHandler(generic_MouseUp);
            minuteDownButton.Location = new Point(this.Width - 40, this.Height - 2);
            minuteDownButton.FacingDown = true;
            this.Controls.Add(minuteDownButton);
        }

        protected void OnTimeChanged(object sender, EventArgs e)
        {
            this.Refresh();
        }

        protected override void OnResize(EventArgs e)
        {
            float points = (this.Height - 10) * 72 / 96;
            this.Font = new Font(this.Font.FontFamily, points, this.Font.Style);

            Size hourSize = TextRenderer.MeasureText(string.Format("{0:00}", hours), this.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
            Size minSize = TextRenderer.MeasureText(string.Format("{0:00}", minutes), this.Font, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);

            int hourLeft = (hourSize.Height / 2) - 8;
            int minuteLeft = hourSize.Width + (minSize.Height / 2) - 10;

            hourTextLocation = new Point(2, 2);
            minuteTextLocation = new Point(hourSize.Width, 2);
            seperatorPosition = new Point(hourSize.Width - 20, 2);

            hourUpButton.Location = new Point(hourLeft, 5);
            hourDownButton.Location = new Point(hourLeft, this.Height - 12);
            minuteUpButton.Location = new Point(minuteLeft, 5);
            minuteDownButton.Location = new Point(minuteLeft, this.Height - 12);

            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            TextRenderer.DrawText(e.Graphics, string.Format("{0:00}", hours), this.Font, hourTextLocation, this.ForeColor, this.BackColor, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(e.Graphics, ":", this.Font, seperatorPosition, this.ForeColor, this.BackColor, TextFormatFlags.NoPadding);
            TextRenderer.DrawText(e.Graphics, string.Format("{0:00}", minutes), this.Font, minuteTextLocation, this.ForeColor, this.BackColor, TextFormatFlags.NoPadding);
            base.OnPaint(e);
        }

        void mouseDownTimer_Tick(object sender, EventArgs e)
        {
            if (timeToUpdate == TimeToUpdate.HourUp)
                this.Hours += 1;
            else if (timeToUpdate == TimeToUpdate.HourDown)
                this.Hours -= 1;
            else if (timeToUpdate == TimeToUpdate.MinuteUp)
                this.Minutes += 1;
            else if (timeToUpdate == TimeToUpdate.MinuteDown)
                this.Minutes -= 1;
        }

        void hourUpButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hours += 1;

            timeToUpdate = TimeToUpdate.HourUp;
            System.Threading.Thread.Sleep(500);
            mouseDownTimer.Start();
        }

        void minuteDownButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Minutes -= 1;

            timeToUpdate = TimeToUpdate.MinuteDown;
            System.Threading.Thread.Sleep(500);
            mouseDownTimer.Start();
        }

        void minuteUpButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Minutes += 1;

            timeToUpdate = TimeToUpdate.MinuteUp;
            System.Threading.Thread.Sleep(500);
            mouseDownTimer.Start();
        }

        void hourDownButton_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hours -= 1;

            timeToUpdate = TimeToUpdate.HourDown;
            System.Threading.Thread.Sleep(500);
            mouseDownTimer.Start();
        }

        void generic_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownTimer.Stop();
            timeToUpdate = TimeToUpdate.None;
        }
    }

    public enum TimeToUpdate
    {
        HourUp,
        HourDown,
        MinuteUp,
        MinuteDown,
        None
    };
}
