namespace WcfServiceLibraryForStrings
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceForStrings
    {
        [OperationContract]
        int GetData(string firstString, string secondString);
    }
}
