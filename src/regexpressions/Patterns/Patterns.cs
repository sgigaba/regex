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

        public (List<ExpressionBase> expressionList, bool startAnchor, bool endAnchor) BuildExpressionList(string expression)
        {
            var characterExpressions = new List<ExpressionBase>();
            ExpressionBase handlers;
            var startAnchor = false;
            var endAnchor = false;

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
                        var searchCharacters = "";
                        if (expression[i + 1] == '^')
                        {
                            searchCharacters = expression.Substring(i + 2, expression.IndexOf(']', i) - (i + 2));
                            characterExpressions.Add(new NegativeCharacterClass(searchCharacters));
                            i = expression.IndexOf(']', i);
                        }
                        else{
                            searchCharacters = expression.Substring(i + 1, expression.IndexOf(']', i) - (i + 1));
                            characterExpressions.Add(new PositiveCharacterClass(searchCharacters));
                            i = expression.IndexOf(']', i);
                        }
                        break;
                    case '^':
                        startAnchor = true;
                        break;
                    case '$':
                        endAnchor = true;
                        break;
                    default:
                       characterExpressions.Add(new ExactMatch(expression[i]));
                       break;
                }
            }

            return (characterExpressions, startAnchor, endAnchor);
        }

        public bool MatchExpression(char[] inputLine, List<ExpressionBase> expressions, bool startAnchor, bool endAnchor, int i = 0, int y = 0)
        {
            if (i == inputLine.Count())
            {
                if (i == inputLine.Count() && y == expressions.Count)
                    return true;
                return false;
            }

            if (y == expressions.Count)
            {
                if (endAnchor)
                {
                    if (i != inputLine.Count())
                        return false;
                    return true;
                }
                return true;
            }

            if (expressions[y].InvokeDelegate(inputLine[i]))
                return MatchExpression(inputLine, expressions, startAnchor, endAnchor, i + 1, y + 1);
            else
            {
                if (startAnchor)
                    return false;
                if (y > 0)
                    i--;
                return MatchExpression(inputLine, expressions, startAnchor, endAnchor, i + 1, 0);
            }
        }
    }
}