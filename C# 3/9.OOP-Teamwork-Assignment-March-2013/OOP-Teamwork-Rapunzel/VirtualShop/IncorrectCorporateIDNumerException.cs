using System;

namespace VirtualShop
{
    class IncorrectCorporateIDNumberException : Exception
    {
         public IncorrectCorporateIDNumberException()
            : base(message: "ID must have 9 or 13 digits!")
        {
        }
    }
}
