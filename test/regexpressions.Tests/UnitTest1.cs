namespace regexpressions.Tests;
using regexpressions.Patterns;

using Xunit;

public class PatternsTests
{
    private readonly Patterns expression;

    public PatternsTests()
    {
        expression = new Patterns();
    }

    [Theory]
    [InlineData("\\d")]
    public void Match_Digit_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression("1", expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d")]
    public void Match_Digit_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression("a", expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression("a", expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression("*", expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w")]
    public void Match_Mutliple_Patterns_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression("a1g", expressionList);

        Assert.False(result);
    }
}
