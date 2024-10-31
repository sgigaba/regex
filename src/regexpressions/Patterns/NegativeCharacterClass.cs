
namespace regexpressions.Patterns
{
    public class NegativeCharacterClass : ExpressionBase
    {
        private string SearchCharacters {get; set;}

        public NegativeCharacterClass(string searchCharacters)
        {
            this.SearchCharacters = searchCharacters;
            SetDelegate(DoesNotContainCharacter);   
        }

        public override void SetDelegate(Func<char, bool> matchCharacters)
        {
            base.IsMatch = matchCharacters;
        }

        public override bool InvokeDelegate(char value, char comparison)
        {
            throw new NotImplementedException();
        }

        public override bool InvokeDelegate(char value)
        {
            return (bool)this.IsMatch.DynamicInvoke(value);
        }

        public override void SetDelegate(Func<char, char, bool> isExactMatch)
        {
            throw new NotImplementedException();
        }

        private bool DoesNotContainCharacter(char value) => !SearchCharacters.Contains(value);

        public override void SetDelegate(Func<string, bool> matchCharacters)
        {
            throw new NotImplementedException();
        }
    }
}
