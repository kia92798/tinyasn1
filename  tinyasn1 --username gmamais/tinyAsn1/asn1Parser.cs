// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-25 15:09:53



using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



public class asn1Parser : Parser 
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"UID", 
		"LID", 
		"INT", 
		"UnionMark", 
		"IntersectionMark", 
		"Bstring", 
		"Hstring", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT", 
		"'DEFINITIONS'", 
		"'EXPLICIT'", 
		"'TAGS'", 
		"'IMPLICIT'", 
		"'AUTOMATIC'", 
		"'EXTENSIBILITY'", 
		"'IMPLIED'", 
		"'::='", 
		"'BEGIN'", 
		"'END'", 
		"'['", 
		"'UNIVERSAL'", 
		"'APPLICATION'", 
		"'PRIVATE'", 
		"']'", 
		"'BIT'", 
		"'STRING'", 
		"'{'", 
		"'('", 
		"')'", 
		"','", 
		"'}'", 
		"'BOOLEAN'", 
		"'ENUMERATED'", 
		"'INTEGER'", 
		"'REAL'", 
		"'CHOICE'", 
		"'SEQUENCE'", 
		"'OPTIONAL'", 
		"'SIZE'", 
		"'OF'", 
		"'OCTET'", 
		"'+'", 
		"'-'", 
		"'..'", 
		"'ALL'", 
		"'EXCEPT'", 
		"'<'", 
		"'.'", 
		"'MIN'", 
		"'MAX'", 
		"'TRUE'", 
		"'FALSE'"
    };

    public const int UnionMark = 7;
    public const int WS = 11;
    public const int LINE_COMMENT = 13;
    public const int Hstring = 10;
    public const int Bstring = 9;
    public const int IntersectionMark = 8;
    public const int INT = 6;
    public const int UID = 4;
    public const int COMMENT = 12;
    public const int EOF = -1;
    public const int LID = 5;
    
    
        public asn1Parser(ITokenStream input) 
    		: base(input)
    	{
    		InitializeCyclicDFAs();
        }
        

    override public string[] TokenNames
	{
		get { return tokenNames; }
	}

    override public string GrammarFileName
	{
		get { return "C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g"; }
	}


    
    // $ANTLR start moduleDefinition
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:1: moduleDefinition : UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( typeAssigment | valueAssigment )* 'END' ;
    public void moduleDefinition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:22: ( UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( typeAssigment | valueAssigment )* 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:22: UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( typeAssigment | valueAssigment )* 'END'
            {
            	Match(input,UID,FOLLOW_UID_in_moduleDefinition28); 
            	Match(input,14,FOLLOW_14_in_moduleDefinition36); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:4: ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )?
            	int alt1 = 4;
            	switch ( input.LA(1) ) 
            	{
            	    case 15:
            	    	{
            	        alt1 = 1;
            	        }
            	        break;
            	    case 17:
            	    	{
            	        alt1 = 2;
            	        }
            	        break;
            	    case 18:
            	    	{
            	        alt1 = 3;
            	        }
            	        break;
            	}
            	
            	switch (alt1) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:5: 'EXPLICIT' 'TAGS'
            	        {
            	        	Match(input,15,FOLLOW_15_in_moduleDefinition42); 
            	        	Match(input,16,FOLLOW_16_in_moduleDefinition44); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:25: 'IMPLICIT' 'TAGS'
            	        {
            	        	Match(input,17,FOLLOW_17_in_moduleDefinition48); 
            	        	Match(input,16,FOLLOW_16_in_moduleDefinition50); 
            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:45: 'AUTOMATIC' 'TAGS'
            	        {
            	        	Match(input,18,FOLLOW_18_in_moduleDefinition54); 
            	        	Match(input,16,FOLLOW_16_in_moduleDefinition56); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: ( 'EXTENSIBILITY' 'IMPLIED' )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);
            	
            	if ( (LA2_0 == 19) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:5: 'EXTENSIBILITY' 'IMPLIED'
            	        {
            	        	Match(input,19,FOLLOW_19_in_moduleDefinition64); 
            	        	Match(input,20,FOLLOW_20_in_moduleDefinition66); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,21,FOLLOW_21_in_moduleDefinition73); 
            	Match(input,22,FOLLOW_22_in_moduleDefinition75); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:4: ( typeAssigment | valueAssigment )*
            	do 
            	{
            	    int alt3 = 3;
            	    int LA3_0 = input.LA(1);
            	    
            	    if ( (LA3_0 == UID) )
            	    {
            	        alt3 = 1;
            	    }
            	    else if ( (LA3_0 == LID) )
            	    {
            	        alt3 = 2;
            	    }
            	    
            	
            	    switch (alt3) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:5: typeAssigment
            			    {
            			    	PushFollow(FOLLOW_typeAssigment_in_moduleDefinition86);
            			    	typeAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            			case 2 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:6: valueAssigment
            			    {
            			    	PushFollow(FOLLOW_valueAssigment_in_moduleDefinition93);
            			    	valueAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop3;
            	    }
            	} while (true);
            	
            	loop3:
            		;	// Stops C# compiler whinging that label 'loop3' has no statements

            	Match(input,23,FOLLOW_23_in_moduleDefinition104); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end moduleDefinition

    
    // $ANTLR start valueAssigment
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:1: valueAssigment : LID type '::=' value ;
    public void valueAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:4: ( LID type '::=' value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:4: LID type '::=' value
            {
            	Match(input,LID,FOLLOW_LID_in_valueAssigment115); 
            	PushFollow(FOLLOW_type_in_valueAssigment117);
            	type();
            	followingStackPointer_--;

            	Match(input,21,FOLLOW_21_in_valueAssigment119); 
            	PushFollow(FOLLOW_value_in_valueAssigment121);
            	value();
            	followingStackPointer_--;

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end valueAssigment

    
    // $ANTLR start typeAssigment
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:1: typeAssigment : UID '::=' type ;
    public void typeAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:4: ( UID '::=' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:25:4: UID '::=' type
            {
            	Match(input,UID,FOLLOW_UID_in_typeAssigment138); 
            	Match(input,21,FOLLOW_21_in_typeAssigment140); 
            	PushFollow(FOLLOW_type_in_typeAssigment142);
            	type();
            	followingStackPointer_--;

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end typeAssigment

    
    // $ANTLR start type
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:1: type : ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:8: ( ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:8: ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:8: ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);
            	
            	if ( (LA6_0 == 24) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:9: '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )?
            	        {
            	        	Match(input,24,FOLLOW_24_in_type154); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:13: ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )?
            	        	int alt4 = 2;
            	        	int LA4_0 = input.LA(1);
            	        	
            	        	if ( ((LA4_0 >= 25 && LA4_0 <= 27)) )
            	        	{
            	        	    alt4 = 1;
            	        	}
            	        	switch (alt4) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( (input.LA(1) >= 25 && input.LA(1) <= 27) ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type156);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,INT,FOLLOW_INT_in_type169); 
            	        	Match(input,28,FOLLOW_28_in_type172); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:65: ( 'IMPLICIT' | 'EXPLICIT' )?
            	        	int alt5 = 2;
            	        	int LA5_0 = input.LA(1);
            	        	
            	        	if ( (LA5_0 == 15 || LA5_0 == 17) )
            	        	{
            	        	    alt5 = 1;
            	        	}
            	        	switch (alt5) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( input.LA(1) == 15 || input.LA(1) == 17 ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type174);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:1: ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType )
            	int alt9 = 2;
            	int LA9_0 = input.LA(1);
            	
            	if ( (LA9_0 == UID || LA9_0 == 29 || (LA9_0 >= 36 && LA9_0 <= 40) || LA9_0 == 45) )
            	{
            	    alt9 = 1;
            	}
            	else if ( (LA9_0 == 41) )
            	{
            	    int LA9_2 = input.LA(2);
            	    
            	    if ( (LA9_2 == 31) )
            	    {
            	        alt9 = 1;
            	    }
            	    else if ( (LA9_2 == 32 || LA9_2 == 44) )
            	    {
            	        alt9 = 2;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d9s2 =
            	            new NoViableAltException("29:1: ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType )", 9, 2, input);
            	    
            	        throw nvae_d9s2;
            	    }
            	}
            	else 
            	{
            	    NoViableAltException nvae_d9s0 =
            	        new NoViableAltException("29:1: ( ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )? | sequenceOfType )", 9, 0, input);
            	
            	    throw nvae_d9s0;
            	}
            	switch (alt9) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:3: ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID ) ( constraint )?
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:3: ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID )
            	        	int alt7 = 9;
            	        	switch ( input.LA(1) ) 
            	        	{
            	        	case 29:
            	        		{
            	        	    alt7 = 1;
            	        	    }
            	        	    break;
            	        	case 36:
            	        		{
            	        	    alt7 = 2;
            	        	    }
            	        	    break;
            	        	case 40:
            	        		{
            	        	    alt7 = 3;
            	        	    }
            	        	    break;
            	        	case 37:
            	        		{
            	        	    alt7 = 4;
            	        	    }
            	        	    break;
            	        	case 38:
            	        		{
            	        	    alt7 = 5;
            	        	    }
            	        	    break;
            	        	case 45:
            	        		{
            	        	    alt7 = 6;
            	        	    }
            	        	    break;
            	        	case 39:
            	        		{
            	        	    alt7 = 7;
            	        	    }
            	        	    break;
            	        	case 41:
            	        		{
            	        	    alt7 = 8;
            	        	    }
            	        	    break;
            	        	case UID:
            	        		{
            	        	    alt7 = 9;
            	        	    }
            	        	    break;
            	        		default:
            	        		    NoViableAltException nvae_d7s0 =
            	        		        new NoViableAltException("29:3: ( bitStringType | booleanType | choiceType | enumeratedType | integerType | octetStringType | realType | sequenceType | UID )", 7, 0, input);
            	        	
            	        		    throw nvae_d7s0;
            	        	}
            	        	
            	        	switch (alt7) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:6: bitStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_bitStringType_in_type196);
            	        	        	bitStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:7: booleanType
            	        	        {
            	        	        	PushFollow(FOLLOW_booleanType_in_type204);
            	        	        	booleanType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 3 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:7: choiceType
            	        	        {
            	        	        	PushFollow(FOLLOW_choiceType_in_type212);
            	        	        	choiceType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 4 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:33:7: enumeratedType
            	        	        {
            	        	        	PushFollow(FOLLOW_enumeratedType_in_type220);
            	        	        	enumeratedType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 5 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:7: integerType
            	        	        {
            	        	        	PushFollow(FOLLOW_integerType_in_type228);
            	        	        	integerType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 6 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:7: octetStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_octetStringType_in_type236);
            	        	        	octetStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 7 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:7: realType
            	        	        {
            	        	        	PushFollow(FOLLOW_realType_in_type244);
            	        	        	realType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 8 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:37:7: sequenceType
            	        	        {
            	        	        	PushFollow(FOLLOW_sequenceType_in_type252);
            	        	        	sequenceType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 9 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:7: UID
            	        	        {
            	        	        	Match(input,UID,FOLLOW_UID_in_type260); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:4: ( constraint )?
            	        	int alt8 = 2;
            	        	int LA8_0 = input.LA(1);
            	        	
            	        	if ( (LA8_0 == 32) )
            	        	{
            	        	    alt8 = 1;
            	        	}
            	        	switch (alt8) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:4: constraint
            	        	        {
            	        	        	PushFollow(FOLLOW_constraint_in_type268);
            	        	        	constraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type273);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end type

    
    // $ANTLR start bitStringType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:1: bitStringType : 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )? ;
    public void bitStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:4: ( 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:4: 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )?
            {
            	Match(input,29,FOLLOW_29_in_bitStringType287); 
            	Match(input,30,FOLLOW_30_in_bitStringType289); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:19: ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);
            	
            	if ( (LA12_0 == 31) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:20: '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}'
            	        {
            	        	Match(input,31,FOLLOW_31_in_bitStringType292); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:24: ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )?
            	        	int alt11 = 2;
            	        	int LA11_0 = input.LA(1);
            	        	
            	        	if ( (LA11_0 == LID) )
            	        	{
            	        	    alt11 = 1;
            	        	}
            	        	switch (alt11) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:25: LID '(' INT ')' ( ',' LID '(' INT ')' )*
            	        	        {
            	        	        	Match(input,LID,FOLLOW_LID_in_bitStringType295); 
            	        	        	Match(input,32,FOLLOW_32_in_bitStringType297); 
            	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType299); 
            	        	        	Match(input,33,FOLLOW_33_in_bitStringType301); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:41: ( ',' LID '(' INT ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt10 = 2;
            	        	        	    int LA10_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA10_0 == 34) )
            	        	        	    {
            	        	        	        alt10 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt10) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:42: ',' LID '(' INT ')'
            	        	        			    {
            	        	        			    	Match(input,34,FOLLOW_34_in_bitStringType304); 
            	        	        			    	Match(input,LID,FOLLOW_LID_in_bitStringType306); 
            	        	        			    	Match(input,32,FOLLOW_32_in_bitStringType308); 
            	        	        			    	Match(input,INT,FOLLOW_INT_in_bitStringType310); 
            	        	        			    	Match(input,33,FOLLOW_33_in_bitStringType312); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop10;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop10:
            	        	        		;	// Stops C# compiler whinging that label 'loop10' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,35,FOLLOW_35_in_bitStringType320); 
            	        
            	        }
            	        break;
            	
            	}

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end bitStringType

    
    // $ANTLR start booleanType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:1: booleanType : 'BOOLEAN' ;
    public void booleanType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:50:4: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:50:4: 'BOOLEAN'
            {
            	Match(input,36,FOLLOW_36_in_booleanType335); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end booleanType

    
    // $ANTLR start enumeratedType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:1: enumeratedType : 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}' ;
    public void enumeratedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:4: ( 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:4: 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}'
            {
            	Match(input,37,FOLLOW_37_in_enumeratedType348); 
            	Match(input,31,FOLLOW_31_in_enumeratedType350); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:21: ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);
            	
            	if ( (LA16_0 == LID) )
            	{
            	    alt16 = 1;
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:22: LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_enumeratedType353); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:26: ( '(' signedNumber ')' )?
            	        	int alt13 = 2;
            	        	int LA13_0 = input.LA(1);
            	        	
            	        	if ( (LA13_0 == 32) )
            	        	{
            	        	    alt13 = 1;
            	        	}
            	        	switch (alt13) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:28: '(' signedNumber ')'
            	        	        {
            	        	        	Match(input,32,FOLLOW_32_in_enumeratedType357); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType359);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,33,FOLLOW_33_in_enumeratedType361); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:51: ( ',' LID ( '(' signedNumber ')' )? )*
            	        	do 
            	        	{
            	        	    int alt15 = 2;
            	        	    int LA15_0 = input.LA(1);
            	        	    
            	        	    if ( (LA15_0 == 34) )
            	        	    {
            	        	        alt15 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt15) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:52: ',' LID ( '(' signedNumber ')' )?
            	        			    {
            	        			    	Match(input,34,FOLLOW_34_in_enumeratedType366); 
            	        			    	Match(input,LID,FOLLOW_LID_in_enumeratedType368); 
            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:60: ( '(' signedNumber ')' )?
            	        			    	int alt14 = 2;
            	        			    	int LA14_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA14_0 == 32) )
            	        			    	{
            	        			    	    alt14 = 1;
            	        			    	}
            	        			    	switch (alt14) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:62: '(' signedNumber ')'
            	        			    	        {
            	        			    	        	Match(input,32,FOLLOW_32_in_enumeratedType372); 
            	        			    	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType374);
            	        			    	        	signedNumber();
            	        			    	        	followingStackPointer_--;

            	        			    	        	Match(input,33,FOLLOW_33_in_enumeratedType376); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop15;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop15:
            	        		;	// Stops C# compiler whinging that label 'loop15' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,35,FOLLOW_35_in_enumeratedType384); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end enumeratedType

    
    // $ANTLR start integerType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:1: integerType : 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )? ;
    public void integerType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:4: ( 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:4: 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )?
            {
            	Match(input,38,FOLLOW_38_in_integerType396); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:14: ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )?
            	int alt19 = 2;
            	int LA19_0 = input.LA(1);
            	
            	if ( (LA19_0 == 31) )
            	{
            	    alt19 = 1;
            	}
            	switch (alt19) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:16: '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}'
            	        {
            	        	Match(input,31,FOLLOW_31_in_integerType400); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:20: ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )?
            	        	int alt18 = 2;
            	        	int LA18_0 = input.LA(1);
            	        	
            	        	if ( (LA18_0 == LID) )
            	        	{
            	        	    alt18 = 1;
            	        	}
            	        	switch (alt18) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:21: LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )*
            	        	        {
            	        	        	Match(input,LID,FOLLOW_LID_in_integerType403); 
            	        	        	Match(input,32,FOLLOW_32_in_integerType405); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_integerType407);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,33,FOLLOW_33_in_integerType409); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:46: ( ',' LID '(' signedNumber ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt17 = 2;
            	        	        	    int LA17_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA17_0 == 34) )
            	        	        	    {
            	        	        	        alt17 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt17) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:47: ',' LID '(' signedNumber ')'
            	        	        			    {
            	        	        			    	Match(input,34,FOLLOW_34_in_integerType412); 
            	        	        			    	Match(input,LID,FOLLOW_LID_in_integerType414); 
            	        	        			    	Match(input,32,FOLLOW_32_in_integerType416); 
            	        	        			    	PushFollow(FOLLOW_signedNumber_in_integerType418);
            	        	        			    	signedNumber();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,33,FOLLOW_33_in_integerType420); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop17;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop17:
            	        	        		;	// Stops C# compiler whinging that label 'loop17' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,35,FOLLOW_35_in_integerType426); 
            	        
            	        }
            	        break;
            	
            	}

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end integerType

    
    // $ANTLR start realType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:1: realType : 'REAL' ;
    public void realType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:62:4: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:62:4: 'REAL'
            {
            	Match(input,39,FOLLOW_39_in_realType441); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end realType

    
    // $ANTLR start choiceType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:1: choiceType : 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}' ;
    public void choiceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:4: ( 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:4: 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}'
            {
            	Match(input,40,FOLLOW_40_in_choiceType453); 
            	Match(input,31,FOLLOW_31_in_choiceType455); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:17: ( LID type ( ',' LID type )* )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);
            	
            	if ( (LA21_0 == LID) )
            	{
            	    alt21 = 1;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:18: LID type ( ',' LID type )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_choiceType458); 
            	        	PushFollow(FOLLOW_type_in_choiceType460);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:27: ( ',' LID type )*
            	        	do 
            	        	{
            	        	    int alt20 = 2;
            	        	    int LA20_0 = input.LA(1);
            	        	    
            	        	    if ( (LA20_0 == 34) )
            	        	    {
            	        	        alt20 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt20) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:28: ',' LID type
            	        			    {
            	        			    	Match(input,34,FOLLOW_34_in_choiceType463); 
            	        			    	Match(input,LID,FOLLOW_LID_in_choiceType465); 
            	        			    	PushFollow(FOLLOW_type_in_choiceType467);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop20;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop20:
            	        		;	// Stops C# compiler whinging that label 'loop20' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,35,FOLLOW_35_in_choiceType474); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end choiceType

    
    // $ANTLR start sequenceType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:1: sequenceType : 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}' ;
    public void sequenceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:4: ( 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:4: 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}'
            {
            	Match(input,41,FOLLOW_41_in_sequenceType485); 
            	Match(input,31,FOLLOW_31_in_sequenceType487); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:19: ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )?
            	int alt25 = 2;
            	int LA25_0 = input.LA(1);
            	
            	if ( (LA25_0 == LID) )
            	{
            	    alt25 = 1;
            	}
            	switch (alt25) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:20: LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_sequenceType490); 
            	        	PushFollow(FOLLOW_type_in_sequenceType492);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:29: ( 'OPTIONAL' )?
            	        	int alt22 = 2;
            	        	int LA22_0 = input.LA(1);
            	        	
            	        	if ( (LA22_0 == 42) )
            	        	{
            	        	    alt22 = 1;
            	        	}
            	        	switch (alt22) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:30: 'OPTIONAL'
            	        	        {
            	        	        	Match(input,42,FOLLOW_42_in_sequenceType495); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:44: ( ',' LID type ( 'OPTIONAL' )? )*
            	        	do 
            	        	{
            	        	    int alt24 = 2;
            	        	    int LA24_0 = input.LA(1);
            	        	    
            	        	    if ( (LA24_0 == 34) )
            	        	    {
            	        	        alt24 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt24) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:45: ',' LID type ( 'OPTIONAL' )?
            	        			    {
            	        			    	Match(input,34,FOLLOW_34_in_sequenceType501); 
            	        			    	Match(input,LID,FOLLOW_LID_in_sequenceType503); 
            	        			    	PushFollow(FOLLOW_type_in_sequenceType505);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:58: ( 'OPTIONAL' )?
            	        			    	int alt23 = 2;
            	        			    	int LA23_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA23_0 == 42) )
            	        			    	{
            	        			    	    alt23 = 1;
            	        			    	}
            	        			    	switch (alt23) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:59: 'OPTIONAL'
            	        			    	        {
            	        			    	        	Match(input,42,FOLLOW_42_in_sequenceType508); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop24;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop24:
            	        		;	// Stops C# compiler whinging that label 'loop24' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,35,FOLLOW_35_in_sequenceType518); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end sequenceType

    
    // $ANTLR start sequenceOfType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:1: sequenceOfType : 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type ;
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:4: ( 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:4: 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type
            {
            	Match(input,41,FOLLOW_41_in_sequenceOfType531); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:15: ( '(' 'SIZE' constraint ')' )?
            	int alt26 = 2;
            	int LA26_0 = input.LA(1);
            	
            	if ( (LA26_0 == 32) )
            	{
            	    alt26 = 1;
            	}
            	switch (alt26) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:17: '(' 'SIZE' constraint ')'
            	        {
            	        	Match(input,32,FOLLOW_32_in_sequenceOfType535); 
            	        	Match(input,43,FOLLOW_43_in_sequenceOfType537); 
            	        	PushFollow(FOLLOW_constraint_in_sequenceOfType539);
            	        	constraint();
            	        	followingStackPointer_--;

            	        	Match(input,33,FOLLOW_33_in_sequenceOfType541); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,44,FOLLOW_44_in_sequenceOfType546); 
            	PushFollow(FOLLOW_type_in_sequenceOfType548);
            	type();
            	followingStackPointer_--;

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end sequenceOfType

    
    // $ANTLR start octetStringType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:1: octetStringType : 'OCTET' 'STRING' ;
    public void octetStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:4: ( 'OCTET' 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:4: 'OCTET' 'STRING'
            {
            	Match(input,45,FOLLOW_45_in_octetStringType562); 
            	Match(input,30,FOLLOW_30_in_octetStringType564); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end octetStringType

    
    // $ANTLR start namedNumber
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:1: namedNumber : LID '(' signedNumber ')' ;
    public void namedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:83:4: ( LID '(' signedNumber ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:83:4: LID '(' signedNumber ')'
            {
            	Match(input,LID,FOLLOW_LID_in_namedNumber576); 
            	Match(input,32,FOLLOW_32_in_namedNumber578); 
            	PushFollow(FOLLOW_signedNumber_in_namedNumber580);
            	signedNumber();
            	followingStackPointer_--;

            	Match(input,33,FOLLOW_33_in_namedNumber582); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end namedNumber

    
    // $ANTLR start signedNumber
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:86:1: signedNumber : ( '+' | '-' )? INT ;
    public void signedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:87:4: ( ( '+' | '-' )? INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:87:4: ( '+' | '-' )? INT
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:87:4: ( '+' | '-' )?
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);
            	
            	if ( ((LA27_0 >= 46 && LA27_0 <= 47)) )
            	{
            	    alt27 = 1;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( (input.LA(1) >= 46 && input.LA(1) <= 47) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber593);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber600); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end signedNumber

    
    // $ANTLR start constraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:1: constraint : '(' unionSet ( ',' '..' ( ',' unionSet )? )? ')' ;
    public void constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:4: ( '(' unionSet ( ',' '..' ( ',' unionSet )? )? ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:4: '(' unionSet ( ',' '..' ( ',' unionSet )? )? ')'
            {
            	Match(input,32,FOLLOW_32_in_constraint612); 
            	PushFollow(FOLLOW_unionSet_in_constraint614);
            	unionSet();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:17: ( ',' '..' ( ',' unionSet )? )?
            	int alt29 = 2;
            	int LA29_0 = input.LA(1);
            	
            	if ( (LA29_0 == 34) )
            	{
            	    alt29 = 1;
            	}
            	switch (alt29) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:18: ',' '..' ( ',' unionSet )?
            	        {
            	        	Match(input,34,FOLLOW_34_in_constraint617); 
            	        	Match(input,48,FOLLOW_48_in_constraint619); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:27: ( ',' unionSet )?
            	        	int alt28 = 2;
            	        	int LA28_0 = input.LA(1);
            	        	
            	        	if ( (LA28_0 == 34) )
            	        	{
            	        	    alt28 = 1;
            	        	}
            	        	switch (alt28) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:91:28: ',' unionSet
            	        	        {
            	        	        	Match(input,34,FOLLOW_34_in_constraint622); 
            	        	        	PushFollow(FOLLOW_unionSet_in_constraint624);
            	        	        	unionSet();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,33,FOLLOW_33_in_constraint630); 
            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end constraint

    
    // $ANTLR start unionSet
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:1: unionSet : ( intersectionSet ( UnionMark intersectionSet )* | 'ALL' 'EXCEPT' element );
    public void unionSet() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:95:4: ( intersectionSet ( UnionMark intersectionSet )* | 'ALL' 'EXCEPT' element )
            int alt31 = 2;
            int LA31_0 = input.LA(1);
            
            if ( ((LA31_0 >= LID && LA31_0 <= INT) || (LA31_0 >= Bstring && LA31_0 <= Hstring) || LA31_0 == 32 || LA31_0 == 43 || (LA31_0 >= 46 && LA31_0 <= 47) || (LA31_0 >= 53 && LA31_0 <= 56)) )
            {
                alt31 = 1;
            }
            else if ( (LA31_0 == 49) )
            {
                alt31 = 2;
            }
            else 
            {
                NoViableAltException nvae_d31s0 =
                    new NoViableAltException("94:1: unionSet : ( intersectionSet ( UnionMark intersectionSet )* | 'ALL' 'EXCEPT' element );", 31, 0, input);
            
                throw nvae_d31s0;
            }
            switch (alt31) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:95:4: intersectionSet ( UnionMark intersectionSet )*
                    {
                    	PushFollow(FOLLOW_intersectionSet_in_unionSet642);
                    	intersectionSet();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:95:20: ( UnionMark intersectionSet )*
                    	do 
                    	{
                    	    int alt30 = 2;
                    	    int LA30_0 = input.LA(1);
                    	    
                    	    if ( (LA30_0 == UnionMark) )
                    	    {
                    	        alt30 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt30) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:95:21: UnionMark intersectionSet
                    			    {
                    			    	Match(input,UnionMark,FOLLOW_UnionMark_in_unionSet645); 
                    			    	PushFollow(FOLLOW_intersectionSet_in_unionSet647);
                    			    	intersectionSet();
                    			    	followingStackPointer_--;

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop30;
                    	    }
                    	} while (true);
                    	
                    	loop30:
                    		;	// Stops C# compiler whinging that label 'loop30' has no statements

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:96:4: 'ALL' 'EXCEPT' element
                    {
                    	Match(input,49,FOLLOW_49_in_unionSet656); 
                    	Match(input,50,FOLLOW_50_in_unionSet659); 
                    	PushFollow(FOLLOW_element_in_unionSet661);
                    	element();
                    	followingStackPointer_--;

                    
                    }
                    break;
            
            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end unionSet

    
    // $ANTLR start intersectionSet
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:99:1: intersectionSet : element ( 'EXCEPT' element )? ( IntersectionMark element ( 'EXCEPT' element )? )* ;
    public void intersectionSet() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:4: ( element ( 'EXCEPT' element )? ( IntersectionMark element ( 'EXCEPT' element )? )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:4: element ( 'EXCEPT' element )? ( IntersectionMark element ( 'EXCEPT' element )? )*
            {
            	PushFollow(FOLLOW_element_in_intersectionSet674);
            	element();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:12: ( 'EXCEPT' element )?
            	int alt32 = 2;
            	int LA32_0 = input.LA(1);
            	
            	if ( (LA32_0 == 50) )
            	{
            	    alt32 = 1;
            	}
            	switch (alt32) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:14: 'EXCEPT' element
            	        {
            	        	Match(input,50,FOLLOW_50_in_intersectionSet678); 
            	        	PushFollow(FOLLOW_element_in_intersectionSet680);
            	        	element();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:33: ( IntersectionMark element ( 'EXCEPT' element )? )*
            	do 
            	{
            	    int alt34 = 2;
            	    int LA34_0 = input.LA(1);
            	    
            	    if ( (LA34_0 == IntersectionMark) )
            	    {
            	        alt34 = 1;
            	    }
            	    
            	
            	    switch (alt34) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:34: IntersectionMark element ( 'EXCEPT' element )?
            			    {
            			    	Match(input,IntersectionMark,FOLLOW_IntersectionMark_in_intersectionSet685); 
            			    	PushFollow(FOLLOW_element_in_intersectionSet687);
            			    	element();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:59: ( 'EXCEPT' element )?
            			    	int alt33 = 2;
            			    	int LA33_0 = input.LA(1);
            			    	
            			    	if ( (LA33_0 == 50) )
            			    	{
            			    	    alt33 = 1;
            			    	}
            			    	switch (alt33) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:61: 'EXCEPT' element
            			    	        {
            			    	        	Match(input,50,FOLLOW_50_in_intersectionSet691); 
            			    	        	PushFollow(FOLLOW_element_in_intersectionSet693);
            			    	        	element();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop34;
            	    }
            	} while (true);
            	
            	loop34:
            		;	// Stops C# compiler whinging that label 'loop34' has no statements

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end intersectionSet

    
    // $ANTLR start element
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:103:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | '(' unionSet ')' | 'SIZE' constraint );
    public void element() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:5: ( value ( ( '<' )? '..' ( '<' )? value )? | '(' unionSet ')' | 'SIZE' constraint )
            int alt38 = 3;
            switch ( input.LA(1) ) 
            {
            case LID:
            case INT:
            case Bstring:
            case Hstring:
            case 46:
            case 47:
            case 53:
            case 54:
            case 55:
            case 56:
            	{
                alt38 = 1;
                }
                break;
            case 32:
            	{
                alt38 = 2;
                }
                break;
            case 43:
            	{
                alt38 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d38s0 =
            	        new NoViableAltException("103:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | '(' unionSet ')' | 'SIZE' constraint );", 38, 0, input);
            
            	    throw nvae_d38s0;
            }
            
            switch (alt38) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:5: value ( ( '<' )? '..' ( '<' )? value )?
                    {
                    	PushFollow(FOLLOW_value_in_element709);
                    	value();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:11: ( ( '<' )? '..' ( '<' )? value )?
                    	int alt37 = 2;
                    	int LA37_0 = input.LA(1);
                    	
                    	if ( (LA37_0 == 48 || LA37_0 == 51) )
                    	{
                    	    alt37 = 1;
                    	}
                    	switch (alt37) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:13: ( '<' )? '..' ( '<' )? value
                    	        {
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:13: ( '<' )?
                    	        	int alt35 = 2;
                    	        	int LA35_0 = input.LA(1);
                    	        	
                    	        	if ( (LA35_0 == 51) )
                    	        	{
                    	        	    alt35 = 1;
                    	        	}
                    	        	switch (alt35) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:14: '<'
                    	        	        {
                    	        	        	Match(input,51,FOLLOW_51_in_element714); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	Match(input,48,FOLLOW_48_in_element718); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:25: ( '<' )?
                    	        	int alt36 = 2;
                    	        	int LA36_0 = input.LA(1);
                    	        	
                    	        	if ( (LA36_0 == 51) )
                    	        	{
                    	        	    alt36 = 1;
                    	        	}
                    	        	switch (alt36) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:26: '<'
                    	        	        {
                    	        	        	Match(input,51,FOLLOW_51_in_element721); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	PushFollow(FOLLOW_value_in_element725);
                    	        	value();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:4: '(' unionSet ')'
                    {
                    	Match(input,32,FOLLOW_32_in_element732); 
                    	PushFollow(FOLLOW_unionSet_in_element734);
                    	unionSet();
                    	followingStackPointer_--;

                    	Match(input,33,FOLLOW_33_in_element736); 
                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:106:4: 'SIZE' constraint
                    {
                    	Match(input,43,FOLLOW_43_in_element741); 
                    	PushFollow(FOLLOW_constraint_in_element743);
                    	constraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
            
            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end element

    
    // $ANTLR start value
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:109:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:3: ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' )
            int alt42 = 6;
            switch ( input.LA(1) ) 
            {
            case Bstring:
            case Hstring:
            	{
                alt42 = 1;
                }
                break;
            case 55:
            case 56:
            	{
                alt42 = 2;
                }
                break;
            case LID:
            	{
                alt42 = 3;
                }
                break;
            case INT:
            case 46:
            case 47:
            	{
                alt42 = 4;
                }
                break;
            case 53:
            	{
                alt42 = 5;
                }
                break;
            case 54:
            	{
                alt42 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d42s0 =
            	        new NoViableAltException("109:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' );", 42, 0, input);
            
            	    throw nvae_d42s0;
            }
            
            switch (alt42) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:3: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value756);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:112:4: booleanValue
                    {
                    	PushFollow(FOLLOW_booleanValue_in_value761);
                    	booleanValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:114:4: LID
                    {
                    	Match(input,LID,FOLLOW_LID_in_value767); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:4: ( '+' | '-' )?
                    	int alt39 = 2;
                    	int LA39_0 = input.LA(1);
                    	
                    	if ( ((LA39_0 >= 46 && LA39_0 <= 47)) )
                    	{
                    	    alt39 = 1;
                    	}
                    	switch (alt39) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
                    	        {
                    	        	if ( (input.LA(1) >= 46 && input.LA(1) <= 47) ) 
                    	        	{
                    	        	    input.Consume();
                    	        	    errorRecovery = false;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse =
                    	        	        new MismatchedSetException(null,input);
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value774);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value781); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:19: ( '.' ( INT )? )?
                    	int alt41 = 2;
                    	int LA41_0 = input.LA(1);
                    	
                    	if ( (LA41_0 == 52) )
                    	{
                    	    alt41 = 1;
                    	}
                    	switch (alt41) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:20: '.' ( INT )?
                    	        {
                    	        	Match(input,52,FOLLOW_52_in_value784); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:24: ( INT )?
                    	        	int alt40 = 2;
                    	        	int LA40_0 = input.LA(1);
                    	        	
                    	        	if ( (LA40_0 == INT) )
                    	        	{
                    	        	    alt40 = 1;
                    	        	}
                    	        	switch (alt40) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value786); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:116:4: 'MIN'
                    {
                    	Match(input,53,FOLLOW_53_in_value794); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:117:4: 'MAX'
                    {
                    	Match(input,54,FOLLOW_54_in_value799); 
                    
                    }
                    break;
            
            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end value

    
    // $ANTLR start bitStringValue
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:120:1: bitStringValue : ( Bstring | Hstring );
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:4: ( Bstring | Hstring )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            {
            	if ( (input.LA(1) >= Bstring && input.LA(1) <= Hstring) ) 
            	{
            	    input.Consume();
            	    errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse =
            	        new MismatchedSetException(null,input);
            	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_bitStringValue0);    throw mse;
            	}

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end bitStringValue

    
    // $ANTLR start booleanValue
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:1: booleanValue : ( 'TRUE' | 'FALSE' );
    public void booleanValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:4: ( 'TRUE' | 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            {
            	if ( (input.LA(1) >= 55 && input.LA(1) <= 56) ) 
            	{
            	    input.Consume();
            	    errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse =
            	        new MismatchedSetException(null,input);
            	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_booleanValue0);    throw mse;
            	}

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
        }
        return ;
    }
    // $ANTLR end booleanValue


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_UID_in_moduleDefinition28 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_14_in_moduleDefinition36 = new BitSet(new ulong[]{0x00000000002E8000UL});
    public static readonly BitSet FOLLOW_15_in_moduleDefinition42 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_16_in_moduleDefinition44 = new BitSet(new ulong[]{0x0000000000280000UL});
    public static readonly BitSet FOLLOW_17_in_moduleDefinition48 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_16_in_moduleDefinition50 = new BitSet(new ulong[]{0x0000000000280000UL});
    public static readonly BitSet FOLLOW_18_in_moduleDefinition54 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_16_in_moduleDefinition56 = new BitSet(new ulong[]{0x0000000000280000UL});
    public static readonly BitSet FOLLOW_19_in_moduleDefinition64 = new BitSet(new ulong[]{0x0000000000100000UL});
    public static readonly BitSet FOLLOW_20_in_moduleDefinition66 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_21_in_moduleDefinition73 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_22_in_moduleDefinition75 = new BitSet(new ulong[]{0x0000000000800030UL});
    public static readonly BitSet FOLLOW_typeAssigment_in_moduleDefinition86 = new BitSet(new ulong[]{0x0000000000800030UL});
    public static readonly BitSet FOLLOW_valueAssigment_in_moduleDefinition93 = new BitSet(new ulong[]{0x0000000000800030UL});
    public static readonly BitSet FOLLOW_23_in_moduleDefinition104 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valueAssigment115 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_valueAssigment117 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_21_in_valueAssigment119 = new BitSet(new ulong[]{0x01E0C00000000660UL});
    public static readonly BitSet FOLLOW_value_in_valueAssigment121 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typeAssigment138 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_21_in_typeAssigment140 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_typeAssigment142 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_24_in_type154 = new BitSet(new ulong[]{0x000000000E000040UL});
    public static readonly BitSet FOLLOW_set_in_type156 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_type169 = new BitSet(new ulong[]{0x0000000010000000UL});
    public static readonly BitSet FOLLOW_28_in_type172 = new BitSet(new ulong[]{0x000023F020028010UL});
    public static readonly BitSet FOLLOW_set_in_type174 = new BitSet(new ulong[]{0x000023F020000010UL});
    public static readonly BitSet FOLLOW_bitStringType_in_type196 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_booleanType_in_type204 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type212 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type220 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_integerType_in_type228 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_octetStringType_in_type236 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_realType_in_type244 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type252 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_UID_in_type260 = new BitSet(new ulong[]{0x0000000100000002UL});
    public static readonly BitSet FOLLOW_constraint_in_type268 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type273 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_29_in_bitStringType287 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_bitStringType289 = new BitSet(new ulong[]{0x0000000080000002UL});
    public static readonly BitSet FOLLOW_31_in_bitStringType292 = new BitSet(new ulong[]{0x0000000800000020UL});
    public static readonly BitSet FOLLOW_LID_in_bitStringType295 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_bitStringType297 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType299 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_bitStringType301 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_34_in_bitStringType304 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_bitStringType306 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_bitStringType308 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType310 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_bitStringType312 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_35_in_bitStringType320 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_booleanType335 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_37_in_enumeratedType348 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_enumeratedType350 = new BitSet(new ulong[]{0x0000000800000020UL});
    public static readonly BitSet FOLLOW_LID_in_enumeratedType353 = new BitSet(new ulong[]{0x0000000D00000000UL});
    public static readonly BitSet FOLLOW_32_in_enumeratedType357 = new BitSet(new ulong[]{0x0000C00000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType359 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_enumeratedType361 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_34_in_enumeratedType366 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_enumeratedType368 = new BitSet(new ulong[]{0x0000000D00000000UL});
    public static readonly BitSet FOLLOW_32_in_enumeratedType372 = new BitSet(new ulong[]{0x0000C00000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType374 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_enumeratedType376 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_35_in_enumeratedType384 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_38_in_integerType396 = new BitSet(new ulong[]{0x0000000080000002UL});
    public static readonly BitSet FOLLOW_31_in_integerType400 = new BitSet(new ulong[]{0x0000000800000020UL});
    public static readonly BitSet FOLLOW_LID_in_integerType403 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_integerType405 = new BitSet(new ulong[]{0x0000C00000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType407 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_integerType409 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_34_in_integerType412 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_integerType414 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_integerType416 = new BitSet(new ulong[]{0x0000C00000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType418 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_integerType420 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_35_in_integerType426 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_realType441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_choiceType453 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_choiceType455 = new BitSet(new ulong[]{0x0000000800000020UL});
    public static readonly BitSet FOLLOW_LID_in_choiceType458 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_choiceType460 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_34_in_choiceType463 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_choiceType465 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_choiceType467 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_35_in_choiceType474 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_41_in_sequenceType485 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_31_in_sequenceType487 = new BitSet(new ulong[]{0x0000000800000020UL});
    public static readonly BitSet FOLLOW_LID_in_sequenceType490 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType492 = new BitSet(new ulong[]{0x0000040C00000000UL});
    public static readonly BitSet FOLLOW_42_in_sequenceType495 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_34_in_sequenceType501 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_sequenceType503 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType505 = new BitSet(new ulong[]{0x0000040C00000000UL});
    public static readonly BitSet FOLLOW_42_in_sequenceType508 = new BitSet(new ulong[]{0x0000000C00000000UL});
    public static readonly BitSet FOLLOW_35_in_sequenceType518 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_41_in_sequenceOfType531 = new BitSet(new ulong[]{0x0000100100000000UL});
    public static readonly BitSet FOLLOW_32_in_sequenceOfType535 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_43_in_sequenceOfType537 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_constraint_in_sequenceOfType539 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_sequenceOfType541 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_sequenceOfType546 = new BitSet(new ulong[]{0x000023F021000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType548 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_octetStringType562 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_30_in_octetStringType564 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_namedNumber576 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_namedNumber578 = new BitSet(new ulong[]{0x0000C00000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_namedNumber580 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_namedNumber582 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber593 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber600 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_constraint612 = new BitSet(new ulong[]{0x01E2C80100000660UL});
    public static readonly BitSet FOLLOW_unionSet_in_constraint614 = new BitSet(new ulong[]{0x0000000600000000UL});
    public static readonly BitSet FOLLOW_34_in_constraint617 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_constraint619 = new BitSet(new ulong[]{0x0000000600000000UL});
    public static readonly BitSet FOLLOW_34_in_constraint622 = new BitSet(new ulong[]{0x01E2C80100000660UL});
    public static readonly BitSet FOLLOW_unionSet_in_constraint624 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_constraint630 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_intersectionSet_in_unionSet642 = new BitSet(new ulong[]{0x0000000000000082UL});
    public static readonly BitSet FOLLOW_UnionMark_in_unionSet645 = new BitSet(new ulong[]{0x01E0C80100000660UL});
    public static readonly BitSet FOLLOW_intersectionSet_in_unionSet647 = new BitSet(new ulong[]{0x0000000000000082UL});
    public static readonly BitSet FOLLOW_49_in_unionSet656 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_50_in_unionSet659 = new BitSet(new ulong[]{0x01E0C80100000660UL});
    public static readonly BitSet FOLLOW_element_in_unionSet661 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_intersectionSet674 = new BitSet(new ulong[]{0x0004000000000102UL});
    public static readonly BitSet FOLLOW_50_in_intersectionSet678 = new BitSet(new ulong[]{0x01E0C80100000660UL});
    public static readonly BitSet FOLLOW_element_in_intersectionSet680 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_IntersectionMark_in_intersectionSet685 = new BitSet(new ulong[]{0x01E0C80100000660UL});
    public static readonly BitSet FOLLOW_element_in_intersectionSet687 = new BitSet(new ulong[]{0x0004000000000102UL});
    public static readonly BitSet FOLLOW_50_in_intersectionSet691 = new BitSet(new ulong[]{0x01E0C80100000660UL});
    public static readonly BitSet FOLLOW_element_in_intersectionSet693 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_value_in_element709 = new BitSet(new ulong[]{0x0009000000000002UL});
    public static readonly BitSet FOLLOW_51_in_element714 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_element718 = new BitSet(new ulong[]{0x01E8C00000000660UL});
    public static readonly BitSet FOLLOW_51_in_element721 = new BitSet(new ulong[]{0x01E0C00000000660UL});
    public static readonly BitSet FOLLOW_value_in_element725 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_32_in_element732 = new BitSet(new ulong[]{0x01E2C80100000660UL});
    public static readonly BitSet FOLLOW_unionSet_in_element734 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_33_in_element736 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_43_in_element741 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_constraint_in_element743 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value756 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanValue_in_value761 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_value767 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value774 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_value781 = new BitSet(new ulong[]{0x0010000000000002UL});
    public static readonly BitSet FOLLOW_52_in_value784 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_INT_in_value786 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_53_in_value794 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_54_in_value799 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_bitStringValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_booleanValue0 = new BitSet(new ulong[]{0x0000000000000002UL});

}
