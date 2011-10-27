using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SimpleAlarm.Controls
{
    public class TimeUpDownControlButton : Control
    {
        bool isHovered = false;
        bool isSelected = false;

        bool facingDown = false;
        public bool FacingDown
        {
            get { return facingDown; }
            set { facingDown = value; }
        }

        public TimeUpDownControlButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Size = new Size(20, 10);
        }

        protected void DrawNormalState(Graphics g)
        {
            if (!facingDown)
                g.DrawImage(SimpleAlarm.Properties.Resources.upButton, this.Bounds);
            else
                g.DrawImage(SimpleAlarm.Properties.Resources.downButton, this.Bounds);
        }

        protected void DrawHoveredState(Graphics g)
        {
            g.FillRectangle(SystemBrushes.ButtonHighlight, this.Bounds);
            DrawNormalState(g);
        }

        protected void DrawSelectedState(Graphics g)
        {
            g.FillRectangle(SystemBrushes.ButtonShadow, this.Bounds);
            DrawNormalState(g);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            isHovered = true;
            this.Refresh();

            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            isHovered = false;
            this.Refresh();

            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            isSelected = true;
            this.Refresh();

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isSelected = false;
            this.Refresh();

            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (isHovered)
                e.Graphics.FillRectangle(SystemBrushes.ButtonHighlight, e.ClipRectangle);

            if (!facingDown)
                e.Graphics.DrawImage(SimpleAlarm.Properties.Resources.upButton, e.ClipRectangle);
            else
                e.Graphics.DrawImage(SimpleAlarm.Properties.Resources.downButton, e.ClipRectangle);

            base.OnPaint(e);
        }
    }
}
