namespace StringCountService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IPhraseCountable
    {
        [OperationContract]
        int GetCount(string phrase, string text);
    }
}
