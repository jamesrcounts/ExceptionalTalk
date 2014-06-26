using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionalExamples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using ApprovalTests;
    using ApprovalTests.StatePrinter;
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

        //Uri badUri = new Uri("mailto:test1@mischel.comtest2@mischel.com");
        //var absoluteUri = badUri.AbsoluteUri;
        //string f = "blah blah blah";
        //int hc = f.GetHashCode();
        //hc = Int32.MinValue;
        //string[] words = { "one", "two", "three" };
        //Console.WriteLine(words[Math.Abs(hc) % 3]);
        [TestMethod]
        public void ArrayCopy()
        {
            Component[] from = { new Button(), new Form(), new ToolTip(), };
            Component[] to = new Collage().GetMemories();
            Array.Copy(from, to, from.Length);
        }

        [TestMethod]
        public void DateTimeParse()
        {
            var form = new { Date = "2010-01-24" };
            var dateTime = DateTime.Parse(form.Date);
        }

        //var isAnimating = (bool)pb.Invoke("GetFlag", new object[] { 0x0010 });

        [TestMethod]
        public void ButtonAnimation()
        {
            var su = new SignUpPrompt();
            su.Advertise();
            var pb = new PrivateObject(su.BuyButton, new PrivateType(typeof(ButtonBase)));
            var isAnimating = (bool)pb.Invoke("GetFlag", new[] { 0x0010 });
            Assert.IsTrue(isAnimating);
        }

        [TestMethod]
        public void NativeTest()
        {
            NativeDll.svn_client_info();
        }
    }

    public class NativeDll
    {
        [DllImport("libsvn_client-1-0.dll")]
        public static extern int svn_client_info();
    }

    public class SignUpPrompt : Form
    {
        public SignUpPrompt()
        {
            BuyButton = new Button();
        }

        public Button BuyButton { get; private set; }

        public void Advertise()
        {
        }
    }

    public class Collage
    {
        public Component[] GetMemories()
        {
            return new Control[10];
        }
    }
}