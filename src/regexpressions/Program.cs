using regexpressions.Patterns;

if (args[0] != "-E")
{
    Console.WriteLine("Expected first argument to be '-E'");
    Environment.Exit(2);
}

var inputLine = Console.In.ReadToEnd();
var pattern = args[1];

var patternBuilder = new Patterns();
var expressionDetails = patternBuilder.BuildExpressionList(pattern);

var isMatch = patternBuilder.MatchExpression(inputLine.ToCharArray(), expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);
var result = isMatch ? "is a match" : "is not a match";

Console.WriteLine($"The input: {inputLine} {result} for the expression: {pattern}");