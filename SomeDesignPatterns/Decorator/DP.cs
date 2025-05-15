using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
	/*Senaryo: Şirket içi mailler bir plugin yazmaktasınız. Her kuralı uygulayabilmeniz için ne yaparsınız?*/

	public interface IMail
	{
		void Send();
	}
    public class Mail : IMail
    {
        public void Send()
        {
            Console.WriteLine("Eposta gönderildi");
        }
    }

    public abstract class MailDecorator : IMail
    {
        private readonly IMail _mail;

        protected MailDecorator(IMail mail)
        {
            _mail = mail;
        }

        public void Send()
        {
            _mail.Send();
        }
    }

    public class SignedMail : MailDecorator
    {
        public SignedMail(IMail mail) : base(mail)
        {
        }

        public void AddSign(string key)
        {
            Console.WriteLine($"{key} olarak imzalandı");
        }
    }


    public class CryptoMail : MailDecorator
    {
        public CryptoMail(IMail mail) : base(mail)
        {
        }

        public string CryptoAlgorithm { get; set; }
        public void Crypt()
        {
            Console.WriteLine($"{CryptoAlgorithm} algoritması ile şifrelendi");
        }
    }



}
