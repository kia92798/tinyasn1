// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-31 16:10:53

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Lexer : Lexer 
{
    public const int UnionMark = 63;
    public const int COMMENT2 = 72;
    public const int TeletexString = 40;
    public const int BitStringLiteral = 55;
    public const int PrintableString = 37;
    public const int EXCEPT = 64;
    public const int EOF = -1;
    public const int PATTERN = 68;
    public const int INCLUDES = 66;
    public const int EXPORTS = 14;
    public const int BEGIN = 11;
    public const int UID = 47;
    public const int COMMENT = 71;
    public const int PRIVATE = 20;
    public const int DEFINITIONS = 4;
    public const int NULL = 21;
    public const int INT = 13;
    public const int UTF8String = 46;
    public const int OF = 33;
    public const int IMPLIED = 10;
    public const int LID = 62;
    public const int REAL = 27;
    public const int SEQUENCE = 29;
    public const int WS = 70;
    public const int ABSENT = 54;
    public const int GraphicString = 42;
    public const int IntersectionMark = 65;
    public const int IMPORTS = 16;
    public const int UniversalString = 44;
    public const int FROM = 17;
    public const int END = 12;
    public const int FALSE = 58;
    public const int UNIVERSAL = 18;
    public const int SIZE = 34;
    public const int AUTOMATIC = 8;
    public const int T75 = 75;
    public const int T76 = 76;
    public const int T73 = 73;
    public const int IA5String = 39;
    public const int T74 = 74;
    public const int T79 = 79;
    public const int T77 = 77;
    public const int COMPONENTS = 52;
    public const int T78 = 78;
    public const int APPLICATION = 19;
    public const int OctectStringLiteral = 56;
    public const int NumericString = 36;
    public const int MAX = 61;
    public const int EXPLICIT = 5;
    public const int STR = 69;
    public const int BOOLEAN = 24;
    public const int OBJECT = 48;
    public const int PRESENT = 53;
    public const int IDENTIFIER = 49;
    public const int ALL = 15;
    public const int RELATIVE_OID = 50;
    public const int GeneralString = 43;
    public const int BMPString = 45;
    public const int COMPONENT = 67;
    public const int CHOICE = 28;
    public const int WITH = 51;
    public const int INTEGER = 26;
    public const int EXTENSIBILITY = 9;
    public const int IMPLICIT = 7;
    public const int DEFAULT = 32;
    public const int SET = 30;
    public const int TAGS = 6;
    public const int MIN = 60;
    public const int Tokens = 92;
    public const int TRUE = 57;
    public const int T91 = 91;
    public const int T90 = 90;
    public const int OPTIONAL = 31;
    public const int StringLiteral = 59;
    public const int T88 = 88;
    public const int T89 = 89;
    public const int ENUMERATED = 25;
    public const int VideotexString = 41;
    public const int T84 = 84;
    public const int T85 = 85;
    public const int T86 = 86;
    public const int T87 = 87;
    public const int BIT = 22;
    public const int VisibleString = 38;
    public const int T81 = 81;
    public const int T80 = 80;
    public const int T83 = 83;
    public const int T82 = 82;
    public const int OCTET = 35;
    public const int STRING = 23;

    public asn1Lexer() 
    {
		InitializeCyclicDFAs();
    }
    public asn1Lexer(ICharStream input) 
		: base(input)
	{
		InitializeCyclicDFAs();
    }
    
    override public string GrammarFileName
    {
    	get { return "C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g";} 
    }

    // $ANTLR start T73 
    public void mT73() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T73;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:7:7: ( '::=' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:7:7: '::='
            {
            	Match("::="); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T73

    // $ANTLR start T74 
    public void mT74() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T74;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:8:7: ( '{' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:8:7: '{'
            {
            	Match('{'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T74

    // $ANTLR start T75 
    public void mT75() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T75;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:7: ( '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:7: '}'
            {
            	Match('}'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T75

    // $ANTLR start T76 
    public void mT76() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T76;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:10:7: ( '(' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:10:7: '('
            {
            	Match('('); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T76

    // $ANTLR start T77 
    public void mT77() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T77;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:7: ( ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:7: ')'
            {
            	Match(')'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T77

    // $ANTLR start T78 
    public void mT78() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T78;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:7: ( ';' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:7: ';'
            {
            	Match(';'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T78

    // $ANTLR start T79 
    public void mT79() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T79;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:13:7: ( ',' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:13:7: ','
            {
            	Match(','); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T79

    // $ANTLR start T80 
    public void mT80() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T80;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:7: ( '[' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:7: '['
            {
            	Match('['); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T80

    // $ANTLR start T81 
    public void mT81() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T81;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:7: ( ']' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:7: ']'
            {
            	Match(']'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T81

    // $ANTLR start T82 
    public void mT82() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T82;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: ( '...' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: '...'
            {
            	Match("..."); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T82

    // $ANTLR start T83 
    public void mT83() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T83;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: ( '[[' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: '[['
            {
            	Match("[["); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T83

    // $ANTLR start T84 
    public void mT84() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T84;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: ( ']]' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: ']]'
            {
            	Match("]]"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T84

    // $ANTLR start T85 
    public void mT85() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T85;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: ( '.' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: '.'
            {
            	Match('.'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T85

    // $ANTLR start T86 
    public void mT86() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T86;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ( '+' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: '+'
            {
            	Match('+'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T86

    // $ANTLR start T87 
    public void mT87() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T87;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: ( '-' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: '-'
            {
            	Match('-'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T87

    // $ANTLR start T88 
    public void mT88() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T88;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: ( '<' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: '<'
            {
            	Match('<'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T88

    // $ANTLR start T89 
    public void mT89() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T89;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: ( '..' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: '..'
            {
            	Match(".."); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T89

    // $ANTLR start T90 
    public void mT90() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T90;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: ( '!' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: '!'
            {
            	Match('!'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T90

    // $ANTLR start T91 
    public void mT91() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T91;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: ( ':' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: ':'
            {
            	Match(':'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T91

    // $ANTLR start UnionMark 
    public void mUnionMark() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UnionMark;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:371:15: ( '|' | 'UNION' )
            int alt1 = 2;
            int LA1_0 = input.LA(1);
            
            if ( (LA1_0 == '|') )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == 'U') )
            {
                alt1 = 2;
            }
            else 
            {
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("371:1: UnionMark : ( '|' | 'UNION' );", 1, 0, input);
            
                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:371:15: '|'
                    {
                    	Match('|'); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:371:19: 'UNION'
                    {
                    	Match("UNION"); 

                    
                    }
                    break;
            
            }
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end UnionMark

    // $ANTLR start IntersectionMark 
    public void mIntersectionMark() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IntersectionMark;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:373:21: ( '^' | 'INTERSECTION' )
            int alt2 = 2;
            int LA2_0 = input.LA(1);
            
            if ( (LA2_0 == '^') )
            {
                alt2 = 1;
            }
            else if ( (LA2_0 == 'I') )
            {
                alt2 = 2;
            }
            else 
            {
                NoViableAltException nvae_d2s0 =
                    new NoViableAltException("373:1: IntersectionMark : ( '^' | 'INTERSECTION' );", 2, 0, input);
            
                throw nvae_d2s0;
            }
            switch (alt2) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:373:21: '^'
                    {
                    	Match('^'); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:373:27: 'INTERSECTION'
                    {
                    	Match("INTERSECTION"); 

                    
                    }
                    break;
            
            }
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IntersectionMark

    // $ANTLR start DEFINITIONS 
    public void mDEFINITIONS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = DEFINITIONS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:376:16: ( 'DEFINITIONS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:376:16: 'DEFINITIONS'
            {
            	Match("DEFINITIONS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end DEFINITIONS

    // $ANTLR start EXPLICIT 
    public void mEXPLICIT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = EXPLICIT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:378:12: ( 'EXPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:378:12: 'EXPLICIT'
            {
            	Match("EXPLICIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end EXPLICIT

    // $ANTLR start TAGS 
    public void mTAGS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = TAGS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:380:9: ( 'TAGS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:380:9: 'TAGS'
            {
            	Match("TAGS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end TAGS

    // $ANTLR start IMPLICIT 
    public void mIMPLICIT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IMPLICIT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:382:11: ( 'IMPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:382:11: 'IMPLICIT'
            {
            	Match("IMPLICIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IMPLICIT

    // $ANTLR start AUTOMATIC 
    public void mAUTOMATIC() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = AUTOMATIC;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:384:13: ( 'AUTOMATIC' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:384:13: 'AUTOMATIC'
            {
            	Match("AUTOMATIC"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end AUTOMATIC

    // $ANTLR start EXTENSIBILITY 
    public void mEXTENSIBILITY() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = EXTENSIBILITY;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:386:17: ( 'EXTENSIBILITY' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:386:17: 'EXTENSIBILITY'
            {
            	Match("EXTENSIBILITY"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end EXTENSIBILITY

    // $ANTLR start IMPLIED 
    public void mIMPLIED() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IMPLIED;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:388:11: ( 'IMPLIED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:388:11: 'IMPLIED'
            {
            	Match("IMPLIED"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IMPLIED

    // $ANTLR start BEGIN 
    public void mBEGIN() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = BEGIN;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:390:9: ( 'BEGIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:390:9: 'BEGIN'
            {
            	Match("BEGIN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end BEGIN

    // $ANTLR start END 
    public void mEND() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = END;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:391:7: ( 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:391:7: 'END'
            {
            	Match("END"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end END

    // $ANTLR start EXPORTS 
    public void mEXPORTS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = EXPORTS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:393:11: ( 'EXPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:393:11: 'EXPORTS'
            {
            	Match("EXPORTS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end EXPORTS

    // $ANTLR start ALL 
    public void mALL() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = ALL;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:395:8: ( 'ALL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:395:8: 'ALL'
            {
            	Match("ALL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end ALL

    // $ANTLR start IMPORTS 
    public void mIMPORTS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IMPORTS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:397:11: ( 'IMPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:397:11: 'IMPORTS'
            {
            	Match("IMPORTS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IMPORTS

    // $ANTLR start FROM 
    public void mFROM() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = FROM;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:399:8: ( 'FROM' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:399:8: 'FROM'
            {
            	Match("FROM"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end FROM

    // $ANTLR start UNIVERSAL 
    public void mUNIVERSAL() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UNIVERSAL;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:401:13: ( 'UNIVERSAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:401:13: 'UNIVERSAL'
            {
            	Match("UNIVERSAL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end UNIVERSAL

    // $ANTLR start APPLICATION 
    public void mAPPLICATION() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = APPLICATION;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:402:15: ( 'APPLICATION' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:402:15: 'APPLICATION'
            {
            	Match("APPLICATION"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end APPLICATION

    // $ANTLR start PRIVATE 
    public void mPRIVATE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = PRIVATE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:403:11: ( 'PRIVATE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:403:11: 'PRIVATE'
            {
            	Match("PRIVATE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end PRIVATE

    // $ANTLR start BIT 
    public void mBIT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = BIT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:404:7: ( 'BIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:404:7: 'BIT'
            {
            	Match("BIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end BIT

    // $ANTLR start STRING 
    public void mSTRING() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = STRING;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:406:10: ( 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:406:10: 'STRING'
            {
            	Match("STRING"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end STRING

    // $ANTLR start BOOLEAN 
    public void mBOOLEAN() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = BOOLEAN;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:408:11: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:408:11: 'BOOLEAN'
            {
            	Match("BOOLEAN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end BOOLEAN

    // $ANTLR start ENUMERATED 
    public void mENUMERATED() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = ENUMERATED;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:410:13: ( 'ENUMERATED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:410:13: 'ENUMERATED'
            {
            	Match("ENUMERATED"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end ENUMERATED

    // $ANTLR start INTEGER 
    public void mINTEGER() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = INTEGER;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:412:11: ( 'INTEGER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:412:11: 'INTEGER'
            {
            	Match("INTEGER"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end INTEGER

    // $ANTLR start REAL 
    public void mREAL() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = REAL;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:414:8: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:414:8: 'REAL'
            {
            	Match("REAL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end REAL

    // $ANTLR start CHOICE 
    public void mCHOICE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = CHOICE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:416:10: ( 'CHOICE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:416:10: 'CHOICE'
            {
            	Match("CHOICE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end CHOICE

    // $ANTLR start SEQUENCE 
    public void mSEQUENCE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = SEQUENCE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:418:11: ( 'SEQUENCE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:418:11: 'SEQUENCE'
            {
            	Match("SEQUENCE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end SEQUENCE

    // $ANTLR start OPTIONAL 
    public void mOPTIONAL() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = OPTIONAL;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:420:11: ( 'OPTIONAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:420:11: 'OPTIONAL'
            {
            	Match("OPTIONAL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end OPTIONAL

    // $ANTLR start SIZE 
    public void mSIZE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = SIZE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:422:8: ( 'SIZE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:422:8: 'SIZE'
            {
            	Match("SIZE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end SIZE

    // $ANTLR start OF 
    public void mOF() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = OF;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:424:6: ( 'OF' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:424:6: 'OF'
            {
            	Match("OF"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end OF

    // $ANTLR start OCTET 
    public void mOCTET() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = OCTET;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:426:9: ( 'OCTET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:426:9: 'OCTET'
            {
            	Match("OCTET"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end OCTET

    // $ANTLR start MIN 
    public void mMIN() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = MIN;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:428:8: ( 'MIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:428:8: 'MIN'
            {
            	Match("MIN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end MIN

    // $ANTLR start MAX 
    public void mMAX() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = MAX;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:430:7: ( 'MAX' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:430:7: 'MAX'
            {
            	Match("MAX"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end MAX

    // $ANTLR start TRUE 
    public void mTRUE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = TRUE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:432:8: ( 'TRUE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:432:8: 'TRUE'
            {
            	Match("TRUE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end TRUE

    // $ANTLR start FALSE 
    public void mFALSE() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = FALSE;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:434:9: ( 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:434:9: 'FALSE'
            {
            	Match("FALSE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end FALSE

    // $ANTLR start ABSENT 
    public void mABSENT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = ABSENT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:436:10: ( 'ABSENT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:436:10: 'ABSENT'
            {
            	Match("ABSENT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end ABSENT

    // $ANTLR start PRESENT 
    public void mPRESENT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = PRESENT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:438:11: ( 'PRESENT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:438:11: 'PRESENT'
            {
            	Match("PRESENT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end PRESENT

    // $ANTLR start WITH 
    public void mWITH() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = WITH;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:440:9: ( 'WITH' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:440:9: 'WITH'
            {
            	Match("WITH"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end WITH

    // $ANTLR start COMPONENT 
    public void mCOMPONENT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = COMPONENT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:441:13: ( 'COMPONENT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:441:13: 'COMPONENT'
            {
            	Match("COMPONENT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end COMPONENT

    // $ANTLR start COMPONENTS 
    public void mCOMPONENTS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = COMPONENTS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:442:15: ( 'COMPONENTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:442:15: 'COMPONENTS'
            {
            	Match("COMPONENTS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end COMPONENTS

    // $ANTLR start DEFAULT 
    public void mDEFAULT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = DEFAULT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:443:12: ( 'DEFAULT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:443:12: 'DEFAULT'
            {
            	Match("DEFAULT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end DEFAULT

    // $ANTLR start NULL 
    public void mNULL() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = NULL;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:444:8: ( 'NULL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:444:8: 'NULL'
            {
            	Match("NULL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end NULL

    // $ANTLR start PATTERN 
    public void mPATTERN() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = PATTERN;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:445:11: ( 'PATTERN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:445:11: 'PATTERN'
            {
            	Match("PATTERN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end PATTERN

    // $ANTLR start OBJECT 
    public void mOBJECT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = OBJECT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:446:11: ( 'OBJECT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:446:11: 'OBJECT'
            {
            	Match("OBJECT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end OBJECT

    // $ANTLR start IDENTIFIER 
    public void mIDENTIFIER() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IDENTIFIER;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:447:13: ( 'IDENTIFIER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:447:13: 'IDENTIFIER'
            {
            	Match("IDENTIFIER"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IDENTIFIER

    // $ANTLR start RELATIVE_OID 
    public void mRELATIVE_OID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = RELATIVE_OID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:448:15: ( 'RELATIVE-OID' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:448:15: 'RELATIVE-OID'
            {
            	Match("RELATIVE-OID"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end RELATIVE_OID

    // $ANTLR start NumericString 
    public void mNumericString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = NumericString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:449:16: ( 'NumericString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:449:16: 'NumericString'
            {
            	Match("NumericString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end NumericString

    // $ANTLR start PrintableString 
    public void mPrintableString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = PrintableString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:450:18: ( 'PrintableString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:450:18: 'PrintableString'
            {
            	Match("PrintableString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end PrintableString

    // $ANTLR start VisibleString 
    public void mVisibleString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = VisibleString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:451:16: ( 'VisibleString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:451:16: 'VisibleString'
            {
            	Match("VisibleString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end VisibleString

    // $ANTLR start IA5String 
    public void mIA5String() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = IA5String;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:452:12: ( 'IA5String' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:452:12: 'IA5String'
            {
            	Match("IA5String"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end IA5String

    // $ANTLR start TeletexString 
    public void mTeletexString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = TeletexString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:453:16: ( 'TeletexString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:453:16: 'TeletexString'
            {
            	Match("TeletexString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end TeletexString

    // $ANTLR start VideotexString 
    public void mVideotexString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = VideotexString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:454:17: ( 'VideotexString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:454:17: 'VideotexString'
            {
            	Match("VideotexString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end VideotexString

    // $ANTLR start GraphicString 
    public void mGraphicString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = GraphicString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:455:16: ( 'GraphicString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:455:16: 'GraphicString'
            {
            	Match("GraphicString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end GraphicString

    // $ANTLR start GeneralString 
    public void mGeneralString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = GeneralString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:456:16: ( 'GeneralString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:456:16: 'GeneralString'
            {
            	Match("GeneralString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end GeneralString

    // $ANTLR start UniversalString 
    public void mUniversalString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UniversalString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:457:18: ( 'UniversalString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:457:18: 'UniversalString'
            {
            	Match("UniversalString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end UniversalString

    // $ANTLR start BMPString 
    public void mBMPString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = BMPString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:458:12: ( 'BMPString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:458:12: 'BMPString'
            {
            	Match("BMPString"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end BMPString

    // $ANTLR start UTF8String 
    public void mUTF8String() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UTF8String;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:459:13: ( 'UTF8String' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:459:13: 'UTF8String'
            {
            	Match("UTF8String"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end UTF8String

    // $ANTLR start INCLUDES 
    public void mINCLUDES() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = INCLUDES;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:460:11: ( 'INCLUDES' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:460:11: 'INCLUDES'
            {
            	Match("INCLUDES"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end INCLUDES

    // $ANTLR start EXCEPT 
    public void mEXCEPT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = EXCEPT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:461:10: ( 'EXCEPT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:461:10: 'EXCEPT'
            {
            	Match("EXCEPT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end EXCEPT

    // $ANTLR start SET 
    public void mSET() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = SET;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:463:7: ( 'SET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:463:7: 'SET'
            {
            	Match("SET"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end SET

    // $ANTLR start BitStringLiteral 
    public void mBitStringLiteral() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = BitStringLiteral;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:466:2: ( '\\'' ( '0' | '1' )* '\\'B' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:466:2: '\\'' ( '0' | '1' )* '\\'B'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:466:7: ( '0' | '1' )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);
            	    
            	    if ( ((LA3_0 >= '0' && LA3_0 <= '1')) )
            	    {
            	        alt3 = 1;
            	    }
            	    
            	
            	    switch (alt3) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '1') ) 
            			    	{
            			    	    input.Consume();
            			    	
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    Recover(mse);    throw mse;
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop3;
            	    }
            	} while (true);
            	
            	loop3:
            		;	// Stops C# compiler whinging that label 'loop3' has no statements

            	Match("\'B"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end BitStringLiteral

    // $ANTLR start OctectStringLiteral 
    public void mOctectStringLiteral() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = OctectStringLiteral;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:469:2: ( '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:469:2: '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:469:7: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);
            	    
            	    if ( ((LA4_0 >= '0' && LA4_0 <= '9') || (LA4_0 >= 'A' && LA4_0 <= 'F') || (LA4_0 >= 'a' && LA4_0 <= 'f')) )
            	    {
            	        alt4 = 1;
            	    }
            	    
            	
            	    switch (alt4) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'F') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
            			    	{
            			    	    input.Consume();
            			    	
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    Recover(mse);    throw mse;
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop4;
            	    }
            	} while (true);
            	
            	loop4:
            		;	// Stops C# compiler whinging that label 'loop4' has no statements

            	Match("\'H"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end OctectStringLiteral

    // $ANTLR start StringLiteral 
    public void mStringLiteral() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = StringLiteral;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:473:19: ( ( STR )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:473:19: ( STR )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:473:19: ( STR )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);
            	    
            	    if ( (LA5_0 == '\"') )
            	    {
            	        alt5 = 1;
            	    }
            	    
            	
            	    switch (alt5) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:473:19: STR
            			    {
            			    	mSTR(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee =
            		                new EarlyExitException(5, input);
            		            throw eee;
            	    }
            	    cnt5++;
            	} while (true);
            	
            	loop5:
            		;	// Stops C# compiler whinging that label 'loop5' has no statements

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end StringLiteral

    // $ANTLR start STR 
    public void mSTR() // throws RecognitionException [2]
    {
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:476:8: ( '\"' ( options {greedy=false; } : . )* '\"' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:476:8: '\"' ( options {greedy=false; } : . )* '\"'
            {
            	Match('\"'); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:476:12: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);
            	    
            	    if ( (LA6_0 == '\"') )
            	    {
            	        alt6 = 2;
            	    }
            	    else if ( ((LA6_0 >= '\u0000' && LA6_0 <= '!') || (LA6_0 >= '#' && LA6_0 <= '\uFFFE')) )
            	    {
            	        alt6 = 1;
            	    }
            	    
            	
            	    switch (alt6) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:476:40: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop6;
            	    }
            	} while (true);
            	
            	loop6:
            		;	// Stops C# compiler whinging that label 'loop6' has no statements

            	Match('\"'); 
            
            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end STR

    // $ANTLR start UID 
    public void mUID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:478:10: ( ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:478:10: ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:478:10: ( 'A' .. 'Z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:478:11: 'A' .. 'Z'
            	{
            		MatchRange('A','Z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:478:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);
            	    
            	    if ( (LA7_0 == '-' || (LA7_0 >= '0' && LA7_0 <= '9') || (LA7_0 >= 'A' && LA7_0 <= 'Z') || (LA7_0 >= 'a' && LA7_0 <= 'z')) )
            	    {
            	        alt7 = 1;
            	    }
            	    
            	
            	    switch (alt7) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            			    {
            			    	if ( input.LA(1) == '-' || (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();
            			    	
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    Recover(mse);    throw mse;
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop7;
            	    }
            	} while (true);
            	
            	loop7:
            		;	// Stops C# compiler whinging that label 'loop7' has no statements

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end UID

    // $ANTLR start LID 
    public void mLID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = LID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:481:10: ( ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:481:10: ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:481:10: ( 'a' .. 'z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:481:11: 'a' .. 'z'
            	{
            		MatchRange('a','z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:481:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);
            	    
            	    if ( (LA8_0 == '-' || (LA8_0 >= '0' && LA8_0 <= '9') || (LA8_0 >= 'A' && LA8_0 <= 'Z') || (LA8_0 >= 'a' && LA8_0 <= 'z')) )
            	    {
            	        alt8 = 1;
            	    }
            	    
            	
            	    switch (alt8) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            			    {
            			    	if ( input.LA(1) == '-' || (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            			    	{
            			    	    input.Consume();
            			    	
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    Recover(mse);    throw mse;
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop8;
            	    }
            	} while (true);
            	
            	loop8:
            		;	// Stops C# compiler whinging that label 'loop8' has no statements

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end LID

    // $ANTLR start INT 
    public void mINT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = INT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:7: ( ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);
            	
            	if ( (LA10_0 == '0') )
            	{
            	    alt10 = 1;
            	}
            	else if ( ((LA10_0 >= '1' && LA10_0 <= '9')) )
            	{
            	    alt10 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d10s0 =
            	        new NoViableAltException("484:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )", 10, 0, input);
            	
            	    throw nvae_d10s0;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:9: '0'
            	        {
            	        	Match('0'); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:15: ( '1' .. '9' ) ( '0' .. '9' )*
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:15: ( '1' .. '9' )
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:16: '1' .. '9'
            	        	{
            	        		MatchRange('1','9'); 
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:26: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt9 = 2;
            	        	    int LA9_0 = input.LA(1);
            	        	    
            	        	    if ( ((LA9_0 >= '0' && LA9_0 <= '9')) )
            	        	    {
            	        	        alt9 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt9) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:484:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 
            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop9;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop9:
            	        		;	// Stops C# compiler whinging that label 'loop9' has no statements

            	        
            	        }
            	        break;
            	
            	}

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end INT

    // $ANTLR start WS 
    public void mWS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = WS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:490:9: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:490:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:490:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            	int cnt11 = 0;
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);
            	    
            	    if ( ((LA11_0 >= '\t' && LA11_0 <= '\n') || LA11_0 == '\r' || LA11_0 == ' ') )
            	    {
            	        alt11 = 1;
            	    }
            	    
            	
            	    switch (alt11) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            			    {
            			    	if ( (input.LA(1) >= '\t' && input.LA(1) <= '\n') || input.LA(1) == '\r' || input.LA(1) == ' ' ) 
            			    	{
            			    	    input.Consume();
            			    	
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    Recover(mse);    throw mse;
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    if ( cnt11 >= 1 ) goto loop11;
            		            EarlyExitException eee =
            		                new EarlyExitException(11, input);
            		            throw eee;
            	    }
            	    cnt11++;
            	} while (true);
            	
            	loop11:
            		;	// Stops C# compiler whinging that label 'loop11' has no statements

            	channel=HIDDEN;
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end WS

    // $ANTLR start COMMENT 
    public void mCOMMENT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = COMMENT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:494:9: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:494:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:494:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);
            	    
            	    if ( (LA12_0 == '*') )
            	    {
            	        int LA12_1 = input.LA(2);
            	        
            	        if ( (LA12_1 == '/') )
            	        {
            	            alt12 = 2;
            	        }
            	        else if ( ((LA12_1 >= '\u0000' && LA12_1 <= '.') || (LA12_1 >= '0' && LA12_1 <= '\uFFFE')) )
            	        {
            	            alt12 = 1;
            	        }
            	        
            	    
            	    }
            	    else if ( ((LA12_0 >= '\u0000' && LA12_0 <= ')') || (LA12_0 >= '+' && LA12_0 <= '\uFFFE')) )
            	    {
            	        alt12 = 1;
            	    }
            	    
            	
            	    switch (alt12) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:494:42: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop12;
            	    }
            	} while (true);
            	
            	loop12:
            		;	// Stops C# compiler whinging that label 'loop12' has no statements

            	Match("*/"); 

            	channel=HIDDEN;
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end COMMENT

    // $ANTLR start COMMENT2 
    public void mCOMMENT2() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = COMMENT2;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:9: ( '--' ( options {greedy=false; } : . )* ( '--' | ( '\\r' )? '\\n' ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:9: '--' ( options {greedy=false; } : . )* ( '--' | ( '\\r' )? '\\n' )
            {
            	Match("--"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt13 = 2;
            	    int LA13_0 = input.LA(1);
            	    
            	    if ( (LA13_0 == '-') )
            	    {
            	        int LA13_1 = input.LA(2);
            	        
            	        if ( (LA13_1 == '-') )
            	        {
            	            alt13 = 2;
            	        }
            	        else if ( ((LA13_1 >= '\u0000' && LA13_1 <= ',') || (LA13_1 >= '.' && LA13_1 <= '\uFFFE')) )
            	        {
            	            alt13 = 1;
            	        }
            	        
            	    
            	    }
            	    else if ( (LA13_0 == '\r') )
            	    {
            	        alt13 = 2;
            	    }
            	    else if ( (LA13_0 == '\n') )
            	    {
            	        alt13 = 2;
            	    }
            	    else if ( ((LA13_0 >= '\u0000' && LA13_0 <= '\t') || (LA13_0 >= '\u000B' && LA13_0 <= '\f') || (LA13_0 >= '\u000E' && LA13_0 <= ',') || (LA13_0 >= '.' && LA13_0 <= '\uFFFE')) )
            	    {
            	        alt13 = 1;
            	    }
            	    
            	
            	    switch (alt13) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:42: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop13;
            	    }
            	} while (true);
            	
            	loop13:
            		;	// Stops C# compiler whinging that label 'loop13' has no statements

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:47: ( '--' | ( '\\r' )? '\\n' )
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);
            	
            	if ( (LA15_0 == '-') )
            	{
            	    alt15 = 1;
            	}
            	else if ( (LA15_0 == '\n' || LA15_0 == '\r') )
            	{
            	    alt15 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d15s0 =
            	        new NoViableAltException("498:47: ( '--' | ( '\\r' )? '\\n' )", 15, 0, input);
            	
            	    throw nvae_d15s0;
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:48: '--'
            	        {
            	        	Match("--"); 

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:53: ( '\\r' )? '\\n'
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:53: ( '\\r' )?
            	        	int alt14 = 2;
            	        	int LA14_0 = input.LA(1);
            	        	
            	        	if ( (LA14_0 == '\r') )
            	        	{
            	        	    alt14 = 1;
            	        	}
            	        	switch (alt14) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:498:53: '\\r'
            	        	        {
            	        	        	Match('\r'); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match('\n'); 
            	        
            	        }
            	        break;
            	
            	}

            	channel=HIDDEN;
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end COMMENT2

    override public void mTokens() // throws RecognitionException 
    {
        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: ( T73 | T74 | T75 | T76 | T77 | T78 | T79 | T80 | T81 | T82 | T83 | T84 | T85 | T86 | T87 | T88 | T89 | T90 | T91 | UnionMark | IntersectionMark | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | ABSENT | PRESENT | WITH | COMPONENT | COMPONENTS | DEFAULT | NULL | PATTERN | OBJECT | IDENTIFIER | RELATIVE_OID | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String | INCLUDES | EXCEPT | SET | BitStringLiteral | OctectStringLiteral | StringLiteral | UID | LID | INT | WS | COMMENT | COMMENT2 )
        int alt16 = 87;
        alt16 = dfa16.Predict(input);
        switch (alt16) 
        {
            case 1 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: T73
                {
                	mT73(); 
                
                }
                break;
            case 2 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:14: T74
                {
                	mT74(); 
                
                }
                break;
            case 3 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:18: T75
                {
                	mT75(); 
                
                }
                break;
            case 4 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:22: T76
                {
                	mT76(); 
                
                }
                break;
            case 5 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:26: T77
                {
                	mT77(); 
                
                }
                break;
            case 6 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:30: T78
                {
                	mT78(); 
                
                }
                break;
            case 7 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:34: T79
                {
                	mT79(); 
                
                }
                break;
            case 8 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:38: T80
                {
                	mT80(); 
                
                }
                break;
            case 9 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:42: T81
                {
                	mT81(); 
                
                }
                break;
            case 10 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:46: T82
                {
                	mT82(); 
                
                }
                break;
            case 11 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:50: T83
                {
                	mT83(); 
                
                }
                break;
            case 12 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:54: T84
                {
                	mT84(); 
                
                }
                break;
            case 13 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:58: T85
                {
                	mT85(); 
                
                }
                break;
            case 14 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:62: T86
                {
                	mT86(); 
                
                }
                break;
            case 15 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:66: T87
                {
                	mT87(); 
                
                }
                break;
            case 16 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:70: T88
                {
                	mT88(); 
                
                }
                break;
            case 17 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:74: T89
                {
                	mT89(); 
                
                }
                break;
            case 18 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:78: T90
                {
                	mT90(); 
                
                }
                break;
            case 19 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:82: T91
                {
                	mT91(); 
                
                }
                break;
            case 20 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:86: UnionMark
                {
                	mUnionMark(); 
                
                }
                break;
            case 21 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:96: IntersectionMark
                {
                	mIntersectionMark(); 
                
                }
                break;
            case 22 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:113: DEFINITIONS
                {
                	mDEFINITIONS(); 
                
                }
                break;
            case 23 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:125: EXPLICIT
                {
                	mEXPLICIT(); 
                
                }
                break;
            case 24 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:134: TAGS
                {
                	mTAGS(); 
                
                }
                break;
            case 25 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:139: IMPLICIT
                {
                	mIMPLICIT(); 
                
                }
                break;
            case 26 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:148: AUTOMATIC
                {
                	mAUTOMATIC(); 
                
                }
                break;
            case 27 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:158: EXTENSIBILITY
                {
                	mEXTENSIBILITY(); 
                
                }
                break;
            case 28 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:172: IMPLIED
                {
                	mIMPLIED(); 
                
                }
                break;
            case 29 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:180: BEGIN
                {
                	mBEGIN(); 
                
                }
                break;
            case 30 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:186: END
                {
                	mEND(); 
                
                }
                break;
            case 31 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:190: EXPORTS
                {
                	mEXPORTS(); 
                
                }
                break;
            case 32 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:198: ALL
                {
                	mALL(); 
                
                }
                break;
            case 33 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:202: IMPORTS
                {
                	mIMPORTS(); 
                
                }
                break;
            case 34 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:210: FROM
                {
                	mFROM(); 
                
                }
                break;
            case 35 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:215: UNIVERSAL
                {
                	mUNIVERSAL(); 
                
                }
                break;
            case 36 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:225: APPLICATION
                {
                	mAPPLICATION(); 
                
                }
                break;
            case 37 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:237: PRIVATE
                {
                	mPRIVATE(); 
                
                }
                break;
            case 38 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:245: BIT
                {
                	mBIT(); 
                
                }
                break;
            case 39 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:249: STRING
                {
                	mSTRING(); 
                
                }
                break;
            case 40 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:256: BOOLEAN
                {
                	mBOOLEAN(); 
                
                }
                break;
            case 41 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:264: ENUMERATED
                {
                	mENUMERATED(); 
                
                }
                break;
            case 42 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:275: INTEGER
                {
                	mINTEGER(); 
                
                }
                break;
            case 43 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:283: REAL
                {
                	mREAL(); 
                
                }
                break;
            case 44 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:288: CHOICE
                {
                	mCHOICE(); 
                
                }
                break;
            case 45 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:295: SEQUENCE
                {
                	mSEQUENCE(); 
                
                }
                break;
            case 46 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:304: OPTIONAL
                {
                	mOPTIONAL(); 
                
                }
                break;
            case 47 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:313: SIZE
                {
                	mSIZE(); 
                
                }
                break;
            case 48 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:318: OF
                {
                	mOF(); 
                
                }
                break;
            case 49 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:321: OCTET
                {
                	mOCTET(); 
                
                }
                break;
            case 50 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:327: MIN
                {
                	mMIN(); 
                
                }
                break;
            case 51 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:331: MAX
                {
                	mMAX(); 
                
                }
                break;
            case 52 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:335: TRUE
                {
                	mTRUE(); 
                
                }
                break;
            case 53 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:340: FALSE
                {
                	mFALSE(); 
                
                }
                break;
            case 54 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:346: ABSENT
                {
                	mABSENT(); 
                
                }
                break;
            case 55 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:353: PRESENT
                {
                	mPRESENT(); 
                
                }
                break;
            case 56 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:361: WITH
                {
                	mWITH(); 
                
                }
                break;
            case 57 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:366: COMPONENT
                {
                	mCOMPONENT(); 
                
                }
                break;
            case 58 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:376: COMPONENTS
                {
                	mCOMPONENTS(); 
                
                }
                break;
            case 59 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:387: DEFAULT
                {
                	mDEFAULT(); 
                
                }
                break;
            case 60 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:395: NULL
                {
                	mNULL(); 
                
                }
                break;
            case 61 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:400: PATTERN
                {
                	mPATTERN(); 
                
                }
                break;
            case 62 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:408: OBJECT
                {
                	mOBJECT(); 
                
                }
                break;
            case 63 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:415: IDENTIFIER
                {
                	mIDENTIFIER(); 
                
                }
                break;
            case 64 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:426: RELATIVE_OID
                {
                	mRELATIVE_OID(); 
                
                }
                break;
            case 65 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:439: NumericString
                {
                	mNumericString(); 
                
                }
                break;
            case 66 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:453: PrintableString
                {
                	mPrintableString(); 
                
                }
                break;
            case 67 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:469: VisibleString
                {
                	mVisibleString(); 
                
                }
                break;
            case 68 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:483: IA5String
                {
                	mIA5String(); 
                
                }
                break;
            case 69 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:493: TeletexString
                {
                	mTeletexString(); 
                
                }
                break;
            case 70 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:507: VideotexString
                {
                	mVideotexString(); 
                
                }
                break;
            case 71 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:522: GraphicString
                {
                	mGraphicString(); 
                
                }
                break;
            case 72 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:536: GeneralString
                {
                	mGeneralString(); 
                
                }
                break;
            case 73 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:550: UniversalString
                {
                	mUniversalString(); 
                
                }
                break;
            case 74 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:566: BMPString
                {
                	mBMPString(); 
                
                }
                break;
            case 75 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:576: UTF8String
                {
                	mUTF8String(); 
                
                }
                break;
            case 76 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:587: INCLUDES
                {
                	mINCLUDES(); 
                
                }
                break;
            case 77 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:596: EXCEPT
                {
                	mEXCEPT(); 
                
                }
                break;
            case 78 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:603: SET
                {
                	mSET(); 
                
                }
                break;
            case 79 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:607: BitStringLiteral
                {
                	mBitStringLiteral(); 
                
                }
                break;
            case 80 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:624: OctectStringLiteral
                {
                	mOctectStringLiteral(); 
                
                }
                break;
            case 81 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:644: StringLiteral
                {
                	mStringLiteral(); 
                
                }
                break;
            case 82 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:658: UID
                {
                	mUID(); 
                
                }
                break;
            case 83 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:662: LID
                {
                	mLID(); 
                
                }
                break;
            case 84 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:666: INT
                {
                	mINT(); 
                
                }
                break;
            case 85 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:670: WS
                {
                	mWS(); 
                
                }
                break;
            case 86 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:673: COMMENT
                {
                	mCOMMENT(); 
                
                }
                break;
            case 87 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:681: COMMENT2
                {
                	mCOMMENT2(); 
                
                }
                break;
        
        }
    
    }


    protected DFA16 dfa16;
	private void InitializeCyclicDFAs()
	{
	    this.dfa16 = new DFA16(this);
	}

    static readonly short[] DFA16_eot = {
        -1, 43, -1, -1, -1, -1, -1, -1, 45, 47, 49, -1, 51, -1, -1, -1, 
        37, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 37, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        100, -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 37, 37, 37, 141, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        -1, -1, -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 171, 37, 37, 37, 37, 176, 37, 37, 37, 37, 37, 182, 37, 37, 
        37, 37, 37, 37, 37, 37, 191, 37, 37, 37, 37, 37, 37, -1, 37, 37, 
        200, 201, 37, 37, 37, 37, 37, 37, 37, -1, 37, 37, 37, 37, 37, 37, 
        37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, -1, 227, 228, 37, 37, 
        -1, 37, 37, 37, 37, 37, -1, 37, 237, 37, 37, 37, 37, 242, 37, -1, 
        37, 37, 246, 37, 37, 37, 37, 37, -1, -1, 252, 37, 254, 37, 37, 37, 
        37, 37, 15, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 37, -1, -1, 37, 37, 37, 37, 281, 37, 37, 284, -1, 37, 37, 
        37, 37, -1, 37, 37, 37, -1, 37, 37, 294, 37, 37, -1, 37, -1, 37, 
        37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
        37, 316, 37, 37, 37, 37, 321, 37, 37, -1, 37, 37, -1, 37, 37, 37, 
        37, 37, 331, 37, 333, 37, -1, 37, 336, 37, 37, 37, 37, 37, 37, 37, 
        37, 37, 346, 37, 37, 349, 350, 37, 37, 353, 37, 37, -1, 356, 37, 
        37, 37, -1, 37, 37, 362, 37, 364, 365, 37, 367, 37, -1, 37, -1, 
        37, 37, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, -1, 37, 382, -1, 
        -1, 383, 37, -1, 37, 37, -1, 387, 37, 37, 37, 37, -1, 37, -1, -1, 
        37, -1, 394, 37, 37, 397, 37, 37, 37, 37, 37, 403, 37, 37, 37, 37, 
        -1, -1, 408, 37, 37, -1, 37, 37, 413, 37, 415, 37, -1, 37, 419, 
        -1, 37, 37, 37, 37, 37, -1, 37, 426, 427, 37, -1, 37, 37, 431, 37, 
        -1, 37, -1, 37, 37, 436, -1, 37, 37, 37, 37, 37, 37, -1, -1, 37, 
        444, 37, -1, 37, 447, 37, 37, -1, 37, 37, 37, 37, 37, 37, 17, -1, 
        37, 37, -1, 37, 459, 37, 37, 37, 37, 37, 37, 466, 467, 37, -1, 469, 
        470, 37, 472, 473, 37, -1, -1, 37, -1, -1, 476, -1, -1, 477, 478, 
        -1, -1, -1
        };
    static readonly short[] DFA16_eof = {
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    static readonly int[] DFA16_min = {
        9, 58, 0, 0, 0, 0, 0, 0, 91, 93, 46, 0, 45, 0, 0, 0, 78, 0, 65, 
        69, 78, 65, 66, 69, 65, 65, 69, 69, 72, 66, 65, 73, 85, 105, 101, 
        39, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 73, 105, 70, 
        69, 67, 80, 53, 70, 67, 68, 85, 71, 108, 83, 76, 84, 80, 71, 79, 
        80, 84, 76, 79, 69, 105, 84, 90, 81, 82, 65, 79, 77, 84, 45, 84, 
        74, 88, 78, 84, 109, 76, 100, 110, 97, 39, 66, 0, 0, 0, 79, 118, 
        56, 78, 69, 76, 76, 83, 65, 69, 69, 76, 77, 45, 69, 83, 101, 69, 
        45, 79, 76, 73, 76, 83, 45, 83, 77, 86, 83, 110, 84, 69, 85, 45, 
        73, 65, 76, 73, 80, 69, 0, 73, 69, 45, 45, 72, 101, 76, 105, 101, 
        101, 112, 0, 69, 78, 101, 83, 84, 71, 85, 82, 73, 116, 85, 78, 78, 
        80, 82, 73, 69, 0, 45, 45, 116, 78, 0, 77, 73, 78, 69, 116, 0, 69, 
        45, 65, 69, 116, 69, 45, 69, 0, 78, 84, 45, 67, 79, 84, 79, 67, 
        0, 0, 45, 114, 45, 98, 111, 114, 104, 82, 45, 114, 116, 73, 69, 
        83, 68, 84, 67, 114, 76, 73, 83, 84, 84, 67, 82, 0, 0, 101, 84, 
        65, 67, 45, 65, 114, 45, 0, 84, 78, 97, 82, 0, 78, 71, 73, 0, 69, 
        78, 45, 78, 84, 0, 105, 0, 108, 116, 97, 105, 83, 115, 114, 70, 
        82, 69, 69, 83, 68, 73, 105, 84, 84, 73, 45, 83, 73, 65, 120, 45, 
        84, 65, 0, 78, 105, 0, 69, 84, 98, 78, 67, 45, 86, 45, 69, 0, 65, 
        45, 99, 101, 101, 108, 99, 65, 97, 105, 73, 45, 67, 83, 45, 45, 
        84, 110, 45, 73, 66, 0, 45, 84, 84, 83, 0, 73, 84, 45, 110, 45, 
        45, 108, 45, 69, 0, 69, 0, 78, 76, 0, 83, 83, 120, 83, 83, 76, 108, 
        110, 69, 0, 84, 45, 0, 0, 45, 103, 0, 79, 73, 0, 45, 69, 116, 67, 
        73, 0, 103, 0, 0, 101, 0, 45, 45, 84, 45, 116, 116, 83, 116, 116, 
        45, 83, 103, 82, 73, 0, 0, 45, 78, 76, 0, 68, 114, 45, 79, 45, 83, 
        0, 79, 45, 0, 114, 114, 116, 114, 114, 0, 116, 45, 45, 79, 0, 83, 
        73, 45, 105, 0, 78, 0, 116, 73, 45, 0, 105, 105, 114, 105, 105, 
        114, 0, 0, 78, 45, 84, 0, 110, 45, 114, 68, 0, 110, 110, 105, 110, 
        110, 105, 45, 0, 89, 103, 0, 105, 45, 103, 103, 110, 103, 103, 110, 
        45, 45, 110, 0, 45, 45, 103, 45, 45, 103, 0, 0, 103, 0, 0, 45, 0, 
        0, 45, 45, 0, 0, 0
        };
    static readonly int[] DFA16_max = {
        125, 58, 0, 0, 0, 0, 0, 0, 91, 93, 46, 0, 45, 0, 0, 0, 110, 0, 78, 
        69, 88, 101, 85, 79, 82, 114, 84, 69, 79, 80, 73, 73, 117, 105, 
        114, 102, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 0, 0, 0, 73, 105, 
        70, 69, 84, 80, 53, 70, 84, 85, 85, 71, 108, 83, 76, 84, 80, 71, 
        79, 80, 84, 76, 79, 73, 105, 84, 90, 84, 82, 76, 79, 77, 84, 122, 
        84, 74, 88, 78, 84, 109, 76, 115, 110, 97, 102, 72, 0, 0, 0, 86, 
        118, 56, 78, 69, 76, 79, 83, 73, 69, 69, 79, 77, 122, 69, 83, 101, 
        69, 122, 79, 76, 73, 76, 83, 122, 83, 77, 86, 83, 110, 84, 69, 85, 
        122, 73, 65, 76, 73, 80, 69, 0, 73, 69, 122, 122, 72, 101, 76, 105, 
        101, 101, 112, 0, 69, 78, 101, 83, 84, 82, 85, 82, 73, 116, 85, 
        78, 78, 80, 82, 73, 69, 0, 122, 122, 116, 78, 0, 77, 73, 78, 69, 
        116, 0, 69, 122, 65, 69, 116, 69, 122, 69, 0, 78, 84, 122, 67, 79, 
        84, 79, 67, 0, 0, 122, 114, 122, 98, 111, 114, 104, 82, 122, 114, 
        116, 73, 69, 83, 68, 84, 69, 114, 76, 73, 83, 84, 84, 67, 82, 0, 
        0, 101, 84, 65, 67, 122, 65, 114, 122, 0, 84, 78, 97, 82, 0, 78, 
        71, 73, 0, 69, 78, 122, 78, 84, 0, 105, 0, 108, 116, 97, 105, 83, 
        115, 114, 70, 82, 69, 69, 83, 68, 73, 105, 84, 84, 73, 122, 83, 
        73, 65, 120, 122, 84, 65, 0, 78, 105, 0, 69, 84, 98, 78, 67, 122, 
        86, 122, 69, 0, 65, 122, 99, 101, 101, 108, 99, 65, 97, 105, 73, 
        122, 67, 83, 122, 122, 84, 110, 122, 73, 66, 0, 122, 84, 84, 83, 
        0, 73, 84, 122, 110, 122, 122, 108, 122, 69, 0, 69, 0, 78, 76, 0, 
        83, 83, 120, 83, 83, 76, 108, 110, 69, 0, 84, 122, 0, 0, 122, 103, 
        0, 79, 73, 0, 122, 69, 116, 67, 73, 0, 103, 0, 0, 101, 0, 122, 45, 
        84, 122, 116, 116, 83, 116, 116, 122, 83, 103, 82, 73, 0, 0, 122, 
        78, 76, 0, 68, 114, 122, 79, 122, 83, 0, 79, 122, 0, 114, 114, 116, 
        114, 114, 0, 116, 122, 122, 79, 0, 83, 73, 122, 105, 0, 78, 0, 116, 
        73, 122, 0, 105, 105, 114, 105, 105, 114, 0, 0, 78, 122, 84, 0, 
        110, 122, 114, 68, 0, 110, 110, 105, 110, 110, 105, 122, 0, 89, 
        103, 0, 105, 122, 103, 103, 110, 103, 103, 110, 122, 122, 110, 0, 
        122, 122, 103, 122, 122, 103, 0, 0, 103, 0, 0, 122, 0, 0, 122, 122, 
        0, 0, 0
        };
    static readonly short[] DFA16_accept = {
        -1, -1, 2, 3, 4, 5, 6, 7, -1, -1, -1, 14, -1, 16, 18, 20, -1, 21, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, 81, 82, 83, 84, 85, 86, 1, 19, 11, 8, 12, 9, -1, 13, 87, 
        15, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 80, 
        10, 17, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 48, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, 79, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, 30, -1, -1, -1, -1, 32, -1, -1, 
        -1, -1, -1, 38, -1, -1, -1, -1, -1, -1, -1, -1, 78, -1, -1, -1, 
        -1, -1, -1, -1, -1, 51, 50, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        52, 24, -1, -1, -1, -1, -1, -1, -1, -1, 34, -1, -1, -1, -1, 47, 
        -1, -1, -1, 43, -1, -1, -1, -1, -1, 56, -1, 60, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, 29, -1, -1, 53, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, 49, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 77, -1, -1, -1, -1, 54, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, 39, -1, 44, -1, -1, 62, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, 42, -1, -1, 33, 28, -1, -1, 59, -1, 
        -1, 31, -1, -1, -1, -1, -1, 40, -1, 37, 55, -1, 61, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 76, 25, -1, -1, -1, 
        23, -1, -1, -1, -1, -1, -1, 45, -1, -1, 46, -1, -1, -1, -1, -1, 
        35, -1, -1, -1, -1, 68, -1, -1, -1, -1, 26, -1, 74, -1, -1, -1, 
        57, -1, -1, -1, -1, -1, -1, 75, 63, -1, -1, -1, 41, -1, -1, -1, 
        -1, 58, -1, -1, -1, -1, -1, -1, -1, 22, -1, -1, 36, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, 64, -1, -1, -1, -1, -1, -1, 27, 
        69, -1, 65, 67, -1, 72, 71, -1, -1, 70, 73, 66
        };
    static readonly short[] DFA16_special = {
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    
    static readonly short[] dfa16_transition_null = null;

    static readonly short[] dfa16_transition0 = {
    	37, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, -1, -1, -1, -1, 
    	    -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
    	    37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, -1, -1, -1, 
    	    -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
    	    37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37
    	};
    static readonly short[] dfa16_transition1 = {
    	81
    	};
    static readonly short[] dfa16_transition2 = {
    	52, -1, -1, -1, -1, -1, 54, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 53
    	};
    static readonly short[] dfa16_transition3 = {
    	164, -1, -1, -1, -1, -1, -1, -1, 165
    	};
    static readonly short[] dfa16_transition4 = {
    	109
    	};
    static readonly short[] dfa16_transition5 = {
    	97, -1, -1, -1, -1, -1, -1, -1, -1, 96, 96, 98, 98, 98, 98, 98, 98, 
    	    98, 98, -1, -1, -1, -1, -1, -1, -1, 98, 98, 98, 98, 98, 98, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, 98, 98, 98, 98, 98, 98
    	};
    static readonly short[] dfa16_transition6 = {
    	261
    	};
    static readonly short[] dfa16_transition7 = {
    	114, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    113
    	};
    static readonly short[] dfa16_transition8 = {
    	304
    	};
    static readonly short[] dfa16_transition9 = {
    	157
    	};
    static readonly short[] dfa16_transition10 = {
    	212
    	};
    static readonly short[] dfa16_transition11 = {
    	405
    	};
    static readonly short[] dfa16_transition12 = {
    	344
    	};
    static readonly short[] dfa16_transition13 = {
    	379
    	};
    static readonly short[] dfa16_transition14 = {
    	216
    	};
    static readonly short[] dfa16_transition15 = {
    	265
    	};
    static readonly short[] dfa16_transition16 = {
    	87, 84, -1, -1, 85, -1, -1, -1, -1, -1, -1, -1, -1, -1, 86
    	};
    static readonly short[] dfa16_transition17 = {
    	160
    	};
    static readonly short[] dfa16_transition18 = {
    	348
    	};
    static readonly short[] dfa16_transition19 = {
    	308
    	};
    static readonly short[] dfa16_transition20 = {
    	273
    	};
    static readonly short[] dfa16_transition21 = {
    	223
    	};
    static readonly short[] dfa16_transition22 = {
    	167
    	};
    static readonly short[] dfa16_transition23 = {
    	474
    	};
    static readonly short[] dfa16_transition24 = {
    	465
    	};
    static readonly short[] dfa16_transition25 = {
    	425
    	};
    static readonly short[] dfa16_transition26 = {
    	404
    	};
    static readonly short[] dfa16_transition27 = {
    	455
    	};
    static readonly short[] dfa16_transition28 = {
    	442
    	};
    static readonly short[] dfa16_transition29 = {
    	303
    	};
    static readonly short[] dfa16_transition30 = {
    	260
    	};
    static readonly short[] dfa16_transition31 = {
    	378
    	};
    static readonly short[] dfa16_transition32 = {
    	343
    	};
    static readonly short[] dfa16_transition33 = {
    	102
    	};
    static readonly short[] dfa16_transition34 = {
    	211
    	};
    static readonly short[] dfa16_transition35 = {
    	156
    	};
    static readonly short[] dfa16_transition36 = {
    	103
    	};
    static readonly short[] dfa16_transition37 = {
    	363
    	};
    static readonly short[] dfa16_transition38 = {
    	392
    	};
    static readonly short[] dfa16_transition39 = {
    	181
    	};
    static readonly short[] dfa16_transition40 = {
    	235
    	};
    static readonly short[] dfa16_transition41 = {
    	283
    	};
    static readonly short[] dfa16_transition42 = {
    	325
    	};
    static readonly short[] dfa16_transition43 = {
    	124
    	};
    static readonly short[] dfa16_transition44 = {
    	464
    	};
    static readonly short[] dfa16_transition45 = {
    	454
    	};
    static readonly short[] dfa16_transition46 = {
    	441
    	};
    static readonly short[] dfa16_transition47 = {
    	424
    	};
    static readonly short[] dfa16_transition48 = {
    	402
    	};
    static readonly short[] dfa16_transition49 = {
    	376
    	};
    static readonly short[] dfa16_transition50 = {
    	341
    	};
    static readonly short[] dfa16_transition51 = {
    	301
    	};
    static readonly short[] dfa16_transition52 = {
    	258
    	};
    static readonly short[] dfa16_transition53 = {
    	208
    	};
    static readonly short[] dfa16_transition54 = {
    	152
    	};
    static readonly short[] dfa16_transition55 = {
    	453
    	};
    static readonly short[] dfa16_transition56 = {
    	463
    	};
    static readonly short[] dfa16_transition57 = {
    	423
    	};
    static readonly short[] dfa16_transition58 = {
    	440
    	};
    static readonly short[] dfa16_transition59 = {
    	375
    	};
    static readonly short[] dfa16_transition60 = {
    	401
    	};
    static readonly short[] dfa16_transition61 = {
    	300
    	};
    static readonly short[] dfa16_transition62 = {
    	340
    	};
    static readonly short[] dfa16_transition63 = {
    	207
    	};
    static readonly short[] dfa16_transition64 = {
    	257
    	};
    static readonly short[] dfa16_transition65 = {
    	151
    	};
    static readonly short[] dfa16_transition66 = {
    	446
    	};
    static readonly short[] dfa16_transition67 = {
    	432
    	};
    static readonly short[] dfa16_transition68 = {
    	159
    	};
    static readonly short[] dfa16_transition69 = {
    	457
    	};
    static readonly short[] dfa16_transition70 = {
    	214, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 215
    	};
    static readonly short[] dfa16_transition71 = {
    	174
    	};
    static readonly short[] dfa16_transition72 = {
    	117
    	};
    static readonly short[] dfa16_transition73 = {
    	277
    	};
    static readonly short[] dfa16_transition74 = {
    	229
    	};
    static readonly short[] dfa16_transition75 = {
    	359
    	};
    static readonly short[] dfa16_transition76 = {
    	320
    	};
    static readonly short[] dfa16_transition77 = {
    	412
    	};
    static readonly short[] dfa16_transition78 = {
    	389
    	};
    static readonly short[] dfa16_transition79 = {
    	439
    	};
    static readonly short[] dfa16_transition80 = {
    	452
    	};
    static readonly short[] dfa16_transition81 = {
    	462
    	};
    static readonly short[] dfa16_transition82 = {
    	471
    	};
    static readonly short[] dfa16_transition83 = {
    	40, 40, -1, -1, 40, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, 40, 14, 36, -1, -1, -1, -1, 35, 4, 5, -1, 
    	    11, 7, 12, 10, 41, 39, 39, 39, 39, 39, 39, 39, 39, 39, 39, 1, 6, 
    	    13, -1, -1, -1, -1, 22, 23, 28, 19, 20, 24, 34, 37, 18, 37, 37, 
    	    37, 30, 32, 29, 25, 37, 27, 26, 21, 16, 33, 31, 37, 37, 37, 8, 
    	    -1, 9, 17, -1, -1, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 
    	    38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 38, 2, 
    	    15, 3
    	};
    static readonly short[] dfa16_transition84 = {
    	206
    	};
    static readonly short[] dfa16_transition85 = {
    	256
    	};
    static readonly short[] dfa16_transition86 = {
    	299
    	};
    static readonly short[] dfa16_transition87 = {
    	339
    	};
    static readonly short[] dfa16_transition88 = {
    	374
    	};
    static readonly short[] dfa16_transition89 = {
    	400
    	};
    static readonly short[] dfa16_transition90 = {
    	422
    	};
    static readonly short[] dfa16_transition91 = {
    	421
    	};
    static readonly short[] dfa16_transition92 = {
    	399
    	};
    static readonly short[] dfa16_transition93 = {
    	373
    	};
    static readonly short[] dfa16_transition94 = {
    	338
    	};
    static readonly short[] dfa16_transition95 = {
    	461
    	};
    static readonly short[] dfa16_transition96 = {
    	451
    	};
    static readonly short[] dfa16_transition97 = {
    	438
    	};
    static readonly short[] dfa16_transition98 = {
    	298
    	};
    static readonly short[] dfa16_transition99 = {
    	255
    	};
    static readonly short[] dfa16_transition100 = {
    	205
    	};
    static readonly short[] dfa16_transition101 = {
    	384
    	};
    static readonly short[] dfa16_transition102 = {
    	312
    	};
    static readonly short[] dfa16_transition103 = {
    	352
    	};
    static readonly short[] dfa16_transition104 = {
    	92, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 91
    	};
    static readonly short[] dfa16_transition105 = {
    	219
    	};
    static readonly short[] dfa16_transition106 = {
    	269
    	};
    static readonly short[] dfa16_transition107 = {
    	108
    	};
    static readonly short[] dfa16_transition108 = {
    	163
    	};
    static readonly short[] dfa16_transition109 = {
    	366
    	};
    static readonly short[] dfa16_transition110 = {
    	328
    	};
    static readonly short[] dfa16_transition111 = {
    	287
    	};
    static readonly short[] dfa16_transition112 = {
    	240
    	};
    static readonly short[] dfa16_transition113 = {
    	187
    	};
    static readonly short[] dfa16_transition114 = {
    	130
    	};
    static readonly short[] dfa16_transition115 = {
    	475
    	};
    static readonly short[] dfa16_transition116 = {
    	468
    	};
    static readonly short[] dfa16_transition117 = {
    	458
    	};
    static readonly short[] dfa16_transition118 = {
    	448
    	};
    static readonly short[] dfa16_transition119 = {
    	434
    	};
    static readonly short[] dfa16_transition120 = {
    	416
    	};
    static readonly short[] dfa16_transition121 = {
    	393
    	};
    static readonly short[] dfa16_transition122 = {
    	337
    	};
    static readonly short[] dfa16_transition123 = {
    	372
    	};
    static readonly short[] dfa16_transition124 = {
    	253
    	};
    static readonly short[] dfa16_transition125 = {
    	297
    	};
    static readonly short[] dfa16_transition126 = {
    	147
    	};
    static readonly short[] dfa16_transition127 = {
    	203
    	};
    static readonly short[] dfa16_transition128 = {
    	460
    	};
    static readonly short[] dfa16_transition129 = {
    	437
    	};
    static readonly short[] dfa16_transition130 = {
    	450
    	};
    static readonly short[] dfa16_transition131 = {
    	398
    	};
    static readonly short[] dfa16_transition132 = {
    	420
    	};
    static readonly short[] dfa16_transition133 = {
    	245
    	};
    static readonly short[] dfa16_transition134 = {
    	193
    	};
    static readonly short[] dfa16_transition135 = {
    	332
    	};
    static readonly short[] dfa16_transition136 = {
    	291
    	};
    static readonly short[] dfa16_transition137 = {
    	101
    	};
    static readonly short[] dfa16_transition138 = {
    	155, -1, -1, -1, -1, -1, -1, 154
    	};
    static readonly short[] dfa16_transition139 = {
    	449
    	};
    static readonly short[] dfa16_transition140 = {
    	169, -1, -1, 168
    	};
    static readonly short[] dfa16_transition141 = {
    	395
    	};
    static readonly short[] dfa16_transition142 = {
    	218
    	};
    static readonly short[] dfa16_transition143 = {
    	369
    	};
    static readonly short[] dfa16_transition144 = {
    	435
    	};
    static readonly short[] dfa16_transition145 = {
    	417
    	};
    static readonly short[] dfa16_transition146 = {
    	268, -1, 267
    	};
    static readonly short[] dfa16_transition147 = {
    	104
    	};
    static readonly short[] dfa16_transition148 = {
    	158
    	};
    static readonly short[] dfa16_transition149 = {
    	296
    	};
    static readonly short[] dfa16_transition150 = {
    	380
    	};
    static readonly short[] dfa16_transition151 = {
    	406
    	};
    static readonly short[] dfa16_transition152 = {
    	213
    	};
    static readonly short[] dfa16_transition153 = {
    	262
    	};
    static readonly short[] dfa16_transition154 = {
    	305
    	};
    static readonly short[] dfa16_transition155 = {
    	345
    	};
    static readonly short[] dfa16_transition156 = {
    	131
    	};
    static readonly short[] dfa16_transition157 = {
    	93
    	};
    static readonly short[] dfa16_transition158 = {
    	329
    	};
    static readonly short[] dfa16_transition159 = {
    	288
    	};
    static readonly short[] dfa16_transition160 = {
    	241
    	};
    static readonly short[] dfa16_transition161 = {
    	188
    	};
    static readonly short[] dfa16_transition162 = {
    	251
    	};
    static readonly short[] dfa16_transition163 = {
    	199
    	};
    static readonly short[] dfa16_transition164 = {
    	143
    	};
    static readonly short[] dfa16_transition165 = {
    	313
    	};
    static readonly short[] dfa16_transition166 = {
    	220
    	};
    static readonly short[] dfa16_transition167 = {
    	270
    	};
    static readonly short[] dfa16_transition168 = {
    	148
    	};
    static readonly short[] dfa16_transition169 = {
    	204
    	};
    static readonly short[] dfa16_transition170 = {
    	146
    	};
    static readonly short[] dfa16_transition171 = {
    	202
    	};
    static readonly short[] dfa16_transition172 = {
    	327
    	};
    static readonly short[] dfa16_transition173 = {
    	239
    	};
    static readonly short[] dfa16_transition174 = {
    	286
    	};
    static readonly short[] dfa16_transition175 = {
    	186
    	};
    static readonly short[] dfa16_transition176 = {
    	278
    	};
    static readonly short[] dfa16_transition177 = {
    	175
    	};
    static readonly short[] dfa16_transition178 = {
    	230
    	};
    static readonly short[] dfa16_transition179 = {
    	118
    	};
    static readonly short[] dfa16_transition180 = {
    	236
    	};
    static readonly short[] dfa16_transition181 = {
    	90
    	};
    static readonly short[] dfa16_transition182 = {
    	183
    	};
    static readonly short[] dfa16_transition183 = {
    	126
    	};
    static readonly short[] dfa16_transition184 = {
    	172
    	};
    static readonly short[] dfa16_transition185 = {
    	115
    	};
    static readonly short[] dfa16_transition186 = {
    	144
    	};
    static readonly short[] dfa16_transition187 = {
    	145
    	};
    static readonly short[] dfa16_transition188 = {
    	197
    	};
    static readonly short[] dfa16_transition189 = {
    	140
    	};
    static readonly short[] dfa16_transition190 = {
    	249
    	};
    static readonly short[] dfa16_transition191 = {
    	189
    	};
    static readonly short[] dfa16_transition192 = {
    	132
    	};
    static readonly short[] dfa16_transition193 = {
    	371
    	};
    static readonly short[] dfa16_transition194 = {
    	295
    	};
    static readonly short[] dfa16_transition195 = {
    	335
    	};
    static readonly short[] dfa16_transition196 = {
    	198
    	};
    static readonly short[] dfa16_transition197 = {
    	250
    	};
    static readonly short[] dfa16_transition198 = {
    	142
    	};
    static readonly short[] dfa16_transition199 = {
    	190
    	};
    static readonly short[] dfa16_transition200 = {
    	368
    	};
    static readonly short[] dfa16_transition201 = {
    	330
    	};
    static readonly short[] dfa16_transition202 = {
    	289
    	};
    static readonly short[] dfa16_transition203 = {
    	243
    	};
    static readonly short[] dfa16_transition204 = {
    	247
    	};
    static readonly short[] dfa16_transition205 = {
    	195
    	};
    static readonly short[] dfa16_transition206 = {
    	138
    	};
    static readonly short[] dfa16_transition207 = {
    	292
    	};
    static readonly short[] dfa16_transition208 = {
    	79, -1, -1, -1, 78, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 80
    	};
    static readonly short[] dfa16_transition209 = {
    	194
    	};
    static readonly short[] dfa16_transition210 = {
    	263
    	};
    static readonly short[] dfa16_transition211 = {
    	77, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    75, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    76
    	};
    static readonly short[] dfa16_transition212 = {
    	306
    	};
    static readonly short[] dfa16_transition213 = {
    	94, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 95
    	};
    static readonly short[] dfa16_transition214 = {
    	388
    	};
    static readonly short[] dfa16_transition215 = {
    	358
    	};
    static readonly short[] dfa16_transition216 = {
    	411
    	};
    static readonly short[] dfa16_transition217 = {
    	226
    	};
    static readonly short[] dfa16_transition218 = {
    	170
    	};
    static readonly short[] dfa16_transition219 = {
    	319
    	};
    static readonly short[] dfa16_transition220 = {
    	276
    	};
    static readonly short[] dfa16_transition221 = {
    	46
    	};
    static readonly short[] dfa16_transition222 = {
    	445
    	};
    static readonly short[] dfa16_transition223 = {
    	456
    	};
    static readonly short[] dfa16_transition224 = {
    	410
    	};
    static readonly short[] dfa16_transition225 = {
    	430
    	};
    static readonly short[] dfa16_transition226 = {
    	355
    	};
    static readonly short[] dfa16_transition227 = {
    	386
    	};
    static readonly short[] dfa16_transition228 = {
    	272
    	};
    static readonly short[] dfa16_transition229 = {
    	315
    	};
    static readonly short[] dfa16_transition230 = {
    	233
    	};
    static readonly short[] dfa16_transition231 = {
    	179
    	};
    static readonly short[] dfa16_transition232 = {
    	44
    	};
    static readonly short[] dfa16_transition233 = {
    	122
    	};
    static readonly short[] dfa16_transition234 = {
    	310
    	};
    static readonly short[] dfa16_transition235 = {
    	119
    	};
    static readonly short[] dfa16_transition236 = {
    	274
    	};
    static readonly short[] dfa16_transition237 = {
    	317
    	};
    static readonly short[] dfa16_transition238 = {
    	224
    	};
    static readonly short[] dfa16_transition239 = {
    	127
    	};
    static readonly short[] dfa16_transition240 = {
    	309
    	};
    static readonly short[] dfa16_transition241 = {
    	266
    	};
    static readonly short[] dfa16_transition242 = {
    	217
    	};
    static readonly short[] dfa16_transition243 = {
    	302
    	};
    static readonly short[] dfa16_transition244 = {
    	342
    	};
    static readonly short[] dfa16_transition245 = {
    	209
    	};
    static readonly short[] dfa16_transition246 = {
    	259
    	};
    static readonly short[] dfa16_transition247 = {
    	377
    	};
    static readonly short[] dfa16_transition248 = {
    	184
    	};
    static readonly short[] dfa16_transition249 = {
    	433
    	};
    static readonly short[] dfa16_transition250 = {
    	414
    	};
    static readonly short[] dfa16_transition251 = {
    	391
    	};
    static readonly short[] dfa16_transition252 = {
    	150, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 149
    	};
    static readonly short[] dfa16_transition253 = {
    	178
    	};
    static readonly short[] dfa16_transition254 = {
    	121
    	};
    static readonly short[] dfa16_transition255 = {
    	361
    	};
    static readonly short[] dfa16_transition256 = {
    	323
    	};
    static readonly short[] dfa16_transition257 = {
    	280
    	};
    static readonly short[] dfa16_transition258 = {
    	232
    	};
    static readonly short[] dfa16_transition259 = {
    	125
    	};
    static readonly short[] dfa16_transition260 = {
    	185
    	};
    static readonly short[] dfa16_transition261 = {
    	238
    	};
    static readonly short[] dfa16_transition262 = {
    	285
    	};
    static readonly short[] dfa16_transition263 = {
    	326
    	};
    static readonly short[] dfa16_transition264 = {
    	133, -1, -1, 134
    	};
    static readonly short[] dfa16_transition265 = {
    	123
    	};
    static readonly short[] dfa16_transition266 = {
    	234
    	};
    static readonly short[] dfa16_transition267 = {
    	180
    	};
    static readonly short[] dfa16_transition268 = {
    	324
    	};
    static readonly short[] dfa16_transition269 = {
    	282
    	};
    static readonly short[] dfa16_transition270 = {
    	192
    	};
    static readonly short[] dfa16_transition271 = {
    	135
    	};
    static readonly short[] dfa16_transition272 = {
    	290
    	};
    static readonly short[] dfa16_transition273 = {
    	244
    	};
    static readonly short[] dfa16_transition274 = {
    	58, -1, -1, 55, -1, -1, -1, -1, -1, -1, -1, -1, 57, 56
    	};
    static readonly short[] dfa16_transition275 = {
    	210
    	};
    static readonly short[] dfa16_transition276 = {
    	65, -1, -1, -1, -1, -1, -1, -1, -1, -1, 66, -1, -1, -1, 68, -1, -1, 
    	    -1, -1, 67
    	};
    static readonly short[] dfa16_transition277 = {
    	407
    	};
    static readonly short[] dfa16_transition278 = {
    	428
    	};
    static readonly short[] dfa16_transition279 = {
    	443
    	};
    static readonly short[] dfa16_transition280 = {
    	264
    	};
    static readonly short[] dfa16_transition281 = {
    	307
    	};
    static readonly short[] dfa16_transition282 = {
    	82, -1, -1, -1, -1, -1, -1, 83
    	};
    static readonly short[] dfa16_transition283 = {
    	347
    	};
    static readonly short[] dfa16_transition284 = {
    	381
    	};
    static readonly short[] dfa16_transition285 = {
    	396
    	};
    static readonly short[] dfa16_transition286 = {
    	370
    	};
    static readonly short[] dfa16_transition287 = {
    	334
    	};
    static readonly short[] dfa16_transition288 = {
    	354
    	};
    static readonly short[] dfa16_transition289 = {
    	314
    	};
    static readonly short[] dfa16_transition290 = {
    	271
    	};
    static readonly short[] dfa16_transition291 = {
    	293
    	};
    static readonly short[] dfa16_transition292 = {
    	221
    	};
    static readonly short[] dfa16_transition293 = {
    	248
    	};
    static readonly short[] dfa16_transition294 = {
    	429
    	};
    static readonly short[] dfa16_transition295 = {
    	409
    	};
    static readonly short[] dfa16_transition296 = {
    	196
    	};
    static readonly short[] dfa16_transition297 = {
    	385
    	};
    static readonly short[] dfa16_transition298 = {
    	225
    	};
    static readonly short[] dfa16_transition299 = {
    	275
    	};
    static readonly short[] dfa16_transition300 = {
    	63, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    62, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, 64
    	};
    static readonly short[] dfa16_transition301 = {
    	106, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    105
    	};
    static readonly short[] dfa16_transition302 = {
    	318
    	};
    static readonly short[] dfa16_transition303 = {
    	357
    	};
    static readonly short[] dfa16_transition304 = {
    	116
    	};
    static readonly short[] dfa16_transition305 = {
    	173
    	};
    static readonly short[] dfa16_transition306 = {
    	61, -1, -1, -1, -1, -1, -1, -1, -1, -1, 60
    	};
    static readonly short[] dfa16_transition307 = {
    	351
    	};
    static readonly short[] dfa16_transition308 = {
    	311
    	};
    static readonly short[] dfa16_transition309 = {
    	50
    	};
    static readonly short[] dfa16_transition310 = {
    	120
    	};
    static readonly short[] dfa16_transition311 = {
    	177
    	};
    static readonly short[] dfa16_transition312 = {
    	231
    	};
    static readonly short[] dfa16_transition313 = {
    	279
    	};
    static readonly short[] dfa16_transition314 = {
    	322
    	};
    static readonly short[] dfa16_transition315 = {
    	360
    	};
    static readonly short[] dfa16_transition316 = {
    	390
    	};
    static readonly short[] dfa16_transition317 = {
    	166
    	};
    static readonly short[] dfa16_transition318 = {
    	222
    	};
    static readonly short[] dfa16_transition319 = {
    	137, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 136
    	};
    static readonly short[] dfa16_transition320 = {
    	59
    	};
    static readonly short[] dfa16_transition321 = {
    	139
    	};
    static readonly short[] dfa16_transition322 = {
    	69, -1, -1, -1, 72, -1, -1, -1, 71, -1, 70
    	};
    static readonly short[] dfa16_transition323 = {
    	37, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, -1, -1, -1, -1, 
    	    -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
    	    37, 37, 37, 37, 37, 418, 37, 37, 37, 37, 37, 37, 37, -1, -1, -1, 
    	    -1, -1, -1, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 
    	    37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37, 37
    	};
    static readonly short[] dfa16_transition324 = {
    	153, -1, -1, -1, -1, -1, 98
    	};
    static readonly short[] dfa16_transition325 = {
    	73, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    74
    	};
    static readonly short[] dfa16_transition326 = {
    	48
    	};
    static readonly short[] dfa16_transition327 = {
    	42
    	};
    static readonly short[] dfa16_transition328 = {
    	107
    	};
    static readonly short[] dfa16_transition329 = {
    	99
    	};
    static readonly short[] dfa16_transition330 = {
    	162, -1, -1, 161
    	};
    static readonly short[] dfa16_transition331 = {
    	129, -1, -1, -1, 128
    	};
    static readonly short[] dfa16_transition332 = {
    	111, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 112, -1, -1, -1, 
    	    110
    	};
    static readonly short[] dfa16_transition333 = {
    	88, -1, -1, -1, -1, -1, -1, -1, 89
    	};
    
    static readonly short[][] DFA16_transition = {
    	dfa16_transition83,
    	dfa16_transition327,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition232,
    	dfa16_transition221,
    	dfa16_transition326,
    	dfa16_transition_null,
    	dfa16_transition309,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition2,
    	dfa16_transition_null,
    	dfa16_transition274,
    	dfa16_transition320,
    	dfa16_transition306,
    	dfa16_transition300,
    	dfa16_transition276,
    	dfa16_transition322,
    	dfa16_transition325,
    	dfa16_transition211,
    	dfa16_transition208,
    	dfa16_transition1,
    	dfa16_transition282,
    	dfa16_transition16,
    	dfa16_transition333,
    	dfa16_transition181,
    	dfa16_transition104,
    	dfa16_transition157,
    	dfa16_transition213,
    	dfa16_transition5,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition329,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition137,
    	dfa16_transition33,
    	dfa16_transition36,
    	dfa16_transition147,
    	dfa16_transition301,
    	dfa16_transition328,
    	dfa16_transition107,
    	dfa16_transition4,
    	dfa16_transition332,
    	dfa16_transition7,
    	dfa16_transition185,
    	dfa16_transition304,
    	dfa16_transition72,
    	dfa16_transition179,
    	dfa16_transition235,
    	dfa16_transition310,
    	dfa16_transition254,
    	dfa16_transition233,
    	dfa16_transition265,
    	dfa16_transition43,
    	dfa16_transition259,
    	dfa16_transition183,
    	dfa16_transition239,
    	dfa16_transition331,
    	dfa16_transition114,
    	dfa16_transition156,
    	dfa16_transition192,
    	dfa16_transition264,
    	dfa16_transition271,
    	dfa16_transition319,
    	dfa16_transition206,
    	dfa16_transition321,
    	dfa16_transition189,
    	dfa16_transition0,
    	dfa16_transition198,
    	dfa16_transition164,
    	dfa16_transition186,
    	dfa16_transition187,
    	dfa16_transition170,
    	dfa16_transition126,
    	dfa16_transition168,
    	dfa16_transition252,
    	dfa16_transition65,
    	dfa16_transition54,
    	dfa16_transition5,
    	dfa16_transition324,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition138,
    	dfa16_transition35,
    	dfa16_transition9,
    	dfa16_transition148,
    	dfa16_transition68,
    	dfa16_transition17,
    	dfa16_transition330,
    	dfa16_transition108,
    	dfa16_transition3,
    	dfa16_transition317,
    	dfa16_transition22,
    	dfa16_transition140,
    	dfa16_transition218,
    	dfa16_transition0,
    	dfa16_transition184,
    	dfa16_transition305,
    	dfa16_transition71,
    	dfa16_transition177,
    	dfa16_transition0,
    	dfa16_transition311,
    	dfa16_transition253,
    	dfa16_transition231,
    	dfa16_transition267,
    	dfa16_transition39,
    	dfa16_transition0,
    	dfa16_transition182,
    	dfa16_transition248,
    	dfa16_transition260,
    	dfa16_transition175,
    	dfa16_transition113,
    	dfa16_transition161,
    	dfa16_transition191,
    	dfa16_transition199,
    	dfa16_transition0,
    	dfa16_transition270,
    	dfa16_transition134,
    	dfa16_transition209,
    	dfa16_transition205,
    	dfa16_transition296,
    	dfa16_transition188,
    	dfa16_transition_null,
    	dfa16_transition196,
    	dfa16_transition163,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition171,
    	dfa16_transition127,
    	dfa16_transition169,
    	dfa16_transition100,
    	dfa16_transition84,
    	dfa16_transition63,
    	dfa16_transition53,
    	dfa16_transition_null,
    	dfa16_transition245,
    	dfa16_transition275,
    	dfa16_transition34,
    	dfa16_transition10,
    	dfa16_transition152,
    	dfa16_transition70,
    	dfa16_transition14,
    	dfa16_transition242,
    	dfa16_transition142,
    	dfa16_transition105,
    	dfa16_transition166,
    	dfa16_transition292,
    	dfa16_transition318,
    	dfa16_transition21,
    	dfa16_transition238,
    	dfa16_transition298,
    	dfa16_transition217,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition74,
    	dfa16_transition178,
    	dfa16_transition_null,
    	dfa16_transition312,
    	dfa16_transition258,
    	dfa16_transition230,
    	dfa16_transition266,
    	dfa16_transition40,
    	dfa16_transition_null,
    	dfa16_transition180,
    	dfa16_transition0,
    	dfa16_transition261,
    	dfa16_transition173,
    	dfa16_transition112,
    	dfa16_transition160,
    	dfa16_transition0,
    	dfa16_transition203,
    	dfa16_transition_null,
    	dfa16_transition273,
    	dfa16_transition133,
    	dfa16_transition0,
    	dfa16_transition204,
    	dfa16_transition293,
    	dfa16_transition190,
    	dfa16_transition197,
    	dfa16_transition162,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition124,
    	dfa16_transition0,
    	dfa16_transition99,
    	dfa16_transition85,
    	dfa16_transition64,
    	dfa16_transition52,
    	dfa16_transition246,
    	dfa16_transition0,
    	dfa16_transition30,
    	dfa16_transition6,
    	dfa16_transition153,
    	dfa16_transition210,
    	dfa16_transition280,
    	dfa16_transition15,
    	dfa16_transition241,
    	dfa16_transition146,
    	dfa16_transition106,
    	dfa16_transition167,
    	dfa16_transition290,
    	dfa16_transition228,
    	dfa16_transition20,
    	dfa16_transition236,
    	dfa16_transition299,
    	dfa16_transition220,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition73,
    	dfa16_transition176,
    	dfa16_transition313,
    	dfa16_transition257,
    	dfa16_transition0,
    	dfa16_transition269,
    	dfa16_transition41,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition262,
    	dfa16_transition174,
    	dfa16_transition111,
    	dfa16_transition159,
    	dfa16_transition_null,
    	dfa16_transition202,
    	dfa16_transition272,
    	dfa16_transition136,
    	dfa16_transition_null,
    	dfa16_transition207,
    	dfa16_transition291,
    	dfa16_transition0,
    	dfa16_transition194,
    	dfa16_transition149,
    	dfa16_transition_null,
    	dfa16_transition125,
    	dfa16_transition_null,
    	dfa16_transition98,
    	dfa16_transition86,
    	dfa16_transition61,
    	dfa16_transition51,
    	dfa16_transition243,
    	dfa16_transition29,
    	dfa16_transition8,
    	dfa16_transition154,
    	dfa16_transition212,
    	dfa16_transition281,
    	dfa16_transition19,
    	dfa16_transition240,
    	dfa16_transition234,
    	dfa16_transition308,
    	dfa16_transition102,
    	dfa16_transition165,
    	dfa16_transition289,
    	dfa16_transition229,
    	dfa16_transition0,
    	dfa16_transition237,
    	dfa16_transition302,
    	dfa16_transition219,
    	dfa16_transition76,
    	dfa16_transition0,
    	dfa16_transition314,
    	dfa16_transition256,
    	dfa16_transition_null,
    	dfa16_transition268,
    	dfa16_transition42,
    	dfa16_transition_null,
    	dfa16_transition263,
    	dfa16_transition172,
    	dfa16_transition110,
    	dfa16_transition158,
    	dfa16_transition201,
    	dfa16_transition0,
    	dfa16_transition135,
    	dfa16_transition0,
    	dfa16_transition287,
    	dfa16_transition_null,
    	dfa16_transition195,
    	dfa16_transition0,
    	dfa16_transition122,
    	dfa16_transition94,
    	dfa16_transition87,
    	dfa16_transition62,
    	dfa16_transition50,
    	dfa16_transition244,
    	dfa16_transition32,
    	dfa16_transition12,
    	dfa16_transition155,
    	dfa16_transition0,
    	dfa16_transition283,
    	dfa16_transition18,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition307,
    	dfa16_transition103,
    	dfa16_transition0,
    	dfa16_transition288,
    	dfa16_transition226,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition303,
    	dfa16_transition215,
    	dfa16_transition75,
    	dfa16_transition_null,
    	dfa16_transition315,
    	dfa16_transition255,
    	dfa16_transition0,
    	dfa16_transition37,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition109,
    	dfa16_transition0,
    	dfa16_transition200,
    	dfa16_transition_null,
    	dfa16_transition143,
    	dfa16_transition_null,
    	dfa16_transition286,
    	dfa16_transition193,
    	dfa16_transition_null,
    	dfa16_transition123,
    	dfa16_transition93,
    	dfa16_transition88,
    	dfa16_transition59,
    	dfa16_transition49,
    	dfa16_transition247,
    	dfa16_transition31,
    	dfa16_transition13,
    	dfa16_transition150,
    	dfa16_transition_null,
    	dfa16_transition284,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition101,
    	dfa16_transition_null,
    	dfa16_transition297,
    	dfa16_transition227,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition214,
    	dfa16_transition78,
    	dfa16_transition316,
    	dfa16_transition251,
    	dfa16_transition_null,
    	dfa16_transition38,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition121,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition141,
    	dfa16_transition285,
    	dfa16_transition0,
    	dfa16_transition131,
    	dfa16_transition92,
    	dfa16_transition89,
    	dfa16_transition60,
    	dfa16_transition48,
    	dfa16_transition0,
    	dfa16_transition26,
    	dfa16_transition11,
    	dfa16_transition151,
    	dfa16_transition277,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition295,
    	dfa16_transition224,
    	dfa16_transition_null,
    	dfa16_transition216,
    	dfa16_transition77,
    	dfa16_transition0,
    	dfa16_transition250,
    	dfa16_transition0,
    	dfa16_transition120,
    	dfa16_transition_null,
    	dfa16_transition145,
    	dfa16_transition323,
    	dfa16_transition_null,
    	dfa16_transition132,
    	dfa16_transition91,
    	dfa16_transition90,
    	dfa16_transition57,
    	dfa16_transition47,
    	dfa16_transition_null,
    	dfa16_transition25,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition278,
    	dfa16_transition_null,
    	dfa16_transition294,
    	dfa16_transition225,
    	dfa16_transition0,
    	dfa16_transition67,
    	dfa16_transition_null,
    	dfa16_transition249,
    	dfa16_transition_null,
    	dfa16_transition119,
    	dfa16_transition144,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition129,
    	dfa16_transition97,
    	dfa16_transition79,
    	dfa16_transition58,
    	dfa16_transition46,
    	dfa16_transition28,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition279,
    	dfa16_transition0,
    	dfa16_transition222,
    	dfa16_transition_null,
    	dfa16_transition66,
    	dfa16_transition0,
    	dfa16_transition118,
    	dfa16_transition139,
    	dfa16_transition_null,
    	dfa16_transition130,
    	dfa16_transition96,
    	dfa16_transition80,
    	dfa16_transition55,
    	dfa16_transition45,
    	dfa16_transition27,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition223,
    	dfa16_transition69,
    	dfa16_transition_null,
    	dfa16_transition117,
    	dfa16_transition0,
    	dfa16_transition128,
    	dfa16_transition95,
    	dfa16_transition81,
    	dfa16_transition56,
    	dfa16_transition44,
    	dfa16_transition24,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition116,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition82,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition23,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition115,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition0,
    	dfa16_transition0,
    	dfa16_transition_null,
    	dfa16_transition_null,
    	dfa16_transition_null
        };
    
    protected class DFA16 : DFA
    {
        public DFA16(BaseRecognizer recognizer) 
        {
            this.recognizer = recognizer;
            this.decisionNumber = 16;
            this.eot = DFA16_eot;
            this.eof = DFA16_eof;
            this.min = DFA16_min;
            this.max = DFA16_max;
            this.accept     = DFA16_accept;
            this.special    = DFA16_special;
            this.transition = DFA16_transition;
        }
    
        override public string Description
        {
            get { return "1:1: Tokens : ( T73 | T74 | T75 | T76 | T77 | T78 | T79 | T80 | T81 | T82 | T83 | T84 | T85 | T86 | T87 | T88 | T89 | T90 | T91 | UnionMark | IntersectionMark | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | ABSENT | PRESENT | WITH | COMPONENT | COMPONENTS | DEFAULT | NULL | PATTERN | OBJECT | IDENTIFIER | RELATIVE_OID | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String | INCLUDES | EXCEPT | SET | BitStringLiteral | OctectStringLiteral | StringLiteral | UID | LID | INT | WS | COMMENT | COMMENT2 );"; }
        }
    
    }
    
 
    
}
