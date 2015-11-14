namespace DayOfWeekService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IDayOfWeekInBulgarian
    {

        [OperationContract]
        string GetDayOfWeekInBulgarian(DateTime value);
        
    }
    
}
