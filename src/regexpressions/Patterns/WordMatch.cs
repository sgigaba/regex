namespace regexpressions.Patterns
{
    public class WordMatch : ExpressionBase
    {
        public WordMatch()
        {
            setDelegate(char.IsLetterOrDigit );   
        }

        public override void setDelegate(Func<char, bool> isDigit) => isMatch = isDigit;

        public override bool InvokeDelegate(char value) => (bool)this.isMatch.DynamicInvoke(value);

        public override void setDelegate(Func<char, char, bool> isExactMatch)
        {
            throw new NotImplementedException();
        }

        public override void setDelegate(Func<string, bool> matchCharacters)
        {
            throw new NotImplementedException();
        }

        public override bool InvokeDelegate(char value, char comparison)
        {
            throw new NotImplementedException();
        }
    }
}