using System.IO.Compression;
using System.Security.Cryptography;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Varolan bir sınıfa yeni özellik eklemek istiyorsunuz. Ancak miras alma ihtimaliniz 0. Nasıl çözersiniz?
            //Bir ürünü hediye paketi yaptığınızda, hediye paketi üründen miras almaz. O ürünün yeni formudur...

            /*
             * 
             */

           //Stream stream = new MemoryStream();
           // CryptoStream cryptoStream = new CryptoStream(stream,null, CryptoStreamMode.Write);
           // GZipStream gZipStream = new GZipStream(cryptoStream,  CompressionMode.Decompress);

            Mail mail = new Mail();
            SignedMail signedMail = new SignedMail(mail);
            signedMail.AddSign("Türkay");

            CryptoMail cryptoMail = new CryptoMail(signedMail);
            cryptoMail.CryptoAlgorithm = "SHA256";

            cryptoMail.Crypt();

            cryptoMail.Send();





        }
    }
}
