namespace regexpressions.Patterns
{
    public class ExactMatch : ExpressionBase
    {
        // take a word and return if it's an exact match
        public char Comparison { get; set; }

        public ExactMatch(char comparison)
        {
            this.Comparison = comparison;
            SetDelegate(IsExactMatch); 
        }

        public override void SetDelegate(Func<char, bool> isExactMatch) => IsMatch = isExactMatch;

        public override bool InvokeDelegate(char value) => (bool)this.IsMatch.DynamicInvoke(value);

        private bool IsExactMatch(char value) => value == this.Comparison;

        public override void SetDelegate(Func<char, char, bool> isExactMatch)
        {
            throw new NotImplementedException();
        }

        public override void SetDelegate(Func<string, bool> matchCharacters)
        {
            throw new NotImplementedException();
        }

        public override bool InvokeDelegate(char value, char comparison)
        {
            throw new NotImplementedException();
        }
    }
}