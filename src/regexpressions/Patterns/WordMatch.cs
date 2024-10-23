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
    }
}