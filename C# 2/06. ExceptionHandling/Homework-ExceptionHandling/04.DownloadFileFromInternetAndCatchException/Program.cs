using System;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string fileAddress = @"http://www.devbg.org/img/Logo-BASD.jpg";
        //File will be saved in Bin/Debug folder
        string saveAddress = "Logo-BASD.jpg";

        try
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(fileAddress, saveAddress);
            }
            Console.WriteLine("Job is DONE!");
        }
        catch (WebException we)
        {
            Console.Error.WriteLine("{0}", we.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.Error.WriteLine("{0}", dnfe.Message);
        }
        catch (ArgumentNullException ane)
        {
            Console.Error.WriteLine("{0}", ane.Message);
        }
    }
}