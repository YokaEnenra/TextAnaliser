namespace RGZ_Real
{
    internal class LetterChecker: Checker
    {
        public static bool IsLetter(char symbol)
        {
            return symbol >= 1040 && symbol <= 1103 || symbol >= 65 && symbol <= 90 || symbol >= 97 && symbol <= 122 ||
                   symbol == 1030 || symbol == 1031 || symbol == 1110 ||
                   symbol == 1111 || symbol == 1108 || symbol == 1028 || symbol == 1168 || symbol == 1169;
        }
        public override bool Check(char symbol)
        {
            if (IsLetter(symbol))
            {
                Counter.LettersAmount++;
                BetweenLetters++;
                return true;
            }

            return false;
        }
    }
}
