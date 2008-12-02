/**=============================================================================
Definition of utility classes
in autoICD and asn1scc projects  
================================================================================
Copyright(c) Semantix Information Technologies S.A www.semantix.gr
All rights reserved.

This source code is only intended as a supplement to the
Semantix Technical Reference and related electronic documentation 
provided with the autoICD and asn1scc applications.
See these sources for detailed information regarding the
asn1scc and autoICD applications.
==============================================================================*/
using System;
using System.Collections.Generic;
using System.IO;
using Antlr.Runtime.Tree;
using semantix.util;

namespace tinyAsn1
{


    public class SemanticTreeNode : ITree /* util class, no need to be abstract*/
    {
        List<ITree> children = new List<ITree>();

        public void AddChild(ITree t)
        {
            children.Add(t);
        }

        int m_CharPositionInLine;
        public int CharPositionInLine
        {
            get { return m_CharPositionInLine; }
        }

        public int ChildCount
        {
            get { return children.Count; }
        }

        public ITree DupNode()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ITree DupTree()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public ITree GetChild(int i)
        {
            return children[i];
        }

        public bool IsNil
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int m_line;
        public int Line
        {
            get { return m_line; }
        }

        string m_text;
        public string Text
        {
            get { return m_text; }
        }

        public string ToStringTree()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int TokenStartIndex
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int TokenStopIndex
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int m_type;
        public int Type
        {
            get { return m_type; }
        }

        public SemanticTreeNode(int charPositionInLine, int line, string text, int type)
        {
            m_CharPositionInLine = charPositionInLine;
            m_line = line;
            m_text = text;
            m_type = type;
        }
    }

    public static class Config
    {
        private static int m_integerSize = 8;
        public static int IntegerSize 
        { 
            get { return m_integerSize; }
            set
            {
                if (value == 2 || value == 4 || value == 8)
                    m_integerSize = value;
                else
                    throw new SemanticErrorException("Word size must be 2, 4 or 8");
            }
        }
        private static int m_MaxObjectIdentifierSize = 200;
        public static int MaxObjectIdentifierSize { get { return m_MaxObjectIdentifierSize; } }
        public static Int64 MAXINT
        {
            get
            {
                if (IntegerSize == 2)
                    return Int16.MaxValue;
                if (IntegerSize == 4)
                    return Int32.MaxValue;
                if (IntegerSize == 8)
                    return Int64.MaxValue;
                throw new SemanticErrorException("Error Setting in configuration file. IntegerSize must be 2 or 4 or 8");
            }
        }
        public static Int64 MININT
        {
            get
            {
                if (IntegerSize == 2)
                    return Int16.MinValue;
                if (IntegerSize == 4)
                    return Int32.MinValue;
                if (IntegerSize == 8)
                    return Int64.MinValue;
                throw new SemanticErrorException("Error Setting in configuration file. IntegerSize must be 2 or 4 or 8");
            }
        }

        public static void ExportDefaultSettingToFile(string fileName)
        {
        }
        public static void ReadSettingsFromFile(string fileName)
        {
        }
    }



    public delegate void OnAntrlNode(ITree root);
    public class AntlrTreeVisitor /* util class, no need to be abstract*/
    {
        public void visit(ITree root, int tokenID, OnAntrlNode callBack)
        {
            if (root.Type == tokenID)
                callBack(root);
            for (int i = 0; i < root.ChildCount; i++)
                visit(root.GetChild(i), tokenID, callBack);
        }

        public void visit(ITree root, int tokenID, OnAntrlNode callBack, IEnumerable<int> StopList)
        {
            List<int> stopList = new List<int>(StopList);
            if (root.Type == tokenID)
                callBack(root);
            if (stopList.Contains(root.Type))
                return;
            for (int i = 0; i < root.ChildCount; i++)
                visit(root.GetChild(i), tokenID, callBack, StopList);
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





}