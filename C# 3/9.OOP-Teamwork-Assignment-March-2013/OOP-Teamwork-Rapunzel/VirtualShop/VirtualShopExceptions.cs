using System;

namespace VirtualShop
{
    public class VirtualShopExceptions : Exception
    {
        public VirtualShopExceptions(string message)
            : base(message)
        { 
        }
    }
}
