namespace regexpressions.Patterns
{
    public class WordMatch : ExpressionBase
    {
        Delegate isMatch { get; set; }

        public WordMatch()
        {
            setDelegate(char.IsLetterOrDigit );   
        }

        public override void setDelegate(Func<char, bool> isDigit)
        {
            isMatch = isDigit;
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.isMatch.DynamicInvoke(value);
        }
        // take a word and return if it's a word or digit 
    }
}