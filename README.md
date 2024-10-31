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

run: ** echo -n {input string} | dotnet run -E {expression} **
i.e:
```
echo -n "apple" | dotnet run -E "a"
```
# Expressions catered for (WIP)

1. Matching literal character <br/>
```
echo -n "apple" | ./your_program.sh -E "a"
```
2.  Matching Digits <br/>
```
echo -n "apple123" | ./your_program.sh -E "\\d"
```
3. Match alphanumeric characters <br/>
```
echo -n "alpha-num3ric" | ./your_program.sh -E "\\w"
```

4. Positive character groups <br/>
```
echo -n "apple" | ./your_program.sh -E "[abc]"
```

5. Negative character groups <br/>
```
echo -n "apple" | ./your_program.sh -E "[^abc]"
```

6. Combining Character Classes <br/>
```
echo -n "1 apple" | ./your_program.sh -E "\d apple"
```

7. Start of string anchor <br/>
```
echo -n "log" | ./your_program.sh -E "^log"
```

8. End of string character <br/>
```
echo -n "dog" | ./your_program.sh -E "dog$"
```

9. Match one or more times (WIP, not catered for) <br/>
```
echo -n "caats" | ./your_program.sh -E "ca+ts"
```

10.  Match Zero or one times (WIP, not catered for) <br/>
```
echo -n "dogs" | ./your_program.sh -E "dogs?"
```

11. Wildcard (WIP, not catered for) <br/>
```
echo -n "dog" | ./your_program.sh -E "d.g"
```

12.  Alternation (WIP, not catered for) <br/>
```
echo -n "cat" | ./your_program.sh -E "(cat|dog)"
```
