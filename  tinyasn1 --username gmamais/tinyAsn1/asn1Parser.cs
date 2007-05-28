// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-28 18:09:26



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
		"OF", 
		"OCTET", 
		"NumericString", 
		"PrintableString", 
		"VisibleString", 
		"IA5String", 
		"TeletexString", 
		"VideotexString", 
		"GraphicString", 
		"GeneralString", 
		"UniversalString", 
		"BMPString", 
		"UTF8String", 
		"LID", 
		"SIZE", 
		"WITH", 
		"COMPONENTS", 
		"PRESENT", 
		"ABSENT", 
		"StringLiteral", 
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
		"'...'", 
		"'.'"
    };

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
    public const int BOOLEAN = 23;
    public const int EXPORTS = 14;
    public const int PRESENT = 47;
    public const int ALL = 15;
    public const int BEGIN = 11;
    public const int GeneralString = 39;
    public const int UID = 56;
    public const int COMMENT = 58;
    public const int BMPString = 41;
    public const int CHOICE = 27;
    public const int WITH = 45;
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
    public const int Hstring = 53;
    public const int ABSENT = 48;
    public const int GraphicString = 38;
    public const int BIT = 21;
    public const int IMPORTS = 16;
    public const int VisibleString = 34;
    public const int FROM = 17;
    public const int END = 12;
    public const int UniversalString = 40;
    public const int FALSE = 55;
    public const int UNIVERSAL = 18;
    public const int SIZE = 44;
    public const int OCTET = 31;
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
            	
            	if ( (LA2_0 == 61) )
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

            	Match(input,60,FOLLOW_60_in_moduleDefinition86); 
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
            	Match(input,61,FOLLOW_61_in_definitiveIdentifier141); 
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

            	Match(input,62,FOLLOW_62_in_definitiveIdentifier146); 
            
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
                    	
                    	if ( (LA9_0 == 63) )
                    	{
                    	    alt9 = 1;
                    	}
                    	switch (alt9) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:17: '(' INT ')'
                    	        {
                    	        	Match(input,63,FOLLOW_63_in_definitiveObjIdComponent163); 
                    	        	Match(input,INT,FOLLOW_INT_in_definitiveObjIdComponent165); 
                    	        	Match(input,64,FOLLOW_64_in_definitiveObjIdComponent167); 
                    	        
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
                    	Match(input,65,FOLLOW_65_in_exports194); 
                    
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
                    	    
                    	    if ( (LA13_0 == 66) )
                    	    {
                    	        alt13 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:36:46: ',' ( typereference | valuereference )
                    			    {
                    			    	Match(input,66,FOLLOW_66_in_exports210); 
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

                    	Match(input,65,FOLLOW_65_in_exports223); 
                    
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
            			    	    
            			    	    if ( (LA17_0 == 66) )
            			    	    {
            			    	        alt17 = 1;
            			    	    }
            			    	    
            			    	
            			    	    switch (alt17) 
            			    		{
            			    			case 1 :
            			    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:45: ',' ( typereference | valuereference )
            			    			    {
            			    			    	Match(input,66,FOLLOW_66_in_imports248); 
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

            	Match(input,65,FOLLOW_65_in_imports266); 
            
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

            	Match(input,60,FOLLOW_60_in_valueAssigment286); 
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

            	Match(input,60,FOLLOW_60_in_typeAssigment307); 
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:1: type : ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);
            	
            	if ( (LA21_0 == 67) )
            	{
            	    alt21 = 1;
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:9: '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )?
            	        {
            	        	Match(input,67,FOLLOW_67_in_type321); 
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
            	        	Match(input,68,FOLLOW_68_in_type339); 
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

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:1: ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType )
            	int alt27 = 10;
            	switch ( input.LA(1) ) 
            	{
            	case BIT:
            		{
            	    alt27 = 1;
            	    }
            	    break;
            	case BOOLEAN:
            		{
            	    alt27 = 2;
            	    }
            	    break;
            	case ENUMERATED:
            		{
            	    alt27 = 3;
            	    }
            	    break;
            	case INTEGER:
            		{
            	    alt27 = 4;
            	    }
            	    break;
            	case REAL:
            		{
            	    alt27 = 5;
            	    }
            	    break;
            	case OCTET:
            	case NumericString:
            	case PrintableString:
            	case VisibleString:
            	case IA5String:
            	case TeletexString:
            	case VideotexString:
            	case GraphicString:
            	case GeneralString:
            	case UniversalString:
            	case BMPString:
            	case UTF8String:
            		{
            	    alt27 = 6;
            	    }
            	    break;
            	case UID:
            		{
            	    alt27 = 7;
            	    }
            	    break;
            	case SEQUENCE:
            		{
            	    int LA27_8 = input.LA(2);
            	    
            	    if ( (LA27_8 == 61) )
            	    {
            	        alt27 = 10;
            	    }
            	    else if ( (LA27_8 == OF || LA27_8 == 63) )
            	    {
            	        alt27 = 8;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d27s8 =
            	            new NoViableAltException("53:1: ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType )", 27, 8, input);
            	    
            	        throw nvae_d27s8;
            	    }
            	    }
            	    break;
            	case CHOICE:
            		{
            	    alt27 = 9;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d27s0 =
            		        new NoViableAltException("53:1: ( bitStringType | booleanType | enumeratedType | integerType ( singleValueOrRangeConstraint )? | realType ( singleValueOrRangeConstraint | withComponentsConstraint )? | stringType ( sizeConstraint )? ( permittedAlphabetConstraint )? | typereference ( constraint )? | sequenceOfType | choiceType | sequenceType )", 27, 0, input);
            	
            		    throw nvae_d27s0;
            	}
            	
            	switch (alt27) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:54:3: bitStringType
            	        {
            	        	PushFollow(FOLLOW_bitStringType_in_type359);
            	        	bitStringType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:55:3: booleanType
            	        {
            	        	PushFollow(FOLLOW_booleanType_in_type363);
            	        	booleanType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:56:3: enumeratedType
            	        {
            	        	PushFollow(FOLLOW_enumeratedType_in_type367);
            	        	enumeratedType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 4 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:3: integerType ( singleValueOrRangeConstraint )?
            	        {
            	        	PushFollow(FOLLOW_integerType_in_type371);
            	        	integerType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:15: ( singleValueOrRangeConstraint )?
            	        	int alt22 = 2;
            	        	int LA22_0 = input.LA(1);
            	        	
            	        	if ( (LA22_0 == 63) )
            	        	{
            	        	    alt22 = 1;
            	        	}
            	        	switch (alt22) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:15: singleValueOrRangeConstraint
            	        	        {
            	        	        	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_type373);
            	        	        	singleValueOrRangeConstraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 5 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:10: realType ( singleValueOrRangeConstraint | withComponentsConstraint )?
            	        {
            	        	PushFollow(FOLLOW_realType_in_type385);
            	        	realType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:19: ( singleValueOrRangeConstraint | withComponentsConstraint )?
            	        	int alt23 = 3;
            	        	int LA23_0 = input.LA(1);
            	        	
            	        	if ( (LA23_0 == 63) )
            	        	{
            	        	    int LA23_1 = input.LA(2);
            	        	    
            	        	    if ( (LA23_1 == WITH) )
            	        	    {
            	        	        alt23 = 2;
            	        	    }
            	        	    else if ( (LA23_1 == INT || LA23_1 == LID || (LA23_1 >= StringLiteral && LA23_1 <= FALSE) || (LA23_1 >= 69 && LA23_1 <= 70)) )
            	        	    {
            	        	        alt23 = 1;
            	        	    }
            	        	}
            	        	switch (alt23) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:20: singleValueOrRangeConstraint
            	        	        {
            	        	        	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_type388);
            	        	        	singleValueOrRangeConstraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:58:51: withComponentsConstraint
            	        	        {
            	        	        	PushFollow(FOLLOW_withComponentsConstraint_in_type392);
            	        	        	withComponentsConstraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 6 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:3: stringType ( sizeConstraint )? ( permittedAlphabetConstraint )?
            	        {
            	        	PushFollow(FOLLOW_stringType_in_type398);
            	        	stringType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:14: ( sizeConstraint )?
            	        	int alt24 = 2;
            	        	int LA24_0 = input.LA(1);
            	        	
            	        	if ( (LA24_0 == 63) )
            	        	{
            	        	    int LA24_1 = input.LA(2);
            	        	    
            	        	    if ( (LA24_1 == SIZE) )
            	        	    {
            	        	        alt24 = 1;
            	        	    }
            	        	}
            	        	switch (alt24) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:14: sizeConstraint
            	        	        {
            	        	        	PushFollow(FOLLOW_sizeConstraint_in_type400);
            	        	        	sizeConstraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:30: ( permittedAlphabetConstraint )?
            	        	int alt25 = 2;
            	        	int LA25_0 = input.LA(1);
            	        	
            	        	if ( (LA25_0 == 63) )
            	        	{
            	        	    alt25 = 1;
            	        	}
            	        	switch (alt25) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:30: permittedAlphabetConstraint
            	        	        {
            	        	        	PushFollow(FOLLOW_permittedAlphabetConstraint_in_type403);
            	        	        	permittedAlphabetConstraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 7 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:3: typereference ( constraint )?
            	        {
            	        	PushFollow(FOLLOW_typereference_in_type408);
            	        	typereference();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:17: ( constraint )?
            	        	int alt26 = 2;
            	        	int LA26_0 = input.LA(1);
            	        	
            	        	if ( (LA26_0 == 63) )
            	        	{
            	        	    alt26 = 1;
            	        	}
            	        	switch (alt26) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:17: constraint
            	        	        {
            	        	        	PushFollow(FOLLOW_constraint_in_type410);
            	        	        	constraint();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	    case 8 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:61:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type415);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 9 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:62:3: choiceType
            	        {
            	        	PushFollow(FOLLOW_choiceType_in_type419);
            	        	choiceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 10 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:10: sequenceType
            	        {
            	        	PushFollow(FOLLOW_sequenceType_in_type430);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:1: bitStringType : BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )? ;
    public void bitStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:4: ( BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:4: BIT STRING ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )?
            {
            	Match(input,BIT,FOLLOW_BIT_in_bitStringType444); 
            	Match(input,STRING,FOLLOW_STRING_in_bitStringType446); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:15: ( '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}' )?
            	int alt30 = 2;
            	int LA30_0 = input.LA(1);
            	
            	if ( (LA30_0 == 61) )
            	{
            	    alt30 = 1;
            	}
            	switch (alt30) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:16: '{' ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )? '}'
            	        {
            	        	Match(input,61,FOLLOW_61_in_bitStringType449); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:20: ( identifier '(' INT ')' ( ',' identifier '(' INT ')' )* )?
            	        	int alt29 = 2;
            	        	int LA29_0 = input.LA(1);
            	        	
            	        	if ( (LA29_0 == LID) )
            	        	{
            	        	    alt29 = 1;
            	        	}
            	        	switch (alt29) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:21: identifier '(' INT ')' ( ',' identifier '(' INT ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_bitStringType452);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,63,FOLLOW_63_in_bitStringType454); 
            	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType456); 
            	        	        	Match(input,64,FOLLOW_64_in_bitStringType458); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:44: ( ',' identifier '(' INT ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt28 = 2;
            	        	        	    int LA28_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA28_0 == 66) )
            	        	        	    {
            	        	        	        alt28 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt28) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:69:45: ',' identifier '(' INT ')'
            	        	        			    {
            	        	        			    	Match(input,66,FOLLOW_66_in_bitStringType461); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_bitStringType463);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,63,FOLLOW_63_in_bitStringType465); 
            	        	        			    	Match(input,INT,FOLLOW_INT_in_bitStringType467); 
            	        	        			    	Match(input,64,FOLLOW_64_in_bitStringType469); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop28;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop28:
            	        	        		;	// Stops C# compiler whinging that label 'loop28' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,62,FOLLOW_62_in_bitStringType477); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:72:1: booleanType : BOOLEAN ;
    public void booleanType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:4: ( BOOLEAN )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:4: BOOLEAN
            {
            	Match(input,BOOLEAN,FOLLOW_BOOLEAN_in_booleanType492); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:1: enumeratedType : ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}' ;
    public void enumeratedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:4: ( ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:4: ENUMERATED '{' ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )? '}'
            {
            	Match(input,ENUMERATED,FOLLOW_ENUMERATED_in_enumeratedType505); 
            	Match(input,61,FOLLOW_61_in_enumeratedType507); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:19: ( identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )* )?
            	int alt34 = 2;
            	int LA34_0 = input.LA(1);
            	
            	if ( (LA34_0 == LID) )
            	{
            	    alt34 = 1;
            	}
            	switch (alt34) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:20: identifier ( '(' signedNumber ')' )? ( ',' identifier ( '(' signedNumber ')' )? )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_enumeratedType510);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:31: ( '(' signedNumber ')' )?
            	        	int alt31 = 2;
            	        	int LA31_0 = input.LA(1);
            	        	
            	        	if ( (LA31_0 == 63) )
            	        	{
            	        	    alt31 = 1;
            	        	}
            	        	switch (alt31) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:33: '(' signedNumber ')'
            	        	        {
            	        	        	Match(input,63,FOLLOW_63_in_enumeratedType514); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType516);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,64,FOLLOW_64_in_enumeratedType518); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:56: ( ',' identifier ( '(' signedNumber ')' )? )*
            	        	do 
            	        	{
            	        	    int alt33 = 2;
            	        	    int LA33_0 = input.LA(1);
            	        	    
            	        	    if ( (LA33_0 == 66) )
            	        	    {
            	        	        alt33 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt33) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:57: ',' identifier ( '(' signedNumber ')' )?
            	        			    {
            	        			    	Match(input,66,FOLLOW_66_in_enumeratedType523); 
            	        			    	PushFollow(FOLLOW_identifier_in_enumeratedType525);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:72: ( '(' signedNumber ')' )?
            	        			    	int alt32 = 2;
            	        			    	int LA32_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA32_0 == 63) )
            	        			    	{
            	        			    	    alt32 = 1;
            	        			    	}
            	        			    	switch (alt32) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:74: '(' signedNumber ')'
            	        			    	        {
            	        			    	        	Match(input,63,FOLLOW_63_in_enumeratedType529); 
            	        			    	        	PushFollow(FOLLOW_signedNumber_in_enumeratedType531);
            	        			    	        	signedNumber();
            	        			    	        	followingStackPointer_--;

            	        			    	        	Match(input,64,FOLLOW_64_in_enumeratedType533); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop33;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop33:
            	        		;	// Stops C# compiler whinging that label 'loop33' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,62,FOLLOW_62_in_enumeratedType541); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:80:1: integerType : INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )? ;
    public void integerType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:4: ( INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:4: INTEGER ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )?
            {
            	Match(input,INTEGER,FOLLOW_INTEGER_in_integerType553); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:12: ( '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}' )?
            	int alt37 = 2;
            	int LA37_0 = input.LA(1);
            	
            	if ( (LA37_0 == 61) )
            	{
            	    alt37 = 1;
            	}
            	switch (alt37) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:14: '{' ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )? '}'
            	        {
            	        	Match(input,61,FOLLOW_61_in_integerType557); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:18: ( identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )* )?
            	        	int alt36 = 2;
            	        	int LA36_0 = input.LA(1);
            	        	
            	        	if ( (LA36_0 == LID) )
            	        	{
            	        	    alt36 = 1;
            	        	}
            	        	switch (alt36) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:19: identifier '(' signedNumber ')' ( ',' identifier '(' signedNumber ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_integerType560);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,63,FOLLOW_63_in_integerType562); 
            	        	        	PushFollow(FOLLOW_signedNumber_in_integerType564);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,64,FOLLOW_64_in_integerType566); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:51: ( ',' identifier '(' signedNumber ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt35 = 2;
            	        	        	    int LA35_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA35_0 == 66) )
            	        	        	    {
            	        	        	        alt35 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt35) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:52: ',' identifier '(' signedNumber ')'
            	        	        			    {
            	        	        			    	Match(input,66,FOLLOW_66_in_integerType569); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_integerType571);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,63,FOLLOW_63_in_integerType573); 
            	        	        			    	PushFollow(FOLLOW_signedNumber_in_integerType575);
            	        	        			    	signedNumber();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,64,FOLLOW_64_in_integerType577); 
            	        	        			    
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

            	        	Match(input,62,FOLLOW_62_in_integerType583); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:84:1: realType : REAL ;
    public void realType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:4: ( REAL )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:85:4: REAL
            {
            	Match(input,REAL,FOLLOW_REAL_in_realType598); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:96:1: choiceType : CHOICE '{' ( identifier type ( ',' identifier type )* )? '}' ;
    public void choiceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:4: ( CHOICE '{' ( identifier type ( ',' identifier type )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:4: CHOICE '{' ( identifier type ( ',' identifier type )* )? '}'
            {
            	Match(input,CHOICE,FOLLOW_CHOICE_in_choiceType615); 
            	Match(input,61,FOLLOW_61_in_choiceType617); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:15: ( identifier type ( ',' identifier type )* )?
            	int alt39 = 2;
            	int LA39_0 = input.LA(1);
            	
            	if ( (LA39_0 == LID) )
            	{
            	    alt39 = 1;
            	}
            	switch (alt39) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:16: identifier type ( ',' identifier type )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_choiceType620);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	PushFollow(FOLLOW_type_in_choiceType622);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:32: ( ',' identifier type )*
            	        	do 
            	        	{
            	        	    int alt38 = 2;
            	        	    int LA38_0 = input.LA(1);
            	        	    
            	        	    if ( (LA38_0 == 66) )
            	        	    {
            	        	        alt38 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt38) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:33: ',' identifier type
            	        			    {
            	        			    	Match(input,66,FOLLOW_66_in_choiceType625); 
            	        			    	PushFollow(FOLLOW_identifier_in_choiceType627);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	PushFollow(FOLLOW_type_in_choiceType629);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop38;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop38:
            	        		;	// Stops C# compiler whinging that label 'loop38' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,62,FOLLOW_62_in_choiceType636); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:1: sequenceType : SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}' ;
    public void sequenceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:4: ( SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:4: SEQUENCE '{' ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )? '}'
            {
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceType647); 
            	Match(input,61,FOLLOW_61_in_sequenceType649); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:17: ( identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )* )?
            	int alt43 = 2;
            	int LA43_0 = input.LA(1);
            	
            	if ( (LA43_0 == LID) )
            	{
            	    alt43 = 1;
            	}
            	switch (alt43) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:18: identifier type ( OPTIONAL )? ( ',' identifier type ( OPTIONAL )? )*
            	        {
            	        	PushFollow(FOLLOW_identifier_in_sequenceType652);
            	        	identifier();
            	        	followingStackPointer_--;

            	        	PushFollow(FOLLOW_type_in_sequenceType654);
            	        	type();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:34: ( OPTIONAL )?
            	        	int alt40 = 2;
            	        	int LA40_0 = input.LA(1);
            	        	
            	        	if ( (LA40_0 == OPTIONAL) )
            	        	{
            	        	    alt40 = 1;
            	        	}
            	        	switch (alt40) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:35: OPTIONAL
            	        	        {
            	        	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_sequenceType657); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:47: ( ',' identifier type ( OPTIONAL )? )*
            	        	do 
            	        	{
            	        	    int alt42 = 2;
            	        	    int LA42_0 = input.LA(1);
            	        	    
            	        	    if ( (LA42_0 == 66) )
            	        	    {
            	        	        alt42 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt42) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:48: ',' identifier type ( OPTIONAL )?
            	        			    {
            	        			    	Match(input,66,FOLLOW_66_in_sequenceType663); 
            	        			    	PushFollow(FOLLOW_identifier_in_sequenceType665);
            	        			    	identifier();
            	        			    	followingStackPointer_--;

            	        			    	PushFollow(FOLLOW_type_in_sequenceType667);
            	        			    	type();
            	        			    	followingStackPointer_--;

            	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:68: ( OPTIONAL )?
            	        			    	int alt41 = 2;
            	        			    	int LA41_0 = input.LA(1);
            	        			    	
            	        			    	if ( (LA41_0 == OPTIONAL) )
            	        			    	{
            	        			    	    alt41 = 1;
            	        			    	}
            	        			    	switch (alt41) 
            	        			    	{
            	        			    	    case 1 :
            	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:69: OPTIONAL
            	        			    	        {
            	        			    	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_sequenceType670); 
            	        			    	        
            	        			    	        }
            	        			    	        break;
            	        			    	
            	        			    	}

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop42;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop42:
            	        		;	// Stops C# compiler whinging that label 'loop42' has no statements

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,62,FOLLOW_62_in_sequenceType680); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:1: sequenceOfType : SEQUENCE ( sizeConstraint )? OF type ;
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:4: ( SEQUENCE ( sizeConstraint )? OF type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:4: SEQUENCE ( sizeConstraint )? OF type
            {
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType693); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:13: ( sizeConstraint )?
            	int alt44 = 2;
            	int LA44_0 = input.LA(1);
            	
            	if ( (LA44_0 == 63) )
            	{
            	    alt44 = 1;
            	}
            	switch (alt44) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:13: sizeConstraint
            	        {
            	        	PushFollow(FOLLOW_sizeConstraint_in_sequenceOfType695);
            	        	sizeConstraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,OF,FOLLOW_OF_in_sequenceOfType698); 
            	PushFollow(FOLLOW_type_in_sequenceOfType700);
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

    
    // $ANTLR start stringType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:109:1: stringType : ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String );
    public void stringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:110:3: ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String )
            int alt45 = 12;
            switch ( input.LA(1) ) 
            {
            case OCTET:
            	{
                alt45 = 1;
                }
                break;
            case NumericString:
            	{
                alt45 = 2;
                }
                break;
            case PrintableString:
            	{
                alt45 = 3;
                }
                break;
            case VisibleString:
            	{
                alt45 = 4;
                }
                break;
            case IA5String:
            	{
                alt45 = 5;
                }
                break;
            case TeletexString:
            	{
                alt45 = 6;
                }
                break;
            case VideotexString:
            	{
                alt45 = 7;
                }
                break;
            case GraphicString:
            	{
                alt45 = 8;
                }
                break;
            case GeneralString:
            	{
                alt45 = 9;
                }
                break;
            case UniversalString:
            	{
                alt45 = 10;
                }
                break;
            case BMPString:
            	{
                alt45 = 11;
                }
                break;
            case UTF8String:
            	{
                alt45 = 12;
                }
                break;
            	default:
            	    NoViableAltException nvae_d45s0 =
            	        new NoViableAltException("109:1: stringType : ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String );", 45, 0, input);
            
            	    throw nvae_d45s0;
            }
            
            switch (alt45) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:110:3: OCTET STRING
                    {
                    	Match(input,OCTET,FOLLOW_OCTET_in_stringType715); 
                    	Match(input,STRING,FOLLOW_STRING_in_stringType717); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:111:3: NumericString
                    {
                    	Match(input,NumericString,FOLLOW_NumericString_in_stringType721); 
                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:112:3: PrintableString
                    {
                    	Match(input,PrintableString,FOLLOW_PrintableString_in_stringType725); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:113:3: VisibleString
                    {
                    	Match(input,VisibleString,FOLLOW_VisibleString_in_stringType729); 
                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:114:3: IA5String
                    {
                    	Match(input,IA5String,FOLLOW_IA5String_in_stringType733); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:115:3: TeletexString
                    {
                    	Match(input,TeletexString,FOLLOW_TeletexString_in_stringType737); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:116:3: VideotexString
                    {
                    	Match(input,VideotexString,FOLLOW_VideotexString_in_stringType741); 
                    
                    }
                    break;
                case 8 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:117:3: GraphicString
                    {
                    	Match(input,GraphicString,FOLLOW_GraphicString_in_stringType745); 
                    
                    }
                    break;
                case 9 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:118:3: GeneralString
                    {
                    	Match(input,GeneralString,FOLLOW_GeneralString_in_stringType749); 
                    
                    }
                    break;
                case 10 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:119:3: UniversalString
                    {
                    	Match(input,UniversalString,FOLLOW_UniversalString_in_stringType753); 
                    
                    }
                    break;
                case 11 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:120:3: BMPString
                    {
                    	Match(input,BMPString,FOLLOW_BMPString_in_stringType757); 
                    
                    }
                    break;
                case 12 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:3: UTF8String
                    {
                    	Match(input,UTF8String,FOLLOW_UTF8String_in_stringType761); 
                    
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
    // $ANTLR end stringType

    
    // $ANTLR start namedNumber
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:126:1: namedNumber : LID '(' signedNumber ')' ;
    public void namedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:127:4: ( LID '(' signedNumber ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:127:4: LID '(' signedNumber ')'
            {
            	Match(input,LID,FOLLOW_LID_in_namedNumber777); 
            	Match(input,63,FOLLOW_63_in_namedNumber779); 
            	PushFollow(FOLLOW_signedNumber_in_namedNumber781);
            	signedNumber();
            	followingStackPointer_--;

            	Match(input,64,FOLLOW_64_in_namedNumber783); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:130:1: signedNumber : ( '+' | '-' )? INT ;
    public void signedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:4: ( ( '+' | '-' )? INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:4: ( '+' | '-' )? INT
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:4: ( '+' | '-' )?
            	int alt46 = 2;
            	int LA46_0 = input.LA(1);
            	
            	if ( ((LA46_0 >= 69 && LA46_0 <= 70)) )
            	{
            	    alt46 = 1;
            	}
            	switch (alt46) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( (input.LA(1) >= 69 && input.LA(1) <= 70) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber794);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber801); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:154:1: constraint : ( singleValueOrRangeConstraint | sizeConstraint | withComponentsConstraint );
    public void constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:155:4: ( singleValueOrRangeConstraint | sizeConstraint | withComponentsConstraint )
            int alt47 = 3;
            int LA47_0 = input.LA(1);
            
            if ( (LA47_0 == 63) )
            {
                switch ( input.LA(2) ) 
                {
                case WITH:
                	{
                    alt47 = 3;
                    }
                    break;
                case SIZE:
                	{
                    alt47 = 2;
                    }
                    break;
                case INT:
                case LID:
                case StringLiteral:
                case MIN:
                case MAX:
                case Bstring:
                case Hstring:
                case TRUE:
                case FALSE:
                case 69:
                case 70:
                	{
                    alt47 = 1;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d47s1 =
                	        new NoViableAltException("154:1: constraint : ( singleValueOrRangeConstraint | sizeConstraint | withComponentsConstraint );", 47, 1, input);
                
                	    throw nvae_d47s1;
                }
            
            }
            else 
            {
                NoViableAltException nvae_d47s0 =
                    new NoViableAltException("154:1: constraint : ( singleValueOrRangeConstraint | sizeConstraint | withComponentsConstraint );", 47, 0, input);
            
                throw nvae_d47s0;
            }
            switch (alt47) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:155:4: singleValueOrRangeConstraint
                    {
                    	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_constraint814);
                    	singleValueOrRangeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:4: sizeConstraint
                    {
                    	PushFollow(FOLLOW_sizeConstraint_in_constraint819);
                    	sizeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:157:4: withComponentsConstraint
                    {
                    	PushFollow(FOLLOW_withComponentsConstraint_in_constraint824);
                    	withComponentsConstraint();
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
    // $ANTLR end constraint

    
    // $ANTLR start singleValueOrRangeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:1: singleValueOrRangeConstraint : '(' value ( ( '<' )? '..' ( '<' )? value )? ')' ;
    public void singleValueOrRangeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:4: ( '(' value ( ( '<' )? '..' ( '<' )? value )? ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:4: '(' value ( ( '<' )? '..' ( '<' )? value )? ')'
            {
            	Match(input,63,FOLLOW_63_in_singleValueOrRangeConstraint839); 
            	PushFollow(FOLLOW_value_in_singleValueOrRangeConstraint841);
            	value();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:14: ( ( '<' )? '..' ( '<' )? value )?
            	int alt50 = 2;
            	int LA50_0 = input.LA(1);
            	
            	if ( ((LA50_0 >= 71 && LA50_0 <= 72)) )
            	{
            	    alt50 = 1;
            	}
            	switch (alt50) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:16: ( '<' )? '..' ( '<' )? value
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:16: ( '<' )?
            	        	int alt48 = 2;
            	        	int LA48_0 = input.LA(1);
            	        	
            	        	if ( (LA48_0 == 71) )
            	        	{
            	        	    alt48 = 1;
            	        	}
            	        	switch (alt48) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:17: '<'
            	        	        {
            	        	        	Match(input,71,FOLLOW_71_in_singleValueOrRangeConstraint846); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,72,FOLLOW_72_in_singleValueOrRangeConstraint850); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:28: ( '<' )?
            	        	int alt49 = 2;
            	        	int LA49_0 = input.LA(1);
            	        	
            	        	if ( (LA49_0 == 71) )
            	        	{
            	        	    alt49 = 1;
            	        	}
            	        	switch (alt49) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:162:29: '<'
            	        	        {
            	        	        	Match(input,71,FOLLOW_71_in_singleValueOrRangeConstraint853); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	PushFollow(FOLLOW_value_in_singleValueOrRangeConstraint857);
            	        	value();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,64,FOLLOW_64_in_singleValueOrRangeConstraint861); 
            
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
    // $ANTLR end singleValueOrRangeConstraint

    
    // $ANTLR start sizeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:1: sizeConstraint : '(' SIZE singleValueOrRangeConstraint ')' ;
    public void sizeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:166:4: ( '(' SIZE singleValueOrRangeConstraint ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:166:4: '(' SIZE singleValueOrRangeConstraint ')'
            {
            	Match(input,63,FOLLOW_63_in_sizeConstraint872); 
            	Match(input,SIZE,FOLLOW_SIZE_in_sizeConstraint874); 
            	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_sizeConstraint876);
            	singleValueOrRangeConstraint();
            	followingStackPointer_--;

            	Match(input,64,FOLLOW_64_in_sizeConstraint878); 
            
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
    // $ANTLR end sizeConstraint

    
    // $ANTLR start permittedAlphabetConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:1: permittedAlphabetConstraint : '(' FROM singleValueOrRangeConstraint ')' ;
    public void permittedAlphabetConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:4: ( '(' FROM singleValueOrRangeConstraint ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:170:4: '(' FROM singleValueOrRangeConstraint ')'
            {
            	Match(input,63,FOLLOW_63_in_permittedAlphabetConstraint891); 
            	Match(input,FROM,FOLLOW_FROM_in_permittedAlphabetConstraint893); 
            	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_permittedAlphabetConstraint895);
            	singleValueOrRangeConstraint();
            	followingStackPointer_--;

            	Match(input,64,FOLLOW_64_in_permittedAlphabetConstraint897); 
            
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
    // $ANTLR end permittedAlphabetConstraint

    
    // $ANTLR start withComponentsConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:1: withComponentsConstraint : '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')' ;
    public void withComponentsConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:4: ( '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:4: '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')'
            {
            	Match(input,63,FOLLOW_63_in_withComponentsConstraint911); 
            	Match(input,WITH,FOLLOW_WITH_in_withComponentsConstraint914); 
            	Match(input,COMPONENTS,FOLLOW_COMPONENTS_in_withComponentsConstraint916); 
            	Match(input,61,FOLLOW_61_in_withComponentsConstraint918); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:175:4: ( '...' ',' )?
            	int alt51 = 2;
            	int LA51_0 = input.LA(1);
            	
            	if ( (LA51_0 == 73) )
            	{
            	    alt51 = 1;
            	}
            	switch (alt51) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:175:6: '...' ','
            	        {
            	        	Match(input,73,FOLLOW_73_in_withComponentsConstraint925); 
            	        	Match(input,66,FOLLOW_66_in_withComponentsConstraint927); 
            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint934);
            	namedConstraint();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:21: ( ',' namedConstraint )*
            	do 
            	{
            	    int alt52 = 2;
            	    int LA52_0 = input.LA(1);
            	    
            	    if ( (LA52_0 == 66) )
            	    {
            	        alt52 = 1;
            	    }
            	    
            	
            	    switch (alt52) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:176:22: ',' namedConstraint
            			    {
            			    	Match(input,66,FOLLOW_66_in_withComponentsConstraint938); 
            			    	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint940);
            			    	namedConstraint();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop52;
            	    }
            	} while (true);
            	
            	loop52:
            		;	// Stops C# compiler whinging that label 'loop52' has no statements

            	Match(input,62,FOLLOW_62_in_withComponentsConstraint946); 
            	Match(input,64,FOLLOW_64_in_withComponentsConstraint950); 
            
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
    // $ANTLR end withComponentsConstraint

    
    // $ANTLR start namedConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:181:1: namedConstraint : identifier ( singleValueOrRangeConstraint )? ( PRESENT | ABSENT | OPTIONAL )? ;
    public void namedConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:4: ( identifier ( singleValueOrRangeConstraint )? ( PRESENT | ABSENT | OPTIONAL )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:4: identifier ( singleValueOrRangeConstraint )? ( PRESENT | ABSENT | OPTIONAL )?
            {
            	PushFollow(FOLLOW_identifier_in_namedConstraint962);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:15: ( singleValueOrRangeConstraint )?
            	int alt53 = 2;
            	int LA53_0 = input.LA(1);
            	
            	if ( (LA53_0 == 63) )
            	{
            	    alt53 = 1;
            	}
            	switch (alt53) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:16: singleValueOrRangeConstraint
            	        {
            	        	PushFollow(FOLLOW_singleValueOrRangeConstraint_in_namedConstraint965);
            	        	singleValueOrRangeConstraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:182:47: ( PRESENT | ABSENT | OPTIONAL )?
            	int alt54 = 2;
            	int LA54_0 = input.LA(1);
            	
            	if ( (LA54_0 == OPTIONAL || (LA54_0 >= PRESENT && LA54_0 <= ABSENT)) )
            	{
            	    alt54 = 1;
            	}
            	switch (alt54) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( input.LA(1) == OPTIONAL || (input.LA(1) >= PRESENT && input.LA(1) <= ABSENT) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_namedConstraint969);    throw mse;
            	        	}

            	        
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
    // $ANTLR end namedConstraint

    
    // $ANTLR start value
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:184:1: value : ( bitStringValue | booleanValue | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:3: ( bitStringValue | booleanValue | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX )
            int alt58 = 7;
            switch ( input.LA(1) ) 
            {
            case Bstring:
            case Hstring:
            	{
                alt58 = 1;
                }
                break;
            case TRUE:
            case FALSE:
            	{
                alt58 = 2;
                }
                break;
            case StringLiteral:
            	{
                alt58 = 3;
                }
                break;
            case LID:
            	{
                alt58 = 4;
                }
                break;
            case INT:
            case 69:
            case 70:
            	{
                alt58 = 5;
                }
                break;
            case MIN:
            	{
                alt58 = 6;
                }
                break;
            case MAX:
            	{
                alt58 = 7;
                }
                break;
            	default:
            	    NoViableAltException nvae_d58s0 =
            	        new NoViableAltException("184:1: value : ( bitStringValue | booleanValue | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );", 58, 0, input);
            
            	    throw nvae_d58s0;
            }
            
            switch (alt58) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:3: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value989);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:4: booleanValue
                    {
                    	PushFollow(FOLLOW_booleanValue_in_value994);
                    	booleanValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:187:4: StringLiteral
                    {
                    	Match(input,StringLiteral,FOLLOW_StringLiteral_in_value999); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:188:4: valuereference
                    {
                    	PushFollow(FOLLOW_valuereference_in_value1004);
                    	valuereference();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:4: ( '+' | '-' )?
                    	int alt55 = 2;
                    	int LA55_0 = input.LA(1);
                    	
                    	if ( ((LA55_0 >= 69 && LA55_0 <= 70)) )
                    	{
                    	    alt55 = 1;
                    	}
                    	switch (alt55) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
                    	        {
                    	        	if ( (input.LA(1) >= 69 && input.LA(1) <= 70) ) 
                    	        	{
                    	        	    input.Consume();
                    	        	    errorRecovery = false;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse =
                    	        	        new MismatchedSetException(null,input);
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value1011);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value1018); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:19: ( '.' ( INT )? )?
                    	int alt57 = 2;
                    	int LA57_0 = input.LA(1);
                    	
                    	if ( (LA57_0 == 74) )
                    	{
                    	    alt57 = 1;
                    	}
                    	switch (alt57) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:20: '.' ( INT )?
                    	        {
                    	        	Match(input,74,FOLLOW_74_in_value1021); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:24: ( INT )?
                    	        	int alt56 = 2;
                    	        	int LA56_0 = input.LA(1);
                    	        	
                    	        	if ( (LA56_0 == INT) )
                    	        	{
                    	        	    alt56 = 1;
                    	        	}
                    	        	switch (alt56) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value1023); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:191:4: MIN
                    {
                    	Match(input,MIN,FOLLOW_MIN_in_value1033); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:192:4: MAX
                    {
                    	Match(input,MAX,FOLLOW_MAX_in_value1038); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:195:1: bitStringValue : ( Bstring | Hstring );
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:196:4: ( Bstring | Hstring )
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:200:1: booleanValue : ( TRUE | FALSE );
    public void booleanValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:201:4: ( TRUE | FALSE )
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:206:1: lID : LID ;
    public void lID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:206:7: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:206:7: LID
            {
            	Match(input,LID,FOLLOW_LID_in_lID1085); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:1: modulereference : UID ;
    public void modulereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:19: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:19: UID
            {
            	Match(input,UID,FOLLOW_UID_in_modulereference1093); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:210:1: typereference : UID ;
    public void typereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:210:17: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:210:17: UID
            {
            	Match(input,UID,FOLLOW_UID_in_typereference1101); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:1: valuereference : LID ;
    public void valuereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:19: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:19: LID
            {
            	Match(input,LID,FOLLOW_LID_in_valuereference1111); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:214:1: identifier : LID ;
    public void identifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:214:14: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:214:14: LID
            {
            	Match(input,LID,FOLLOW_LID_in_identifier1121); 
            
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

 

    public static readonly BitSet FOLLOW_moduleDefinition_in_moduleDefinitions30 = new BitSet(new ulong[]{0x0100000000000002UL});
    public static readonly BitSet FOLLOW_modulereference_in_moduleDefinition41 = new BitSet(new ulong[]{0x2000000000000010UL});
    public static readonly BitSet FOLLOW_definitiveIdentifier_in_moduleDefinition43 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_DEFINITIONS_in_moduleDefinition49 = new BitSet(new ulong[]{0x10000000000003A0UL});
    public static readonly BitSet FOLLOW_EXPLICIT_in_moduleDefinition55 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition57 = new BitSet(new ulong[]{0x1000000000000200UL});
    public static readonly BitSet FOLLOW_IMPLICIT_in_moduleDefinition61 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition63 = new BitSet(new ulong[]{0x1000000000000200UL});
    public static readonly BitSet FOLLOW_AUTOMATIC_in_moduleDefinition67 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition69 = new BitSet(new ulong[]{0x1000000000000200UL});
    public static readonly BitSet FOLLOW_EXTENSIBILITY_in_moduleDefinition77 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_IMPLIED_in_moduleDefinition79 = new BitSet(new ulong[]{0x1000000000000000UL});
    public static readonly BitSet FOLLOW_60_in_moduleDefinition86 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_BEGIN_in_moduleDefinition88 = new BitSet(new ulong[]{0x0100080000015000UL});
    public static readonly BitSet FOLLOW_exports_in_moduleDefinition94 = new BitSet(new ulong[]{0x0100080000011000UL});
    public static readonly BitSet FOLLOW_imports_in_moduleDefinition102 = new BitSet(new ulong[]{0x0100080000001000UL});
    public static readonly BitSet FOLLOW_typeAssigment_in_moduleDefinition115 = new BitSet(new ulong[]{0x0100080000001000UL});
    public static readonly BitSet FOLLOW_valueAssigment_in_moduleDefinition122 = new BitSet(new ulong[]{0x0100080000001000UL});
    public static readonly BitSet FOLLOW_END_in_moduleDefinition133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_61_in_definitiveIdentifier141 = new BitSet(new ulong[]{0x4000080000002000UL});
    public static readonly BitSet FOLLOW_definitiveObjIdComponent_in_definitiveIdentifier143 = new BitSet(new ulong[]{0x4000080000002000UL});
    public static readonly BitSet FOLLOW_62_in_definitiveIdentifier146 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_definitiveObjIdComponent159 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_definitiveObjIdComponent163 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent165 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_definitiveObjIdComponent167 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports190 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_ALL_in_exports192 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_65_in_exports194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports199 = new BitSet(new ulong[]{0x0100080000000000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports202 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000006UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports206 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000006UL});
    public static readonly BitSet FOLLOW_66_in_exports210 = new BitSet(new ulong[]{0x0100080000000000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports213 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000006UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports217 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000006UL});
    public static readonly BitSet FOLLOW_65_in_exports223 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IMPORTS_in_imports236 = new BitSet(new ulong[]{0x0100080000000000UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_imports240 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports244 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_imports248 = new BitSet(new ulong[]{0x0100080000000000UL});
    public static readonly BitSet FOLLOW_typereference_in_imports251 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports255 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_FROM_in_imports260 = new BitSet(new ulong[]{0x0100000000000000UL});
    public static readonly BitSet FOLLOW_modulereference_in_imports262 = new BitSet(new ulong[]{0x0100080000000000UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_65_in_imports266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_valueAssigment282 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_valueAssigment284 = new BitSet(new ulong[]{0x1000000000000000UL});
    public static readonly BitSet FOLLOW_60_in_valueAssigment286 = new BitSet(new ulong[]{0x00FE080000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_value_in_valueAssigment288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_typeAssigment305 = new BitSet(new ulong[]{0x1000000000000000UL});
    public static readonly BitSet FOLLOW_60_in_typeAssigment307 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_typeAssigment309 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_67_in_type321 = new BitSet(new ulong[]{0x00000000001C2000UL});
    public static readonly BitSet FOLLOW_set_in_type323 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_type336 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000010UL});
    public static readonly BitSet FOLLOW_68_in_type339 = new BitSet(new ulong[]{0x010007FF9FA000A0UL});
    public static readonly BitSet FOLLOW_set_in_type341 = new BitSet(new ulong[]{0x010007FF9FA00000UL});
    public static readonly BitSet FOLLOW_bitStringType_in_type359 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanType_in_type363 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type367 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_integerType_in_type371 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_type373 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_realType_in_type385 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_type388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withComponentsConstraint_in_type392 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_stringType_in_type398 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_type400 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_permittedAlphabetConstraint_in_type403 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_type408 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_constraint_in_type410 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type415 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type419 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type430 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BIT_in_bitStringType444 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_STRING_in_bitStringType446 = new BitSet(new ulong[]{0x2000000000000002UL});
    public static readonly BitSet FOLLOW_61_in_bitStringType449 = new BitSet(new ulong[]{0x4000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType452 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_63_in_bitStringType454 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType456 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_bitStringType458 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_bitStringType461 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType463 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_63_in_bitStringType465 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType467 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_bitStringType469 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_bitStringType477 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BOOLEAN_in_booleanType492 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENUMERATED_in_enumeratedType505 = new BitSet(new ulong[]{0x2000000000000000UL});
    public static readonly BitSet FOLLOW_61_in_enumeratedType507 = new BitSet(new ulong[]{0x4000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedType510 = new BitSet(new ulong[]{0xC000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_63_in_enumeratedType514 = new BitSet(new ulong[]{0x0000000000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType516 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_enumeratedType518 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_enumeratedType523 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedType525 = new BitSet(new ulong[]{0xC000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_63_in_enumeratedType529 = new BitSet(new ulong[]{0x0000000000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedType531 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_enumeratedType533 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_enumeratedType541 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INTEGER_in_integerType553 = new BitSet(new ulong[]{0x2000000000000002UL});
    public static readonly BitSet FOLLOW_61_in_integerType557 = new BitSet(new ulong[]{0x4000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType560 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_63_in_integerType562 = new BitSet(new ulong[]{0x0000000000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType564 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_integerType566 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_integerType569 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType571 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_63_in_integerType573 = new BitSet(new ulong[]{0x0000000000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType575 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_integerType577 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_integerType583 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_realType598 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CHOICE_in_choiceType615 = new BitSet(new ulong[]{0x2000000000000000UL});
    public static readonly BitSet FOLLOW_61_in_choiceType617 = new BitSet(new ulong[]{0x4000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceType620 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_choiceType622 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_choiceType625 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceType627 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_choiceType629 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_choiceType636 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceType647 = new BitSet(new ulong[]{0x2000000000000000UL});
    public static readonly BitSet FOLLOW_61_in_sequenceType649 = new BitSet(new ulong[]{0x4000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceType652 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType654 = new BitSet(new ulong[]{0x4000000020000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_sequenceType657 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_sequenceType663 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceType665 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_sequenceType667 = new BitSet(new ulong[]{0x4000000020000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_sequenceType670 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_sequenceType680 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType693 = new BitSet(new ulong[]{0x8000000040000000UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_sequenceOfType695 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType698 = new BitSet(new ulong[]{0x010007FF9FA00000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType700 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCTET_in_stringType715 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_STRING_in_stringType717 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NumericString_in_stringType721 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PrintableString_in_stringType725 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VisibleString_in_stringType729 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IA5String_in_stringType733 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TeletexString_in_stringType737 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VideotexString_in_stringType741 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GraphicString_in_stringType745 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GeneralString_in_stringType749 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UniversalString_in_stringType753 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BMPString_in_stringType757 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UTF8String_in_stringType761 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_namedNumber777 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_63_in_namedNumber779 = new BitSet(new ulong[]{0x0000000000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_signedNumber_in_namedNumber781 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_namedNumber783 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber794 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber801 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_constraint814 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_constraint819 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withComponentsConstraint_in_constraint824 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_singleValueOrRangeConstraint839 = new BitSet(new ulong[]{0x00FE080000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_value_in_singleValueOrRangeConstraint841 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000181UL});
    public static readonly BitSet FOLLOW_71_in_singleValueOrRangeConstraint846 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000100UL});
    public static readonly BitSet FOLLOW_72_in_singleValueOrRangeConstraint850 = new BitSet(new ulong[]{0x00FE080000002000UL,0x00000000000000E0UL});
    public static readonly BitSet FOLLOW_71_in_singleValueOrRangeConstraint853 = new BitSet(new ulong[]{0x00FE080000002000UL,0x0000000000000060UL});
    public static readonly BitSet FOLLOW_value_in_singleValueOrRangeConstraint857 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_singleValueOrRangeConstraint861 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_sizeConstraint872 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sizeConstraint874 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_sizeConstraint876 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_sizeConstraint878 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_permittedAlphabetConstraint891 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_FROM_in_permittedAlphabetConstraint893 = new BitSet(new ulong[]{0x8000000000000000UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_permittedAlphabetConstraint895 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_permittedAlphabetConstraint897 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_63_in_withComponentsConstraint911 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_WITH_in_withComponentsConstraint914 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_COMPONENTS_in_withComponentsConstraint916 = new BitSet(new ulong[]{0x2000000000000000UL});
    public static readonly BitSet FOLLOW_61_in_withComponentsConstraint918 = new BitSet(new ulong[]{0x0000080000000000UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_withComponentsConstraint925 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_withComponentsConstraint927 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint934 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_66_in_withComponentsConstraint938 = new BitSet(new ulong[]{0x0000080000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint940 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000004UL});
    public static readonly BitSet FOLLOW_62_in_withComponentsConstraint946 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_64_in_withComponentsConstraint950 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_namedConstraint962 = new BitSet(new ulong[]{0x8001800020000002UL});
    public static readonly BitSet FOLLOW_singleValueOrRangeConstraint_in_namedConstraint965 = new BitSet(new ulong[]{0x0001800020000002UL});
    public static readonly BitSet FOLLOW_set_in_namedConstraint969 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value989 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanValue_in_value994 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_StringLiteral_in_value999 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_value1004 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value1011 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_value1018 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_value1021 = new BitSet(new ulong[]{0x0000000000002002UL});
    public static readonly BitSet FOLLOW_INT_in_value1023 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MIN_in_value1033 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAX_in_value1038 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_bitStringValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_booleanValue0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_lID1085 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_modulereference1093 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typereference1101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valuereference1111 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_identifier1121 = new BitSet(new ulong[]{0x0000000000000002UL});

}
