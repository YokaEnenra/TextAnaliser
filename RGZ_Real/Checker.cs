namespace RGZ_Real
{
    public abstract class Checker
    {
        protected static int BetweenWords = 0;
        protected static int BetweenLetters = 0;
        public static char PrevSymbol = '0';

        public virtual bool Check(char symbol)
        {
            return false;
        }
    }
}
