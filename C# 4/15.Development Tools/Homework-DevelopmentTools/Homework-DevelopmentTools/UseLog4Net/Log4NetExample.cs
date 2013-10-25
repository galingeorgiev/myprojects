using log4net;
using log4net.Config;

namespace UseLog4Net
{
    class Log4NetExample
    {
        private static readonly ILog firstLog = LogManager.GetLogger("FirstLogger");
        private static readonly ILog secondLog = LogManager.GetLogger("SecondLogger");

        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    firstLog.Debug(i);
                }
                else
                {
                    secondLog.Debug(i);
                }
            }
        }
    }
}
