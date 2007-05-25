// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-25 19:40:05



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
		"'EXPORTS'", 
		"'ALL'", 
		"';'", 
		"','", 
		"'IMPORTS'", 
		"'FROM'", 
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
		"'<'", 
		"'..'", 
		"'.'", 
		"'MIN'", 
		"'MAX'", 
		"'TRUE'", 
		"'FALSE'"
    };

    public const int WS = 9;
    public const int LINE_COMMENT = 11;
    public const int Hstring = 8;
    public const int Bstring = 7;
    public const int INT = 6;
    public const int UID = 4;
    public const int COMMENT = 10;
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:1: moduleDefinition : UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( exports )? ( imports )? ( typeAssigment | valueAssigment )* 'END' ;
    public void moduleDefinition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:22: ( UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( exports )? ( imports )? ( typeAssigment | valueAssigment )* 'END' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:9:22: UID 'DEFINITIONS' ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )? ( 'EXTENSIBILITY' 'IMPLIED' )? '::=' 'BEGIN' ( exports )? ( imports )? ( typeAssigment | valueAssigment )* 'END'
            {
            	Match(input,UID,FOLLOW_UID_in_moduleDefinition28); 
            	Match(input,12,FOLLOW_12_in_moduleDefinition36); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:4: ( 'EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS' )?
            	int alt1 = 4;
            	switch ( input.LA(1) ) 
            	{
            	    case 13:
            	    	{
            	        alt1 = 1;
            	        }
            	        break;
            	    case 15:
            	    	{
            	        alt1 = 2;
            	        }
            	        break;
            	    case 16:
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
            	        	Match(input,13,FOLLOW_13_in_moduleDefinition42); 
            	        	Match(input,14,FOLLOW_14_in_moduleDefinition44); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:25: 'IMPLICIT' 'TAGS'
            	        {
            	        	Match(input,15,FOLLOW_15_in_moduleDefinition48); 
            	        	Match(input,14,FOLLOW_14_in_moduleDefinition50); 
            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:45: 'AUTOMATIC' 'TAGS'
            	        {
            	        	Match(input,16,FOLLOW_16_in_moduleDefinition54); 
            	        	Match(input,14,FOLLOW_14_in_moduleDefinition56); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: ( 'EXTENSIBILITY' 'IMPLIED' )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);
            	
            	if ( (LA2_0 == 17) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:5: 'EXTENSIBILITY' 'IMPLIED'
            	        {
            	        	Match(input,17,FOLLOW_17_in_moduleDefinition64); 
            	        	Match(input,18,FOLLOW_18_in_moduleDefinition66); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,19,FOLLOW_19_in_moduleDefinition73); 
            	Match(input,20,FOLLOW_20_in_moduleDefinition75); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:4: ( exports )?
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);
            	
            	if ( (LA3_0 == 22) )
            	{
            	    alt3 = 1;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:5: exports
            	        {
            	        	PushFollow(FOLLOW_exports_in_moduleDefinition81);
            	        	exports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:4: ( imports )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);
            	
            	if ( (LA4_0 == 26) )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:15:5: imports
            	        {
            	        	PushFollow(FOLLOW_imports_in_moduleDefinition89);
            	        	imports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:4: ( typeAssigment | valueAssigment )*
            	do 
            	{
            	    int alt5 = 3;
            	    int LA5_0 = input.LA(1);
            	    
            	    if ( (LA5_0 == UID) )
            	    {
            	        alt5 = 1;
            	    }
            	    else if ( (LA5_0 == LID) )
            	    {
            	        alt5 = 2;
            	    }
            	    
            	
            	    switch (alt5) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:5: typeAssigment
            			    {
            			    	PushFollow(FOLLOW_typeAssigment_in_moduleDefinition102);
            			    	typeAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            			case 2 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:6: valueAssigment
            			    {
            			    	PushFollow(FOLLOW_valueAssigment_in_moduleDefinition109);
            			    	valueAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop5;
            	    }
            	} while (true);
            	
            	loop5:
            		;	// Stops C# compiler whinging that label 'loop5' has no statements

            	Match(input,21,FOLLOW_21_in_moduleDefinition120); 
            
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

    
    // $ANTLR start exports
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:1: exports : ( 'EXPORTS' 'ALL' ';' | 'EXPORTS' ( UID | LID ) ( ',' ( UID | LID ) )* ';' );
    public void exports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:3: ( 'EXPORTS' 'ALL' ';' | 'EXPORTS' ( UID | LID ) ( ',' ( UID | LID ) )* ';' )
            int alt7 = 2;
            int LA7_0 = input.LA(1);
            
            if ( (LA7_0 == 22) )
            {
                int LA7_1 = input.LA(2);
                
                if ( (LA7_1 == 23) )
                {
                    alt7 = 1;
                }
                else if ( ((LA7_1 >= UID && LA7_1 <= LID)) )
                {
                    alt7 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d7s1 =
                        new NoViableAltException("22:1: exports : ( 'EXPORTS' 'ALL' ';' | 'EXPORTS' ( UID | LID ) ( ',' ( UID | LID ) )* ';' );", 7, 1, input);
                
                    throw nvae_d7s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d7s0 =
                    new NoViableAltException("22:1: exports : ( 'EXPORTS' 'ALL' ';' | 'EXPORTS' ( UID | LID ) ( ',' ( UID | LID ) )* ';' );", 7, 0, input);
            
                throw nvae_d7s0;
            }
            switch (alt7) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:3: 'EXPORTS' 'ALL' ';'
                    {
                    	Match(input,22,FOLLOW_22_in_exports133); 
                    	Match(input,23,FOLLOW_23_in_exports135); 
                    	Match(input,24,FOLLOW_24_in_exports137); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:4: 'EXPORTS' ( UID | LID ) ( ',' ( UID | LID ) )* ';'
                    {
                    	Match(input,22,FOLLOW_22_in_exports142); 
                    	if ( (input.LA(1) >= UID && input.LA(1) <= LID) ) 
                    	{
                    	    input.Consume();
                    	    errorRecovery = false;
                    	}
                    	else 
                    	{
                    	    MismatchedSetException mse =
                    	        new MismatchedSetException(null,input);
                    	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_exports144);    throw mse;
                    	}

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:26: ( ',' ( UID | LID ) )*
                    	do 
                    	{
                    	    int alt6 = 2;
                    	    int LA6_0 = input.LA(1);
                    	    
                    	    if ( (LA6_0 == 25) )
                    	    {
                    	        alt6 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt6) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:27: ',' ( UID | LID )
                    			    {
                    			    	Match(input,25,FOLLOW_25_in_exports153); 
                    			    	if ( (input.LA(1) >= UID && input.LA(1) <= LID) ) 
                    			    	{
                    			    	    input.Consume();
                    			    	    errorRecovery = false;
                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse =
                    			    	        new MismatchedSetException(null,input);
                    			    	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_exports155);    throw mse;
                    			    	}

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop6;
                    	    }
                    	} while (true);
                    	
                    	loop6:
                    		;	// Stops C# compiler whinging that label 'loop6' has no statements

                    	Match(input,24,FOLLOW_24_in_exports166); 
                    
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
    // $ANTLR end exports

    
    // $ANTLR start imports
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:1: imports : 'IMPORTS' ( ( UID | LID ) ( ',' ( UID | LID ) )* 'FROM' UID )* ';' ;
    public void imports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:2: ( 'IMPORTS' ( ( UID | LID ) ( ',' ( UID | LID ) )* 'FROM' UID )* ';' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:2: 'IMPORTS' ( ( UID | LID ) ( ',' ( UID | LID ) )* 'FROM' UID )* ';'
            {
            	Match(input,26,FOLLOW_26_in_imports179); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:12: ( ( UID | LID ) ( ',' ( UID | LID ) )* 'FROM' UID )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);
            	    
            	    if ( ((LA9_0 >= UID && LA9_0 <= LID)) )
            	    {
            	        alt9 = 1;
            	    }
            	    
            	
            	    switch (alt9) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:13: ( UID | LID ) ( ',' ( UID | LID ) )* 'FROM' UID
            			    {
            			    	if ( (input.LA(1) >= UID && input.LA(1) <= LID) ) 
            			    	{
            			    	    input.Consume();
            			    	    errorRecovery = false;
            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse =
            			    	        new MismatchedSetException(null,input);
            			    	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_imports182);    throw mse;
            			    	}

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:25: ( ',' ( UID | LID ) )*
            			    	do 
            			    	{
            			    	    int alt8 = 2;
            			    	    int LA8_0 = input.LA(1);
            			    	    
            			    	    if ( (LA8_0 == 25) )
            			    	    {
            			    	        alt8 = 1;
            			    	    }
            			    	    
            			    	
            			    	    switch (alt8) 
            			    		{
            			    			case 1 :
            			    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:26: ',' ( UID | LID )
            			    			    {
            			    			    	Match(input,25,FOLLOW_25_in_imports191); 
            			    			    	if ( (input.LA(1) >= UID && input.LA(1) <= LID) ) 
            			    			    	{
            			    			    	    input.Consume();
            			    			    	    errorRecovery = false;
            			    			    	}
            			    			    	else 
            			    			    	{
            			    			    	    MismatchedSetException mse =
            			    			    	        new MismatchedSetException(null,input);
            			    			    	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_imports193);    throw mse;
            			    			    	}

            			    			    
            			    			    }
            			    			    break;
            			    	
            			    			default:
            			    			    goto loop8;
            			    	    }
            			    	} while (true);
            			    	
            			    	loop8:
            			    		;	// Stops C# compiler whinging that label 'loop8' has no statements

            			    	Match(input,27,FOLLOW_27_in_imports203); 
            			    	Match(input,UID,FOLLOW_UID_in_imports205); 
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop9;
            	    }
            	} while (true);
            	
            	loop9:
            		;	// Stops C# compiler whinging that label 'loop9' has no statements

            	Match(input,24,FOLLOW_24_in_imports209); 
            
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
    // $ANTLR end imports

    
    // $ANTLR start valueAssigment
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:1: valueAssigment : LID type '::=' value ;
    public void valueAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:4: ( LID type '::=' value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:4: LID type '::=' value
            {
            	Match(input,LID,FOLLOW_LID_in_valueAssigment223); 
            	PushFollow(FOLLOW_type_in_valueAssigment225);
            	type();
            	followingStackPointer_--;

            	Match(input,19,FOLLOW_19_in_valueAssigment227); 
            	PushFollow(FOLLOW_value_in_valueAssigment229);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:1: typeAssigment : UID '::=' type ;
    public void typeAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:4: ( UID '::=' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:4: UID '::=' type
            {
            	Match(input,UID,FOLLOW_UID_in_typeAssigment246); 
            	Match(input,19,FOLLOW_19_in_typeAssigment248); 
            	PushFollow(FOLLOW_type_in_typeAssigment250);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:1: type : ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:8: ( ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:8: ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:8: ( '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )? )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);
            	
            	if ( (LA12_0 == 28) )
            	{
            	    alt12 = 1;
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:9: '[' ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )? INT ']' ( 'IMPLICIT' | 'EXPLICIT' )?
            	        {
            	        	Match(input,28,FOLLOW_28_in_type262); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:13: ( 'UNIVERSAL' | 'APPLICATION' | 'PRIVATE' )?
            	        	int alt10 = 2;
            	        	int LA10_0 = input.LA(1);
            	        	
            	        	if ( ((LA10_0 >= 29 && LA10_0 <= 31)) )
            	        	{
            	        	    alt10 = 1;
            	        	}
            	        	switch (alt10) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( (input.LA(1) >= 29 && input.LA(1) <= 31) ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type264);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,INT,FOLLOW_INT_in_type277); 
            	        	Match(input,32,FOLLOW_32_in_type280); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:65: ( 'IMPLICIT' | 'EXPLICIT' )?
            	        	int alt11 = 2;
            	        	int LA11_0 = input.LA(1);
            	        	
            	        	if ( (LA11_0 == 13 || LA11_0 == 15) )
            	        	{
            	        	    alt11 = 1;
            	        	}
            	        	switch (alt11) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( input.LA(1) == 13 || input.LA(1) == 15 ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type282);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType )
            	int alt15 = 4;
            	switch ( input.LA(1) ) 
            	{
            	case UID:
            	case 33:
            	case 39:
            	case 40:
            	case 41:
            	case 42:
            	case 48:
            		{
            	    alt15 = 1;
            	    }
            	    break;
            	case 44:
            		{
            	    int LA15_2 = input.LA(2);
            	    
            	    if ( (LA15_2 == 35) )
            	    {
            	        alt15 = 4;
            	    }
            	    else if ( (LA15_2 == 36 || LA15_2 == 47) )
            	    {
            	        alt15 = 2;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d15s2 =
            	            new NoViableAltException("40:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType )", 15, 2, input);
            	    
            	        throw nvae_d15s2;
            	    }
            	    }
            	    break;
            	case 43:
            		{
            	    alt15 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d15s0 =
            		        new NoViableAltException("40:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )? | sequenceOfType | choiceType | sequenceType )", 15, 0, input);
            	
            		    throw nvae_d15s0;
            	}
            	
            	switch (alt15) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID ) ( constraint )?
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID )
            	        	int alt13 = 7;
            	        	switch ( input.LA(1) ) 
            	        	{
            	        	case 33:
            	        		{
            	        	    alt13 = 1;
            	        	    }
            	        	    break;
            	        	case 39:
            	        		{
            	        	    alt13 = 2;
            	        	    }
            	        	    break;
            	        	case 40:
            	        		{
            	        	    alt13 = 3;
            	        	    }
            	        	    break;
            	        	case 41:
            	        		{
            	        	    alt13 = 4;
            	        	    }
            	        	    break;
            	        	case 48:
            	        		{
            	        	    alt13 = 5;
            	        	    }
            	        	    break;
            	        	case 42:
            	        		{
            	        	    alt13 = 6;
            	        	    }
            	        	    break;
            	        	case UID:
            	        		{
            	        	    alt13 = 7;
            	        	    }
            	        	    break;
            	        		default:
            	        		    NoViableAltException nvae_d13s0 =
            	        		        new NoViableAltException("40:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | UID )", 13, 0, input);
            	        	
            	        		    throw nvae_d13s0;
            	        	}
            	        	
            	        	switch (alt13) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:41:6: bitStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_bitStringType_in_type304);
            	        	        	bitStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:7: booleanType
            	        	        {
            	        	        	PushFollow(FOLLOW_booleanType_in_type312);
            	        	        	booleanType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 3 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:7: enumeratedType
            	        	        {
            	        	        	PushFollow(FOLLOW_enumeratedType_in_type320);
            	        	        	enumeratedType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 4 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:7: integerType
            	        	        {
            	        	        	PushFollow(FOLLOW_integerType_in_type328);
            	        	        	integerType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 5 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:7: octetStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_octetStringType_in_type336);
            	        	        	octetStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 6 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:46:7: realType
            	        	        {
            	        	        	PushFollow(FOLLOW_realType_in_type344);
            	        	        	realType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 7 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:7: UID
            	        	        {
            	        	        	Match(input,UID,FOLLOW_UID_in_type352); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:4: ( constraint )?
            	        	int alt14 = 2;
            	        	int LA14_0 = input.LA(1);
            	        	
            	        	if ( (LA14_0 == 36) )
            	        	{
            	        	    alt14 = 1;
            	        	}
            	        	switch (alt14) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:4: constraint
            	        	        {
            	        	        	PushFollow(FOLLOW_constraint_in_type360);
            	        	        	constraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type365);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:50:3: choiceType
            	        {
            	        	PushFollow(FOLLOW_choiceType_in_type369);
            	        	choiceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 4 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:51:10: sequenceType
            	        {
            	        	PushFollow(FOLLOW_sequenceType_in_type380);
            	        	sequenceType();
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:56:1: bitStringType : 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )? ;
    public void bitStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:4: ( 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:4: 'BIT' 'STRING' ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )?
            {
            	Match(input,33,FOLLOW_33_in_bitStringType394); 
            	Match(input,34,FOLLOW_34_in_bitStringType396); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:19: ( '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}' )?
            	int alt18 = 2;
            	int LA18_0 = input.LA(1);
            	
            	if ( (LA18_0 == 35) )
            	{
            	    alt18 = 1;
            	}
            	switch (alt18) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:20: '{' ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )? '}'
            	        {
            	        	Match(input,35,FOLLOW_35_in_bitStringType399); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:24: ( LID '(' INT ')' ( ',' LID '(' INT ')' )* )?
            	        	int alt17 = 2;
            	        	int LA17_0 = input.LA(1);
            	        	
            	        	if ( (LA17_0 == LID) )
            	        	{
            	        	    alt17 = 1;
            	        	}
            	        	switch (alt17) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:25: LID '(' INT ')' ( ',' LID '(' INT ')' )*
            	        	        {
            	        	        	Match(input,LID,FOLLOW_LID_in_bitStringType402); 
            	        	        	Match(input,36,FOLLOW_36_in_bitStringType404); 
            	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType406); 
            	        	        	Match(input,37,FOLLOW_37_in_bitStringType408); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:41: ( ',' LID '(' INT ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt16 = 2;
            	        	        	    int LA16_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA16_0 == 25) )
            	        	        	    {
            	        	        	        alt16 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt16) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:42: ',' LID '(' INT ')'
            	        	        			    {
            	        	        			    	Match(input,25,FOLLOW_25_in_bitStringType411); 
            	        	        			    	Match(input,LID,FOLLOW_LID_in_bitStringType413); 
            	        	        			    	Match(input,36,FOLLOW_36_in_bitStringType415); 
            	        	        			    	Match(input,INT,FOLLOW_INT_in_bitStringType417); 
            	        	        			    	Match(input,37,FOLLOW_37_in_bitStringType419); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop16;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop16:
            	        	        		;	// Stops C# compiler whinging that label 'loop16' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,38,FOLLOW_38_in_bitStringType427); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:1: booleanType : 'BOOLEAN' ;
    public void booleanType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:4: ( 'BOOLEAN' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:4: 'BOOLEAN'
            {
            	Match(input,39,FOLLOW_39_in_booleanType442); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:64:1: enumeratedType : 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}' ;
    public void enumeratedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:4: ( 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:4: 'ENUMERATED' '{' ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )? '}'
            {
            	Match(input,40,FOLLOW_40_in_enumeratedType455); 
            	Match(input,35,FOLLOW_35_in_enumeratedType457); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:21: ( LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )* )?
            	int alt22 = 2;
            	int LA22_0 = input.LA(1);
            	
            	if ( (LA22_0 == LID) )
            	{
            	    alt22 = 1;
            	}
            	switch (alt22) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:22: LID ( '(' signedNumber ')' )? ( ',' LID ( '(' signedNumber ')' )? )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_enumeratedType460); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:26: ( '(' signedNumber ')' )?
            	        	int alt19 = 2;
            	        	int LA19_0 = input.LA(1);
            	        	
            	        	if ( (LA19_0 == 36) )
            	        	{
            	        	    alt19 = 1;
            	        	}
            	        	switch (alt19) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:28: '(' signedNumber ')'
            	        	        {
            	        	        	Match(input,36,FOLLOW_36_in_enumeratedType464); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType466);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,37,FOLLOW_37_in_enumeratedType468); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:51: ( ',' LID ( '(' signedNumber ')' )? )*
            	        	do 
            	        	{
            	        	    int alt21 = 2;
            	        	    int LA21_0 = input.LA(1);
            	        	    
            	        	    if ( (LA21_0 == 25) )
            	        	    {
            	        	        alt21 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt21) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:52: ',' LID ( '(' signedNumber ')' )?
            	        			    {
            	        			    	Match(input,25,FOLLOW_25_in_enumeratedType473); 
            	        			    	Match(input,LID,FOLLOW_LID_in_enumeratedType475); 
            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:60: ( '(' signedNumber ')' )?
            	        			    	int alt20 = 2;
            	        			    	int LA20_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA20_0 == 36) )
            	        			    	{
            	        			    	    alt20 = 1;
            	        			    	}
            	        			    	switch (alt20) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:62: '(' signedNumber ')'
            	        			    	        {
            	        			    	        	Match(input,36,FOLLOW_36_in_enumeratedType479); 
            	        			    	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType481);
            	        			    	        	signedNumber();
            	        			    	        	followingStackPointer_--;

            	        			    	        	Match(input,37,FOLLOW_37_in_enumeratedType483); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop21;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop21:
            	        		;	// Stops C# compiler whinging that label 'loop21' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,38,FOLLOW_38_in_enumeratedType491); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:1: integerType : 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )? ;
    public void integerType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:4: ( 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:4: 'INTEGER' ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )?
            {
            	Match(input,41,FOLLOW_41_in_integerType503); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:14: ( '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}' )?
            	int alt25 = 2;
            	int LA25_0 = input.LA(1);
            	
            	if ( (LA25_0 == 35) )
            	{
            	    alt25 = 1;
            	}
            	switch (alt25) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:16: '{' ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )? '}'
            	        {
            	        	Match(input,35,FOLLOW_35_in_integerType507); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:20: ( LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )* )?
            	        	int alt24 = 2;
            	        	int LA24_0 = input.LA(1);
            	        	
            	        	if ( (LA24_0 == LID) )
            	        	{
            	        	    alt24 = 1;
            	        	}
            	        	switch (alt24) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:21: LID '(' signedNumber ')' ( ',' LID '(' signedNumber ')' )*
            	        	        {
            	        	        	Match(input,LID,FOLLOW_LID_in_integerType510); 
            	        	        	Match(input,36,FOLLOW_36_in_integerType512); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_integerType514);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,37,FOLLOW_37_in_integerType516); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:46: ( ',' LID '(' signedNumber ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt23 = 2;
            	        	        	    int LA23_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA23_0 == 25) )
            	        	        	    {
            	        	        	        alt23 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt23) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:47: ',' LID '(' signedNumber ')'
            	        	        			    {
            	        	        			    	Match(input,25,FOLLOW_25_in_integerType519); 
            	        	        			    	Match(input,LID,FOLLOW_LID_in_integerType521); 
            	        	        			    	Match(input,36,FOLLOW_36_in_integerType523); 
            	        	        			    	PushFollow(FOLLOW_signedNumber_in_integerType525);
            	        	        			    	signedNumber();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,37,FOLLOW_37_in_integerType527); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop23;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop23:
            	        	        		;	// Stops C# compiler whinging that label 'loop23' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,38,FOLLOW_38_in_integerType533); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:72:1: realType : 'REAL' ;
    public void realType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:4: ( 'REAL' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:4: 'REAL'
            {
            	Match(input,42,FOLLOW_42_in_realType548); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:1: choiceType : 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}' ;
    public void choiceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:4: ( 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:4: 'CHOICE' '{' ( LID type ( ',' LID type )* )? '}'
            {
            	Match(input,43,FOLLOW_43_in_choiceType560); 
            	Match(input,35,FOLLOW_35_in_choiceType562); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:17: ( LID type ( ',' LID type )* )?
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);
            	
            	if ( (LA27_0 == LID) )
            	{
            	    alt27 = 1;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:18: LID type ( ',' LID type )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_choiceType565); 
            	        	PushFollow(FOLLOW_type_in_choiceType567);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:27: ( ',' LID type )*
            	        	do 
            	        	{
            	        	    int alt26 = 2;
            	        	    int LA26_0 = input.LA(1);
            	        	    
            	        	    if ( (LA26_0 == 25) )
            	        	    {
            	        	        alt26 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt26) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:28: ',' LID type
            	        			    {
            	        			    	Match(input,25,FOLLOW_25_in_choiceType570); 
            	        			    	Match(input,LID,FOLLOW_LID_in_choiceType572); 
            	        			    	PushFollow(FOLLOW_type_in_choiceType574);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop26;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop26:
            	        		;	// Stops C# compiler whinging that label 'loop26' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,38,FOLLOW_38_in_choiceType581); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:80:1: sequenceType : 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}' ;
    public void sequenceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:4: ( 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:4: 'SEQUENCE' '{' ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )? '}'
            {
            	Match(input,44,FOLLOW_44_in_sequenceType592); 
            	Match(input,35,FOLLOW_35_in_sequenceType594); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:19: ( LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )* )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);
            	
            	if ( (LA31_0 == LID) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:20: LID type ( 'OPTIONAL' )? ( ',' LID type ( 'OPTIONAL' )? )*
            	        {
            	        	Match(input,LID,FOLLOW_LID_in_sequenceType597); 
            	        	PushFollow(FOLLOW_type_in_sequenceType599);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:29: ( 'OPTIONAL' )?
            	        	int alt28 = 2;
            	        	int LA28_0 = input.LA(1);
            	        	
            	        	if ( (LA28_0 == 45) )
            	        	{
            	        	    alt28 = 1;
            	        	}
            	        	switch (alt28) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:30: 'OPTIONAL'
            	        	        {
            	        	        	Match(input,45,FOLLOW_45_in_sequenceType602); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:44: ( ',' LID type ( 'OPTIONAL' )? )*
            	        	do 
            	        	{
            	        	    int alt30 = 2;
            	        	    int LA30_0 = input.LA(1);
            	        	    
            	        	    if ( (LA30_0 == 25) )
            	        	    {
            	        	        alt30 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt30) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:45: ',' LID type ( 'OPTIONAL' )?
            	        			    {
            	        			    	Match(input,25,FOLLOW_25_in_sequenceType608); 
            	        			    	Match(input,LID,FOLLOW_LID_in_sequenceType610); 
            	        			    	PushFollow(FOLLOW_type_in_sequenceType612);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:58: ( 'OPTIONAL' )?
            	        			    	int alt29 = 2;
            	        			    	int LA29_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA29_0 == 45) )
            	        			    	{
            	        			    	    alt29 = 1;
            	        			    	}
            	        			    	switch (alt29) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:59: 'OPTIONAL'
            	        			    	        {
            	        			    	        	Match(input,45,FOLLOW_45_in_sequenceType615); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
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
            	
            	}

            	Match(input,38,FOLLOW_38_in_sequenceType625); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:84:1: sequenceOfType : 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type ;
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:4: ( 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:4: 'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type
            {
            	Match(input,44,FOLLOW_44_in_sequenceOfType638); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:15: ( '(' 'SIZE' constraint ')' )?
            	int alt32 = 2;
            	int LA32_0 = input.LA(1);
            	
            	if ( (LA32_0 == 36) )
            	{
            	    alt32 = 1;
            	}
            	switch (alt32) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:17: '(' 'SIZE' constraint ')'
            	        {
            	        	Match(input,36,FOLLOW_36_in_sequenceOfType642); 
            	        	Match(input,46,FOLLOW_46_in_sequenceOfType644); 
            	        	PushFollow(FOLLOW_constraint_in_sequenceOfType646);
            	        	constraint();
            	        	followingStackPointer_--;

            	        	Match(input,37,FOLLOW_37_in_sequenceOfType648); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,47,FOLLOW_47_in_sequenceOfType653); 
            	PushFollow(FOLLOW_type_in_sequenceOfType655);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:1: octetStringType : 'OCTET' 'STRING' ;
    public void octetStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:4: ( 'OCTET' 'STRING' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:4: 'OCTET' 'STRING'
            {
            	Match(input,48,FOLLOW_48_in_octetStringType669); 
            	Match(input,34,FOLLOW_34_in_octetStringType671); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:93:1: namedNumber : LID '(' signedNumber ')' ;
    public void namedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:4: ( LID '(' signedNumber ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:4: LID '(' signedNumber ')'
            {
            	Match(input,LID,FOLLOW_LID_in_namedNumber683); 
            	Match(input,36,FOLLOW_36_in_namedNumber685); 
            	PushFollow(FOLLOW_signedNumber_in_namedNumber687);
            	signedNumber();
            	followingStackPointer_--;

            	Match(input,37,FOLLOW_37_in_namedNumber689); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:1: signedNumber : ( '+' | '-' )? INT ;
    public void signedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:4: ( ( '+' | '-' )? INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:4: ( '+' | '-' )? INT
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:4: ( '+' | '-' )?
            	int alt33 = 2;
            	int LA33_0 = input.LA(1);
            	
            	if ( ((LA33_0 >= 49 && LA33_0 <= 50)) )
            	{
            	    alt33 = 1;
            	}
            	switch (alt33) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( (input.LA(1) >= 49 && input.LA(1) <= 50) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber700);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber707); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:1: constraint : '(' element ')' ;
    public void constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:122:4: ( '(' element ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:122:4: '(' element ')'
            {
            	Match(input,36,FOLLOW_36_in_constraint720); 
            	PushFollow(FOLLOW_element_in_constraint722);
            	element();
            	followingStackPointer_--;

            	Match(input,37,FOLLOW_37_in_constraint724); 
            
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

    
    // $ANTLR start element
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | 'SIZE' constraint );
    public void element() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:5: ( value ( ( '<' )? '..' ( '<' )? value )? | 'SIZE' constraint )
            int alt37 = 2;
            int LA37_0 = input.LA(1);
            
            if ( ((LA37_0 >= LID && LA37_0 <= Hstring) || (LA37_0 >= 49 && LA37_0 <= 50) || (LA37_0 >= 54 && LA37_0 <= 57)) )
            {
                alt37 = 1;
            }
            else if ( (LA37_0 == 46) )
            {
                alt37 = 2;
            }
            else 
            {
                NoViableAltException nvae_d37s0 =
                    new NoViableAltException("125:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | 'SIZE' constraint );", 37, 0, input);
            
                throw nvae_d37s0;
            }
            switch (alt37) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:5: value ( ( '<' )? '..' ( '<' )? value )?
                    {
                    	PushFollow(FOLLOW_value_in_element736);
                    	value();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:11: ( ( '<' )? '..' ( '<' )? value )?
                    	int alt36 = 2;
                    	int LA36_0 = input.LA(1);
                    	
                    	if ( ((LA36_0 >= 51 && LA36_0 <= 52)) )
                    	{
                    	    alt36 = 1;
                    	}
                    	switch (alt36) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:13: ( '<' )? '..' ( '<' )? value
                    	        {
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:13: ( '<' )?
                    	        	int alt34 = 2;
                    	        	int LA34_0 = input.LA(1);
                    	        	
                    	        	if ( (LA34_0 == 51) )
                    	        	{
                    	        	    alt34 = 1;
                    	        	}
                    	        	switch (alt34) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:14: '<'
                    	        	        {
                    	        	        	Match(input,51,FOLLOW_51_in_element741); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	Match(input,52,FOLLOW_52_in_element745); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:25: ( '<' )?
                    	        	int alt35 = 2;
                    	        	int LA35_0 = input.LA(1);
                    	        	
                    	        	if ( (LA35_0 == 51) )
                    	        	{
                    	        	    alt35 = 1;
                    	        	}
                    	        	switch (alt35) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:26: '<'
                    	        	        {
                    	        	        	Match(input,51,FOLLOW_51_in_element748); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	PushFollow(FOLLOW_value_in_element752);
                    	        	value();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:127:4: 'SIZE' constraint
                    {
                    	Match(input,46,FOLLOW_46_in_element759); 
                    	PushFollow(FOLLOW_constraint_in_element761);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:130:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:3: ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' )
            int alt41 = 6;
            switch ( input.LA(1) ) 
            {
            case Bstring:
            case Hstring:
            	{
                alt41 = 1;
                }
                break;
            case 56:
            case 57:
            	{
                alt41 = 2;
                }
                break;
            case LID:
            	{
                alt41 = 3;
                }
                break;
            case INT:
            case 49:
            case 50:
            	{
                alt41 = 4;
                }
                break;
            case 54:
            	{
                alt41 = 5;
                }
                break;
            case 55:
            	{
                alt41 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d41s0 =
            	        new NoViableAltException("130:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | 'MIN' | 'MAX' );", 41, 0, input);
            
            	    throw nvae_d41s0;
            }
            
            switch (alt41) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:3: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value773);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:4: booleanValue
                    {
                    	PushFollow(FOLLOW_booleanValue_in_value778);
                    	booleanValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:134:4: LID
                    {
                    	Match(input,LID,FOLLOW_LID_in_value784); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:4: ( '+' | '-' )?
                    	int alt38 = 2;
                    	int LA38_0 = input.LA(1);
                    	
                    	if ( ((LA38_0 >= 49 && LA38_0 <= 50)) )
                    	{
                    	    alt38 = 1;
                    	}
                    	switch (alt38) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
                    	        {
                    	        	if ( (input.LA(1) >= 49 && input.LA(1) <= 50) ) 
                    	        	{
                    	        	    input.Consume();
                    	        	    errorRecovery = false;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse =
                    	        	        new MismatchedSetException(null,input);
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value791);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value798); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:19: ( '.' ( INT )? )?
                    	int alt40 = 2;
                    	int LA40_0 = input.LA(1);
                    	
                    	if ( (LA40_0 == 53) )
                    	{
                    	    alt40 = 1;
                    	}
                    	switch (alt40) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:20: '.' ( INT )?
                    	        {
                    	        	Match(input,53,FOLLOW_53_in_value801); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:24: ( INT )?
                    	        	int alt39 = 2;
                    	        	int LA39_0 = input.LA(1);
                    	        	
                    	        	if ( (LA39_0 == INT) )
                    	        	{
                    	        	    alt39 = 1;
                    	        	}
                    	        	switch (alt39) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value803); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:4: 'MIN'
                    {
                    	Match(input,54,FOLLOW_54_in_value813); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:138:4: 'MAX'
                    {
                    	Match(input,55,FOLLOW_55_in_value818); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:141:1: bitStringValue : ( Bstring | Hstring );
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:142:4: ( Bstring | Hstring )
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:146:1: booleanValue : ( 'TRUE' | 'FALSE' );
    public void booleanValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:4: ( 'TRUE' | 'FALSE' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            {
            	if ( (input.LA(1) >= 56 && input.LA(1) <= 57) ) 
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

    
    // $ANTLR start lID
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:152:1: lID : LID ;
    public void lID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:152:7: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:152:7: LID
            {
            	Match(input,LID,FOLLOW_LID_in_lID865); 
            
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
    // $ANTLR end lID


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_UID_in_moduleDefinition28 = new BitSet(new ulong[]{0x0000000000001000UL});
    public static readonly BitSet FOLLOW_12_in_moduleDefinition36 = new BitSet(new ulong[]{0x00000000000BA000UL});
    public static readonly BitSet FOLLOW_13_in_moduleDefinition42 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_14_in_moduleDefinition44 = new BitSet(new ulong[]{0x00000000000A0000UL});
    public static readonly BitSet FOLLOW_15_in_moduleDefinition48 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_14_in_moduleDefinition50 = new BitSet(new ulong[]{0x00000000000A0000UL});
    public static readonly BitSet FOLLOW_16_in_moduleDefinition54 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_14_in_moduleDefinition56 = new BitSet(new ulong[]{0x00000000000A0000UL});
    public static readonly BitSet FOLLOW_17_in_moduleDefinition64 = new BitSet(new ulong[]{0x0000000000040000UL});
    public static readonly BitSet FOLLOW_18_in_moduleDefinition66 = new BitSet(new ulong[]{0x0000000000080000UL});
    public static readonly BitSet FOLLOW_19_in_moduleDefinition73 = new BitSet(new ulong[]{0x0000000000100000UL});
    public static readonly BitSet FOLLOW_20_in_moduleDefinition75 = new BitSet(new ulong[]{0x0000000004600030UL});
    public static readonly BitSet FOLLOW_exports_in_moduleDefinition81 = new BitSet(new ulong[]{0x0000000004200030UL});
    public static readonly BitSet FOLLOW_imports_in_moduleDefinition89 = new BitSet(new ulong[]{0x0000000000200030UL});
    public static readonly BitSet FOLLOW_typeAssigment_in_moduleDefinition102 = new BitSet(new ulong[]{0x0000000000200030UL});
    public static readonly BitSet FOLLOW_valueAssigment_in_moduleDefinition109 = new BitSet(new ulong[]{0x0000000000200030UL});
    public static readonly BitSet FOLLOW_21_in_moduleDefinition120 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_22_in_exports133 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_23_in_exports135 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_24_in_exports137 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_22_in_exports142 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_set_in_exports144 = new BitSet(new ulong[]{0x0000000003000000UL});
    public static readonly BitSet FOLLOW_25_in_exports153 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_set_in_exports155 = new BitSet(new ulong[]{0x0000000003000000UL});
    public static readonly BitSet FOLLOW_24_in_exports166 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_26_in_imports179 = new BitSet(new ulong[]{0x0000000001000030UL});
    public static readonly BitSet FOLLOW_set_in_imports182 = new BitSet(new ulong[]{0x000000000A000000UL});
    public static readonly BitSet FOLLOW_25_in_imports191 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_set_in_imports193 = new BitSet(new ulong[]{0x000000000A000000UL});
    public static readonly BitSet FOLLOW_27_in_imports203 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_UID_in_imports205 = new BitSet(new ulong[]{0x0000000001000030UL});
    public static readonly BitSet FOLLOW_24_in_imports209 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valueAssigment223 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_valueAssigment225 = new BitSet(new ulong[]{0x0000000000080000UL});
    public static readonly BitSet FOLLOW_19_in_valueAssigment227 = new BitSet(new ulong[]{0x03C60000000001E0UL});
    public static readonly BitSet FOLLOW_value_in_valueAssigment229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typeAssigment246 = new BitSet(new ulong[]{0x0000000000080000UL});
    public static readonly BitSet FOLLOW_19_in_typeAssigment248 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_typeAssigment250 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_28_in_type262 = new BitSet(new ulong[]{0x00000000E0000040UL});
    public static readonly BitSet FOLLOW_set_in_type264 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_type277 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_32_in_type280 = new BitSet(new ulong[]{0x00011F820000A010UL});
    public static readonly BitSet FOLLOW_set_in_type282 = new BitSet(new ulong[]{0x00011F8200000010UL});
    public static readonly BitSet FOLLOW_bitStringType_in_type304 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_booleanType_in_type312 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type320 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_integerType_in_type328 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_octetStringType_in_type336 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_realType_in_type344 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_UID_in_type352 = new BitSet(new ulong[]{0x0000001000000002UL});
    public static readonly BitSet FOLLOW_constraint_in_type360 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type365 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type380 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_33_in_bitStringType394 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_bitStringType396 = new BitSet(new ulong[]{0x0000000800000002UL});
    public static readonly BitSet FOLLOW_35_in_bitStringType399 = new BitSet(new ulong[]{0x0000004000000020UL});
    public static readonly BitSet FOLLOW_LID_in_bitStringType402 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_36_in_bitStringType404 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType406 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_bitStringType408 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_25_in_bitStringType411 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_bitStringType413 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_36_in_bitStringType415 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType417 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_bitStringType419 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_38_in_bitStringType427 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_39_in_booleanType442 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_40_in_enumeratedType455 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_35_in_enumeratedType457 = new BitSet(new ulong[]{0x0000004000000020UL});
    public static readonly BitSet FOLLOW_LID_in_enumeratedType460 = new BitSet(new ulong[]{0x0000005002000000UL});
    public static readonly BitSet FOLLOW_36_in_enumeratedType464 = new BitSet(new ulong[]{0x0006000000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType466 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_enumeratedType468 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_25_in_enumeratedType473 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_enumeratedType475 = new BitSet(new ulong[]{0x0000005002000000UL});
    public static readonly BitSet FOLLOW_36_in_enumeratedType479 = new BitSet(new ulong[]{0x0006000000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType481 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_enumeratedType483 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_38_in_enumeratedType491 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_41_in_integerType503 = new BitSet(new ulong[]{0x0000000800000002UL});
    public static readonly BitSet FOLLOW_35_in_integerType507 = new BitSet(new ulong[]{0x0000004000000020UL});
    public static readonly BitSet FOLLOW_LID_in_integerType510 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_36_in_integerType512 = new BitSet(new ulong[]{0x0006000000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType514 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_integerType516 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_25_in_integerType519 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_integerType521 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_36_in_integerType523 = new BitSet(new ulong[]{0x0006000000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType525 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_integerType527 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_38_in_integerType533 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_42_in_realType548 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_43_in_choiceType560 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_35_in_choiceType562 = new BitSet(new ulong[]{0x0000004000000020UL});
    public static readonly BitSet FOLLOW_LID_in_choiceType565 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_choiceType567 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_25_in_choiceType570 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_choiceType572 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_choiceType574 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_38_in_choiceType581 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_sequenceType592 = new BitSet(new ulong[]{0x0000000800000000UL});
    public static readonly BitSet FOLLOW_35_in_sequenceType594 = new BitSet(new ulong[]{0x0000004000000020UL});
    public static readonly BitSet FOLLOW_LID_in_sequenceType597 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType599 = new BitSet(new ulong[]{0x0000204002000000UL});
    public static readonly BitSet FOLLOW_45_in_sequenceType602 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_25_in_sequenceType608 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_LID_in_sequenceType610 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType612 = new BitSet(new ulong[]{0x0000204002000000UL});
    public static readonly BitSet FOLLOW_45_in_sequenceType615 = new BitSet(new ulong[]{0x0000004002000000UL});
    public static readonly BitSet FOLLOW_38_in_sequenceType625 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_44_in_sequenceOfType638 = new BitSet(new ulong[]{0x0000801000000000UL});
    public static readonly BitSet FOLLOW_36_in_sequenceOfType642 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_46_in_sequenceOfType644 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_constraint_in_sequenceOfType646 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_sequenceOfType648 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_sequenceOfType653 = new BitSet(new ulong[]{0x00011F8210000010UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType655 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_48_in_octetStringType669 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_34_in_octetStringType671 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_namedNumber683 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_36_in_namedNumber685 = new BitSet(new ulong[]{0x0006000000000040UL});
    public static readonly BitSet FOLLOW_signedNumber_in_namedNumber687 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_namedNumber689 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber700 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber707 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_36_in_constraint720 = new BitSet(new ulong[]{0x03C64000000001E0UL});
    public static readonly BitSet FOLLOW_element_in_constraint722 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_37_in_constraint724 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_value_in_element736 = new BitSet(new ulong[]{0x0018000000000002UL});
    public static readonly BitSet FOLLOW_51_in_element741 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_52_in_element745 = new BitSet(new ulong[]{0x03CE0000000001E0UL});
    public static readonly BitSet FOLLOW_51_in_element748 = new BitSet(new ulong[]{0x03C60000000001E0UL});
    public static readonly BitSet FOLLOW_value_in_element752 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_46_in_element759 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_constraint_in_element761 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value773 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanValue_in_value778 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_value784 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value791 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_INT_in_value798 = new BitSet(new ulong[]{0x0020000000000002UL});
    public static readonly BitSet FOLLOW_53_in_value801 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_INT_in_value803 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_54_in_value813 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_55_in_value818 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_bitStringValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_booleanValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_lID865 = new BitSet(new ulong[]{0x0000000000000002UL});

}
