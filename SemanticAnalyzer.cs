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
        public override void OutAVariableOperand(AVariableOperand node)
        {

            Definition varDef;
            String varName = node.GetId().Text;
            
            //    check if variable was declared
            if (!_currentSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not defined.");

            //    check variable defined
            }
            else if (!(varDef is VariableDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not a valid variable.");

            //    decorate parse tree
            }
            else
            {
                _decoratedParseTree.Add(node, ((VariableDefinition)varDef).vartype);
            }
        }
        
        public override void OutAIntOperand(AIntOperand node)
        {
            // decorate this node
            BasicTypeDefinition intDef = new BasicTypeDefinition();
            intDef.name = "int";
            _decoratedParseTree.Add(node, intDef);
        }

        public override void OutAStrOperand(AStrOperand node)
        {
            // decorate this node
            BasicTypeDefinition intDef = new BasicTypeDefinition();
            intDef.name = "str";
            _decoratedParseTree.Add(node, intDef);
        }

        public override void OutAFltOperand(AFltOperand node)
        {
            // decorate this node
            BasicTypeDefinition intDef = new BasicTypeDefinition();
            intDef.name = "flt";
            _decoratedParseTree.Add(node, intDef);
        }

        //paren expr9
        //    check if node is decorated, if not decorate

        //pass expr9
        //    check if node is decorated, if not decorate

        //negation expr8
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
        public override void OutAPlusExpr6(APlusExpr6 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr6(), out lhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : left hand side of '+' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out rhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : right hand side of '+' was not decorated.");

            //    check if both sides are compat types
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

            //    check if both sides are valid mathematical types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

            //    decorate
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }


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
        public override void InAMain(AMain node)
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
        public override void OutAOrExpr1(AOrExpr1 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr1(), out lhs))
            {
                Console.WriteLine("[" + node.GetOr().Line + "] : left hand side of 'or' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr2(), out rhs))
            {
                Console.WriteLine("[" + node.GetOr().Line + "] : right hand side of 'or' was not decorated.");

                //    check if both sides are bool types
            }
            else if (!lhs.name.Equals("boolean") && !rhs.name.Equals("boolean"))
            {
                Console.WriteLine("[" + node.GetOr().Line + "] : Type mismatch.  Cannot or " + lhs.name + " to " +
                    rhs.name + " because one isnt a boolean.");

                //    decorate
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are booleans

        //pass expr1
        //    check if decorated, if not decorate

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
        public override void OutAFunctioncall(AFunctioncall node)
        {
            Definition idDef, exprDef;
            String funcName = node.GetId().Text;

            //    ensure id has been declared
            if (!_currentSymbolTable.TryGetValue(funcName, out idDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + funcName + " is not defined.");

            //    ensure id is a method
            }
            else if (!(idDef is MethodDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + funcName + " is not a method.");

            //    ensure argument is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetParams(), out exprDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : argument was not decorated.");

            // Ensure that expr is a string or basic type
            }
            else if (!(exprDef is StringTypeDefinition) || !(exprDef is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : language only allows strings and basic types as arguments.");
            }
        }

        //declarestmt
        public override void OutADeclarestmt(ADeclarestmt node)
        {
            Definition typeDef, varDef;
            String typeName = node.GetType().Text;
            String varName = node.GetVarname().Text;
            //    check type name is defined
            if (!_currentSymbolTable.TryGetValue(typeName, out typeDef))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not defined.");

            //    check if type name is defined as a type
            }
            else if (!(typeDef is TypeDefinition))
            {
                Console.WriteLine("[" + node.GetType().Line + "] : " + typeName + " is not a valid type.");

            //    check var name is not defined
            }
            else if (_currentSymbolTable.TryGetValue(varName, out varDef))
            {
                Console.WriteLine("[" + node.GetVarname().Line + "] : " + varName + " is already defined.");

            //    add to symbol table
            }
            else
            {
                VariableDefinition newDef = new VariableDefinition();
                newDef.name = varName;
                newDef.vartype = (TypeDefinition)typeDef;
                _currentSymbolTable.Add(varName, newDef);
            }
        }

        //already declared assignstmt
        public override void OutAAlreadydelaredAssignstmt(AAlreadydelaredAssignstmt node)
        {
            Definition idDef, exprDef;
            String varName = node.GetId().Text;

            //    ensure id was declared
            if (!_currentSymbolTable.TryGetValue(varName, out idDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not defined.");

            //    ensure id is a variable
            }
            else if (!(idDef is VariableDefinition))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : " + varName + " is not a valid variable.");

            //    ensure expr node is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr1(), out exprDef))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : right hand side was not decorated.");

            //    ensure expr and ID are same types
            }
            else if (!exprDef.name.Equals(((VariableDefinition)idDef).vartype.name))
            {
                Console.WriteLine("[" + node.GetId().Line + "] : Invalid assignment. Can not assign " + exprDef.name + " to " +
                    idDef.name + ".");
            }
        }

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
        public override void InAMethod(AMethod node)
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
        public override void OutAMethod(AMethod node)
        {
            //    restore previous symbol table
            _currentSymbolTable = _previousSymbolTables.First();
            _previousSymbolTables.RemoveFirst();

            Definition def;
            String methodName = node.GetId().Text;

            //    ensure submethod isnt used
            if (_currentSymbolTable.TryGetValue(methodName, out def))
            {
                Console.WriteLine("[" + node.GetOpenparen().Line + "] : " + methodName + " is already declared.");

            //    build function def and add to symbol table 
            }
            else
            {
                def = new MethodDefinition();
                def.name = node.GetId().Text;
                ((MethodDefinition)def).paramList = new List<VariableDefinition>();

                //    add a param list if allowed ****EDIT tHIS****
                ((MethodDefinition)def).paramList.Clear();

                _currentSymbolTable.Add(methodName, def);
            }
        }
        public override void CaseEOF(EOF node)
        {
            base.CaseEOF(node);
            Console.WriteLine("Semantic Analyzation complete.");
        }

        //constant
        //    check if type name is defined
        //    check if type name is defined as a type
        //    check var name is not defined
        //    add to global symbolTable

    }
}
