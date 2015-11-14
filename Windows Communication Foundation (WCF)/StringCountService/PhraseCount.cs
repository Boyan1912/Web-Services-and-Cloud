namespace StringCountService
{
    //03. Create a Web service library which accepts two string as parameters.It should return the number of times the second string contains the first string.

    //Test it with the integrated WCF client.

    public class PhraseCount : IPhraseCountable
    {

        public int GetCount(string phrase, string text)
        {

            int count = 0;
            int index = text.IndexOf(phrase);
            while ( index >= 0)
            {
                count++;
                index = text.IndexOf(phrase, index + phrase.Length);
            }

            return count;
        }
    }
}
