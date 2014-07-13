namespace ExceptionalExamples
{
    using System.Runtime.InteropServices;

    public class NativeDll
    {
        [DllImport("libsvn_client-1-0.dll")]
        public static extern int svn_client_info();
    }
}