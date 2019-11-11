using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToyLanguage
{
    public abstract class Definition
    {
        public string name;
    }
    public abstract class TypeDefinition : Definition
    {
    }
    public class IntTypeDefinition : TypeDefinition
    {
    }
    public class FloatTypeDefinition : TypeDefinition
    {
    }
    public class StringTypeDefinition : TypeDefinition
    {
    }
    public class VariableDefinition : Definition
    {
        public TypeDefinition vartype;
    }
    public class MethodDefinition : Definition
    {
        public List<VariableDefinition> paramList;

    }
}
