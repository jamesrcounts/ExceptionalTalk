using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionalExamples
{
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
    }
}