
namespace regexpressions.Patterns
{
    public class NegativeCharacterClass : ExpressionBase
    {
        private string SearchCharacters {get; set;}

        public NegativeCharacterClass(string searchCharacters)
        {
            this.SearchCharacters = searchCharacters;
            setDelegate(IsMatch);   
        }

        public override void setDelegate(Func<char, bool> matchCharacters)
        {
            isMatch = matchCharacters;
        }

        public override bool InvokeDelegate(char value, char comparison)
        {
            throw new NotImplementedException();
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.isMatch.DynamicInvoke(value);
        }

        public override void setDelegate(Func<char, char, bool> isExactMatch)
        {
            throw new NotImplementedException();
        }

        private bool IsMatch(char value) => !SearchCharacters.Contains(value);

        public override void setDelegate(Func<string, bool> matchCharacters)
        {
            throw new NotImplementedException();
        }
    }
}
