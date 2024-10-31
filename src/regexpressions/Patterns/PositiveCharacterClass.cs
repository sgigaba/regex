namespace regexpressions.Patterns
{
    public class PositiveCharacterClass : ExpressionBase
    {
        // take a string with characters and return if a value in that string is in the character class

        public string SearchCharacters { get; set; }

        public PositiveCharacterClass(string searchCharacters)
        {
            this.SearchCharacters = searchCharacters;
            SetDelegate(ContainsCharacter);   
        }

        public override void SetDelegate(Func<char, bool> matchCharacters)
        {
            base.IsMatch = matchCharacters;
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.IsMatch.DynamicInvoke(value);
        }

        private bool ContainsCharacter(char value) => SearchCharacters.Contains(value);

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