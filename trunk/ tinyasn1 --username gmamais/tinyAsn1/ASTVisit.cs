using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    public interface IASTVisitor
    {
        bool Finished();

        int PassNo { get;}

        void OnBeforeAsn1File(Asn1File asn1File);
        void OnAfterAsn1File(Asn1File asn1File);
        void OnBeforeModule(Asn1File asn1File, Module mod);
        void OnAfterModule(Asn1File asn1File, Module mod);
        void OnBeforeTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas);

        void OnValueAssigment(Asn1File asn1File, Module mod, ValueAssigment vas);

        void OnAfterTypeAssigment(Asn1File asn1File, Module mod, TypeAssigment tas);
        void OnNullType(Asn1File asn1File, Module mod, NullType nullType, TypeAssigment tas);
        void OnBitStringType(Asn1File asn1File, Module mod, BitStringType bsType, TypeAssigment tas);
        void OnBooleanType(Asn1File asn1File, Module mod, BooleanType boolType, TypeAssigment tas);
        void OnRealType(Asn1File asn1File, Module mod, RealType realType, TypeAssigment tas);
        void OnEnumeratedType(Asn1File asn1File, Module mod, EnumeratedType enumType, TypeAssigment tas);
        void OnIntegerType(Asn1File asn1File, Module mod, IntegerType intType, TypeAssigment tas);
        void OnChoiceType(Asn1File asn1File, Module mod, ChoiceType choiceType, TypeAssigment tas);
        void OnSequenceType(Asn1File asn1File, Module mod, SequenceType seqType, TypeAssigment tas);
        void OnSetType(Asn1File asn1File, Module mod, SetType setType, TypeAssigment tas);
        void OnSequenceOfType(Asn1File asn1File, Module mod, SequenceOfType sqOfType, TypeAssigment tas);
        void OnSetOfType(Asn1File asn1File, Module mod, SetOfType setOfType, TypeAssigment tas);
        void OnOctectStringType(Asn1File asn1File, Module mod, OctetStringType osType, TypeAssigment tas);
        void OnReferenceType(Asn1File asn1File, Module mod, ReferenceType refType, TypeAssigment tas);
    
    }


    public delegate void OnAntrlNode(ITree root);

    public class AntlrTreeVisitor
    {
        public void visit(ITree root, int tokenID, OnAntrlNode callBack)
        {
            if (root.Type == tokenID)
                callBack(root);
            for (int i = 0; i < root.ChildCount; i++)
                visit(root.GetChild(i), tokenID, callBack);
        }

        public void visit(ITree root, IList<int> tokenIDs, OnAntrlNode callBack)
        {
            if (tokenIDs.Contains(root.Type))
                callBack(root);
            for (int i = 0; i < root.ChildCount; i++)
                visit(root.GetChild(i), tokenIDs, callBack);
        }

        public void visitIfNot(ITree root, IEnumerable<int> TokenIDs, OnAntrlNode callBack, IEnumerable<int> StopList)
        {
            List<int> tokenIDs = new List<int>(TokenIDs);
            List<int> stopList = new List<int>(StopList);
            if (!tokenIDs.Contains(root.Type))
                callBack(root);
            if (stopList.Contains(root.Type))
                return;
            for (int i = 0; i < root.ChildCount; i++)
                visitIfNot(root.GetChild(i), tokenIDs, callBack, StopList);
        }
    }


    public partial class Asn1CompilerInvokation
    {
        public void Visit(IASTVisitor visitor)
        {
            do
            {
                for (int i = 0; i < m_files.Count; i++)
                    m_files[i].Visit(visitor);
            } while (!visitor.Finished() && visitor.PassNo < 50);
            Console.Error.WriteLine("Semantic parsing passes : " + visitor.PassNo.ToString());
        }
    }


    public partial class Asn1File
    {
        public void Visit(IASTVisitor visitor)
        {
            visitor.OnBeforeAsn1File(this);

            foreach (Module m in m_modules)
                m.Visit(visitor, this);

            visitor.OnAfterAsn1File(this);
        }
    }

    public partial class Module
    {
        public void Visit(IASTVisitor visitor, Asn1File asn1File)
        {
            visitor.OnBeforeModule(asn1File, this);

            foreach (TypeAssigment t in m_typeAssigments.Values)
                t.Visit(visitor,asn1File,this);

            foreach (ValueAssigment v in m_valuesAssigments.Values)
                v.Visit(visitor, asn1File, this);

            visitor.OnAfterModule(asn1File, this);
        }
    }


    public partial class ValueAssigment
    {
        public void Visit(IASTVisitor visitor, Asn1File asn1File, Module mod)
        {
            visitor.OnValueAssigment(asn1File, mod, this);
        }
    }


    public partial class TypeAssigment
    {
        public void Visit(IASTVisitor visitor, Asn1File asn1File, Module mod)
        {
            visitor.OnBeforeTypeAssigment(asn1File, mod, this);

            m_type.visit(visitor, asn1File, mod,this);

            visitor.OnAfterTypeAssigment(asn1File, mod, this);
        }
    }

    public partial class Asn1Type
    {
        public virtual void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
        }
    }


    public partial class NullType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnNullType(asn1File, mod, this, tas);
        }
    }

    public partial class BitStringType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnBitStringType(asn1File, mod, this, tas);
        }
    }

    public partial class BooleanType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnBooleanType(asn1File, mod, this, tas);
        }
    }

    public partial class RealType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnRealType(asn1File, mod, this, tas);
        }
    }


    public partial class EnumeratedType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnEnumeratedType(asn1File, mod, this, tas);
        }
    }
    
    public partial class IntegerType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnIntegerType(asn1File, mod, this, tas);
        }
    }

    public partial class ChoiceType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnChoiceType(asn1File, mod, this, tas);
        }
    }

    public partial class SequenceType : SequenceOrSetType
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnSequenceType(asn1File, mod, this, tas);
        }
    }

    public partial class SetType : SequenceOrSetType
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnSetType(asn1File, mod, this, tas);
        }
    }

    public partial class SequenceOfType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnSequenceOfType(asn1File, mod, this, tas);            
        }
    }

    public partial class SetOfType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnSetOfType(asn1File, mod, this, tas);
        }
    }

    public partial class OctetStringType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnOctectStringType(asn1File, mod, this, tas);
        }
    }

    public partial class ReferenceType : Asn1Type
    {
        public override void visit(IASTVisitor visitor, Asn1File asn1File, Module mod, TypeAssigment tas)
        {
            visitor.OnReferenceType(asn1File, mod, this, tas);
        }
    }
}
