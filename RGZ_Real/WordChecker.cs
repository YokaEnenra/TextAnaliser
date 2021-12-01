namespace RGZ_Real
{
    internal class WordChecker: Checker
    {
        public static void IsWord()
        {
            if (LetterChecker.IsLetter(PrevSymbol))
            {
                BetweenWords++;
                BetweenLetters = 0;
                Counter.WordsAmount++;
            }
        }
        public override bool Check(char symbol)
        {
            if (symbol == 34 || symbol == 32)
            {
                IsWord();
                return true;
            }
            return false;
        }

    }
}
