using System;
using System.Collections.Generic;
using System.IO;
using Antlr.Runtime.Tree;

namespace tinyAsn1
{
    // The difference with the normal dictionary is that
    // the Values property retains order (as inserted)
    public class OrderedDictionary<TKey, TValue> 
    {
        Dictionary<TKey, TValue> m_keyval = new Dictionary<TKey, TValue>();
        List<TValue> m_values = new List<TValue>();
        List<TKey> m_keys = new List<TKey>();

        public void Add(TKey key, TValue value)
        {
            m_keyval.Add(key, value);
            m_values.Add(value);
            m_keys.Add(key);
        }
        public void Clear()
        {
            m_keys.Clear();
            m_keyval.Clear();
            m_values.Clear();
        }
        public TValue this[TKey key] {
            get
            {
                return m_keyval[key];
            }
            set
            {
                
                m_keyval[key] = value;
                m_values[m_keys.IndexOf(key)] = value;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return m_keyval.ContainsKey(key);
        }



        public List<TValue> Values {
            get { return m_values; }
        }
        public List<TKey> Keys
        {
            get { return m_keys; }
        }
        public int Count { get { return m_values.Count; } }

        public override int GetHashCode()
        {
            return m_keyval.GetHashCode();
        }

    }


    public class StreamWriterLevel : StreamWriter
    {
        public StreamWriterLevel(string fileName) : base(fileName) { }
        public void P(int level)
        {
            for (int i = 0; i < level; i++)
                Write("    ");
        }
        public string BR(List<string> lines)
        {
            string ret = "";
            foreach (string line in lines)
                ret += line + "<br/>";
            return ret;
        }
        public void WriteComment(List<string> comments, int lev)
        {
            List<string> comments2 = new List<string>();
            foreach (string li in comments)
            {
                string line = li.Replace("--", "").Trim();
                if (line.Length > 0)
                    comments2.Add(line);
            }
            if (comments2.Count == 0)
                return;
            if (comments2.Count == 1)
            {
                P(lev); WriteLine("/* {0} */", comments2[0]);
            }
            else
            {
                P(lev); WriteLine("/*");
                foreach (string li in comments2)
                {
                    P(lev); WriteLine(li);
                }
                P(lev); WriteLine("*/");
            }
        }
    }

    public class SemanticTreeNode : ITree
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
        public static int IntegerSize { get { return m_integerSize; } }
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

    public class SemanticErrorException : Exception
    {
        public SemanticErrorException(string ErrMsg)
            : base(ErrMsg)
        {
        }
    }

    public class AbstractMethodCalledException : Exception
    {
    }

    public class ErrorReporter
    {
        public static void SemanticError(string inputFileName, int line, string msg, params object[] args)
        {
            throw new SemanticErrorException("Error: " + inputFileName +"(" + line+") : "+string.Format(msg,args));
        }
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

    static class C
    {
        public static string ID(string str)
        {
            return str.Replace('-', '_').Replace('.', '_').Replace('/', '_');
        }

        public static string L(long i)
        {
            string sx = "";
            if (Math.Abs(i) > Int32.MaxValue)
                sx = "LL";
            return i.ToString() + sx;
        }
#if obsolete
        public static string CodeTemplate(string code, int lev, params KeyValuePair<string, string>[] replacements)
        {
            System.IO.StringWriter wr = new StringWriter();
            foreach (KeyValuePair<string, string> p in replacements)
            {
                if (!code.Contains(p.Key))
                    throw new ArgumentException("key attribute '" + p.Key + "' is not contained in the code template");
            }
            

            List<string> lines = new List<string>(code.Split('\n'));
            
            foreach(string line in lines) 
            {
                
                for (int i = 0; i < lev; i++)
                    wr.Write("    ");
                string curLine = line.TrimEnd();
                
                foreach (KeyValuePair<string, string> p in replacements)
                {
                    if (curLine.Contains(p.Key))
                        curLine = curLine.Replace(p.Key, p.Value);
                }
                wr.WriteLine(curLine);
                
            }
            return wr.ToString();
        }
#endif
    }

    public class CLocalVariable
    {
        public string varName = "";
        public string type = "";
        public int arrayLen = 0;
        public string initVal = "";
        public CLocalVariable(string VarName, string Type, int ArrayLen, string InitVal)
        {
            varName = VarName;
            type = Type;
            arrayLen = ArrayLen;
            initVal = InitVal;
        }
        public static void Print(StreamWriterLevel c, OrderedDictionary<string, CLocalVariable> vars)
        {
            foreach (CLocalVariable v in vars.Values)
            {
                c.P(1);
                if (v.arrayLen == 0)
                {
                    c.WriteLine("{0} {1} = {2};", v.type, v.varName, v.initVal);
                }
                else
                {
                    c.WriteLine("{0} {1}[{2}];", v.type, v.varName, v.arrayLen);
                }
            }
            if (vars.Count > 0)
                c.WriteLine();
        }

        public static int GetArrayIndex(string varName)
        {
            int ret = 0;
            foreach (char ch in varName.ToCharArray())
                if (ch == '[')
                    ret++;
            return ret;

        }

    }

}