namespace regexpressions.Patterns 
{
    public class Patterns
    {
        Dictionary<string, Func<char, bool>> _expressionss = new Dictionary<string, Func<char, bool>>
        {
            { "\\d", char.IsDigit },
            { "\\w", char.IsLetterOrDigit }
        };

        public List<Func<char, bool>> BuildExpressionList(string expression)
        {
            var characterExpressions = new List<Func<char, bool>>();

            for (int i = 0; i < expression.Length - 1; i++)
            {
                switch (expression[i])
                {
                    case '\\':
                        Func<char, bool> searchDelegate;
                        var search = string.Concat(expression[i], expression[i + 1]);
                        
                        _expressionss.TryGetValue(search, out searchDelegate);

                        if (searchDelegate != null)
                            characterExpressions.Add(searchDelegate);
                        else
                            Console.WriteLine("There is No such");
                        i++;
                        break;
                }
            }
            return characterExpressions;
        }

        public bool MatchExpression(string inputLine, List<Func<char, bool>> expressions)
        {
            int i = 0;
            foreach (var val in inputLine)
            {
                if (expressions[i].Invoke(val))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
