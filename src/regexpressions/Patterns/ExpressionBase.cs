namespace regexpressions.Patterns
{
    public abstract class ExpressionBase
    {
        protected Delegate isMatch { get; set; }

        public abstract void setDelegate(Func<char, bool> isDigit);
        

        public abstract void setDelegate(Func<char, char, bool> isExactMatch);

        public abstract void setDelegate(Func<string, bool> matchCharacters);

        public abstract bool InvokeDelegate(char value, char comparison);

        public abstract bool InvokeDelegate(char value);
    }
}