using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.GenerateCryptoKey
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] secretkey = new byte[64];
                rng.GetBytes(secretkey);

                var dir = Directory.GetCurrentDirectory();

                using (FileStream writer = new FileStream(@dir+ @"\SecretKey.key", FileMode.Create))
                {
                    writer.Write(secretkey, 0, secretkey.Length);
                }
                Console.WriteLine("Created file in " + dir);
            }
            Console.ReadLine();
        }
    }
}
