// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-31 14:30:30



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
		"NULL", 
		"BIT", 
		"STRING", 
		"BOOLEAN", 
		"ENUMERATED", 
		"INTEGER", 
		"REAL", 
		"CHOICE", 
		"SEQUENCE", 
		"SET", 
		"OPTIONAL", 
		"DEFAULT", 
		"OF", 
		"SIZE", 
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
		"UID", 
		"OBJECT", 
		"IDENTIFIER", 
		"RELATIVE_OID", 
		"WITH", 
		"COMPONENTS", 
		"PRESENT", 
		"ABSENT", 
		"BitStringLiteral", 
		"OctectStringLiteral", 
		"TRUE", 
		"FALSE", 
		"StringLiteral", 
		"MIN", 
		"MAX", 
		"LID", 
		"UnionMark", 
		"EXCEPT", 
		"IntersectionMark", 
		"INCLUDES", 
		"COMPONENT", 
		"PATTERN", 
		"STR", 
		"WS", 
		"COMMENT", 
		"COMMENT2", 
		"'::='", 
		"'{'", 
		"'}'", 
		"'('", 
		"')'", 
		"';'", 
		"','", 
		"'['", 
		"']'", 
		"'...'", 
		"'[['", 
		"']]'", 
		"'.'", 
		"'+'", 
		"'-'", 
		"'<'", 
		"'..'", 
		"'!'", 
		"':'"
    };

    public const int COMMENT2 = 72;
    public const int UnionMark = 63;
    public const int IA5String = 39;
    public const int TeletexString = 40;
    public const int COMPONENTS = 52;
    public const int APPLICATION = 19;
    public const int OctectStringLiteral = 56;
    public const int NumericString = 36;
    public const int BitStringLiteral = 55;
    public const int PrintableString = 37;
    public const int MAX = 61;
    public const int EXPLICIT = 5;
    public const int EXCEPT = 64;
    public const int EOF = -1;
    public const int PATTERN = 68;
    public const int INCLUDES = 66;
    public const int STR = 69;
    public const int BOOLEAN = 24;
    public const int OBJECT = 48;
    public const int EXPORTS = 14;
    public const int PRESENT = 53;
    public const int IDENTIFIER = 49;
    public const int ALL = 15;
    public const int BEGIN = 11;
    public const int RELATIVE_OID = 50;
    public const int GeneralString = 43;
    public const int UID = 47;
    public const int COMMENT = 71;
    public const int COMPONENT = 67;
    public const int BMPString = 45;
    public const int CHOICE = 28;
    public const int WITH = 51;
    public const int INTEGER = 26;
    public const int EXTENSIBILITY = 9;
    public const int IMPLICIT = 7;
    public const int PRIVATE = 20;
    public const int DEFINITIONS = 4;
    public const int NULL = 21;
    public const int DEFAULT = 32;
    public const int TAGS = 6;
    public const int SET = 30;
    public const int INT = 13;
    public const int MIN = 60;
    public const int UTF8String = 46;
    public const int OF = 33;
    public const int TRUE = 57;
    public const int IMPLIED = 10;
    public const int LID = 62;
    public const int OPTIONAL = 31;
    public const int StringLiteral = 59;
    public const int REAL = 27;
    public const int SEQUENCE = 29;
    public const int ENUMERATED = 25;
    public const int VideotexString = 41;
    public const int WS = 70;
    public const int ABSENT = 54;
    public const int GraphicString = 42;
    public const int IntersectionMark = 65;
    public const int BIT = 22;
    public const int IMPORTS = 16;
    public const int VisibleString = 38;
    public const int UniversalString = 44;
    public const int FROM = 17;
    public const int END = 12;
    public const int FALSE = 58;
    public const int UNIVERSAL = 18;
    public const int SIZE = 34;
    public const int OCTET = 35;
    public const int STRING = 23;
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

    
    public override void ReportError(RecognitionException e) {
    	base.ReportError(e);
            throw e;
    }
    


    
    // $ANTLR start moduleDefinitions
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:18:1: moduleDefinitions : ( moduleDefinition )* ;
    public void moduleDefinitions() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:4: ( ( moduleDefinition )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:4: ( moduleDefinition )*
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:4: ( moduleDefinition )*
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
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:19:4: moduleDefinition
            			    {
            			    	PushFollow(FOLLOW_moduleDefinition_in_moduleDefinitions35);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:1: moduleDefinition : modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment | valueSetAssigment )* END ;
    public void moduleDefinition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:22: ( modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment | valueSetAssigment )* END )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:22: modulereference ( definitiveIdentifier )? DEFINITIONS ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )? ( EXTENSIBILITY IMPLIED )? '::=' BEGIN ( exports )? ( imports )? ( typeAssigment | valueAssigment | valueSetAssigment )* END
            {
            	PushFollow(FOLLOW_modulereference_in_moduleDefinition46);
            	modulereference();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:38: ( definitiveIdentifier )?
            	int alt2 = 2;
            	int LA2_0 = input.LA(1);
            	
            	if ( (LA2_0 == 74) )
            	{
            	    alt2 = 1;
            	}
            	switch (alt2) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:21:38: definitiveIdentifier
            	        {
            	        	PushFollow(FOLLOW_definitiveIdentifier_in_moduleDefinition48);
            	        	definitiveIdentifier();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,DEFINITIONS,FOLLOW_DEFINITIONS_in_moduleDefinition54); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:4: ( EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS )?
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
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:5: EXPLICIT TAGS
            	        {
            	        	Match(input,EXPLICIT,FOLLOW_EXPLICIT_in_moduleDefinition60); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition62); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:21: IMPLICIT TAGS
            	        {
            	        	Match(input,IMPLICIT,FOLLOW_IMPLICIT_in_moduleDefinition66); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition68); 
            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:23:37: AUTOMATIC TAGS
            	        {
            	        	Match(input,AUTOMATIC,FOLLOW_AUTOMATIC_in_moduleDefinition72); 
            	        	Match(input,TAGS,FOLLOW_TAGS_in_moduleDefinition74); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:4: ( EXTENSIBILITY IMPLIED )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);
            	
            	if ( (LA4_0 == EXTENSIBILITY) )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:24:5: EXTENSIBILITY IMPLIED
            	        {
            	        	Match(input,EXTENSIBILITY,FOLLOW_EXTENSIBILITY_in_moduleDefinition82); 
            	        	Match(input,IMPLIED,FOLLOW_IMPLIED_in_moduleDefinition84); 
            	        
            	        }
            	        break;
            	
            	}

            	Match(input,73,FOLLOW_73_in_moduleDefinition91); 
            	Match(input,BEGIN,FOLLOW_BEGIN_in_moduleDefinition93); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:4: ( exports )?
            	int alt5 = 2;
            	int LA5_0 = input.LA(1);
            	
            	if ( (LA5_0 == EXPORTS) )
            	{
            	    alt5 = 1;
            	}
            	switch (alt5) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:26:5: exports
            	        {
            	        	PushFollow(FOLLOW_exports_in_moduleDefinition99);
            	        	exports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:4: ( imports )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);
            	
            	if ( (LA6_0 == IMPORTS) )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:27:5: imports
            	        {
            	        	PushFollow(FOLLOW_imports_in_moduleDefinition107);
            	        	imports();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:28:4: ( typeAssigment | valueAssigment | valueSetAssigment )*
            	do 
            	{
            	    int alt7 = 4;
            	    int LA7_0 = input.LA(1);
            	    
            	    if ( (LA7_0 == UID) )
            	    {
            	        int LA7_2 = input.LA(2);
            	        
            	        if ( (LA7_2 == 73) )
            	        {
            	            alt7 = 1;
            	        }
            	        else if ( ((LA7_2 >= NULL && LA7_2 <= BIT) || (LA7_2 >= BOOLEAN && LA7_2 <= SET) || (LA7_2 >= OCTET && LA7_2 <= OBJECT) || LA7_2 == RELATIVE_OID || LA7_2 == 80) )
            	        {
            	            alt7 = 3;
            	        }
            	        
            	    
            	    }
            	    else if ( (LA7_0 == LID) )
            	    {
            	        alt7 = 2;
            	    }
            	    
            	
            	    switch (alt7) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:29:5: typeAssigment
            			    {
            			    	PushFollow(FOLLOW_typeAssigment_in_moduleDefinition120);
            			    	typeAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            			case 2 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:30:6: valueAssigment
            			    {
            			    	PushFollow(FOLLOW_valueAssigment_in_moduleDefinition127);
            			    	valueAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            			case 3 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:31:6: valueSetAssigment
            			    {
            			    	PushFollow(FOLLOW_valueSetAssigment_in_moduleDefinition134);
            			    	valueSetAssigment();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop7;
            	    }
            	} while (true);
            	
            	loop7:
            		;	// Stops C# compiler whinging that label 'loop7' has no statements

            	Match(input,END,FOLLOW_END_in_moduleDefinition145); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:34:1: definitiveIdentifier : '{' ( definitiveObjIdComponent )* '}' ;
    public void definitiveIdentifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:4: ( '{' ( definitiveObjIdComponent )* '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:4: '{' ( definitiveObjIdComponent )* '}'
            {
            	Match(input,74,FOLLOW_74_in_definitiveIdentifier153); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:8: ( definitiveObjIdComponent )*
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
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:35:8: definitiveObjIdComponent
            			    {
            			    	PushFollow(FOLLOW_definitiveObjIdComponent_in_definitiveIdentifier155);
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

            	Match(input,75,FOLLOW_75_in_definitiveIdentifier158); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:38:1: definitiveObjIdComponent : ( identifier ( '(' INT ')' )? | INT );
    public void definitiveObjIdComponent() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:4: ( identifier ( '(' INT ')' )? | INT )
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
                    new NoViableAltException("38:1: definitiveObjIdComponent : ( identifier ( '(' INT ')' )? | INT );", 10, 0, input);
            
                throw nvae_d10s0;
            }
            switch (alt10) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:4: identifier ( '(' INT ')' )?
                    {
                    	PushFollow(FOLLOW_identifier_in_definitiveObjIdComponent171);
                    	identifier();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:15: ( '(' INT ')' )?
                    	int alt9 = 2;
                    	int LA9_0 = input.LA(1);
                    	
                    	if ( (LA9_0 == 76) )
                    	{
                    	    alt9 = 1;
                    	}
                    	switch (alt9) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:39:17: '(' INT ')'
                    	        {
                    	        	Match(input,76,FOLLOW_76_in_definitiveObjIdComponent175); 
                    	        	Match(input,INT,FOLLOW_INT_in_definitiveObjIdComponent177); 
                    	        	Match(input,77,FOLLOW_77_in_definitiveObjIdComponent179); 
                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:40:4: INT
                    {
                    	Match(input,INT,FOLLOW_INT_in_definitiveObjIdComponent187); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:42:1: exports : ( EXPORTS ALL ';' | EXPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )? ';' );
    public void exports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:3: ( EXPORTS ALL ';' | EXPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )? ';' )
            int alt15 = 2;
            int LA15_0 = input.LA(1);
            
            if ( (LA15_0 == EXPORTS) )
            {
                int LA15_1 = input.LA(2);
                
                if ( (LA15_1 == ALL) )
                {
                    alt15 = 1;
                }
                else if ( (LA15_1 == UID || LA15_1 == LID || LA15_1 == 78) )
                {
                    alt15 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d15s1 =
                        new NoViableAltException("42:1: exports : ( EXPORTS ALL ';' | EXPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )? ';' );", 15, 1, input);
                
                    throw nvae_d15s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d15s0 =
                    new NoViableAltException("42:1: exports : ( EXPORTS ALL ';' | EXPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )? ';' );", 15, 0, input);
            
                throw nvae_d15s0;
            }
            switch (alt15) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:43:3: EXPORTS ALL ';'
                    {
                    	Match(input,EXPORTS,FOLLOW_EXPORTS_in_exports202); 
                    	Match(input,ALL,FOLLOW_ALL_in_exports204); 
                    	Match(input,78,FOLLOW_78_in_exports206); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:4: EXPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )? ';'
                    {
                    	Match(input,EXPORTS,FOLLOW_EXPORTS_in_exports211); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:12: ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* )?
                    	int alt14 = 2;
                    	int LA14_0 = input.LA(1);
                    	
                    	if ( (LA14_0 == UID || LA14_0 == LID) )
                    	{
                    	    alt14 = 1;
                    	}
                    	switch (alt14) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:13: ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )*
                    	        {
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:13: ( typereference | valuereference )
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
                    	        	        new NoViableAltException("44:13: ( typereference | valuereference )", 11, 0, input);
                    	        	
                    	        	    throw nvae_d11s0;
                    	        	}
                    	        	switch (alt11) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:14: typereference
                    	        	        {
                    	        	        	PushFollow(FOLLOW_typereference_in_exports215);
                    	        	        	typereference();
                    	        	        	followingStackPointer_--;

                    	        	        
                    	        	        }
                    	        	        break;
                    	        	    case 2 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:30: valuereference
                    	        	        {
                    	        	        	PushFollow(FOLLOW_valuereference_in_exports219);
                    	        	        	valuereference();
                    	        	        	followingStackPointer_--;

                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:46: ( ',' ( typereference | valuereference ) )*
                    	        	do 
                    	        	{
                    	        	    int alt13 = 2;
                    	        	    int LA13_0 = input.LA(1);
                    	        	    
                    	        	    if ( (LA13_0 == 79) )
                    	        	    {
                    	        	        alt13 = 1;
                    	        	    }
                    	        	    
                    	        	
                    	        	    switch (alt13) 
                    	        		{
                    	        			case 1 :
                    	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:47: ',' ( typereference | valuereference )
                    	        			    {
                    	        			    	Match(input,79,FOLLOW_79_in_exports223); 
                    	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:51: ( typereference | valuereference )
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
                    	        			    	        new NoViableAltException("44:51: ( typereference | valuereference )", 12, 0, input);
                    	        			    	
                    	        			    	    throw nvae_d12s0;
                    	        			    	}
                    	        			    	switch (alt12) 
                    	        			    	{
                    	        			    	    case 1 :
                    	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:52: typereference
                    	        			    	        {
                    	        			    	        	PushFollow(FOLLOW_typereference_in_exports226);
                    	        			    	        	typereference();
                    	        			    	        	followingStackPointer_--;

                    	        			    	        
                    	        			    	        }
                    	        			    	        break;
                    	        			    	    case 2 :
                    	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:44:68: valuereference
                    	        			    	        {
                    	        			    	        	PushFollow(FOLLOW_valuereference_in_exports230);
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

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,78,FOLLOW_78_in_exports238); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:47:1: imports : IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference ( definitiveIdentifier )? )* ';' ;
    public void imports() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:2: ( IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference ( definitiveIdentifier )? )* ';' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:2: IMPORTS ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference ( definitiveIdentifier )? )* ';'
            {
            	Match(input,IMPORTS,FOLLOW_IMPORTS_in_imports251); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:10: ( ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference ( definitiveIdentifier )? )*
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);
            	    
            	    if ( (LA20_0 == UID || LA20_0 == LID) )
            	    {
            	        alt20 = 1;
            	    }
            	    
            	
            	    switch (alt20) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:11: ( typereference | valuereference ) ( ',' ( typereference | valuereference ) )* FROM modulereference ( definitiveIdentifier )?
            			    {
            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:11: ( typereference | valuereference )
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
            			    	        new NoViableAltException("48:11: ( typereference | valuereference )", 16, 0, input);
            			    	
            			    	    throw nvae_d16s0;
            			    	}
            			    	switch (alt16) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:12: typereference
            			    	        {
            			    	        	PushFollow(FOLLOW_typereference_in_imports255);
            			    	        	typereference();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:28: valuereference
            			    	        {
            			    	        	PushFollow(FOLLOW_valuereference_in_imports259);
            			    	        	valuereference();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:44: ( ',' ( typereference | valuereference ) )*
            			    	do 
            			    	{
            			    	    int alt18 = 2;
            			    	    int LA18_0 = input.LA(1);
            			    	    
            			    	    if ( (LA18_0 == 79) )
            			    	    {
            			    	        alt18 = 1;
            			    	    }
            			    	    
            			    	
            			    	    switch (alt18) 
            			    		{
            			    			case 1 :
            			    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:45: ',' ( typereference | valuereference )
            			    			    {
            			    			    	Match(input,79,FOLLOW_79_in_imports263); 
            			    			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:49: ( typereference | valuereference )
            			    			    	int alt17 = 2;
            			    			    	int LA17_0 = input.LA(1);
            			    			    	
            			    			    	if ( (LA17_0 == UID) )
            			    			    	{
            			    			    	    alt17 = 1;
            			    			    	}
            			    			    	else if ( (LA17_0 == LID) )
            			    			    	{
            			    			    	    alt17 = 2;
            			    			    	}
            			    			    	else 
            			    			    	{
            			    			    	    NoViableAltException nvae_d17s0 =
            			    			    	        new NoViableAltException("48:49: ( typereference | valuereference )", 17, 0, input);
            			    			    	
            			    			    	    throw nvae_d17s0;
            			    			    	}
            			    			    	switch (alt17) 
            			    			    	{
            			    			    	    case 1 :
            			    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:50: typereference
            			    			    	        {
            			    			    	        	PushFollow(FOLLOW_typereference_in_imports266);
            			    			    	        	typereference();
            			    			    	        	followingStackPointer_--;

            			    			    	        
            			    			    	        }
            			    			    	        break;
            			    			    	    case 2 :
            			    			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:66: valuereference
            			    			    	        {
            			    			    	        	PushFollow(FOLLOW_valuereference_in_imports270);
            			    			    	        	valuereference();
            			    			    	        	followingStackPointer_--;

            			    			    	        
            			    			    	        }
            			    			    	        break;
            			    			    	
            			    			    	}

            			    			    
            			    			    }
            			    			    break;
            			    	
            			    			default:
            			    			    goto loop18;
            			    	    }
            			    	} while (true);
            			    	
            			    	loop18:
            			    		;	// Stops C# compiler whinging that label 'loop18' has no statements

            			    	Match(input,FROM,FOLLOW_FROM_in_imports275); 
            			    	PushFollow(FOLLOW_modulereference_in_imports277);
            			    	modulereference();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:105: ( definitiveIdentifier )?
            			    	int alt19 = 2;
            			    	int LA19_0 = input.LA(1);
            			    	
            			    	if ( (LA19_0 == 74) )
            			    	{
            			    	    alt19 = 1;
            			    	}
            			    	switch (alt19) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:48:105: definitiveIdentifier
            			    	        {
            			    	        	PushFollow(FOLLOW_definitiveIdentifier_in_imports279);
            			    	        	definitiveIdentifier();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop20;
            	    }
            	} while (true);
            	
            	loop20:
            		;	// Stops C# compiler whinging that label 'loop20' has no statements

            	Match(input,78,FOLLOW_78_in_imports285); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:52:1: valueAssigment : valuereference type '::=' value ;
    public void valueAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:4: ( valuereference type '::=' value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:53:4: valuereference type '::=' value
            {
            	PushFollow(FOLLOW_valuereference_in_valueAssigment301);
            	valuereference();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_valueAssigment303);
            	type();
            	followingStackPointer_--;

            	Match(input,73,FOLLOW_73_in_valueAssigment305); 
            	PushFollow(FOLLOW_value_in_valueAssigment307);
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

    
    // $ANTLR start valueSetAssigment
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:56:1: valueSetAssigment : typereference type '::=' '{' g_elementSetSpecs '}' ;
    public void valueSetAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:4: ( typereference type '::=' '{' g_elementSetSpecs '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:57:4: typereference type '::=' '{' g_elementSetSpecs '}'
            {
            	PushFollow(FOLLOW_typereference_in_valueSetAssigment323);
            	typereference();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_valueSetAssigment325);
            	type();
            	followingStackPointer_--;

            	Match(input,73,FOLLOW_73_in_valueSetAssigment327); 
            	Match(input,74,FOLLOW_74_in_valueSetAssigment329); 
            	PushFollow(FOLLOW_g_elementSetSpecs_in_valueSetAssigment331);
            	g_elementSetSpecs();
            	followingStackPointer_--;

            	Match(input,75,FOLLOW_75_in_valueSetAssigment333); 
            
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
    // $ANTLR end valueSetAssigment

    
    // $ANTLR start typeAssigment
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:59:1: typeAssigment : typereference '::=' type ;
    public void typeAssigment() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:4: ( typereference '::=' type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:60:4: typereference '::=' type
            {
            	PushFollow(FOLLOW_typereference_in_typeAssigment346);
            	typereference();
            	followingStackPointer_--;

            	Match(input,73,FOLLOW_73_in_typeAssigment348); 
            	PushFollow(FOLLOW_type_in_typeAssigment350);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:1: type : ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:8: ( ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID )
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )?
            	int alt23 = 2;
            	int LA23_0 = input.LA(1);
            	
            	if ( (LA23_0 == 80) )
            	{
            	    alt23 = 1;
            	}
            	switch (alt23) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:9: '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )?
            	        {
            	        	Match(input,80,FOLLOW_80_in_type362); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:13: ( UNIVERSAL | APPLICATION | PRIVATE )?
            	        	int alt21 = 2;
            	        	int LA21_0 = input.LA(1);
            	        	
            	        	if ( ((LA21_0 >= UNIVERSAL && LA21_0 <= PRIVATE)) )
            	        	{
            	        	    alt21 = 1;
            	        	}
            	        	switch (alt21) 
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
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type364);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,INT,FOLLOW_INT_in_type377); 
            	        	Match(input,81,FOLLOW_81_in_type380); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:59: ( IMPLICIT | EXPLICIT )?
            	        	int alt22 = 2;
            	        	int LA22_0 = input.LA(1);
            	        	
            	        	if ( (LA22_0 == EXPLICIT || LA22_0 == IMPLICIT) )
            	        	{
            	        	    alt22 = 1;
            	        	}
            	        	switch (alt22) 
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
            	        	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_type382);    throw mse;
            	        	        	}

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:64:1: ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID )
            	int alt30 = 15;
            	switch ( input.LA(1) ) 
            	{
            	case NULL:
            		{
            	    alt30 = 1;
            	    }
            	    break;
            	case BIT:
            		{
            	    alt30 = 2;
            	    }
            	    break;
            	case BOOLEAN:
            		{
            	    alt30 = 3;
            	    }
            	    break;
            	case ENUMERATED:
            		{
            	    alt30 = 4;
            	    }
            	    break;
            	case INTEGER:
            		{
            	    alt30 = 5;
            	    }
            	    break;
            	case REAL:
            		{
            	    alt30 = 6;
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
            	    alt30 = 7;
            	    }
            	    break;
            	case UID:
            		{
            	    alt30 = 8;
            	    }
            	    break;
            	case SEQUENCE:
            		{
            	    int LA30_9 = input.LA(2);
            	    
            	    if ( (LA30_9 == 74) )
            	    {
            	        alt30 = 11;
            	    }
            	    else if ( ((LA30_9 >= OF && LA30_9 <= SIZE) || LA30_9 == 76) )
            	    {
            	        alt30 = 9;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d30s9 =
            	            new NoViableAltException("64:1: ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID )", 30, 9, input);
            	    
            	        throw nvae_d30s9;
            	    }
            	    }
            	    break;
            	case CHOICE:
            		{
            	    alt30 = 10;
            	    }
            	    break;
            	case SET:
            		{
            	    int LA30_11 = input.LA(2);
            	    
            	    if ( (LA30_11 == 74) )
            	    {
            	        alt30 = 12;
            	    }
            	    else if ( ((LA30_11 >= OF && LA30_11 <= SIZE) || LA30_11 == 76) )
            	    {
            	        alt30 = 13;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d30s11 =
            	            new NoViableAltException("64:1: ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID )", 30, 11, input);
            	    
            	        throw nvae_d30s11;
            	    }
            	    }
            	    break;
            	case OBJECT:
            		{
            	    alt30 = 14;
            	    }
            	    break;
            	case RELATIVE_OID:
            		{
            	    alt30 = 15;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d30s0 =
            		        new NoViableAltException("64:1: ( NULL | bitStringType | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType | setType | setOfType | objectIdentifier | relativeOID )", 30, 0, input);
            	
            		    throw nvae_d30s0;
            	}
            	
            	switch (alt30) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:3: NULL
            	        {
            	        	Match(input,NULL,FOLLOW_NULL_in_type400); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:3: bitStringType
            	        {
            	        	PushFollow(FOLLOW_bitStringType_in_type404);
            	        	bitStringType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:3: booleanType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_booleanType_in_type408);
            	        	booleanType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:15: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt24 = 2;
            	        	    int LA24_0 = input.LA(1);
            	        	    
            	        	    if ( (LA24_0 == 76) )
            	        	    {
            	        	        alt24 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt24) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:15: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type410);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
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
            	    case 4 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:3: enumeratedType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_enumeratedType_in_type415);
            	        	enumeratedType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:18: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt25 = 2;
            	        	    int LA25_0 = input.LA(1);
            	        	    
            	        	    if ( (LA25_0 == 76) )
            	        	    {
            	        	        alt25 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt25) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:18: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type417);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
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
            	    case 5 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:3: integerType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_integerType_in_type426);
            	        	integerType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:15: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt26 = 2;
            	        	    int LA26_0 = input.LA(1);
            	        	    
            	        	    if ( (LA26_0 == 76) )
            	        	    {
            	        	        alt26 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt26) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:15: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type428);
            	        			    	g_constraint();
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
            	    case 6 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:10: realType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_realType_in_type440);
            	        	realType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:19: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt27 = 2;
            	        	    int LA27_0 = input.LA(1);
            	        	    
            	        	    if ( (LA27_0 == 76) )
            	        	    {
            	        	        alt27 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt27) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:19: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type442);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop27;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop27:
            	        		;	// Stops C# compiler whinging that label 'loop27' has no statements

            	        
            	        }
            	        break;
            	    case 7 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:3: stringType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_stringType_in_type447);
            	        	stringType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:14: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt28 = 2;
            	        	    int LA28_0 = input.LA(1);
            	        	    
            	        	    if ( (LA28_0 == 76) )
            	        	    {
            	        	        alt28 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt28) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:14: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type449);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
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
            	    case 8 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:3: referencedType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_referencedType_in_type454);
            	        	referencedType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:18: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt29 = 2;
            	        	    int LA29_0 = input.LA(1);
            	        	    
            	        	    if ( (LA29_0 == 76) )
            	        	    {
            	        	        alt29 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt29) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:18: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type456);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop29;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop29:
            	        		;	// Stops C# compiler whinging that label 'loop29' has no statements

            	        
            	        }
            	        break;
            	    case 9 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type461);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 10 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:3: choiceType
            	        {
            	        	PushFollow(FOLLOW_choiceType_in_type465);
            	        	choiceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 11 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:10: sequenceType
            	        {
            	        	PushFollow(FOLLOW_sequenceType_in_type476);
            	        	sequenceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 12 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:80:11: setType
            	        {
            	        	PushFollow(FOLLOW_setType_in_type488);
            	        	setType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 13 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:11: setOfType
            	        {
            	        	PushFollow(FOLLOW_setOfType_in_type500);
            	        	setOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 14 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:11: objectIdentifier
            	        {
            	        	PushFollow(FOLLOW_objectIdentifier_in_type512);
            	        	objectIdentifier();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 15 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:83:10: relativeOID
            	        {
            	        	PushFollow(FOLLOW_relativeOID_in_type523);
            	        	relativeOID();
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:88:1: bitStringType : BIT STRING ( '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}' )? ;
    public void bitStringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:4: ( BIT STRING ( '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:4: BIT STRING ( '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}' )?
            {
            	Match(input,BIT,FOLLOW_BIT_in_bitStringType537); 
            	Match(input,STRING,FOLLOW_STRING_in_bitStringType539); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:15: ( '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}' )?
            	int alt35 = 2;
            	int LA35_0 = input.LA(1);
            	
            	if ( (LA35_0 == 74) )
            	{
            	    alt35 = 1;
            	}
            	switch (alt35) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:16: '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}'
            	        {
            	        	Match(input,74,FOLLOW_74_in_bitStringType542); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:20: ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )?
            	        	int alt34 = 2;
            	        	int LA34_0 = input.LA(1);
            	        	
            	        	if ( (LA34_0 == LID) )
            	        	{
            	        	    alt34 = 1;
            	        	}
            	        	switch (alt34) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:21: identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_bitStringType545);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,76,FOLLOW_76_in_bitStringType547); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:36: ( INT | valuereference )
            	        	        	int alt31 = 2;
            	        	        	int LA31_0 = input.LA(1);
            	        	        	
            	        	        	if ( (LA31_0 == INT) )
            	        	        	{
            	        	        	    alt31 = 1;
            	        	        	}
            	        	        	else if ( (LA31_0 == LID) )
            	        	        	{
            	        	        	    alt31 = 2;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    NoViableAltException nvae_d31s0 =
            	        	        	        new NoViableAltException("89:36: ( INT | valuereference )", 31, 0, input);
            	        	        	
            	        	        	    throw nvae_d31s0;
            	        	        	}
            	        	        	switch (alt31) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:37: INT
            	        	        	        {
            	        	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType550); 
            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	    case 2 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:41: valuereference
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_valuereference_in_bitStringType552);
            	        	        	        	valuereference();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	
            	        	        	}

            	        	        	Match(input,77,FOLLOW_77_in_bitStringType555); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:61: ( ',' identifier '(' ( INT | valuereference ) ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt33 = 2;
            	        	        	    int LA33_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA33_0 == 79) )
            	        	        	    {
            	        	        	        alt33 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt33) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:62: ',' identifier '(' ( INT | valuereference ) ')'
            	        	        			    {
            	        	        			    	Match(input,79,FOLLOW_79_in_bitStringType558); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_bitStringType560);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,76,FOLLOW_76_in_bitStringType562); 
            	        	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:81: ( INT | valuereference )
            	        	        			    	int alt32 = 2;
            	        	        			    	int LA32_0 = input.LA(1);
            	        	        			    	
            	        	        			    	if ( (LA32_0 == INT) )
            	        	        			    	{
            	        	        			    	    alt32 = 1;
            	        	        			    	}
            	        	        			    	else if ( (LA32_0 == LID) )
            	        	        			    	{
            	        	        			    	    alt32 = 2;
            	        	        			    	}
            	        	        			    	else 
            	        	        			    	{
            	        	        			    	    NoViableAltException nvae_d32s0 =
            	        	        			    	        new NoViableAltException("89:81: ( INT | valuereference )", 32, 0, input);
            	        	        			    	
            	        	        			    	    throw nvae_d32s0;
            	        	        			    	}
            	        	        			    	switch (alt32) 
            	        	        			    	{
            	        	        			    	    case 1 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:82: INT
            	        	        			    	        {
            	        	        			    	        	Match(input,INT,FOLLOW_INT_in_bitStringType565); 
            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	    case 2 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:86: valuereference
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_valuereference_in_bitStringType567);
            	        	        			    	        	valuereference();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	
            	        	        			    	}

            	        	        			    	Match(input,77,FOLLOW_77_in_bitStringType570); 
            	        	        			    
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

            	        	Match(input,75,FOLLOW_75_in_bitStringType578); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:92:1: booleanType : BOOLEAN ;
    public void booleanType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:93:4: ( BOOLEAN )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:93:4: BOOLEAN
            {
            	Match(input,BOOLEAN,FOLLOW_BOOLEAN_in_booleanType593); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:96:1: enumeratedType : ENUMERATED '{' enumeratedTypeItems ( ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )? )? '}' ;
    public void enumeratedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:4: ( ENUMERATED '{' enumeratedTypeItems ( ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )? )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:4: ENUMERATED '{' enumeratedTypeItems ( ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )? )? '}'
            {
            	Match(input,ENUMERATED,FOLLOW_ENUMERATED_in_enumeratedType606); 
            	Match(input,74,FOLLOW_74_in_enumeratedType608); 
            	PushFollow(FOLLOW_enumeratedTypeItems_in_enumeratedType610);
            	enumeratedTypeItems();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:40: ( ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )? )?
            	int alt38 = 2;
            	int LA38_0 = input.LA(1);
            	
            	if ( (LA38_0 == 79) )
            	{
            	    alt38 = 1;
            	}
            	switch (alt38) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:42: ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_enumeratedType615); 
            	        	Match(input,82,FOLLOW_82_in_enumeratedType617); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:52: ( g_exceptionSpec )?
            	        	int alt36 = 2;
            	        	int LA36_0 = input.LA(1);
            	        	
            	        	if ( (LA36_0 == 90) )
            	        	{
            	        	    alt36 = 1;
            	        	}
            	        	switch (alt36) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:52: g_exceptionSpec
            	        	        {
            	        	        	PushFollow(FOLLOW_g_exceptionSpec_in_enumeratedType619);
            	        	        	g_exceptionSpec();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:69: ( ',' enumeratedTypeItems )?
            	        	int alt37 = 2;
            	        	int LA37_0 = input.LA(1);
            	        	
            	        	if ( (LA37_0 == 79) )
            	        	{
            	        	    alt37 = 1;
            	        	}
            	        	switch (alt37) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:70: ',' enumeratedTypeItems
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_enumeratedType623); 
            	        	        	PushFollow(FOLLOW_enumeratedTypeItems_in_enumeratedType625);
            	        	        	enumeratedTypeItems();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_enumeratedType632); 
            
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

    
    // $ANTLR start enumeratedTypeItems
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:100:1: enumeratedTypeItems : identifier ( '(' ( signedNumber | valuereference ) ')' )? ( ',' identifier ( '(' ( signedNumber | valuereference ) ')' )? )* ;
    public void enumeratedTypeItems() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:4: ( identifier ( '(' ( signedNumber | valuereference ) ')' )? ( ',' identifier ( '(' ( signedNumber | valuereference ) ')' )? )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:4: identifier ( '(' ( signedNumber | valuereference ) ')' )? ( ',' identifier ( '(' ( signedNumber | valuereference ) ')' )? )*
            {
            	PushFollow(FOLLOW_identifier_in_enumeratedTypeItems644);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:15: ( '(' ( signedNumber | valuereference ) ')' )?
            	int alt40 = 2;
            	int LA40_0 = input.LA(1);
            	
            	if ( (LA40_0 == 76) )
            	{
            	    alt40 = 1;
            	}
            	switch (alt40) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:17: '(' ( signedNumber | valuereference ) ')'
            	        {
            	        	Match(input,76,FOLLOW_76_in_enumeratedTypeItems648); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:21: ( signedNumber | valuereference )
            	        	int alt39 = 2;
            	        	int LA39_0 = input.LA(1);
            	        	
            	        	if ( (LA39_0 == INT || (LA39_0 >= 86 && LA39_0 <= 87)) )
            	        	{
            	        	    alt39 = 1;
            	        	}
            	        	else if ( (LA39_0 == LID) )
            	        	{
            	        	    alt39 = 2;
            	        	}
            	        	else 
            	        	{
            	        	    NoViableAltException nvae_d39s0 =
            	        	        new NoViableAltException("101:21: ( signedNumber | valuereference )", 39, 0, input);
            	        	
            	        	    throw nvae_d39s0;
            	        	}
            	        	switch (alt39) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:22: signedNumber
            	        	        {
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedTypeItems651);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:35: valuereference
            	        	        {
            	        	        	PushFollow(FOLLOW_valuereference_in_enumeratedTypeItems653);
            	        	        	valuereference();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,77,FOLLOW_77_in_enumeratedTypeItems656); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:57: ( ',' identifier ( '(' ( signedNumber | valuereference ) ')' )? )*
            	do 
            	{
            	    int alt43 = 2;
            	    int LA43_0 = input.LA(1);
            	    
            	    if ( (LA43_0 == 79) )
            	    {
            	        int LA43_1 = input.LA(2);
            	        
            	        if ( (LA43_1 == LID) )
            	        {
            	            alt43 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt43) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:58: ',' identifier ( '(' ( signedNumber | valuereference ) ')' )?
            			    {
            			    	Match(input,79,FOLLOW_79_in_enumeratedTypeItems661); 
            			    	PushFollow(FOLLOW_identifier_in_enumeratedTypeItems663);
            			    	identifier();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:73: ( '(' ( signedNumber | valuereference ) ')' )?
            			    	int alt42 = 2;
            			    	int LA42_0 = input.LA(1);
            			    	
            			    	if ( (LA42_0 == 76) )
            			    	{
            			    	    alt42 = 1;
            			    	}
            			    	switch (alt42) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:75: '(' ( signedNumber | valuereference ) ')'
            			    	        {
            			    	        	Match(input,76,FOLLOW_76_in_enumeratedTypeItems667); 
            			    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:79: ( signedNumber | valuereference )
            			    	        	int alt41 = 2;
            			    	        	int LA41_0 = input.LA(1);
            			    	        	
            			    	        	if ( (LA41_0 == INT || (LA41_0 >= 86 && LA41_0 <= 87)) )
            			    	        	{
            			    	        	    alt41 = 1;
            			    	        	}
            			    	        	else if ( (LA41_0 == LID) )
            			    	        	{
            			    	        	    alt41 = 2;
            			    	        	}
            			    	        	else 
            			    	        	{
            			    	        	    NoViableAltException nvae_d41s0 =
            			    	        	        new NoViableAltException("101:79: ( signedNumber | valuereference )", 41, 0, input);
            			    	        	
            			    	        	    throw nvae_d41s0;
            			    	        	}
            			    	        	switch (alt41) 
            			    	        	{
            			    	        	    case 1 :
            			    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:80: signedNumber
            			    	        	        {
            			    	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedTypeItems670);
            			    	        	        	signedNumber();
            			    	        	        	followingStackPointer_--;

            			    	        	        
            			    	        	        }
            			    	        	        break;
            			    	        	    case 2 :
            			    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:93: valuereference
            			    	        	        {
            			    	        	        	PushFollow(FOLLOW_valuereference_in_enumeratedTypeItems672);
            			    	        	        	valuereference();
            			    	        	        	followingStackPointer_--;

            			    	        	        
            			    	        	        }
            			    	        	        break;
            			    	        	
            			    	        	}

            			    	        	Match(input,77,FOLLOW_77_in_enumeratedTypeItems675); 
            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop43;
            	    }
            	} while (true);
            	
            	loop43:
            		;	// Stops C# compiler whinging that label 'loop43' has no statements

            
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
    // $ANTLR end enumeratedTypeItems

    
    // $ANTLR start integerType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:104:1: integerType : INTEGER ( '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}' )? ;
    public void integerType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:4: ( INTEGER ( '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}' )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:4: INTEGER ( '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}' )?
            {
            	Match(input,INTEGER,FOLLOW_INTEGER_in_integerType692); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:12: ( '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}' )?
            	int alt48 = 2;
            	int LA48_0 = input.LA(1);
            	
            	if ( (LA48_0 == 74) )
            	{
            	    alt48 = 1;
            	}
            	switch (alt48) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:14: '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}'
            	        {
            	        	Match(input,74,FOLLOW_74_in_integerType696); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:18: ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )?
            	        	int alt47 = 2;
            	        	int LA47_0 = input.LA(1);
            	        	
            	        	if ( (LA47_0 == LID) )
            	        	{
            	        	    alt47 = 1;
            	        	}
            	        	switch (alt47) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:19: identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_integerType699);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,76,FOLLOW_76_in_integerType701); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:34: ( signedNumber | valuereference )
            	        	        	int alt44 = 2;
            	        	        	int LA44_0 = input.LA(1);
            	        	        	
            	        	        	if ( (LA44_0 == INT || (LA44_0 >= 86 && LA44_0 <= 87)) )
            	        	        	{
            	        	        	    alt44 = 1;
            	        	        	}
            	        	        	else if ( (LA44_0 == LID) )
            	        	        	{
            	        	        	    alt44 = 2;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    NoViableAltException nvae_d44s0 =
            	        	        	        new NoViableAltException("105:34: ( signedNumber | valuereference )", 44, 0, input);
            	        	        	
            	        	        	    throw nvae_d44s0;
            	        	        	}
            	        	        	switch (alt44) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:35: signedNumber
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_signedNumber_in_integerType704);
            	        	        	        	signedNumber();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	    case 2 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:48: valuereference
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_valuereference_in_integerType706);
            	        	        	        	valuereference();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	
            	        	        	}

            	        	        	Match(input,77,FOLLOW_77_in_integerType709); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:68: ( ',' identifier '(' ( signedNumber | valuereference ) ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt46 = 2;
            	        	        	    int LA46_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA46_0 == 79) )
            	        	        	    {
            	        	        	        alt46 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt46) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:69: ',' identifier '(' ( signedNumber | valuereference ) ')'
            	        	        			    {
            	        	        			    	Match(input,79,FOLLOW_79_in_integerType712); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_integerType714);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,76,FOLLOW_76_in_integerType716); 
            	        	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:88: ( signedNumber | valuereference )
            	        	        			    	int alt45 = 2;
            	        	        			    	int LA45_0 = input.LA(1);
            	        	        			    	
            	        	        			    	if ( (LA45_0 == INT || (LA45_0 >= 86 && LA45_0 <= 87)) )
            	        	        			    	{
            	        	        			    	    alt45 = 1;
            	        	        			    	}
            	        	        			    	else if ( (LA45_0 == LID) )
            	        	        			    	{
            	        	        			    	    alt45 = 2;
            	        	        			    	}
            	        	        			    	else 
            	        	        			    	{
            	        	        			    	    NoViableAltException nvae_d45s0 =
            	        	        			    	        new NoViableAltException("105:88: ( signedNumber | valuereference )", 45, 0, input);
            	        	        			    	
            	        	        			    	    throw nvae_d45s0;
            	        	        			    	}
            	        	        			    	switch (alt45) 
            	        	        			    	{
            	        	        			    	    case 1 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:89: signedNumber
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_signedNumber_in_integerType719);
            	        	        			    	        	signedNumber();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	    case 2 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:102: valuereference
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_valuereference_in_integerType721);
            	        	        			    	        	valuereference();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	
            	        	        			    	}

            	        	        			    	Match(input,77,FOLLOW_77_in_integerType724); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop46;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop46:
            	        	        		;	// Stops C# compiler whinging that label 'loop46' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,75,FOLLOW_75_in_integerType730); 
            	        
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:108:1: realType : REAL ;
    public void realType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:109:4: ( REAL )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:109:4: REAL
            {
            	Match(input,REAL,FOLLOW_REAL_in_realType745); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:120:1: choiceType : CHOICE '{' choiceList ( ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )? )? '}' ;
    public void choiceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:4: ( CHOICE '{' choiceList ( ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )? )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:4: CHOICE '{' choiceList ( ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )? )? '}'
            {
            	Match(input,CHOICE,FOLLOW_CHOICE_in_choiceType762); 
            	Match(input,74,FOLLOW_74_in_choiceType764); 
            	PushFollow(FOLLOW_choiceList_in_choiceType766);
            	choiceList();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:26: ( ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )? )?
            	int alt52 = 2;
            	int LA52_0 = input.LA(1);
            	
            	if ( (LA52_0 == 79) )
            	{
            	    alt52 = 1;
            	}
            	switch (alt52) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:27: ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_choiceType769); 
            	        	Match(input,82,FOLLOW_82_in_choiceType771); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:37: ( g_exceptionSpec )?
            	        	int alt49 = 2;
            	        	int LA49_0 = input.LA(1);
            	        	
            	        	if ( (LA49_0 == 90) )
            	        	{
            	        	    alt49 = 1;
            	        	}
            	        	switch (alt49) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:37: g_exceptionSpec
            	        	        {
            	        	        	PushFollow(FOLLOW_g_exceptionSpec_in_choiceType773);
            	        	        	g_exceptionSpec();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:55: ( choiceListExtension )?
            	        	int alt50 = 2;
            	        	int LA50_0 = input.LA(1);
            	        	
            	        	if ( (LA50_0 == 79) )
            	        	{
            	        	    int LA50_1 = input.LA(2);
            	        	    
            	        	    if ( (LA50_1 == LID || LA50_1 == 83) )
            	        	    {
            	        	        alt50 = 1;
            	        	    }
            	        	}
            	        	switch (alt50) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:55: choiceListExtension
            	        	        {
            	        	        	PushFollow(FOLLOW_choiceListExtension_in_choiceType777);
            	        	        	choiceListExtension();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:78: ( ',' '...' )?
            	        	int alt51 = 2;
            	        	int LA51_0 = input.LA(1);
            	        	
            	        	if ( (LA51_0 == 79) )
            	        	{
            	        	    alt51 = 1;
            	        	}
            	        	switch (alt51) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:79: ',' '...'
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_choiceType783); 
            	        	        	Match(input,82,FOLLOW_82_in_choiceType785); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_choiceType793); 
            
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

    
    // $ANTLR start choiceList
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:124:1: choiceList : identifier type ( ',' identifier type )* ;
    public void choiceList() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:4: ( identifier type ( ',' identifier type )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:4: identifier type ( ',' identifier type )*
            {
            	PushFollow(FOLLOW_identifier_in_choiceList804);
            	identifier();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_choiceList806);
            	type();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:20: ( ',' identifier type )*
            	do 
            	{
            	    int alt53 = 2;
            	    int LA53_0 = input.LA(1);
            	    
            	    if ( (LA53_0 == 79) )
            	    {
            	        int LA53_1 = input.LA(2);
            	        
            	        if ( (LA53_1 == LID) )
            	        {
            	            alt53 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt53) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:21: ',' identifier type
            			    {
            			    	Match(input,79,FOLLOW_79_in_choiceList809); 
            			    	PushFollow(FOLLOW_identifier_in_choiceList811);
            			    	identifier();
            			    	followingStackPointer_--;

            			    	PushFollow(FOLLOW_type_in_choiceList813);
            			    	type();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop53;
            	    }
            	} while (true);
            	
            	loop53:
            		;	// Stops C# compiler whinging that label 'loop53' has no statements

            
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
    // $ANTLR end choiceList

    
    // $ANTLR start choiceListExtension
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:128:1: choiceListExtension : ',' extensionAdditionAlternative ( ',' extensionAdditionAlternative )* ;
    public void choiceListExtension() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:4: ( ',' extensionAdditionAlternative ( ',' extensionAdditionAlternative )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:4: ',' extensionAdditionAlternative ( ',' extensionAdditionAlternative )*
            {
            	Match(input,79,FOLLOW_79_in_choiceListExtension826); 
            	PushFollow(FOLLOW_extensionAdditionAlternative_in_choiceListExtension828);
            	extensionAdditionAlternative();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:37: ( ',' extensionAdditionAlternative )*
            	do 
            	{
            	    int alt54 = 2;
            	    int LA54_0 = input.LA(1);
            	    
            	    if ( (LA54_0 == 79) )
            	    {
            	        int LA54_1 = input.LA(2);
            	        
            	        if ( (LA54_1 == LID || LA54_1 == 83) )
            	        {
            	            alt54 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt54) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:38: ',' extensionAdditionAlternative
            			    {
            			    	Match(input,79,FOLLOW_79_in_choiceListExtension831); 
            			    	PushFollow(FOLLOW_extensionAdditionAlternative_in_choiceListExtension833);
            			    	extensionAdditionAlternative();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop54;
            	    }
            	} while (true);
            	
            	loop54:
            		;	// Stops C# compiler whinging that label 'loop54' has no statements

            
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
    // $ANTLR end choiceListExtension

    
    // $ANTLR start extensionAdditionAlternative
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:131:1: extensionAdditionAlternative : ( '[[' ( versionNumber )? choiceList ']]' | identifier type );
    public void extensionAdditionAlternative() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:5: ( '[[' ( versionNumber )? choiceList ']]' | identifier type )
            int alt56 = 2;
            int LA56_0 = input.LA(1);
            
            if ( (LA56_0 == 83) )
            {
                alt56 = 1;
            }
            else if ( (LA56_0 == LID) )
            {
                alt56 = 2;
            }
            else 
            {
                NoViableAltException nvae_d56s0 =
                    new NoViableAltException("131:1: extensionAdditionAlternative : ( '[[' ( versionNumber )? choiceList ']]' | identifier type );", 56, 0, input);
            
                throw nvae_d56s0;
            }
            switch (alt56) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:5: '[[' ( versionNumber )? choiceList ']]'
                    {
                    	Match(input,83,FOLLOW_83_in_extensionAdditionAlternative847); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:10: ( versionNumber )?
                    	int alt55 = 2;
                    	int LA55_0 = input.LA(1);
                    	
                    	if ( (LA55_0 == INT) )
                    	{
                    	    alt55 = 1;
                    	}
                    	switch (alt55) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:10: versionNumber
                    	        {
                    	        	PushFollow(FOLLOW_versionNumber_in_extensionAdditionAlternative849);
                    	        	versionNumber();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_choiceList_in_extensionAdditionAlternative852);
                    	choiceList();
                    	followingStackPointer_--;

                    	Match(input,84,FOLLOW_84_in_extensionAdditionAlternative854); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:133:5: identifier type
                    {
                    	PushFollow(FOLLOW_identifier_in_extensionAdditionAlternative860);
                    	identifier();
                    	followingStackPointer_--;

                    	PushFollow(FOLLOW_type_in_extensionAdditionAlternative862);
                    	type();
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
    // $ANTLR end extensionAdditionAlternative

    
    // $ANTLR start sequenceType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:136:1: sequenceType : SEQUENCE '{' ( sequenceOrSetBody )? '}' ;
    public void sequenceType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:4: ( SEQUENCE '{' ( sequenceOrSetBody )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:4: SEQUENCE '{' ( sequenceOrSetBody )? '}'
            {
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceType874); 
            	Match(input,74,FOLLOW_74_in_sequenceType876); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:17: ( sequenceOrSetBody )?
            	int alt57 = 2;
            	int LA57_0 = input.LA(1);
            	
            	if ( (LA57_0 == LID || LA57_0 == 82) )
            	{
            	    alt57 = 1;
            	}
            	switch (alt57) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:17: sequenceOrSetBody
            	        {
            	        	PushFollow(FOLLOW_sequenceOrSetBody_in_sequenceType878);
            	        	sequenceOrSetBody();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_sequenceType882); 
            
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

    
    // $ANTLR start setType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:1: setType : SET '{' ( sequenceOrSetBody )? '}' ;
    public void setType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:11: ( SET '{' ( sequenceOrSetBody )? '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:11: SET '{' ( sequenceOrSetBody )? '}'
            {
            	Match(input,SET,FOLLOW_SET_in_setType894); 
            	Match(input,74,FOLLOW_74_in_setType896); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:19: ( sequenceOrSetBody )?
            	int alt58 = 2;
            	int LA58_0 = input.LA(1);
            	
            	if ( (LA58_0 == LID || LA58_0 == 82) )
            	{
            	    alt58 = 1;
            	}
            	switch (alt58) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:19: sequenceOrSetBody
            	        {
            	        	PushFollow(FOLLOW_sequenceOrSetBody_in_setType898);
            	        	sequenceOrSetBody();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_setType902); 
            
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
    // $ANTLR end setType

    
    // $ANTLR start sequenceOrSetBody
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:143:1: sequenceOrSetBody : ( componentTypeList ( ',' seqOrSetExtBody )? | seqOrSetExtBody );
    public void sequenceOrSetBody() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:5: ( componentTypeList ( ',' seqOrSetExtBody )? | seqOrSetExtBody )
            int alt60 = 2;
            int LA60_0 = input.LA(1);
            
            if ( (LA60_0 == LID) )
            {
                alt60 = 1;
            }
            else if ( (LA60_0 == 82) )
            {
                alt60 = 2;
            }
            else 
            {
                NoViableAltException nvae_d60s0 =
                    new NoViableAltException("143:1: sequenceOrSetBody : ( componentTypeList ( ',' seqOrSetExtBody )? | seqOrSetExtBody );", 60, 0, input);
            
                throw nvae_d60s0;
            }
            switch (alt60) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:5: componentTypeList ( ',' seqOrSetExtBody )?
                    {
                    	PushFollow(FOLLOW_componentTypeList_in_sequenceOrSetBody919);
                    	componentTypeList();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:23: ( ',' seqOrSetExtBody )?
                    	int alt59 = 2;
                    	int LA59_0 = input.LA(1);
                    	
                    	if ( (LA59_0 == 79) )
                    	{
                    	    alt59 = 1;
                    	}
                    	switch (alt59) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:25: ',' seqOrSetExtBody
                    	        {
                    	        	Match(input,79,FOLLOW_79_in_sequenceOrSetBody923); 
                    	        	PushFollow(FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody925);
                    	        	seqOrSetExtBody();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:145:5: seqOrSetExtBody
                    {
                    	PushFollow(FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody933);
                    	seqOrSetExtBody();
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
    // $ANTLR end sequenceOrSetBody

    
    // $ANTLR start seqOrSetExtBody
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:148:1: seqOrSetExtBody : '...' ( g_exceptionSpec )? ( ',' extensionAdditionList )? ( ',' '...' ( ',' componentTypeList )? )? ;
    public void seqOrSetExtBody() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:4: ( '...' ( g_exceptionSpec )? ( ',' extensionAdditionList )? ( ',' '...' ( ',' componentTypeList )? )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:4: '...' ( g_exceptionSpec )? ( ',' extensionAdditionList )? ( ',' '...' ( ',' componentTypeList )? )?
            {
            	Match(input,82,FOLLOW_82_in_seqOrSetExtBody945); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:10: ( g_exceptionSpec )?
            	int alt61 = 2;
            	int LA61_0 = input.LA(1);
            	
            	if ( (LA61_0 == 90) )
            	{
            	    alt61 = 1;
            	}
            	switch (alt61) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:10: g_exceptionSpec
            	        {
            	        	PushFollow(FOLLOW_g_exceptionSpec_in_seqOrSetExtBody947);
            	        	g_exceptionSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:27: ( ',' extensionAdditionList )?
            	int alt62 = 2;
            	int LA62_0 = input.LA(1);
            	
            	if ( (LA62_0 == 79) )
            	{
            	    int LA62_1 = input.LA(2);
            	    
            	    if ( (LA62_1 == LID || LA62_1 == 83) )
            	    {
            	        alt62 = 1;
            	    }
            	}
            	switch (alt62) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:28: ',' extensionAdditionList
            	        {
            	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody951); 
            	        	PushFollow(FOLLOW_extensionAdditionList_in_seqOrSetExtBody953);
            	        	extensionAdditionList();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:56: ( ',' '...' ( ',' componentTypeList )? )?
            	int alt64 = 2;
            	int LA64_0 = input.LA(1);
            	
            	if ( (LA64_0 == 79) )
            	{
            	    alt64 = 1;
            	}
            	switch (alt64) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:57: ',' '...' ( ',' componentTypeList )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody958); 
            	        	Match(input,82,FOLLOW_82_in_seqOrSetExtBody960); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:69: ( ',' componentTypeList )?
            	        	int alt63 = 2;
            	        	int LA63_0 = input.LA(1);
            	        	
            	        	if ( (LA63_0 == 79) )
            	        	{
            	        	    alt63 = 1;
            	        	}
            	        	switch (alt63) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:70: ',' componentTypeList
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody965); 
            	        	        	PushFollow(FOLLOW_componentTypeList_in_seqOrSetExtBody967);
            	        	        	componentTypeList();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
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
    // $ANTLR end seqOrSetExtBody

    
    // $ANTLR start extensionAdditionList
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:152:1: extensionAdditionList : extensionAddition ( ',' extensionAddition )* ;
    public void extensionAdditionList() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:4: ( extensionAddition ( ',' extensionAddition )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:4: extensionAddition ( ',' extensionAddition )*
            {
            	PushFollow(FOLLOW_extensionAddition_in_extensionAdditionList986);
            	extensionAddition();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:22: ( ',' extensionAddition )*
            	do 
            	{
            	    int alt65 = 2;
            	    int LA65_0 = input.LA(1);
            	    
            	    if ( (LA65_0 == 79) )
            	    {
            	        int LA65_1 = input.LA(2);
            	        
            	        if ( (LA65_1 == LID || LA65_1 == 83) )
            	        {
            	            alt65 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt65) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:23: ',' extensionAddition
            			    {
            			    	Match(input,79,FOLLOW_79_in_extensionAdditionList989); 
            			    	PushFollow(FOLLOW_extensionAddition_in_extensionAdditionList991);
            			    	extensionAddition();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop65;
            	    }
            	} while (true);
            	
            	loop65:
            		;	// Stops C# compiler whinging that label 'loop65' has no statements

            
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
    // $ANTLR end extensionAdditionList

    
    // $ANTLR start extensionAddition
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:1: extensionAddition : ( componentType | extensionAdditionGroup );
    public void extensionAddition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:157:4: ( componentType | extensionAdditionGroup )
            int alt66 = 2;
            int LA66_0 = input.LA(1);
            
            if ( (LA66_0 == LID) )
            {
                alt66 = 1;
            }
            else if ( (LA66_0 == 83) )
            {
                alt66 = 2;
            }
            else 
            {
                NoViableAltException nvae_d66s0 =
                    new NoViableAltException("156:1: extensionAddition : ( componentType | extensionAdditionGroup );", 66, 0, input);
            
                throw nvae_d66s0;
            }
            switch (alt66) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:157:4: componentType
                    {
                    	PushFollow(FOLLOW_componentType_in_extensionAddition1005);
                    	componentType();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:158:10: extensionAdditionGroup
                    {
                    	PushFollow(FOLLOW_extensionAdditionGroup_in_extensionAddition1016);
                    	extensionAdditionGroup();
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
    // $ANTLR end extensionAddition

    
    // $ANTLR start extensionAdditionGroup
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:160:1: extensionAdditionGroup : '[[' ( versionNumber )? componentTypeList ']]' ;
    public void extensionAdditionGroup() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:4: ( '[[' ( versionNumber )? componentTypeList ']]' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:4: '[[' ( versionNumber )? componentTypeList ']]'
            {
            	Match(input,83,FOLLOW_83_in_extensionAdditionGroup1026); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:9: ( versionNumber )?
            	int alt67 = 2;
            	int LA67_0 = input.LA(1);
            	
            	if ( (LA67_0 == INT) )
            	{
            	    alt67 = 1;
            	}
            	switch (alt67) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:9: versionNumber
            	        {
            	        	PushFollow(FOLLOW_versionNumber_in_extensionAdditionGroup1028);
            	        	versionNumber();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_componentTypeList_in_extensionAdditionGroup1031);
            	componentTypeList();
            	followingStackPointer_--;

            	Match(input,84,FOLLOW_84_in_extensionAdditionGroup1033); 
            
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
    // $ANTLR end extensionAdditionGroup

    
    // $ANTLR start componentTypeList
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:164:1: componentTypeList : componentType ( ',' componentType )* ;
    public void componentTypeList() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:4: ( componentType ( ',' componentType )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:4: componentType ( ',' componentType )*
            {
            	PushFollow(FOLLOW_componentType_in_componentTypeList1045);
            	componentType();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:19: ( ',' componentType )*
            	do 
            	{
            	    int alt68 = 2;
            	    int LA68_0 = input.LA(1);
            	    
            	    if ( (LA68_0 == 79) )
            	    {
            	        int LA68_1 = input.LA(2);
            	        
            	        if ( (LA68_1 == LID) )
            	        {
            	            alt68 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt68) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:20: ',' componentType
            			    {
            			    	Match(input,79,FOLLOW_79_in_componentTypeList1049); 
            			    	PushFollow(FOLLOW_componentType_in_componentTypeList1051);
            			    	componentType();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop68;
            	    }
            	} while (true);
            	
            	loop68:
            		;	// Stops C# compiler whinging that label 'loop68' has no statements

            
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
    // $ANTLR end componentTypeList

    
    // $ANTLR start componentType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:168:1: componentType : identifier type ( OPTIONAL | DEFAULT value )? ;
    public void componentType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:4: ( identifier type ( OPTIONAL | DEFAULT value )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:4: identifier type ( OPTIONAL | DEFAULT value )?
            {
            	PushFollow(FOLLOW_identifier_in_componentType1066);
            	identifier();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_componentType1068);
            	type();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:20: ( OPTIONAL | DEFAULT value )?
            	int alt69 = 3;
            	int LA69_0 = input.LA(1);
            	
            	if ( (LA69_0 == OPTIONAL) )
            	{
            	    alt69 = 1;
            	}
            	else if ( (LA69_0 == DEFAULT) )
            	{
            	    alt69 = 2;
            	}
            	switch (alt69) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:21: OPTIONAL
            	        {
            	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_componentType1071); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:32: DEFAULT value
            	        {
            	        	Match(input,DEFAULT,FOLLOW_DEFAULT_in_componentType1075); 
            	        	PushFollow(FOLLOW_value_in_componentType1077);
            	        	value();
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
    // $ANTLR end componentType

    
    // $ANTLR start sequenceOfType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF type | SEQUENCE SIZE valueConstraint OF type );
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:4: ( SEQUENCE ( sizeConstraint )? OF type | SEQUENCE SIZE valueConstraint OF type )
            int alt71 = 2;
            int LA71_0 = input.LA(1);
            
            if ( (LA71_0 == SEQUENCE) )
            {
                int LA71_1 = input.LA(2);
                
                if ( (LA71_1 == SIZE) )
                {
                    alt71 = 2;
                }
                else if ( (LA71_1 == OF || LA71_1 == 76) )
                {
                    alt71 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d71s1 =
                        new NoViableAltException("172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF type | SEQUENCE SIZE valueConstraint OF type );", 71, 1, input);
                
                    throw nvae_d71s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d71s0 =
                    new NoViableAltException("172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF type | SEQUENCE SIZE valueConstraint OF type );", 71, 0, input);
            
                throw nvae_d71s0;
            }
            switch (alt71) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:4: SEQUENCE ( sizeConstraint )? OF type
                    {
                    	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType1092); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:13: ( sizeConstraint )?
                    	int alt70 = 2;
                    	int LA70_0 = input.LA(1);
                    	
                    	if ( (LA70_0 == 76) )
                    	{
                    	    alt70 = 1;
                    	}
                    	switch (alt70) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:13: sizeConstraint
                    	        {
                    	        	PushFollow(FOLLOW_sizeConstraint_in_sequenceOfType1094);
                    	        	sizeConstraint();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,OF,FOLLOW_OF_in_sequenceOfType1097); 
                    	PushFollow(FOLLOW_type_in_sequenceOfType1099);
                    	type();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:4: SEQUENCE SIZE valueConstraint OF type
                    {
                    	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType1104); 
                    	Match(input,SIZE,FOLLOW_SIZE_in_sequenceOfType1106); 
                    	PushFollow(FOLLOW_valueConstraint_in_sequenceOfType1108);
                    	valueConstraint();
                    	followingStackPointer_--;

                    	Match(input,OF,FOLLOW_OF_in_sequenceOfType1110); 
                    	PushFollow(FOLLOW_type_in_sequenceOfType1112);
                    	type();
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
    // $ANTLR end sequenceOfType

    
    // $ANTLR start setOfType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:177:1: setOfType : ( SET ( sizeConstraint )? OF type | SET SIZE valueConstraint OF type );
    public void setOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:4: ( SET ( sizeConstraint )? OF type | SET SIZE valueConstraint OF type )
            int alt73 = 2;
            int LA73_0 = input.LA(1);
            
            if ( (LA73_0 == SET) )
            {
                int LA73_1 = input.LA(2);
                
                if ( (LA73_1 == SIZE) )
                {
                    alt73 = 2;
                }
                else if ( (LA73_1 == OF || LA73_1 == 76) )
                {
                    alt73 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d73s1 =
                        new NoViableAltException("177:1: setOfType : ( SET ( sizeConstraint )? OF type | SET SIZE valueConstraint OF type );", 73, 1, input);
                
                    throw nvae_d73s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d73s0 =
                    new NoViableAltException("177:1: setOfType : ( SET ( sizeConstraint )? OF type | SET SIZE valueConstraint OF type );", 73, 0, input);
            
                throw nvae_d73s0;
            }
            switch (alt73) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:4: SET ( sizeConstraint )? OF type
                    {
                    	Match(input,SET,FOLLOW_SET_in_setOfType1124); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:8: ( sizeConstraint )?
                    	int alt72 = 2;
                    	int LA72_0 = input.LA(1);
                    	
                    	if ( (LA72_0 == 76) )
                    	{
                    	    alt72 = 1;
                    	}
                    	switch (alt72) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:8: sizeConstraint
                    	        {
                    	        	PushFollow(FOLLOW_sizeConstraint_in_setOfType1126);
                    	        	sizeConstraint();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,OF,FOLLOW_OF_in_setOfType1129); 
                    	PushFollow(FOLLOW_type_in_setOfType1131);
                    	type();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:179:4: SET SIZE valueConstraint OF type
                    {
                    	Match(input,SET,FOLLOW_SET_in_setOfType1136); 
                    	Match(input,SIZE,FOLLOW_SIZE_in_setOfType1138); 
                    	PushFollow(FOLLOW_valueConstraint_in_setOfType1140);
                    	valueConstraint();
                    	followingStackPointer_--;

                    	Match(input,OF,FOLLOW_OF_in_setOfType1142); 
                    	PushFollow(FOLLOW_type_in_setOfType1144);
                    	type();
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
    // $ANTLR end setOfType

    
    // $ANTLR start stringType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:183:1: stringType : ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String );
    public void stringType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:184:3: ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String )
            int alt74 = 12;
            switch ( input.LA(1) ) 
            {
            case OCTET:
            	{
                alt74 = 1;
                }
                break;
            case NumericString:
            	{
                alt74 = 2;
                }
                break;
            case PrintableString:
            	{
                alt74 = 3;
                }
                break;
            case VisibleString:
            	{
                alt74 = 4;
                }
                break;
            case IA5String:
            	{
                alt74 = 5;
                }
                break;
            case TeletexString:
            	{
                alt74 = 6;
                }
                break;
            case VideotexString:
            	{
                alt74 = 7;
                }
                break;
            case GraphicString:
            	{
                alt74 = 8;
                }
                break;
            case GeneralString:
            	{
                alt74 = 9;
                }
                break;
            case UniversalString:
            	{
                alt74 = 10;
                }
                break;
            case BMPString:
            	{
                alt74 = 11;
                }
                break;
            case UTF8String:
            	{
                alt74 = 12;
                }
                break;
            	default:
            	    NoViableAltException nvae_d74s0 =
            	        new NoViableAltException("183:1: stringType : ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String );", 74, 0, input);
            
            	    throw nvae_d74s0;
            }
            
            switch (alt74) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:184:3: OCTET STRING
                    {
                    	Match(input,OCTET,FOLLOW_OCTET_in_stringType1160); 
                    	Match(input,STRING,FOLLOW_STRING_in_stringType1162); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:3: NumericString
                    {
                    	Match(input,NumericString,FOLLOW_NumericString_in_stringType1166); 
                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:3: PrintableString
                    {
                    	Match(input,PrintableString,FOLLOW_PrintableString_in_stringType1170); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:187:3: VisibleString
                    {
                    	Match(input,VisibleString,FOLLOW_VisibleString_in_stringType1174); 
                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:188:3: IA5String
                    {
                    	Match(input,IA5String,FOLLOW_IA5String_in_stringType1178); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:3: TeletexString
                    {
                    	Match(input,TeletexString,FOLLOW_TeletexString_in_stringType1182); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:3: VideotexString
                    {
                    	Match(input,VideotexString,FOLLOW_VideotexString_in_stringType1186); 
                    
                    }
                    break;
                case 8 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:191:3: GraphicString
                    {
                    	Match(input,GraphicString,FOLLOW_GraphicString_in_stringType1190); 
                    
                    }
                    break;
                case 9 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:192:3: GeneralString
                    {
                    	Match(input,GeneralString,FOLLOW_GeneralString_in_stringType1194); 
                    
                    }
                    break;
                case 10 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:193:3: UniversalString
                    {
                    	Match(input,UniversalString,FOLLOW_UniversalString_in_stringType1198); 
                    
                    }
                    break;
                case 11 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:194:3: BMPString
                    {
                    	Match(input,BMPString,FOLLOW_BMPString_in_stringType1202); 
                    
                    }
                    break;
                case 12 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:195:3: UTF8String
                    {
                    	Match(input,UTF8String,FOLLOW_UTF8String_in_stringType1206); 
                    
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

    
    // $ANTLR start referencedType
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:198:1: referencedType : UID ( '.' UID )? ;
    public void referencedType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:4: ( UID ( '.' UID )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:4: UID ( '.' UID )?
            {
            	Match(input,UID,FOLLOW_UID_in_referencedType1218); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:8: ( '.' UID )?
            	int alt75 = 2;
            	int LA75_0 = input.LA(1);
            	
            	if ( (LA75_0 == 85) )
            	{
            	    alt75 = 1;
            	}
            	switch (alt75) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:9: '.' UID
            	        {
            	        	Match(input,85,FOLLOW_85_in_referencedType1221); 
            	        	Match(input,UID,FOLLOW_UID_in_referencedType1223); 
            	        
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
    // $ANTLR end referencedType

    
    // $ANTLR start objectIdentifier
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:202:1: objectIdentifier : OBJECT IDENTIFIER ;
    public void objectIdentifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:203:4: ( OBJECT IDENTIFIER )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:203:4: OBJECT IDENTIFIER
            {
            	Match(input,OBJECT,FOLLOW_OBJECT_in_objectIdentifier1237); 
            	Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_objectIdentifier1239); 
            
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
    // $ANTLR end objectIdentifier

    
    // $ANTLR start relativeOID
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:205:1: relativeOID : RELATIVE_OID ;
    public void relativeOID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:205:15: ( RELATIVE_OID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:205:15: RELATIVE_OID
            {
            	Match(input,RELATIVE_OID,FOLLOW_RELATIVE_OID_in_relativeOID1247); 
            
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
    // $ANTLR end relativeOID

    
    // $ANTLR start signedNumber
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:208:1: signedNumber : ( '+' | '-' )? INT ;
    public void signedNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:209:4: ( ( '+' | '-' )? INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:209:4: ( '+' | '-' )? INT
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:209:4: ( '+' | '-' )?
            	int alt76 = 2;
            	int LA76_0 = input.LA(1);
            	
            	if ( ((LA76_0 >= 86 && LA76_0 <= 87)) )
            	{
            	    alt76 = 1;
            	}
            	switch (alt76) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
            	        {
            	        	if ( (input.LA(1) >= 86 && input.LA(1) <= 87) ) 
            	        	{
            	        	    input.Consume();
            	        	    errorRecovery = false;
            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse =
            	        	        new MismatchedSetException(null,input);
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber1258);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber1265); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:212:1: constraint : ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint );
    public void constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:213:4: ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint )
            int alt77 = 4;
            int LA77_0 = input.LA(1);
            
            if ( (LA77_0 == 76) )
            {
                switch ( input.LA(2) ) 
                {
                case WITH:
                	{
                    alt77 = 3;
                    }
                    break;
                case SIZE:
                	{
                    alt77 = 2;
                    }
                    break;
                case NULL:
                case BIT:
                case BOOLEAN:
                case ENUMERATED:
                case INTEGER:
                case REAL:
                case CHOICE:
                case SEQUENCE:
                case SET:
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
                case UID:
                case OBJECT:
                case RELATIVE_OID:
                case 80:
                	{
                    alt77 = 4;
                    }
                    break;
                case INT:
                case BitStringLiteral:
                case OctectStringLiteral:
                case TRUE:
                case FALSE:
                case StringLiteral:
                case MIN:
                case MAX:
                case LID:
                case 74:
                case 86:
                case 87:
                	{
                    alt77 = 1;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d77s1 =
                	        new NoViableAltException("212:1: constraint : ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint );", 77, 1, input);
                
                	    throw nvae_d77s1;
                }
            
            }
            else 
            {
                NoViableAltException nvae_d77s0 =
                    new NoViableAltException("212:1: constraint : ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint );", 77, 0, input);
            
                throw nvae_d77s0;
            }
            switch (alt77) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:213:4: valueConstraint
                    {
                    	PushFollow(FOLLOW_valueConstraint_in_constraint1276);
                    	valueConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:214:4: sizeConstraint
                    {
                    	PushFollow(FOLLOW_sizeConstraint_in_constraint1281);
                    	sizeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:215:4: withComponentsConstraint
                    {
                    	PushFollow(FOLLOW_withComponentsConstraint_in_constraint1286);
                    	withComponentsConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:216:4: subTypeConstraint
                    {
                    	PushFollow(FOLLOW_subTypeConstraint_in_constraint1291);
                    	subTypeConstraint();
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

    
    // $ANTLR start valueConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:221:1: valueConstraint : '(' value ( ( '<' )? '..' ( '<' )? value )? ')' ;
    public void valueConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:4: ( '(' value ( ( '<' )? '..' ( '<' )? value )? ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:4: '(' value ( ( '<' )? '..' ( '<' )? value )? ')'
            {
            	Match(input,76,FOLLOW_76_in_valueConstraint1307); 
            	PushFollow(FOLLOW_value_in_valueConstraint1309);
            	value();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:14: ( ( '<' )? '..' ( '<' )? value )?
            	int alt80 = 2;
            	int LA80_0 = input.LA(1);
            	
            	if ( ((LA80_0 >= 88 && LA80_0 <= 89)) )
            	{
            	    alt80 = 1;
            	}
            	switch (alt80) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:16: ( '<' )? '..' ( '<' )? value
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:16: ( '<' )?
            	        	int alt78 = 2;
            	        	int LA78_0 = input.LA(1);
            	        	
            	        	if ( (LA78_0 == 88) )
            	        	{
            	        	    alt78 = 1;
            	        	}
            	        	switch (alt78) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:17: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_valueConstraint1314); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,89,FOLLOW_89_in_valueConstraint1318); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:28: ( '<' )?
            	        	int alt79 = 2;
            	        	int LA79_0 = input.LA(1);
            	        	
            	        	if ( (LA79_0 == 88) )
            	        	{
            	        	    alt79 = 1;
            	        	}
            	        	switch (alt79) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:29: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_valueConstraint1321); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	PushFollow(FOLLOW_value_in_valueConstraint1325);
            	        	value();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,77,FOLLOW_77_in_valueConstraint1329); 
            
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
    // $ANTLR end valueConstraint

    
    // $ANTLR start sizeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:225:1: sizeConstraint : '(' SIZE valueConstraint ')' ;
    public void sizeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:226:4: ( '(' SIZE valueConstraint ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:226:4: '(' SIZE valueConstraint ')'
            {
            	Match(input,76,FOLLOW_76_in_sizeConstraint1340); 
            	Match(input,SIZE,FOLLOW_SIZE_in_sizeConstraint1342); 
            	PushFollow(FOLLOW_valueConstraint_in_sizeConstraint1344);
            	valueConstraint();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_sizeConstraint1346); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:229:1: permittedAlphabetConstraint : '(' FROM valueConstraint ')' ;
    public void permittedAlphabetConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:230:4: ( '(' FROM valueConstraint ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:230:4: '(' FROM valueConstraint ')'
            {
            	Match(input,76,FOLLOW_76_in_permittedAlphabetConstraint1359); 
            	Match(input,FROM,FOLLOW_FROM_in_permittedAlphabetConstraint1361); 
            	PushFollow(FOLLOW_valueConstraint_in_permittedAlphabetConstraint1363);
            	valueConstraint();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_permittedAlphabetConstraint1365); 
            
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

    
    // $ANTLR start subTypeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:233:1: subTypeConstraint : '(' type ')' ;
    public void subTypeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:234:4: ( '(' type ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:234:4: '(' type ')'
            {
            	Match(input,76,FOLLOW_76_in_subTypeConstraint1378); 
            	PushFollow(FOLLOW_type_in_subTypeConstraint1380);
            	type();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_subTypeConstraint1382); 
            
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
    // $ANTLR end subTypeConstraint

    
    // $ANTLR start withComponentsConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:237:1: withComponentsConstraint : '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')' ;
    public void withComponentsConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:238:4: ( '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:238:4: '(' WITH COMPONENTS '{' ( '...' ',' )? namedConstraint ( ',' namedConstraint )* '}' ')'
            {
            	Match(input,76,FOLLOW_76_in_withComponentsConstraint1397); 
            	Match(input,WITH,FOLLOW_WITH_in_withComponentsConstraint1400); 
            	Match(input,COMPONENTS,FOLLOW_COMPONENTS_in_withComponentsConstraint1402); 
            	Match(input,74,FOLLOW_74_in_withComponentsConstraint1404); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:4: ( '...' ',' )?
            	int alt81 = 2;
            	int LA81_0 = input.LA(1);
            	
            	if ( (LA81_0 == 82) )
            	{
            	    alt81 = 1;
            	}
            	switch (alt81) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:6: '...' ','
            	        {
            	        	Match(input,82,FOLLOW_82_in_withComponentsConstraint1411); 
            	        	Match(input,79,FOLLOW_79_in_withComponentsConstraint1413); 
            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint1420);
            	namedConstraint();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:21: ( ',' namedConstraint )*
            	do 
            	{
            	    int alt82 = 2;
            	    int LA82_0 = input.LA(1);
            	    
            	    if ( (LA82_0 == 79) )
            	    {
            	        alt82 = 1;
            	    }
            	    
            	
            	    switch (alt82) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:22: ',' namedConstraint
            			    {
            			    	Match(input,79,FOLLOW_79_in_withComponentsConstraint1424); 
            			    	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint1426);
            			    	namedConstraint();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop82;
            	    }
            	} while (true);
            	
            	loop82:
            		;	// Stops C# compiler whinging that label 'loop82' has no statements

            	Match(input,75,FOLLOW_75_in_withComponentsConstraint1432); 
            	Match(input,77,FOLLOW_77_in_withComponentsConstraint1436); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:245:1: namedConstraint : identifier ( valueConstraint )? ( PRESENT | ABSENT | OPTIONAL )? ;
    public void namedConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:4: ( identifier ( valueConstraint )? ( PRESENT | ABSENT | OPTIONAL )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:4: identifier ( valueConstraint )? ( PRESENT | ABSENT | OPTIONAL )?
            {
            	PushFollow(FOLLOW_identifier_in_namedConstraint1448);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:15: ( valueConstraint )?
            	int alt83 = 2;
            	int LA83_0 = input.LA(1);
            	
            	if ( (LA83_0 == 76) )
            	{
            	    alt83 = 1;
            	}
            	switch (alt83) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:16: valueConstraint
            	        {
            	        	PushFollow(FOLLOW_valueConstraint_in_namedConstraint1451);
            	        	valueConstraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:34: ( PRESENT | ABSENT | OPTIONAL )?
            	int alt84 = 2;
            	int LA84_0 = input.LA(1);
            	
            	if ( (LA84_0 == OPTIONAL || (LA84_0 >= PRESENT && LA84_0 <= ABSENT)) )
            	{
            	    alt84 = 1;
            	}
            	switch (alt84) 
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
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_namedConstraint1455);    throw mse;
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:3: ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX )
            int alt88 = 10;
            switch ( input.LA(1) ) 
            {
            case BitStringLiteral:
            	{
                alt88 = 1;
                }
                break;
            case 74:
            	{
                alt88 = 2;
                }
                break;
            case OctectStringLiteral:
            	{
                alt88 = 3;
                }
                break;
            case TRUE:
            	{
                alt88 = 4;
                }
                break;
            case FALSE:
            	{
                alt88 = 5;
                }
                break;
            case StringLiteral:
            	{
                alt88 = 6;
                }
                break;
            case LID:
            	{
                alt88 = 7;
                }
                break;
            case INT:
            case 86:
            case 87:
            	{
                alt88 = 8;
                }
                break;
            case MIN:
            	{
                alt88 = 9;
                }
                break;
            case MAX:
            	{
                alt88 = 10;
                }
                break;
            	default:
            	    NoViableAltException nvae_d88s0 =
            	        new NoViableAltException("248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX );", 88, 0, input);
            
            	    throw nvae_d88s0;
            }
            
            switch (alt88) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:3: BitStringLiteral
                    {
                    	Match(input,BitStringLiteral,FOLLOW_BitStringLiteral_in_value1475); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:250:4: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value1480);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:4: OctectStringLiteral
                    {
                    	Match(input,OctectStringLiteral,FOLLOW_OctectStringLiteral_in_value1485); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:252:4: TRUE
                    {
                    	Match(input,TRUE,FOLLOW_TRUE_in_value1490); 
                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:253:4: FALSE
                    {
                    	Match(input,FALSE,FOLLOW_FALSE_in_value1495); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:254:4: StringLiteral
                    {
                    	Match(input,StringLiteral,FOLLOW_StringLiteral_in_value1500); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:4: valuereference
                    {
                    	PushFollow(FOLLOW_valuereference_in_value1505);
                    	valuereference();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 8 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:4: ( '+' | '-' )?
                    	int alt85 = 2;
                    	int LA85_0 = input.LA(1);
                    	
                    	if ( ((LA85_0 >= 86 && LA85_0 <= 87)) )
                    	{
                    	    alt85 = 1;
                    	}
                    	switch (alt85) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:
                    	        {
                    	        	if ( (input.LA(1) >= 86 && input.LA(1) <= 87) ) 
                    	        	{
                    	        	    input.Consume();
                    	        	    errorRecovery = false;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    MismatchedSetException mse =
                    	        	        new MismatchedSetException(null,input);
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value1512);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value1519); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:19: ( '.' ( INT )? )?
                    	int alt87 = 2;
                    	int LA87_0 = input.LA(1);
                    	
                    	if ( (LA87_0 == 85) )
                    	{
                    	    alt87 = 1;
                    	}
                    	switch (alt87) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:20: '.' ( INT )?
                    	        {
                    	        	Match(input,85,FOLLOW_85_in_value1522); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:24: ( INT )?
                    	        	int alt86 = 2;
                    	        	int LA86_0 = input.LA(1);
                    	        	
                    	        	if ( (LA86_0 == INT) )
                    	        	{
                    	        	    alt86 = 1;
                    	        	}
                    	        	switch (alt86) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value1524); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 9 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:258:4: MIN
                    {
                    	Match(input,MIN,FOLLOW_MIN_in_value1534); 
                    
                    }
                    break;
                case 10 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:259:4: MAX
                    {
                    	Match(input,MAX,FOLLOW_MAX_in_value1539); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:262:1: bitStringValue : '{' identifier ( ',' identifier )* '}' ;
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:263:4: ( '{' identifier ( ',' identifier )* '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:263:4: '{' identifier ( ',' identifier )* '}'
            {
            	Match(input,74,FOLLOW_74_in_bitStringValue1552); 
            	PushFollow(FOLLOW_identifier_in_bitStringValue1554);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:263:19: ( ',' identifier )*
            	do 
            	{
            	    int alt89 = 2;
            	    int LA89_0 = input.LA(1);
            	    
            	    if ( (LA89_0 == 79) )
            	    {
            	        alt89 = 1;
            	    }
            	    
            	
            	    switch (alt89) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:263:20: ',' identifier
            			    {
            			    	Match(input,79,FOLLOW_79_in_bitStringValue1557); 
            			    	PushFollow(FOLLOW_identifier_in_bitStringValue1559);
            			    	identifier();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop89;
            	    }
            	} while (true);
            	
            	loop89:
            		;	// Stops C# compiler whinging that label 'loop89' has no statements

            	Match(input,75,FOLLOW_75_in_bitStringValue1563); 
            
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

    
    // $ANTLR start lID
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:1: lID : LID ;
    public void lID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:7: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:7: LID
            {
            	Match(input,LID,FOLLOW_LID_in_lID1576); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:269:1: modulereference : UID ;
    public void modulereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:269:19: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:269:19: UID
            {
            	Match(input,UID,FOLLOW_UID_in_modulereference1584); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:1: typereference : UID ;
    public void typereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:17: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:17: UID
            {
            	Match(input,UID,FOLLOW_UID_in_typereference1592); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:273:1: valuereference : LID ;
    public void valuereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:273:19: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:273:19: LID
            {
            	Match(input,LID,FOLLOW_LID_in_valuereference1602); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:1: identifier : LID ;
    public void identifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:14: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:275:14: LID
            {
            	Match(input,LID,FOLLOW_LID_in_identifier1612); 
            
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

    
    // $ANTLR start versionNumber
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:277:1: versionNumber : INT ;
    public void versionNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:277:17: ( INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:277:17: INT
            {
            	Match(input,INT,FOLLOW_INT_in_versionNumber1620); 
            
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
    // $ANTLR end versionNumber

    
    // $ANTLR start g_constraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:285:1: g_constraint : '(' g_subtypeConstraint ( g_exceptionSpec )? ')' ;
    public void g_constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:4: ( '(' g_subtypeConstraint ( g_exceptionSpec )? ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:4: '(' g_subtypeConstraint ( g_exceptionSpec )? ')'
            {
            	Match(input,76,FOLLOW_76_in_g_constraint1640); 
            	PushFollow(FOLLOW_g_subtypeConstraint_in_g_constraint1642);
            	g_subtypeConstraint();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:29: ( g_exceptionSpec )?
            	int alt90 = 2;
            	int LA90_0 = input.LA(1);
            	
            	if ( (LA90_0 == 90) )
            	{
            	    alt90 = 1;
            	}
            	switch (alt90) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:29: g_exceptionSpec
            	        {
            	        	PushFollow(FOLLOW_g_exceptionSpec_in_g_constraint1645);
            	        	g_exceptionSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,77,FOLLOW_77_in_g_constraint1648); 
            
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
    // $ANTLR end g_constraint

    
    // $ANTLR start g_exceptionSpec
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:289:1: g_exceptionSpec : '!' ( signedNumber | valuereference | type ':' value ) ;
    public void g_exceptionSpec() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:4: ( '!' ( signedNumber | valuereference | type ':' value ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:4: '!' ( signedNumber | valuereference | type ':' value )
            {
            	Match(input,90,FOLLOW_90_in_g_exceptionSpec1660); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:291:2: ( signedNumber | valuereference | type ':' value )
            	int alt91 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case INT:
            	case 86:
            	case 87:
            		{
            	    alt91 = 1;
            	    }
            	    break;
            	case LID:
            		{
            	    alt91 = 2;
            	    }
            	    break;
            	case NULL:
            	case BIT:
            	case BOOLEAN:
            	case ENUMERATED:
            	case INTEGER:
            	case REAL:
            	case CHOICE:
            	case SEQUENCE:
            	case SET:
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
            	case UID:
            	case OBJECT:
            	case RELATIVE_OID:
            	case 80:
            		{
            	    alt91 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d91s0 =
            		        new NoViableAltException("291:2: ( signedNumber | valuereference | type ':' value )", 91, 0, input);
            	
            		    throw nvae_d91s0;
            	}
            	
            	switch (alt91) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:292:4: signedNumber
            	        {
            	        	PushFollow(FOLLOW_signedNumber_in_g_exceptionSpec1669);
            	        	signedNumber();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:293:4: valuereference
            	        {
            	        	PushFollow(FOLLOW_valuereference_in_g_exceptionSpec1674);
            	        	valuereference();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:294:6: type ':' value
            	        {
            	        	PushFollow(FOLLOW_type_in_g_exceptionSpec1681);
            	        	type();
            	        	followingStackPointer_--;

            	        	Match(input,91,FOLLOW_91_in_g_exceptionSpec1683); 
            	        	PushFollow(FOLLOW_value_in_g_exceptionSpec1685);
            	        	value();
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
    // $ANTLR end g_exceptionSpec

    
    // $ANTLR start g_subtypeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:299:1: g_subtypeConstraint : g_elementSetSpecs ;
    public void g_subtypeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:300:4: ( g_elementSetSpecs )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:300:4: g_elementSetSpecs
            {
            	PushFollow(FOLLOW_g_elementSetSpecs_in_g_subtypeConstraint1700);
            	g_elementSetSpecs();
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
    // $ANTLR end g_subtypeConstraint

    
    // $ANTLR start g_elementSetSpecs
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:302:1: g_elementSetSpecs : g_unionElement ( ',' '...' ( ',' g_unionElement )? )? ;
    public void g_elementSetSpecs() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:4: ( g_unionElement ( ',' '...' ( ',' g_unionElement )? )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:4: g_unionElement ( ',' '...' ( ',' g_unionElement )? )?
            {
            	PushFollow(FOLLOW_g_unionElement_in_g_elementSetSpecs1709);
            	g_unionElement();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:19: ( ',' '...' ( ',' g_unionElement )? )?
            	int alt93 = 2;
            	int LA93_0 = input.LA(1);
            	
            	if ( (LA93_0 == 79) )
            	{
            	    alt93 = 1;
            	}
            	switch (alt93) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:20: ',' '...' ( ',' g_unionElement )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_g_elementSetSpecs1712); 
            	        	Match(input,82,FOLLOW_82_in_g_elementSetSpecs1714); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:30: ( ',' g_unionElement )?
            	        	int alt92 = 2;
            	        	int LA92_0 = input.LA(1);
            	        	
            	        	if ( (LA92_0 == 79) )
            	        	{
            	        	    alt92 = 1;
            	        	}
            	        	switch (alt92) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:303:32: ',' g_unionElement
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_g_elementSetSpecs1718); 
            	        	        	PushFollow(FOLLOW_g_unionElement_in_g_elementSetSpecs1720);
            	        	        	g_unionElement();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
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
    // $ANTLR end g_elementSetSpecs

    
    // $ANTLR start g_unionElement
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:305:1: g_unionElement : ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec );
    public void g_unionElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:4: ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec )
            int alt95 = 2;
            int LA95_0 = input.LA(1);
            
            if ( (LA95_0 == INT || LA95_0 == FROM || (LA95_0 >= NULL && LA95_0 <= BIT) || (LA95_0 >= BOOLEAN && LA95_0 <= SET) || (LA95_0 >= SIZE && LA95_0 <= OBJECT) || (LA95_0 >= RELATIVE_OID && LA95_0 <= WITH) || (LA95_0 >= BitStringLiteral && LA95_0 <= LID) || LA95_0 == INCLUDES || LA95_0 == PATTERN || LA95_0 == 74 || LA95_0 == 76 || LA95_0 == 80 || (LA95_0 >= 86 && LA95_0 <= 87)) )
            {
                alt95 = 1;
            }
            else if ( (LA95_0 == ALL) )
            {
                alt95 = 2;
            }
            else 
            {
                NoViableAltException nvae_d95s0 =
                    new NoViableAltException("305:1: g_unionElement : ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec );", 95, 0, input);
            
                throw nvae_d95s0;
            }
            switch (alt95) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:4: g_intersectionElement ( UnionMark g_intersectionElement )*
                    {
                    	PushFollow(FOLLOW_g_intersectionElement_in_g_unionElement1734);
                    	g_intersectionElement();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:26: ( UnionMark g_intersectionElement )*
                    	do 
                    	{
                    	    int alt94 = 2;
                    	    int LA94_0 = input.LA(1);
                    	    
                    	    if ( (LA94_0 == UnionMark) )
                    	    {
                    	        alt94 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt94) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:27: UnionMark g_intersectionElement
                    			    {
                    			    	Match(input,UnionMark,FOLLOW_UnionMark_in_g_unionElement1737); 
                    			    	PushFollow(FOLLOW_g_intersectionElement_in_g_unionElement1739);
                    			    	g_intersectionElement();
                    			    	followingStackPointer_--;

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop94;
                    	    }
                    	} while (true);
                    	
                    	loop94:
                    		;	// Stops C# compiler whinging that label 'loop94' has no statements

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:307:4: ALL EXCEPT g_elementSetSpec
                    {
                    	Match(input,ALL,FOLLOW_ALL_in_g_unionElement1746); 
                    	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_unionElement1748); 
                    	PushFollow(FOLLOW_g_elementSetSpec_in_g_unionElement1750);
                    	g_elementSetSpec();
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
    // $ANTLR end g_unionElement

    
    // $ANTLR start g_intersectionElement
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:310:1: g_intersectionElement : g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )* ;
    public void g_intersectionElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:4: ( g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:4: g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )*
            {
            	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1763);
            	g_elementSetSpec();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:21: ( EXCEPT g_elementSetSpec )?
            	int alt96 = 2;
            	int LA96_0 = input.LA(1);
            	
            	if ( (LA96_0 == EXCEPT) )
            	{
            	    alt96 = 1;
            	}
            	switch (alt96) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:22: EXCEPT g_elementSetSpec
            	        {
            	        	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_intersectionElement1766); 
            	        	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1768);
            	        	g_elementSetSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:48: ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )*
            	do 
            	{
            	    int alt98 = 2;
            	    int LA98_0 = input.LA(1);
            	    
            	    if ( (LA98_0 == IntersectionMark) )
            	    {
            	        alt98 = 1;
            	    }
            	    
            	
            	    switch (alt98) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:49: IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )?
            			    {
            			    	Match(input,IntersectionMark,FOLLOW_IntersectionMark_in_g_intersectionElement1773); 
            			    	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1775);
            			    	g_elementSetSpec();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:83: ( EXCEPT g_elementSetSpec )?
            			    	int alt97 = 2;
            			    	int LA97_0 = input.LA(1);
            			    	
            			    	if ( (LA97_0 == EXCEPT) )
            			    	{
            			    	    alt97 = 1;
            			    	}
            			    	switch (alt97) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:311:84: EXCEPT g_elementSetSpec
            			    	        {
            			    	        	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_intersectionElement1778); 
            			    	        	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1780);
            			    	        	g_elementSetSpec();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop98;
            	    }
            	} while (true);
            	
            	loop98:
            		;	// Stops C# compiler whinging that label 'loop98' has no statements

            
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
    // $ANTLR end g_intersectionElement

    
    // $ANTLR start g_elementSetSpec
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:314:1: g_elementSetSpec : ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' );
    public void g_elementSetSpec() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:4: ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' )
            int alt99 = 7;
            switch ( input.LA(1) ) 
            {
            case INT:
            case BitStringLiteral:
            case OctectStringLiteral:
            case TRUE:
            case FALSE:
            case StringLiteral:
            case MIN:
            case MAX:
            case LID:
            case 74:
            case 86:
            case 87:
            	{
                alt99 = 1;
                }
                break;
            case NULL:
            case BIT:
            case BOOLEAN:
            case ENUMERATED:
            case INTEGER:
            case REAL:
            case CHOICE:
            case SEQUENCE:
            case SET:
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
            case UID:
            case OBJECT:
            case RELATIVE_OID:
            case INCLUDES:
            case 80:
            	{
                alt99 = 2;
                }
                break;
            case SIZE:
            	{
                alt99 = 3;
                }
                break;
            case FROM:
            	{
                alt99 = 4;
                }
                break;
            case WITH:
            	{
                alt99 = 5;
                }
                break;
            case PATTERN:
            	{
                alt99 = 6;
                }
                break;
            case 76:
            	{
                alt99 = 7;
                }
                break;
            	default:
            	    NoViableAltException nvae_d99s0 =
            	        new NoViableAltException("314:1: g_elementSetSpec : ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' );", 99, 0, input);
            
            	    throw nvae_d99s0;
            }
            
            switch (alt99) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:4: g_valueElement
                    {
                    	PushFollow(FOLLOW_g_valueElement_in_g_elementSetSpec1796);
                    	g_valueElement();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:316:4: g_containedSubtype
                    {
                    	PushFollow(FOLLOW_g_containedSubtype_in_g_elementSetSpec1801);
                    	g_containedSubtype();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:317:4: g_SizeConstraint
                    {
                    	PushFollow(FOLLOW_g_SizeConstraint_in_g_elementSetSpec1806);
                    	g_SizeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:4: g_permittedAlphabet
                    {
                    	PushFollow(FOLLOW_g_permittedAlphabet_in_g_elementSetSpec1811);
                    	g_permittedAlphabet();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:319:4: g_innerTypeConstraints
                    {
                    	PushFollow(FOLLOW_g_innerTypeConstraints_in_g_elementSetSpec1816);
                    	g_innerTypeConstraints();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:320:4: g_patternConstraint
                    {
                    	PushFollow(FOLLOW_g_patternConstraint_in_g_elementSetSpec1821);
                    	g_patternConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:4: '(' g_elementSetSpecs ')'
                    {
                    	Match(input,76,FOLLOW_76_in_g_elementSetSpec1826); 
                    	PushFollow(FOLLOW_g_elementSetSpecs_in_g_elementSetSpec1828);
                    	g_elementSetSpecs();
                    	followingStackPointer_--;

                    	Match(input,77,FOLLOW_77_in_g_elementSetSpec1830); 
                    
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
    // $ANTLR end g_elementSetSpec

    
    // $ANTLR start g_valueElement
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:324:1: g_valueElement : value ( ( '<' )? '..' ( '<' )? value )? ;
    public void g_valueElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:4: ( value ( ( '<' )? '..' ( '<' )? value )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:4: value ( ( '<' )? '..' ( '<' )? value )?
            {
            	PushFollow(FOLLOW_value_in_g_valueElement1843);
            	value();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:10: ( ( '<' )? '..' ( '<' )? value )?
            	int alt102 = 2;
            	int LA102_0 = input.LA(1);
            	
            	if ( ((LA102_0 >= 88 && LA102_0 <= 89)) )
            	{
            	    alt102 = 1;
            	}
            	switch (alt102) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:12: ( '<' )? '..' ( '<' )? value
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:12: ( '<' )?
            	        	int alt100 = 2;
            	        	int LA100_0 = input.LA(1);
            	        	
            	        	if ( (LA100_0 == 88) )
            	        	{
            	        	    alt100 = 1;
            	        	}
            	        	switch (alt100) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:13: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_g_valueElement1848); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,89,FOLLOW_89_in_g_valueElement1852); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:24: ( '<' )?
            	        	int alt101 = 2;
            	        	int LA101_0 = input.LA(1);
            	        	
            	        	if ( (LA101_0 == 88) )
            	        	{
            	        	    alt101 = 1;
            	        	}
            	        	switch (alt101) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:25: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_g_valueElement1855); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	PushFollow(FOLLOW_value_in_g_valueElement1859);
            	        	value();
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
    // $ANTLR end g_valueElement

    
    // $ANTLR start g_containedSubtype
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:1: g_containedSubtype : ( INCLUDES )? type ;
    public void g_containedSubtype() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:21: ( ( INCLUDES )? type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:21: ( INCLUDES )? type
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:21: ( INCLUDES )?
            	int alt103 = 2;
            	int LA103_0 = input.LA(1);
            	
            	if ( (LA103_0 == INCLUDES) )
            	{
            	    alt103 = 1;
            	}
            	switch (alt103) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:327:21: INCLUDES
            	        {
            	        	Match(input,INCLUDES,FOLLOW_INCLUDES_in_g_containedSubtype1870); 
            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_type_in_g_containedSubtype1873);
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
    // $ANTLR end g_containedSubtype

    
    // $ANTLR start g_SizeConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:329:1: g_SizeConstraint : SIZE g_constraint ;
    public void g_SizeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:329:20: ( SIZE g_constraint )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:329:20: SIZE g_constraint
            {
            	Match(input,SIZE,FOLLOW_SIZE_in_g_SizeConstraint1881); 
            	PushFollow(FOLLOW_g_constraint_in_g_SizeConstraint1883);
            	g_constraint();
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
    // $ANTLR end g_SizeConstraint

    
    // $ANTLR start g_permittedAlphabet
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:1: g_permittedAlphabet : FROM g_constraint ;
    public void g_permittedAlphabet() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:23: ( FROM g_constraint )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:23: FROM g_constraint
            {
            	Match(input,FROM,FOLLOW_FROM_in_g_permittedAlphabet1891); 
            	PushFollow(FOLLOW_g_constraint_in_g_permittedAlphabet1893);
            	g_constraint();
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
    // $ANTLR end g_permittedAlphabet

    
    // $ANTLR start g_innerTypeConstraints
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:333:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );
    public void g_innerTypeConstraints() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:334:4: ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' )
            int alt106 = 2;
            int LA106_0 = input.LA(1);
            
            if ( (LA106_0 == WITH) )
            {
                int LA106_1 = input.LA(2);
                
                if ( (LA106_1 == COMPONENTS) )
                {
                    alt106 = 2;
                }
                else if ( (LA106_1 == COMPONENT) )
                {
                    alt106 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d106s1 =
                        new NoViableAltException("333:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );", 106, 1, input);
                
                    throw nvae_d106s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d106s0 =
                    new NoViableAltException("333:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );", 106, 0, input);
            
                throw nvae_d106s0;
            }
            switch (alt106) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:334:4: WITH COMPONENT g_constraint
                    {
                    	Match(input,WITH,FOLLOW_WITH_in_g_innerTypeConstraints1903); 
                    	Match(input,COMPONENT,FOLLOW_COMPONENT_in_g_innerTypeConstraints1905); 
                    	PushFollow(FOLLOW_g_constraint_in_g_innerTypeConstraints1907);
                    	g_constraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:4: WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}'
                    {
                    	Match(input,WITH,FOLLOW_WITH_in_g_innerTypeConstraints1912); 
                    	Match(input,COMPONENTS,FOLLOW_COMPONENTS_in_g_innerTypeConstraints1914); 
                    	Match(input,74,FOLLOW_74_in_g_innerTypeConstraints1916); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:336:4: ( '...' ',' )?
                    	int alt104 = 2;
                    	int LA104_0 = input.LA(1);
                    	
                    	if ( (LA104_0 == 82) )
                    	{
                    	    alt104 = 1;
                    	}
                    	switch (alt104) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:336:6: '...' ','
                    	        {
                    	        	Match(input,82,FOLLOW_82_in_g_innerTypeConstraints1923); 
                    	        	Match(input,79,FOLLOW_79_in_g_innerTypeConstraints1925); 
                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_g_namedConstraint_in_g_innerTypeConstraints1932);
                    	g_namedConstraint();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:337:23: ( ',' g_namedConstraint )*
                    	do 
                    	{
                    	    int alt105 = 2;
                    	    int LA105_0 = input.LA(1);
                    	    
                    	    if ( (LA105_0 == 79) )
                    	    {
                    	        alt105 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt105) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:337:24: ',' g_namedConstraint
                    			    {
                    			    	Match(input,79,FOLLOW_79_in_g_innerTypeConstraints1936); 
                    			    	PushFollow(FOLLOW_g_namedConstraint_in_g_innerTypeConstraints1938);
                    			    	g_namedConstraint();
                    			    	followingStackPointer_--;

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop105;
                    	    }
                    	} while (true);
                    	
                    	loop105:
                    		;	// Stops C# compiler whinging that label 'loop105' has no statements

                    	Match(input,75,FOLLOW_75_in_g_innerTypeConstraints1944); 
                    
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
    // $ANTLR end g_innerTypeConstraints

    
    // $ANTLR start g_namedConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:1: g_namedConstraint : identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )? ;
    public void g_namedConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:343:4: ( identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:343:4: identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )?
            {
            	PushFollow(FOLLOW_identifier_in_g_namedConstraint1956);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:343:15: ( g_constraint )?
            	int alt107 = 2;
            	int LA107_0 = input.LA(1);
            	
            	if ( (LA107_0 == 76) )
            	{
            	    alt107 = 1;
            	}
            	switch (alt107) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:343:16: g_constraint
            	        {
            	        	PushFollow(FOLLOW_g_constraint_in_g_namedConstraint1959);
            	        	g_constraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:343:31: ( PRESENT | ABSENT | OPTIONAL )?
            	int alt108 = 2;
            	int LA108_0 = input.LA(1);
            	
            	if ( (LA108_0 == OPTIONAL || (LA108_0 >= PRESENT && LA108_0 <= ABSENT)) )
            	{
            	    alt108 = 1;
            	}
            	switch (alt108) 
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
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_g_namedConstraint1963);    throw mse;
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
    // $ANTLR end g_namedConstraint

    
    // $ANTLR start g_patternConstraint
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:345:1: g_patternConstraint : PATTERN value ;
    public void g_patternConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:345:23: ( PATTERN value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:345:23: PATTERN value
            {
            	Match(input,PATTERN,FOLLOW_PATTERN_in_g_patternConstraint1981); 
            	PushFollow(FOLLOW_value_in_g_patternConstraint1983);
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
    // $ANTLR end g_patternConstraint


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_moduleDefinition_in_moduleDefinitions35 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_modulereference_in_moduleDefinition46 = new BitSet(new ulong[]{0x0000000000000010UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_definitiveIdentifier_in_moduleDefinition48 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_DEFINITIONS_in_moduleDefinition54 = new BitSet(new ulong[]{0x00000000000003A0UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_EXPLICIT_in_moduleDefinition60 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition62 = new BitSet(new ulong[]{0x0000000000000200UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_IMPLICIT_in_moduleDefinition66 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition68 = new BitSet(new ulong[]{0x0000000000000200UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_AUTOMATIC_in_moduleDefinition72 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_TAGS_in_moduleDefinition74 = new BitSet(new ulong[]{0x0000000000000200UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_EXTENSIBILITY_in_moduleDefinition82 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_IMPLIED_in_moduleDefinition84 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_moduleDefinition91 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_BEGIN_in_moduleDefinition93 = new BitSet(new ulong[]{0x4000800000015000UL});
    public static readonly BitSet FOLLOW_exports_in_moduleDefinition99 = new BitSet(new ulong[]{0x4000800000011000UL});
    public static readonly BitSet FOLLOW_imports_in_moduleDefinition107 = new BitSet(new ulong[]{0x4000800000001000UL});
    public static readonly BitSet FOLLOW_typeAssigment_in_moduleDefinition120 = new BitSet(new ulong[]{0x4000800000001000UL});
    public static readonly BitSet FOLLOW_valueAssigment_in_moduleDefinition127 = new BitSet(new ulong[]{0x4000800000001000UL});
    public static readonly BitSet FOLLOW_valueSetAssigment_in_moduleDefinition134 = new BitSet(new ulong[]{0x4000800000001000UL});
    public static readonly BitSet FOLLOW_END_in_moduleDefinition145 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_74_in_definitiveIdentifier153 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_definitiveObjIdComponent_in_definitiveIdentifier155 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_definitiveIdentifier158 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_definitiveObjIdComponent171 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_definitiveObjIdComponent175 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent177 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_definitiveObjIdComponent179 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_definitiveObjIdComponent187 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports202 = new BitSet(new ulong[]{0x0000000000008000UL});
    public static readonly BitSet FOLLOW_ALL_in_exports204 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_exports206 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EXPORTS_in_exports211 = new BitSet(new ulong[]{0x4000800000000000UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports215 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000000C000UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports219 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000000C000UL});
    public static readonly BitSet FOLLOW_79_in_exports223 = new BitSet(new ulong[]{0x4000800000000000UL});
    public static readonly BitSet FOLLOW_typereference_in_exports226 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000000C000UL});
    public static readonly BitSet FOLLOW_valuereference_in_exports230 = new BitSet(new ulong[]{0x0000000000000000UL,0x000000000000C000UL});
    public static readonly BitSet FOLLOW_78_in_exports238 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IMPORTS_in_imports251 = new BitSet(new ulong[]{0x4000800000000000UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_typereference_in_imports255 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports259 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_imports263 = new BitSet(new ulong[]{0x4000800000000000UL});
    public static readonly BitSet FOLLOW_typereference_in_imports266 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_valuereference_in_imports270 = new BitSet(new ulong[]{0x0000000000020000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_FROM_in_imports275 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_modulereference_in_imports277 = new BitSet(new ulong[]{0x4000800000000000UL,0x0000000000004400UL});
    public static readonly BitSet FOLLOW_definitiveIdentifier_in_imports279 = new BitSet(new ulong[]{0x4000800000000000UL,0x0000000000004000UL});
    public static readonly BitSet FOLLOW_78_in_imports285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_valueAssigment301 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_valueAssigment303 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_valueAssigment305 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_valueAssigment307 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_valueSetAssigment323 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_valueSetAssigment325 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_valueSetAssigment327 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_valueSetAssigment329 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpecs_in_valueSetAssigment331 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_valueSetAssigment333 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_typereference_in_typeAssigment346 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000200UL});
    public static readonly BitSet FOLLOW_73_in_typeAssigment348 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_typeAssigment350 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_80_in_type362 = new BitSet(new ulong[]{0x00000000001C2000UL});
    public static readonly BitSet FOLLOW_set_in_type364 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_type377 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000020000UL});
    public static readonly BitSet FOLLOW_81_in_type380 = new BitSet(new ulong[]{0x0005FFF87F6000A0UL});
    public static readonly BitSet FOLLOW_set_in_type382 = new BitSet(new ulong[]{0x0005FFF87F600000UL});
    public static readonly BitSet FOLLOW_NULL_in_type400 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringType_in_type404 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_booleanType_in_type408 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type410 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type415 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type417 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_integerType_in_type426 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type428 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_realType_in_type440 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type442 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_stringType_in_type447 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type449 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_referencedType_in_type454 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type456 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type461 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type465 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type476 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_setType_in_type488 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_setOfType_in_type500 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_objectIdentifier_in_type512 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_relativeOID_in_type523 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BIT_in_bitStringType537 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_STRING_in_bitStringType539 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_bitStringType542 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType545 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitStringType547 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType550 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_bitStringType552 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitStringType555 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_bitStringType558 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType560 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitStringType562 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType565 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_bitStringType567 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitStringType570 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_bitStringType578 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BOOLEAN_in_booleanType593 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENUMERATED_in_enumeratedType606 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_enumeratedType608 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_enumeratedTypeItems_in_enumeratedType610 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedType615 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_enumeratedType617 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004008800UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_enumeratedType619 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedType623 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_enumeratedTypeItems_in_enumeratedType625 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_enumeratedType632 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedTypeItems644 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000009000UL});
    public static readonly BitSet FOLLOW_76_in_enumeratedTypeItems648 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedTypeItems651 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_enumeratedTypeItems653 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_enumeratedTypeItems656 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedTypeItems661 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedTypeItems663 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000009000UL});
    public static readonly BitSet FOLLOW_76_in_enumeratedTypeItems667 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedTypeItems670 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_enumeratedTypeItems672 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_enumeratedTypeItems675 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_INTEGER_in_integerType692 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_integerType696 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType699 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_integerType701 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType704 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_integerType706 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_integerType709 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_integerType712 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType714 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_integerType716 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType719 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_integerType721 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_integerType724 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_integerType730 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_realType745 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CHOICE_in_choiceType762 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_choiceType764 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_choiceList_in_choiceType766 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_choiceType769 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_choiceType771 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004008800UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_choiceType773 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_choiceListExtension_in_choiceType777 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_choiceType783 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_choiceType785 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_choiceType793 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceList804 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_choiceList806 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceList809 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceList811 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_choiceList813 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceListExtension826 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionAlternative_in_choiceListExtension828 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceListExtension831 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionAlternative_in_choiceListExtension833 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_83_in_extensionAdditionAlternative847 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_versionNumber_in_extensionAdditionAlternative849 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_choiceList_in_extensionAdditionAlternative852 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
    public static readonly BitSet FOLLOW_84_in_extensionAdditionAlternative854 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_extensionAdditionAlternative860 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_extensionAdditionAlternative862 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceType874 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_sequenceType876 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040800UL});
    public static readonly BitSet FOLLOW_sequenceOrSetBody_in_sequenceType878 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_sequenceType882 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setType894 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_setType896 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040800UL});
    public static readonly BitSet FOLLOW_sequenceOrSetBody_in_setType898 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_setType902 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_sequenceOrSetBody919 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_sequenceOrSetBody923 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody925 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody933 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_82_in_seqOrSetExtBody945 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000004008000UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_seqOrSetExtBody947 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody951 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionList_in_seqOrSetExtBody953 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody958 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_seqOrSetExtBody960 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody965 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_seqOrSetExtBody967 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_extensionAddition_in_extensionAdditionList986 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_extensionAdditionList989 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAddition_in_extensionAdditionList991 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_componentType_in_extensionAddition1005 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_extensionAdditionGroup_in_extensionAddition1016 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_83_in_extensionAdditionGroup1026 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_versionNumber_in_extensionAdditionGroup1028 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_extensionAdditionGroup1031 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
    public static readonly BitSet FOLLOW_84_in_extensionAdditionGroup1033 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_componentType_in_componentTypeList1045 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_componentTypeList1049 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentType_in_componentTypeList1051 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_identifier_in_componentType1066 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_componentType1068 = new BitSet(new ulong[]{0x0000000180000002UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_componentType1071 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DEFAULT_in_componentType1075 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_componentType1077 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType1092 = new BitSet(new ulong[]{0x0000000200000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_sequenceOfType1094 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType1097 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType1099 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType1104 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sequenceOfType1106 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_sequenceOfType1108 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType1110 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType1112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setOfType1124 = new BitSet(new ulong[]{0x0000000200000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_setOfType1126 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_setOfType1129 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_setOfType1131 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setOfType1136 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_setOfType1138 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_setOfType1140 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_setOfType1142 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_setOfType1144 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCTET_in_stringType1160 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_STRING_in_stringType1162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NumericString_in_stringType1166 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PrintableString_in_stringType1170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VisibleString_in_stringType1174 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IA5String_in_stringType1178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TeletexString_in_stringType1182 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VideotexString_in_stringType1186 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GraphicString_in_stringType1190 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GeneralString_in_stringType1194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UniversalString_in_stringType1198 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BMPString_in_stringType1202 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UTF8String_in_stringType1206 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_referencedType1218 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_referencedType1221 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_UID_in_referencedType1223 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OBJECT_in_objectIdentifier1237 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_objectIdentifier1239 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RELATIVE_OID_in_relativeOID1247 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber1258 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber1265 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_constraint1276 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_constraint1281 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withComponentsConstraint_in_constraint1286 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_subTypeConstraint_in_constraint1291 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_valueConstraint1307 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_valueConstraint1309 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000003002000UL});
    public static readonly BitSet FOLLOW_88_in_valueConstraint1314 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000002000000UL});
    public static readonly BitSet FOLLOW_89_in_valueConstraint1318 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000001C00400UL});
    public static readonly BitSet FOLLOW_88_in_valueConstraint1321 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_valueConstraint1325 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_valueConstraint1329 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_sizeConstraint1340 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sizeConstraint1342 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_sizeConstraint1344 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_sizeConstraint1346 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_permittedAlphabetConstraint1359 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_FROM_in_permittedAlphabetConstraint1361 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_permittedAlphabetConstraint1363 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_permittedAlphabetConstraint1365 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_subTypeConstraint1378 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_subTypeConstraint1380 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_subTypeConstraint1382 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_withComponentsConstraint1397 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_WITH_in_withComponentsConstraint1400 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_COMPONENTS_in_withComponentsConstraint1402 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_withComponentsConstraint1404 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_withComponentsConstraint1411 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_withComponentsConstraint1413 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint1420 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_withComponentsConstraint1424 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint1426 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_withComponentsConstraint1432 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_withComponentsConstraint1436 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_namedConstraint1448 = new BitSet(new ulong[]{0x0060000080000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_namedConstraint1451 = new BitSet(new ulong[]{0x0060000080000002UL});
    public static readonly BitSet FOLLOW_set_in_namedConstraint1455 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BitStringLiteral_in_value1475 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value1480 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OctectStringLiteral_in_value1485 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TRUE_in_value1490 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FALSE_in_value1495 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_StringLiteral_in_value1500 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_value1505 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value1512 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_value1519 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_value1522 = new BitSet(new ulong[]{0x0000000000002002UL});
    public static readonly BitSet FOLLOW_INT_in_value1524 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MIN_in_value1534 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAX_in_value1539 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_74_in_bitStringValue1552 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringValue1554 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_bitStringValue1557 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringValue1559 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_bitStringValue1563 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_lID1576 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_modulereference1584 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typereference1592 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valuereference1602 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_identifier1612 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_versionNumber1620 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_g_constraint1640 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_subtypeConstraint_in_g_constraint1642 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004002000UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_g_constraint1645 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_g_constraint1648 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_90_in_g_exceptionSpec1660 = new BitSet(new ulong[]{0x4005FFF87F602000UL,0x0000000000C10000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_g_exceptionSpec1669 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_g_exceptionSpec1674 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_in_g_exceptionSpec1681 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000008000000UL});
    public static readonly BitSet FOLLOW_91_in_g_exceptionSpec1683 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_exceptionSpec1685 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_elementSetSpecs_in_g_subtypeConstraint1700 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_unionElement_in_g_elementSetSpecs1709 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_elementSetSpecs1712 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_g_elementSetSpecs1714 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_elementSetSpecs1718 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_unionElement_in_g_elementSetSpecs1720 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_intersectionElement_in_g_unionElement1734 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_UnionMark_in_g_unionElement1737 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_intersectionElement_in_g_unionElement1739 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_ALL_in_g_unionElement1746 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_unionElement1748 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_unionElement1750 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1763 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_intersectionElement1766 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1768 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IntersectionMark_in_g_intersectionElement1773 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1775 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_intersectionElement1778 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1780 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_valueElement_in_g_elementSetSpec1796 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_containedSubtype_in_g_elementSetSpec1801 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_SizeConstraint_in_g_elementSetSpec1806 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_permittedAlphabet_in_g_elementSetSpec1811 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_innerTypeConstraints_in_g_elementSetSpec1816 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_patternConstraint_in_g_elementSetSpec1821 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_g_elementSetSpec1826 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpecs_in_g_elementSetSpec1828 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_g_elementSetSpec1830 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_value_in_g_valueElement1843 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000003000000UL});
    public static readonly BitSet FOLLOW_88_in_g_valueElement1848 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000002000000UL});
    public static readonly BitSet FOLLOW_89_in_g_valueElement1852 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000001C00400UL});
    public static readonly BitSet FOLLOW_88_in_g_valueElement1855 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_valueElement1859 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INCLUDES_in_g_containedSubtype1870 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_g_containedSubtype1873 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SIZE_in_g_SizeConstraint1881 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_SizeConstraint1883 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_g_permittedAlphabet1891 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_permittedAlphabet1893 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_g_innerTypeConstraints1903 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_COMPONENT_in_g_innerTypeConstraints1905 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_innerTypeConstraints1907 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_g_innerTypeConstraints1912 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_COMPONENTS_in_g_innerTypeConstraints1914 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_g_innerTypeConstraints1916 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_g_innerTypeConstraints1923 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_innerTypeConstraints1925 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_g_namedConstraint_in_g_innerTypeConstraints1932 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_g_innerTypeConstraints1936 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_g_namedConstraint_in_g_innerTypeConstraints1938 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_g_innerTypeConstraints1944 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_g_namedConstraint1956 = new BitSet(new ulong[]{0x0060000080000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_namedConstraint1959 = new BitSet(new ulong[]{0x0060000080000002UL});
    public static readonly BitSet FOLLOW_set_in_g_namedConstraint1963 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PATTERN_in_g_patternConstraint1981 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_patternConstraint1983 = new BitSet(new ulong[]{0x0000000000000002UL});

}
