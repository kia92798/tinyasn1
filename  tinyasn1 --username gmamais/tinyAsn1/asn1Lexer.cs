// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-28 18:09:26

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Lexer : Lexer 
{
    public const int T73 = 73;
    public const int T74 = 74;
    public const int IA5String = 35;
    public const int TeletexString = 36;
    public const int COMPONENTS = 46;
    public const int APPLICATION = 19;
    public const int NumericString = 32;
    public const int Bstring = 52;
    public const int PrintableString = 33;
    public const int MAX = 51;
    public const int EXPLICIT = 5;
    public const int EOF = -1;
    public const int T72 = 72;
    public const int T71 = 71;
    public const int T70 = 70;
    public const int T62 = 62;
    public const int T63 = 63;
    public const int T64 = 64;
    public const int T65 = 65;
    public const int T66 = 66;
    public const int BOOLEAN = 23;
    public const int T67 = 67;
    public const int T68 = 68;
    public const int T69 = 69;
    public const int EXPORTS = 14;
    public const int PRESENT = 47;
    public const int BEGIN = 11;
    public const int ALL = 15;
    public const int GeneralString = 39;
    public const int UID = 56;
    public const int COMMENT = 58;
    public const int BMPString = 41;
    public const int CHOICE = 27;
    public const int T61 = 61;
    public const int WITH = 45;
    public const int T60 = 60;
    public const int INTEGER = 25;
    public const int EXTENSIBILITY = 9;
    public const int IMPLICIT = 7;
    public const int LINE_COMMENT = 59;
    public const int PRIVATE = 20;
    public const int DEFINITIONS = 4;
    public const int TAGS = 6;
    public const int INT = 13;
    public const int MIN = 50;
    public const int UTF8String = 42;
    public const int Tokens = 75;
    public const int OF = 30;
    public const int TRUE = 54;
    public const int IMPLIED = 10;
    public const int OPTIONAL = 29;
    public const int LID = 43;
    public const int StringLiteral = 49;
    public const int REAL = 26;
    public const int SEQUENCE = 28;
    public const int ENUMERATED = 24;
    public const int VideotexString = 37;
    public const int WS = 57;
    public const int ABSENT = 48;
    public const int Hstring = 53;
    public const int GraphicString = 38;
    public const int BIT = 21;
    public const int VisibleString = 34;
    public const int IMPORTS = 16;
    public const int UniversalString = 40;
    public const int END = 12;
    public const int FROM = 17;
    public const int UNIVERSAL = 18;
    public const int FALSE = 55;
    public const int SIZE = 44;
    public const int OCTET = 31;
    public const int STRING = 22;
    public const int AUTOMATIC = 8;

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

    // $ANTLR start T60 
    public void mT60() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T60;
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
    // $ANTLR end T60

    // $ANTLR start T61 
    public void mT61() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T61;
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
    // $ANTLR end T61

    // $ANTLR start T62 
    public void mT62() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T62;
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
    // $ANTLR end T62

    // $ANTLR start T63 
    public void mT63() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T63;
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
    // $ANTLR end T63

    // $ANTLR start T64 
    public void mT64() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T64;
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
    // $ANTLR end T64

    // $ANTLR start T65 
    public void mT65() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T65;
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
    // $ANTLR end T65

    // $ANTLR start T66 
    public void mT66() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T66;
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
    // $ANTLR end T66

    // $ANTLR start T67 
    public void mT67() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T67;
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
    // $ANTLR end T67

    // $ANTLR start T68 
    public void mT68() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T68;
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
    // $ANTLR end T68

    // $ANTLR start T69 
    public void mT69() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T69;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: ( '+' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: '+'
            {
            	Match('+'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T69

    // $ANTLR start T70 
    public void mT70() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T70;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: ( '-' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: '-'
            {
            	Match('-'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T70

    // $ANTLR start T71 
    public void mT71() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T71;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: ( '<' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: '<'
            {
            	Match('<'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T71

    // $ANTLR start T72 
    public void mT72() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T72;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: ( '..' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: '..'
            {
            	Match(".."); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T72

    // $ANTLR start T73 
    public void mT73() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T73;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ( '...' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: '...'
            {
            	Match("..."); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: ( '.' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: '.'
            {
            	Match('.'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T74

    // $ANTLR start DEFINITIONS 
    public void mDEFINITIONS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = DEFINITIONS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:226:16: ( 'DEFINITIONS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:226:16: 'DEFINITIONS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:228:12: ( 'EXPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:228:12: 'EXPLICIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:230:9: ( 'TAGS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:230:9: 'TAGS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:232:11: ( 'IMPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:232:11: 'IMPLICIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:234:13: ( 'AUTOMATIC' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:234:13: 'AUTOMATIC'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:236:17: ( 'EXTENSIBILITY' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:236:17: 'EXTENSIBILITY'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:238:11: ( 'IMPLIED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:238:11: 'IMPLIED'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:9: ( 'BEGIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:9: 'BEGIN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:241:7: ( 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:241:7: 'END'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:243:11: ( 'EXPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:243:11: 'EXPORTS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:245:8: ( 'ALL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:245:8: 'ALL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:247:11: ( 'IMPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:247:11: 'IMPORTS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:8: ( 'FROM' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:8: 'FROM'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:13: ( 'UNIVERSAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:13: 'UNIVERSAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:252:15: ( 'APPLICATION' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:252:15: 'APPLICATION'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:253:11: ( 'PRIVATE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:253:11: 'PRIVATE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:254:7: ( 'BIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:254:7: 'BIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:10: ( 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:10: 'STRING'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:11: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:11: 'BOOLEAN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:260:13: ( 'ENUMERATED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:260:13: 'ENUMERATED'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:262:11: ( 'INTEGER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:262:11: 'INTEGER'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:8: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:8: 'REAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:266:10: ( 'CHOICE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:266:10: 'CHOICE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:11: ( 'SEQUENCE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:11: 'SEQUENCE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:270:11: ( 'OPTIONAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:270:11: 'OPTIONAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:272:8: ( 'SIZE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:272:8: 'SIZE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:274:6: ( 'OF' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:274:6: 'OF'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:276:9: ( 'OCTET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:276:9: 'OCTET'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:278:8: ( 'MIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:278:8: 'MIN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:280:7: ( 'MAX' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:280:7: 'MAX'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:282:8: ( 'TRUE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:282:8: 'TRUE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:284:9: ( 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:284:9: 'FALSE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:10: ( 'ABSENT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:10: 'ABSENT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:288:11: ( 'PRESENT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:288:11: 'PRESENT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:9: ( 'WITH' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:9: 'WITH'
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

    // $ANTLR start COMPONENTS 
    public void mCOMPONENTS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = COMPONENTS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:291:15: ( 'COMPONENTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:291:15: 'COMPONENTS'
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

    // $ANTLR start NumericString 
    public void mNumericString() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = NumericString;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:293:16: ( 'NumericString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:293:16: 'NumericString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:294:18: ( 'PrintableString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:294:18: 'PrintableString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:295:16: ( 'VisibleString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:295:16: 'VisibleString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:296:12: ( 'IA5String' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:296:12: 'IA5String'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:297:16: ( 'TeletexString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:297:16: 'TeletexString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:298:17: ( 'VideotexString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:298:17: 'VideotexString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:299:16: ( 'GraphicString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:299:16: 'GraphicString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:300:16: ( 'GeneralString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:300:16: 'GeneralString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:18: ( 'UniversalString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:18: 'UniversalString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:302:12: ( 'BMPString' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:302:12: 'BMPString'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:13: ( 'UTF8String' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:13: 'UTF8String'
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

    // $ANTLR start Bstring 
    public void mBstring() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = Bstring;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:2: ( '\\'' ( '0' | '1' )* '\\'B' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:2: '\\'' ( '0' | '1' )* '\\'B'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:7: ( '0' | '1' )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);
            	    
            	    if ( ((LA1_0 >= '0' && LA1_0 <= '1')) )
            	    {
            	        alt1 = 1;
            	    }
            	    
            	
            	    switch (alt1) 
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
            			    goto loop1;
            	    }
            	} while (true);
            	
            	loop1:
            		;	// Stops C# compiler whinging that label 'loop1' has no statements

            	Match("\'B"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end Bstring

    // $ANTLR start Hstring 
    public void mHstring() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = Hstring;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:309:2: ( '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:309:2: '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:309:7: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);
            	    
            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9') || (LA2_0 >= 'A' && LA2_0 <= 'F') || (LA2_0 >= 'a' && LA2_0 <= 'f')) )
            	    {
            	        alt2 = 1;
            	    }
            	    
            	
            	    switch (alt2) 
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
            			    goto loop2;
            	    }
            	} while (true);
            	
            	loop2:
            		;	// Stops C# compiler whinging that label 'loop2' has no statements

            	Match("\'H"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end Hstring

    // $ANTLR start StringLiteral 
    public void mStringLiteral() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = StringLiteral;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:313:19: ( '\"' ( options {greedy=false; } : . )* '\"' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:313:19: '\"' ( options {greedy=false; } : . )* '\"'
            {
            	Match('\"'); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:313:23: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);
            	    
            	    if ( (LA3_0 == '\"') )
            	    {
            	        alt3 = 2;
            	    }
            	    else if ( ((LA3_0 >= '\u0000' && LA3_0 <= '!') || (LA3_0 >= '#' && LA3_0 <= '\uFFFE')) )
            	    {
            	        alt3 = 1;
            	    }
            	    
            	
            	    switch (alt3) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:313:50: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop3;
            	    }
            	} while (true);
            	
            	loop3:
            		;	// Stops C# compiler whinging that label 'loop3' has no statements

            	Match('\"'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end StringLiteral

    // $ANTLR start UID 
    public void mUID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:10: ( ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:10: ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:10: ( 'A' .. 'Z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:11: 'A' .. 'Z'
            	{
            		MatchRange('A','Z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);
            	    
            	    if ( (LA4_0 == '-' || (LA4_0 >= '0' && LA4_0 <= '9') || (LA4_0 >= 'A' && LA4_0 <= 'Z') || (LA4_0 >= 'a' && LA4_0 <= 'z')) )
            	    {
            	        alt4 = 1;
            	    }
            	    
            	
            	    switch (alt4) 
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
            			    goto loop4;
            	    }
            	} while (true);
            	
            	loop4:
            		;	// Stops C# compiler whinging that label 'loop4' has no statements

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:10: ( ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:10: ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:10: ( 'a' .. 'z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:11: 'a' .. 'z'
            	{
            		MatchRange('a','z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);
            	    
            	    if ( (LA5_0 == '-' || (LA5_0 >= '0' && LA5_0 <= '9') || (LA5_0 >= 'A' && LA5_0 <= 'Z') || (LA5_0 >= 'a' && LA5_0 <= 'z')) )
            	    {
            	        alt5 = 1;
            	    }
            	    
            	
            	    switch (alt5) 
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
            			    goto loop5;
            	    }
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
    // $ANTLR end LID

    // $ANTLR start INT 
    public void mINT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = INT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:7: ( ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            	int alt7 = 2;
            	int LA7_0 = input.LA(1);
            	
            	if ( (LA7_0 == '0') )
            	{
            	    alt7 = 1;
            	}
            	else if ( ((LA7_0 >= '1' && LA7_0 <= '9')) )
            	{
            	    alt7 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d7s0 =
            	        new NoViableAltException("321:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )", 7, 0, input);
            	
            	    throw nvae_d7s0;
            	}
            	switch (alt7) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:9: '0'
            	        {
            	        	Match('0'); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:15: ( '1' .. '9' ) ( '0' .. '9' )*
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:15: ( '1' .. '9' )
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:16: '1' .. '9'
            	        	{
            	        		MatchRange('1','9'); 
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:26: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt6 = 2;
            	        	    int LA6_0 = input.LA(1);
            	        	    
            	        	    if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
            	        	    {
            	        	        alt6 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt6) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 
            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop6;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop6:
            	        		;	// Stops C# compiler whinging that label 'loop6' has no statements

            	        
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:9: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            	int cnt8 = 0;
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);
            	    
            	    if ( ((LA8_0 >= '\t' && LA8_0 <= '\n') || LA8_0 == '\r' || LA8_0 == ' ') )
            	    {
            	        alt8 = 1;
            	    }
            	    
            	
            	    switch (alt8) 
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
            			    if ( cnt8 >= 1 ) goto loop8;
            		            EarlyExitException eee =
            		                new EarlyExitException(8, input);
            		            throw eee;
            	    }
            	    cnt8++;
            	} while (true);
            	
            	loop8:
            		;	// Stops C# compiler whinging that label 'loop8' has no statements

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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:9: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);
            	    
            	    if ( (LA9_0 == '*') )
            	    {
            	        int LA9_1 = input.LA(2);
            	        
            	        if ( (LA9_1 == '/') )
            	        {
            	            alt9 = 2;
            	        }
            	        else if ( ((LA9_1 >= '\u0000' && LA9_1 <= '.') || (LA9_1 >= '0' && LA9_1 <= '\uFFFE')) )
            	        {
            	            alt9 = 1;
            	        }
            	        
            	    
            	    }
            	    else if ( ((LA9_0 >= '\u0000' && LA9_0 <= ')') || (LA9_0 >= '+' && LA9_0 <= '\uFFFE')) )
            	    {
            	        alt9 = 1;
            	    }
            	    
            	
            	    switch (alt9) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:42: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop9;
            	    }
            	} while (true);
            	
            	loop9:
            		;	// Stops C# compiler whinging that label 'loop9' has no statements

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

    // $ANTLR start LINE_COMMENT 
    public void mLINE_COMMENT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = LINE_COMMENT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:7: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("--"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);
            	    
            	    if ( ((LA10_0 >= '\u0000' && LA10_0 <= '\t') || (LA10_0 >= '\u000B' && LA10_0 <= '\f') || (LA10_0 >= '\u000E' && LA10_0 <= '\uFFFE')) )
            	    {
            	        alt10 = 1;
            	    }
            	    
            	
            	    switch (alt10) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:12: ~ ( '\\n' | '\\r' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFE') ) 
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
            			    goto loop10;
            	    }
            	} while (true);
            	
            	loop10:
            		;	// Stops C# compiler whinging that label 'loop10' has no statements

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:26: ( '\\r' )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);
            	
            	if ( (LA11_0 == '\r') )
            	{
            	    alt11 = 1;
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:26: '\\r'
            	        {
            	        	Match('\r'); 
            	        
            	        }
            	        break;
            	
            	}

            	Match('\n'); 
            	channel=HIDDEN;
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end LINE_COMMENT

    override public void mTokens() // throws RecognitionException 
    {
        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: ( T60 | T61 | T62 | T63 | T64 | T65 | T66 | T67 | T68 | T69 | T70 | T71 | T72 | T73 | T74 | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | ABSENT | PRESENT | WITH | COMPONENTS | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String | Bstring | Hstring | StringLiteral | UID | LID | INT | WS | COMMENT | LINE_COMMENT )
        int alt12 = 71;
        alt12 = dfa12.Predict(input);
        switch (alt12) 
        {
            case 1 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: T60
                {
                	mT60(); 
                
                }
                break;
            case 2 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:14: T61
                {
                	mT61(); 
                
                }
                break;
            case 3 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:18: T62
                {
                	mT62(); 
                
                }
                break;
            case 4 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:22: T63
                {
                	mT63(); 
                
                }
                break;
            case 5 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:26: T64
                {
                	mT64(); 
                
                }
                break;
            case 6 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:30: T65
                {
                	mT65(); 
                
                }
                break;
            case 7 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:34: T66
                {
                	mT66(); 
                
                }
                break;
            case 8 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:38: T67
                {
                	mT67(); 
                
                }
                break;
            case 9 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:42: T68
                {
                	mT68(); 
                
                }
                break;
            case 10 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:46: T69
                {
                	mT69(); 
                
                }
                break;
            case 11 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:50: T70
                {
                	mT70(); 
                
                }
                break;
            case 12 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:54: T71
                {
                	mT71(); 
                
                }
                break;
            case 13 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:58: T72
                {
                	mT72(); 
                
                }
                break;
            case 14 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:62: T73
                {
                	mT73(); 
                
                }
                break;
            case 15 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:66: T74
                {
                	mT74(); 
                
                }
                break;
            case 16 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:70: DEFINITIONS
                {
                	mDEFINITIONS(); 
                
                }
                break;
            case 17 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:82: EXPLICIT
                {
                	mEXPLICIT(); 
                
                }
                break;
            case 18 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:91: TAGS
                {
                	mTAGS(); 
                
                }
                break;
            case 19 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:96: IMPLICIT
                {
                	mIMPLICIT(); 
                
                }
                break;
            case 20 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:105: AUTOMATIC
                {
                	mAUTOMATIC(); 
                
                }
                break;
            case 21 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:115: EXTENSIBILITY
                {
                	mEXTENSIBILITY(); 
                
                }
                break;
            case 22 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:129: IMPLIED
                {
                	mIMPLIED(); 
                
                }
                break;
            case 23 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:137: BEGIN
                {
                	mBEGIN(); 
                
                }
                break;
            case 24 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:143: END
                {
                	mEND(); 
                
                }
                break;
            case 25 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:147: EXPORTS
                {
                	mEXPORTS(); 
                
                }
                break;
            case 26 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:155: ALL
                {
                	mALL(); 
                
                }
                break;
            case 27 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:159: IMPORTS
                {
                	mIMPORTS(); 
                
                }
                break;
            case 28 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:167: FROM
                {
                	mFROM(); 
                
                }
                break;
            case 29 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:172: UNIVERSAL
                {
                	mUNIVERSAL(); 
                
                }
                break;
            case 30 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:182: APPLICATION
                {
                	mAPPLICATION(); 
                
                }
                break;
            case 31 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:194: PRIVATE
                {
                	mPRIVATE(); 
                
                }
                break;
            case 32 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:202: BIT
                {
                	mBIT(); 
                
                }
                break;
            case 33 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:206: STRING
                {
                	mSTRING(); 
                
                }
                break;
            case 34 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:213: BOOLEAN
                {
                	mBOOLEAN(); 
                
                }
                break;
            case 35 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:221: ENUMERATED
                {
                	mENUMERATED(); 
                
                }
                break;
            case 36 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:232: INTEGER
                {
                	mINTEGER(); 
                
                }
                break;
            case 37 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:240: REAL
                {
                	mREAL(); 
                
                }
                break;
            case 38 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:245: CHOICE
                {
                	mCHOICE(); 
                
                }
                break;
            case 39 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:252: SEQUENCE
                {
                	mSEQUENCE(); 
                
                }
                break;
            case 40 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:261: OPTIONAL
                {
                	mOPTIONAL(); 
                
                }
                break;
            case 41 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:270: SIZE
                {
                	mSIZE(); 
                
                }
                break;
            case 42 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:275: OF
                {
                	mOF(); 
                
                }
                break;
            case 43 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:278: OCTET
                {
                	mOCTET(); 
                
                }
                break;
            case 44 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:284: MIN
                {
                	mMIN(); 
                
                }
                break;
            case 45 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:288: MAX
                {
                	mMAX(); 
                
                }
                break;
            case 46 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:292: TRUE
                {
                	mTRUE(); 
                
                }
                break;
            case 47 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:297: FALSE
                {
                	mFALSE(); 
                
                }
                break;
            case 48 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:303: ABSENT
                {
                	mABSENT(); 
                
                }
                break;
            case 49 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:310: PRESENT
                {
                	mPRESENT(); 
                
                }
                break;
            case 50 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:318: WITH
                {
                	mWITH(); 
                
                }
                break;
            case 51 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:323: COMPONENTS
                {
                	mCOMPONENTS(); 
                
                }
                break;
            case 52 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:334: NumericString
                {
                	mNumericString(); 
                
                }
                break;
            case 53 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:348: PrintableString
                {
                	mPrintableString(); 
                
                }
                break;
            case 54 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:364: VisibleString
                {
                	mVisibleString(); 
                
                }
                break;
            case 55 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:378: IA5String
                {
                	mIA5String(); 
                
                }
                break;
            case 56 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:388: TeletexString
                {
                	mTeletexString(); 
                
                }
                break;
            case 57 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:402: VideotexString
                {
                	mVideotexString(); 
                
                }
                break;
            case 58 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:417: GraphicString
                {
                	mGraphicString(); 
                
                }
                break;
            case 59 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:431: GeneralString
                {
                	mGeneralString(); 
                
                }
                break;
            case 60 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:445: UniversalString
                {
                	mUniversalString(); 
                
                }
                break;
            case 61 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:461: BMPString
                {
                	mBMPString(); 
                
                }
                break;
            case 62 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:471: UTF8String
                {
                	mUTF8String(); 
                
                }
                break;
            case 63 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:482: Bstring
                {
                	mBstring(); 
                
                }
                break;
            case 64 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:490: Hstring
                {
                	mHstring(); 
                
                }
                break;
            case 65 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:498: StringLiteral
                {
                	mStringLiteral(); 
                
                }
                break;
            case 66 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:512: UID
                {
                	mUID(); 
                
                }
                break;
            case 67 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:516: LID
                {
                	mLID(); 
                
                }
                break;
            case 68 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:520: INT
                {
                	mINT(); 
                
                }
                break;
            case 69 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:524: WS
                {
                	mWS(); 
                
                }
                break;
            case 70 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:527: COMMENT
                {
                	mCOMMENT(); 
                
                }
                break;
            case 71 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:535: LINE_COMMENT
                {
                	mLINE_COMMENT(); 
                
                }
                break;
        
        }
    
    }


    protected DFA12 dfa12;
	private void InitializeCyclicDFAs()
	{
	    this.dfa12 = new DFA12(this);
	}

    static readonly short[] DFA12_eot = {
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 40, -1, 42, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 87, -1, 34, 34, 34, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, 34, 34, 121, 34, 34, 34, 34, 34, 34, 
        34, 34, 34, -1, -1, -1, -1, -1, 34, 34, 34, 34, 138, 34, 34, 34, 
        34, 34, 34, 146, 34, 34, 34, 34, 34, 34, 153, 34, 34, 34, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, 34, 34, -1, 34, 34, 170, 171, 34, 34, 
        34, 34, 34, 34, -1, 34, 34, 34, 34, 34, -1, 183, 184, 34, 34, 34, 
        34, 34, -1, 34, 34, 34, 34, 34, 34, -1, 196, 34, 34, 34, 34, 34, 
        34, 34, 34, 34, 206, 207, 34, 34, 34, 34, -1, -1, 212, 34, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, -1, -1, 34, 34, 34, 34, 34, 34, 34, 
        34, 232, 34, 34, -1, 235, 34, 34, 34, 34, 34, 34, 34, 34, -1, -1, 
        34, 34, 34, 247, -1, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
        34, 34, 34, 34, 34, 34, 34, 266, -1, 34, 34, -1, 34, 34, 34, 34, 
        34, 34, 34, 276, 277, 34, 34, -1, 34, 34, 34, 34, 34, 34, 34, 287, 
        34, 34, 34, 34, 292, 293, 294, 34, 34, 34, -1, 34, 299, 34, 34, 
        34, 303, 304, 34, 34, -1, -1, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
        -1, 316, 34, 34, 319, -1, -1, -1, 34, 34, 34, 34, -1, 34, 34, 34, 
        -1, -1, 34, 328, 34, 330, 34, 34, 34, 34, 34, 34, 34, -1, 34, 34, 
        -1, 340, 341, 34, 343, 34, 34, 346, 34, -1, 34, -1, 34, 34, 34, 
        34, 34, 34, 34, 356, 34, -1, -1, 34, -1, 359, 34, -1, 34, 362, 34, 
        34, 34, 34, 34, 368, 34, -1, 34, 371, -1, 34, 34, -1, 34, 34, 34, 
        34, 34, -1, 34, 34, -1, 34, 34, 34, 34, 34, 34, 34, 388, 389, 34, 
        34, 392, 393, 34, 395, 396, -1, -1, 34, 34, -1, -1, 399, -1, -1, 
        400, 401, -1, -1, -1
        };
    static readonly short[] DFA12_eof = {
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
        -1, -1
        };
    static readonly int[] DFA12_min = {
        9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 46, 69, 78, 65, 65, 66, 
        69, 65, 78, 82, 69, 69, 72, 67, 65, 73, 117, 105, 101, 39, 0, 0, 
        0, 0, 0, 0, 0, 0, 46, 0, 70, 80, 68, 71, 85, 108, 80, 84, 53, 76, 
        84, 80, 83, 71, 80, 79, 84, 79, 76, 70, 105, 73, 69, 105, 81, 82, 
        90, 65, 79, 77, 45, 84, 84, 88, 78, 84, 109, 100, 110, 97, 39, 66, 
        0, 0, 0, 73, 69, 76, 77, 45, 83, 69, 101, 76, 69, 83, 45, 79, 76, 
        69, 73, 83, 76, 45, 77, 83, 56, 118, 86, 86, 83, 110, 85, 73, 69, 
        76, 73, 80, 0, 73, 69, 45, 45, 72, 101, 105, 101, 101, 112, 0, 78, 
        78, 82, 73, 69, 0, 45, 45, 116, 73, 82, 71, 116, 0, 77, 73, 78, 
        78, 116, 69, 0, 45, 69, 83, 101, 69, 65, 69, 116, 69, 78, 45, 45, 
        67, 79, 79, 84, 0, 0, 45, 114, 98, 111, 114, 104, 73, 83, 84, 67, 
        82, 0, 0, 101, 67, 84, 69, 114, 65, 67, 84, 45, 114, 65, 0, 45, 
        116, 114, 82, 84, 78, 97, 78, 71, 0, 0, 69, 78, 78, 45, 0, 105, 
        108, 116, 97, 105, 84, 73, 83, 73, 65, 120, 73, 68, 83, 82, 105, 
        84, 65, 45, 0, 105, 78, 0, 114, 115, 83, 69, 84, 98, 67, 45, 45, 
        69, 65, 0, 99, 101, 101, 108, 99, 73, 66, 45, 84, 84, 83, 84, 45, 
        45, 45, 110, 73, 84, 0, 110, 45, 105, 97, 65, 45, 45, 108, 69, 0, 
        0, 78, 76, 83, 83, 120, 83, 83, 79, 73, 0, 45, 69, 116, 45, 0, 0, 
        0, 103, 67, 73, 103, 0, 110, 108, 76, 0, 0, 101, 45, 84, 45, 116, 
        116, 83, 116, 116, 78, 76, 0, 68, 114, 0, 45, 45, 79, 45, 103, 83, 
        45, 83, 0, 83, 0, 114, 114, 116, 114, 114, 83, 73, 45, 105, 0, 0, 
        78, 0, 45, 116, 0, 116, 45, 105, 105, 114, 105, 105, 45, 84, 0, 
        110, 45, 0, 114, 114, 0, 110, 110, 105, 110, 110, 0, 89, 103, 0, 
        105, 105, 103, 103, 110, 103, 103, 45, 45, 110, 110, 45, 45, 103, 
        45, 45, 0, 0, 103, 103, 0, 0, 45, 0, 0, 45, 45, 0, 0, 0
        };
    static readonly int[] DFA12_max = {
        125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 46, 69, 88, 101, 78, 85, 
        79, 82, 110, 114, 84, 69, 79, 80, 73, 73, 117, 105, 114, 102, 0, 
        0, 0, 0, 0, 0, 0, 0, 46, 0, 70, 84, 85, 71, 85, 108, 80, 84, 53, 
        76, 84, 80, 83, 71, 80, 79, 84, 79, 76, 70, 105, 73, 73, 105, 81, 
        82, 90, 65, 79, 77, 122, 84, 84, 88, 78, 84, 109, 115, 110, 97, 
        102, 72, 0, 0, 0, 73, 69, 79, 77, 122, 83, 69, 101, 79, 69, 83, 
        122, 79, 76, 69, 73, 83, 76, 122, 77, 83, 56, 118, 86, 86, 83, 110, 
        85, 73, 69, 76, 73, 80, 0, 73, 69, 122, 122, 72, 101, 105, 101, 
        101, 112, 0, 78, 78, 82, 73, 69, 0, 122, 122, 116, 73, 82, 71, 116, 
        0, 77, 73, 78, 78, 116, 69, 0, 122, 69, 83, 101, 69, 65, 69, 116, 
        69, 78, 122, 122, 67, 79, 79, 84, 0, 0, 122, 114, 98, 111, 114, 
        104, 73, 83, 84, 67, 82, 0, 0, 101, 69, 84, 69, 114, 65, 67, 84, 
        122, 114, 65, 0, 122, 116, 114, 82, 84, 78, 97, 78, 71, 0, 0, 69, 
        78, 78, 122, 0, 105, 108, 116, 97, 105, 84, 73, 83, 73, 65, 120, 
        73, 68, 83, 82, 105, 84, 65, 122, 0, 105, 78, 0, 114, 115, 83, 69, 
        84, 98, 67, 122, 122, 69, 65, 0, 99, 101, 101, 108, 99, 73, 66, 
        122, 84, 84, 83, 84, 122, 122, 122, 110, 73, 84, 0, 110, 122, 105, 
        97, 65, 122, 122, 108, 69, 0, 0, 78, 76, 83, 83, 120, 83, 83, 79, 
        73, 0, 122, 69, 116, 122, 0, 0, 0, 103, 67, 73, 103, 0, 110, 108, 
        76, 0, 0, 101, 122, 84, 122, 116, 116, 83, 116, 116, 78, 76, 0, 
        68, 114, 0, 122, 122, 79, 122, 103, 83, 122, 83, 0, 83, 0, 114, 
        114, 116, 114, 114, 83, 73, 122, 105, 0, 0, 78, 0, 122, 116, 0, 
        116, 122, 105, 105, 114, 105, 105, 122, 84, 0, 110, 122, 0, 114, 
        114, 0, 110, 110, 105, 110, 110, 0, 89, 103, 0, 105, 105, 103, 103, 
        110, 103, 103, 122, 122, 110, 110, 122, 122, 103, 122, 122, 0, 0, 
        103, 103, 0, 0, 122, 0, 0, 122, 122, 0, 0, 0
        };
    static readonly short[] DFA12_accept = {
        -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, 12, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 65, 66, 
        67, 68, 69, 70, 71, 11, -1, 15, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, 64, 14, 13, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, 42, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 63, -1, -1, -1, -1, -1, 24, -1, -1, -1, -1, -1, -1, -1, 26, 
        -1, -1, -1, -1, -1, -1, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, 45, 44, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, 18, 46, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 28, -1, -1, -1, -1, -1, -1, -1, -1, -1, 41, 37, -1, -1, -1, 
        -1, 50, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, 23, -1, -1, 47, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, 43, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, 48, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 33, 38, -1, -1, -1, -1, -1, -1, -1, -1, -1, 25, -1, -1, -1, 
        -1, 22, 27, 36, -1, -1, -1, -1, 34, -1, -1, -1, 31, 49, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 17, -1, -1, 19, -1, -1, -1, 
        -1, -1, -1, -1, -1, 39, -1, 40, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 55, 20, -1, 61, -1, -1, 29, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 35, -1, -1, 62, -1, -1, 51, -1, -1, -1, -1, -1, 16, -1, -1, 
        30, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 21, 56, -1, -1, 52, 54, -1, 59, 58, -1, -1, 57, 60, 53
        };
    static readonly short[] DFA12_special = {
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
        -1, -1
        };
    
    static readonly short[] dfa12_transition_null = null;

    static readonly short[] dfa12_transition0 = {
    	34, -1, -1, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, -1, -1, -1, -1, 
    	    -1, -1, -1, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
    	    34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, -1, -1, -1, 
    	    -1, -1, -1, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 
    	    34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34
    	};
    static readonly short[] dfa12_transition1 = {
    	129, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 128
    	};
    static readonly short[] dfa12_transition2 = {
    	51, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 49, 50
    	};
    static readonly short[] dfa12_transition3 = {
    	84, -1, -1, -1, -1, -1, -1, -1, -1, 83, 83, 85, 85, 85, 85, 85, 85, 
    	    85, 85, -1, -1, -1, -1, -1, -1, -1, 85, 85, 85, 85, 85, 85, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, 85, 85, 85, 85, 85, 85
    	};
    static readonly short[] dfa12_transition4 = {
    	259
    	};
    static readonly short[] dfa12_transition5 = {
    	291
    	};
    static readonly short[] dfa12_transition6 = {
    	296
    	};
    static readonly short[] dfa12_transition7 = {
    	264
    	};
    static readonly short[] dfa12_transition8 = {
    	321
    	};
    static readonly short[] dfa12_transition9 = {
    	147
    	};
    static readonly short[] dfa12_transition10 = {
    	100
    	};
    static readonly short[] dfa12_transition11 = {
    	229
    	};
    static readonly short[] dfa12_transition12 = {
    	190
    	};
    static readonly short[] dfa12_transition13 = {
    	93
    	};
    static readonly short[] dfa12_transition14 = {
    	139
    	};
    static readonly short[] dfa12_transition15 = {
    	288
    	};
    static readonly short[] dfa12_transition16 = {
    	354
    	};
    static readonly short[] dfa12_transition17 = {
    	336
    	};
    static readonly short[] dfa12_transition18 = {
    	314
    	};
    static readonly short[] dfa12_transition19 = {
    	285
    	};
    static readonly short[] dfa12_transition20 = {
    	253
    	};
    static readonly short[] dfa12_transition21 = {
    	218
    	};
    static readonly short[] dfa12_transition22 = {
    	256
    	};
    static readonly short[] dfa12_transition23 = {
    	221
    	};
    static readonly short[] dfa12_transition24 = {
    	181
    	};
    static readonly short[] dfa12_transition25 = {
    	133
    	};
    static readonly short[] dfa12_transition26 = {
    	178
    	};
    static readonly short[] dfa12_transition27 = {
    	88
    	};
    static readonly short[] dfa12_transition28 = {
    	79
    	};
    static readonly short[] dfa12_transition29 = {
    	78
    	};
    static readonly short[] dfa12_transition30 = {
    	41
    	};
    static readonly short[] dfa12_transition31 = {
    	70
    	};
    static readonly short[] dfa12_transition32 = {
    	86
    	};
    static readonly short[] dfa12_transition33 = {
    	90, -1, -1, -1, 89
    	};
    static readonly short[] dfa12_transition34 = {
    	113, -1, -1, -1, 112
    	};
    static readonly short[] dfa12_transition35 = {
    	132, -1, -1, -1, -1, -1, 85
    	};
    static readonly short[] dfa12_transition36 = {
    	142, -1, -1, 143
    	};
    static readonly short[] dfa12_transition37 = {
    	96
    	};
    static readonly short[] dfa12_transition38 = {
    	95
    	};
    static readonly short[] dfa12_transition39 = {
    	223
    	};
    static readonly short[] dfa12_transition40 = {
    	258
    	};
    static readonly short[] dfa12_transition41 = {
    	141
    	};
    static readonly short[] dfa12_transition42 = {
    	185
    	};
    static readonly short[] dfa12_transition43 = {
    	228
    	};
    static readonly short[] dfa12_transition44 = {
    	263
    	};
    static readonly short[] dfa12_transition45 = {
    	145
    	};
    static readonly short[] dfa12_transition46 = {
    	189
    	};
    static readonly short[] dfa12_transition47 = {
    	295
    	};
    static readonly short[] dfa12_transition48 = {
    	320
    	};
    static readonly short[] dfa12_transition49 = {
    	75, -1, -1, 73, -1, -1, -1, -1, -1, -1, -1, -1, -1, 74
    	};
    static readonly short[] dfa12_transition50 = {
    	384
    	};
    static readonly short[] dfa12_transition51 = {
    	375
    	};
    static readonly short[] dfa12_transition52 = {
    	98
    	};
    static readonly short[] dfa12_transition53 = {
    	281
    	};
    static readonly short[] dfa12_transition54 = {
    	249
    	};
    static readonly short[] dfa12_transition55 = {
    	214
    	};
    static readonly short[] dfa12_transition56 = {
    	174
    	};
    static readonly short[] dfa12_transition57 = {
    	364
    	};
    static readonly short[] dfa12_transition58 = {
    	350
    	};
    static readonly short[] dfa12_transition59 = {
    	332
    	};
    static readonly short[] dfa12_transition60 = {
    	310
    	};
    static readonly short[] dfa12_transition61 = {
    	131
    	};
    static readonly short[] dfa12_transition62 = {
    	177
    	};
    static readonly short[] dfa12_transition63 = {
    	217
    	};
    static readonly short[] dfa12_transition64 = {
    	252
    	};
    static readonly short[] dfa12_transition65 = {
    	67, -1, -1, -1, 69, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 68
    	};
    static readonly short[] dfa12_transition66 = {
    	311
    	};
    static readonly short[] dfa12_transition67 = {
    	333
    	};
    static readonly short[] dfa12_transition68 = {
    	351
    	};
    static readonly short[] dfa12_transition69 = {
    	365
    	};
    static readonly short[] dfa12_transition70 = {
    	376
    	};
    static readonly short[] dfa12_transition71 = {
    	385
    	};
    static readonly short[] dfa12_transition72 = {
    	394
    	};
    static readonly short[] dfa12_transition73 = {
    	215
    	};
    static readonly short[] dfa12_transition74 = {
    	175
    	};
    static readonly short[] dfa12_transition75 = {
    	282
    	};
    static readonly short[] dfa12_transition76 = {
    	43
    	};
    static readonly short[] dfa12_transition77 = {
    	250
    	};
    static readonly short[] dfa12_transition78 = {
    	318
    	};
    static readonly short[] dfa12_transition79 = {
    	55, -1, -1, -1, -1, -1, -1, -1, -1, -1, 52, -1, -1, -1, 54, -1, -1, 
    	    -1, -1, 53
    	};
    static readonly short[] dfa12_transition80 = {
    	290
    	};
    static readonly short[] dfa12_transition81 = {
    	81, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 82
    	};
    static readonly short[] dfa12_transition82 = {
    	357
    	};
    static readonly short[] dfa12_transition83 = {
    	339
    	};
    static readonly short[] dfa12_transition84 = {
    	380
    	};
    static readonly short[] dfa12_transition85 = {
    	370
    	};
    static readonly short[] dfa12_transition86 = {
    	173
    	};
    static readonly short[] dfa12_transition87 = {
    	213
    	};
    static readonly short[] dfa12_transition88 = {
    	127
    	};
    static readonly short[] dfa12_transition89 = {
    	329
    	};
    static readonly short[] dfa12_transition90 = {
    	348
    	};
    static readonly short[] dfa12_transition91 = {
    	278
    	};
    static readonly short[] dfa12_transition92 = {
    	307
    	};
    static readonly short[] dfa12_transition93 = {
    	209
    	};
    static readonly short[] dfa12_transition94 = {
    	245
    	};
    static readonly short[] dfa12_transition95 = {
    	120
    	};
    static readonly short[] dfa12_transition96 = {
    	136, -1, -1, 135
    	};
    static readonly short[] dfa12_transition97 = {
    	167
    	};
    static readonly short[] dfa12_transition98 = {
    	224, -1, 225
    	};
    static readonly short[] dfa12_transition99 = {
    	186
    	};
    static readonly short[] dfa12_transition100 = {
    	172
    	};
    static readonly short[] dfa12_transition101 = {
    	126
    	};
    static readonly short[] dfa12_transition102 = {
    	80
    	};
    static readonly short[] dfa12_transition103 = {
    	273
    	};
    static readonly short[] dfa12_transition104 = {
    	240
    	};
    static readonly short[] dfa12_transition105 = {
    	202
    	};
    static readonly short[] dfa12_transition106 = {
    	160
    	};
    static readonly short[] dfa12_transition107 = {
    	46, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    47, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, 48
    	};
    static readonly short[] dfa12_transition108 = {
    	391
    	};
    static readonly short[] dfa12_transition109 = {
    	398
    	};
    static readonly short[] dfa12_transition110 = {
    	347
    	};
    static readonly short[] dfa12_transition111 = {
    	361
    	};
    static readonly short[] dfa12_transition112 = {
    	373
    	};
    static readonly short[] dfa12_transition113 = {
    	37, 37, -1, -1, 37, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, 37, -1, 33, -1, -1, -1, -1, 32, 4, 5, -1, 
    	    10, 7, 11, 13, 38, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 1, 6, 
    	    12, -1, -1, -1, -1, 18, 19, 25, 14, 15, 20, 31, 34, 17, 34, 34, 
    	    34, 27, 29, 26, 22, 34, 24, 23, 16, 21, 30, 28, 34, 34, 34, 8, 
    	    -1, 9, -1, -1, -1, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 
    	    35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 35, 2, 
    	    -1, 3
    	};
    static readonly short[] dfa12_transition114 = {
    	382
    	};
    static readonly short[] dfa12_transition115 = {
    	241
    	};
    static readonly short[] dfa12_transition116 = {
    	274
    	};
    static readonly short[] dfa12_transition117 = {
    	305
    	};
    static readonly short[] dfa12_transition118 = {
    	327
    	};
    static readonly short[] dfa12_transition119 = {
    	114
    	};
    static readonly short[] dfa12_transition120 = {
    	203
    	};
    static readonly short[] dfa12_transition121 = {
    	161
    	};
    static readonly short[] dfa12_transition122 = {
    	363
    	};
    static readonly short[] dfa12_transition123 = {
    	349
    	};
    static readonly short[] dfa12_transition124 = {
    	383
    	};
    static readonly short[] dfa12_transition125 = {
    	374
    	};
    static readonly short[] dfa12_transition126 = {
    	280
    	};
    static readonly short[] dfa12_transition127 = {
    	248
    	};
    static readonly short[] dfa12_transition128 = {
    	331
    	};
    static readonly short[] dfa12_transition129 = {
    	309
    	};
    static readonly short[] dfa12_transition130 = {
    	45, -1, -1, -1, -1, -1, -1, -1, -1, -1, 44
    	};
    static readonly short[] dfa12_transition131 = {
    	324
    	};
    static readonly short[] dfa12_transition132 = {
    	344
    	};
    static readonly short[] dfa12_transition133 = {
    	386
    	};
    static readonly short[] dfa12_transition134 = {
    	377
    	};
    static readonly short[] dfa12_transition135 = {
    	366
    	};
    static readonly short[] dfa12_transition136 = {
    	352
    	};
    static readonly short[] dfa12_transition137 = {
    	334
    	};
    static readonly short[] dfa12_transition138 = {
    	312
    	};
    static readonly short[] dfa12_transition139 = {
    	65, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 66
    	};
    static readonly short[] dfa12_transition140 = {
    	283
    	};
    static readonly short[] dfa12_transition141 = {
    	237
    	};
    static readonly short[] dfa12_transition142 = {
    	199
    	};
    static readonly short[] dfa12_transition143 = {
    	157
    	};
    static readonly short[] dfa12_transition144 = {
    	110
    	};
    static readonly short[] dfa12_transition145 = {
    	387
    	};
    static readonly short[] dfa12_transition146 = {
    	367
    	};
    static readonly short[] dfa12_transition147 = {
    	378
    	};
    static readonly short[] dfa12_transition148 = {
    	335
    	};
    static readonly short[] dfa12_transition149 = {
    	353
    	};
    static readonly short[] dfa12_transition150 = {
    	284
    	};
    static readonly short[] dfa12_transition151 = {
    	313
    	};
    static readonly short[] dfa12_transition152 = {
    	216
    	};
    static readonly short[] dfa12_transition153 = {
    	251
    	};
    static readonly short[] dfa12_transition154 = {
    	130
    	};
    static readonly short[] dfa12_transition155 = {
    	176
    	};
    static readonly short[] dfa12_transition156 = {
    	323
    	};
    static readonly short[] dfa12_transition157 = {
    	92, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    91
    	};
    static readonly short[] dfa12_transition158 = {
    	233
    	};
    static readonly short[] dfa12_transition159 = {
    	194
    	};
    static readonly short[] dfa12_transition160 = {
    	298
    	};
    static readonly short[] dfa12_transition161 = {
    	267
    	};
    static readonly short[] dfa12_transition162 = {
    	236
    	};
    static readonly short[] dfa12_transition163 = {
    	198
    	};
    static readonly short[] dfa12_transition164 = {
    	300
    	};
    static readonly short[] dfa12_transition165 = {
    	269
    	};
    static readonly short[] dfa12_transition166 = {
    	156
    	};
    static readonly short[] dfa12_transition167 = {
    	109
    	};
    static readonly short[] dfa12_transition168 = {
    	360
    	};
    static readonly short[] dfa12_transition169 = {
    	372
    	};
    static readonly short[] dfa12_transition170 = {
    	381
    	};
    static readonly short[] dfa12_transition171 = {
    	390
    	};
    static readonly short[] dfa12_transition172 = {
    	270
    	};
    static readonly short[] dfa12_transition173 = {
    	301
    	};
    static readonly short[] dfa12_transition174 = {
    	325
    	};
    static readonly short[] dfa12_transition175 = {
    	345
    	};
    static readonly short[] dfa12_transition176 = {
    	104
    	};
    static readonly short[] dfa12_transition177 = {
    	151
    	};
    static readonly short[] dfa12_transition178 = {
    	397
    	};
    static readonly short[] dfa12_transition179 = {
    	111
    	};
    static readonly short[] dfa12_transition180 = {
    	200
    	};
    static readonly short[] dfa12_transition181 = {
    	158
    	};
    static readonly short[] dfa12_transition182 = {
    	261
    	};
    static readonly short[] dfa12_transition183 = {
    	154
    	};
    static readonly short[] dfa12_transition184 = {
    	107
    	};
    static readonly short[] dfa12_transition185 = {
    	101
    	};
    static readonly short[] dfa12_transition186 = {
    	148
    	};
    static readonly short[] dfa12_transition187 = {
    	191
    	};
    static readonly short[] dfa12_transition188 = {
    	230
    	};
    static readonly short[] dfa12_transition189 = {
    	265
    	};
    static readonly short[] dfa12_transition190 = {
    	297
    	};
    static readonly short[] dfa12_transition191 = {
    	322
    	};
    static readonly short[] dfa12_transition192 = {
    	238
    	};
    static readonly short[] dfa12_transition193 = {
    	271
    	};
    static readonly short[] dfa12_transition194 = {
    	302
    	};
    static readonly short[] dfa12_transition195 = {
    	326
    	};
    static readonly short[] dfa12_transition196 = {
    	272
    	};
    static readonly short[] dfa12_transition197 = {
    	239
    	};
    static readonly short[] dfa12_transition198 = {
    	201
    	};
    static readonly short[] dfa12_transition199 = {
    	159
    	};
    static readonly short[] dfa12_transition200 = {
    	358
    	};
    static readonly short[] dfa12_transition201 = {
    	342
    	};
    static readonly short[] dfa12_transition202 = {
    	243
    	};
    static readonly short[] dfa12_transition203 = {
    	163
    	};
    static readonly short[] dfa12_transition204 = {
    	205
    	};
    static readonly short[] dfa12_transition205 = {
    	106
    	};
    static readonly short[] dfa12_transition206 = {
    	116
    	};
    static readonly short[] dfa12_transition207 = {
    	369
    	};
    static readonly short[] dfa12_transition208 = {
    	355
    	};
    static readonly short[] dfa12_transition209 = {
    	379
    	};
    static readonly short[] dfa12_transition210 = {
    	286
    	};
    static readonly short[] dfa12_transition211 = {
    	254
    	};
    static readonly short[] dfa12_transition212 = {
    	337
    	};
    static readonly short[] dfa12_transition213 = {
    	315
    	};
    static readonly short[] dfa12_transition214 = {
    	134
    	};
    static readonly short[] dfa12_transition215 = {
    	219
    	};
    static readonly short[] dfa12_transition216 = {
    	179
    	};
    static readonly short[] dfa12_transition217 = {
    	103
    	};
    static readonly short[] dfa12_transition218 = {
    	150
    	};
    static readonly short[] dfa12_transition219 = {
    	260
    	};
    static readonly short[] dfa12_transition220 = {
    	220
    	};
    static readonly short[] dfa12_transition221 = {
    	180
    	};
    static readonly short[] dfa12_transition222 = {
    	193
    	};
    static readonly short[] dfa12_transition223 = {
    	187
    	};
    static readonly short[] dfa12_transition224 = {
    	226
    	};
    static readonly short[] dfa12_transition225 = {
    	99
    	};
    static readonly short[] dfa12_transition226 = {
    	76, -1, -1, -1, -1, -1, -1, -1, 77
    	};
    static readonly short[] dfa12_transition227 = {
    	71, -1, -1, -1, -1, -1, -1, 72
    	};
    static readonly short[] dfa12_transition228 = {
    	255
    	};
    static readonly short[] dfa12_transition229 = {
    	279
    	};
    static readonly short[] dfa12_transition230 = {
    	308
    	};
    static readonly short[] dfa12_transition231 = {
    	117
    	};
    static readonly short[] dfa12_transition232 = {
    	164
    	};
    static readonly short[] dfa12_transition233 = {
    	123
    	};
    static readonly short[] dfa12_transition234 = {
    	211
    	};
    static readonly short[] dfa12_transition235 = {
    	169
    	};
    static readonly short[] dfa12_transition236 = {
    	125
    	};
    static readonly short[] dfa12_transition237 = {
    	124
    	};
    static readonly short[] dfa12_transition238 = {
    	94
    	};
    static readonly short[] dfa12_transition239 = {
    	140
    	};
    static readonly short[] dfa12_transition240 = {
    	108
    	};
    static readonly short[] dfa12_transition241 = {
    	155
    	};
    static readonly short[] dfa12_transition242 = {
    	197
    	};
    static readonly short[] dfa12_transition243 = {
    	149
    	};
    static readonly short[] dfa12_transition244 = {
    	102
    	};
    static readonly short[] dfa12_transition245 = {
    	231
    	};
    static readonly short[] dfa12_transition246 = {
    	192
    	};
    static readonly short[] dfa12_transition247 = {
    	268
    	};
    static readonly short[] dfa12_transition248 = {
    	64, -1, -1, -1, -1, -1, 62, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 63
    	};
    static readonly short[] dfa12_transition249 = {
    	105
    	};
    static readonly short[] dfa12_transition250 = {
    	152
    	};
    static readonly short[] dfa12_transition251 = {
    	195
    	};
    static readonly short[] dfa12_transition252 = {
    	234
    	};
    static readonly short[] dfa12_transition253 = {
    	182
    	};
    static readonly short[] dfa12_transition254 = {
    	222
    	};
    static readonly short[] dfa12_transition255 = {
    	257
    	};
    static readonly short[] dfa12_transition256 = {
    	289
    	};
    static readonly short[] dfa12_transition257 = {
    	137
    	};
    static readonly short[] dfa12_transition258 = {
    	97
    	};
    static readonly short[] dfa12_transition259 = {
    	338
    	};
    static readonly short[] dfa12_transition260 = {
    	317
    	};
    static readonly short[] dfa12_transition261 = {
    	188
    	};
    static readonly short[] dfa12_transition262 = {
    	144
    	};
    static readonly short[] dfa12_transition263 = {
    	262
    	};
    static readonly short[] dfa12_transition264 = {
    	227
    	};
    static readonly short[] dfa12_transition265 = {
    	165
    	};
    static readonly short[] dfa12_transition266 = {
    	56, -1, -1, -1, 59, -1, -1, -1, 57, -1, 58
    	};
    static readonly short[] dfa12_transition267 = {
    	118
    	};
    static readonly short[] dfa12_transition268 = {
    	208
    	};
    static readonly short[] dfa12_transition269 = {
    	39
    	};
    static readonly short[] dfa12_transition270 = {
    	244
    	};
    static readonly short[] dfa12_transition271 = {
    	119
    	};
    static readonly short[] dfa12_transition272 = {
    	166
    	};
    static readonly short[] dfa12_transition273 = {
    	306
    	};
    static readonly short[] dfa12_transition274 = {
    	275
    	};
    static readonly short[] dfa12_transition275 = {
    	242
    	};
    static readonly short[] dfa12_transition276 = {
    	204
    	};
    static readonly short[] dfa12_transition277 = {
    	162
    	};
    static readonly short[] dfa12_transition278 = {
    	115
    	};
    static readonly short[] dfa12_transition279 = {
    	61, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    60
    	};
    static readonly short[] dfa12_transition280 = {
    	246
    	};
    static readonly short[] dfa12_transition281 = {
    	210
    	};
    static readonly short[] dfa12_transition282 = {
    	168
    	};
    static readonly short[] dfa12_transition283 = {
    	122
    	};
    
    static readonly short[][] DFA12_transition = {
    	dfa12_transition113,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition269,
    	dfa12_transition_null,
    	dfa12_transition30,
    	dfa12_transition76,
    	dfa12_transition130,
    	dfa12_transition107,
    	dfa12_transition2,
    	dfa12_transition79,
    	dfa12_transition266,
    	dfa12_transition279,
    	dfa12_transition248,
    	dfa12_transition139,
    	dfa12_transition65,
    	dfa12_transition31,
    	dfa12_transition227,
    	dfa12_transition49,
    	dfa12_transition226,
    	dfa12_transition29,
    	dfa12_transition28,
    	dfa12_transition102,
    	dfa12_transition81,
    	dfa12_transition3,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition32,
    	dfa12_transition_null,
    	dfa12_transition27,
    	dfa12_transition33,
    	dfa12_transition157,
    	dfa12_transition13,
    	dfa12_transition238,
    	dfa12_transition38,
    	dfa12_transition37,
    	dfa12_transition258,
    	dfa12_transition52,
    	dfa12_transition225,
    	dfa12_transition10,
    	dfa12_transition185,
    	dfa12_transition244,
    	dfa12_transition217,
    	dfa12_transition176,
    	dfa12_transition249,
    	dfa12_transition205,
    	dfa12_transition184,
    	dfa12_transition240,
    	dfa12_transition167,
    	dfa12_transition144,
    	dfa12_transition179,
    	dfa12_transition34,
    	dfa12_transition119,
    	dfa12_transition278,
    	dfa12_transition206,
    	dfa12_transition231,
    	dfa12_transition267,
    	dfa12_transition271,
    	dfa12_transition95,
    	dfa12_transition0,
    	dfa12_transition283,
    	dfa12_transition233,
    	dfa12_transition237,
    	dfa12_transition236,
    	dfa12_transition101,
    	dfa12_transition88,
    	dfa12_transition1,
    	dfa12_transition154,
    	dfa12_transition61,
    	dfa12_transition3,
    	dfa12_transition35,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition25,
    	dfa12_transition214,
    	dfa12_transition96,
    	dfa12_transition257,
    	dfa12_transition0,
    	dfa12_transition14,
    	dfa12_transition239,
    	dfa12_transition41,
    	dfa12_transition36,
    	dfa12_transition262,
    	dfa12_transition45,
    	dfa12_transition0,
    	dfa12_transition9,
    	dfa12_transition186,
    	dfa12_transition243,
    	dfa12_transition218,
    	dfa12_transition177,
    	dfa12_transition250,
    	dfa12_transition0,
    	dfa12_transition183,
    	dfa12_transition241,
    	dfa12_transition166,
    	dfa12_transition143,
    	dfa12_transition181,
    	dfa12_transition199,
    	dfa12_transition106,
    	dfa12_transition121,
    	dfa12_transition277,
    	dfa12_transition203,
    	dfa12_transition232,
    	dfa12_transition265,
    	dfa12_transition272,
    	dfa12_transition97,
    	dfa12_transition_null,
    	dfa12_transition282,
    	dfa12_transition235,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition100,
    	dfa12_transition86,
    	dfa12_transition56,
    	dfa12_transition74,
    	dfa12_transition155,
    	dfa12_transition62,
    	dfa12_transition_null,
    	dfa12_transition26,
    	dfa12_transition216,
    	dfa12_transition221,
    	dfa12_transition24,
    	dfa12_transition253,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition42,
    	dfa12_transition99,
    	dfa12_transition223,
    	dfa12_transition261,
    	dfa12_transition46,
    	dfa12_transition_null,
    	dfa12_transition12,
    	dfa12_transition187,
    	dfa12_transition246,
    	dfa12_transition222,
    	dfa12_transition159,
    	dfa12_transition251,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition242,
    	dfa12_transition163,
    	dfa12_transition142,
    	dfa12_transition180,
    	dfa12_transition198,
    	dfa12_transition105,
    	dfa12_transition120,
    	dfa12_transition276,
    	dfa12_transition204,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition268,
    	dfa12_transition93,
    	dfa12_transition281,
    	dfa12_transition234,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition87,
    	dfa12_transition55,
    	dfa12_transition73,
    	dfa12_transition152,
    	dfa12_transition63,
    	dfa12_transition21,
    	dfa12_transition215,
    	dfa12_transition220,
    	dfa12_transition23,
    	dfa12_transition254,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition39,
    	dfa12_transition98,
    	dfa12_transition224,
    	dfa12_transition264,
    	dfa12_transition43,
    	dfa12_transition11,
    	dfa12_transition188,
    	dfa12_transition245,
    	dfa12_transition0,
    	dfa12_transition158,
    	dfa12_transition252,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition162,
    	dfa12_transition141,
    	dfa12_transition192,
    	dfa12_transition197,
    	dfa12_transition104,
    	dfa12_transition115,
    	dfa12_transition275,
    	dfa12_transition202,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition270,
    	dfa12_transition94,
    	dfa12_transition280,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition127,
    	dfa12_transition54,
    	dfa12_transition77,
    	dfa12_transition153,
    	dfa12_transition64,
    	dfa12_transition20,
    	dfa12_transition211,
    	dfa12_transition228,
    	dfa12_transition22,
    	dfa12_transition255,
    	dfa12_transition40,
    	dfa12_transition4,
    	dfa12_transition219,
    	dfa12_transition182,
    	dfa12_transition263,
    	dfa12_transition44,
    	dfa12_transition7,
    	dfa12_transition189,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition161,
    	dfa12_transition247,
    	dfa12_transition_null,
    	dfa12_transition165,
    	dfa12_transition172,
    	dfa12_transition193,
    	dfa12_transition196,
    	dfa12_transition103,
    	dfa12_transition116,
    	dfa12_transition274,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition91,
    	dfa12_transition229,
    	dfa12_transition_null,
    	dfa12_transition126,
    	dfa12_transition53,
    	dfa12_transition75,
    	dfa12_transition140,
    	dfa12_transition150,
    	dfa12_transition19,
    	dfa12_transition210,
    	dfa12_transition0,
    	dfa12_transition15,
    	dfa12_transition256,
    	dfa12_transition80,
    	dfa12_transition5,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition47,
    	dfa12_transition6,
    	dfa12_transition190,
    	dfa12_transition_null,
    	dfa12_transition160,
    	dfa12_transition0,
    	dfa12_transition164,
    	dfa12_transition173,
    	dfa12_transition194,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition117,
    	dfa12_transition273,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition92,
    	dfa12_transition230,
    	dfa12_transition129,
    	dfa12_transition60,
    	dfa12_transition66,
    	dfa12_transition138,
    	dfa12_transition151,
    	dfa12_transition18,
    	dfa12_transition213,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition260,
    	dfa12_transition78,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition48,
    	dfa12_transition8,
    	dfa12_transition191,
    	dfa12_transition156,
    	dfa12_transition_null,
    	dfa12_transition131,
    	dfa12_transition174,
    	dfa12_transition195,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition118,
    	dfa12_transition0,
    	dfa12_transition89,
    	dfa12_transition0,
    	dfa12_transition128,
    	dfa12_transition59,
    	dfa12_transition67,
    	dfa12_transition137,
    	dfa12_transition148,
    	dfa12_transition17,
    	dfa12_transition212,
    	dfa12_transition_null,
    	dfa12_transition259,
    	dfa12_transition83,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition201,
    	dfa12_transition0,
    	dfa12_transition132,
    	dfa12_transition175,
    	dfa12_transition0,
    	dfa12_transition110,
    	dfa12_transition_null,
    	dfa12_transition90,
    	dfa12_transition_null,
    	dfa12_transition123,
    	dfa12_transition58,
    	dfa12_transition68,
    	dfa12_transition136,
    	dfa12_transition149,
    	dfa12_transition16,
    	dfa12_transition208,
    	dfa12_transition0,
    	dfa12_transition82,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition200,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition168,
    	dfa12_transition_null,
    	dfa12_transition111,
    	dfa12_transition0,
    	dfa12_transition122,
    	dfa12_transition57,
    	dfa12_transition69,
    	dfa12_transition135,
    	dfa12_transition146,
    	dfa12_transition0,
    	dfa12_transition207,
    	dfa12_transition_null,
    	dfa12_transition85,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition169,
    	dfa12_transition112,
    	dfa12_transition_null,
    	dfa12_transition125,
    	dfa12_transition51,
    	dfa12_transition70,
    	dfa12_transition134,
    	dfa12_transition147,
    	dfa12_transition_null,
    	dfa12_transition209,
    	dfa12_transition84,
    	dfa12_transition_null,
    	dfa12_transition170,
    	dfa12_transition114,
    	dfa12_transition124,
    	dfa12_transition50,
    	dfa12_transition71,
    	dfa12_transition133,
    	dfa12_transition145,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition171,
    	dfa12_transition108,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition72,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition178,
    	dfa12_transition109,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition0,
    	dfa12_transition0,
    	dfa12_transition_null,
    	dfa12_transition_null,
    	dfa12_transition_null
        };
    
    protected class DFA12 : DFA
    {
        public DFA12(BaseRecognizer recognizer) 
        {
            this.recognizer = recognizer;
            this.decisionNumber = 12;
            this.eot = DFA12_eot;
            this.eof = DFA12_eof;
            this.min = DFA12_min;
            this.max = DFA12_max;
            this.accept     = DFA12_accept;
            this.special    = DFA12_special;
            this.transition = DFA12_transition;
        }
    
        override public string Description
        {
            get { return "1:1: Tokens : ( T60 | T61 | T62 | T63 | T64 | T65 | T66 | T67 | T68 | T69 | T70 | T71 | T72 | T73 | T74 | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | ABSENT | PRESENT | WITH | COMPONENTS | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String | Bstring | Hstring | StringLiteral | UID | LID | INT | WS | COMMENT | LINE_COMMENT );"; }
        }
    
    }
    
 
    
}
