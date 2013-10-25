namespace CatalogOfFreeContent.Test
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTestPerformance
    {
        [Ignore]
        [TestMethod]
        [Timeout(5000)]
        public void TestUpdatePerformance()
        {
            int addsCount = 6000;
            int updatesCount = 3000;

            // Prepare the input commands 
            StringBuilder input = new StringBuilder();
            input.AppendLine("Add movie: mov; au; 42323723; http://movie.com");
            for (int i = 0; i < addsCount; i++)
            {
                input.AppendLine("Add application: app; a; 12345; http://oldurl");
            }

            input.AppendLine("Update: http://newmovie.com; http://othermovie.com");
            input.AppendLine("Update: http://movie.com; http://newmovie.com");
            input.AppendLine("Update: http://movie.com; http://newmovie.com");
            for (int i = 0; i < updatesCount; i++)
            {
                input.AppendLine("Update: http://oldurl; http://newurl");
                input.AppendLine("Update: http://newurl; http://oldurl");
            }

            input.AppendLine("Update: http://newurl; http://otherurl");
            input.AppendLine("Update: http://movie.com; http://newmovie.com");
            input.AppendLine("Update: http://newmovie.com; http://otherurl");
            input.AppendLine("End");

            // Prepare the expected result 
            StringBuilder expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Movie added");
            for (int i = 0; i < addsCount; i++)
            {
                expectedOutput.AppendLine("Application added");
            }

            expectedOutput.AppendLine("0 items updated");
            expectedOutput.AppendLine("1 items updated");
            expectedOutput.AppendLine("0 items updated");
            for (int i = 0; i < 2 * updatesCount; i++)
            {
                expectedOutput.AppendLine(addsCount + " items updated");
            }

            expectedOutput.AppendLine("0 items updated");
            expectedOutput.AppendLine("0 items updated");
            expectedOutput.AppendLine("1 items updated");

            // Redirect the console input / output and invoke the Main() method
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            CatalogOfFreeContent.StartUsingCatalog.Main();

            // Assert that the program execution result is correct
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Ignore]
        [TestMethod]
        [Timeout(5000)]
        public void TestSearchPerformance()
        {
            int addsCount = 10000;
            int searchCount = 50000;

            // Prepare the input commands
            StringBuilder input = new StringBuilder();
            for (int i = 0; i < addsCount; i++)
            {
                input.AppendLine("Add application: app; a; 12345; http://oldurl");
            }

            for (int i = 0; i < searchCount; i++)
            {
                input.AppendLine("Find: app; 100");
            }

            input.AppendLine("End");

            // Prepare the expected result 
            StringBuilder expectedOutput = new StringBuilder();
            for (int i = 0; i < addsCount; i++)
            {
                expectedOutput.AppendLine("Application added");
            }

            for (int i = 0; i < searchCount * 100; i++)
            {
                expectedOutput.AppendLine("Application: app; a; 12345; http://oldurl");
            }

            // Redirect the console input / output and invoke the Main() method
            Console.SetIn(new StringReader(input.ToString()));
            StringWriter consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);
            CatalogOfFreeContent.StartUsingCatalog.Main();

            // Assert that the program execution result is correct
            string expected = expectedOutput.ToString();
            string actual = consoleOutput.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
