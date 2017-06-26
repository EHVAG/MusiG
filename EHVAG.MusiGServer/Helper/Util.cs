using System;

namespace EHVAG.MusiGServer.Helper
{
    internal class Util
    {
        public static void PrintException(Exception e)
        {
            Console.WriteLine($"Exception: ${e.Message}");
            if (e.InnerException != null)
                Console.WriteLine($"Exception: ${e.InnerException}");
            Console.WriteLine($"Exception: ${e.StackTrace}");
        }
    }
}