# Regex clone

An implementation of certain regular expressions in c#.

# Running this program

[dotnet 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) needs to be installed. <br/>
**To build solution:**
```
dotnet build in root directory
```
**To run solution:**

navigate to src/regexpressions

run: <br/>
**echo -n {input string} | dotnet run -E {expression}** <br/>
i.e:
```
echo -n "apple" | dotnet run -E "a"
```
# Expressions catered for (WIP)

1. Matching literal character <br/>
```
echo -n "apple" | dotnet run -E "a"
```
2.  Matching Digits <br/>
```
echo -n "apple123" | dotnet run -E "\d"
```
3. Match alphanumeric characters <br/>
```
echo -n "alpha-num3ric" | dotnet run -E "\w"
```

4. Positive character groups <br/>
```
echo -n "apple" | dotnet run -E "[abc]"
```

5. Negative character groups <br/>
```
echo -n "apple" | dotnet run -E "[^abc]"
```

6. Combining Character Classes <br/>
```
echo -n "1 apple" | dotnet run -E "\d apple"
```

7. Start of string anchor <br/>
```
echo -n "log" | dotnet run -E "^log"
```

8. End of string character (WIP, not catered for) <br/>
```
echo -n "dog" | dotnet run -E "dog$"
```

9. Match one or more times (WIP, not catered for) <br/>
```
echo -n "caats" | dotnet run -E "ca+ts"
```

10.  Match Zero or one times (WIP, not catered for) <br/>
```
echo -n "dogs" | dotnet run -E "dogs?"
```

11. Wildcard (WIP, not catered for) <br/>
```
echo -n "dog" | dotnet run -E "d.g"
```

12.  Alternation (WIP, not catered for) <br/>
```
echo -n "cat" | ./your_program.sh -E "(cat|dog)"
```
