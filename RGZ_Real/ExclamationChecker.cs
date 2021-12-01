namespace RGZ_Real
{
    internal class ExclamationChecker : Punctuation
    {
        public override bool Check(char symbol)
        {
            if (symbol == 33)
            {
                Counter.ExclamationsAmount++;
                WordChecker.IsWord();
                if (IsSentence())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
