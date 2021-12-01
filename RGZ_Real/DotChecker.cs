namespace RGZ_Real
{
    internal class DotChecker : Punctuation
    {
        public override bool Check(char symbol)
        {
            if (symbol == 46)
            {
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
