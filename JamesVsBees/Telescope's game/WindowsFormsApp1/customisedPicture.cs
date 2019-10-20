using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomisedPicture;


namespace CustomisedPicture
{
    public class TestClass
    {
 

        //public static void Func()
        //{
        //    //time consuming code
        //    UpdateStatus(status);
        //    // time consuming code
        //    UpdateStatus(status);
        //}

        //private void UpdateStatus(string status)
        //{
        //    // Make sure someone is listening to event
        //    if (OnUpdateStatus == null) return;

        //    ProgressEventArgs args = new ProgressEventArgs(status);
        //    OnUpdateStatus(this, args);
        //}
    }

    public class CustomisedPic : PictureBox
    {
        private PaintEventArgs args;

        public PaintEventArgs getArgs()
        {
            return args;
        }

        public void updateView()
        {
            Graphics g = this.CreateGraphics();

            if (this.Parent != null)
            {
                var index = Parent.Controls.GetChildIndex(this);
                for (var i = Parent.Controls.Count - 1; i > index; i--)
                {
                    var c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        using (var bmp = new Bitmap(c.Width, c.Height, g))
                        {
                            c.DrawToBitmap(bmp, c.ClientRectangle);
                            g.TranslateTransform(c.Left - Left, c.Top - Top);
                            g.DrawImageUnscaled(bmp, Point.Empty);
                            g.TranslateTransform(Left - c.Left, Top - c.Top);
                        }
                    }
                }
            }

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            args = e;

            Graphics g = e.Graphics;

            if (this.Parent != null)
            {
                var index = Parent.Controls.GetChildIndex(this);
                for (var i = Parent.Controls.Count - 1; i > index; i--)
                {
                    var c = Parent.Controls[i];
                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        using (var bmp = new Bitmap(c.Width, c.Height, g))
                        {
                            c.DrawToBitmap(bmp, c.ClientRectangle);
                            g.TranslateTransform(c.Left - Left, c.Top - Top);
                            g.DrawImageUnscaled(bmp, Point.Empty);
                            g.TranslateTransform(Left - c.Left, Top - c.Top);
                        }
                    }
                }
            }
        }
    }
}
