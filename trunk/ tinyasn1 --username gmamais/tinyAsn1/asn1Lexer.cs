// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-28 14:34:30

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Lexer : Lexer 
{
    public const int APPLICATION = 19;
    public const int Bstring = 36;
    public const int MAX = 35;
    public const int EXPLICIT = 5;
    public const int EOF = -1;
    public const int BOOLEAN = 23;
    public const int EXPORTS = 14;
    public const int BEGIN = 11;
    public const int ALL = 15;
    public const int UID = 40;
    public const int COMMENT = 42;
    public const int CHOICE = 27;
    public const int INTEGER = 25;
    public const int EXTENSIBILITY = 9;
    public const int IMPLICIT = 7;
    public const int LINE_COMMENT = 43;
    public const int PRIVATE = 20;
    public const int DEFINITIONS = 4;
    public const int T49 = 49;
    public const int T48 = 48;
    public const int TAGS = 6;
    public const int INT = 13;
    public const int MIN = 34;
    public const int Tokens = 58;
    public const int OF = 31;
    public const int TRUE = 38;
    public const int IMPLIED = 10;
    public const int T47 = 47;
    public const int T46 = 46;
    public const int T45 = 45;
    public const int OPTIONAL = 29;
    public const int LID = 33;
    public const int T44 = 44;
    public const int REAL = 26;
    public const int SEQUENCE = 28;
    public const int ENUMERATED = 24;
    public const int WS = 41;
    public const int T50 = 50;
    public const int Hstring = 37;
    public const int BIT = 21;
    public const int IMPORTS = 16;
    public const int T52 = 52;
    public const int FROM = 17;
    public const int END = 12;
    public const int T51 = 51;
    public const int UNIVERSAL = 18;
    public const int FALSE = 39;
    public const int T54 = 54;
    public const int T53 = 53;
    public const int T56 = 56;
    public const int SIZE = 30;
    public const int T55 = 55;
    public const int OCTET = 32;
    public const int STRING = 22;
    public const int T57 = 57;
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

    // $ANTLR start T44 
    public void mT44() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T44;
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
    // $ANTLR end T44

    // $ANTLR start T45 
    public void mT45() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T45;
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
    // $ANTLR end T45

    // $ANTLR start T46 
    public void mT46() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T46;
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
    // $ANTLR end T46

    // $ANTLR start T47 
    public void mT47() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T47;
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
    // $ANTLR end T47

    // $ANTLR start T48 
    public void mT48() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T48;
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
    // $ANTLR end T48

    // $ANTLR start T49 
    public void mT49() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T49;
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
    // $ANTLR end T49

    // $ANTLR start T50 
    public void mT50() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T50;
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
    // $ANTLR end T50

    // $ANTLR start T51 
    public void mT51() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T51;
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
    // $ANTLR end T51

    // $ANTLR start T52 
    public void mT52() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T52;
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
    // $ANTLR end T52

    // $ANTLR start T53 
    public void mT53() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T53;
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
    // $ANTLR end T53

    // $ANTLR start T54 
    public void mT54() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T54;
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
    // $ANTLR end T54

    // $ANTLR start T55 
    public void mT55() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T55;
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
    // $ANTLR end T55

    // $ANTLR start T56 
    public void mT56() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T56;
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
    // $ANTLR end T56

    // $ANTLR start T57 
    public void mT57() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T57;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ( '.' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: '.'
            {
            	Match('.'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T57

    // $ANTLR start DEFINITIONS 
    public void mDEFINITIONS() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = DEFINITIONS;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:16: ( 'DEFINITIONS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:16: 'DEFINITIONS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:187:12: ( 'EXPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:187:12: 'EXPLICIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:9: ( 'TAGS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:9: 'TAGS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:191:11: ( 'IMPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:191:11: 'IMPLICIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:193:13: ( 'AUTOMATIC' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:193:13: 'AUTOMATIC'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:195:17: ( 'EXTENSIBILITY' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:195:17: 'EXTENSIBILITY'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:197:11: ( 'IMPLIED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:197:11: 'IMPLIED'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:9: ( 'BEGIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:9: 'BEGIN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:200:7: ( 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:200:7: 'END'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:202:11: ( 'EXPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:202:11: 'EXPORTS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:204:8: ( 'ALL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:204:8: 'ALL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:206:11: ( 'IMPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:206:11: 'IMPORTS'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:8: ( 'FROM' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:8: 'FROM'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:210:13: ( 'UNIVERSAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:210:13: 'UNIVERSAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:211:15: ( 'APPLICATION' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:211:15: 'APPLICATION'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:11: ( 'PRIVATE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:11: 'PRIVATE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:213:7: ( 'BIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:213:7: 'BIT'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:215:10: ( 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:215:10: 'STRING'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:217:11: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:217:11: 'BOOLEAN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:219:13: ( 'ENUMERATED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:219:13: 'ENUMERATED'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:221:11: ( 'INTEGER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:221:11: 'INTEGER'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:223:8: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:223:8: 'REAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:225:10: ( 'CHOICE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:225:10: 'CHOICE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:227:12: ( 'SEQUENCE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:227:12: 'SEQUENCE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:229:12: ( 'OPTIONAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:229:12: 'OPTIONAL'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:231:8: ( 'SIZE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:231:8: 'SIZE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:233:6: ( 'OF' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:233:6: 'OF'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:235:9: ( 'OCTET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:235:9: 'OCTET'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:237:7: ( 'MIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:237:7: 'MIN'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:7: ( 'MAX' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:7: 'MAX'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:241:8: ( 'TRUE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:241:8: 'TRUE'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:243:9: ( 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:243:9: 'FALSE'
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

    // $ANTLR start Bstring 
    public void mBstring() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = Bstring;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:248:2: ( '\\'' ( '0' | '1' )* '\\'B' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:248:2: '\\'' ( '0' | '1' )* '\\'B'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:248:7: ( '0' | '1' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:2: ( '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:2: '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:7: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )*
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

    // $ANTLR start UID 
    public void mUID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:10: ( ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:10: ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:10: ( 'A' .. 'Z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:11: 'A' .. 'Z'
            	{
            		MatchRange('A','Z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);
            	    
            	    if ( (LA3_0 == '-' || (LA3_0 >= '0' && LA3_0 <= '9') || (LA3_0 >= 'A' && LA3_0 <= 'Z') || (LA3_0 >= 'a' && LA3_0 <= 'z')) )
            	    {
            	        alt3 = 1;
            	    }
            	    
            	
            	    switch (alt3) 
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
            			    goto loop3;
            	    }
            	} while (true);
            	
            	loop3:
            		;	// Stops C# compiler whinging that label 'loop3' has no statements

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:10: ( ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:10: ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:10: ( 'a' .. 'z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:11: 'a' .. 'z'
            	{
            		MatchRange('a','z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
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
    // $ANTLR end LID

    // $ANTLR start INT 
    public void mINT() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = INT;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:7: ( ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);
            	
            	if ( (LA6_0 == '0') )
            	{
            	    alt6 = 1;
            	}
            	else if ( ((LA6_0 >= '1' && LA6_0 <= '9')) )
            	{
            	    alt6 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d6s0 =
            	        new NoViableAltException("261:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )", 6, 0, input);
            	
            	    throw nvae_d6s0;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:9: '0'
            	        {
            	        	Match('0'); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:15: ( '1' .. '9' ) ( '0' .. '9' )*
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:15: ( '1' .. '9' )
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:16: '1' .. '9'
            	        	{
            	        		MatchRange('1','9'); 
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:26: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt5 = 2;
            	        	    int LA5_0 = input.LA(1);
            	        	    
            	        	    if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
            	        	    {
            	        	        alt5 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt5) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:261:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 
            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop5;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop5:
            	        		;	// Stops C# compiler whinging that label 'loop5' has no statements

            	        
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:9: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            	int cnt7 = 0;
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);
            	    
            	    if ( ((LA7_0 >= '\t' && LA7_0 <= '\n') || LA7_0 == '\r' || LA7_0 == ' ') )
            	    {
            	        alt7 = 1;
            	    }
            	    
            	
            	    switch (alt7) 
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
            			    if ( cnt7 >= 1 ) goto loop7;
            		            EarlyExitException eee =
            		                new EarlyExitException(7, input);
            		            throw eee;
            	    }
            	    cnt7++;
            	} while (true);
            	
            	loop7:
            		;	// Stops C# compiler whinging that label 'loop7' has no statements

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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:9: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);
            	    
            	    if ( (LA8_0 == '*') )
            	    {
            	        int LA8_1 = input.LA(2);
            	        
            	        if ( (LA8_1 == '/') )
            	        {
            	            alt8 = 2;
            	        }
            	        else if ( ((LA8_1 >= '\u0000' && LA8_1 <= '.') || (LA8_1 >= '0' && LA8_1 <= '\uFFFE')) )
            	        {
            	            alt8 = 1;
            	        }
            	        
            	    
            	    }
            	    else if ( ((LA8_0 >= '\u0000' && LA8_0 <= ')') || (LA8_0 >= '+' && LA8_0 <= '\uFFFE')) )
            	    {
            	        alt8 = 1;
            	    }
            	    
            	
            	    switch (alt8) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:42: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop8;
            	    }
            	} while (true);
            	
            	loop8:
            		;	// Stops C# compiler whinging that label 'loop8' has no statements

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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:7: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("--"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);
            	    
            	    if ( ((LA9_0 >= '\u0000' && LA9_0 <= '\t') || (LA9_0 >= '\u000B' && LA9_0 <= '\f') || (LA9_0 >= '\u000E' && LA9_0 <= '\uFFFE')) )
            	    {
            	        alt9 = 1;
            	    }
            	    
            	
            	    switch (alt9) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:12: ~ ( '\\n' | '\\r' )
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
            			    goto loop9;
            	    }
            	} while (true);
            	
            	loop9:
            		;	// Stops C# compiler whinging that label 'loop9' has no statements

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:26: ( '\\r' )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);
            	
            	if ( (LA10_0 == '\r') )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:26: '\\r'
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
        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: ( T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | T57 | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | Bstring | Hstring | UID | LID | INT | WS | COMMENT | LINE_COMMENT )
        int alt11 = 54;
        alt11 = dfa11.Predict(input);
        switch (alt11) 
        {
            case 1 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: T44
                {
                	mT44(); 
                
                }
                break;
            case 2 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:14: T45
                {
                	mT45(); 
                
                }
                break;
            case 3 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:18: T46
                {
                	mT46(); 
                
                }
                break;
            case 4 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:22: T47
                {
                	mT47(); 
                
                }
                break;
            case 5 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:26: T48
                {
                	mT48(); 
                
                }
                break;
            case 6 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:30: T49
                {
                	mT49(); 
                
                }
                break;
            case 7 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:34: T50
                {
                	mT50(); 
                
                }
                break;
            case 8 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:38: T51
                {
                	mT51(); 
                
                }
                break;
            case 9 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:42: T52
                {
                	mT52(); 
                
                }
                break;
            case 10 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:46: T53
                {
                	mT53(); 
                
                }
                break;
            case 11 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:50: T54
                {
                	mT54(); 
                
                }
                break;
            case 12 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:54: T55
                {
                	mT55(); 
                
                }
                break;
            case 13 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:58: T56
                {
                	mT56(); 
                
                }
                break;
            case 14 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:62: T57
                {
                	mT57(); 
                
                }
                break;
            case 15 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:66: DEFINITIONS
                {
                	mDEFINITIONS(); 
                
                }
                break;
            case 16 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:78: EXPLICIT
                {
                	mEXPLICIT(); 
                
                }
                break;
            case 17 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:87: TAGS
                {
                	mTAGS(); 
                
                }
                break;
            case 18 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:92: IMPLICIT
                {
                	mIMPLICIT(); 
                
                }
                break;
            case 19 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:101: AUTOMATIC
                {
                	mAUTOMATIC(); 
                
                }
                break;
            case 20 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:111: EXTENSIBILITY
                {
                	mEXTENSIBILITY(); 
                
                }
                break;
            case 21 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:125: IMPLIED
                {
                	mIMPLIED(); 
                
                }
                break;
            case 22 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:133: BEGIN
                {
                	mBEGIN(); 
                
                }
                break;
            case 23 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:139: END
                {
                	mEND(); 
                
                }
                break;
            case 24 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:143: EXPORTS
                {
                	mEXPORTS(); 
                
                }
                break;
            case 25 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:151: ALL
                {
                	mALL(); 
                
                }
                break;
            case 26 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:155: IMPORTS
                {
                	mIMPORTS(); 
                
                }
                break;
            case 27 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:163: FROM
                {
                	mFROM(); 
                
                }
                break;
            case 28 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:168: UNIVERSAL
                {
                	mUNIVERSAL(); 
                
                }
                break;
            case 29 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:178: APPLICATION
                {
                	mAPPLICATION(); 
                
                }
                break;
            case 30 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:190: PRIVATE
                {
                	mPRIVATE(); 
                
                }
                break;
            case 31 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:198: BIT
                {
                	mBIT(); 
                
                }
                break;
            case 32 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:202: STRING
                {
                	mSTRING(); 
                
                }
                break;
            case 33 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:209: BOOLEAN
                {
                	mBOOLEAN(); 
                
                }
                break;
            case 34 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:217: ENUMERATED
                {
                	mENUMERATED(); 
                
                }
                break;
            case 35 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:228: INTEGER
                {
                	mINTEGER(); 
                
                }
                break;
            case 36 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:236: REAL
                {
                	mREAL(); 
                
                }
                break;
            case 37 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:241: CHOICE
                {
                	mCHOICE(); 
                
                }
                break;
            case 38 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:248: SEQUENCE
                {
                	mSEQUENCE(); 
                
                }
                break;
            case 39 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:257: OPTIONAL
                {
                	mOPTIONAL(); 
                
                }
                break;
            case 40 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:266: SIZE
                {
                	mSIZE(); 
                
                }
                break;
            case 41 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:271: OF
                {
                	mOF(); 
                
                }
                break;
            case 42 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:274: OCTET
                {
                	mOCTET(); 
                
                }
                break;
            case 43 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:280: MIN
                {
                	mMIN(); 
                
                }
                break;
            case 44 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:284: MAX
                {
                	mMAX(); 
                
                }
                break;
            case 45 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:288: TRUE
                {
                	mTRUE(); 
                
                }
                break;
            case 46 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:293: FALSE
                {
                	mFALSE(); 
                
                }
                break;
            case 47 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:299: Bstring
                {
                	mBstring(); 
                
                }
                break;
            case 48 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:307: Hstring
                {
                	mHstring(); 
                
                }
                break;
            case 49 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:315: UID
                {
                	mUID(); 
                
                }
                break;
            case 50 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:319: LID
                {
                	mLID(); 
                
                }
                break;
            case 51 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:323: INT
                {
                	mINT(); 
                
                }
                break;
            case 52 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:327: WS
                {
                	mWS(); 
                
                }
                break;
            case 53 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:330: COMMENT
                {
                	mCOMMENT(); 
                
                }
                break;
            case 54 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:338: LINE_COMMENT
                {
                	mLINE_COMMENT(); 
                
                }
                break;
        
        }
    
    }


    protected DFA11 dfa11;
	private void InitializeCyclicDFAs()
	{
	    this.dfa11 = new DFA11(this);
	}

    static readonly short[] DFA11_eot = {
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 35, -1, 37, 29, 29, 
        29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
        29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 92, 29, 29, 29, 
        29, -1, -1, -1, 29, 29, 29, 102, 29, 29, 29, 29, 29, 29, 29, 111, 
        29, 29, 114, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, 29, 29, 126, 
        127, -1, 29, 29, 29, 29, -1, 29, 133, 134, 29, 29, 29, 29, 29, -1, 
        29, 29, -1, 29, 143, 29, 29, 29, 147, 29, 149, 29, 29, 29, -1, -1, 
        29, 29, 29, 29, 29, -1, -1, 29, 29, 29, 29, 29, 164, 29, 166, -1, 
        29, 29, 29, -1, 29, -1, 29, 172, 29, 29, 29, 29, 29, 29, 29, 29, 
        29, 29, 29, 29, -1, 29, -1, 29, 29, 188, 29, 190, -1, 29, 29, 29, 
        194, 29, 29, 197, 198, 29, 200, 29, 29, 203, 29, 205, -1, 29, -1, 
        29, 29, 209, -1, 29, 29, -1, -1, 212, -1, 29, 29, -1, 29, -1, 216, 
        217, 29, -1, 29, 29, -1, 221, 29, 223, -1, -1, 29, 29, 226, -1, 
        29, -1, 228, 29, -1, 230, -1, 29, -1, 232, -1
        };
    static readonly short[] DFA11_eof = {
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
        -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    static readonly int[] DFA11_min = {
        9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 46, 69, 78, 65, 77, 76, 
        69, 65, 78, 82, 69, 69, 72, 67, 65, 39, 0, 0, 0, 0, 0, 0, 0, 0, 
        0, 70, 80, 68, 85, 71, 80, 84, 84, 80, 76, 71, 79, 84, 76, 79, 73, 
        73, 82, 90, 81, 65, 79, 45, 84, 84, 88, 78, 39, 66, 0, 73, 76, 69, 
        45, 77, 69, 83, 76, 69, 79, 76, 45, 73, 76, 45, 83, 77, 86, 86, 
        73, 69, 85, 76, 73, 0, 69, 73, 45, 45, 0, 78, 73, 82, 78, 0, 69, 
        45, 45, 82, 73, 71, 77, 73, 0, 78, 69, 0, 69, 45, 69, 65, 78, 45, 
        69, 45, 67, 84, 79, 0, 0, 73, 67, 84, 83, 82, 0, 0, 84, 67, 69, 
        65, 67, 45, 65, 45, 0, 82, 84, 71, 0, 78, 0, 69, 45, 78, 84, 73, 
        83, 73, 65, 83, 68, 73, 82, 84, 65, 0, 78, 0, 83, 69, 45, 67, 45, 
        0, 65, 73, 84, 45, 66, 84, 45, 45, 84, 45, 73, 84, 45, 65, 45, 0, 
        69, 0, 76, 79, 45, 0, 73, 69, 0, 0, 45, 0, 67, 73, 0, 76, 0, 45, 
        45, 78, 0, 76, 68, 0, 45, 79, 45, 0, 0, 83, 73, 45, 0, 78, 0, 45, 
        84, 0, 45, 0, 89, 0, 45, 0
        };
    static readonly int[] DFA11_max = {
        125, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 45, 0, 46, 69, 88, 82, 78, 85, 
        79, 82, 78, 82, 84, 69, 72, 80, 73, 102, 0, 0, 0, 0, 0, 0, 0, 0, 
        0, 70, 84, 85, 85, 71, 80, 84, 84, 80, 76, 71, 79, 84, 76, 79, 73, 
        73, 82, 90, 81, 65, 79, 122, 84, 84, 88, 78, 102, 72, 0, 73, 79, 
        69, 122, 77, 69, 83, 79, 69, 79, 76, 122, 73, 76, 122, 83, 77, 86, 
        86, 73, 69, 85, 76, 73, 0, 69, 73, 122, 122, 0, 78, 73, 82, 78, 
        0, 69, 122, 122, 82, 73, 71, 77, 73, 0, 78, 69, 0, 69, 122, 69, 
        65, 78, 122, 69, 122, 67, 84, 79, 0, 0, 73, 67, 84, 83, 82, 0, 0, 
        84, 69, 69, 65, 67, 122, 65, 122, 0, 82, 84, 71, 0, 78, 0, 69, 122, 
        78, 84, 73, 83, 73, 65, 83, 68, 73, 82, 84, 65, 0, 78, 0, 83, 69, 
        122, 67, 122, 0, 65, 73, 84, 122, 66, 84, 122, 122, 84, 122, 73, 
        84, 122, 65, 122, 0, 69, 0, 76, 79, 122, 0, 73, 69, 0, 0, 122, 0, 
        67, 73, 0, 76, 0, 122, 122, 78, 0, 76, 68, 0, 122, 79, 122, 0, 0, 
        83, 73, 122, 0, 78, 0, 122, 84, 0, 122, 0, 89, 0, 122, 0
        };
    static readonly short[] DFA11_accept = {
        -1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, 12, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 49, 50, 51, 52, 53, 54, 
        11, 13, 14, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        48, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 41, -1, -1, -1, -1, 47, -1, 
        -1, -1, -1, 23, -1, -1, -1, -1, -1, -1, -1, -1, 25, -1, -1, 31, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 44, 43, -1, -1, -1, 
        -1, -1, 45, 17, -1, -1, -1, -1, -1, -1, -1, -1, 27, -1, -1, -1, 
        40, -1, 36, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 22, -1, 46, -1, -1, -1, -1, -1, 42, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 32, -1, 37, -1, -1, -1, 24, 
        -1, -1, 26, 21, -1, 35, -1, -1, 33, -1, 30, -1, -1, -1, 16, -1, 
        -1, 18, -1, -1, -1, 38, 39, -1, -1, -1, 19, -1, 28, -1, -1, 34, 
        -1, 15, -1, 29, -1, 20
        };
    static readonly short[] DFA11_special = {
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
        -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    
    static readonly short[] dfa11_transition_null = null;

    static readonly short[] dfa11_transition0 = {
    	193
    	};
    static readonly short[] dfa11_transition1 = {
    	29, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, -1, -1, -1, 
    	    -1, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
    	    29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, -1, -1, 
    	    -1, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
    	    29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29
    	};
    static readonly short[] dfa11_transition2 = {
    	74
    	};
    static readonly short[] dfa11_transition3 = {
    	105
    	};
    static readonly short[] dfa11_transition4 = {
    	208
    	};
    static readonly short[] dfa11_transition5 = {
    	192
    	};
    static readonly short[] dfa11_transition6 = {
    	174
    	};
    static readonly short[] dfa11_transition7 = {
    	153
    	};
    static readonly short[] dfa11_transition8 = {
    	224
    	};
    static readonly short[] dfa11_transition9 = {
    	218
    	};
    static readonly short[] dfa11_transition10 = {
    	175
    	};
    static readonly short[] dfa11_transition11 = {
    	154
    	};
    static readonly short[] dfa11_transition12 = {
    	129
    	};
    static readonly short[] dfa11_transition13 = {
    	66, -1, -1, -1, -1, -1, -1, -1, -1, 65, 65, 67, 67, 67, 67, 67, 67, 
    	    67, 67, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67
    	};
    static readonly short[] dfa11_transition14 = {
    	68
    	};
    static readonly short[] dfa11_transition15 = {
    	98
    	};
    static readonly short[] dfa11_transition16 = {
    	128
    	};
    static readonly short[] dfa11_transition17 = {
    	75
    	};
    static readonly short[] dfa11_transition18 = {
    	107, -1, -1, 106
    	};
    static readonly short[] dfa11_transition19 = {
    	54
    	};
    static readonly short[] dfa11_transition20 = {
    	47, -1, -1, -1, 46, -1, -1, -1, -1, 45
    	};
    static readonly short[] dfa11_transition21 = {
    	53
    	};
    static readonly short[] dfa11_transition22 = {
    	61, -1, -1, 60, -1, -1, -1, -1, -1, -1, -1, -1, -1, 62
    	};
    static readonly short[] dfa11_transition23 = {
    	40, -1, -1, -1, -1, -1, -1, -1, -1, -1, 39
    	};
    static readonly short[] dfa11_transition24 = {
    	51, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    52
    	};
    static readonly short[] dfa11_transition25 = {
    	59
    	};
    static readonly short[] dfa11_transition26 = {
    	58
    	};
    static readonly short[] dfa11_transition27 = {
    	48, -1, -1, -1, 50, -1, -1, -1, -1, -1, 49
    	};
    static readonly short[] dfa11_transition28 = {
    	36
    	};
    static readonly short[] dfa11_transition29 = {
    	63, -1, -1, -1, -1, -1, -1, -1, 64
    	};
    static readonly short[] dfa11_transition30 = {
    	93
    	};
    static readonly short[] dfa11_transition31 = {
    	151
    	};
    static readonly short[] dfa11_transition32 = {
    	124
    	};
    static readonly short[] dfa11_transition33 = {
    	96
    	};
    static readonly short[] dfa11_transition34 = {
    	95
    	};
    static readonly short[] dfa11_transition35 = {
    	136
    	};
    static readonly short[] dfa11_transition36 = {
    	160, -1, 159
    	};
    static readonly short[] dfa11_transition37 = {
    	73
    	};
    static readonly short[] dfa11_transition38 = {
    	104
    	};
    static readonly short[] dfa11_transition39 = {
    	99, -1, -1, 100
    	};
    static readonly short[] dfa11_transition40 = {
    	83
    	};
    static readonly short[] dfa11_transition41 = {
    	115
    	};
    static readonly short[] dfa11_transition42 = {
    	148
    	};
    static readonly short[] dfa11_transition43 = {
    	121
    	};
    static readonly short[] dfa11_transition44 = {
    	142
    	};
    static readonly short[] dfa11_transition45 = {
    	89
    	};
    static readonly short[] dfa11_transition46 = {
    	206
    	};
    static readonly short[] dfa11_transition47 = {
    	189
    	};
    static readonly short[] dfa11_transition48 = {
    	170
    	};
    static readonly short[] dfa11_transition49 = {
    	43, 44
    	};
    static readonly short[] dfa11_transition50 = {
    	173
    	};
    static readonly short[] dfa11_transition51 = {
    	152
    	};
    static readonly short[] dfa11_transition52 = {
    	125
    	};
    static readonly short[] dfa11_transition53 = {
    	94
    	};
    static readonly short[] dfa11_transition54 = {
    	191
    	};
    static readonly short[] dfa11_transition55 = {
    	207
    	};
    static readonly short[] dfa11_transition56 = {
    	88
    	};
    static readonly short[] dfa11_transition57 = {
    	120
    	};
    static readonly short[] dfa11_transition58 = {
    	76
    	};
    static readonly short[] dfa11_transition59 = {
    	220
    	};
    static readonly short[] dfa11_transition60 = {
    	211
    	};
    static readonly short[] dfa11_transition61 = {
    	137
    	};
    static readonly short[] dfa11_transition62 = {
    	108
    	};
    static readonly short[] dfa11_transition63 = {
    	182
    	};
    static readonly short[] dfa11_transition64 = {
    	161
    	};
    static readonly short[] dfa11_transition65 = {
    	90
    	};
    static readonly short[] dfa11_transition66 = {
    	122
    	};
    static readonly short[] dfa11_transition67 = {
    	91
    	};
    static readonly short[] dfa11_transition68 = {
    	123
    	};
    static readonly short[] dfa11_transition69 = {
    	150
    	};
    static readonly short[] dfa11_transition70 = {
    	171
    	};
    static readonly short[] dfa11_transition71 = {
    	87
    	};
    static readonly short[] dfa11_transition72 = {
    	82
    	};
    static readonly short[] dfa11_transition73 = {
    	169
    	};
    static readonly short[] dfa11_transition74 = {
    	146
    	};
    static readonly short[] dfa11_transition75 = {
    	119
    	};
    static readonly short[] dfa11_transition76 = {
    	185
    	};
    static readonly short[] dfa11_transition77 = {
    	141
    	};
    static readonly short[] dfa11_transition78 = {
    	165
    	};
    static readonly short[] dfa11_transition79 = {
    	81
    	};
    static readonly short[] dfa11_transition80 = {
    	32, 32, -1, -1, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, 32, -1, -1, -1, -1, -1, -1, 28, 4, 5, -1, 
    	    10, 7, 11, 13, 33, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 1, 6, 
    	    12, -1, -1, -1, -1, 18, 19, 25, 14, 15, 20, 29, 29, 17, 29, 29, 
    	    29, 27, 29, 26, 22, 29, 24, 23, 16, 21, 29, 29, 29, 29, 29, 8, 
    	    -1, 9, -1, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 
    	    30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 2, 
    	    -1, 3
    	};
    static readonly short[] dfa11_transition81 = {
    	113
    	};
    static readonly short[] dfa11_transition82 = {
    	178
    	};
    static readonly short[] dfa11_transition83 = {
    	196
    	};
    static readonly short[] dfa11_transition84 = {
    	132
    	};
    static readonly short[] dfa11_transition85 = {
    	157
    	};
    static readonly short[] dfa11_transition86 = {
    	103
    	};
    static readonly short[] dfa11_transition87 = {
    	78
    	};
    static readonly short[] dfa11_transition88 = {
    	110
    	};
    static readonly short[] dfa11_transition89 = {
    	139
    	};
    static readonly short[] dfa11_transition90 = {
    	163
    	};
    static readonly short[] dfa11_transition91 = {
    	184
    	};
    static readonly short[] dfa11_transition92 = {
    	202
    	};
    static readonly short[] dfa11_transition93 = {
    	214
    	};
    static readonly short[] dfa11_transition94 = {
    	167
    	};
    static readonly short[] dfa11_transition95 = {
    	186
    	};
    static readonly short[] dfa11_transition96 = {
    	204
    	};
    static readonly short[] dfa11_transition97 = {
    	215
    	};
    static readonly short[] dfa11_transition98 = {
    	34
    	};
    static readonly short[] dfa11_transition99 = {
    	145
    	};
    static readonly short[] dfa11_transition100 = {
    	118
    	};
    static readonly short[] dfa11_transition101 = {
    	187
    	};
    static readonly short[] dfa11_transition102 = {
    	168
    	};
    static readonly short[] dfa11_transition103 = {
    	227
    	};
    static readonly short[] dfa11_transition104 = {
    	222
    	};
    static readonly short[] dfa11_transition105 = {
    	86
    	};
    static readonly short[] dfa11_transition106 = {
    	135
    	};
    static readonly short[] dfa11_transition107 = {
    	158
    	};
    static readonly short[] dfa11_transition108 = {
    	176
    	};
    static readonly short[] dfa11_transition109 = {
    	79
    	};
    static readonly short[] dfa11_transition110 = {
    	144
    	};
    static readonly short[] dfa11_transition111 = {
    	117
    	};
    static readonly short[] dfa11_transition112 = {
    	85
    	};
    static readonly short[] dfa11_transition113 = {
    	71, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    72
    	};
    static readonly short[] dfa11_transition114 = {
    	179
    	};
    static readonly short[] dfa11_transition115 = {
    	116
    	};
    static readonly short[] dfa11_transition116 = {
    	84
    	};
    static readonly short[] dfa11_transition117 = {
    	80
    	};
    static readonly short[] dfa11_transition118 = {
    	112
    	};
    static readonly short[] dfa11_transition119 = {
    	180
    	};
    static readonly short[] dfa11_transition120 = {
    	38
    	};
    static readonly short[] dfa11_transition121 = {
    	155
    	};
    static readonly short[] dfa11_transition122 = {
    	130
    	};
    static readonly short[] dfa11_transition123 = {
    	57, -1, -1, -1, 56, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 55
    	};
    static readonly short[] dfa11_transition124 = {
    	140
    	};
    static readonly short[] dfa11_transition125 = {
    	213
    	};
    static readonly short[] dfa11_transition126 = {
    	183
    	};
    static readonly short[] dfa11_transition127 = {
    	201
    	};
    static readonly short[] dfa11_transition128 = {
    	138
    	};
    static readonly short[] dfa11_transition129 = {
    	162
    	};
    static readonly short[] dfa11_transition130 = {
    	77
    	};
    static readonly short[] dfa11_transition131 = {
    	109
    	};
    static readonly short[] dfa11_transition132 = {
    	199
    	};
    static readonly short[] dfa11_transition133 = {
    	181
    	};
    static readonly short[] dfa11_transition134 = {
    	231
    	};
    static readonly short[] dfa11_transition135 = {
    	229
    	};
    static readonly short[] dfa11_transition136 = {
    	225
    	};
    static readonly short[] dfa11_transition137 = {
    	219
    	};
    static readonly short[] dfa11_transition138 = {
    	69, -1, -1, -1, 70
    	};
    static readonly short[] dfa11_transition139 = {
    	210
    	};
    static readonly short[] dfa11_transition140 = {
    	195
    	};
    static readonly short[] dfa11_transition141 = {
    	177
    	};
    static readonly short[] dfa11_transition142 = {
    	156
    	};
    static readonly short[] dfa11_transition143 = {
    	131
    	};
    static readonly short[] dfa11_transition144 = {
    	101
    	};
    static readonly short[] dfa11_transition145 = {
    	97, -1, -1, -1, -1, -1, 67
    	};
    static readonly short[] dfa11_transition146 = {
    	42, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    41
    	};
    
    static readonly short[][] DFA11_transition = {
    	dfa11_transition80,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition98,
    	dfa11_transition_null,
    	dfa11_transition28,
    	dfa11_transition120,
    	dfa11_transition23,
    	dfa11_transition146,
    	dfa11_transition49,
    	dfa11_transition20,
    	dfa11_transition27,
    	dfa11_transition24,
    	dfa11_transition21,
    	dfa11_transition19,
    	dfa11_transition123,
    	dfa11_transition26,
    	dfa11_transition25,
    	dfa11_transition22,
    	dfa11_transition29,
    	dfa11_transition13,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition14,
    	dfa11_transition138,
    	dfa11_transition113,
    	dfa11_transition37,
    	dfa11_transition2,
    	dfa11_transition17,
    	dfa11_transition58,
    	dfa11_transition130,
    	dfa11_transition87,
    	dfa11_transition109,
    	dfa11_transition117,
    	dfa11_transition79,
    	dfa11_transition72,
    	dfa11_transition40,
    	dfa11_transition116,
    	dfa11_transition112,
    	dfa11_transition105,
    	dfa11_transition71,
    	dfa11_transition56,
    	dfa11_transition45,
    	dfa11_transition65,
    	dfa11_transition67,
    	dfa11_transition1,
    	dfa11_transition30,
    	dfa11_transition53,
    	dfa11_transition34,
    	dfa11_transition33,
    	dfa11_transition13,
    	dfa11_transition145,
    	dfa11_transition_null,
    	dfa11_transition15,
    	dfa11_transition39,
    	dfa11_transition144,
    	dfa11_transition1,
    	dfa11_transition86,
    	dfa11_transition38,
    	dfa11_transition3,
    	dfa11_transition18,
    	dfa11_transition62,
    	dfa11_transition131,
    	dfa11_transition88,
    	dfa11_transition1,
    	dfa11_transition118,
    	dfa11_transition81,
    	dfa11_transition1,
    	dfa11_transition41,
    	dfa11_transition115,
    	dfa11_transition111,
    	dfa11_transition100,
    	dfa11_transition75,
    	dfa11_transition57,
    	dfa11_transition43,
    	dfa11_transition66,
    	dfa11_transition68,
    	dfa11_transition_null,
    	dfa11_transition32,
    	dfa11_transition52,
    	dfa11_transition1,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition16,
    	dfa11_transition12,
    	dfa11_transition122,
    	dfa11_transition143,
    	dfa11_transition_null,
    	dfa11_transition84,
    	dfa11_transition1,
    	dfa11_transition1,
    	dfa11_transition106,
    	dfa11_transition35,
    	dfa11_transition61,
    	dfa11_transition128,
    	dfa11_transition89,
    	dfa11_transition_null,
    	dfa11_transition124,
    	dfa11_transition77,
    	dfa11_transition_null,
    	dfa11_transition44,
    	dfa11_transition1,
    	dfa11_transition110,
    	dfa11_transition99,
    	dfa11_transition74,
    	dfa11_transition1,
    	dfa11_transition42,
    	dfa11_transition1,
    	dfa11_transition69,
    	dfa11_transition31,
    	dfa11_transition51,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition7,
    	dfa11_transition11,
    	dfa11_transition121,
    	dfa11_transition142,
    	dfa11_transition85,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition107,
    	dfa11_transition36,
    	dfa11_transition64,
    	dfa11_transition129,
    	dfa11_transition90,
    	dfa11_transition1,
    	dfa11_transition78,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition94,
    	dfa11_transition102,
    	dfa11_transition73,
    	dfa11_transition_null,
    	dfa11_transition48,
    	dfa11_transition_null,
    	dfa11_transition70,
    	dfa11_transition1,
    	dfa11_transition50,
    	dfa11_transition6,
    	dfa11_transition10,
    	dfa11_transition108,
    	dfa11_transition141,
    	dfa11_transition82,
    	dfa11_transition114,
    	dfa11_transition119,
    	dfa11_transition133,
    	dfa11_transition63,
    	dfa11_transition126,
    	dfa11_transition91,
    	dfa11_transition_null,
    	dfa11_transition76,
    	dfa11_transition_null,
    	dfa11_transition95,
    	dfa11_transition101,
    	dfa11_transition1,
    	dfa11_transition47,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition54,
    	dfa11_transition5,
    	dfa11_transition0,
    	dfa11_transition1,
    	dfa11_transition140,
    	dfa11_transition83,
    	dfa11_transition1,
    	dfa11_transition1,
    	dfa11_transition132,
    	dfa11_transition1,
    	dfa11_transition127,
    	dfa11_transition92,
    	dfa11_transition1,
    	dfa11_transition96,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition46,
    	dfa11_transition_null,
    	dfa11_transition55,
    	dfa11_transition4,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition139,
    	dfa11_transition60,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition125,
    	dfa11_transition93,
    	dfa11_transition_null,
    	dfa11_transition97,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition1,
    	dfa11_transition9,
    	dfa11_transition_null,
    	dfa11_transition137,
    	dfa11_transition59,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition104,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition8,
    	dfa11_transition136,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition103,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition135,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition_null,
    	dfa11_transition134,
    	dfa11_transition_null,
    	dfa11_transition1,
    	dfa11_transition_null
        };
    
    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer) 
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept     = DFA11_accept;
            this.special    = DFA11_special;
            this.transition = DFA11_transition;
        }
    
        override public string Description
        {
            get { return "1:1: Tokens : ( T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | T57 | DEFINITIONS | EXPLICIT | TAGS | IMPLICIT | AUTOMATIC | EXTENSIBILITY | IMPLIED | BEGIN | END | EXPORTS | ALL | IMPORTS | FROM | UNIVERSAL | APPLICATION | PRIVATE | BIT | STRING | BOOLEAN | ENUMERATED | INTEGER | REAL | CHOICE | SEQUENCE | OPTIONAL | SIZE | OF | OCTET | MIN | MAX | TRUE | FALSE | Bstring | Hstring | UID | LID | INT | WS | COMMENT | LINE_COMMENT );"; }
        }
    
    }
    
 
    
}
