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
using System.Collections.Generic; using System.Linq;
using System.IO;

namespace semantix.util
{
    // The difference with the normal dictionary is that
    // the Values property retains order (as inserted)
    public class OrderedDictionary<TKey, TValue>    /* util class, no need to be abstract*/
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
        public TValue this[TKey key]
        {
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



        public List<TValue> Values
        {
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


    /// <summary>
    /// Utility class used for generating output
    /// </summary>
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
            {
                string l = line;
                if (l.StartsWith("--@"))
                    l = l.Substring(3);
                while (l.StartsWith("-"))
                    l = l.Substring(1);
                if (l.StartsWith("/*") && l.EndsWith("*/"))
                    l = l.Substring(2, l.Length - 4);
                ret += l + "<br/>";
            }
            return ret;
        }

        public string Constraint(string constraint)
        {
            if (constraint == "")
                return "N.A.";

            if (constraint.StartsWith("(") && constraint.EndsWith(")") && !constraint.Substring(1, constraint.Length - 2).Contains("("))
                return constraint.Substring(1, constraint.Length - 2);
            return constraint;
        }
        public void WriteComment(List<string> comments, int lev)
        {
            List<string> comments2 = new List<string>();
            foreach (string li in comments)
            {
                string line = li.Replace("--@", "").Replace("--", "").Trim();
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

        public void WriteCodeBlock(int lev, string codeBlock, params object[] args)
        {

            List<string> lines = new List<string>(string.Format(codeBlock, args).Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries));

            foreach (string line in lines)
            {
                P(lev);
                WriteLine(line.TrimEnd(Environment.NewLine.ToCharArray()));
            }
        }

        public void WL(int L, string format, params object[] arg)
        {
            P(L);
            if (arg.Length > 0)
                WriteLine(format, arg);
            else
                WriteLine(format);
        }


    }


    public class SemanticErrorException : Exception /* util class, no need to be abstract*/
    {
        public SemanticErrorException(string ErrMsg)
            : base(ErrMsg)
        {
        }
    }

    public class AbstractMethodCalledException : Exception /* util class, no need to be abstract*/
    {
    }

    public class ErrorReporter /* util class, no need to be abstract*/
    {
        public static void SemanticError(string inputFileName, int line, string msg, params object[] args)
        {
            throw new SemanticErrorException("Error: " + inputFileName + "(" + line + ") : " + string.Format(msg, args));
        }
    }



    public static class C
    {
        public static string ID(string str)
        {
            return str.Replace('-', '_').Replace('.', '_').Replace('/', '_');
        }

        public static string L(long i)
        {
            string sx = "";

            //Math.Abs(long.MinValue) throws an exception 
            if (i == long.MinValue)
                return i.ToString() + "LL";

            if (Math.Abs(i) > Int32.MaxValue)
                sx = "LL";
            return i.ToString() + sx;
        }
    }

    public static class Tuple
    {
        public static Tuple<T1> Create<T1>(T1 t1) { return new Tuple<T1>(t1); }
        public static Tuple<T1, T2> Create<T1, T2>(T1 t1, T2 t2) { return new Tuple<T1, T2>(t1, t2); }

    }

    public class Tuple<T1>
    {

        public Tuple(T1 t1)
        {
            I1 = t1;
        }

        T1 _i1;
        public T1 I1 { get { return _i1; } set { _i1 = value; } }

        public override string ToString()
        {
            return String.Format("<{0}>", I1.ToString());
        }
        public override bool Equals(object obj)
        {
            Tuple<T1> o = obj as Tuple<T1>;
            if (o == null)
                return false;

            return I1.Equals(o.I1);
        }
        public override int GetHashCode()
        {
            return I1.GetHashCode();
        }
    }


    public class Tuple<T1, T2> : Tuple<T1>
    {
        public Tuple(T1 t1, T2 t2)
            : base(t1)
        {
            I2 = t2;
        }

        T2 _i2;
        public T2 I2 { get { return _i2; } set { _i2 = value; } }

        public override string ToString()
        {
            return String.Format("<{0},{1}>", I1.ToString(), I2.ToString());
        }

        public override bool Equals(object obj)
        {
            Tuple<T1, T2> o = obj as Tuple<T1, T2>;
            if (o == null)
                return false;
            return I1.Equals(o.I1) && I2.Equals(o.I2);
        }

        public override int GetHashCode()
        {
            return I1.GetHashCode() | I2.GetHashCode();
        }
    }

    public static class EnumerableUtils
    {
        public static T GetFirst<T>(IEnumerable<T> list)
        {
            foreach (T t in list)
            {
                return t;
            }
            throw new IndexOutOfRangeException();
        }

        public static T GetLast<T>(IEnumerable<T> list)
        {
            int i = 0;
            T ret = default(T);
            foreach (T t in list)
            {
                ret = t;
                i++;
            }
            if (i == 0)
                throw new IndexOutOfRangeException();
            return ret;
        }

        public static T GetNext<T>(T v, IEnumerable<T> list) where T : IEquatable<T>
        {
            T ret = v;

            bool found = false;
            foreach (T t in list)
            {
                if (found)
                    return t;
                if (t.Equals(v))
                    found = true;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static T GetPrev<T>(T v, IEnumerable<T> list) where T : IEquatable<T>
        {
            T ret = v;

            foreach (T t in list)
            {
                if (t.Equals(v) && !ret.Equals(v))
                    return ret;
                ret = t;
            }

            throw new ArgumentOutOfRangeException();
        }

    }

    public static class XML
    {
        public static string esc(string s)
        {
            return s.Replace("&", "&amp;").Replace("\"", "&quot;").Replace("<", "&lt;").Replace(">", "&gt;");
        }
    }

    public class CmdLineArgs
    {
        public class ArgException : Exception
        {
            public ArgException(string Message)
                : base(Message)
            {
            }
        }
        public static bool HasArg(string[] args, string arg)
        {
            foreach (string a in args)
                if (a == arg)
                    return true;
            return false;
        }

        public static string GetArgValue(string[] args, string arg, string errMsg)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == arg)
                {
                    i++;
                    if (i>=args.Length)
                        throw new ArgException(errMsg);
                    if (args[i].StartsWith("-"))
                        throw new ArgException(errMsg);
                    return args[i];
                }
            }
            throw new ArgException(errMsg);
        }

        public static List<string> GetFiles(string[] args, params string[] singleArgs)
        {
            List<string> ret = new List<string>();
            List<string> sArgs = new List<string>(singleArgs);
            foreach (string s in sArgs)
                if (!s.StartsWith("-"))
                    throw new Exception("Bug. Single args should start with '-'");

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("-"))
                {
                    if (sArgs.Contains(args[i]))
                        continue;
                    else
                    {
                        // value argument ...
                        i++;
                        if (i >= args.Length)
                            throw new ArgException("Argument: '" + args[i] + "' is missing!");
                        continue;
                    }
                } else
                    ret.Add(args[i]);
            }
            return ret;
        }
    }


}