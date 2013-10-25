using System;

namespace VirtualShop
{
    class CustomerExperience : ISendMail
    {
        public void SendMail()
        {
            Console.WriteLine("Mail with promotion was send to customer!");
        }
    }
}
