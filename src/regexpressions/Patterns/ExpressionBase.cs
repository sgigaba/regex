namespace regexpressions.Patterns
{
    public class ExpressionBase
    {
        Delegate isMatch;

        public virtual void setDelegate(Func<char, bool> isDigit)
        {
        }

        public virtual void setDelegate(Func<char, char, bool> isExactMatch)
        {
        }

        public virtual void setDelegate(Func<string, bool> matchCharacters)
        {
        }

        public virtual bool InvokeDelegate(char value, char comparison)
        {
            return false;
        }

        public virtual bool InvokeDelegate(char value)
        {
            return false;
        }
    }
}