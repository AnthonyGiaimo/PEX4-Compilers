:::::::::::::::::::::::::::::
:: This is the LEXDRIVER it runs the test cases for the toy language from CS426
::
:: use double :'s for a line comment
:: use > to create and redirect output to a file
:: use >> to append output to a file
:::::::::::::::::::::::::::::

:: Run good test cases
echo Andrew Christensen's 426 Parser for ToyLanguage > results.txt
echo Running Correct Test Cases >> Results.txt
echo. >> results.txt

:: Fill in your test cases here

echo ----------------------------------- >> results.txt

echo '- fail when types aren’t integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\- fail when types aren’t integer or float.txt' >> results.txt
echo. >> results.txt


echo '- fail when types don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\- fail when types don’t match.txt' >> results.txt
echo. >> results.txt

echo '+ fail when types aren’t integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\+ fail when types aren’t integer or float.txt' >> results.txt
echo. >> results.txt

echo '+ fail when types don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\+ fail when types don’t match.txt' >> results.txt
echo. >> results.txt

echo 'and fails when type doesnt match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\and fails when type doesnt match.txt' >> results.txt
echo. >> results.txt

echo 'and fails when types not boolean' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\and fails when types not boolean.txt' >> results.txt
echo. >> results.txt

echo 'Assignment - x=y fails when x is declared, but not a variable' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Assignment - x=y fails when x is declared, but not a variable.txt' >> results.txt
echo. >> results.txt

echo 'Assignment - x=y fails when x is not declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Assignment - x=y fails when x is not declared.txt' >> results.txt
echo. >> results.txt

echo 'Assignment x=y fails when types don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Assignment x=y fails when types don’t match.txt' >> results.txt
echo. >> results.txt

echo 'Assignment x=y fails when x is constant' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Assignment x=y fails when x is constant.txt' >> results.txt
echo. >> results.txt

echo 'div fail when types aren’t integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\div fail when types aren’t integer or float.txt' >> results.txt
echo. >> results.txt

echo 'div fail when types don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\div fail when types don’t match.txt' >> results.txt
echo. >> results.txt

echo 'equal fails when types dont match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\equal fails when types dont match.txt' >> results.txt
echo. >> results.txt

echo 'equals fails when types arent integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\equals fails when types arent integer or float.txt' >> results.txt
echo. >> results.txt

echo 'Expressions - fails if type name used instead of variable name' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Expressions - fails if type name used instead of variable name.txt' >> results.txt
echo. >> results.txt

echo 'Expressions - fails if undeclared variable used' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Expressions - fails if undeclared variable used.txt' >> results.txt
echo. >> results.txt

echo 'final y x=z; - fails if types of y, z don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\final y x=z; - fails if types of y, z don’t match.txt' >> results.txt
echo. >> results.txt

echo 'final y x=z; - fails if x already declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\final y x=z; - fails if x already declared.txt' >> results.txt
echo. >> results.txt

echo 'final y x=z; - fails if y is declared, but not a type' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\final y x=z; - fails if y is declared, but not a type.txt' >> results.txt
echo. >> results.txt

echo 'final y x=z; - fails if y is not declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\final y x=z; - fails if y is not declared.txt' >> results.txt
echo. >> results.txt

echo 'greater than fails when types arent integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\greater than fails when types arent integer or float.txt' >> results.txt
echo. >> results.txt

echo 'greater than fails when types dont match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\greater than fails when types dont match.txt' >> results.txt
echo. >> results.txt

echo 'greater than or equal to fails when types arent integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\greater than or equal to fails when types arent integer or float.txt' >> results.txt
echo. >> results.txt

echo 'greater than or equal to fails when types dont match - Copy' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\greater than or equal to fails when types dont match - Copy.txt' >> results.txt
echo. >> results.txt

echo 'if (Expr)… - fails if Expr is not Boolean' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\if (Expr)… - fails if Expr is not Boolean.txt' >> results.txt
echo. >> results.txt

echo 'less than fails when types arent integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\less than fails when types arent integer or float.txt' >> results.txt
echo. >> results.txt

echo 'less than fails when types dont match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\less than fails when types dont match.txt' >> results.txt
echo. >> results.txt

echo 'less than or equal to fails when types arent integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\less than or equal to fails when types arent integer or float.txt' >> results.txt
echo. >> results.txt

echo 'less than or equal to fails when types dont match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\less than or equal to fails when types dont match.txt' >> results.txt
echo. >> results.txt

echo 'mult fail when types aren’t integer or float' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\mult fail when types aren’t integer or float.txt' >> results.txt
echo. >> results.txt

echo 'mult fail when types don’t match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\mult fail when types don’t match.txt' >> results.txt
echo. >> results.txt

echo 'not fails when types not boolean' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\not fails when types not boolean.txt' >> results.txt
echo. >> results.txt

echo 'or fails when type doesnt match' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\or fails when type doesnt match.txt' >> results.txt
echo. >> results.txt

echo 'or fails when types not boolean' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\or fails when types not boolean.txt' >> results.txt
echo. >> results.txt

echo 'Procedures reports failure when formal parameter declared incorrectly (e.g. x x)' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Procedures reports failure when formal parameter declared incorrectly (e.g. x x).txt' >> results.txt
echo. >> results.txt

echo 'Procedures reports failure when formal parameter declared twice (e.g. int x, int x)' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Procedures reports failure when formal parameter declared twice (e.g. int x, int x).txt' >> results.txt
echo. >> results.txt

echo 'Procedures reports failure when procedure name already used' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\Procedures reports failure when procedure name already used.txt' >> results.txt
echo. >> results.txt

echo 'while (Expr) … - fails if Expr is not Boolean' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\while (Expr) … - fails if Expr is not Boolean.txt' >> results.txt
echo. >> results.txt

echo 'x(y,z)  reports failure when types of y,z don’t match formal parameters' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\x(y,z)  reports failure when types of y,z don’t match formal parameters.txt' >> results.txt
echo. >> results.txt

echo 'x(y,z)  reports failure when x is declared, but not a procedure' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\x(y,z)  reports failure when x is declared, but not a procedure.txt' >> results.txt
echo. >> results.txt

echo 'x(y,z)  reports failure when x is not declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\x(y,z)  reports failure when x is not declared.txt' >> results.txt
echo. >> results.txt

echo 'x(y,z)  reports failure when x is not declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\x(y,z)  reports failure when x is not declared.txt' >> results.txt
echo. >> results.txt

echo 'y x; - fails if x is already declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\y x; - fails if x is already declared.txt' >> results.txt
echo. >> results.txt

echo 'y x; - fails if y is not declared' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\y x; - fails if y is not declared.txt' >> results.txt
echo. >> results.txt

echo 'y x; - fails of y is declared, but not a type' >> results.txt
bin\Debug\ConsoleApplication.exe 'tests\FailCasesSemanticAnalyzer\y x; - fails of y is declared, but not a type.txt' >> results.txt
echo. >> results.txt