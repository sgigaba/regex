namespace regexpressions.Patterns
{
    public abstract class ExpressionBase
    {
        protected Delegate IsMatch { get; set; }

        public abstract void SetDelegate(Func<char, bool> isDigit);

        public abstract void SetDelegate(Func<char, char, bool> isExactMatch);

        public abstract void SetDelegate(Func<string, bool> matchCharacters);

        public abstract bool InvokeDelegate(char value, char comparison);

        public abstract bool InvokeDelegate(char value);
    }
}