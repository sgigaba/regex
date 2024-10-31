namespace regexpressions.Patterns
{
    public class DigitMatch : ExpressionBase
    {
        // take a character and return if it's a digit
        public DigitMatch()
        {
            SetDelegate(char.IsDigit);   
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