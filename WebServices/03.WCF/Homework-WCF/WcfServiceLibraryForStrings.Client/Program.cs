namespace WcfServiceLibraryForStrings.Client
{
    using System;
    using WcfServiceLibraryForStrings.Client.ServiceReferenceForStrings;

    class Program
    {
        static void Main()
        {
            ServiceForStringsClient client = new ServiceForStringsClient();
            Console.WriteLine(client.GetData("aabbccaabbaamaam", "aa"));
        }
    }
}
