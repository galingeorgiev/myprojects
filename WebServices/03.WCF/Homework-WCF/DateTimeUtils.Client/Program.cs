namespace DateTimeUtils.Client
{
    using DateTimeUtils.Client.ServiceReferenceDateTimeUtil;
    using System;

    class Program
    {
        static void Main()
        {
            ServiceDateTimeUtilClient client = new ServiceDateTimeUtilClient();

            Console.WriteLine(client.GetDayOfWeek(new DateTime(2013, 8, 11)));
            Console.WriteLine(client.GetDayOfWeek(DateTime.Now));
            
            client.Close();
        }
    }
}
