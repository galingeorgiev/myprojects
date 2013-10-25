using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();
            string fileContent = null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                fileContent = reader.ReadToEnd();
            }

            Console.WriteLine(fileContent);
        }
        catch (OutOfMemoryException ome)
        {
            Console.Error.WriteLine("{0}\nYou have not enough memory to read this file.", ome.Message);
        }
        catch (FileNotFoundException fnfe)
        {
            Console.Error.WriteLine("{0}\nYou enter wrong file path or file doesn't exist.", fnfe.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.Error.WriteLine("{0}\nYou enter wrong file path or directory doesn't exist.", dnfe.Message);
        }
        catch (FileLoadException fle)
        {
            Console.Error.WriteLine("{0}\nFile can't be loaded.", fle.Message);
        }
        catch (FieldAccessException fae)
        {
            Console.Error.WriteLine("{0}\nYou have not access to read this file.", fae.Message);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine("{0}", e.Message);
        }
    }
}
