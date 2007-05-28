// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-28 14:34:30



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
		"DEFINITIONS", 
		"EXPLICIT", 
		"TAGS", 
		"IMPLICIT", 
		"AUTOMATIC", 
		"EXTENSIBILITY", 
		"IMPLIED", 
		"BEGIN", 
		"END", 
		"INT", 
		"EXPORTS", 
		"ALL", 
		"IMPORTS", 
		"FROM", 
		"UNIVERSAL", 
		"APPLICATION", 
		"PRIVATE", 
		"BIT", 
		"STRING", 
		"BOOLEAN", 
		"ENUMERATED", 
		"INTEGER", 
		"REAL", 
		"CHOICE", 
		"SEQUENCE", 
		"OPTIONAL", 
		"SIZE", 
		"OF", 
		"OCTET", 
		"LID", 
		"MIN", 
		"MAX", 
		"Bstring", 
		"Hstring", 
		"TRUE", 
		"FALSE", 
		"UID", 
		"WS", 
		"COMMENT", 
		"LINE_COMMENT", 
		"'::='", 
		"'{'", 
		"'}'", 
		"'('", 
		"')'", 
		"';'", 
		"','", 
		"'['", 
		"']'", 
		"'+'", 
		"'-'", 
		"'<'", 
		"'..'", 
		"'.'"
    };

    public const int APPLICATION = 19;
    public const int Bstring = 36;
    public const int MAX = 35;
    public const int EXPLICIT = 5;
    public const int EOF = -1;
    public const int BOOLEAN = 23;
    public const int EXPORTS = 14;
    public const int ALL = 15;
    public const int BEGIN = 11;
    public const int UID = 40;
    public const int COMMENT = 42;
    public const int CHOICE = 27;
    public const int INTEGER = 25;
    public const int EXTENSIBILITY = 9;
    public const int IMPLICIT = 7;
    public const int LINE_COMMENT = 43;
    public const int PRIVATE = 20;
    public const int DEFINITIONS = 4;
    public const int TAGS = 6;
    public const int INT = 13;
    public const int MIN = 34;
    public const int OF = 31;
    public const int TRUE = 38;
    public const int IMPLIED = 10;
    public const int OPTIONAL = 29;
    public const int LID = 33;
    public const int REAL = 26;
    public const int SEQUENCE = 28;
    public const int ENUMERATED = 24;
    public const int WS = 41;
    public const int Hstring = 37;
    public const int BIT = 21;
    public const int IMPORTS = 16;
    public const int FROM = 17;
    public const int END = 12;
    public const int UNIVERSAL = 18;
    public const int FALSE = 39;
    public const int SIZE = 30;
    public const int OCTET = 32;
    public const int STRING = 22;
    public const int AUTOMATIC = 8;
    
    
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


    
    // $ANTLR start moduleDefinitions
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:11:1: moduleDefinitions : ( moduleDefinition )* ;
    public void moduleDefinitions() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: ( ( moduleDefinition )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: ( moduleDefinition )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: ( moduleDefinition )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);
            	    
            	    if ( (LA1_0 == UID) )
            	    {
            	        alt1 = 1;
            	    }
            	    
            	
            	    switch (alt1) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:12:4: moduleDefinition
            			    {
            			    	PushFollow(FOLLOW_moduleDefinition_in_moduleDefinitions30);
            			    	moduleDefinition();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop1;
            	    }
            	} while (true);
            	
            	loop1:
            		;	// Stops C# compiler whinging that label 'loop1' has no statements

            
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
    // $ANTLR end moduleDefinitions

    
    // $ANTLR start moduleDefinition
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:1: moduleDefinition : modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment )* END ;
    public void moduleDefinition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:22: ( modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment )* END )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:22: modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment )* END
            {
            	PushFollow(FOLLOW_modulereference_in_moduleDefinition41);
            	modulereference();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:38: ( definitiveIdentifier )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);
            	
            	if ( (LA2_0 == 45) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:14:38: definitiveIdentifier
            	        {
            	        	PushFollow(FOLLOW_definitiveIdentifier_in_moduleDefinition43);
            	        	definitiveIdentifier();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,DEFINITIONS,FOLLOW_DEFINITIONS_in_moduleDefinition49); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:4: ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )?
            	int alt3 = 4;
            	switch ( input.LA(1) ) 
            	{
            	    case EXPLICIT:
            	    	{
            	        alt3 = 1;
            	        }
            	        break;
            	    case IMPLICIT:
            	    	{
            	        alt3 = 2;
            	        }
            	        break;
            	    case AUTOMATIC:
            	    	{
            	        alt3 = 3;
            	        }
            	        break;
            	}
            	
            	switch (alt3) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:5: EXPLICIT TAGS
            	        {
            	        	Match(input,EXPLICIT,FOLLOW_EXPLICIT_in_moduleDefinition55); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition57); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:21: IMPLICIT TAGS
            	        {
            	        	Match(input,IMPLICIT,FOLLOW_IMPLICIT_in_moduleDefinition61); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition63); 
            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:16:37: AUTOMATIC TAGS
            	        {
            	        	Match(input,AUTOMATIC,FOLLOW_AUTOMATIC_in_moduleDefinition67); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition69); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:4: ( EXTENSIBILITY IMPLIED )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);
            	
            	if ( (LA4_0 == EXTENSIBILITY) )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:17:5: EXTENSIBILITY IMPLIED
            	        {
            	        	Match(input,EXTENSIBILITY,FOLLOW_EXTENSIBILITY_in_moduleDefinition77); 
            	        	Match(input,IMPLIED,FOLLOW_IMPLIED_in_moduleDefinition79); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,44,FOLLOW_44_in_moduleDefinition86); 
            	Match(input,BEGIN,FOLLOW_BEGIN_in_moduleDefinition88); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:4: ( exports )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);
            	
            	if ( (LA5_0 == EXPORTS) )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:5: exports
            	        {
            	        	PushFollow(FOLLOW_exports_in_moduleDefinition94);
            	        	exports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:4: ( imports )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);
            	
            	if ( (LA6_0 == IMPORTS) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:20:5: imports
            	        {
            	        	PushFollow(FOLLOW_imports_in_moduleDefinition102);
            	        	imports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:4: ( typeAssigment | valueAssigment )*
            	do 
            	{
            	    int alt7 = 3;
            	    int LA7_0 = input.LA(1);
            	    
            	    if ( (LA7_0 == UID) )
            	    {
            	        alt7 = 1;
            	    }
            	    else if ( (LA7_0 == LID) )
            	    {
            	        alt7 = 2;
            	    }
            	    
            	
            	    switch (alt7) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:22:5: typeAssigment
            			    {
            			    	PushFollow(FOLLOW_typeAssigment_in_moduleDefinition115);
            			    	typeAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            			case 2 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:6: valueAssigment
            			    {
            			    	PushFollow(FOLLOW_valueAssigment_in_moduleDefinition122);
            			    	valueAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop7;
            	    }
            	} while (true);
            	
            	loop7:
            		;	// Stops C# compiler whinging that label 'loop7' has no statements

            	Match(input,END,FOLLOW_END_in_moduleDefinition133); 
            
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

    
    // $ANTLR start definitiveIdentifier
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:1: definitiveIdentifier : '{' ( definitiveObjIdComponent )* '}' ;
    public void definitiveIdentifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:4: ( '{' ( definitiveObjIdComponent )* '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:4: '{' ( definitiveObjIdComponent )* '}'
            {
            	Match(input,45,FOLLOW_45_in_definitiveIdentifier141); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:8: ( definitiveObjIdComponent )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);
            	    
            	    if ( (LA8_0 == INT || LA8_0 == LID) )
            	    {
            	        alt8 = 1;
            	    }
            	    
            	
            	    switch (alt8) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:8: definitiveObjIdComponent
            			    {
            			    	PushFollow(FOLLOW_definitiveObjIdComponent_in_definitiveIdentifier143);
            			    	definitiveObjIdComponent();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop8;
            	    }
            	} while (true);
            	
            	loop8:
            		;	// Stops C# compiler whinging that label 'loop8' has no statements

            	Match(input,46,FOLLOW_46_in_definitiveIdentifier146); 
            
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
    // $ANTLR end definitiveIdentifier

    
    // $ANTLR start definitiveObjIdComponent
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:1: definitiveObjIdComponent : ( identifier ( '(' INT ')' )? | INT );
    public void definitiveObjIdComponent() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:4: ( identifier ( '(' INT ')' )? | INT )
            int alt10 = 2;
            int LA10_0 = input.LA(1);
            
            if ( (LA10_0 == LID) )
            {
                alt10 = 1;
            }
            else if ( (LA10_0 == INT) )
            {
                alt10 = 2;
            }
            else 
            {
                NoViableAltException nvae_d10s0 =
                    new NoViableAltException("30:1: definitiveObjIdComponent : ( identifier ( '(' INT ')' )? | INT );", 10, 0, input);
            
                throw nvae_d10s0;
            }
            switch (alt10) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:4: identifier ( '(' INT ')' )?
                    {
                    	PushFollow(FOLLOW_identifier_in_definitiveObjIdComponent159);
                    	identifier();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:15: ( '(' INT ')' )?
                    	int alt9 = 2;
                    	int LA9_0 = input.LA(1);
                    	
                    	if ( (LA9_0 == 47) )
                    	{
                    	    alt9 = 1;
                    	}
                    	switch (alt9) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:17: '(' INT ')'
                    	        {
                    	        	Match(input,47,FOLLOW_47_in_definitiveObjIdComponent163); 
                    	        	Match(input,INT,FOLLOW_INT_in_definitiveObjIdComponent165); 
                    	        	Match(input,48,FOLLOW_48_in_definitiveObjIdComponent167); 
                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:32:4: INT
                    {
                    	Match(input,INT,FOLLOW_INT_in_definitiveObjIdComponent175); 
                    
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
    // $ANTLR end definitiveObjIdComponent

    
    // $ANTLR start exports
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:1: exports : ( EXPORTS ALL ';' | EXPORTS ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* ';' );
    public void exports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:3: ( EXPORTS ALL ';' | EXPORTS ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* ';' )
            int alt14 = 2;
            int LA14_0 = input.LA(1);
            
            if ( (LA14_0 == EXPORTS) )
            {
                int LA14_1 = input.LA(2);
                
                if ( (LA14_1 == ALL) )
                {
                    alt14 = 1;
                }
                else if ( (LA14_1 == LID || LA14_1 == UID) )
                {
                    alt14 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d14s1 =
                        new NoViableAltException("34:1: exports : ( EXPORTS ALL ';' | EXPORTS ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* ';' );", 14, 1, input);
                
                    throw nvae_d14s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d14s0 =
                    new NoViableAltException("34:1: exports : ( EXPORTS ALL ';' | EXPORTS ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* ';' );", 14, 0, input);
            
                throw nvae_d14s0;
            }
            switch (alt14) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:3: EXPORTS ALL ';'
                    {
                    	Match(input,EXPORTS,FOLLOW_EXPORTS_in_exports190); 
                    	Match(input,ALL,FOLLOW_ALL_in_exports192); 
                    	Match(input,49,FOLLOW_49_in_exports194); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:4: EXPORTS ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* ';'
                    {
                    	Match(input,EXPORTS,FOLLOW_EXPORTS_in_exports199); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:12: ( typereference | valuereference )
                    	int alt11 = 2;
                    	int LA11_0 = input.LA(1);
                    	
                    	if ( (LA11_0 == UID) )
                    	{
                    	    alt11 = 1;
                    	}
                    	else if ( (LA11_0 == LID) )
                    	{
                    	    alt11 = 2;
                    	}
                    	else 
                    	{
                    	    NoViableAltException nvae_d11s0 =
                    	        new NoViableAltException("36:12: ( typereference | valuereference )", 11, 0, input);
                    	
                    	    throw nvae_d11s0;
                    	}
                    	switch (alt11) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:13: typereference
                    	        {
                    	        	PushFollow(FOLLOW_typereference_in_exports202);
                    	        	typereference();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	    case 2 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:29: valuereference
                    	        {
                    	        	PushFollow(FOLLOW_valuereference_in_exports206);
                    	        	valuereference();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:45: ( ',' ( typereference | valuereference ) )*
                    	do 
                    	{
                    	    int alt13 = 2;
                    	    int LA13_0 = input.LA(1);
                    	    
                    	    if ( (LA13_0 == 50) )
                    	    {
                    	        alt13 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:46: ',' ( typereference | valuereference )
                    			    {
                    			    	Match(input,50,FOLLOW_50_in_exports210); 
                    			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:50: ( typereference | valuereference )
                    			    	int alt12 = 2;
                    			    	int LA12_0 = input.LA(1);
                    			    	
                    			    	if ( (LA12_0 == UID) )
                    			    	{
                    			    	    alt12 = 1;
                    			    	}
                    			    	else if ( (LA12_0 == LID) )
                    			    	{
                    			    	    alt12 = 2;
                    			    	}
                    			    	else 
                    			    	{
                    			    	    NoViableAltException nvae_d12s0 =
                    			    	        new NoViableAltException("36:50: ( typereference | valuereference )", 12, 0, input);
                    			    	
                    			    	    throw nvae_d12s0;
                    			    	}
                    			    	switch (alt12) 
                    			    	{
                    			    	    case 1 :
                    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:51: typereference
                    			    	        {
                    			    	        	PushFollow(FOLLOW_typereference_in_exports213);
                    			    	        	typereference();
                    			    	        	followingStackPointer_--;

                    			    	        
                    			    	        }
                    			    	        break;
                    			    	    case 2 :
                    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:67: valuereference
                    			    	        {
                    			    	        	PushFollow(FOLLOW_valuereference_in_exports217);
                    			    	        	valuereference();
                    			    	        	followingStackPointer_--;

                    			    	        
                    			    	        }
                    			    	        break;
                    			    	
                    			    	}

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop13;
                    	    }
                    	} while (true);
                    	
                    	loop13:
                    		;	// Stops C# compiler whinging that label 'loop13' has no statements

                    	Match(input,49,FOLLOW_49_in_exports223); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:1: imports : IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference )* ';' ;
    public void imports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:2: ( IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference )* ';' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:2: IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference )* ';'
            {
            	Match(input,IMPORTS,FOLLOW_IMPORTS_in_imports236); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:10: ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference )*
            	do 
            	{
            	    int alt18 = 2;
            	    int LA18_0 = input.LA(1);
            	    
            	    if ( (LA18_0 == LID || LA18_0 == UID) )
            	    {
            	        alt18 = 1;
            	    }
            	    
            	
            	    switch (alt18) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:11: ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference
            			    {
            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:11: ( typereference | valuereference )
            			    	int alt15 = 2;
            			    	int LA15_0 = input.LA(1);
            			    	
            			    	if ( (LA15_0 == UID) )
            			    	{
            			    	    alt15 = 1;
            			    	}
            			    	else if ( (LA15_0 == LID) )
            			    	{
            			    	    alt15 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d15s0 =
            			    	        new NoViableAltException("40:11: ( typereference | valuereference )", 15, 0, input);
            			    	
            			    	    throw nvae_d15s0;
            			    	}
            			    	switch (alt15) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:12: typereference
            			    	        {
            			    	        	PushFollow(FOLLOW_typereference_in_imports240);
            			    	        	typereference();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:28: valuereference
            			    	        {
            			    	        	PushFollow(FOLLOW_valuereference_in_imports244);
            			    	        	valuereference();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:44: ( ',' ( typereference | valuereference ) )*
            			    	do 
            			    	{
            			    	    int alt17 = 2;
            			    	    int LA17_0 = input.LA(1);
            			    	    
            			    	    if ( (LA17_0 == 50) )
            			    	    {
            			    	        alt17 = 1;
            			    	    }
            			    	    
            			    	
            			    	    switch (alt17) 
            			    		{
            			    			case 1 :
            			    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:45: ',' ( typereference | valuereference )
            			    			    {
            			    			    	Match(input,50,FOLLOW_50_in_imports248); 
            			    			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:49: ( typereference | valuereference )
            			    			    	int alt16 = 2;
            			    			    	int LA16_0 = input.LA(1);
            			    			    	
            			    			    	if ( (LA16_0 == UID) )
            			    			    	{
            			    			    	    alt16 = 1;
            			    			    	}
            			    			    	else if ( (LA16_0 == LID) )
            			    			    	{
            			    			    	    alt16 = 2;
            			    			    	}
            			    			    	else 
            			    			    	{
            			    			    	    NoViableAltException nvae_d16s0 =
            			    			    	        new NoViableAltException("40:49: ( typereference | valuereference )", 16, 0, input);
            			    			    	
            			    			    	    throw nvae_d16s0;
            			    			    	}
            			    			    	switch (alt16) 
            			    			    	{
            			    			    	    case 1 :
            			    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:50: typereference
            			    			    	        {
            			    			    	        	PushFollow(FOLLOW_typereference_in_imports251);
            			    			    	        	typereference();
            			    			    	        	followingStackPointer_--;

            			    			    	        
            			    			    	        }
            			    			    	        break;
            			    			    	    case 2 :
            			    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:66: valuereference
            			    			    	        {
            			    			    	        	PushFollow(FOLLOW_valuereference_in_imports255);
            			    			    	        	valuereference();
            			    			    	        	followingStackPointer_--;

            			    			    	        
            			    			    	        }
            			    			    	        break;
            			    			    	
            			    			    	}

            			    			    
            			    			    }
            			    			    break;
            			    	
            			    			default:
            			    			    goto loop17;
            			    	    }
            			    	} while (true);
            			    	
            			    	loop17:
            			    		;	// Stops C# compiler whinging that label 'loop17' has no statements

            			    	Match(input,FROM,FOLLOW_FROM_in_imports260); 
            			    	PushFollow(FOLLOW_modulereference_in_imports262);
            			    	modulereference();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop18;
            	    }
            	} while (true);
            	
            	loop18:
            		;	// Stops C# compiler whinging that label 'loop18' has no statements

            	Match(input,49,FOLLOW_49_in_imports266); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:1: valueAssigment : valuereference type '::=' value ;
    public void valueAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:4: ( valuereference type '::=' value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:45:4: valuereference type '::=' value
            {
            	PushFollow(FOLLOW_valuereference_in_valueAssigment282);
            	valuereference();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_valueAssigment284);
            	type();
            	followingStackPointer_--;

            	Match(input,44,FOLLOW_44_in_valueAssigment286); 
            	PushFollow(FOLLOW_value_in_valueAssigment288);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:1: typeAssigment : typereference '::=' type ;
    public void typeAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:4: ( typereference '::=' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:49:4: typereference '::=' type
            {
            	PushFollow(FOLLOW_typereference_in_typeAssigment305);
            	typereference();
            	followingStackPointer_--;

            	Match(input,44,FOLLOW_44_in_typeAssigment307); 
            	PushFollow(FOLLOW_type_in_typeAssigment309);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:1: type : ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);
            	
            	if ( (LA21_0 == 51) )
            	{
            	    alt21 = 1;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:9: '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )?
            	        {
            	        	Match(input,51,FOLLOW_51_in_type321); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:13: ( UNIVERSAL | APPLICATION | PRIVATE )?
            	        	int alt19 = 2;
            	        	int LA19_0 = input.LA(1);
            	        	
            	        	if ( ((LA19_0 >= UNIVERSAL && LA19_0 <= PRIVATE)) )
            	        	{
            	        	    alt19 = 1;
            	        	}
            	        	switch (alt19) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( (input.LA(1) >= UNIVERSAL && input.LA(1) <= PRIVATE) ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type323);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,INT,FOLLOW_INT_in_type336); 
            	        	Match(input,52,FOLLOW_52_in_type339); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:59: ( IMPLICIT | EXPLICIT )?
            	        	int alt20 = 2;
            	        	int LA20_0 = input.LA(1);
            	        	
            	        	if ( (LA20_0 == EXPLICIT || LA20_0 == IMPLICIT) )
            	        	{
            	        	    alt20 = 1;
            	        	}
            	        	switch (alt20) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        	        {
            	        	        	if ( input.LA(1) == EXPLICIT || input.LA(1) == IMPLICIT ) 
            	        	        	{
            	        	        	    input.Consume();
            	        	        	    errorRecovery = false;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    MismatchedSetException mse =
            	        	        	        new MismatchedSetException(null,input);
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type341);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType )
            	int alt24 = 4;
            	switch ( input.LA(1) ) 
            	{
            	case BIT:
            	case BOOLEAN:
            	case ENUMERATED:
            	case INTEGER:
            	case REAL:
            	case OCTET:
            	case UID:
            		{
            	    alt24 = 1;
            	    }
            	    break;
            	case SEQUENCE:
            		{
            	    int LA24_2 = input.LA(2);
            	    
            	    if ( (LA24_2 == 45) )
            	    {
            	        alt24 = 4;
            	    }
            	    else if ( (LA24_2 == OF || LA24_2 == 47) )
            	    {
            	        alt24 = 2;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d24s2 =
            	            new NoViableAltException("53:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType )", 24, 2, input);
            	    
            	        throw nvae_d24s2;
            	    }
            	    }
            	    break;
            	case CHOICE:
            		{
            	    alt24 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d24s0 =
            		        new NoViableAltException("53:1: ( ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )? | sequenceOfType | choiceType | sequenceType )", 24, 0, input);
            	
            		    throw nvae_d24s0;
            	}
            	
            	switch (alt24) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference ) ( constraint )?
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference )
            	        	int alt22 = 7;
            	        	switch ( input.LA(1) ) 
            	        	{
            	        	case BIT:
            	        		{
            	        	    alt22 = 1;
            	        	    }
            	        	    break;
            	        	case BOOLEAN:
            	        		{
            	        	    alt22 = 2;
            	        	    }
            	        	    break;
            	        	case ENUMERATED:
            	        		{
            	        	    alt22 = 3;
            	        	    }
            	        	    break;
            	        	case INTEGER:
            	        		{
            	        	    alt22 = 4;
            	        	    }
            	        	    break;
            	        	case OCTET:
            	        		{
            	        	    alt22 = 5;
            	        	    }
            	        	    break;
            	        	case REAL:
            	        		{
            	        	    alt22 = 6;
            	        	    }
            	        	    break;
            	        	case UID:
            	        		{
            	        	    alt22 = 7;
            	        	    }
            	        	    break;
            	        		default:
            	        		    NoViableAltException nvae_d22s0 =
            	        		        new NoViableAltException("53:3: ( bitStringType | booleanType | enumeratedType | integerType | octetStringType | realType | typereference )", 22, 0, input);
            	        	
            	        		    throw nvae_d22s0;
            	        	}
            	        	
            	        	switch (alt22) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:6: bitStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_bitStringType_in_type363);
            	        	        	bitStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:55:7: booleanType
            	        	        {
            	        	        	PushFollow(FOLLOW_booleanType_in_type371);
            	        	        	booleanType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 3 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:56:7: enumeratedType
            	        	        {
            	        	        	PushFollow(FOLLOW_enumeratedType_in_type379);
            	        	        	enumeratedType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 4 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:7: integerType
            	        	        {
            	        	        	PushFollow(FOLLOW_integerType_in_type387);
            	        	        	integerType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 5 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:7: octetStringType
            	        	        {
            	        	        	PushFollow(FOLLOW_octetStringType_in_type395);
            	        	        	octetStringType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 6 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:7: realType
            	        	        {
            	        	        	PushFollow(FOLLOW_realType_in_type403);
            	        	        	realType();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 7 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:7: typereference
            	        	        {
            	        	        	PushFollow(FOLLOW_typereference_in_type411);
            	        	        	typereference();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:4: ( constraint )?
            	        	int alt23 = 2;
            	        	int LA23_0 = input.LA(1);
            	        	
            	        	if ( (LA23_0 == 47) )
            	        	{
            	        	    alt23 = 1;
            	        	}
            	        	switch (alt23) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:4: constraint
            	        	        {
            	        	        	PushFollow(FOLLOW_constraint_in_type419);
            	        	        	constraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:62:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type424);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:3: choiceType
            	        {
            	        	PushFollow(FOLLOW_choiceType_in_type428);
            	        	choiceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 4 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:64:10: sequenceType
            	        {
            	        	PushFollow(FOLLOW_sequenceType_in_type439);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:1: bitStringType : BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )? ;
    public void bitStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:4: ( BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:4: BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )?
            {
            	Match(input,BIT,FOLLOW_BIT_in_bitStringType453); 
            	Match(input,STRING,FOLLOW_STRING_in_bitStringType455); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:15: ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )?
            	int alt27 = 2;
            	int LA27_0 = input.LA(1);
            	
            	if ( (LA27_0 == 45) )
            	{
            	    alt27 = 1;
            	}
            	switch (alt27) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:16: '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}'
            	        {
            	        	Match(input,45,FOLLOW_45_in_bitStringType458); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:20: ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )?
            	        	int alt26 = 2;
            	        	int LA26_0 = input.LA(1);
            	        	
            	        	if ( (LA26_0 == LID) )
            	        	{
            	        	    alt26 = 1;
            	        	}
            	        	switch (alt26) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:21: identifier '(' INT ')' ( ',' identifier '(' INT ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_bitStringType461);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,47,FOLLOW_47_in_bitStringType463); 
            	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType465); 
            	        	        	Match(input,48,FOLLOW_48_in_bitStringType467); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:44: ( ',' identifier '(' INT ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt25 = 2;
            	        	        	    int LA25_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA25_0 == 50) )
            	        	        	    {
            	        	        	        alt25 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt25) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:70:45: ',' identifier '(' INT ')'
            	        	        			    {
            	        	        			    	Match(input,50,FOLLOW_50_in_bitStringType470); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_bitStringType472);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,47,FOLLOW_47_in_bitStringType474); 
            	        	        			    	Match(input,INT,FOLLOW_INT_in_bitStringType476); 
            	        	        			    	Match(input,48,FOLLOW_48_in_bitStringType478); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop25;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop25:
            	        	        		;	// Stops C# compiler whinging that label 'loop25' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,46,FOLLOW_46_in_bitStringType486); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:1: booleanType : BOOLEAN ;
    public void booleanType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:4: ( BOOLEAN )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:4: BOOLEAN
            {
            	Match(input,BOOLEAN,FOLLOW_BOOLEAN_in_booleanType501); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:1: enumeratedType : ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}' ;
    public void enumeratedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:4: ( ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:4: ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}'
            {
            	Match(input,ENUMERATED,FOLLOW_ENUMERATED_in_enumeratedType514); 
            	Match(input,45,FOLLOW_45_in_enumeratedType516); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:19: ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )?
            	int alt31 = 2;
            	int LA31_0 = input.LA(1);
            	
            	if ( (LA31_0 == LID) )
            	{
            	    alt31 = 1;
            	}
            	switch (alt31) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:20: identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_enumeratedType519);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:31: ( '(' signedNumber ')' )?
            	        	int alt28 = 2;
            	        	int LA28_0 = input.LA(1);
            	        	
            	        	if ( (LA28_0 == 47) )
            	        	{
            	        	    alt28 = 1;
            	        	}
            	        	switch (alt28) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:33: '(' signedNumber ')'
            	        	        {
            	        	        	Match(input,47,FOLLOW_47_in_enumeratedType523); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType525);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,48,FOLLOW_48_in_enumeratedType527); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:56: ( ',' identifier ( '(' signedNumber ')' )? )*
            	        	do 
            	        	{
            	        	    int alt30 = 2;
            	        	    int LA30_0 = input.LA(1);
            	        	    
            	        	    if ( (LA30_0 == 50) )
            	        	    {
            	        	        alt30 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt30) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:57: ',' identifier ( '(' signedNumber ')' )?
            	        			    {
            	        			    	Match(input,50,FOLLOW_50_in_enumeratedType532); 
            	        			    	PushFollow(FOLLOW_identifier_in_enumeratedType534);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:72: ( '(' signedNumber ')' )?
            	        			    	int alt29 = 2;
            	        			    	int LA29_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA29_0 == 47) )
            	        			    	{
            	        			    	    alt29 = 1;
            	        			    	}
            	        			    	switch (alt29) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:74: '(' signedNumber ')'
            	        			    	        {
            	        			    	        	Match(input,47,FOLLOW_47_in_enumeratedType538); 
            	        			    	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType540);
            	        			    	        	signedNumber();
            	        			    	        	followingStackPointer_--;

            	        			    	        	Match(input,48,FOLLOW_48_in_enumeratedType542); 
            	        			    	        
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

            	Match(input,46,FOLLOW_46_in_enumeratedType550); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:1: integerType : INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )? ;
    public void integerType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:4: ( INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:4: INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )?
            {
            	Match(input,INTEGER,FOLLOW_INTEGER_in_integerType562); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:12: ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )?
            	int alt34 = 2;
            	int LA34_0 = input.LA(1);
            	
            	if ( (LA34_0 == 45) )
            	{
            	    alt34 = 1;
            	}
            	switch (alt34) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:14: '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}'
            	        {
            	        	Match(input,45,FOLLOW_45_in_integerType566); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:18: ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )?
            	        	int alt33 = 2;
            	        	int LA33_0 = input.LA(1);
            	        	
            	        	if ( (LA33_0 == LID) )
            	        	{
            	        	    alt33 = 1;
            	        	}
            	        	switch (alt33) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:19: identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_integerType569);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,47,FOLLOW_47_in_integerType571); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_integerType573);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,48,FOLLOW_48_in_integerType575); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:51: ( ',' identifier '(' signedNumber ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt32 = 2;
            	        	        	    int LA32_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA32_0 == 50) )
            	        	        	    {
            	        	        	        alt32 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt32) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:52: ',' identifier '(' signedNumber ')'
            	        	        			    {
            	        	        			    	Match(input,50,FOLLOW_50_in_integerType578); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_integerType580);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,47,FOLLOW_47_in_integerType582); 
            	        	        			    	PushFollow(FOLLOW_signedNumber_in_integerType584);
            	        	        			    	signedNumber();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,48,FOLLOW_48_in_integerType586); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop32;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop32:
            	        	        		;	// Stops C# compiler whinging that label 'loop32' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,46,FOLLOW_46_in_integerType592); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:1: realType : REAL ;
    public void realType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:86:4: ( REAL )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:86:4: REAL
            {
            	Match(input,REAL,FOLLOW_REAL_in_realType607); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:1: choiceType : CHOICE '{' ( identifier type ( ',' identifier type )* )? '}' ;
    public void choiceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:4: ( CHOICE '{' ( identifier type ( ',' identifier type )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:4: CHOICE '{' ( identifier type ( ',' identifier type )* )? '}'
            {
            	Match(input,CHOICE,FOLLOW_CHOICE_in_choiceType619); 
            	Match(input,45,FOLLOW_45_in_choiceType621); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:15: ( identifier type ( ',' identifier type )* )?
            	int alt36 = 2;
            	int LA36_0 = input.LA(1);
            	
            	if ( (LA36_0 == LID) )
            	{
            	    alt36 = 1;
            	}
            	switch (alt36) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:16: identifier type ( ',' identifier type )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_choiceType624);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	PushFollow(FOLLOW_type_in_choiceType626);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:32: ( ',' identifier type )*
            	        	do 
            	        	{
            	        	    int alt35 = 2;
            	        	    int LA35_0 = input.LA(1);
            	        	    
            	        	    if ( (LA35_0 == 50) )
            	        	    {
            	        	        alt35 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt35) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:90:33: ',' identifier type
            	        			    {
            	        			    	Match(input,50,FOLLOW_50_in_choiceType629); 
            	        			    	PushFollow(FOLLOW_identifier_in_choiceType631);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	PushFollow(FOLLOW_type_in_choiceType633);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop35;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop35:
            	        		;	// Stops C# compiler whinging that label 'loop35' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,46,FOLLOW_46_in_choiceType640); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:93:1: sequenceType : SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}' ;
    public void sequenceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:4: ( SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:4: SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}'
            {
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceType651); 
            	Match(input,45,FOLLOW_45_in_sequenceType653); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:17: ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )?
            	int alt40 = 2;
            	int LA40_0 = input.LA(1);
            	
            	if ( (LA40_0 == LID) )
            	{
            	    alt40 = 1;
            	}
            	switch (alt40) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:18: identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_sequenceType656);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	PushFollow(FOLLOW_type_in_sequenceType658);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:34: ( OPTIONAL )?
            	        	int alt37 = 2;
            	        	int LA37_0 = input.LA(1);
            	        	
            	        	if ( (LA37_0 == OPTIONAL) )
            	        	{
            	        	    alt37 = 1;
            	        	}
            	        	switch (alt37) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:35: OPTIONAL
            	        	        {
            	        	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_sequenceType661); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:47: ( ',' identifier type ( OPTIONAL )? )*
            	        	do 
            	        	{
            	        	    int alt39 = 2;
            	        	    int LA39_0 = input.LA(1);
            	        	    
            	        	    if ( (LA39_0 == 50) )
            	        	    {
            	        	        alt39 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt39) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:48: ',' identifier type ( OPTIONAL )?
            	        			    {
            	        			    	Match(input,50,FOLLOW_50_in_sequenceType667); 
            	        			    	PushFollow(FOLLOW_identifier_in_sequenceType669);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	PushFollow(FOLLOW_type_in_sequenceType671);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:68: ( OPTIONAL )?
            	        			    	int alt38 = 2;
            	        			    	int LA38_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA38_0 == OPTIONAL) )
            	        			    	{
            	        			    	    alt38 = 1;
            	        			    	}
            	        			    	switch (alt38) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:94:69: OPTIONAL
            	        			    	        {
            	        			    	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_sequenceType674); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop39;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop39:
            	        		;	// Stops C# compiler whinging that label 'loop39' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,46,FOLLOW_46_in_sequenceType684); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:1: sequenceOfType : SEQUENCE ( '(' SIZE constraint ')' )? OF type ;
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:4: ( SEQUENCE ( '(' SIZE constraint ')' )? OF type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:4: SEQUENCE ( '(' SIZE constraint ')' )? OF type
            {
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType697); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:13: ( '(' SIZE constraint ')' )?
            	int alt41 = 2;
            	int LA41_0 = input.LA(1);
            	
            	if ( (LA41_0 == 47) )
            	{
            	    alt41 = 1;
            	}
            	switch (alt41) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:98:15: '(' SIZE constraint ')'
            	        {
            	        	Match(input,47,FOLLOW_47_in_sequenceOfType701); 
            	        	Match(input,SIZE,FOLLOW_SIZE_in_sequenceOfType703); 
            	        	PushFollow(FOLLOW_constraint_in_sequenceOfType705);
            	        	constraint();
            	        	followingStackPointer_--;

            	        	Match(input,48,FOLLOW_48_in_sequenceOfType707); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,OF,FOLLOW_OF_in_sequenceOfType712); 
            	PushFollow(FOLLOW_type_in_sequenceOfType714);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:102:1: octetStringType : OCTET STRING ;
    public void octetStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:103:4: ( OCTET STRING )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:103:4: OCTET STRING
            {
            	Match(input,OCTET,FOLLOW_OCTET_in_octetStringType728); 
            	Match(input,STRING,FOLLOW_STRING_in_octetStringType730); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:106:1: namedNumber : LID '(' signedNumber ')' ;
    public void namedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:107:4: ( LID '(' signedNumber ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:107:4: LID '(' signedNumber ')'
            {
            	Match(input,LID,FOLLOW_LID_in_namedNumber742); 
            	Match(input,47,FOLLOW_47_in_namedNumber744); 
            	PushFollow(FOLLOW_signedNumber_in_namedNumber746);
            	signedNumber();
            	followingStackPointer_--;

            	Match(input,48,FOLLOW_48_in_namedNumber748); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:110:1: signedNumber : ( '+' | '-' )? INT ;
    public void signedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:4: ( ( '+' | '-' )? INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:4: ( '+' | '-' )? INT
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:4: ( '+' | '-' )?
            	int alt42 = 2;
            	int LA42_0 = input.LA(1);
            	
            	if ( ((LA42_0 >= 53 && LA42_0 <= 54)) )
            	{
            	    alt42 = 1;
            	}
            	switch (alt42) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( (input.LA(1) >= 53 && input.LA(1) <= 54) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber759);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber766); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:134:1: constraint : '(' element ')' ;
    public void constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:4: ( '(' element ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:135:4: '(' element ')'
            {
            	Match(input,47,FOLLOW_47_in_constraint779); 
            	PushFollow(FOLLOW_element_in_constraint781);
            	element();
            	followingStackPointer_--;

            	Match(input,48,FOLLOW_48_in_constraint783); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:138:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | SIZE constraint );
    public void element() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:5: ( value ( ( '<' )? '..' ( '<' )? value )? | SIZE constraint )
            int alt46 = 2;
            int LA46_0 = input.LA(1);
            
            if ( (LA46_0 == INT || (LA46_0 >= LID && LA46_0 <= FALSE) || (LA46_0 >= 53 && LA46_0 <= 54)) )
            {
                alt46 = 1;
            }
            else if ( (LA46_0 == SIZE) )
            {
                alt46 = 2;
            }
            else 
            {
                NoViableAltException nvae_d46s0 =
                    new NoViableAltException("138:1: element : ( value ( ( '<' )? '..' ( '<' )? value )? | SIZE constraint );", 46, 0, input);
            
                throw nvae_d46s0;
            }
            switch (alt46) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:5: value ( ( '<' )? '..' ( '<' )? value )?
                    {
                    	PushFollow(FOLLOW_value_in_element795);
                    	value();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:11: ( ( '<' )? '..' ( '<' )? value )?
                    	int alt45 = 2;
                    	int LA45_0 = input.LA(1);
                    	
                    	if ( ((LA45_0 >= 55 && LA45_0 <= 56)) )
                    	{
                    	    alt45 = 1;
                    	}
                    	switch (alt45) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:13: ( '<' )? '..' ( '<' )? value
                    	        {
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:13: ( '<' )?
                    	        	int alt43 = 2;
                    	        	int LA43_0 = input.LA(1);
                    	        	
                    	        	if ( (LA43_0 == 55) )
                    	        	{
                    	        	    alt43 = 1;
                    	        	}
                    	        	switch (alt43) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:14: '<'
                    	        	        {
                    	        	        	Match(input,55,FOLLOW_55_in_element800); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	Match(input,56,FOLLOW_56_in_element804); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:25: ( '<' )?
                    	        	int alt44 = 2;
                    	        	int LA44_0 = input.LA(1);
                    	        	
                    	        	if ( (LA44_0 == 55) )
                    	        	{
                    	        	    alt44 = 1;
                    	        	}
                    	        	switch (alt44) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:139:26: '<'
                    	        	        {
                    	        	        	Match(input,55,FOLLOW_55_in_element807); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	PushFollow(FOLLOW_value_in_element811);
                    	        	value();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:4: SIZE constraint
                    {
                    	Match(input,SIZE,FOLLOW_SIZE_in_element818); 
                    	PushFollow(FOLLOW_constraint_in_element820);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:143:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:3: ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX )
            int alt50 = 6;
            switch ( input.LA(1) ) 
            {
            case Bstring:
            case Hstring:
            	{
                alt50 = 1;
                }
                break;
            case TRUE:
            case FALSE:
            	{
                alt50 = 2;
                }
                break;
            case LID:
            	{
                alt50 = 3;
                }
                break;
            case INT:
            case 53:
            case 54:
            	{
                alt50 = 4;
                }
                break;
            case MIN:
            	{
                alt50 = 5;
                }
                break;
            case MAX:
            	{
                alt50 = 6;
                }
                break;
            	default:
            	    NoViableAltException nvae_d50s0 =
            	        new NoViableAltException("143:1: value : ( bitStringValue | booleanValue | LID | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );", 50, 0, input);
            
            	    throw nvae_d50s0;
            }
            
            switch (alt50) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:3: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value832);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:145:4: booleanValue
                    {
                    	PushFollow(FOLLOW_booleanValue_in_value837);
                    	booleanValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:147:4: LID
                    {
                    	Match(input,LID,FOLLOW_LID_in_value843); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:4: ( '+' | '-' )?
                    	int alt47 = 2;
                    	int LA47_0 = input.LA(1);
                    	
                    	if ( ((LA47_0 >= 53 && LA47_0 <= 54)) )
                    	{
                    	    alt47 = 1;
                    	}
                    	switch (alt47) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
                    	        {
                    	        	if ( (input.LA(1) >= 53 && input.LA(1) <= 54) ) 
                    	        	{
                    	        	    input.Consume();
                    	        	    errorRecovery = false;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse =
                    	        	        new MismatchedSetException(null,input);
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value850);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value857); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:19: ( '.' ( INT )? )?
                    	int alt49 = 2;
                    	int LA49_0 = input.LA(1);
                    	
                    	if ( (LA49_0 == 57) )
                    	{
                    	    alt49 = 1;
                    	}
                    	switch (alt49) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:20: '.' ( INT )?
                    	        {
                    	        	Match(input,57,FOLLOW_57_in_value860); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:24: ( INT )?
                    	        	int alt48 = 2;
                    	        	int LA48_0 = input.LA(1);
                    	        	
                    	        	if ( (LA48_0 == INT) )
                    	        	{
                    	        	    alt48 = 1;
                    	        	}
                    	        	switch (alt48) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value862); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:150:4: MIN
                    {
                    	Match(input,MIN,FOLLOW_MIN_in_value872); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:151:4: MAX
                    {
                    	Match(input,MAX,FOLLOW_MAX_in_value877); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:154:1: bitStringValue : ( Bstring | Hstring );
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:155:4: ( Bstring | Hstring )
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:159:1: booleanValue : ( TRUE | FALSE );
    public void booleanValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:160:4: ( TRUE | FALSE )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            {
            	if ( (input.LA(1) >= TRUE && input.LA(1) <= FALSE) ) 
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:1: lID : LID ;
    public void lID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:7: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:7: LID
            {
            	Match(input,LID,FOLLOW_LID_in_lID924); 
            
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

    
    // $ANTLR start modulereference
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:1: modulereference : UID ;
    public void modulereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:19: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:167:19: UID
            {
            	Match(input,UID,FOLLOW_UID_in_modulereference932); 
            
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
    // $ANTLR end modulereference

    
    // $ANTLR start typereference
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:1: typereference : UID ;
    public void typereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:17: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:17: UID
            {
            	Match(input,UID,FOLLOW_UID_in_typereference940); 
            
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
    // $ANTLR end typereference

    
    // $ANTLR start valuereference
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:171:1: valuereference : LID ;
    public void valuereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:171:19: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:171:19: LID
            {
            	Match(input,LID,FOLLOW_LID_in_valuereference950); 
            
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
    // $ANTLR end valuereference

    
    // $ANTLR start identifier
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:1: identifier : LID ;
    public void identifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:14: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:14: LID
            {
            	Match(input,LID,FOLLOW_LID_in_identifier960); 
            
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
    // $ANTLR end identifier


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_moduleDefinition_in_moduleDefinitions30 = new BitSet(new ulong[]{0x0000010000000002UL});
    public static readonly BitSet FOLLOW_modulereference_in_moduleDefinition41 = new BitSet(new ulong[]{0x0000200000000010UL});
    public static readonly BitSet FOLLOW_definitiveIdentifier_in_moduleDefinition43 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_DEFINITIONS_in_moduleDefinition49 = new BitSet(new ulong[]{0x00001000000003A0UL});
    public static readonly BitSet FOLLOW_EXPLICIT_in_moduleDefinition55 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition57 = new BitSet(new ulong[]{0x0000100000000200UL});
    public static readonly BitSet FOLLOW_IMPLICIT_in_moduleDefinition61 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition63 = new BitSet(new ulong[]{0x0000100000000200UL});
    public static readonly BitSet FOLLOW_AUTOMATIC_in_moduleDefinition67 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition69 = new BitSet(new ulong[]{0x0000100000000200UL});
    public static readonly BitSet FOLLOW_EXTENSIBILITY_in_moduleDefinition77 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_IMPLIED_in_moduleDefinition79 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_moduleDefinition86 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_BEGIN_in_moduleDefinition88 = new BitSet(new ulong[]{0x0000010200015000UL});
    public static readonly BitSet FOLLOW_exports_in_moduleDefinition94 = new BitSet(new ulong[]{0x0000010200011000UL});
    public static readonly BitSet FOLLOW_imports_in_moduleDefinition102 = new BitSet(new ulong[]{0x0000010200001000UL});
    public static readonly BitSet FOLLOW_typeAssigment_in_moduleDefinition115 = new BitSet(new ulong[]{0x0000010200001000UL});
    public static readonly BitSet FOLLOW_valueAssigment_in_moduleDefinition122 = new BitSet(new ulong[]{0x0000010200001000UL});
    public static readonly BitSet FOLLOW_END_in_moduleDefinition133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_45_in_definitiveIdentifier141 = new BitSet(new ulong[]{0x0000400200002000UL});
    public static readonly BitSet FOLLOW_definitiveObjIdComponent_in_definitiveIdentifier143 = new BitSet(new ulong[]{0x0000400200002000UL});
    public static readonly BitSet FOLLOW_46_in_definitiveIdentifier146 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_definitiveObjIdComponent159 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_47_in_definitiveObjIdComponent163 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent165 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_definitiveObjIdComponent167 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports190 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_ALL_in_exports192 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_49_in_exports194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports199 = new BitSet(new ulong[]{0x0000010200000000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports202 = new BitSet(new ulong[]{0x0006000000000000UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports206 = new BitSet(new ulong[]{0x0006000000000000UL});
    public static readonly BitSet FOLLOW_50_in_exports210 = new BitSet(new ulong[]{0x0000010200000000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports213 = new BitSet(new ulong[]{0x0006000000000000UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports217 = new BitSet(new ulong[]{0x0006000000000000UL});
    public static readonly BitSet FOLLOW_49_in_exports223 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IMPORTS_in_imports236 = new BitSet(new ulong[]{0x0002010200000000UL});
    public static readonly BitSet FOLLOW_typereference_in_imports240 = new BitSet(new ulong[]{0x0004000000020000UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports244 = new BitSet(new ulong[]{0x0004000000020000UL});
    public static readonly BitSet FOLLOW_50_in_imports248 = new BitSet(new ulong[]{0x0000010200000000UL});
    public static readonly BitSet FOLLOW_typereference_in_imports251 = new BitSet(new ulong[]{0x0004000000020000UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports255 = new BitSet(new ulong[]{0x0004000000020000UL});
    public static readonly BitSet FOLLOW_FROM_in_imports260 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_modulereference_in_imports262 = new BitSet(new ulong[]{0x0002010200000000UL});
    public static readonly BitSet FOLLOW_49_in_imports266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_valueAssigment282 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_valueAssigment284 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_valueAssigment286 = new BitSet(new ulong[]{0x006000FE00002000UL});
    public static readonly BitSet FOLLOW_value_in_valueAssigment288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_typeAssigment305 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_44_in_typeAssigment307 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_typeAssigment309 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_51_in_type321 = new BitSet(new ulong[]{0x00000000001C2000UL});
    public static readonly BitSet FOLLOW_set_in_type323 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_type336 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_52_in_type339 = new BitSet(new ulong[]{0x000001011FA000A0UL});
    public static readonly BitSet FOLLOW_set_in_type341 = new BitSet(new ulong[]{0x000001011FA00000UL});
    public static readonly BitSet FOLLOW_bitStringType_in_type363 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_booleanType_in_type371 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type379 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_integerType_in_type387 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_octetStringType_in_type395 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_realType_in_type403 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_type411 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_constraint_in_type419 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type424 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type428 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type439 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BIT_in_bitStringType453 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_STRING_in_bitStringType455 = new BitSet(new ulong[]{0x0000200000000002UL});
    public static readonly BitSet FOLLOW_45_in_bitStringType458 = new BitSet(new ulong[]{0x0000400200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType461 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_bitStringType463 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType465 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_bitStringType467 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_50_in_bitStringType470 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType472 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_bitStringType474 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType476 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_bitStringType478 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_46_in_bitStringType486 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BOOLEAN_in_booleanType501 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENUMERATED_in_enumeratedType514 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_45_in_enumeratedType516 = new BitSet(new ulong[]{0x0000400200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedType519 = new BitSet(new ulong[]{0x0004C00000000000UL});
    public static readonly BitSet FOLLOW_47_in_enumeratedType523 = new BitSet(new ulong[]{0x0060000000002000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType525 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_enumeratedType527 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_50_in_enumeratedType532 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedType534 = new BitSet(new ulong[]{0x0004C00000000000UL});
    public static readonly BitSet FOLLOW_47_in_enumeratedType538 = new BitSet(new ulong[]{0x0060000000002000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType540 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_enumeratedType542 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_46_in_enumeratedType550 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INTEGER_in_integerType562 = new BitSet(new ulong[]{0x0000200000000002UL});
    public static readonly BitSet FOLLOW_45_in_integerType566 = new BitSet(new ulong[]{0x0000400200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType569 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_integerType571 = new BitSet(new ulong[]{0x0060000000002000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType573 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_integerType575 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_50_in_integerType578 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType580 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_integerType582 = new BitSet(new ulong[]{0x0060000000002000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType584 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_integerType586 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_46_in_integerType592 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_realType607 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CHOICE_in_choiceType619 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_45_in_choiceType621 = new BitSet(new ulong[]{0x0000400200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceType624 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_choiceType626 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_50_in_choiceType629 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceType631 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_choiceType633 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_46_in_choiceType640 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceType651 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_45_in_sequenceType653 = new BitSet(new ulong[]{0x0000400200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceType656 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType658 = new BitSet(new ulong[]{0x0004400020000000UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_sequenceType661 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_50_in_sequenceType667 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceType669 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType671 = new BitSet(new ulong[]{0x0004400020000000UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_sequenceType674 = new BitSet(new ulong[]{0x0004400000000000UL});
    public static readonly BitSet FOLLOW_46_in_sequenceType684 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType697 = new BitSet(new ulong[]{0x0000800080000000UL});
    public static readonly BitSet FOLLOW_47_in_sequenceOfType701 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sequenceOfType703 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_constraint_in_sequenceOfType705 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_sequenceOfType707 = new BitSet(new ulong[]{0x0000000080000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType712 = new BitSet(new ulong[]{0x000801011FA00000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType714 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCTET_in_octetStringType728 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_STRING_in_octetStringType730 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_namedNumber742 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_47_in_namedNumber744 = new BitSet(new ulong[]{0x0060000000002000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_namedNumber746 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_namedNumber748 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber759 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber766 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_47_in_constraint779 = new BitSet(new ulong[]{0x006000FE40002000UL});
    public static readonly BitSet FOLLOW_element_in_constraint781 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_48_in_constraint783 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_value_in_element795 = new BitSet(new ulong[]{0x0180000000000002UL});
    public static readonly BitSet FOLLOW_55_in_element800 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_56_in_element804 = new BitSet(new ulong[]{0x00E000FE00002000UL});
    public static readonly BitSet FOLLOW_55_in_element807 = new BitSet(new ulong[]{0x006000FE00002000UL});
    public static readonly BitSet FOLLOW_value_in_element811 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SIZE_in_element818 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_constraint_in_element820 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value832 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanValue_in_value837 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_value843 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value850 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_value857 = new BitSet(new ulong[]{0x0200000000000002UL});
    public static readonly BitSet FOLLOW_57_in_value860 = new BitSet(new ulong[]{0x0000000000002002UL});
    public static readonly BitSet FOLLOW_INT_in_value862 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MIN_in_value872 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAX_in_value877 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_bitStringValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_booleanValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_lID924 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_modulereference932 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typereference940 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valuereference950 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_identifier960 = new BitSet(new ulong[]{0x0000000000000002UL});

}
