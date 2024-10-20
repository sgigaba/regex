
/*if (args[0] != "-E")
{
    Console.WriteLine("Expected first argument to be '-E'");
    Environment.Exit(2);
}*/


using regexpressions.Patterns;

string inputLine = Console.In.ReadToEnd();
// string inputLine = "abcdabcc is abcdabcc, not efg";
//string inputLine = "1a1a";
 string pattern =args[1]; 
//string pattern = "\\d\\w\\d\\w"; 
// string pattern = "([abcd]+) is \\1, not [^xyz]+";
//string pattern = "abcde\\d";

//var patternExpressions = new List<Expressions>();

inputLine = inputLine.Trim();
var expressionBuilder = new Patterns();


var expressions = expressionBuilder.BuildExpressionList(pattern);

Console.WriteLine(expressions);
int i = 0;

foreach(var val in inputLine)
{
    if (expressions[i].Invoke(val)){
        Console.WriteLine("Match");
        i++;
    }
}
/*
List<bool> foundMatches = new List<bool>();

// You can use print statements as follows for debugging, they'll be visible when running tests.
Console.WriteLine("Logs from your program will appear here!");


var startAnchor = false;
var endAnchor = false;
var backReferences = new Dictionary<string, string>();

StripPattern();
StoreExpressions(pattern);
int patternC = 0;
int v = 0;

MatchExpression(v, inputLine, patternExpressions);

void MatchExpression(int v, string inputLine, List<Expressions> expressions)
{
    if (patternC >= patternExpressions.Count){
        StoreFoundMatches(expressions);
        if (v != inputLine.Length)
           patternC = 0; 
        else
            return;
    }

    if (v >= inputLine.Length)
    {
        StoreFoundMatches(expressions);
        return;
    }

    var ex = patternExpressions.Where(_ => _.Index == patternC).First();
    ex.Input = inputLine[v].ToString();
    ex.InvokeDelegate();
    patternExpressions[patternC] = ex;

    if (ex.Found.LastOrDefault() == "False"){
        if (startAnchor)
            return;
        if (ex.OneOrMore){
            v--;
            ex.OneOrMore = false;
            ex.Found.RemoveAt(ex.Found.Count - 1);
            patternExpressions[patternC] = ex;
            patternC++;
        }
        if (ex.ZeroOrMore){
            v--;
            ex.ZeroOrMore = false;
            ex.Found.RemoveAt(ex.Found.Count - 1);
            ex.Found.Add("True");
            patternExpressions[patternC] = ex;
            patternC++;
        }
        else
            patternC = 0;
    }else{
        if (ex.ZeroOrMore){
            ex.ZeroOrMore = false;
            patternExpressions[patternC] = ex;
        }
        if (!ex.OneOrMore)
            patternC++;
    }
    v++;

    MatchExpression(v, inputLine, expressions);
}

void StoreFoundMatches(List<Expressions> expressions)
{
    if (expressions.Any(_ => _.Found.Count == 0 && _.ZeroOrMore != true))
        return;
    
    
    var allMatched = expressions.Where(_ =>  _.ZeroOrMore != true)
        .Any(_ => _.Found.LastOrDefault().Contains("False"));

    if (!allMatched)
        foundMatches.Add(true);
}

bool CalculateFinalResult(List<Expressions> expressions)
{
    var checkNegCharacterGroups = expressions.Where(_ => _.PatternType.Equals(ExpressionTypes.NegativeCharacterClass))
        .Any(_ => _.Found.Contains("False"));

    if (checkNegCharacterGroups)
        return false;

    if (expressions.Any(_ => _.Found.Count == 0))
        return false;

    if (startAnchor)
        return !expressions.Any(_ => _.Found.FirstOrDefault().Contains("False"));

    if (endAnchor)
        return !expressions.Any(_ => _.Found.LastOrDefault().Contains("False"));

    var checkAllExpressions = foundMatches.Any(_ => _.Equals(true));

    return checkAllExpressions;
}

Console.WriteLine(CalculateFinalResult(patternExpressions));
Environment.Exit(0);

void StripPattern()
{
    if (pattern[pattern.Length - 1] == '$'){
        endAnchor = true;
        pattern = pattern.Substring(0, pattern.Length - 1);
    }

    if (pattern[0] == '^'){
        startAnchor = true;
        pattern = pattern.Substring(1);
    }
}

void StoreExpressions(string pattern)
{
    int expressionCount = 0;
    int i = 0;
    while (true)
    {
        if(pattern[i] == '\\' && pattern[i + 1] == 'd')
        {
            var ex = new Expressions(
                "\\d",
                expressionCount,
                ExpressionTypes.Digit);
 
            ex.setDelegate(char.IsDigit);
            i+=2;

            patternExpressions.Add(ex);
        }
        else if(pattern[i] == '\\' && pattern[i + 1] == 'w')
        {
            var ex = new Expressions(
                "\\d",
                expressionCount,
                ExpressionTypes.Word
                );

            ex.setDelegate(char.IsLetterOrDigit);
            i+=2;

            patternExpressions.Add(ex);
        }
        else if (pattern[i] == '[')
        {
            var ex = SetCharacterGroups(pattern, i, expressionCount);
            var searchPattern = pattern.Substring(i);
            i +=searchPattern.IndexOf(']') + 1;

            patternExpressions.Add(ex);
        }
        else if (pattern[i] == '+')
        {
            var ex = patternExpressions.LastOrDefault();
            ex.OneOrMore = true;

            patternExpressions[expressionCount - 1] = ex;
            i++;
            expressionCount--;
        }
        else if (pattern[i] == '?')
        {
            var ex = patternExpressions.LastOrDefault();
            ex.ZeroOrMore = true;

            patternExpressions[expressionCount - 1] = ex;
            i++;
            expressionCount--;
        }
        else{
            var ex = new Expressions(
                pattern[i].ToString(),
                expressionCount,
                ExpressionTypes.ExactMatch
            );

            ex.setDelegate((string p, string v) => p == v); 
            i++; 

            patternExpressions.Add(ex);
        }
        expressionCount++;
        if (i == pattern.Length)
            break;
    }
}

Expressions SetCharacterGroups(string pattern, int indexPatternIndex, int expressionCount)
{
    var exclusion = pattern[indexPatternIndex + 1] == '^';
    var searchPattern = pattern.Substring(indexPatternIndex);
    var sub = exclusion ? searchPattern.Substring(2, pattern.IndexOf(']') - 2) :
            searchPattern.Substring(1, pattern.IndexOf(']') - 1);

    if(exclusion){
        var ex = new Expressions(
            sub,
            expressionCount,
            ExpressionTypes.NegativeCharacterClass);

        ex.setDelegate((string inputChar, string characterClass) => !characterClass.Contains(inputChar));

        return ex;
    }
    else{
        var ex = new Expressions(
            sub,
            expressionCount,
            ExpressionTypes.PositiveCharacterClass);

        ex.setDelegate((string inputChar, string characterClass) => characterClass.Contains(inputChar));

        return ex;
    }
}

struct FoundMatches
{
    Expressions foundMatches;
}

struct Expressions
{
    public string Pattern;
    public int Index;
    public List<string> Found = new List<string>();
    public ExpressionTypes PatternType;
    public string Input;
    public Delegate Eng;
    public bool OneOrMore;
    public bool ZeroOrMore;
    
    public Expressions(
        string pattern,
        int index,
        ExpressionTypes patternName){
        Pattern = pattern;
        Index = index;
        PatternType = patternName;
    }

    public void setDelegate(Func<char,bool> t){
        Eng = t;
    }

    public void setDelegate(Func<string,string,bool> t){
        Eng = t;
    }

    public void InvokeDelegate()
    {
        switch (PatternType)
        {
            case ExpressionTypes.Digit:
                this.Found.Add(this.Eng.DynamicInvoke(this.Input[0]).ToString());
                break;
            case ExpressionTypes.Word: 
                this.Found.Add(this.Eng.DynamicInvoke(this.Input[0]).ToString());
                break;
            case ExpressionTypes.PositiveCharacterClass:
                this.Found.Add(this.Eng.DynamicInvoke(this.Input, this.Pattern).ToString());
                break;
            case ExpressionTypes.NegativeCharacterClass: 
                this.Found.Add(this.Eng.DynamicInvoke(this.Input, this.Pattern).ToString());
                break;
            default:
                this.Found.Add(this.Eng.DynamicInvoke(this.Pattern, this.Input).ToString());
                break;
        }
    }
}

enum ExpressionTypes
{
    Digit,
    Word,
    PositiveCharacterClass,
    NegativeCharacterClass,
    ExactMatch
}
*/