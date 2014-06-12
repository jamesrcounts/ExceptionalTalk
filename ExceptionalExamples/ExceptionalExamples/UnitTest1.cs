using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionalExamples
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void NullRef()
        {
            var routeA = Router.GetRoute("A");
            var routeB = Router.GetRoute("B");
            var routeC = Router.GetRoute("C");
            var processor = new Processor(routeA, routeB, routeC);
            processor.Run();
        }
    }

    public class Processor
    {
        private readonly Route a;

        private readonly Route b;

        private readonly Route c;

        public Processor(Route a, Route b, Route c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Run()
        {
            var helper = new Helper(this.a.From, this.b.To, this.c.ViaProxy);
            helper.Send();
        }
    }
}