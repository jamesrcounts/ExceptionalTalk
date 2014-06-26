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
        public void Name()
        {
            var foo = new Foo();
            var pFoo = new PrivateObject(foo);
            var response = new object();
            pFoo.Invoke("SaveCallback", new object[] { response, (Action)null, }); //this line throws exception
        }

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

        public class Foo
        {
            private void SaveCallback(object response,
                                                   Action rollbackActionIfSaveFails,
                                                   Action postSaveActionOnSuccess)
            { }
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