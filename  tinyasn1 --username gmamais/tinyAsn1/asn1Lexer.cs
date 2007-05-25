// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-25 19:40:06

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Lexer : Lexer 
{
    public const int Bstring = 7;
    public const int T29 = 29;
    public const int T28 = 28;
    public const int T27 = 27;
    public const int T26 = 26;
    public const int T25 = 25;
    public const int EOF = -1;
    public const int T24 = 24;
    public const int T23 = 23;
    public const int T22 = 22;
    public const int T21 = 21;
    public const int T20 = 20;
    public const int T38 = 38;
    public const int T37 = 37;
    public const int UID = 4;
    public const int T39 = 39;
    public const int COMMENT = 10;
    public const int T34 = 34;
    public const int T33 = 33;
    public const int T36 = 36;
    public const int T35 = 35;
    public const int T30 = 30;
    public const int T32 = 32;
    public const int T31 = 31;
    public const int LINE_COMMENT = 11;
    public const int T49 = 49;
    public const int T48 = 48;
    public const int INT = 6;
    public const int T43 = 43;
    public const int Tokens = 58;
    public const int T42 = 42;
    public const int T41 = 41;
    public const int T40 = 40;
    public const int T47 = 47;
    public const int T46 = 46;
    public const int T45 = 45;
    public const int LID = 5;
    public const int T44 = 44;
    public const int WS = 9;
    public const int T50 = 50;
    public const int Hstring = 8;
    public const int T12 = 12;
    public const int T13 = 13;
    public const int T14 = 14;
    public const int T52 = 52;
    public const int T15 = 15;
    public const int T51 = 51;
    public const int T16 = 16;
    public const int T54 = 54;
    public const int T17 = 17;
    public const int T53 = 53;
    public const int T18 = 18;
    public const int T56 = 56;
    public const int T19 = 19;
    public const int T55 = 55;
    public const int T57 = 57;

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

    // $ANTLR start T12 
    public void mT12() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T12;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:7:7: ( 'DEFINITIONS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:7:7: 'DEFINITIONS'
            {
            	Match("DEFINITIONS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T12

    // $ANTLR start T13 
    public void mT13() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T13;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:8:7: ( 'EXPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:8:7: 'EXPLICIT'
            {
            	Match("EXPLICIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T13

    // $ANTLR start T14 
    public void mT14() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T14;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:7: ( 'TAGS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:7: 'TAGS'
            {
            	Match("TAGS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T14

    // $ANTLR start T15 
    public void mT15() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T15;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:10:7: ( 'IMPLICIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:10:7: 'IMPLICIT'
            {
            	Match("IMPLICIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T15

    // $ANTLR start T16 
    public void mT16() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T16;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:7: ( 'AUTOMATIC' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:7: 'AUTOMATIC'
            {
            	Match("AUTOMATIC"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T16

    // $ANTLR start T17 
    public void mT17() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T17;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:7: ( 'EXTENSIBILITY' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:7: 'EXTENSIBILITY'
            {
            	Match("EXTENSIBILITY"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T17

    // $ANTLR start T18 
    public void mT18() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T18;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:13:7: ( 'IMPLIED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:13:7: 'IMPLIED'
            {
            	Match("IMPLIED"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T18

    // $ANTLR start T19 
    public void mT19() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T19;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:7: ( '::=' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:7: '::='
            {
            	Match("::="); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T19

    // $ANTLR start T20 
    public void mT20() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T20;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:7: ( 'BEGIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:7: 'BEGIN'
            {
            	Match("BEGIN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T20

    // $ANTLR start T21 
    public void mT21() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T21;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: ( 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:7: 'END'
            {
            	Match("END"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T21

    // $ANTLR start T22 
    public void mT22() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T22;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: ( 'EXPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: 'EXPORTS'
            {
            	Match("EXPORTS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T22

    // $ANTLR start T23 
    public void mT23() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T23;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: ( 'ALL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: 'ALL'
            {
            	Match("ALL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T23

    // $ANTLR start T24 
    public void mT24() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T24;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: ( ';' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: ';'
            {
            	Match(';'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T24

    // $ANTLR start T25 
    public void mT25() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T25;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ( ',' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ','
            {
            	Match(','); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T25

    // $ANTLR start T26 
    public void mT26() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T26;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: ( 'IMPORTS' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: 'IMPORTS'
            {
            	Match("IMPORTS"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T26

    // $ANTLR start T27 
    public void mT27() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T27;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: ( 'FROM' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: 'FROM'
            {
            	Match("FROM"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T27

    // $ANTLR start T28 
    public void mT28() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T28;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: ( '[' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: '['
            {
            	Match('['); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T28

    // $ANTLR start T29 
    public void mT29() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T29;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: ( 'UNIVERSAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: 'UNIVERSAL'
            {
            	Match("UNIVERSAL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T29

    // $ANTLR start T30 
    public void mT30() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T30;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: ( 'APPLICATION' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: 'APPLICATION'
            {
            	Match("APPLICATION"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T30

    // $ANTLR start T31 
    public void mT31() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T31;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:7: ( 'PRIVATE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:7: 'PRIVATE'
            {
            	Match("PRIVATE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T31

    // $ANTLR start T32 
    public void mT32() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T32;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:7: ( ']' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:7: ']'
            {
            	Match(']'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T32

    // $ANTLR start T33 
    public void mT33() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T33;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:7: ( 'BIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:7: 'BIT'
            {
            	Match("BIT"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T33

    // $ANTLR start T34 
    public void mT34() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T34;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:7: ( 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:7: 'STRING'
            {
            	Match("STRING"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T34

    // $ANTLR start T35 
    public void mT35() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T35;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:7: ( '{' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:7: '{'
            {
            	Match('{'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T35

    // $ANTLR start T36 
    public void mT36() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T36;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:7: ( '(' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:7: '('
            {
            	Match('('); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T36

    // $ANTLR start T37 
    public void mT37() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T37;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:7: ( ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:7: ')'
            {
            	Match(')'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T37

    // $ANTLR start T38 
    public void mT38() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T38;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:33:7: ( '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:33:7: '}'
            {
            	Match('}'); 
            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T38

    // $ANTLR start T39 
    public void mT39() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T39;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:7: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:7: 'BOOLEAN'
            {
            	Match("BOOLEAN"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T39

    // $ANTLR start T40 
    public void mT40() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T40;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:7: ( 'ENUMERATED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:7: 'ENUMERATED'
            {
            	Match("ENUMERATED"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T40

    // $ANTLR start T41 
    public void mT41() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T41;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:7: ( 'INTEGER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:7: 'INTEGER'
            {
            	Match("INTEGER"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T41

    // $ANTLR start T42 
    public void mT42() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T42;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:37:7: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:37:7: 'REAL'
            {
            	Match("REAL"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T42

    // $ANTLR start T43 
    public void mT43() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T43;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:7: ( 'CHOICE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:7: 'CHOICE'
            {
            	Match("CHOICE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T43

    // $ANTLR start T44 
    public void mT44() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T44;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:7: ( 'SEQUENCE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:7: 'SEQUENCE'
            {
            	Match("SEQUENCE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:7: ( 'OPTIONAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:7: 'OPTIONAL'
            {
            	Match("OPTIONAL"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:41:7: ( 'SIZE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:41:7: 'SIZE'
            {
            	Match("SIZE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:7: ( 'OF' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:7: 'OF'
            {
            	Match("OF"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:7: ( 'OCTET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:7: 'OCTET'
            {
            	Match("OCTET"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:7: ( '+' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:7: '+'
            {
            	Match('+'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:7: ( '-' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:7: '-'
            {
            	Match('-'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:7: ( '<' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:7: '<'
            {
            	Match('<'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:7: ( '..' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:7: '..'
            {
            	Match(".."); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:7: ( '.' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:7: '.'
            {
            	Match('.'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:7: ( 'MIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:7: 'MIN'
            {
            	Match("MIN"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:50:7: ( 'MAX' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:50:7: 'MAX'
            {
            	Match("MAX"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:51:7: ( 'TRUE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:51:7: 'TRUE'
            {
            	Match("TRUE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:7: ( 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:7: 'FALSE'
            {
            	Match("FALSE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T57

    // $ANTLR start Bstring 
    public void mBstring() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = Bstring;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:2: ( '\\'' ( '0' | '1' )* '\\'B' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:2: '\\'' ( '0' | '1' )* '\\'B'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:7: ( '0' | '1' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:2: ( '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:2: '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:7: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:10: ( ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:10: ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:10: ( 'A' .. 'Z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:11: 'A' .. 'Z'
            	{
            		MatchRange('A','Z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:10: ( ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:10: ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:10: ( 'a' .. 'z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:11: 'a' .. 'z'
            	{
            		MatchRange('a','z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:7: ( ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
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
            	        new NoViableAltException("176:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )", 6, 0, input);
            	
            	    throw nvae_d6s0;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:9: '0'
            	        {
            	        	Match('0'); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:15: ( '1' .. '9' ) ( '0' .. '9' )*
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:15: ( '1' .. '9' )
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:16: '1' .. '9'
            	        	{
            	        		MatchRange('1','9'); 
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:26: ( '0' .. '9' )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:27: '0' .. '9'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:9: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:9: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:14: ( options {greedy=false; } : . )*
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
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:42: .
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:7: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("--"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:12: (~ ( '\\n' | '\\r' ) )*
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
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:12: ~ ( '\\n' | '\\r' )
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

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:26: ( '\\r' )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);
            	
            	if ( (LA10_0 == '\r') )
            	{
            	    alt10 = 1;
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:26: '\\r'
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
        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: ( T12 | T13 | T14 | T15 | T16 | T17 | T18 | T19 | T20 | T21 | T22 | T23 | T24 | T25 | T26 | T27 | T28 | T29 | T30 | T31 | T32 | T33 | T34 | T35 | T36 | T37 | T38 | T39 | T40 | T41 | T42 | T43 | T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | T57 | Bstring | Hstring | UID | LID | INT | WS | COMMENT | LINE_COMMENT )
        int alt11 = 54;
        alt11 = dfa11.Predict(input);
        switch (alt11) 
        {
            case 1 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: T12
                {
                	mT12(); 
                
                }
                break;
            case 2 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:14: T13
                {
                	mT13(); 
                
                }
                break;
            case 3 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:18: T14
                {
                	mT14(); 
                
                }
                break;
            case 4 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:22: T15
                {
                	mT15(); 
                
                }
                break;
            case 5 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:26: T16
                {
                	mT16(); 
                
                }
                break;
            case 6 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:30: T17
                {
                	mT17(); 
                
                }
                break;
            case 7 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:34: T18
                {
                	mT18(); 
                
                }
                break;
            case 8 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:38: T19
                {
                	mT19(); 
                
                }
                break;
            case 9 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:42: T20
                {
                	mT20(); 
                
                }
                break;
            case 10 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:46: T21
                {
                	mT21(); 
                
                }
                break;
            case 11 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:50: T22
                {
                	mT22(); 
                
                }
                break;
            case 12 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:54: T23
                {
                	mT23(); 
                
                }
                break;
            case 13 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:58: T24
                {
                	mT24(); 
                
                }
                break;
            case 14 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:62: T25
                {
                	mT25(); 
                
                }
                break;
            case 15 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:66: T26
                {
                	mT26(); 
                
                }
                break;
            case 16 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:70: T27
                {
                	mT27(); 
                
                }
                break;
            case 17 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:74: T28
                {
                	mT28(); 
                
                }
                break;
            case 18 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:78: T29
                {
                	mT29(); 
                
                }
                break;
            case 19 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:82: T30
                {
                	mT30(); 
                
                }
                break;
            case 20 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:86: T31
                {
                	mT31(); 
                
                }
                break;
            case 21 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:90: T32
                {
                	mT32(); 
                
                }
                break;
            case 22 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:94: T33
                {
                	mT33(); 
                
                }
                break;
            case 23 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:98: T34
                {
                	mT34(); 
                
                }
                break;
            case 24 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:102: T35
                {
                	mT35(); 
                
                }
                break;
            case 25 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:106: T36
                {
                	mT36(); 
                
                }
                break;
            case 26 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:110: T37
                {
                	mT37(); 
                
                }
                break;
            case 27 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:114: T38
                {
                	mT38(); 
                
                }
                break;
            case 28 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:118: T39
                {
                	mT39(); 
                
                }
                break;
            case 29 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:122: T40
                {
                	mT40(); 
                
                }
                break;
            case 30 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:126: T41
                {
                	mT41(); 
                
                }
                break;
            case 31 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:130: T42
                {
                	mT42(); 
                
                }
                break;
            case 32 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:134: T43
                {
                	mT43(); 
                
                }
                break;
            case 33 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:138: T44
                {
                	mT44(); 
                
                }
                break;
            case 34 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:142: T45
                {
                	mT45(); 
                
                }
                break;
            case 35 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:146: T46
                {
                	mT46(); 
                
                }
                break;
            case 36 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:150: T47
                {
                	mT47(); 
                
                }
                break;
            case 37 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:154: T48
                {
                	mT48(); 
                
                }
                break;
            case 38 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:158: T49
                {
                	mT49(); 
                
                }
                break;
            case 39 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:162: T50
                {
                	mT50(); 
                
                }
                break;
            case 40 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:166: T51
                {
                	mT51(); 
                
                }
                break;
            case 41 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:170: T52
                {
                	mT52(); 
                
                }
                break;
            case 42 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:174: T53
                {
                	mT53(); 
                
                }
                break;
            case 43 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:178: T54
                {
                	mT54(); 
                
                }
                break;
            case 44 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:182: T55
                {
                	mT55(); 
                
                }
                break;
            case 45 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:186: T56
                {
                	mT56(); 
                
                }
                break;
            case 46 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:190: T57
                {
                	mT57(); 
                
                }
                break;
            case 47 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:194: Bstring
                {
                	mBstring(); 
                
                }
                break;
            case 48 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:202: Hstring
                {
                	mHstring(); 
                
                }
                break;
            case 49 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:210: UID
                {
                	mUID(); 
                
                }
                break;
            case 50 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:214: LID
                {
                	mLID(); 
                
                }
                break;
            case 51 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:218: INT
                {
                	mINT(); 
                
                }
                break;
            case 52 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:222: WS
                {
                	mWS(); 
                
                }
                break;
            case 53 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:225: COMMENT
                {
                	mCOMMENT(); 
                
                }
                break;
            case 54 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:233: LINE_COMMENT
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
        -1, 29, 29, 29, 29, 29, -1, 29, -1, -1, 29, -1, 29, 29, -1, 29, 
        -1, -1, -1, -1, 29, 29, 29, -1, 60, -1, 62, 29, -1, -1, -1, -1, 
        -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
        29, 29, 29, 29, 29, 29, 29, 29, 29, 93, 29, -1, -1, -1, -1, 29, 
        29, -1, -1, -1, 29, 29, 29, 102, 29, 29, 29, 29, 29, 29, 110, 29, 
        29, 113, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, 29, 126, 
        127, -1, 29, 29, 29, 29, -1, 29, 133, 134, 29, 29, 29, 29, -1, 29, 
        29, -1, 29, 29, 143, 29, 29, 29, 29, 148, 149, 29, 29, 29, -1, -1, 
        29, 29, 29, 29, 29, -1, -1, 29, 29, 29, 29, 29, 164, 29, 166, -1, 
        29, 29, 29, 29, -1, -1, 29, 172, 29, 29, 29, 29, 29, 29, 29, 29, 
        29, 29, 29, 29, -1, 29, -1, 29, 29, 188, 29, 190, -1, 29, 29, 193, 
        29, 29, 29, 197, 29, 199, 200, 29, 29, 203, 29, 205, -1, 29, -1, 
        29, 29, -1, 209, 29, 29, -1, 212, -1, -1, 29, 29, -1, 29, -1, 216, 
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
        9, 69, 78, 65, 77, 76, 0, 69, 0, 0, 65, 0, 78, 82, 0, 69, 0, 0, 
        0, 0, 69, 72, 67, 0, 45, 0, 46, 65, 39, 0, 0, 0, 0, 0, 70, 80, 68, 
        85, 71, 80, 84, 84, 76, 80, 71, 84, 79, 76, 79, 73, 73, 82, 81, 
        90, 65, 79, 84, 45, 84, 0, 0, 0, 0, 88, 78, 39, 66, 0, 73, 76, 69, 
        45, 77, 69, 83, 76, 69, 79, 45, 76, 73, 45, 76, 83, 77, 86, 86, 
        73, 85, 69, 76, 73, 69, 0, 73, 45, 45, 0, 78, 82, 73, 78, 0, 69, 
        45, 45, 73, 82, 71, 77, 0, 73, 78, 0, 69, 69, 45, 69, 65, 78, 69, 
        45, 45, 67, 84, 79, 0, 0, 73, 84, 67, 83, 82, 0, 0, 67, 84, 69, 
        65, 67, 45, 65, 45, 0, 82, 84, 71, 78, 0, 0, 69, 45, 78, 84, 83, 
        73, 73, 65, 68, 73, 83, 82, 84, 65, 0, 78, 0, 83, 69, 45, 67, 45, 
        0, 65, 73, 45, 84, 66, 84, 45, 84, 45, 45, 73, 84, 45, 65, 45, 0, 
        69, 0, 76, 79, 0, 45, 73, 69, 0, 45, 0, 0, 67, 73, 0, 76, 0, 45, 
        45, 78, 0, 76, 68, 0, 45, 79, 45, 0, 0, 83, 73, 45, 0, 78, 0, 45, 
        84, 0, 45, 0, 89, 0, 45, 0
        };
    static readonly int[] DFA11_max = {
        125, 69, 88, 82, 78, 85, 0, 79, 0, 0, 82, 0, 78, 82, 0, 84, 0, 0, 
        0, 0, 69, 72, 80, 0, 45, 0, 46, 73, 102, 0, 0, 0, 0, 0, 70, 84, 
        85, 85, 71, 80, 84, 84, 76, 80, 71, 84, 79, 76, 79, 73, 73, 82, 
        81, 90, 65, 79, 84, 122, 84, 0, 0, 0, 0, 88, 78, 102, 72, 0, 73, 
        79, 69, 122, 77, 69, 83, 79, 69, 79, 122, 76, 73, 122, 76, 83, 77, 
        86, 86, 73, 85, 69, 76, 73, 69, 0, 73, 122, 122, 0, 78, 82, 73, 
        78, 0, 69, 122, 122, 73, 82, 71, 77, 0, 73, 78, 0, 69, 69, 122, 
        69, 65, 78, 69, 122, 122, 67, 84, 79, 0, 0, 73, 84, 67, 83, 82, 
        0, 0, 69, 84, 69, 65, 67, 122, 65, 122, 0, 82, 84, 71, 78, 0, 0, 
        69, 122, 78, 84, 83, 73, 73, 65, 68, 73, 83, 82, 84, 65, 0, 78, 
        0, 83, 69, 122, 67, 122, 0, 65, 73, 122, 84, 66, 84, 122, 84, 122, 
        122, 73, 84, 122, 65, 122, 0, 69, 0, 76, 79, 0, 122, 73, 69, 0, 
        122, 0, 0, 67, 73, 0, 76, 0, 122, 122, 78, 0, 76, 68, 0, 122, 79, 
        122, 0, 0, 83, 73, 122, 0, 78, 0, 122, 84, 0, 122, 0, 89, 0, 122, 
        0
        };
    static readonly short[] DFA11_accept = {
        -1, -1, -1, -1, -1, -1, 8, -1, 13, 14, -1, 17, -1, -1, 21, -1, 24, 
        25, 26, 27, -1, -1, -1, 38, -1, 40, -1, -1, -1, 49, 50, 51, 52, 
        53, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 54, 39, 41, 42, -1, -1, 
        -1, -1, 48, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 36, -1, -1, -1, 
        47, -1, -1, -1, -1, 10, -1, -1, -1, -1, -1, -1, -1, 12, -1, -1, 
        22, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 44, 43, -1, 
        -1, -1, -1, -1, 45, 3, -1, -1, -1, -1, -1, -1, -1, -1, 16, -1, -1, 
        -1, -1, 35, 31, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, 9, -1, 46, -1, -1, -1, -1, -1, 37, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 23, -1, 32, -1, -1, 11, -1, 
        -1, -1, 7, -1, 15, 30, -1, -1, 28, -1, 20, -1, -1, -1, 2, -1, -1, 
        4, -1, -1, -1, 33, 34, -1, -1, -1, 5, -1, 18, -1, -1, 29, -1, 1, 
        -1, 19, -1, 6
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
    	49
    	};
    static readonly short[] dfa11_transition1 = {
    	112
    	};
    static readonly short[] dfa11_transition2 = {
    	140
    	};
    static readonly short[] dfa11_transition3 = {
    	80
    	};
    static readonly short[] dfa11_transition4 = {
    	29, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, -1, -1, -1, 
    	    -1, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
    	    29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, -1, -1, -1, 
    	    -1, -1, -1, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 
    	    29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29
    	};
    static readonly short[] dfa11_transition5 = {
    	231
    	};
    static readonly short[] dfa11_transition6 = {
    	229
    	};
    static readonly short[] dfa11_transition7 = {
    	225
    	};
    static readonly short[] dfa11_transition8 = {
    	219
    	};
    static readonly short[] dfa11_transition9 = {
    	179
    	};
    static readonly short[] dfa11_transition10 = {
    	66, -1, -1, -1, -1, -1, -1, -1, -1, 65, 65, 67, 67, 67, 67, 67, 67, 
    	    67, 67, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67
    	};
    static readonly short[] dfa11_transition11 = {
    	162
    	};
    static readonly short[] dfa11_transition12 = {
    	183
    	};
    static readonly short[] dfa11_transition13 = {
    	201
    	};
    static readonly short[] dfa11_transition14 = {
    	213
    	};
    static readonly short[] dfa11_transition15 = {
    	50
    	};
    static readonly short[] dfa11_transition16 = {
    	101
    	};
    static readonly short[] dfa11_transition17 = {
    	131
    	};
    static readonly short[] dfa11_transition18 = {
    	156
    	};
    static readonly short[] dfa11_transition19 = {
    	177
    	};
    static readonly short[] dfa11_transition20 = {
    	195
    	};
    static readonly short[] dfa11_transition21 = {
    	210
    	};
    static readonly short[] dfa11_transition22 = {
    	44, -1, -1, -1, 45, -1, -1, -1, -1, -1, 46
    	};
    static readonly short[] dfa11_transition23 = {
    	198
    	};
    static readonly short[] dfa11_transition24 = {
    	180
    	};
    static readonly short[] dfa11_transition25 = {
    	77
    	};
    static readonly short[] dfa11_transition26 = {
    	138
    	};
    static readonly short[] dfa11_transition27 = {
    	109
    	};
    static readonly short[] dfa11_transition28 = {
    	176
    	};
    static readonly short[] dfa11_transition29 = {
    	194
    	};
    static readonly short[] dfa11_transition30 = {
    	130
    	};
    static readonly short[] dfa11_transition31 = {
    	155
    	};
    static readonly short[] dfa11_transition32 = {
    	105
    	};
    static readonly short[] dfa11_transition33 = {
    	74
    	};
    static readonly short[] dfa11_transition34 = {
    	192
    	};
    static readonly short[] dfa11_transition35 = {
    	174
    	};
    static readonly short[] dfa11_transition36 = {
    	153
    	};
    static readonly short[] dfa11_transition37 = {
    	128
    	};
    static readonly short[] dfa11_transition38 = {
    	98
    	};
    static readonly short[] dfa11_transition39 = {
    	68
    	};
    static readonly short[] dfa11_transition40 = {
    	224
    	};
    static readonly short[] dfa11_transition41 = {
    	218
    	};
    static readonly short[] dfa11_transition42 = {
    	208
    	};
    static readonly short[] dfa11_transition43 = {
    	54
    	};
    static readonly short[] dfa11_transition44 = {
    	55
    	};
    static readonly short[] dfa11_transition45 = {
    	39, 40
    	};
    static readonly short[] dfa11_transition46 = {
    	63, -1, -1, -1, -1, -1, -1, -1, 64
    	};
    static readonly short[] dfa11_transition47 = {
    	52, -1, -1, -1, 53, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 51
    	};
    static readonly short[] dfa11_transition48 = {
    	96
    	};
    static readonly short[] dfa11_transition49 = {
    	38, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    37
    	};
    static readonly short[] dfa11_transition50 = {
    	69, -1, -1, -1, 70
    	};
    static readonly short[] dfa11_transition51 = {
    	95
    	};
    static readonly short[] dfa11_transition52 = {
    	73
    	};
    static readonly short[] dfa11_transition53 = {
    	104
    	};
    static readonly short[] dfa11_transition54 = {
    	61
    	};
    static readonly short[] dfa11_transition55 = {
    	83
    	};
    static readonly short[] dfa11_transition56 = {
    	115
    	};
    static readonly short[] dfa11_transition57 = {
    	121
    	};
    static readonly short[] dfa11_transition58 = {
    	89
    	};
    static readonly short[] dfa11_transition59 = {
    	142
    	};
    static readonly short[] dfa11_transition60 = {
    	124
    	};
    static readonly short[] dfa11_transition61 = {
    	92
    	};
    static readonly short[] dfa11_transition62 = {
    	32, 32, -1, -1, 32, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, 32, -1, -1, -1, -1, -1, -1, 28, 17, 18, 
    	    -1, 23, 9, 24, 26, 33, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 
    	    6, 8, 25, -1, -1, -1, -1, 5, 7, 21, 1, 2, 10, 29, 29, 4, 29, 29, 
    	    29, 27, 29, 22, 13, 29, 20, 15, 3, 12, 29, 29, 29, 29, 29, 11, 
    	    -1, 14, -1, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 
    	    30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 16, 
    	    -1, 19
    	};
    static readonly short[] dfa11_transition63 = {
    	151
    	};
    static readonly short[] dfa11_transition64 = {
    	150
    	};
    static readonly short[] dfa11_transition65 = {
    	123
    	};
    static readonly short[] dfa11_transition66 = {
    	171
    	};
    static readonly short[] dfa11_transition67 = {
    	91
    	};
    static readonly short[] dfa11_transition68 = {
    	120
    	};
    static readonly short[] dfa11_transition69 = {
    	88
    	};
    static readonly short[] dfa11_transition70 = {
    	170
    	};
    static readonly short[] dfa11_transition71 = {
    	147
    	};
    static readonly short[] dfa11_transition72 = {
    	106, -1, -1, 107
    	};
    static readonly short[] dfa11_transition73 = {
    	75
    	};
    static readonly short[] dfa11_transition74 = {
    	94
    	};
    static readonly short[] dfa11_transition75 = {
    	189
    	};
    static readonly short[] dfa11_transition76 = {
    	206
    	};
    static readonly short[] dfa11_transition77 = {
    	207
    	};
    static readonly short[] dfa11_transition78 = {
    	125
    	};
    static readonly short[] dfa11_transition79 = {
    	152
    	};
    static readonly short[] dfa11_transition80 = {
    	173
    	};
    static readonly short[] dfa11_transition81 = {
    	191
    	};
    static readonly short[] dfa11_transition82 = {
    	132
    	};
    static readonly short[] dfa11_transition83 = {
    	103
    	};
    static readonly short[] dfa11_transition84 = {
    	59
    	};
    static readonly short[] dfa11_transition85 = {
    	159, -1, 158
    	};
    static readonly short[] dfa11_transition86 = {
    	220
    	};
    static readonly short[] dfa11_transition87 = {
    	211
    	};
    static readonly short[] dfa11_transition88 = {
    	196
    	};
    static readonly short[] dfa11_transition89 = {
    	178
    	};
    static readonly short[] dfa11_transition90 = {
    	100, -1, -1, 99
    	};
    static readonly short[] dfa11_transition91 = {
    	157
    	};
    static readonly short[] dfa11_transition92 = {
    	182
    	};
    static readonly short[] dfa11_transition93 = {
    	71, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    72
    	};
    static readonly short[] dfa11_transition94 = {
    	137
    	};
    static readonly short[] dfa11_transition95 = {
    	161
    	};
    static readonly short[] dfa11_transition96 = {
    	76
    	};
    static readonly short[] dfa11_transition97 = {
    	108
    	};
    static readonly short[] dfa11_transition98 = {
    	90
    	};
    static readonly short[] dfa11_transition99 = {
    	122
    	};
    static readonly short[] dfa11_transition100 = {
    	36, -1, -1, -1, -1, -1, -1, -1, -1, -1, 35
    	};
    static readonly short[] dfa11_transition101 = {
    	34
    	};
    static readonly short[] dfa11_transition102 = {
    	87
    	};
    static readonly short[] dfa11_transition103 = {
    	119
    	};
    static readonly short[] dfa11_transition104 = {
    	146
    	};
    static readonly short[] dfa11_transition105 = {
    	56, -1, -1, 57, -1, -1, -1, -1, -1, -1, -1, -1, -1, 58
    	};
    static readonly short[] dfa11_transition106 = {
    	169
    	};
    static readonly short[] dfa11_transition107 = {
    	82
    	};
    static readonly short[] dfa11_transition108 = {
    	141
    	};
    static readonly short[] dfa11_transition109 = {
    	114
    	};
    static readonly short[] dfa11_transition110 = {
    	185
    	};
    static readonly short[] dfa11_transition111 = {
    	135
    	};
    static readonly short[] dfa11_transition112 = {
    	165
    	};
    static readonly short[] dfa11_transition113 = {
    	227
    	};
    static readonly short[] dfa11_transition114 = {
    	86
    	};
    static readonly short[] dfa11_transition115 = {
    	118
    	};
    static readonly short[] dfa11_transition116 = {
    	139
    	};
    static readonly short[] dfa11_transition117 = {
    	163
    	};
    static readonly short[] dfa11_transition118 = {
    	79
    	};
    static readonly short[] dfa11_transition119 = {
    	111
    	};
    static readonly short[] dfa11_transition120 = {
    	214
    	};
    static readonly short[] dfa11_transition121 = {
    	222
    	};
    static readonly short[] dfa11_transition122 = {
    	184
    	};
    static readonly short[] dfa11_transition123 = {
    	202
    	};
    static readonly short[] dfa11_transition124 = {
    	81
    	};
    static readonly short[] dfa11_transition125 = {
    	187
    	};
    static readonly short[] dfa11_transition126 = {
    	168
    	};
    static readonly short[] dfa11_transition127 = {
    	145
    	};
    static readonly short[] dfa11_transition128 = {
    	47, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    48
    	};
    static readonly short[] dfa11_transition129 = {
    	84
    	};
    static readonly short[] dfa11_transition130 = {
    	116
    	};
    static readonly short[] dfa11_transition131 = {
    	136
    	};
    static readonly short[] dfa11_transition132 = {
    	160
    	};
    static readonly short[] dfa11_transition133 = {
    	181
    	};
    static readonly short[] dfa11_transition134 = {
    	204
    	};
    static readonly short[] dfa11_transition135 = {
    	186
    	};
    static readonly short[] dfa11_transition136 = {
    	215
    	};
    static readonly short[] dfa11_transition137 = {
    	117
    	};
    static readonly short[] dfa11_transition138 = {
    	85
    	};
    static readonly short[] dfa11_transition139 = {
    	167
    	};
    static readonly short[] dfa11_transition140 = {
    	144
    	};
    static readonly short[] dfa11_transition141 = {
    	154
    	};
    static readonly short[] dfa11_transition142 = {
    	175
    	};
    static readonly short[] dfa11_transition143 = {
    	129
    	};
    static readonly short[] dfa11_transition144 = {
    	42, -1, -1, -1, 43, -1, -1, -1, -1, 41
    	};
    static readonly short[] dfa11_transition145 = {
    	97, -1, -1, -1, -1, -1, 67
    	};
    static readonly short[] dfa11_transition146 = {
    	78
    	};
    
    static readonly short[][] DFA11_transition = {
    	dfa11_transition62,
    	dfa11_transition101,
    	dfa11_transition100,
    	dfa11_transition49,
    	dfa11_transition45,
    	dfa11_transition144,
    	dfa11_transition_null,
    	dfa11_transition22,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition128,
    	dfa11_transition_null,
    	dfa11_transition0,
    	dfa11_transition15,
    	dfa11_transition_null,
    	dfa11_transition47,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition43,
    	dfa11_transition44,
    	dfa11_transition105,
    	dfa11_transition_null,
    	dfa11_transition84,
    	dfa11_transition_null,
    	dfa11_transition54,
    	dfa11_transition46,
    	dfa11_transition10,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition39,
    	dfa11_transition50,
    	dfa11_transition93,
    	dfa11_transition52,
    	dfa11_transition33,
    	dfa11_transition73,
    	dfa11_transition96,
    	dfa11_transition25,
    	dfa11_transition146,
    	dfa11_transition118,
    	dfa11_transition3,
    	dfa11_transition124,
    	dfa11_transition107,
    	dfa11_transition55,
    	dfa11_transition129,
    	dfa11_transition138,
    	dfa11_transition114,
    	dfa11_transition102,
    	dfa11_transition69,
    	dfa11_transition58,
    	dfa11_transition98,
    	dfa11_transition67,
    	dfa11_transition61,
    	dfa11_transition4,
    	dfa11_transition74,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition51,
    	dfa11_transition48,
    	dfa11_transition10,
    	dfa11_transition145,
    	dfa11_transition_null,
    	dfa11_transition38,
    	dfa11_transition90,
    	dfa11_transition16,
    	dfa11_transition4,
    	dfa11_transition83,
    	dfa11_transition53,
    	dfa11_transition32,
    	dfa11_transition72,
    	dfa11_transition97,
    	dfa11_transition27,
    	dfa11_transition4,
    	dfa11_transition119,
    	dfa11_transition1,
    	dfa11_transition4,
    	dfa11_transition109,
    	dfa11_transition56,
    	dfa11_transition130,
    	dfa11_transition137,
    	dfa11_transition115,
    	dfa11_transition103,
    	dfa11_transition68,
    	dfa11_transition57,
    	dfa11_transition99,
    	dfa11_transition65,
    	dfa11_transition60,
    	dfa11_transition_null,
    	dfa11_transition78,
    	dfa11_transition4,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition37,
    	dfa11_transition143,
    	dfa11_transition30,
    	dfa11_transition17,
    	dfa11_transition_null,
    	dfa11_transition82,
    	dfa11_transition4,
    	dfa11_transition4,
    	dfa11_transition111,
    	dfa11_transition131,
    	dfa11_transition94,
    	dfa11_transition26,
    	dfa11_transition_null,
    	dfa11_transition116,
    	dfa11_transition2,
    	dfa11_transition_null,
    	dfa11_transition108,
    	dfa11_transition59,
    	dfa11_transition4,
    	dfa11_transition140,
    	dfa11_transition127,
    	dfa11_transition104,
    	dfa11_transition71,
    	dfa11_transition4,
    	dfa11_transition4,
    	dfa11_transition64,
    	dfa11_transition63,
    	dfa11_transition79,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition36,
    	dfa11_transition141,
    	dfa11_transition31,
    	dfa11_transition18,
    	dfa11_transition91,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition85,
    	dfa11_transition132,
    	dfa11_transition95,
    	dfa11_transition11,
    	dfa11_transition117,
    	dfa11_transition4,
    	dfa11_transition112,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition139,
    	dfa11_transition126,
    	dfa11_transition106,
    	dfa11_transition70,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition66,
    	dfa11_transition4,
    	dfa11_transition80,
    	dfa11_transition35,
    	dfa11_transition142,
    	dfa11_transition28,
    	dfa11_transition19,
    	dfa11_transition89,
    	dfa11_transition9,
    	dfa11_transition24,
    	dfa11_transition133,
    	dfa11_transition92,
    	dfa11_transition12,
    	dfa11_transition122,
    	dfa11_transition_null,
    	dfa11_transition110,
    	dfa11_transition_null,
    	dfa11_transition135,
    	dfa11_transition125,
    	dfa11_transition4,
    	dfa11_transition75,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition81,
    	dfa11_transition34,
    	dfa11_transition4,
    	dfa11_transition29,
    	dfa11_transition20,
    	dfa11_transition88,
    	dfa11_transition4,
    	dfa11_transition23,
    	dfa11_transition4,
    	dfa11_transition4,
    	dfa11_transition13,
    	dfa11_transition123,
    	dfa11_transition4,
    	dfa11_transition134,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition76,
    	dfa11_transition_null,
    	dfa11_transition77,
    	dfa11_transition42,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition21,
    	dfa11_transition87,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition14,
    	dfa11_transition120,
    	dfa11_transition_null,
    	dfa11_transition136,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition4,
    	dfa11_transition41,
    	dfa11_transition_null,
    	dfa11_transition8,
    	dfa11_transition86,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition121,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition_null,
    	dfa11_transition40,
    	dfa11_transition7,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition113,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition6,
    	dfa11_transition_null,
    	dfa11_transition4,
    	dfa11_transition_null,
    	dfa11_transition5,
    	dfa11_transition_null,
    	dfa11_transition4,
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
            get { return "1:1: Tokens : ( T12 | T13 | T14 | T15 | T16 | T17 | T18 | T19 | T20 | T21 | T22 | T23 | T24 | T25 | T26 | T27 | T28 | T29 | T30 | T31 | T32 | T33 | T34 | T35 | T36 | T37 | T38 | T39 | T40 | T41 | T42 | T43 | T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | T57 | Bstring | Hstring | UID | LID | INT | WS | COMMENT | LINE_COMMENT );"; }
        }
    
    }
    
 
    
}
