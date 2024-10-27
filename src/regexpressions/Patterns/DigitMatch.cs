namespace regexpressions.Patterns
{
    public class DigitMatch : ExpressionBase
    {
        // take a character and return if it's a digit
        public DigitMatch()
        {
            setDelegate(char.IsDigit);   
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