using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionalExamples
{
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Windows.Forms;

    using ApprovalTests.WinForms;

    using ApprovalUtilities.Utilities;

    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void NullRef()
        {
            var a = Router.GetRoute("A");
            var b = Router.GetRoute("B");
            var c = Router.GetRoute("C");
            var result = new Helper(a.From, b.To, c.ViaProxy).Send();
        }

        [TestMethod]
        public void FileStreamTest()
        {
            var name = PathUtilities.GetAdjacentFile("Kool.mdf");
            SqlCommand sqlCommand;

            using (var conn = new SqlConnection(@"jdbc:sqlserver://localhost;integratedSecurity=true;"))
            {
                conn.Open();

                sqlCommand = conn.CreateCommand();
                sqlCommand.CommandText = "SELECT 432";
                object executeScalar = sqlCommand.ExecuteScalar();
            }
        }

        [TestMethod]
        public void Rectangle()
        {
            var myForm = new MyForm();
            WinFormsApprovals.Verify(myForm);
        }
    }

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
                var rect = new Rectangle(random.Next(Width), random.Next(Height), w, h);
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