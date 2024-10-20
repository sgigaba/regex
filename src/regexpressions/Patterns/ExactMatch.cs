namespace regexpressions.Patterns
{
    public class ExactMatch : ExpressionBase
    {
        // take a word and return if it's an exact match
        Delegate isMatch { get; set; }
        public char comparison { get; set; }

        public ExactMatch(char comparison)
        {
            this.comparison = comparison;
            setDelegate(isExactMatch); 
        }

        public override void setDelegate(Func<char, bool> isExactMatch)
        {
            isMatch = isExactMatch;
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.isMatch.DynamicInvoke(value);
        }

        private bool isExactMatch(char value) => value == this.comparison;
    }
}