using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyLanguage.node;

namespace ToyLanguage.analysis
{
    class SemanticAnalyzer : DepthFirstAdapter
    {
        // Symbol Tables
        LinkedList<Dictionary<string, Definition>> _previousSymbolTables = new LinkedList<Dictionary<string, Definition>>();
        Dictionary<string, Definition> _currentSymbolTable = new Dictionary<string, Definition>();

        // ParseTree Decoration
        Dictionary<Node, Definition> _decoratedParseTree = new Dictionary<Node, Definition>();

        //For variableOperand
        //    check if variable was declared
        //    check variable defined
        //    decorate parse tree

        //paren expr9
        //    check if node is decorated, if not decorate

        //pass expr9
        //    check if node is decorated, if not decorate

        //neation expr8
        //    check if expr8 is a number
        //    decorate

        //not expr8
        //    check if decorated, if no decorate


        //pass expr8
        //    check if decorated, if no decorate


        //mult expr7
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are valid mathematical types
        //    decorate

        //division expr7
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are valid mathematical types
        //    check if divisor is 0
        //    decorate

        //pass expr7
        //    check if decorated, if no decorate

        //plus expr6
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are valid mathematical types
        //    decorate


        //subtract expr6
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are valid mathematical types
        //    decorate

        //pass expr6
        //    check if decorated, if no decorate

        //lassthan expr5
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //lessthan or equal to
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //greaterthatn expr5
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //greaterthan or equal to
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //equal expr4
        //    check if both sides are decorate
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //not equal expr4
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //pass expr4
        //    check if decorated, if not decorate

        //and expr2
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are booleans

        //main
        public override void InAMain(AMainmethod node)
        {
            //    build def for allowed types
            BasicTypeDefinition intType;
            intType = new BasicTypeDefinition();
            intType.name = "int";

            BasicTypeDefinition fltType;
            fltType = new BasicTypeDefinition();
            fltType.name = "float";

            BasicTypeDefinition boolType;
            boolType = new BasicTypeDefinition();
            boolType.name = "boolean";

            StringTypeDefinition stringType = new StringTypeDefinition();
            stringType.name = "string";

            //    create and seed symbol tables
            _currentSymbolTable = new Dictionary<string, Definition>();
            _currentSymbolTable.Add("int", intType);
            _currentSymbolTable.Add("float", fltType);
            _currentSymbolTable.Add("boolean", boolType);
            _currentSymbolTable.Add("string", stringType);
        }


        //pass expr2
        //    check if decorated, if not decorate

        //or expr1
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are booleans

        //pass expr1
        //    check if decorated, if not decorate

        //main
        //    build definitions for allowed types
        //    create and seed symbolTable

        //whilestmt
        //    check if expr1 is boolean
        //    check if stmts is decorated

        //else
        //    check if decorated, if not decorate

        //ifstmt
        //    check if expr1 is boolean
        //    cehck if stmts is decorated

        //param
        //    check if decorated, if not decorate

        //params 
        //    check if decorated, if not decorate

        //functioncall
        //    ensure id has been declared
        //    ensure id is a method
        //    ensure argument is decorated
        //    ensure argument is declared properly
        //    ensure argument is not delared twice
        //    ensure expr is decorated and proper params

        //declarestmt
        //    check type name is defined
        //    check if type name is defined as a type
        //    check var name is not defined
        //    add to symbol table

        //already declared assignstmt
        //    ensure id was declared
        //    ensure id is a variable
        //    ensure expr node is decorated
        //    ensure expr and ID are same types

        //declaring assignment
        //    check type name is defined
        //    check if type name is defined as a type
        //    check var name is not define
        //    add to symbol table
        //    ensure id is a variable
        //    ensure expr node is decorated
        //    ensure expr and ID are same types

        //parameter
        //    check if decorated, if not decorate

        //parameters
        //    check if decorated, if not decorate

        //in method
        public override void InAMethod(AOneSubmethod node)
        {
            //    save current symbol table
            _previousSymbolTables.AddFirst(_currentSymbolTable);

            //    build def allowed by types according to grammar
            BasicTypeDefinition intType;
            intType = new BasicTypeDefinition();
            intType.name = "int";

            BasicTypeDefinition fltType;
            fltType = new BasicTypeDefinition();
            fltType.name = "float";

            BasicTypeDefinition boolType;
            boolType = new BasicTypeDefinition();
            boolType.name = "boolean";

            StringTypeDefinition stringType = new StringTypeDefinition();
            stringType.name = "string";

            //    create and seed symbol table
            _currentSymbolTable = new Dictionary<string, Definition>();
            _currentSymbolTable.Add("int", intType);
            _currentSymbolTable.Add("float", fltType);
            _currentSymbolTable.Add("boolean", boolType);
            _currentSymbolTable.Add("string", stringType);


        }
            //out mehtod
            //    restore previous symbol table
            //    ensure submethod isnt used
            //    build function def and add to symbol table
            //    add a param list if allowed

            //constant
            //    check if type name is defined
            //    check if type name is defined as a type
            //    check var name is not defined
            //    add to global symbolTable

        }
}


//  Start -> id + start;