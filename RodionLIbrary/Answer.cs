using System;

namespace RodionLIbrary
{
    public abstract class Answer : IAnswer
    {
        private const int _defaultDecimals = 3;

        public string SolutionText
        {
            get;

            protected set;
        }

        protected void AddText(string text, string sep = "\n") => SolutionText += sep + text;

        protected static double Round(double value, int decimals = _defaultDecimals) => Math.Round(value, decimals);
    }
}
