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

namespace SimpleAlarm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timeUpDownControl1 = new SimpleAlarm.Controls.TimeUpDownControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "My alarm is set to go off at...";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(263, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 94);
            this.button1.TabIndex = 4;
            this.button1.Text = "Snooze";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timeUpDownControl1
            // 
            this.timeUpDownControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 63F);
            this.timeUpDownControl1.ForeColor = System.Drawing.Color.Silver;
            this.timeUpDownControl1.Hours = 0;
            this.timeUpDownControl1.Location = new System.Drawing.Point(15, 25);
            this.timeUpDownControl1.Minutes = 0;
            this.timeUpDownControl1.Name = "timeUpDownControl1";
            this.timeUpDownControl1.Size = new System.Drawing.Size(242, 94);
            this.timeUpDownControl1.TabIndex = 3;
            this.timeUpDownControl1.Text = "timeUpDownControl1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 133);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.timeUpDownControl1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Simple Alarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Controls.TimeUpDownControl timeUpDownControl1;
        private System.Windows.Forms.Button button1;
    }
}

