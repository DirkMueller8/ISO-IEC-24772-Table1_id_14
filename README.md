## Good Coding Principles acc. to ISO/IEC 24772-1:2024

### Standard ###  
**ISO/IEC 24772-1**  
Programming languages — Avoiding vulnerabilities in programming languages —
Part 1: Language-independent catalogue of vulnerabilities  

### Good Coding Recommendation  
"*Prohibit dependence on side effects of a term in the expression  itself*",   
in Table 1, Number 14, on p. 29.   

### Theory around the Example  
#### Assignments in Expressions  
- C# allows assignments in expressions because in C# an assignment is also an expression that yields the assigned value. The language defines the evaluation order, so expressions like `int x = (y = 3);` are well‑defined.  
- It’s acceptable when the assignment is the single side effect you need and it makes the code clearer -  common idioms are input/scan loops and condition checks (e.g.,   
`while ((line = reader.ReadLine()) != null)`).  
- It’s not ok when the same expression relies on multiple side effects or reads the same variable before and after the assignment in the same expression (that makes the code hard to read and error prone). 

### Explanation of Problematic and Good Code  
The Bad method shows problematic expressions that rely on side effects; the Good method shows the recommended refactoring: isolate side effects into separate statements and use temporaries.

#### Method Producing the Side Effect  
The expression `int result = i + (i = 10);` reads the same variable before and after the assignment in the same expression (that makes the code hard to read and error prone).

##### Safe alternative:  
A better construct is:  
```
int i = 1;
// Separate the read and the write so the expression no longer depends on an internal side effect.  
int left = i;  
i = 10; // isolate side effect  
int result = left + i;  
```