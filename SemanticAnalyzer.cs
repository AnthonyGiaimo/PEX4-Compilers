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

        //negation expr8
        public override void OutANegationExpr8(ANegationExpr8 node)
        {
            Definition expr8Def;

            if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out expr8Def))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : expr8 was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(expr8Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : Invalid Type.  Cannot negate " + expr8Def.name + "s.");

                //    decorate
            }
        }

        //not expr8
        public override void OutANotExpr8(ANotExpr8 node)
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
            // Ensure rhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out lhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : left hand side of 'x' was not decorated.");
 
            }
            //    check if both sides are compat types
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out rhs))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : right hand side of 'x' was not decorated.");
   
            }
            // Check if both types are equal
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Type mismatch.  Cannot multiply " + lhs.name + " to " +
                    rhs.name + ".");

            }
            //  Check if the left hand type is valid
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetMult().Line + "] : Invalid Type.  Cannot multiply " + lhs.name + "s.");

            }
            //    decorate
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
            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out lhs))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : left hand side of '/' was not decorated.");

            }
            // Ensure rhs of the plus is decorated
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr8(), out rhs))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : right hand side of '/' was not decorated.");
 
            }
            //    check if both sides are equal types
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : Type mismatch.  Cannot divide " + lhs.name + " to " +
                    rhs.name + ".");

                
            }
            //    check if left side is a valid type
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetDivision().Line + "] : Invalid Type.  Cannot divide " + lhs.name + "s.");

            }
            //    decorate
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
            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr6(), out lhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : left hand side of '+' was not decorated.");

            }
            // Ensure rhs of the plus is decorated
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out rhs))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : right hand side of '+' was not decorated.");

            }
            //    check if both sides equal types
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Type mismatch.  Cannot add " + lhs.name + " to " +
                    rhs.name + ".");

            }
            //    check if left side is a valid type
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetPlus().Line + "] : Invalid Type.  Cannot add " + lhs.name + "s.");

            }
            //    decorate
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
            // Ensure lhs of the plus is decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr6(), out lhs))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : left hand side of '-' was not decorated.");

            }
            // Ensure rhs of the plus is decorated
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr7(), out rhs))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : right hand side of '-' was not decorated.");

            }
            //    check if both sides are equal types
            else if (!lhs.name.Equals(rhs.name))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : Type mismatch.  Cannot subtract " + lhs.name + " to " +
                    rhs.name + ".");

            }
            //    check if left hand type is valid
            else if (!(lhs is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetNegative().Line + "] : Invalid Type.  Cannot subtract " + lhs.name + "s.");
 
            }
            //    decorate
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

        //lessthan expr5
        public override void OutALessthanExpr5(ALessthanExpr5 node)
        {
            Definition leftExpr6Def, rightExpr6Def;

            if (!_decoratedParseTree.TryGetValue(node.GetLeft(), out leftExpr6Def))
            {
                Console.WriteLine("[" + node.GetLessthan().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetRight(), out rightExpr6Def))
            {
                Console.WriteLine("[" + node.GetLessthan().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr6Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetLessthan().Line + "] : Invalid Type.  Cannot add " + leftExpr6Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr6Def.name.Equals(rightExpr6Def.name))
            {
                Console.WriteLine("[" + node.GetLessthan().Line + "] : Type mismatch.  Cannot add " + leftExpr6Def.name + " to " +
                    rightExpr6Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //lessthan or equal to
        public override void OutALessthanorequaltoExpr5(ALessthanorequaltoExpr5 node)
        {
            Definition leftExpr6Def, rightExpr6Def;

            if (!_decoratedParseTree.TryGetValue(node.GetLeft(), out leftExpr6Def))
            {
                Console.WriteLine("[" + node.GetLessthanorequalto().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetRight(), out rightExpr6Def))
            {
                Console.WriteLine("[" + node.GetLessthanorequalto().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr6Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetLessthanorequalto().Line + "] : Invalid Type.  Cannot add " + leftExpr6Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr6Def.name.Equals(rightExpr6Def.name))
            {
                Console.WriteLine("[" + node.GetLessthanorequalto().Line + "] : Type mismatch.  Cannot add " + leftExpr6Def.name + " to " +
                    rightExpr6Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

        //greaterthan expr5
        public override void OutAGreaterthanExpr5(AGreaterthanExpr5 node)
        {
            Definition leftExpr6Def, rightExpr6Def;

            if (!_decoratedParseTree.TryGetValue(node.GetLeft(), out leftExpr6Def))
            {
                Console.WriteLine("[" + node.GetGreaterthan().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetRight(), out rightExpr6Def))
            {
                Console.WriteLine("[" + node.GetGreaterthan().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr6Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetGreaterthan().Line + "] : Invalid Type.  Cannot add " + leftExpr6Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr6Def.name.Equals(rightExpr6Def.name))
            {
                Console.WriteLine("[" + node.GetGreaterthan().Line + "] : Type mismatch.  Cannot add " + leftExpr6Def.name + " to " +
                    rightExpr6Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }


        //greaterthan or equal to
        public override void OutAGreaterthanorequaltoExpr5(AGreaterthanorequaltoExpr5 node)
        {
            Definition leftExpr6Def, rightExpr6Def;

            if (!_decoratedParseTree.TryGetValue(node.GetLeft(), out leftExpr6Def))
            {
                Console.WriteLine("[" + node.GetGreaterthanorequalto().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetRight(), out rightExpr6Def))
            {
                Console.WriteLine("[" + node.GetGreaterthanorequalto().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr6Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetGreaterthanorequalto().Line + "] : Invalid Type.  Cannot add " + leftExpr6Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr6Def.name.Equals(rightExpr6Def.name))
            {
                Console.WriteLine("[" + node.GetGreaterthanorequalto().Line + "] : Type mismatch.  Cannot add " + leftExpr6Def.name + " to " +
                    rightExpr6Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }

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
        public override void OutAEqualExpr4(AEqualExpr4 node)
        {
            Definition leftExpr4Def, rightExpr5Def;

            if (!_decoratedParseTree.TryGetValue(node.GetExpr4(), out leftExpr4Def))
            {
                Console.WriteLine("[" + node.GetEqualityoperator().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr5(), out rightExpr5Def))
            {
                Console.WriteLine("[" + node.GetEqualityoperator().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr4Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetEqualityoperator().Line + "] : Invalid Type.  Cannot add " + leftExpr4Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr4Def.name.Equals(rightExpr5Def.name))
            {
                Console.WriteLine("[" + node.GetEqualityoperator().Line + "] : Type mismatch.  Cannot add " + leftExpr4Def.name + " to " +
                    rightExpr5Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }


        //not equal expr4
        public override void OutANotequalExpr4(ANotequalExpr4 node)
        {
            Definition leftExpr4Def, rightExpr5Def;

            if (!_decoratedParseTree.TryGetValue(node.GetExpr4(), out leftExpr4Def))
            {
                Console.WriteLine("[" + node.GetNot().Line + node.GetEqualityoperator().Line + "] : left side was not decorated.");

                // Ensure lhs of the plus is decorated
            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr5(), out rightExpr5Def))
            {
                Console.WriteLine("[" + node.GetNot().Line + node.GetEqualityoperator().Line + "] : right side was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(leftExpr4Def is BasicTypeDefinition))
            {
                Console.WriteLine("[" + node.GetNot().Line + node.GetEqualityoperator().Line + "] : Invalid Type.  Cannot add " + leftExpr4Def.name + "s.");

                // Check if the left hand side is a valid type
            }
            else if (!leftExpr4Def.name.Equals(rightExpr5Def.name))
            {
                Console.WriteLine("[" + node.GetNot().Line + node.GetEqualityoperator().Line + "] : Type mismatch.  Cannot add " + leftExpr4Def.name + " to " +
                    rightExpr5Def.name + ".");

                // Check if types are equal
            }
            else
            {
                TypeDefinition currNodeType = new BasicTypeDefinition();
                currNodeType.name = "boolean";
                _decoratedParseTree.Add(node, currNodeType);
            }
        }


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
        public override void OutAAndExpr2(AAndExpr2 node)
        {
            Definition lhs, rhs;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr2(), out lhs))
            {
                Console.WriteLine("[" + node.GetAnd().Line + "] : left hand side of 'and' was not decorated.");

            }
            else if (!_decoratedParseTree.TryGetValue(node.GetExpr4(), out rhs))
            {
                Console.WriteLine("[" + node.GetAnd().Line + "] : right hand side of 'and' was not decorated.");

            //    check if both sides are bool types
            }
            else if (!lhs.name.Equals("boolean") && !rhs.name.Equals("boolean"))
            {
                Console.WriteLine("[" + node.GetAnd().Line + "] : Type mismatch.  Cannot or " + lhs.name + " to " +
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

        //whilestmt
        public override void InAWhilestmt(AWhilestmt node)
        {
            Definition expr1Def;

            //    check if both sides are decorated
            if (!_decoratedParseTree.TryGetValue(node.GetExpr1(), out expr1Def))
            {
                Console.WriteLine("[" + node.GetClosedparen().Line + "] : left hand side of 'or' was not decorated.");

                // Ensure rhs of the plus is decorated
            }
            else if (!(expr1Def.name.Equals("boolean")))
            {
                Console.WriteLine("[" + node.GetClosedparen().Line + "] : Type mismatch." + expr1Def.name + " isnt a boolean.");
            }
        }

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
