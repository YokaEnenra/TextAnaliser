namespace RGZ_Real
{
    internal class CommaChecker : Punctuation
    {
        public override bool Check(char symbol)
        {
            if (symbol == 44)
            {
                Counter.CommasAmount++;
                WordChecker.IsWord();
                return true;
            }

            return false;
        }
    }
}
