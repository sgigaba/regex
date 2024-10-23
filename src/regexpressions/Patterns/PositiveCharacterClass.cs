namespace regexpressions.Patterns
{
    public class PositiveCharacterClass : ExpressionBase
    {
        // take a string with characters and return if a value in that string is in the character class

        public string SearchCharacters { get; set; }

        public PositiveCharacterClass(string searchCharacters)
        {
            this.SearchCharacters = searchCharacters;
            setDelegate(IsMatch);   
        }

        public override void setDelegate(Func<char, bool> matchCharacters)
        {
            isMatch = matchCharacters;
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.isMatch.DynamicInvoke(value);
        }

        private bool IsMatch(char value) => SearchCharacters.Contains(value);
    }
}