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
    }
}