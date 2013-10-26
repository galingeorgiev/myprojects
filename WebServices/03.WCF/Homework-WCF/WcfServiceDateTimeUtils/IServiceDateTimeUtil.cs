namespace WcfServiceDateTimeUtils
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceDateTimeUtil
    {

        [OperationContract]
        string GetDayOfWeek(DateTime date);
    }
}
