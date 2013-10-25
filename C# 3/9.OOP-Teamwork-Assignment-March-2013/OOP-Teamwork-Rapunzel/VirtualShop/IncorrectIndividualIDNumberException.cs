using System;

namespace VirtualShop
{
    class IncorrectIndividualIDNumberException : Exception
    {
        public IncorrectIndividualIDNumberException()
            : base(message: "ID must have 10 digits!")
        {
        }
    }
}
