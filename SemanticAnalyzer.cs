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
        public override void OutAParenExpr9(AParenExpr9 node)
        {
            Definition expr1Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr1(), out expr1Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr1Def);
            }
        }

        //pass expr9
        public override void OutAPassExpr9(APassExpr9 node)
        {
            Definition operandDef;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetOperand(), out operandDef))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, operandDef);
            }
        }
        //    check if node is decorated, if not decorate

        //neation expr8
        //    check if expr8 is a number
        //    decorate

        //not expr8
        //    check if decorated, if no decorate


        //pass expr8
        public override void OutAPassExpr8(APassExpr8 node)
        {
            Definition expr9Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr9(), out expr9Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr9Def);
            }
        }


        //mult expr7
        public override void OutAMultExpr7(AMultExpr7 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out lhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : left hand side of '+' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out rhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : right hand side of '+' was not decorated.");

                //    check if both sides are compat types
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

                //    check if both sides are valid mathematical types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

                //    decorate
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //division expr7
        public override void OutADivisionExpr7(ADivisionExpr7 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out lhs))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : left hand side of '+' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out rhs))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : right hand side of '+' was not decorated.");

                //    check if both sides are compat types
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

                //    check if both sides are valid mathematical types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

                //    decorate
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //pass expr7
        public override void OutAPassExpr7(APassExpr7 node)
        {
            Definition expr8Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out expr8Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr8Def);
            }
        }

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
        public override void OutASubtractExpr6(ASubtractExpr6 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr6(), out lhs))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : left hand side of '+' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out rhs))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : right hand side of '+' was not decorated.");

                //    check if both sides are compat types
            }
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

                //    check if both sides are valid mathematical types
            }
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

                //    decorate
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = lhs.name;
                _decoratedParseTree.Add(node, currNodeType);
            }
        }


        //pass expr6
        //    check if decorated, if no decorate
        public override void OutAPassExpr6(APassExpr6 node)
        {
            Definition expr7Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out expr7Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr7Def);
            }
        }

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

        //pass expr5
        public override void OutAPassExpr5(APassExpr5 node)
        {
            Definition expr6Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr6(), out expr6Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr6Def);
            }
        }

        //equal expr4
        //    check if both sides are decorate
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //not equal expr4
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both are valid mathematical types

        //pass expr4
        public override void OutAPassExpr4(APassExpr4 node)
        {
            Definition expr5Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr5(), out expr5Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr5Def);
            }
        }

        //and expr2
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are booleans


        //pass expr2
        public override void OutAPassExpr2(APassExpr2 node)
        {
            Definition expr4Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr4(), out expr4Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr4Def);
            }
        }

        //or expr1
        //    check if both sides are decorated
        //    check if both sides are compat types
        //    check if both sides are booleans

        //pass expr1
        public override void OutAPassExpr1(APassExpr1 node)
        {
            Definition expr2Def;

            //    check if decorated, if no decorate
            if (!_decoratedParseTree.TryGetValue(node.GetExpr2(), out expr2Def))
            {

            }
            else
            {
                _decoratedParseTree.Add(node, expr2Def);
            }
        }

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
        
        
        
        

        //constant
        //    check if type name is defined
        //    check if type name is defined as a type
        //    check var name is not defined
        //    add to global symbolTable

    }
}


//  Start -> id + start;