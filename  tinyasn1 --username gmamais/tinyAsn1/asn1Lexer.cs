// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-25 15:09:53

using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Lexer : Lexer 
{
    public const int UnionMark = 7;
    public const int Bstring = 9;
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
    public const int COMMENT = 12;
    public const int T34 = 34;
    public const int T33 = 33;
    public const int T36 = 36;
    public const int T35 = 35;
    public const int T30 = 30;
    public const int T32 = 32;
    public const int T31 = 31;
    public const int LINE_COMMENT = 13;
    public const int T49 = 49;
    public const int T48 = 48;
    public const int INT = 6;
    public const int T43 = 43;
    public const int Tokens = 57;
    public const int T42 = 42;
    public const int T41 = 41;
    public const int T40 = 40;
    public const int T47 = 47;
    public const int T46 = 46;
    public const int T45 = 45;
    public const int LID = 5;
    public const int T44 = 44;
    public const int WS = 11;
    public const int T50 = 50;
    public const int Hstring = 10;
    public const int IntersectionMark = 8;
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

    // $ANTLR start T14 
    public void mT14() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T14;
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
    // $ANTLR end T14

    // $ANTLR start T15 
    public void mT15() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T15;
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
    // $ANTLR end T15

    // $ANTLR start T16 
    public void mT16() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T16;
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
    // $ANTLR end T16

    // $ANTLR start T17 
    public void mT17() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T17;
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
    // $ANTLR end T17

    // $ANTLR start T18 
    public void mT18() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T18;
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
    // $ANTLR end T18

    // $ANTLR start T19 
    public void mT19() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T19;
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
    // $ANTLR end T19

    // $ANTLR start T20 
    public void mT20() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T20;
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
    // $ANTLR end T20

    // $ANTLR start T21 
    public void mT21() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T21;
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
    // $ANTLR end T21

    // $ANTLR start T22 
    public void mT22() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T22;
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
    // $ANTLR end T22

    // $ANTLR start T23 
    public void mT23() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T23;
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
    // $ANTLR end T23

    // $ANTLR start T24 
    public void mT24() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = T24;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: ( '[' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:7: '['
            {
            	Match('['); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: ( 'UNIVERSAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:7: 'UNIVERSAL'
            {
            	Match("UNIVERSAL"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: ( 'APPLICATION' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:7: 'APPLICATION'
            {
            	Match("APPLICATION"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: ( 'PRIVATE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:7: 'PRIVATE'
            {
            	Match("PRIVATE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: ( ']' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:7: ']'
            {
            	Match(']'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: ( 'BIT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:7: 'BIT'
            {
            	Match("BIT"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: ( 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:7: 'STRING'
            {
            	Match("STRING"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: ( '{' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:7: '{'
            {
            	Match('{'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: ( '(' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:7: '('
            {
            	Match('('); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:7: ( ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:7: ')'
            {
            	Match(')'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:7: ( ',' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:7: ','
            {
            	Match(','); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:7: ( '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:7: '}'
            {
            	Match('}'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:7: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:7: 'BOOLEAN'
            {
            	Match("BOOLEAN"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:7: ( 'ENUMERATED' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:7: 'ENUMERATED'
            {
            	Match("ENUMERATED"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:7: ( 'INTEGER' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:7: 'INTEGER'
            {
            	Match("INTEGER"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:7: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:7: 'REAL'
            {
            	Match("REAL"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:33:7: ( 'CHOICE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:33:7: 'CHOICE'
            {
            	Match("CHOICE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:7: ( 'SEQUENCE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:7: 'SEQUENCE'
            {
            	Match("SEQUENCE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:7: ( 'OPTIONAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:7: 'OPTIONAL'
            {
            	Match("OPTIONAL"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:7: ( 'SIZE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:7: 'SIZE'
            {
            	Match("SIZE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:37:7: ( 'OF' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:37:7: 'OF'
            {
            	Match("OF"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:7: ( 'OCTET' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:7: 'OCTET'
            {
            	Match("OCTET"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:7: ( '+' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:7: '+'
            {
            	Match('+'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:7: ( '-' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:7: '-'
            {
            	Match('-'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:41:7: ( '..' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:41:7: '..'
            {
            	Match(".."); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:7: ( 'ALL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:7: 'ALL'
            {
            	Match("ALL"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:7: ( 'EXCEPT' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:7: 'EXCEPT'
            {
            	Match("EXCEPT"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:7: ( '<' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:7: '<'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:7: ( '.' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:7: '.'
            {
            	Match('.'); 
            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:7: ( 'MIN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:7: 'MIN'
            {
            	Match("MIN"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:7: ( 'MAX' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:7: 'MAX'
            {
            	Match("MAX"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:7: ( 'TRUE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:7: 'TRUE'
            {
            	Match("TRUE"); 

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:7: ( 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:7: 'FALSE'
            {
            	Match("FALSE"); 

            
            }
    
            this.type = _type;
        }
        finally 
    	{
        }
    }
    // $ANTLR end T56

    // $ANTLR start Bstring 
    public void mBstring() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = Bstring;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:133:2: ( '\\'' ( '0' | '1' )* '\\'B' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:133:2: '\\'' ( '0' | '1' )* '\\'B'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:133:7: ( '0' | '1' )*
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:136:2: ( '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:136:2: '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )* '\\'H'
            {
            	Match('\''); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:136:7: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )*
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

    // $ANTLR start UnionMark 
    public void mUnionMark() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UnionMark;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:15: ( '|' | 'UNION' )
            int alt3 = 2;
            int LA3_0 = input.LA(1);
            
            if ( (LA3_0 == '|') )
            {
                alt3 = 1;
            }
            else if ( (LA3_0 == 'U') )
            {
                alt3 = 2;
            }
            else 
            {
                NoViableAltException nvae_d3s0 =
                    new NoViableAltException("140:1: UnionMark : ( '|' | 'UNION' );", 3, 0, input);
            
                throw nvae_d3s0;
            }
            switch (alt3) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:15: '|'
                    {
                    	Match('|'); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:141:3: 'UNION'
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:21: ( '^' | 'INTERSECTION' )
            int alt4 = 2;
            int LA4_0 = input.LA(1);
            
            if ( (LA4_0 == '^') )
            {
                alt4 = 1;
            }
            else if ( (LA4_0 == 'I') )
            {
                alt4 = 2;
            }
            else 
            {
                NoViableAltException nvae_d4s0 =
                    new NoViableAltException("144:1: IntersectionMark : ( '^' | 'INTERSECTION' );", 4, 0, input);
            
                throw nvae_d4s0;
            }
            switch (alt4) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:21: '^'
                    {
                    	Match('^'); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:27: 'INTERSECTION'
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

    // $ANTLR start UID 
    public void mUID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = UID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:10: ( ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:10: ( 'A' .. 'Z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:10: ( 'A' .. 'Z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:11: 'A' .. 'Z'
            	{
            		MatchRange('A','Z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
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
    // $ANTLR end UID

    // $ANTLR start LID 
    public void mLID() // throws RecognitionException [2]
    {
        try 
    	{
            int _type = LID;
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:10: ( ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:10: ( 'a' .. 'z' ) ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:10: ( 'a' .. 'z' )
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:11: 'a' .. 'z'
            	{
            		MatchRange('a','z'); 
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:21: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '-' )*
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);
            	    
            	    if ( (LA6_0 == '-' || (LA6_0 >= '0' && LA6_0 <= '9') || (LA6_0 >= 'A' && LA6_0 <= 'Z') || (LA6_0 >= 'a' && LA6_0 <= 'z')) )
            	    {
            	        alt6 = 1;
            	    }
            	    
            	
            	    switch (alt6) 
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
            			    goto loop6;
            	    }
            	} while (true);
            	
            	loop6:
            		;	// Stops C# compiler whinging that label 'loop6' has no statements

            
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:7: ( ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )
            	int alt8 = 2;
            	int LA8_0 = input.LA(1);
            	
            	if ( (LA8_0 == '0') )
            	{
            	    alt8 = 1;
            	}
            	else if ( ((LA8_0 >= '1' && LA8_0 <= '9')) )
            	{
            	    alt8 = 2;
            	}
            	else 
            	{
            	    NoViableAltException nvae_d8s0 =
            	        new NoViableAltException("153:7: ( '0' | ( '1' .. '9' ) ( '0' .. '9' )* )", 8, 0, input);
            	
            	    throw nvae_d8s0;
            	}
            	switch (alt8) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:9: '0'
            	        {
            	        	Match('0'); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:15: ( '1' .. '9' ) ( '0' .. '9' )*
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:15: ( '1' .. '9' )
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:16: '1' .. '9'
            	        	{
            	        		MatchRange('1','9'); 
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:26: ( '0' .. '9' )*
            	        	do 
            	        	{
            	        	    int alt7 = 2;
            	        	    int LA7_0 = input.LA(1);
            	        	    
            	        	    if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
            	        	    {
            	        	        alt7 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt7) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:27: '0' .. '9'
            	        			    {
            	        			    	MatchRange('0','9'); 
            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop7;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop7:
            	        		;	// Stops C# compiler whinging that label 'loop7' has no statements

            	        
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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:9: ( ( ' ' | '\\t' | '\\r' | '\\n' )+ )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:9: ( ' ' | '\\t' | '\\r' | '\\n' )+
            	int cnt9 = 0;
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);
            	    
            	    if ( ((LA9_0 >= '\t' && LA9_0 <= '\n') || LA9_0 == '\r' || LA9_0 == ' ') )
            	    {
            	        alt9 = 1;
            	    }
            	    
            	
            	    switch (alt9) 
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
            			    if ( cnt9 >= 1 ) goto loop9;
            		            EarlyExitException eee =
            		                new EarlyExitException(9, input);
            		            throw eee;
            	    }
            	    cnt9++;
            	} while (true);
            	
            	loop9:
            		;	// Stops C# compiler whinging that label 'loop9' has no statements

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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:163:9: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:163:9: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:163:14: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt10 = 2;
            	    int LA10_0 = input.LA(1);
            	    
            	    if ( (LA10_0 == '*') )
            	    {
            	        int LA10_1 = input.LA(2);
            	        
            	        if ( (LA10_1 == '/') )
            	        {
            	            alt10 = 2;
            	        }
            	        else if ( ((LA10_1 >= '\u0000' && LA10_1 <= '.') || (LA10_1 >= '0' && LA10_1 <= '\uFFFE')) )
            	        {
            	            alt10 = 1;
            	        }
            	        
            	    
            	    }
            	    else if ( ((LA10_0 >= '\u0000' && LA10_0 <= ')') || (LA10_0 >= '+' && LA10_0 <= '\uFFFE')) )
            	    {
            	        alt10 = 1;
            	    }
            	    
            	
            	    switch (alt10) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:163:42: .
            			    {
            			    	MatchAny(); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop10;
            	    }
            	} while (true);
            	
            	loop10:
            		;	// Stops C# compiler whinging that label 'loop10' has no statements

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
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:7: ( '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:7: '--' (~ ( '\\n' | '\\r' ) )* ( '\\r' )? '\\n'
            {
            	Match("--"); 

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:12: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);
            	    
            	    if ( ((LA11_0 >= '\u0000' && LA11_0 <= '\t') || (LA11_0 >= '\u000B' && LA11_0 <= '\f') || (LA11_0 >= '\u000E' && LA11_0 <= '\uFFFE')) )
            	    {
            	        alt11 = 1;
            	    }
            	    
            	
            	    switch (alt11) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:12: ~ ( '\\n' | '\\r' )
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
            			    goto loop11;
            	    }
            	} while (true);
            	
            	loop11:
            		;	// Stops C# compiler whinging that label 'loop11' has no statements

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:26: ( '\\r' )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);
            	
            	if ( (LA12_0 == '\r') )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:26: '\\r'
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
        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: ( T14 | T15 | T16 | T17 | T18 | T19 | T20 | T21 | T22 | T23 | T24 | T25 | T26 | T27 | T28 | T29 | T30 | T31 | T32 | T33 | T34 | T35 | T36 | T37 | T38 | T39 | T40 | T41 | T42 | T43 | T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | Bstring | Hstring | UnionMark | IntersectionMark | UID | LID | INT | WS | COMMENT | LINE_COMMENT )
        int alt13 = 53;
        alt13 = dfa13.Predict(input);
        switch (alt13) 
        {
            case 1 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:10: T14
                {
                	mT14(); 
                
                }
                break;
            case 2 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:14: T15
                {
                	mT15(); 
                
                }
                break;
            case 3 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:18: T16
                {
                	mT16(); 
                
                }
                break;
            case 4 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:22: T17
                {
                	mT17(); 
                
                }
                break;
            case 5 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:26: T18
                {
                	mT18(); 
                
                }
                break;
            case 6 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:30: T19
                {
                	mT19(); 
                
                }
                break;
            case 7 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:34: T20
                {
                	mT20(); 
                
                }
                break;
            case 8 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:38: T21
                {
                	mT21(); 
                
                }
                break;
            case 9 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:42: T22
                {
                	mT22(); 
                
                }
                break;
            case 10 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:46: T23
                {
                	mT23(); 
                
                }
                break;
            case 11 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:50: T24
                {
                	mT24(); 
                
                }
                break;
            case 12 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:54: T25
                {
                	mT25(); 
                
                }
                break;
            case 13 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:58: T26
                {
                	mT26(); 
                
                }
                break;
            case 14 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:62: T27
                {
                	mT27(); 
                
                }
                break;
            case 15 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:66: T28
                {
                	mT28(); 
                
                }
                break;
            case 16 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:70: T29
                {
                	mT29(); 
                
                }
                break;
            case 17 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:74: T30
                {
                	mT30(); 
                
                }
                break;
            case 18 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:78: T31
                {
                	mT31(); 
                
                }
                break;
            case 19 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:82: T32
                {
                	mT32(); 
                
                }
                break;
            case 20 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:86: T33
                {
                	mT33(); 
                
                }
                break;
            case 21 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:90: T34
                {
                	mT34(); 
                
                }
                break;
            case 22 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:94: T35
                {
                	mT35(); 
                
                }
                break;
            case 23 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:98: T36
                {
                	mT36(); 
                
                }
                break;
            case 24 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:102: T37
                {
                	mT37(); 
                
                }
                break;
            case 25 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:106: T38
                {
                	mT38(); 
                
                }
                break;
            case 26 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:110: T39
                {
                	mT39(); 
                
                }
                break;
            case 27 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:114: T40
                {
                	mT40(); 
                
                }
                break;
            case 28 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:118: T41
                {
                	mT41(); 
                
                }
                break;
            case 29 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:122: T42
                {
                	mT42(); 
                
                }
                break;
            case 30 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:126: T43
                {
                	mT43(); 
                
                }
                break;
            case 31 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:130: T44
                {
                	mT44(); 
                
                }
                break;
            case 32 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:134: T45
                {
                	mT45(); 
                
                }
                break;
            case 33 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:138: T46
                {
                	mT46(); 
                
                }
                break;
            case 34 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:142: T47
                {
                	mT47(); 
                
                }
                break;
            case 35 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:146: T48
                {
                	mT48(); 
                
                }
                break;
            case 36 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:150: T49
                {
                	mT49(); 
                
                }
                break;
            case 37 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:154: T50
                {
                	mT50(); 
                
                }
                break;
            case 38 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:158: T51
                {
                	mT51(); 
                
                }
                break;
            case 39 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:162: T52
                {
                	mT52(); 
                
                }
                break;
            case 40 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:166: T53
                {
                	mT53(); 
                
                }
                break;
            case 41 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:170: T54
                {
                	mT54(); 
                
                }
                break;
            case 42 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:174: T55
                {
                	mT55(); 
                
                }
                break;
            case 43 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:178: T56
                {
                	mT56(); 
                
                }
                break;
            case 44 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:182: Bstring
                {
                	mBstring(); 
                
                }
                break;
            case 45 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:190: Hstring
                {
                	mHstring(); 
                
                }
                break;
            case 46 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:198: UnionMark
                {
                	mUnionMark(); 
                
                }
                break;
            case 47 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:208: IntersectionMark
                {
                	mIntersectionMark(); 
                
                }
                break;
            case 48 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:225: UID
                {
                	mUID(); 
                
                }
                break;
            case 49 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:229: LID
                {
                	mLID(); 
                
                }
                break;
            case 50 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:233: INT
                {
                	mINT(); 
                
                }
                break;
            case 51 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:237: WS
                {
                	mWS(); 
                
                }
                break;
            case 52 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:240: COMMENT
                {
                	mCOMMENT(); 
                
                }
                break;
            case 53 :
                // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:1:248: LINE_COMMENT
                {
                	mLINE_COMMENT(); 
                
                }
                break;
        
        }
    
    }


    protected DFA13 dfa13;
	private void InitializeCyclicDFAs()
	{
	    this.dfa13 = new DFA13(this);
	}

    static readonly short[] DFA13_eot = {
        -1, 30, 30, 30, 30, 30, -1, 30, -1, 30, 30, -1, 30, -1, -1, -1, 
        -1, -1, 30, 30, 30, -1, 59, 61, -1, 30, 30, -1, -1, -1, -1, -1, 
        -1, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 
        30, 30, 30, 30, 30, 30, 30, 30, 92, 30, -1, -1, -1, -1, 30, 30, 
        30, -1, -1, -1, 30, 30, 30, 30, 102, 30, 30, 30, 30, 30, 30, 30, 
        110, 30, 112, 30, 30, 30, 30, 30, 30, 30, 30, 30, -1, 30, 124, 125, 
        30, -1, 30, 30, 30, 30, -1, 30, 132, 133, 30, 30, 30, 30, -1, 30, 
        -1, 30, 30, 30, 30, 30, 145, 30, 147, 30, 30, 30, -1, -1, 30, 30, 
        30, 30, 30, 30, -1, -1, 30, 30, 30, 30, 30, 163, 30, 30, 28, 30, 
        30, -1, 30, -1, 30, 170, 30, 172, 30, 30, 30, 176, 30, 30, 30, 30, 
        30, 30, 30, -1, 30, 30, 30, 187, 30, 189, -1, 30, -1, 30, 30, 30, 
        -1, 30, 30, 196, 197, 30, 30, 30, 201, 30, 203, -1, 30, -1, 30, 
        30, 207, 30, 30, 30, -1, -1, 211, 30, 30, -1, 30, -1, 215, 216, 
        30, -1, 30, 30, 30, -1, 221, 30, 223, -1, -1, 30, 30, 226, 30, -1, 
        30, -1, 229, 30, -1, 30, 232, -1, 30, 29, -1, 234, -1
        };
    static readonly short[] DFA13_eof = {
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
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    static readonly int[] DFA13_min = {
        9, 69, 78, 65, 77, 76, 0, 69, 0, 78, 82, 0, 69, 0, 0, 0, 0, 0, 69, 
        72, 67, 0, 45, 46, 0, 65, 65, 39, 0, 0, 0, 0, 0, 0, 0, 70, 67, 68, 
        85, 71, 84, 80, 84, 80, 76, 71, 84, 79, 73, 73, 82, 90, 81, 65, 
        79, 84, 45, 84, 0, 0, 0, 0, 88, 78, 76, 39, 66, 0, 73, 76, 69, 69, 
        45, 77, 69, 83, 69, 76, 79, 76, 45, 73, 45, 76, 79, 86, 73, 69, 
        85, 76, 73, 69, 0, 73, 45, 45, 83, 0, 78, 73, 78, 80, 0, 69, 45, 
        45, 71, 73, 77, 73, 0, 78, 0, 69, 69, 78, 65, 78, 45, 69, 45, 67, 
        84, 79, 0, 0, 69, 73, 67, 83, 84, 82, 0, 0, 83, 69, 67, 65, 67, 
        45, 65, 82, 45, 84, 71, 0, 78, 0, 69, 45, 78, 45, 84, 73, 73, 45, 
        65, 69, 82, 68, 73, 84, 65, 0, 78, 83, 69, 45, 67, 45, 0, 65, 0, 
        73, 84, 66, 0, 84, 67, 45, 45, 84, 73, 84, 45, 65, 45, 0, 69, 0, 
        76, 79, 45, 73, 69, 84, 0, 0, 45, 67, 73, 0, 76, 0, 45, 45, 78, 
        0, 76, 68, 73, 0, 45, 79, 45, 0, 0, 83, 73, 45, 79, 0, 78, 0, 45, 
        84, 0, 78, 45, 0, 89, 45, 0, 45, 0
        };
    static readonly int[] DFA13_max = {
        125, 69, 88, 82, 78, 85, 0, 79, 0, 78, 82, 0, 84, 0, 0, 0, 0, 0, 
        69, 72, 80, 0, 45, 46, 0, 73, 65, 102, 0, 0, 0, 0, 0, 0, 0, 70, 
        84, 85, 85, 71, 84, 80, 84, 80, 76, 71, 84, 79, 73, 73, 82, 90, 
        81, 65, 79, 84, 122, 84, 0, 0, 0, 0, 88, 78, 76, 102, 72, 0, 73, 
        76, 69, 69, 122, 77, 69, 83, 69, 76, 79, 76, 122, 73, 122, 76, 86, 
        86, 73, 69, 85, 76, 73, 69, 0, 73, 122, 122, 83, 0, 78, 73, 78, 
        80, 0, 69, 122, 122, 82, 73, 77, 73, 0, 78, 0, 69, 69, 78, 65, 78, 
        122, 69, 122, 67, 84, 79, 0, 0, 69, 73, 67, 83, 84, 82, 0, 0, 83, 
        69, 69, 65, 67, 122, 65, 82, 122, 84, 71, 0, 78, 0, 69, 122, 78, 
        122, 84, 73, 73, 122, 65, 69, 82, 68, 73, 84, 65, 0, 78, 83, 69, 
        122, 67, 122, 0, 65, 0, 73, 84, 66, 0, 84, 67, 122, 122, 84, 73, 
        84, 122, 65, 122, 0, 69, 0, 76, 79, 122, 73, 69, 84, 0, 0, 122, 
        67, 73, 0, 76, 0, 122, 122, 78, 0, 76, 68, 73, 0, 122, 79, 122, 
        0, 0, 83, 73, 122, 79, 0, 78, 0, 122, 84, 0, 78, 122, 0, 89, 122, 
        0, 122, 0
        };
    static readonly short[] DFA13_accept = {
        -1, -1, -1, -1, -1, -1, 8, -1, 11, -1, -1, 15, -1, 18, 19, 20, 21, 
        22, -1, -1, -1, 33, -1, -1, 38, -1, -1, -1, 46, 47, 48, 49, 50, 
        51, 52, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, 53, 34, 35, 39, -1, -1, -1, 
        -1, -1, 45, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 31, -1, -1, -1, -1, 
        44, -1, -1, -1, -1, 10, -1, -1, -1, -1, -1, -1, -1, 36, -1, 16, 
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 41, 40, -1, -1, -1, 
        -1, -1, -1, 42, 3, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 30, 
        -1, 26, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
        -1, 9, -1, -1, -1, -1, -1, -1, 32, -1, 43, -1, -1, -1, 37, -1, -1, 
        -1, -1, -1, -1, -1, -1, -1, -1, 17, -1, 27, -1, -1, -1, -1, -1, 
        -1, 25, 7, -1, -1, -1, 23, -1, 14, -1, -1, -1, 2, -1, -1, -1, 4, 
        -1, -1, -1, 28, 29, -1, -1, -1, -1, 5, -1, 12, -1, -1, 24, -1, -1, 
        1, -1, -1, 13, -1, 6
        };
    static readonly short[] DFA13_special = {
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
        -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1
        };
    
    static readonly short[] dfa13_transition_null = null;

    static readonly short[] dfa13_transition0 = {
    	199
    	};
    static readonly short[] dfa13_transition1 = {
    	212
    	};
    static readonly short[] dfa13_transition2 = {
    	30, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, -1, -1, -1, -1, 
    	    -1, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 
    	    30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, -1, -1, -1, 
    	    -1, -1, -1, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 
    	    30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30
    	};
    static readonly short[] dfa13_transition3 = {
    	154
    	};
    static readonly short[] dfa13_transition4 = {
    	175
    	};
    static readonly short[] dfa13_transition5 = {
    	100
    	};
    static readonly short[] dfa13_transition6 = {
    	129
    	};
    static readonly short[] dfa13_transition7 = {
    	218
    	};
    static readonly short[] dfa13_transition8 = {
    	225
    	};
    static readonly short[] dfa13_transition9 = {
    	193
    	};
    static readonly short[] dfa13_transition10 = {
    	208
    	};
    static readonly short[] dfa13_transition11 = {
    	198
    	};
    static readonly short[] dfa13_transition12 = {
    	181
    	};
    static readonly short[] dfa13_transition13 = {
    	78
    	};
    static readonly short[] dfa13_transition14 = {
    	182
    	};
    static readonly short[] dfa13_transition15 = {
    	161
    	};
    static readonly short[] dfa13_transition16 = {
    	137
    	};
    static readonly short[] dfa13_transition17 = {
    	108
    	};
    static readonly short[] dfa13_transition18 = {
    	49
    	};
    static readonly short[] dfa13_transition19 = {
    	128
    	};
    static readonly short[] dfa13_transition20 = {
    	153
    	};
    static readonly short[] dfa13_transition21 = {
    	174
    	};
    static readonly short[] dfa13_transition22 = {
    	192
    	};
    static readonly short[] dfa13_transition23 = {
    	75
    	};
    static readonly short[] dfa13_transition24 = {
    	105
    	};
    static readonly short[] dfa13_transition25 = {
    	98
    	};
    static readonly short[] dfa13_transition26 = {
    	84
    	};
    static readonly short[] dfa13_transition27 = {
    	68
    	};
    static readonly short[] dfa13_transition28 = {
    	152
    	};
    static readonly short[] dfa13_transition29 = {
    	127
    	};
    static readonly short[] dfa13_transition30 = {
    	191
    	};
    static readonly short[] dfa13_transition31 = {
    	173
    	};
    static readonly short[] dfa13_transition32 = {
    	217
    	};
    static readonly short[] dfa13_transition33 = {
    	44, -1, -1, -1, 43, -1, -1, -1, -1, 42
    	};
    static readonly short[] dfa13_transition34 = {
    	71, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 69, -1, -1, -1, 
    	    70
    	};
    static readonly short[] dfa13_transition35 = {
    	115, -1, -1, -1, -1, -1, -1, 114
    	};
    static readonly short[] dfa13_transition36 = {
    	206
    	};
    static readonly short[] dfa13_transition37 = {
    	224
    	};
    static readonly short[] dfa13_transition38 = {
    	66, -1, -1, -1, -1, -1, -1, -1, -1, 65, 65, 67, 67, 67, 67, 67, 67, 
    	    67, 67, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, -1, -1, -1, 67, 67, 67, 67, 67, 67
    	};
    static readonly short[] dfa13_transition39 = {
    	99
    	};
    static readonly short[] dfa13_transition40 = {
    	135, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 134
    	};
    static readonly short[] dfa13_transition41 = {
    	76
    	};
    static readonly short[] dfa13_transition42 = {
    	106
    	};
    static readonly short[] dfa13_transition43 = {
    	45, -1, -1, -1, 46, -1, -1, -1, -1, -1, 47
    	};
    static readonly short[] dfa13_transition44 = {
    	54
    	};
    static readonly short[] dfa13_transition45 = {
    	53
    	};
    static readonly short[] dfa13_transition46 = {
    	64
    	};
    static readonly short[] dfa13_transition47 = {
    	62, -1, -1, -1, -1, -1, -1, -1, 63
    	};
    static readonly short[] dfa13_transition48 = {
    	101
    	};
    static readonly short[] dfa13_transition49 = {
    	155
    	};
    static readonly short[] dfa13_transition50 = {
    	130
    	};
    static readonly short[] dfa13_transition51 = {
    	142
    	};
    static readonly short[] dfa13_transition52 = {
    	95
    	};
    static readonly short[] dfa13_transition53 = {
    	178
    	};
    static readonly short[] dfa13_transition54 = {
    	94
    	};
    static readonly short[] dfa13_transition55 = {
    	39, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    38
    	};
    static readonly short[] dfa13_transition56 = {
    	195
    	};
    static readonly short[] dfa13_transition57 = {
    	157
    	};
    static readonly short[] dfa13_transition58 = {
    	227
    	};
    static readonly short[] dfa13_transition59 = {
    	231
    	};
    static readonly short[] dfa13_transition60 = {
    	210
    	};
    static readonly short[] dfa13_transition61 = {
    	220
    	};
    static readonly short[] dfa13_transition62 = {
    	74
    	};
    static readonly short[] dfa13_transition63 = {
    	104
    	};
    static readonly short[] dfa13_transition64 = {
    	91
    	};
    static readonly short[] dfa13_transition65 = {
    	126
    	};
    static readonly short[] dfa13_transition66 = {
    	96
    	};
    static readonly short[] dfa13_transition67 = {
    	58
    	};
    static readonly short[] dfa13_transition68 = {
    	151
    	};
    static readonly short[] dfa13_transition69 = {
    	149
    	};
    static readonly short[] dfa13_transition70 = {
    	122
    	};
    static readonly short[] dfa13_transition71 = {
    	80
    	};
    static readonly short[] dfa13_transition72 = {
    	88
    	};
    static readonly short[] dfa13_transition73 = {
    	146
    	};
    static readonly short[] dfa13_transition74 = {
    	119
    	};
    static readonly short[] dfa13_transition75 = {
    	52, -1, -1, -1, 51, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 50
    	};
    static readonly short[] dfa13_transition76 = {
    	188
    	};
    static readonly short[] dfa13_transition77 = {
    	168
    	};
    static readonly short[] dfa13_transition78 = {
    	204
    	};
    static readonly short[] dfa13_transition79 = {
    	190
    	};
    static readonly short[] dfa13_transition80 = {
    	205
    	};
    static readonly short[] dfa13_transition81 = {
    	93
    	};
    static readonly short[] dfa13_transition82 = {
    	123
    	};
    static readonly short[] dfa13_transition83 = {
    	150
    	};
    static readonly short[] dfa13_transition84 = {
    	171
    	};
    static readonly short[] dfa13_transition85 = {
    	118
    	};
    static readonly short[] dfa13_transition86 = {
    	87
    	};
    static readonly short[] dfa13_transition87 = {
    	219
    	};
    static readonly short[] dfa13_transition88 = {
    	209
    	};
    static readonly short[] dfa13_transition89 = {
    	194
    	};
    static readonly short[] dfa13_transition90 = {
    	177
    	};
    static readonly short[] dfa13_transition91 = {
    	156
    	};
    static readonly short[] dfa13_transition92 = {
    	131
    	};
    static readonly short[] dfa13_transition93 = {
    	179
    	};
    static readonly short[] dfa13_transition94 = {
    	72, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    73
    	};
    static readonly short[] dfa13_transition95 = {
    	158
    	};
    static readonly short[] dfa13_transition96 = {
    	120
    	};
    static readonly short[] dfa13_transition97 = {
    	77
    	};
    static readonly short[] dfa13_transition98 = {
    	89
    	};
    static readonly short[] dfa13_transition99 = {
    	148
    	};
    static readonly short[] dfa13_transition100 = {
    	169
    	};
    static readonly short[] dfa13_transition101 = {
    	90
    	};
    static readonly short[] dfa13_transition102 = {
    	160, -1, 159
    	};
    static readonly short[] dfa13_transition103 = {
    	121
    	};
    static readonly short[] dfa13_transition104 = {
    	136
    	};
    static readonly short[] dfa13_transition105 = {
    	107
    	};
    static readonly short[] dfa13_transition106 = {
    	184
    	};
    static readonly short[] dfa13_transition107 = {
    	48
    	};
    static readonly short[] dfa13_transition108 = {
    	103
    	};
    static readonly short[] dfa13_transition109 = {
    	113
    	};
    static readonly short[] dfa13_transition110 = {
    	83
    	};
    static readonly short[] dfa13_transition111 = {
    	164
    	};
    static readonly short[] dfa13_transition112 = {
    	140
    	};
    static readonly short[] dfa13_transition113 = {
    	85
    	};
    static readonly short[] dfa13_transition114 = {
    	97, -1, -1, -1, -1, -1, 67
    	};
    static readonly short[] dfa13_transition115 = {
    	166
    	};
    static readonly short[] dfa13_transition116 = {
    	186
    	};
    static readonly short[] dfa13_transition117 = {
    	116
    	};
    static readonly short[] dfa13_transition118 = {
    	37, -1, -1, -1, -1, -1, -1, -1, -1, -1, 36
    	};
    static readonly short[] dfa13_transition119 = {
    	143
    	};
    static readonly short[] dfa13_transition120 = {
    	167
    	};
    static readonly short[] dfa13_transition121 = {
    	144
    	};
    static readonly short[] dfa13_transition122 = {
    	117
    	};
    static readonly short[] dfa13_transition123 = {
    	82
    	};
    static readonly short[] dfa13_transition124 = {
    	86
    	};
    static readonly short[] dfa13_transition125 = {
    	35
    	};
    static readonly short[] dfa13_transition126 = {
    	165
    	};
    static readonly short[] dfa13_transition127 = {
    	60
    	};
    static readonly short[] dfa13_transition128 = {
    	185
    	};
    static readonly short[] dfa13_transition129 = {
    	55, -1, -1, 56, -1, -1, -1, -1, -1, -1, -1, -1, -1, 57
    	};
    static readonly short[] dfa13_transition130 = {
    	202
    	};
    static readonly short[] dfa13_transition131 = {
    	214
    	};
    static readonly short[] dfa13_transition132 = {
    	141
    	};
    static readonly short[] dfa13_transition133 = {
    	228
    	};
    static readonly short[] dfa13_transition134 = {
    	222
    	};
    static readonly short[] dfa13_transition135 = {
    	183
    	};
    static readonly short[] dfa13_transition136 = {
    	162
    	};
    static readonly short[] dfa13_transition137 = {
    	213
    	};
    static readonly short[] dfa13_transition138 = {
    	200
    	};
    static readonly short[] dfa13_transition139 = {
    	79
    	};
    static readonly short[] dfa13_transition140 = {
    	138
    	};
    static readonly short[] dfa13_transition141 = {
    	109
    	};
    static readonly short[] dfa13_transition142 = {
    	41, 40
    	};
    static readonly short[] dfa13_transition143 = {
    	180
    	};
    static readonly short[] dfa13_transition144 = {
    	33, 33, -1, -1, 33, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 
    	    -1, -1, -1, -1, -1, -1, 33, -1, -1, -1, -1, -1, -1, 27, 14, 15, 
    	    -1, 21, 16, 22, 23, 34, 32, 32, 32, 32, 32, 32, 32, 32, 32, 32, 
    	    6, -1, 24, -1, -1, -1, -1, 5, 7, 19, 1, 2, 26, 30, 30, 4, 30, 30, 
    	    30, 25, 30, 20, 10, 30, 18, 12, 3, 9, 30, 30, 30, 30, 30, 8, -1, 
    	    11, 29, -1, -1, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 
    	    31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 13, 28, 
    	    17
    	};
    static readonly short[] dfa13_transition145 = {
    	230
    	};
    static readonly short[] dfa13_transition146 = {
    	233
    	};
    static readonly short[] dfa13_transition147 = {
    	139
    	};
    static readonly short[] dfa13_transition148 = {
    	111
    	};
    static readonly short[] dfa13_transition149 = {
    	81
    	};
    
    static readonly short[][] DFA13_transition = {
    	dfa13_transition144,
    	dfa13_transition125,
    	dfa13_transition118,
    	dfa13_transition55,
    	dfa13_transition142,
    	dfa13_transition33,
    	dfa13_transition_null,
    	dfa13_transition43,
    	dfa13_transition_null,
    	dfa13_transition107,
    	dfa13_transition18,
    	dfa13_transition_null,
    	dfa13_transition75,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition45,
    	dfa13_transition44,
    	dfa13_transition129,
    	dfa13_transition_null,
    	dfa13_transition67,
    	dfa13_transition127,
    	dfa13_transition_null,
    	dfa13_transition47,
    	dfa13_transition46,
    	dfa13_transition38,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition27,
    	dfa13_transition34,
    	dfa13_transition94,
    	dfa13_transition62,
    	dfa13_transition23,
    	dfa13_transition41,
    	dfa13_transition97,
    	dfa13_transition13,
    	dfa13_transition139,
    	dfa13_transition71,
    	dfa13_transition149,
    	dfa13_transition123,
    	dfa13_transition110,
    	dfa13_transition26,
    	dfa13_transition113,
    	dfa13_transition124,
    	dfa13_transition86,
    	dfa13_transition72,
    	dfa13_transition98,
    	dfa13_transition101,
    	dfa13_transition64,
    	dfa13_transition2,
    	dfa13_transition81,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition54,
    	dfa13_transition52,
    	dfa13_transition66,
    	dfa13_transition38,
    	dfa13_transition114,
    	dfa13_transition_null,
    	dfa13_transition25,
    	dfa13_transition39,
    	dfa13_transition5,
    	dfa13_transition48,
    	dfa13_transition2,
    	dfa13_transition108,
    	dfa13_transition63,
    	dfa13_transition24,
    	dfa13_transition42,
    	dfa13_transition105,
    	dfa13_transition17,
    	dfa13_transition141,
    	dfa13_transition2,
    	dfa13_transition148,
    	dfa13_transition2,
    	dfa13_transition109,
    	dfa13_transition35,
    	dfa13_transition117,
    	dfa13_transition122,
    	dfa13_transition85,
    	dfa13_transition74,
    	dfa13_transition96,
    	dfa13_transition103,
    	dfa13_transition70,
    	dfa13_transition_null,
    	dfa13_transition82,
    	dfa13_transition2,
    	dfa13_transition2,
    	dfa13_transition65,
    	dfa13_transition_null,
    	dfa13_transition29,
    	dfa13_transition19,
    	dfa13_transition6,
    	dfa13_transition50,
    	dfa13_transition_null,
    	dfa13_transition92,
    	dfa13_transition2,
    	dfa13_transition2,
    	dfa13_transition40,
    	dfa13_transition104,
    	dfa13_transition16,
    	dfa13_transition140,
    	dfa13_transition_null,
    	dfa13_transition147,
    	dfa13_transition_null,
    	dfa13_transition112,
    	dfa13_transition132,
    	dfa13_transition51,
    	dfa13_transition119,
    	dfa13_transition121,
    	dfa13_transition2,
    	dfa13_transition73,
    	dfa13_transition2,
    	dfa13_transition99,
    	dfa13_transition69,
    	dfa13_transition83,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition68,
    	dfa13_transition28,
    	dfa13_transition20,
    	dfa13_transition3,
    	dfa13_transition49,
    	dfa13_transition91,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition57,
    	dfa13_transition95,
    	dfa13_transition102,
    	dfa13_transition15,
    	dfa13_transition136,
    	dfa13_transition2,
    	dfa13_transition111,
    	dfa13_transition126,
    	dfa13_transition2,
    	dfa13_transition115,
    	dfa13_transition120,
    	dfa13_transition_null,
    	dfa13_transition77,
    	dfa13_transition_null,
    	dfa13_transition100,
    	dfa13_transition2,
    	dfa13_transition84,
    	dfa13_transition2,
    	dfa13_transition31,
    	dfa13_transition21,
    	dfa13_transition4,
    	dfa13_transition2,
    	dfa13_transition90,
    	dfa13_transition53,
    	dfa13_transition93,
    	dfa13_transition143,
    	dfa13_transition12,
    	dfa13_transition14,
    	dfa13_transition135,
    	dfa13_transition_null,
    	dfa13_transition106,
    	dfa13_transition128,
    	dfa13_transition116,
    	dfa13_transition2,
    	dfa13_transition76,
    	dfa13_transition2,
    	dfa13_transition_null,
    	dfa13_transition79,
    	dfa13_transition_null,
    	dfa13_transition30,
    	dfa13_transition22,
    	dfa13_transition9,
    	dfa13_transition_null,
    	dfa13_transition89,
    	dfa13_transition56,
    	dfa13_transition2,
    	dfa13_transition2,
    	dfa13_transition11,
    	dfa13_transition0,
    	dfa13_transition138,
    	dfa13_transition2,
    	dfa13_transition130,
    	dfa13_transition2,
    	dfa13_transition_null,
    	dfa13_transition78,
    	dfa13_transition_null,
    	dfa13_transition80,
    	dfa13_transition36,
    	dfa13_transition2,
    	dfa13_transition10,
    	dfa13_transition88,
    	dfa13_transition60,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition2,
    	dfa13_transition1,
    	dfa13_transition137,
    	dfa13_transition_null,
    	dfa13_transition131,
    	dfa13_transition_null,
    	dfa13_transition2,
    	dfa13_transition2,
    	dfa13_transition32,
    	dfa13_transition_null,
    	dfa13_transition7,
    	dfa13_transition87,
    	dfa13_transition61,
    	dfa13_transition_null,
    	dfa13_transition2,
    	dfa13_transition134,
    	dfa13_transition2,
    	dfa13_transition_null,
    	dfa13_transition_null,
    	dfa13_transition37,
    	dfa13_transition8,
    	dfa13_transition2,
    	dfa13_transition58,
    	dfa13_transition_null,
    	dfa13_transition133,
    	dfa13_transition_null,
    	dfa13_transition2,
    	dfa13_transition145,
    	dfa13_transition_null,
    	dfa13_transition59,
    	dfa13_transition2,
    	dfa13_transition_null,
    	dfa13_transition146,
    	dfa13_transition2,
    	dfa13_transition_null,
    	dfa13_transition2,
    	dfa13_transition_null
        };
    
    protected class DFA13 : DFA
    {
        public DFA13(BaseRecognizer recognizer) 
        {
            this.recognizer = recognizer;
            this.decisionNumber = 13;
            this.eot = DFA13_eot;
            this.eof = DFA13_eof;
            this.min = DFA13_min;
            this.max = DFA13_max;
            this.accept     = DFA13_accept;
            this.special    = DFA13_special;
            this.transition = DFA13_transition;
        }
    
        override public string Description
        {
            get { return "1:1: Tokens : ( T14 | T15 | T16 | T17 | T18 | T19 | T20 | T21 | T22 | T23 | T24 | T25 | T26 | T27 | T28 | T29 | T30 | T31 | T32 | T33 | T34 | T35 | T36 | T37 | T38 | T39 | T40 | T41 | T42 | T43 | T44 | T45 | T46 | T47 | T48 | T49 | T50 | T51 | T52 | T53 | T54 | T55 | T56 | Bstring | Hstring | UnionMark | IntersectionMark | UID | LID | INT | WS | COMMENT | LINE_COMMENT );"; }
        }
    
    }
    
 
    
}
