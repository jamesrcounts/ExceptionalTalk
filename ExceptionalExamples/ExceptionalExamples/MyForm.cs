namespace ExceptionalExamples
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class MyForm : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var random = new Random(10003);

            for (var i = 0; i < 10000; i++)
            {
                int w = random.Next(this.Width);
                int h = random.Next(this.Height);
                var start = new Point(0, 0);
                var end = new Point(w, h);
                var b = new LinearGradientBrush(start, end, Color.Red, Color.Blue);
                var rect = new Rectangle(random.Next(this.Width), random.Next(this.Height), w, h);
                e.Graphics.FillRectangle(b, rect);
            }

            //var b = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.Red, Color.Blue, 1.0f);
        }

        protected void OnPaint2(PaintEventArgs e)
        {
            var random = new Random(10003);

            for (var i = 0; i < 10000; i++)
            {
                int w = random.Next(this.Width);
                int h = random.Next(this.Height);

                //var b = new LinearGradientBrush(new Point(0, 0), new Point(w, h), Color.Red, Color.Blue);
                var b = new LinearGradientBrush(new Rectangle(0, 0, w, h), Color.Red, Color.Blue, 1.0f);
                var rect = new Rectangle(random.Next(this.Width), random.Next(this.Height), w, h);
                e.Graphics.FillRectangle(b, rect);
            }
        }
    }
}