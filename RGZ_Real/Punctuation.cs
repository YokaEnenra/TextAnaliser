namespace RGZ_Real
{
    internal class Punctuation: Checker

    {
    protected static bool IsSentence()
    {
        if (BetweenWords > 0)
        {
            Counter.SentencesAmount++;
            BetweenWords = 0;
            return true;
        }

        return false;
    }
    }
}
