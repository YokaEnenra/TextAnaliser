namespace RGZ_Real
{
    public static class Counter
    {
        public static int ParagraphsAmount;
        public static int SentencesAmount;
        public static int WordsAmount;
        public static int LettersAmount;
        public static int QuestionsAmount;
        public static int ExclamationsAmount;
        public static int CommasAmount;
        public static int CountParagraphs(string[] topic)
        {
            foreach (var text in topic)
            {
                if (text.Trim() != string.Empty)
                {
                    ParagraphsAmount++;
                }
            }

            return ParagraphsAmount;
        }

        public static int[] GetAll()
        {
            return new[] {ParagraphsAmount,SentencesAmount,WordsAmount,LettersAmount, CommasAmount, QuestionsAmount, ExclamationsAmount };
        }

        public static void Reset()
        {
            ParagraphsAmount = 0;
            SentencesAmount = 0;
            WordsAmount = 0;
            LettersAmount = 0;
            QuestionsAmount = 0;
            ExclamationsAmount = 0;
            CommasAmount = 0;
        }
    }
}
