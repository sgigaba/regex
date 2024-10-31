namespace regexpressions.Patterns
{
    public class WordMatch : ExpressionBase
    {
        public WordMatch()
        {
            SetDelegate(char.IsLetterOrDigit );   
        }

        public override void SetDelegate(Func<char, bool> isDigit) => IsMatch = isDigit;

        public override bool InvokeDelegate(char value) => (bool)this.IsMatch.DynamicInvoke(value);

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