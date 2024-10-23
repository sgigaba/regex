namespace regexpressions.Patterns
{
    public abstract class ExpressionBase
    {
        protected Delegate isMatch { get; set; }

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