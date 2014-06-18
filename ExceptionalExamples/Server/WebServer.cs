namespace ExceptionalExamples
{
    using System;

    public class WebServer
    {
        public static int? Port;

        static WebServer()
        {
            throw new Exception("You need to initialize WebServer.Port");
        }

        public WebServer()
        {
            if (Port == null)
            {
                throw new Exception("You need to initialize WebServer.Port");
            }
        }
    }
}