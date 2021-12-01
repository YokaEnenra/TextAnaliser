namespace RGZ_Real
{
    internal class QuestionChecker : Punctuation
    {
        public override bool Check(char symbol)
        {
            if (symbol == 63)
            {
                Counter.QuestionsAmount++;
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
