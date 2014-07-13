using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionalExamples
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
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
    public class Examples
    {
        [TestMethod]
        public void RouteToNullEvil()
        {
            var a = Router.GetRoute("A");
            var b = Router.GetRoute("B");
            var c = Router.GetRoute("C");
            var result = new Helper(a.From, b.To, c.ViaProxy).Send();
            //dynamic m;

            //throw new NullReferenceException(
            //    "Null reference while executing: {0}.{1}",
            //    m.ClassName,
            //    m.MethodSignature());
        }

        [TestMethod]
        public void HeapfulOfRectangles()
        {
            var myForm = new MyForm();
            WinFormsApprovals.Verify(myForm);

            //            Point start = null;
            //            Point end = null;

            //            throw new ArgumentException(@"Rectangle ‘{{X={0},Y={1},Width={2},Height={3}}}'
            //cannot have a width or height equal to 0.", start.X, start.Y, end.X - start.X, end.Y - start.Y);
        }

        [TestMethod]
        public void CastIntoVoid()
        {
            Component[] from = { new Button(), new Form(), new ToolTip(), };
            Component[] to = new Collage().GetMemories();
            Array.Copy(from, to, from.Length);

            //int[] to = { 1 };
            //object element = "a";
            //throw new InvalidCastException(string.Format("<{0}> could not be cast to destination array type <{1}>", element.GetType().Name, to.GetType().Name));
        }

        [TestMethod]
        public void DateWithAParser()
        {
            var input = "2010-01-24";
            var form = new { Date = input };
            var dateTime = DateTime.Parse(form.Date);

            throw new FormatException(@"Cannot parse '{0}' at index {1}
Valid formats include:
 '<Month> <Day> <Year>' => 'January 14 2010'
 '<Month>/<Day>/<Year>' => '1/14/2010'
 '<Year>-<Month>-<Day>' => '2010-01-24'".FormatWith(input, 7));
        }

        //var isAnimating = (bool)pb.Invoke("GetFlag", new object[] { 0x0010 });

        [TestMethod]
        public void TouchingYourPrivates()
        {
            var su = new SignUpPrompt();
            su.Advertise();
            var pb = new PrivateObject(su.BuyButton, new PrivateType(typeof(ButtonBase)));
            var isAnimating = (bool)pb.Invoke("GetFlag", new[] { 0x0010 });
            Assert.IsTrue(isAnimating);

            dynamic m;
            object commonFixes;
            var method = m.GetMethodSignature();
            throw new MissingMethodException(@"Cannot find method: {0}.
 Possible methods starting with “{1}” are:\n{2}
 Common Fixes\n{3}".FormatWith(method, method[0], this.GetMethodsStartingWith(method[0]), commonFixes));
        }

        [TestMethod]
        public void DoNotDisturbTheNatives()
        {
            NativeDll.svn_client_info();

            var dll = "libsvn_client-1-0.dll";
            object missingDependancy;
            string[] allDependancies;
            throw new DllNotFoundException(@"Problems loading dependencies for '{0}'.
Could not find dependency: '{1}'
Required libraries:\n{2}".FormatWith(dll, missingDependancy, allDependancies.ToReadableString()));
        }

        private object GetMethodsStartingWith(object o)
        {
            throw new NotImplementedException();
        }
    }
}