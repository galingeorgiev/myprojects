namespace WcfServiceLibraryForStrings
{

    public class ServiceForStrings : IServiceForStrings
    {
        public int GetData(string firstString, string secondString)
        {
            int i = 0;
            int count = 0;
            while ((i = firstString.IndexOf(secondString, i)) != -1)
            {
                i++;
                count++;
            }

            return count;
        }
    }
}
