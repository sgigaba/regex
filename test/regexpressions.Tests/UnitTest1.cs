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
        var result = expression.MatchExpression(['1'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d")]
    public void Match_Digit_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','p','p','l','e'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['*'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w")]
    public void Match_Mutliple_Patterns_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','g'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w\\w")]
    public void Match_Mutliple_Patterns_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','g'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w\\w")]
    public void Match_Mutliple_Patterns_Short_Input_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','a'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','a','g'], expressionList);

        Assert.True(result);
    }


    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','x','x','x','x'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_With_Later_Validation_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','x','x','1'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_With_Middle_Validation_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','1','x','x'], expressionList);

        Assert.True(result);
    }


    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t'], expressionList);

        Assert.False(result);
    }


    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Multiple_Characters_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','a','a','a'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Multiple_Characters_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','t','t','4'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','t','t','4'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['f','t','t','4'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Single_Input_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Single_Input_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['h'], expressionList);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\d[abc]\\w\\d")]
    public void Combine_Positive_Character_Groups_And_Matches_Should_Pass(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','a','w','5'], expressionList);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d[abc]\\w\\d")]
    public void Combine_Positive_Character_Groups_And_Matches_Should_Fail(string inputExpression)
    {
        var expressionList = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','a','a','w','5'], expressionList);

        Assert.False(result);
    }
}