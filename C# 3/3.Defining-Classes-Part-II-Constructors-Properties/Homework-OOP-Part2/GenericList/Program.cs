using System;
using System.Collections.Generic;

namespace GenericList
{
    class Program
    {
        static void Main()
        {
            //Create new list of strings and show functionality
            GenericList<string> myList = new GenericList<string>(10);
            myList[0] = "My";
            myList[1] = "name";
            myList[2] = "is";
            myList[3] = "Svetlin";
            myList[4] = "Nakov";
            Console.WriteLine(myList);

            myList.Add("I like beer!");
            Console.WriteLine(myList[5]);

            myList.RemoveByIndex(2); // remove 'is'
            Console.WriteLine(myList[2]); //print 'Svetlin'

            myList.Insert(2, "my name");
            Console.WriteLine(myList[2]);

            Console.WriteLine(myList.IndexOfElement("name",0)); // print '1'
            Console.WriteLine();
            Console.WriteLine(myList);
            myList[7] = "aaa";
            myList[8] = "bbb";
            myList[9] = myList.Max(myList[7], myList[8]);
            Console.WriteLine(myList[9]); //print 'bbb'

            //Create new list of strings and show functionality
            GenericList<int> otherList = new GenericList<int>(3);
            Console.WriteLine(otherList[0]);
        }
    }
}
