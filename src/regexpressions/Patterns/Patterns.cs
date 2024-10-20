using System.Dynamic;

namespace regexpressions.Patterns
{
    public class Patterns
    {
        Dictionary<string, ExpressionBase> expressionHandler = new Dictionary<string, ExpressionBase>
        {
            { "\\d", new DigitMatch() },
            { "\\w", new WordMatch() },
        };

        public List<ExpressionBase> BuildExpressionList(string expression)
        {
            var characterExpressions = new List<ExpressionBase>();
            ExpressionBase handlers;

            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '\\':
                        var search = string.Concat(expression[i], expression[i + 1]);
                        
                        expressionHandler.TryGetValue(search, out handlers);

                        if (handlers != null)
                            characterExpressions.Add(handlers);
                        else
                            Console.WriteLine("There is No such");
                        i++;
                        break;
                    case '[':
                        var searchCharacters = expression.Substring(i + 1, expression.IndexOf(']') - (i + 1));
                        characterExpressions.Add(new PositiveCharacterClass(searchCharacters));
                        i = expression.IndexOf(']');
                        break;
                    default:
                       characterExpressions.Add(new ExactMatch(expression[i]));
                       break;
                }
            }

            return characterExpressions;
        }

        public bool MatchExpression(char[] inputLine, List<ExpressionBase> expressions, int i = 0, int y = 0)
        {
            if (i == inputLine.Count())
            {
                // if I've looped to the end of the expression and the end of the input line
                if (i == inputLine.Count() && y == expressions.Count)
                    return true;

                return false;
            }

            if (y == expressions.Count)
                return true;

            if (expressions[y].InvokeDelegate(inputLine[i]))
                return MatchExpression(inputLine, expressions, i + 1, y + 1);
            else
                return MatchExpression(inputLine, expressions, i + 1, 0);
        }
    }
}