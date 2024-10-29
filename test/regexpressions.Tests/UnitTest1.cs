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
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d")]
    public void Match_Digit_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','p','p','l','e'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w")]
    public void Match_Word_Character_Expression_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['*'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w")]
    public void Match_Mutliple_Patterns_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w\\w")]
    public void Match_Mutliple_Patterns_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);


        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d\\w\\w")]
    public void Match_Mutliple_Patterns_Short_Input_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','1','a','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }


    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','x','x','x','x'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_With_Later_Validation_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','x','x','1'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\w\\d")]
    public void Match_Mutliple_Patterns_Long_Input_With_Middle_Validation_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['x','x','1','x','x'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }


    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }


    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Multiple_Characters_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','a','a','a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("a")]
    public void Exact_Character_Match_Multiple_Characters_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','t','t','4'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','t','t','4'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['f','t','t','4'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Single_Input_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);


        Assert.True(result);
    }

    [Theory]
    [InlineData("[abc]")]
    public void Positive_Character_Groups_Single_Input_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['h'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("\\d[abc]\\w\\d")]
    public void Combine_Positive_Character_Groups_And_Matches_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','a','w','5'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[^abc]")]
    public void Negative_Character_Expression_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','y'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[^abc]")]
    public void Negative_Character_Expression_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['a','b'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }


    [Theory]
    [InlineData("[^abc]\\d[abc]")]
    public void Negative_Character_Expression_And_Positive_Character_Expressions_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','1','c'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("[^abc]\\d[abc]")]
    public void Negative_Character_Expression_And_Positive_Character_Expressions_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','1'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("[^abc]\\d[abc]vgy\\w\\w\\d")]
    public void Combination_Expressions_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['t','1','a','v','g','y','w','e','1'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("^log")]
    public void Start_Of_String_Anchor_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['s','l','o','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("^log")]
    public void Start_Of_String_Anchor_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['l','o','g','s'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("^\\d\\w\\w\\d[ghb][^abc]")]
    public void Start_Of_String_Anchor_And_Multiple_Characters_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','f','g','2','h','l'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("^\\d\\w\\w\\d[ghb][^abc]")]
    public void Start_Of_String_Anchor_And_Multiple_Characters_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','f','g','2','l','1','f','g','2','h','l'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("log$")]
    public void End_Of_String_Anchor_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['b','a','l','o','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("log$")]
    public void End_Of_String_Anchor_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['l','o','g','o'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }

    [Theory]
    [InlineData("^log$")]
    public void End_Of_String_Anchor_And_Start_Of_String_Anchor_Combined_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['l','o','g'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d\\w\\w\\d[ghb][^abc]$")]
    public void End_Of_String_Anchor_And_Multiple_Characters_Should_Pass(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['w','o','z','a','1','f','g','2','h','l'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.True(result);
    }

    [Theory]
    [InlineData("\\d\\w\\w\\d[ghb][^abc]$")]
    public void End_Of_String_Anchor_And_Multiple_Characters_Should_Fail(string inputExpression)
    {
        var expressionDetails = expression.BuildExpressionList(inputExpression);
        var result = expression.MatchExpression(['1','f','g','2','h','l','w','o','z','a'], expressionDetails.expressionList, expressionDetails.startAnchor, expressionDetails.endAnchor);

        Assert.False(result);
    }
}