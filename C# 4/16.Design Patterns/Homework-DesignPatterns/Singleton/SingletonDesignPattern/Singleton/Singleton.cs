namespace Singleton
{
    class Singleton
    {
        private static Singleton instance;

        private Singleton()
        {
            // Class for which we want to have single instance.
        }

        public static Singleton getInstance()
        {
            if (instance == null)
            {
                instance = new Singleton();
            }

            return instance;
        }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}