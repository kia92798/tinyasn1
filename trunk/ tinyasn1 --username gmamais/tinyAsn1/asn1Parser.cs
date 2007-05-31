// $ANTLR 3.0 C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g 2007-05-31 16:10:52



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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:1: type : ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID ) ;
    public void type() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:8: ( ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:63:8: ( '[' ( UNIVERSAL | APPLICATION | PRIVATE )? INT ']' ( IMPLICIT | EXPLICIT )? )? ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID )
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

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:64:1: ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID )
            	int alt33 = 15;
            	switch ( input.LA(1) ) 
            	{
            	case NULL:
            		{
            	    alt33 = 1;
            	    }
            	    break;
            	case BIT:
            		{
            	    alt33 = 2;
            	    }
            	    break;
            	case BOOLEAN:
            		{
            	    alt33 = 3;
            	    }
            	    break;
            	case ENUMERATED:
            		{
            	    alt33 = 4;
            	    }
            	    break;
            	case INTEGER:
            		{
            	    alt33 = 5;
            	    }
            	    break;
            	case REAL:
            		{
            	    alt33 = 6;
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
            	    alt33 = 7;
            	    }
            	    break;
            	case UID:
            		{
            	    alt33 = 8;
            	    }
            	    break;
            	case SEQUENCE:
            		{
            	    int LA33_9 = input.LA(2);
            	    
            	    if ( ((LA33_9 >= OF && LA33_9 <= SIZE) || LA33_9 == 76) )
            	    {
            	        alt33 = 9;
            	    }
            	    else if ( (LA33_9 == 74) )
            	    {
            	        alt33 = 11;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d33s9 =
            	            new NoViableAltException("64:1: ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID )", 33, 9, input);
            	    
            	        throw nvae_d33s9;
            	    }
            	    }
            	    break;
            	case CHOICE:
            		{
            	    alt33 = 10;
            	    }
            	    break;
            	case SET:
            		{
            	    int LA33_11 = input.LA(2);
            	    
            	    if ( (LA33_11 == 74) )
            	    {
            	        alt33 = 12;
            	    }
            	    else if ( ((LA33_11 >= OF && LA33_11 <= SIZE) || LA33_11 == 76) )
            	    {
            	        alt33 = 13;
            	    }
            	    else 
            	    {
            	        NoViableAltException nvae_d33s11 =
            	            new NoViableAltException("64:1: ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID )", 33, 11, input);
            	    
            	        throw nvae_d33s11;
            	    }
            	    }
            	    break;
            	case OBJECT:
            		{
            	    alt33 = 14;
            	    }
            	    break;
            	case RELATIVE_OID:
            		{
            	    alt33 = 15;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d33s0 =
            		        new NoViableAltException("64:1: ( NULL | bitStringType ( g_constraint )* | booleanType ( g_constraint )* | enumeratedType ( g_constraint )* | integerType ( g_constraint )* | realType ( g_constraint )* | stringType ( g_constraint )* | referencedType ( g_constraint )* | sequenceOfType | choiceType | sequenceType ( g_constraint )* | setType | setOfType | objectIdentifier ( g_constraint )* | relativeOID )", 33, 0, input);
            	
            		    throw nvae_d33s0;
            	}
            	
            	switch (alt33) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:65:3: NULL
            	        {
            	        	Match(input,NULL,FOLLOW_NULL_in_type400); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:3: bitStringType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_bitStringType_in_type404);
            	        	bitStringType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:17: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:66:17: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type406);
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
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:3: booleanType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_booleanType_in_type411);
            	        	booleanType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:15: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:67:15: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type413);
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
            	    case 4 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:3: enumeratedType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_enumeratedType_in_type418);
            	        	enumeratedType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:18: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:68:18: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type420);
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
            	    case 5 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:3: integerType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_integerType_in_type429);
            	        	integerType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:15: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:73:15: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type431);
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
            	    case 6 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:10: realType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_realType_in_type443);
            	        	realType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:19: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:74:19: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type445);
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
            	    case 7 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:3: stringType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_stringType_in_type450);
            	        	stringType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:14: ( g_constraint )*
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
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:75:14: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type452);
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
            	    case 8 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:3: referencedType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_referencedType_in_type457);
            	        	referencedType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:18: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt30 = 2;
            	        	    int LA30_0 = input.LA(1);
            	        	    
            	        	    if ( (LA30_0 == 76) )
            	        	    {
            	        	        alt30 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt30) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:76:18: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type459);
            	        			    	g_constraint();
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
            	    case 9 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:77:3: sequenceOfType
            	        {
            	        	PushFollow(FOLLOW_sequenceOfType_in_type464);
            	        	sequenceOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 10 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:78:3: choiceType
            	        {
            	        	PushFollow(FOLLOW_choiceType_in_type469);
            	        	choiceType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 11 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:10: sequenceType ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_sequenceType_in_type480);
            	        	sequenceType();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:23: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt31 = 2;
            	        	    int LA31_0 = input.LA(1);
            	        	    
            	        	    if ( (LA31_0 == 76) )
            	        	    {
            	        	        alt31 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt31) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:79:23: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type482);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
            	        			    }
            	        			    break;
            	        	
            	        			default:
            	        			    goto loop31;
            	        	    }
            	        	} while (true);
            	        	
            	        	loop31:
            	        		;	// Stops C# compiler whinging that label 'loop31' has no statements

            	        
            	        }
            	        break;
            	    case 12 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:80:11: setType
            	        {
            	        	PushFollow(FOLLOW_setType_in_type496);
            	        	setType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 13 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:81:11: setOfType
            	        {
            	        	PushFollow(FOLLOW_setOfType_in_type508);
            	        	setOfType();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 14 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:11: objectIdentifier ( g_constraint )*
            	        {
            	        	PushFollow(FOLLOW_objectIdentifier_in_type520);
            	        	objectIdentifier();
            	        	followingStackPointer_--;

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:28: ( g_constraint )*
            	        	do 
            	        	{
            	        	    int alt32 = 2;
            	        	    int LA32_0 = input.LA(1);
            	        	    
            	        	    if ( (LA32_0 == 76) )
            	        	    {
            	        	        alt32 = 1;
            	        	    }
            	        	    
            	        	
            	        	    switch (alt32) 
            	        		{
            	        			case 1 :
            	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:82:28: g_constraint
            	        			    {
            	        			    	PushFollow(FOLLOW_g_constraint_in_type522);
            	        			    	g_constraint();
            	        			    	followingStackPointer_--;

            	        			    
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
            	    case 15 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:83:10: relativeOID
            	        {
            	        	PushFollow(FOLLOW_relativeOID_in_type534);
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
            	Match(input,BIT,FOLLOW_BIT_in_bitStringType548); 
            	Match(input,STRING,FOLLOW_STRING_in_bitStringType550); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:15: ( '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}' )?
            	int alt38 = 2;
            	int LA38_0 = input.LA(1);
            	
            	if ( (LA38_0 == 74) )
            	{
            	    alt38 = 1;
            	}
            	switch (alt38) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:16: '{' ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )? '}'
            	        {
            	        	Match(input,74,FOLLOW_74_in_bitStringType553); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:20: ( identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )* )?
            	        	int alt37 = 2;
            	        	int LA37_0 = input.LA(1);
            	        	
            	        	if ( (LA37_0 == LID) )
            	        	{
            	        	    alt37 = 1;
            	        	}
            	        	switch (alt37) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:21: identifier '(' ( INT | valuereference ) ')' ( ',' identifier '(' ( INT | valuereference ) ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_bitStringType556);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,76,FOLLOW_76_in_bitStringType558); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:36: ( INT | valuereference )
            	        	        	int alt34 = 2;
            	        	        	int LA34_0 = input.LA(1);
            	        	        	
            	        	        	if ( (LA34_0 == INT) )
            	        	        	{
            	        	        	    alt34 = 1;
            	        	        	}
            	        	        	else if ( (LA34_0 == LID) )
            	        	        	{
            	        	        	    alt34 = 2;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    NoViableAltException nvae_d34s0 =
            	        	        	        new NoViableAltException("89:36: ( INT | valuereference )", 34, 0, input);
            	        	        	
            	        	        	    throw nvae_d34s0;
            	        	        	}
            	        	        	switch (alt34) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:37: INT
            	        	        	        {
            	        	        	        	Match(input,INT,FOLLOW_INT_in_bitStringType561); 
            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	    case 2 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:41: valuereference
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_valuereference_in_bitStringType563);
            	        	        	        	valuereference();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	
            	        	        	}

            	        	        	Match(input,77,FOLLOW_77_in_bitStringType566); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:61: ( ',' identifier '(' ( INT | valuereference ) ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt36 = 2;
            	        	        	    int LA36_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA36_0 == 79) )
            	        	        	    {
            	        	        	        alt36 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt36) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:62: ',' identifier '(' ( INT | valuereference ) ')'
            	        	        			    {
            	        	        			    	Match(input,79,FOLLOW_79_in_bitStringType569); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_bitStringType571);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,76,FOLLOW_76_in_bitStringType573); 
            	        	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:81: ( INT | valuereference )
            	        	        			    	int alt35 = 2;
            	        	        			    	int LA35_0 = input.LA(1);
            	        	        			    	
            	        	        			    	if ( (LA35_0 == INT) )
            	        	        			    	{
            	        	        			    	    alt35 = 1;
            	        	        			    	}
            	        	        			    	else if ( (LA35_0 == LID) )
            	        	        			    	{
            	        	        			    	    alt35 = 2;
            	        	        			    	}
            	        	        			    	else 
            	        	        			    	{
            	        	        			    	    NoViableAltException nvae_d35s0 =
            	        	        			    	        new NoViableAltException("89:81: ( INT | valuereference )", 35, 0, input);
            	        	        			    	
            	        	        			    	    throw nvae_d35s0;
            	        	        			    	}
            	        	        			    	switch (alt35) 
            	        	        			    	{
            	        	        			    	    case 1 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:82: INT
            	        	        			    	        {
            	        	        			    	        	Match(input,INT,FOLLOW_INT_in_bitStringType576); 
            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	    case 2 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:89:86: valuereference
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_valuereference_in_bitStringType578);
            	        	        			    	        	valuereference();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	
            	        	        			    	}

            	        	        			    	Match(input,77,FOLLOW_77_in_bitStringType581); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop36;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop36:
            	        	        		;	// Stops C# compiler whinging that label 'loop36' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,75,FOLLOW_75_in_bitStringType589); 
            	        
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
            	Match(input,BOOLEAN,FOLLOW_BOOLEAN_in_booleanType604); 
            
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
            	Match(input,ENUMERATED,FOLLOW_ENUMERATED_in_enumeratedType617); 
            	Match(input,74,FOLLOW_74_in_enumeratedType619); 
            	PushFollow(FOLLOW_enumeratedTypeItems_in_enumeratedType621);
            	enumeratedTypeItems();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:40: ( ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )? )?
            	int alt41 = 2;
            	int LA41_0 = input.LA(1);
            	
            	if ( (LA41_0 == 79) )
            	{
            	    alt41 = 1;
            	}
            	switch (alt41) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:42: ',' '...' ( g_exceptionSpec )? ( ',' enumeratedTypeItems )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_enumeratedType626); 
            	        	Match(input,82,FOLLOW_82_in_enumeratedType628); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:52: ( g_exceptionSpec )?
            	        	int alt39 = 2;
            	        	int LA39_0 = input.LA(1);
            	        	
            	        	if ( (LA39_0 == 90) )
            	        	{
            	        	    alt39 = 1;
            	        	}
            	        	switch (alt39) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:52: g_exceptionSpec
            	        	        {
            	        	        	PushFollow(FOLLOW_g_exceptionSpec_in_enumeratedType630);
            	        	        	g_exceptionSpec();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:69: ( ',' enumeratedTypeItems )?
            	        	int alt40 = 2;
            	        	int LA40_0 = input.LA(1);
            	        	
            	        	if ( (LA40_0 == 79) )
            	        	{
            	        	    alt40 = 1;
            	        	}
            	        	switch (alt40) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:97:70: ',' enumeratedTypeItems
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_enumeratedType634); 
            	        	        	PushFollow(FOLLOW_enumeratedTypeItems_in_enumeratedType636);
            	        	        	enumeratedTypeItems();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_enumeratedType643); 
            
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
            	PushFollow(FOLLOW_identifier_in_enumeratedTypeItems655);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:15: ( '(' ( signedNumber | valuereference ) ')' )?
            	int alt43 = 2;
            	int LA43_0 = input.LA(1);
            	
            	if ( (LA43_0 == 76) )
            	{
            	    alt43 = 1;
            	}
            	switch (alt43) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:17: '(' ( signedNumber | valuereference ) ')'
            	        {
            	        	Match(input,76,FOLLOW_76_in_enumeratedTypeItems659); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:21: ( signedNumber | valuereference )
            	        	int alt42 = 2;
            	        	int LA42_0 = input.LA(1);
            	        	
            	        	if ( (LA42_0 == INT || (LA42_0 >= 86 && LA42_0 <= 87)) )
            	        	{
            	        	    alt42 = 1;
            	        	}
            	        	else if ( (LA42_0 == LID) )
            	        	{
            	        	    alt42 = 2;
            	        	}
            	        	else 
            	        	{
            	        	    NoViableAltException nvae_d42s0 =
            	        	        new NoViableAltException("101:21: ( signedNumber | valuereference )", 42, 0, input);
            	        	
            	        	    throw nvae_d42s0;
            	        	}
            	        	switch (alt42) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:22: signedNumber
            	        	        {
            	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedTypeItems662);
            	        	        	signedNumber();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	    case 2 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:35: valuereference
            	        	        {
            	        	        	PushFollow(FOLLOW_valuereference_in_enumeratedTypeItems664);
            	        	        	valuereference();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,77,FOLLOW_77_in_enumeratedTypeItems667); 
            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:57: ( ',' identifier ( '(' ( signedNumber | valuereference ) ')' )? )*
            	do 
            	{
            	    int alt46 = 2;
            	    int LA46_0 = input.LA(1);
            	    
            	    if ( (LA46_0 == 79) )
            	    {
            	        int LA46_1 = input.LA(2);
            	        
            	        if ( (LA46_1 == LID) )
            	        {
            	            alt46 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt46) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:58: ',' identifier ( '(' ( signedNumber | valuereference ) ')' )?
            			    {
            			    	Match(input,79,FOLLOW_79_in_enumeratedTypeItems672); 
            			    	PushFollow(FOLLOW_identifier_in_enumeratedTypeItems674);
            			    	identifier();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:73: ( '(' ( signedNumber | valuereference ) ')' )?
            			    	int alt45 = 2;
            			    	int LA45_0 = input.LA(1);
            			    	
            			    	if ( (LA45_0 == 76) )
            			    	{
            			    	    alt45 = 1;
            			    	}
            			    	switch (alt45) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:75: '(' ( signedNumber | valuereference ) ')'
            			    	        {
            			    	        	Match(input,76,FOLLOW_76_in_enumeratedTypeItems678); 
            			    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:79: ( signedNumber | valuereference )
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
            			    	        	        new NoViableAltException("101:79: ( signedNumber | valuereference )", 44, 0, input);
            			    	        	
            			    	        	    throw nvae_d44s0;
            			    	        	}
            			    	        	switch (alt44) 
            			    	        	{
            			    	        	    case 1 :
            			    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:80: signedNumber
            			    	        	        {
            			    	        	        	PushFollow(FOLLOW_signedNumber_in_enumeratedTypeItems681);
            			    	        	        	signedNumber();
            			    	        	        	followingStackPointer_--;

            			    	        	        
            			    	        	        }
            			    	        	        break;
            			    	        	    case 2 :
            			    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:101:93: valuereference
            			    	        	        {
            			    	        	        	PushFollow(FOLLOW_valuereference_in_enumeratedTypeItems683);
            			    	        	        	valuereference();
            			    	        	        	followingStackPointer_--;

            			    	        	        
            			    	        	        }
            			    	        	        break;
            			    	        	
            			    	        	}

            			    	        	Match(input,77,FOLLOW_77_in_enumeratedTypeItems686); 
            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop46;
            	    }
            	} while (true);
            	
            	loop46:
            		;	// Stops C# compiler whinging that label 'loop46' has no statements

            
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
            	Match(input,INTEGER,FOLLOW_INTEGER_in_integerType703); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:12: ( '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}' )?
            	int alt51 = 2;
            	int LA51_0 = input.LA(1);
            	
            	if ( (LA51_0 == 74) )
            	{
            	    alt51 = 1;
            	}
            	switch (alt51) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:14: '{' ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )? '}'
            	        {
            	        	Match(input,74,FOLLOW_74_in_integerType707); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:18: ( identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )* )?
            	        	int alt50 = 2;
            	        	int LA50_0 = input.LA(1);
            	        	
            	        	if ( (LA50_0 == LID) )
            	        	{
            	        	    alt50 = 1;
            	        	}
            	        	switch (alt50) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:19: identifier '(' ( signedNumber | valuereference ) ')' ( ',' identifier '(' ( signedNumber | valuereference ) ')' )*
            	        	        {
            	        	        	PushFollow(FOLLOW_identifier_in_integerType710);
            	        	        	identifier();
            	        	        	followingStackPointer_--;

            	        	        	Match(input,76,FOLLOW_76_in_integerType712); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:34: ( signedNumber | valuereference )
            	        	        	int alt47 = 2;
            	        	        	int LA47_0 = input.LA(1);
            	        	        	
            	        	        	if ( (LA47_0 == INT || (LA47_0 >= 86 && LA47_0 <= 87)) )
            	        	        	{
            	        	        	    alt47 = 1;
            	        	        	}
            	        	        	else if ( (LA47_0 == LID) )
            	        	        	{
            	        	        	    alt47 = 2;
            	        	        	}
            	        	        	else 
            	        	        	{
            	        	        	    NoViableAltException nvae_d47s0 =
            	        	        	        new NoViableAltException("105:34: ( signedNumber | valuereference )", 47, 0, input);
            	        	        	
            	        	        	    throw nvae_d47s0;
            	        	        	}
            	        	        	switch (alt47) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:35: signedNumber
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_signedNumber_in_integerType715);
            	        	        	        	signedNumber();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	    case 2 :
            	        	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:48: valuereference
            	        	        	        {
            	        	        	        	PushFollow(FOLLOW_valuereference_in_integerType717);
            	        	        	        	valuereference();
            	        	        	        	followingStackPointer_--;

            	        	        	        
            	        	        	        }
            	        	        	        break;
            	        	        	
            	        	        	}

            	        	        	Match(input,77,FOLLOW_77_in_integerType720); 
            	        	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:68: ( ',' identifier '(' ( signedNumber | valuereference ) ')' )*
            	        	        	do 
            	        	        	{
            	        	        	    int alt49 = 2;
            	        	        	    int LA49_0 = input.LA(1);
            	        	        	    
            	        	        	    if ( (LA49_0 == 79) )
            	        	        	    {
            	        	        	        alt49 = 1;
            	        	        	    }
            	        	        	    
            	        	        	
            	        	        	    switch (alt49) 
            	        	        		{
            	        	        			case 1 :
            	        	        			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:69: ',' identifier '(' ( signedNumber | valuereference ) ')'
            	        	        			    {
            	        	        			    	Match(input,79,FOLLOW_79_in_integerType723); 
            	        	        			    	PushFollow(FOLLOW_identifier_in_integerType725);
            	        	        			    	identifier();
            	        	        			    	followingStackPointer_--;

            	        	        			    	Match(input,76,FOLLOW_76_in_integerType727); 
            	        	        			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:88: ( signedNumber | valuereference )
            	        	        			    	int alt48 = 2;
            	        	        			    	int LA48_0 = input.LA(1);
            	        	        			    	
            	        	        			    	if ( (LA48_0 == INT || (LA48_0 >= 86 && LA48_0 <= 87)) )
            	        	        			    	{
            	        	        			    	    alt48 = 1;
            	        	        			    	}
            	        	        			    	else if ( (LA48_0 == LID) )
            	        	        			    	{
            	        	        			    	    alt48 = 2;
            	        	        			    	}
            	        	        			    	else 
            	        	        			    	{
            	        	        			    	    NoViableAltException nvae_d48s0 =
            	        	        			    	        new NoViableAltException("105:88: ( signedNumber | valuereference )", 48, 0, input);
            	        	        			    	
            	        	        			    	    throw nvae_d48s0;
            	        	        			    	}
            	        	        			    	switch (alt48) 
            	        	        			    	{
            	        	        			    	    case 1 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:89: signedNumber
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_signedNumber_in_integerType730);
            	        	        			    	        	signedNumber();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	    case 2 :
            	        	        			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:105:102: valuereference
            	        	        			    	        {
            	        	        			    	        	PushFollow(FOLLOW_valuereference_in_integerType732);
            	        	        			    	        	valuereference();
            	        	        			    	        	followingStackPointer_--;

            	        	        			    	        
            	        	        			    	        }
            	        	        			    	        break;
            	        	        			    	
            	        	        			    	}

            	        	        			    	Match(input,77,FOLLOW_77_in_integerType735); 
            	        	        			    
            	        	        			    }
            	        	        			    break;
            	        	        	
            	        	        			default:
            	        	        			    goto loop49;
            	        	        	    }
            	        	        	} while (true);
            	        	        	
            	        	        	loop49:
            	        	        		;	// Stops C# compiler whinging that label 'loop49' has no statements

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,75,FOLLOW_75_in_integerType741); 
            	        
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
            	Match(input,REAL,FOLLOW_REAL_in_realType756); 
            
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
            	Match(input,CHOICE,FOLLOW_CHOICE_in_choiceType773); 
            	Match(input,74,FOLLOW_74_in_choiceType775); 
            	PushFollow(FOLLOW_choiceList_in_choiceType777);
            	choiceList();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:26: ( ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )? )?
            	int alt55 = 2;
            	int LA55_0 = input.LA(1);
            	
            	if ( (LA55_0 == 79) )
            	{
            	    alt55 = 1;
            	}
            	switch (alt55) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:27: ',' '...' ( g_exceptionSpec )? ( choiceListExtension )? ( ',' '...' )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_choiceType780); 
            	        	Match(input,82,FOLLOW_82_in_choiceType782); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:37: ( g_exceptionSpec )?
            	        	int alt52 = 2;
            	        	int LA52_0 = input.LA(1);
            	        	
            	        	if ( (LA52_0 == 90) )
            	        	{
            	        	    alt52 = 1;
            	        	}
            	        	switch (alt52) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:37: g_exceptionSpec
            	        	        {
            	        	        	PushFollow(FOLLOW_g_exceptionSpec_in_choiceType784);
            	        	        	g_exceptionSpec();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:55: ( choiceListExtension )?
            	        	int alt53 = 2;
            	        	int LA53_0 = input.LA(1);
            	        	
            	        	if ( (LA53_0 == 79) )
            	        	{
            	        	    int LA53_1 = input.LA(2);
            	        	    
            	        	    if ( (LA53_1 == LID || LA53_1 == 83) )
            	        	    {
            	        	        alt53 = 1;
            	        	    }
            	        	}
            	        	switch (alt53) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:55: choiceListExtension
            	        	        {
            	        	        	PushFollow(FOLLOW_choiceListExtension_in_choiceType788);
            	        	        	choiceListExtension();
            	        	        	followingStackPointer_--;

            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:78: ( ',' '...' )?
            	        	int alt54 = 2;
            	        	int LA54_0 = input.LA(1);
            	        	
            	        	if ( (LA54_0 == 79) )
            	        	{
            	        	    alt54 = 1;
            	        	}
            	        	switch (alt54) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:121:79: ',' '...'
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_choiceType794); 
            	        	        	Match(input,82,FOLLOW_82_in_choiceType796); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_choiceType804); 
            
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
            	PushFollow(FOLLOW_identifier_in_choiceList815);
            	identifier();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_choiceList817);
            	type();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:20: ( ',' identifier type )*
            	do 
            	{
            	    int alt56 = 2;
            	    int LA56_0 = input.LA(1);
            	    
            	    if ( (LA56_0 == 79) )
            	    {
            	        int LA56_1 = input.LA(2);
            	        
            	        if ( (LA56_1 == LID) )
            	        {
            	            alt56 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt56) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:125:21: ',' identifier type
            			    {
            			    	Match(input,79,FOLLOW_79_in_choiceList820); 
            			    	PushFollow(FOLLOW_identifier_in_choiceList822);
            			    	identifier();
            			    	followingStackPointer_--;

            			    	PushFollow(FOLLOW_type_in_choiceList824);
            			    	type();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop56;
            	    }
            	} while (true);
            	
            	loop56:
            		;	// Stops C# compiler whinging that label 'loop56' has no statements

            
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
            	Match(input,79,FOLLOW_79_in_choiceListExtension837); 
            	PushFollow(FOLLOW_extensionAdditionAlternative_in_choiceListExtension839);
            	extensionAdditionAlternative();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:37: ( ',' extensionAdditionAlternative )*
            	do 
            	{
            	    int alt57 = 2;
            	    int LA57_0 = input.LA(1);
            	    
            	    if ( (LA57_0 == 79) )
            	    {
            	        int LA57_1 = input.LA(2);
            	        
            	        if ( (LA57_1 == LID || LA57_1 == 83) )
            	        {
            	            alt57 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt57) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:129:38: ',' extensionAdditionAlternative
            			    {
            			    	Match(input,79,FOLLOW_79_in_choiceListExtension842); 
            			    	PushFollow(FOLLOW_extensionAdditionAlternative_in_choiceListExtension844);
            			    	extensionAdditionAlternative();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop57;
            	    }
            	} while (true);
            	
            	loop57:
            		;	// Stops C# compiler whinging that label 'loop57' has no statements

            
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
            int alt59 = 2;
            int LA59_0 = input.LA(1);
            
            if ( (LA59_0 == 83) )
            {
                alt59 = 1;
            }
            else if ( (LA59_0 == LID) )
            {
                alt59 = 2;
            }
            else 
            {
                NoViableAltException nvae_d59s0 =
                    new NoViableAltException("131:1: extensionAdditionAlternative : ( '[[' ( versionNumber )? choiceList ']]' | identifier type );", 59, 0, input);
            
                throw nvae_d59s0;
            }
            switch (alt59) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:5: '[[' ( versionNumber )? choiceList ']]'
                    {
                    	Match(input,83,FOLLOW_83_in_extensionAdditionAlternative858); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:10: ( versionNumber )?
                    	int alt58 = 2;
                    	int LA58_0 = input.LA(1);
                    	
                    	if ( (LA58_0 == INT) )
                    	{
                    	    alt58 = 1;
                    	}
                    	switch (alt58) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:132:10: versionNumber
                    	        {
                    	        	PushFollow(FOLLOW_versionNumber_in_extensionAdditionAlternative860);
                    	        	versionNumber();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_choiceList_in_extensionAdditionAlternative863);
                    	choiceList();
                    	followingStackPointer_--;

                    	Match(input,84,FOLLOW_84_in_extensionAdditionAlternative865); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:133:5: identifier type
                    {
                    	PushFollow(FOLLOW_identifier_in_extensionAdditionAlternative871);
                    	identifier();
                    	followingStackPointer_--;

                    	PushFollow(FOLLOW_type_in_extensionAdditionAlternative873);
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
            	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceType885); 
            	Match(input,74,FOLLOW_74_in_sequenceType887); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:17: ( sequenceOrSetBody )?
            	int alt60 = 2;
            	int LA60_0 = input.LA(1);
            	
            	if ( (LA60_0 == LID || LA60_0 == 82) )
            	{
            	    alt60 = 1;
            	}
            	switch (alt60) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:137:17: sequenceOrSetBody
            	        {
            	        	PushFollow(FOLLOW_sequenceOrSetBody_in_sequenceType889);
            	        	sequenceOrSetBody();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_sequenceType893); 
            
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
            	Match(input,SET,FOLLOW_SET_in_setType905); 
            	Match(input,74,FOLLOW_74_in_setType907); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:19: ( sequenceOrSetBody )?
            	int alt61 = 2;
            	int LA61_0 = input.LA(1);
            	
            	if ( (LA61_0 == LID || LA61_0 == 82) )
            	{
            	    alt61 = 1;
            	}
            	switch (alt61) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:140:19: sequenceOrSetBody
            	        {
            	        	PushFollow(FOLLOW_sequenceOrSetBody_in_setType909);
            	        	sequenceOrSetBody();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,75,FOLLOW_75_in_setType913); 
            
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
            int alt63 = 2;
            int LA63_0 = input.LA(1);
            
            if ( (LA63_0 == LID) )
            {
                alt63 = 1;
            }
            else if ( (LA63_0 == 82) )
            {
                alt63 = 2;
            }
            else 
            {
                NoViableAltException nvae_d63s0 =
                    new NoViableAltException("143:1: sequenceOrSetBody : ( componentTypeList ( ',' seqOrSetExtBody )? | seqOrSetExtBody );", 63, 0, input);
            
                throw nvae_d63s0;
            }
            switch (alt63) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:5: componentTypeList ( ',' seqOrSetExtBody )?
                    {
                    	PushFollow(FOLLOW_componentTypeList_in_sequenceOrSetBody930);
                    	componentTypeList();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:23: ( ',' seqOrSetExtBody )?
                    	int alt62 = 2;
                    	int LA62_0 = input.LA(1);
                    	
                    	if ( (LA62_0 == 79) )
                    	{
                    	    alt62 = 1;
                    	}
                    	switch (alt62) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:144:25: ',' seqOrSetExtBody
                    	        {
                    	        	Match(input,79,FOLLOW_79_in_sequenceOrSetBody934); 
                    	        	PushFollow(FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody936);
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
                    	PushFollow(FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody944);
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
            	Match(input,82,FOLLOW_82_in_seqOrSetExtBody956); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:10: ( g_exceptionSpec )?
            	int alt64 = 2;
            	int LA64_0 = input.LA(1);
            	
            	if ( (LA64_0 == 90) )
            	{
            	    alt64 = 1;
            	}
            	switch (alt64) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:10: g_exceptionSpec
            	        {
            	        	PushFollow(FOLLOW_g_exceptionSpec_in_seqOrSetExtBody958);
            	        	g_exceptionSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:27: ( ',' extensionAdditionList )?
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
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:28: ',' extensionAdditionList
            	        {
            	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody962); 
            	        	PushFollow(FOLLOW_extensionAdditionList_in_seqOrSetExtBody964);
            	        	extensionAdditionList();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:56: ( ',' '...' ( ',' componentTypeList )? )?
            	int alt67 = 2;
            	int LA67_0 = input.LA(1);
            	
            	if ( (LA67_0 == 79) )
            	{
            	    alt67 = 1;
            	}
            	switch (alt67) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:57: ',' '...' ( ',' componentTypeList )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody969); 
            	        	Match(input,82,FOLLOW_82_in_seqOrSetExtBody971); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:69: ( ',' componentTypeList )?
            	        	int alt66 = 2;
            	        	int LA66_0 = input.LA(1);
            	        	
            	        	if ( (LA66_0 == 79) )
            	        	{
            	        	    alt66 = 1;
            	        	}
            	        	switch (alt66) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:149:70: ',' componentTypeList
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_seqOrSetExtBody976); 
            	        	        	PushFollow(FOLLOW_componentTypeList_in_seqOrSetExtBody978);
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
            	PushFollow(FOLLOW_extensionAddition_in_extensionAdditionList997);
            	extensionAddition();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:22: ( ',' extensionAddition )*
            	do 
            	{
            	    int alt68 = 2;
            	    int LA68_0 = input.LA(1);
            	    
            	    if ( (LA68_0 == 79) )
            	    {
            	        int LA68_1 = input.LA(2);
            	        
            	        if ( (LA68_1 == LID || LA68_1 == 83) )
            	        {
            	            alt68 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt68) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:153:23: ',' extensionAddition
            			    {
            			    	Match(input,79,FOLLOW_79_in_extensionAdditionList1000); 
            			    	PushFollow(FOLLOW_extensionAddition_in_extensionAdditionList1002);
            			    	extensionAddition();
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
    // $ANTLR end extensionAdditionList

    
    // $ANTLR start extensionAddition
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:156:1: extensionAddition : ( componentType | extensionAdditionGroup );
    public void extensionAddition() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:157:4: ( componentType | extensionAdditionGroup )
            int alt69 = 2;
            int LA69_0 = input.LA(1);
            
            if ( (LA69_0 == LID) )
            {
                alt69 = 1;
            }
            else if ( (LA69_0 == 83) )
            {
                alt69 = 2;
            }
            else 
            {
                NoViableAltException nvae_d69s0 =
                    new NoViableAltException("156:1: extensionAddition : ( componentType | extensionAdditionGroup );", 69, 0, input);
            
                throw nvae_d69s0;
            }
            switch (alt69) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:157:4: componentType
                    {
                    	PushFollow(FOLLOW_componentType_in_extensionAddition1016);
                    	componentType();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:158:10: extensionAdditionGroup
                    {
                    	PushFollow(FOLLOW_extensionAdditionGroup_in_extensionAddition1027);
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
            	Match(input,83,FOLLOW_83_in_extensionAdditionGroup1037); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:9: ( versionNumber )?
            	int alt70 = 2;
            	int LA70_0 = input.LA(1);
            	
            	if ( (LA70_0 == INT) )
            	{
            	    alt70 = 1;
            	}
            	switch (alt70) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:161:9: versionNumber
            	        {
            	        	PushFollow(FOLLOW_versionNumber_in_extensionAdditionGroup1039);
            	        	versionNumber();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_componentTypeList_in_extensionAdditionGroup1042);
            	componentTypeList();
            	followingStackPointer_--;

            	Match(input,84,FOLLOW_84_in_extensionAdditionGroup1044); 
            
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
            	PushFollow(FOLLOW_componentType_in_componentTypeList1056);
            	componentType();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:19: ( ',' componentType )*
            	do 
            	{
            	    int alt71 = 2;
            	    int LA71_0 = input.LA(1);
            	    
            	    if ( (LA71_0 == 79) )
            	    {
            	        int LA71_1 = input.LA(2);
            	        
            	        if ( (LA71_1 == LID) )
            	        {
            	            alt71 = 1;
            	        }
            	        
            	    
            	    }
            	    
            	
            	    switch (alt71) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:165:20: ',' componentType
            			    {
            			    	Match(input,79,FOLLOW_79_in_componentTypeList1060); 
            			    	PushFollow(FOLLOW_componentType_in_componentTypeList1062);
            			    	componentType();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop71;
            	    }
            	} while (true);
            	
            	loop71:
            		;	// Stops C# compiler whinging that label 'loop71' has no statements

            
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
            	PushFollow(FOLLOW_identifier_in_componentType1077);
            	identifier();
            	followingStackPointer_--;

            	PushFollow(FOLLOW_type_in_componentType1079);
            	type();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:20: ( OPTIONAL | DEFAULT value )?
            	int alt72 = 3;
            	int LA72_0 = input.LA(1);
            	
            	if ( (LA72_0 == OPTIONAL) )
            	{
            	    alt72 = 1;
            	}
            	else if ( (LA72_0 == DEFAULT) )
            	{
            	    alt72 = 2;
            	}
            	switch (alt72) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:21: OPTIONAL
            	        {
            	        	Match(input,OPTIONAL,FOLLOW_OPTIONAL_in_componentType1082); 
            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:169:32: DEFAULT value
            	        {
            	        	Match(input,DEFAULT,FOLLOW_DEFAULT_in_componentType1086); 
            	        	PushFollow(FOLLOW_value_in_componentType1088);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF ( identifier )? type | SEQUENCE SIZE valueConstraint OF ( identifier )? type );
    public void sequenceOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:4: ( SEQUENCE ( sizeConstraint )? OF ( identifier )? type | SEQUENCE SIZE valueConstraint OF ( identifier )? type )
            int alt76 = 2;
            int LA76_0 = input.LA(1);
            
            if ( (LA76_0 == SEQUENCE) )
            {
                int LA76_1 = input.LA(2);
                
                if ( (LA76_1 == SIZE) )
                {
                    alt76 = 2;
                }
                else if ( (LA76_1 == OF || LA76_1 == 76) )
                {
                    alt76 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d76s1 =
                        new NoViableAltException("172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF ( identifier )? type | SEQUENCE SIZE valueConstraint OF ( identifier )? type );", 76, 1, input);
                
                    throw nvae_d76s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d76s0 =
                    new NoViableAltException("172:1: sequenceOfType : ( SEQUENCE ( sizeConstraint )? OF ( identifier )? type | SEQUENCE SIZE valueConstraint OF ( identifier )? type );", 76, 0, input);
            
                throw nvae_d76s0;
            }
            switch (alt76) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:4: SEQUENCE ( sizeConstraint )? OF ( identifier )? type
                    {
                    	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType1103); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:13: ( sizeConstraint )?
                    	int alt73 = 2;
                    	int LA73_0 = input.LA(1);
                    	
                    	if ( (LA73_0 == 76) )
                    	{
                    	    alt73 = 1;
                    	}
                    	switch (alt73) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:13: sizeConstraint
                    	        {
                    	        	PushFollow(FOLLOW_sizeConstraint_in_sequenceOfType1105);
                    	        	sizeConstraint();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,OF,FOLLOW_OF_in_sequenceOfType1108); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:32: ( identifier )?
                    	int alt74 = 2;
                    	int LA74_0 = input.LA(1);
                    	
                    	if ( (LA74_0 == LID) )
                    	{
                    	    alt74 = 1;
                    	}
                    	switch (alt74) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:173:33: identifier
                    	        {
                    	        	PushFollow(FOLLOW_identifier_in_sequenceOfType1111);
                    	        	identifier();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_type_in_sequenceOfType1115);
                    	type();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:4: SEQUENCE SIZE valueConstraint OF ( identifier )? type
                    {
                    	Match(input,SEQUENCE,FOLLOW_SEQUENCE_in_sequenceOfType1120); 
                    	Match(input,SIZE,FOLLOW_SIZE_in_sequenceOfType1122); 
                    	PushFollow(FOLLOW_valueConstraint_in_sequenceOfType1124);
                    	valueConstraint();
                    	followingStackPointer_--;

                    	Match(input,OF,FOLLOW_OF_in_sequenceOfType1126); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:37: ( identifier )?
                    	int alt75 = 2;
                    	int LA75_0 = input.LA(1);
                    	
                    	if ( (LA75_0 == LID) )
                    	{
                    	    alt75 = 1;
                    	}
                    	switch (alt75) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:174:38: identifier
                    	        {
                    	        	PushFollow(FOLLOW_identifier_in_sequenceOfType1129);
                    	        	identifier();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_type_in_sequenceOfType1133);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:177:1: setOfType : ( SET ( sizeConstraint )? OF ( identifier )? type | SET SIZE valueConstraint OF ( identifier )? type );
    public void setOfType() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:4: ( SET ( sizeConstraint )? OF ( identifier )? type | SET SIZE valueConstraint OF ( identifier )? type )
            int alt80 = 2;
            int LA80_0 = input.LA(1);
            
            if ( (LA80_0 == SET) )
            {
                int LA80_1 = input.LA(2);
                
                if ( (LA80_1 == SIZE) )
                {
                    alt80 = 2;
                }
                else if ( (LA80_1 == OF || LA80_1 == 76) )
                {
                    alt80 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d80s1 =
                        new NoViableAltException("177:1: setOfType : ( SET ( sizeConstraint )? OF ( identifier )? type | SET SIZE valueConstraint OF ( identifier )? type );", 80, 1, input);
                
                    throw nvae_d80s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d80s0 =
                    new NoViableAltException("177:1: setOfType : ( SET ( sizeConstraint )? OF ( identifier )? type | SET SIZE valueConstraint OF ( identifier )? type );", 80, 0, input);
            
                throw nvae_d80s0;
            }
            switch (alt80) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:4: SET ( sizeConstraint )? OF ( identifier )? type
                    {
                    	Match(input,SET,FOLLOW_SET_in_setOfType1145); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:8: ( sizeConstraint )?
                    	int alt77 = 2;
                    	int LA77_0 = input.LA(1);
                    	
                    	if ( (LA77_0 == 76) )
                    	{
                    	    alt77 = 1;
                    	}
                    	switch (alt77) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:8: sizeConstraint
                    	        {
                    	        	PushFollow(FOLLOW_sizeConstraint_in_setOfType1147);
                    	        	sizeConstraint();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,OF,FOLLOW_OF_in_setOfType1150); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:27: ( identifier )?
                    	int alt78 = 2;
                    	int LA78_0 = input.LA(1);
                    	
                    	if ( (LA78_0 == LID) )
                    	{
                    	    alt78 = 1;
                    	}
                    	switch (alt78) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:178:28: identifier
                    	        {
                    	        	PushFollow(FOLLOW_identifier_in_setOfType1153);
                    	        	identifier();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_type_in_setOfType1157);
                    	type();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:179:4: SET SIZE valueConstraint OF ( identifier )? type
                    {
                    	Match(input,SET,FOLLOW_SET_in_setOfType1162); 
                    	Match(input,SIZE,FOLLOW_SIZE_in_setOfType1164); 
                    	PushFollow(FOLLOW_valueConstraint_in_setOfType1166);
                    	valueConstraint();
                    	followingStackPointer_--;

                    	Match(input,OF,FOLLOW_OF_in_setOfType1168); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:179:32: ( identifier )?
                    	int alt79 = 2;
                    	int LA79_0 = input.LA(1);
                    	
                    	if ( (LA79_0 == LID) )
                    	{
                    	    alt79 = 1;
                    	}
                    	switch (alt79) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:179:33: identifier
                    	        {
                    	        	PushFollow(FOLLOW_identifier_in_setOfType1171);
                    	        	identifier();
                    	        	followingStackPointer_--;

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_type_in_setOfType1175);
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
            int alt81 = 12;
            switch ( input.LA(1) ) 
            {
            case OCTET:
            	{
                alt81 = 1;
                }
                break;
            case NumericString:
            	{
                alt81 = 2;
                }
                break;
            case PrintableString:
            	{
                alt81 = 3;
                }
                break;
            case VisibleString:
            	{
                alt81 = 4;
                }
                break;
            case IA5String:
            	{
                alt81 = 5;
                }
                break;
            case TeletexString:
            	{
                alt81 = 6;
                }
                break;
            case VideotexString:
            	{
                alt81 = 7;
                }
                break;
            case GraphicString:
            	{
                alt81 = 8;
                }
                break;
            case GeneralString:
            	{
                alt81 = 9;
                }
                break;
            case UniversalString:
            	{
                alt81 = 10;
                }
                break;
            case BMPString:
            	{
                alt81 = 11;
                }
                break;
            case UTF8String:
            	{
                alt81 = 12;
                }
                break;
            	default:
            	    NoViableAltException nvae_d81s0 =
            	        new NoViableAltException("183:1: stringType : ( OCTET STRING | NumericString | PrintableString | VisibleString | IA5String | TeletexString | VideotexString | GraphicString | GeneralString | UniversalString | BMPString | UTF8String );", 81, 0, input);
            
            	    throw nvae_d81s0;
            }
            
            switch (alt81) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:184:3: OCTET STRING
                    {
                    	Match(input,OCTET,FOLLOW_OCTET_in_stringType1191); 
                    	Match(input,STRING,FOLLOW_STRING_in_stringType1193); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:185:3: NumericString
                    {
                    	Match(input,NumericString,FOLLOW_NumericString_in_stringType1197); 
                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:186:3: PrintableString
                    {
                    	Match(input,PrintableString,FOLLOW_PrintableString_in_stringType1201); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:187:3: VisibleString
                    {
                    	Match(input,VisibleString,FOLLOW_VisibleString_in_stringType1205); 
                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:188:3: IA5String
                    {
                    	Match(input,IA5String,FOLLOW_IA5String_in_stringType1209); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:189:3: TeletexString
                    {
                    	Match(input,TeletexString,FOLLOW_TeletexString_in_stringType1213); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:190:3: VideotexString
                    {
                    	Match(input,VideotexString,FOLLOW_VideotexString_in_stringType1217); 
                    
                    }
                    break;
                case 8 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:191:3: GraphicString
                    {
                    	Match(input,GraphicString,FOLLOW_GraphicString_in_stringType1221); 
                    
                    }
                    break;
                case 9 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:192:3: GeneralString
                    {
                    	Match(input,GeneralString,FOLLOW_GeneralString_in_stringType1225); 
                    
                    }
                    break;
                case 10 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:193:3: UniversalString
                    {
                    	Match(input,UniversalString,FOLLOW_UniversalString_in_stringType1229); 
                    
                    }
                    break;
                case 11 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:194:3: BMPString
                    {
                    	Match(input,BMPString,FOLLOW_BMPString_in_stringType1233); 
                    
                    }
                    break;
                case 12 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:195:3: UTF8String
                    {
                    	Match(input,UTF8String,FOLLOW_UTF8String_in_stringType1237); 
                    
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
            	Match(input,UID,FOLLOW_UID_in_referencedType1249); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:8: ( '.' UID )?
            	int alt82 = 2;
            	int LA82_0 = input.LA(1);
            	
            	if ( (LA82_0 == 85) )
            	{
            	    alt82 = 1;
            	}
            	switch (alt82) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:199:9: '.' UID
            	        {
            	        	Match(input,85,FOLLOW_85_in_referencedType1252); 
            	        	Match(input,UID,FOLLOW_UID_in_referencedType1254); 
            	        
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
            	Match(input,OBJECT,FOLLOW_OBJECT_in_objectIdentifier1268); 
            	Match(input,IDENTIFIER,FOLLOW_IDENTIFIER_in_objectIdentifier1270); 
            
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
            	Match(input,RELATIVE_OID,FOLLOW_RELATIVE_OID_in_relativeOID1278); 
            
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
            	int alt83 = 2;
            	int LA83_0 = input.LA(1);
            	
            	if ( ((LA83_0 >= 86 && LA83_0 <= 87)) )
            	{
            	    alt83 = 1;
            	}
            	switch (alt83) 
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
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_signedNumber1289);    throw mse;
            	        	}

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,INT,FOLLOW_INT_in_signedNumber1296); 
            
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
            int alt84 = 4;
            int LA84_0 = input.LA(1);
            
            if ( (LA84_0 == 76) )
            {
                switch ( input.LA(2) ) 
                {
                case SIZE:
                	{
                    alt84 = 2;
                    }
                    break;
                case WITH:
                	{
                    alt84 = 3;
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
                    alt84 = 1;
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
                    alt84 = 4;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d84s1 =
                	        new NoViableAltException("212:1: constraint : ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint );", 84, 1, input);
                
                	    throw nvae_d84s1;
                }
            
            }
            else 
            {
                NoViableAltException nvae_d84s0 =
                    new NoViableAltException("212:1: constraint : ( valueConstraint | sizeConstraint | withComponentsConstraint | subTypeConstraint );", 84, 0, input);
            
                throw nvae_d84s0;
            }
            switch (alt84) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:213:4: valueConstraint
                    {
                    	PushFollow(FOLLOW_valueConstraint_in_constraint1307);
                    	valueConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:214:4: sizeConstraint
                    {
                    	PushFollow(FOLLOW_sizeConstraint_in_constraint1312);
                    	sizeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:215:4: withComponentsConstraint
                    {
                    	PushFollow(FOLLOW_withComponentsConstraint_in_constraint1317);
                    	withComponentsConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:216:4: subTypeConstraint
                    {
                    	PushFollow(FOLLOW_subTypeConstraint_in_constraint1322);
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
            	Match(input,76,FOLLOW_76_in_valueConstraint1338); 
            	PushFollow(FOLLOW_value_in_valueConstraint1340);
            	value();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:14: ( ( '<' )? '..' ( '<' )? value )?
            	int alt87 = 2;
            	int LA87_0 = input.LA(1);
            	
            	if ( ((LA87_0 >= 88 && LA87_0 <= 89)) )
            	{
            	    alt87 = 1;
            	}
            	switch (alt87) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:16: ( '<' )? '..' ( '<' )? value
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:16: ( '<' )?
            	        	int alt85 = 2;
            	        	int LA85_0 = input.LA(1);
            	        	
            	        	if ( (LA85_0 == 88) )
            	        	{
            	        	    alt85 = 1;
            	        	}
            	        	switch (alt85) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:17: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_valueConstraint1345); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,89,FOLLOW_89_in_valueConstraint1349); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:28: ( '<' )?
            	        	int alt86 = 2;
            	        	int LA86_0 = input.LA(1);
            	        	
            	        	if ( (LA86_0 == 88) )
            	        	{
            	        	    alt86 = 1;
            	        	}
            	        	switch (alt86) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:222:29: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_valueConstraint1352); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	PushFollow(FOLLOW_value_in_valueConstraint1356);
            	        	value();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,77,FOLLOW_77_in_valueConstraint1360); 
            
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
            	Match(input,76,FOLLOW_76_in_sizeConstraint1371); 
            	Match(input,SIZE,FOLLOW_SIZE_in_sizeConstraint1373); 
            	PushFollow(FOLLOW_valueConstraint_in_sizeConstraint1375);
            	valueConstraint();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_sizeConstraint1377); 
            
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
            	Match(input,76,FOLLOW_76_in_permittedAlphabetConstraint1390); 
            	Match(input,FROM,FOLLOW_FROM_in_permittedAlphabetConstraint1392); 
            	PushFollow(FOLLOW_valueConstraint_in_permittedAlphabetConstraint1394);
            	valueConstraint();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_permittedAlphabetConstraint1396); 
            
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
            	Match(input,76,FOLLOW_76_in_subTypeConstraint1409); 
            	PushFollow(FOLLOW_type_in_subTypeConstraint1411);
            	type();
            	followingStackPointer_--;

            	Match(input,77,FOLLOW_77_in_subTypeConstraint1413); 
            
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
            	Match(input,76,FOLLOW_76_in_withComponentsConstraint1428); 
            	Match(input,WITH,FOLLOW_WITH_in_withComponentsConstraint1431); 
            	Match(input,COMPONENTS,FOLLOW_COMPONENTS_in_withComponentsConstraint1433); 
            	Match(input,74,FOLLOW_74_in_withComponentsConstraint1435); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:4: ( '...' ',' )?
            	int alt88 = 2;
            	int LA88_0 = input.LA(1);
            	
            	if ( (LA88_0 == 82) )
            	{
            	    alt88 = 1;
            	}
            	switch (alt88) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:239:6: '...' ','
            	        {
            	        	Match(input,82,FOLLOW_82_in_withComponentsConstraint1442); 
            	        	Match(input,79,FOLLOW_79_in_withComponentsConstraint1444); 
            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint1451);
            	namedConstraint();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:21: ( ',' namedConstraint )*
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
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:240:22: ',' namedConstraint
            			    {
            			    	Match(input,79,FOLLOW_79_in_withComponentsConstraint1455); 
            			    	PushFollow(FOLLOW_namedConstraint_in_withComponentsConstraint1457);
            			    	namedConstraint();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop89;
            	    }
            	} while (true);
            	
            	loop89:
            		;	// Stops C# compiler whinging that label 'loop89' has no statements

            	Match(input,75,FOLLOW_75_in_withComponentsConstraint1463); 
            	Match(input,77,FOLLOW_77_in_withComponentsConstraint1467); 
            
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
            	PushFollow(FOLLOW_identifier_in_namedConstraint1479);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:15: ( valueConstraint )?
            	int alt90 = 2;
            	int LA90_0 = input.LA(1);
            	
            	if ( (LA90_0 == 76) )
            	{
            	    alt90 = 1;
            	}
            	switch (alt90) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:16: valueConstraint
            	        {
            	        	PushFollow(FOLLOW_valueConstraint_in_namedConstraint1482);
            	        	valueConstraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:246:34: ( PRESENT | ABSENT | OPTIONAL )?
            	int alt91 = 2;
            	int LA91_0 = input.LA(1);
            	
            	if ( (LA91_0 == OPTIONAL || (LA91_0 >= PRESENT && LA91_0 <= ABSENT)) )
            	{
            	    alt91 = 1;
            	}
            	switch (alt91) 
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
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_namedConstraint1486);    throw mse;
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX | objectIdentifierValue );
    public void value() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:3: ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX | objectIdentifierValue )
            int alt95 = 11;
            switch ( input.LA(1) ) 
            {
            case BitStringLiteral:
            	{
                alt95 = 1;
                }
                break;
            case 74:
            	{
                int LA95_2 = input.LA(2);
                
                if ( (LA95_2 == LID) )
                {
                    switch ( input.LA(3) ) 
                    {
                    case 79:
                    	{
                        alt95 = 2;
                        }
                        break;
                    case 75:
                    	{
                        alt95 = 2;
                        }
                        break;
                    case INT:
                    case UID:
                    case LID:
                    case 76:
                    	{
                        alt95 = 11;
                        }
                        break;
                    	default:
                    	    NoViableAltException nvae_d95s11 =
                    	        new NoViableAltException("248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX | objectIdentifierValue );", 95, 11, input);
                    
                    	    throw nvae_d95s11;
                    }
                
                }
                else if ( (LA95_2 == INT || LA95_2 == UID) )
                {
                    alt95 = 11;
                }
                else 
                {
                    NoViableAltException nvae_d95s2 =
                        new NoViableAltException("248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX | objectIdentifierValue );", 95, 2, input);
                
                    throw nvae_d95s2;
                }
                }
                break;
            case OctectStringLiteral:
            	{
                alt95 = 3;
                }
                break;
            case TRUE:
            	{
                alt95 = 4;
                }
                break;
            case FALSE:
            	{
                alt95 = 5;
                }
                break;
            case StringLiteral:
            	{
                alt95 = 6;
                }
                break;
            case LID:
            	{
                alt95 = 7;
                }
                break;
            case INT:
            case 86:
            case 87:
            	{
                alt95 = 8;
                }
                break;
            case MIN:
            	{
                alt95 = 9;
                }
                break;
            case MAX:
            	{
                alt95 = 10;
                }
                break;
            	default:
            	    NoViableAltException nvae_d95s0 =
            	        new NoViableAltException("248:1: value : ( BitStringLiteral | bitStringValue | OctectStringLiteral | TRUE | FALSE | StringLiteral | valuereference | ( '+' | '-' )? INT ( '.' ( INT )? )? | MIN | MAX | objectIdentifierValue );", 95, 0, input);
            
            	    throw nvae_d95s0;
            }
            
            switch (alt95) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:249:3: BitStringLiteral
                    {
                    	Match(input,BitStringLiteral,FOLLOW_BitStringLiteral_in_value1506); 
                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:250:4: bitStringValue
                    {
                    	PushFollow(FOLLOW_bitStringValue_in_value1511);
                    	bitStringValue();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:251:4: OctectStringLiteral
                    {
                    	Match(input,OctectStringLiteral,FOLLOW_OctectStringLiteral_in_value1516); 
                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:252:4: TRUE
                    {
                    	Match(input,TRUE,FOLLOW_TRUE_in_value1521); 
                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:253:4: FALSE
                    {
                    	Match(input,FALSE,FOLLOW_FALSE_in_value1526); 
                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:254:4: StringLiteral
                    {
                    	Match(input,StringLiteral,FOLLOW_StringLiteral_in_value1531); 
                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:255:4: valuereference
                    {
                    	PushFollow(FOLLOW_valuereference_in_value1536);
                    	valuereference();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 8 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:4: ( '+' | '-' )? INT ( '.' ( INT )? )?
                    {
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:4: ( '+' | '-' )?
                    	int alt92 = 2;
                    	int LA92_0 = input.LA(1);
                    	
                    	if ( ((LA92_0 >= 86 && LA92_0 <= 87)) )
                    	{
                    	    alt92 = 1;
                    	}
                    	switch (alt92) 
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
                    	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_value1543);    throw mse;
                    	        	}

                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	Match(input,INT,FOLLOW_INT_in_value1550); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:19: ( '.' ( INT )? )?
                    	int alt94 = 2;
                    	int LA94_0 = input.LA(1);
                    	
                    	if ( (LA94_0 == 85) )
                    	{
                    	    alt94 = 1;
                    	}
                    	switch (alt94) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:20: '.' ( INT )?
                    	        {
                    	        	Match(input,85,FOLLOW_85_in_value1553); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:24: ( INT )?
                    	        	int alt93 = 2;
                    	        	int LA93_0 = input.LA(1);
                    	        	
                    	        	if ( (LA93_0 == INT) )
                    	        	{
                    	        	    alt93 = 1;
                    	        	}
                    	        	switch (alt93) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:256:24: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_value1555); 
                    	        	        
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
                    	Match(input,MIN,FOLLOW_MIN_in_value1565); 
                    
                    }
                    break;
                case 10 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:259:4: MAX
                    {
                    	Match(input,MAX,FOLLOW_MAX_in_value1570); 
                    
                    }
                    break;
                case 11 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:260:4: objectIdentifierValue
                    {
                    	PushFollow(FOLLOW_objectIdentifierValue_in_value1575);
                    	objectIdentifierValue();
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
    // $ANTLR end value

    
    // $ANTLR start bitStringValue
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:263:1: bitStringValue : '{' identifier ( ',' identifier )* '}' ;
    public void bitStringValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:4: ( '{' identifier ( ',' identifier )* '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:4: '{' identifier ( ',' identifier )* '}'
            {
            	Match(input,74,FOLLOW_74_in_bitStringValue1588); 
            	PushFollow(FOLLOW_identifier_in_bitStringValue1590);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:19: ( ',' identifier )*
            	do 
            	{
            	    int alt96 = 2;
            	    int LA96_0 = input.LA(1);
            	    
            	    if ( (LA96_0 == 79) )
            	    {
            	        alt96 = 1;
            	    }
            	    
            	
            	    switch (alt96) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:264:20: ',' identifier
            			    {
            			    	Match(input,79,FOLLOW_79_in_bitStringValue1593); 
            			    	PushFollow(FOLLOW_identifier_in_bitStringValue1595);
            			    	identifier();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop96;
            	    }
            	} while (true);
            	
            	loop96:
            		;	// Stops C# compiler whinging that label 'loop96' has no statements

            	Match(input,75,FOLLOW_75_in_bitStringValue1599); 
            
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

    
    // $ANTLR start objectIdentifierValue
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:267:1: objectIdentifierValue : '{' ( objectIdentifierComponent )+ '}' ;
    public void objectIdentifierValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:4: ( '{' ( objectIdentifierComponent )+ '}' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:4: '{' ( objectIdentifierComponent )+ '}'
            {
            	Match(input,74,FOLLOW_74_in_objectIdentifierValue1611); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:8: ( objectIdentifierComponent )+
            	int cnt97 = 0;
            	do 
            	{
            	    int alt97 = 2;
            	    int LA97_0 = input.LA(1);
            	    
            	    if ( (LA97_0 == INT || LA97_0 == UID || LA97_0 == LID) )
            	    {
            	        alt97 = 1;
            	    }
            	    
            	
            	    switch (alt97) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:268:8: objectIdentifierComponent
            			    {
            			    	PushFollow(FOLLOW_objectIdentifierComponent_in_objectIdentifierValue1613);
            			    	objectIdentifierComponent();
            			    	followingStackPointer_--;

            			    
            			    }
            			    break;
            	
            			default:
            			    if ( cnt97 >= 1 ) goto loop97;
            		            EarlyExitException eee =
            		                new EarlyExitException(97, input);
            		            throw eee;
            	    }
            	    cnt97++;
            	} while (true);
            	
            	loop97:
            		;	// Stops C# compiler whinging that label 'loop97' has no statements

            	Match(input,75,FOLLOW_75_in_objectIdentifierValue1617); 
            
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
    // $ANTLR end objectIdentifierValue

    
    // $ANTLR start objectIdentifierComponent
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:270:1: objectIdentifierComponent : ( identifier ( '(' ( INT | definedValue ) ')' )? | INT | modulereference '.' valuereference );
    public void objectIdentifierComponent() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:4: ( identifier ( '(' ( INT | definedValue ) ')' )? | INT | modulereference '.' valuereference )
            int alt100 = 3;
            switch ( input.LA(1) ) 
            {
            case LID:
            	{
                alt100 = 1;
                }
                break;
            case INT:
            	{
                alt100 = 2;
                }
                break;
            case UID:
            	{
                alt100 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d100s0 =
            	        new NoViableAltException("270:1: objectIdentifierComponent : ( identifier ( '(' ( INT | definedValue ) ')' )? | INT | modulereference '.' valuereference );", 100, 0, input);
            
            	    throw nvae_d100s0;
            }
            
            switch (alt100) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:4: identifier ( '(' ( INT | definedValue ) ')' )?
                    {
                    	PushFollow(FOLLOW_identifier_in_objectIdentifierComponent1628);
                    	identifier();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:15: ( '(' ( INT | definedValue ) ')' )?
                    	int alt99 = 2;
                    	int LA99_0 = input.LA(1);
                    	
                    	if ( (LA99_0 == 76) )
                    	{
                    	    alt99 = 1;
                    	}
                    	switch (alt99) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:16: '(' ( INT | definedValue ) ')'
                    	        {
                    	        	Match(input,76,FOLLOW_76_in_objectIdentifierComponent1631); 
                    	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:20: ( INT | definedValue )
                    	        	int alt98 = 2;
                    	        	int LA98_0 = input.LA(1);
                    	        	
                    	        	if ( (LA98_0 == INT) )
                    	        	{
                    	        	    alt98 = 1;
                    	        	}
                    	        	else if ( (LA98_0 == UID || LA98_0 == LID) )
                    	        	{
                    	        	    alt98 = 2;
                    	        	}
                    	        	else 
                    	        	{
                    	        	    NoViableAltException nvae_d98s0 =
                    	        	        new NoViableAltException("271:20: ( INT | definedValue )", 98, 0, input);
                    	        	
                    	        	    throw nvae_d98s0;
                    	        	}
                    	        	switch (alt98) 
                    	        	{
                    	        	    case 1 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:21: INT
                    	        	        {
                    	        	        	Match(input,INT,FOLLOW_INT_in_objectIdentifierComponent1634); 
                    	        	        
                    	        	        }
                    	        	        break;
                    	        	    case 2 :
                    	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:271:27: definedValue
                    	        	        {
                    	        	        	PushFollow(FOLLOW_definedValue_in_objectIdentifierComponent1638);
                    	        	        	definedValue();
                    	        	        	followingStackPointer_--;

                    	        	        
                    	        	        }
                    	        	        break;
                    	        	
                    	        	}

                    	        	Match(input,77,FOLLOW_77_in_objectIdentifierComponent1641); 
                    	        
                    	        }
                    	        break;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:272:5: INT
                    {
                    	Match(input,INT,FOLLOW_INT_in_objectIdentifierComponent1651); 
                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:273:4: modulereference '.' valuereference
                    {
                    	PushFollow(FOLLOW_modulereference_in_objectIdentifierComponent1656);
                    	modulereference();
                    	followingStackPointer_--;

                    	Match(input,85,FOLLOW_85_in_objectIdentifierComponent1658); 
                    	PushFollow(FOLLOW_valuereference_in_objectIdentifierComponent1660);
                    	valuereference();
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
    // $ANTLR end objectIdentifierComponent

    
    // $ANTLR start definedValue
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:277:1: definedValue : ( valuereference | modulereference '.' valuereference );
    public void definedValue() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:278:4: ( valuereference | modulereference '.' valuereference )
            int alt101 = 2;
            int LA101_0 = input.LA(1);
            
            if ( (LA101_0 == LID) )
            {
                alt101 = 1;
            }
            else if ( (LA101_0 == UID) )
            {
                alt101 = 2;
            }
            else 
            {
                NoViableAltException nvae_d101s0 =
                    new NoViableAltException("277:1: definedValue : ( valuereference | modulereference '.' valuereference );", 101, 0, input);
            
                throw nvae_d101s0;
            }
            switch (alt101) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:278:4: valuereference
                    {
                    	PushFollow(FOLLOW_valuereference_in_definedValue1673);
                    	valuereference();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:279:5: modulereference '.' valuereference
                    {
                    	PushFollow(FOLLOW_modulereference_in_definedValue1679);
                    	modulereference();
                    	followingStackPointer_--;

                    	Match(input,85,FOLLOW_85_in_definedValue1681); 
                    	PushFollow(FOLLOW_valuereference_in_definedValue1683);
                    	valuereference();
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
    // $ANTLR end definedValue

    
    // $ANTLR start lID
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:282:1: lID : LID ;
    public void lID() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:282:7: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:282:7: LID
            {
            	Match(input,LID,FOLLOW_LID_in_lID1693); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:284:1: modulereference : UID ;
    public void modulereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:284:19: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:284:19: UID
            {
            	Match(input,UID,FOLLOW_UID_in_modulereference1701); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:1: typereference : UID ;
    public void typereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:17: ( UID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:286:17: UID
            {
            	Match(input,UID,FOLLOW_UID_in_typereference1709); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:288:1: valuereference : LID ;
    public void valuereference() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:288:19: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:288:19: LID
            {
            	Match(input,LID,FOLLOW_LID_in_valuereference1719); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:1: identifier : LID ;
    public void identifier() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:14: ( LID )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:290:14: LID
            {
            	Match(input,LID,FOLLOW_LID_in_identifier1729); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:292:1: versionNumber : INT ;
    public void versionNumber() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:292:17: ( INT )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:292:17: INT
            {
            	Match(input,INT,FOLLOW_INT_in_versionNumber1737); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:300:1: g_constraint : '(' g_subtypeConstraint ( g_exceptionSpec )? ')' ;
    public void g_constraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:4: ( '(' g_subtypeConstraint ( g_exceptionSpec )? ')' )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:4: '(' g_subtypeConstraint ( g_exceptionSpec )? ')'
            {
            	Match(input,76,FOLLOW_76_in_g_constraint1757); 
            	PushFollow(FOLLOW_g_subtypeConstraint_in_g_constraint1759);
            	g_subtypeConstraint();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:29: ( g_exceptionSpec )?
            	int alt102 = 2;
            	int LA102_0 = input.LA(1);
            	
            	if ( (LA102_0 == 90) )
            	{
            	    alt102 = 1;
            	}
            	switch (alt102) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:301:29: g_exceptionSpec
            	        {
            	        	PushFollow(FOLLOW_g_exceptionSpec_in_g_constraint1762);
            	        	g_exceptionSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	Match(input,77,FOLLOW_77_in_g_constraint1765); 
            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:304:1: g_exceptionSpec : '!' ( signedNumber | valuereference | type ':' value ) ;
    public void g_exceptionSpec() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:305:4: ( '!' ( signedNumber | valuereference | type ':' value ) )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:305:4: '!' ( signedNumber | valuereference | type ':' value )
            {
            	Match(input,90,FOLLOW_90_in_g_exceptionSpec1777); 
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:306:2: ( signedNumber | valuereference | type ':' value )
            	int alt103 = 3;
            	switch ( input.LA(1) ) 
            	{
            	case INT:
            	case 86:
            	case 87:
            		{
            	    alt103 = 1;
            	    }
            	    break;
            	case LID:
            		{
            	    alt103 = 2;
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
            	    alt103 = 3;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d103s0 =
            		        new NoViableAltException("306:2: ( signedNumber | valuereference | type ':' value )", 103, 0, input);
            	
            		    throw nvae_d103s0;
            	}
            	
            	switch (alt103) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:307:4: signedNumber
            	        {
            	        	PushFollow(FOLLOW_signedNumber_in_g_exceptionSpec1786);
            	        	signedNumber();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 2 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:308:4: valuereference
            	        {
            	        	PushFollow(FOLLOW_valuereference_in_g_exceptionSpec1791);
            	        	valuereference();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	    case 3 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:309:6: type ':' value
            	        {
            	        	PushFollow(FOLLOW_type_in_g_exceptionSpec1798);
            	        	type();
            	        	followingStackPointer_--;

            	        	Match(input,91,FOLLOW_91_in_g_exceptionSpec1800); 
            	        	PushFollow(FOLLOW_value_in_g_exceptionSpec1802);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:314:1: g_subtypeConstraint : g_elementSetSpecs ;
    public void g_subtypeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:4: ( g_elementSetSpecs )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:315:4: g_elementSetSpecs
            {
            	PushFollow(FOLLOW_g_elementSetSpecs_in_g_subtypeConstraint1817);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:317:1: g_elementSetSpecs : g_unionElement ( ',' '...' ( ',' g_unionElement )? )? ;
    public void g_elementSetSpecs() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:4: ( g_unionElement ( ',' '...' ( ',' g_unionElement )? )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:4: g_unionElement ( ',' '...' ( ',' g_unionElement )? )?
            {
            	PushFollow(FOLLOW_g_unionElement_in_g_elementSetSpecs1826);
            	g_unionElement();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:19: ( ',' '...' ( ',' g_unionElement )? )?
            	int alt105 = 2;
            	int LA105_0 = input.LA(1);
            	
            	if ( (LA105_0 == 79) )
            	{
            	    alt105 = 1;
            	}
            	switch (alt105) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:20: ',' '...' ( ',' g_unionElement )?
            	        {
            	        	Match(input,79,FOLLOW_79_in_g_elementSetSpecs1829); 
            	        	Match(input,82,FOLLOW_82_in_g_elementSetSpecs1831); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:30: ( ',' g_unionElement )?
            	        	int alt104 = 2;
            	        	int LA104_0 = input.LA(1);
            	        	
            	        	if ( (LA104_0 == 79) )
            	        	{
            	        	    alt104 = 1;
            	        	}
            	        	switch (alt104) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:318:32: ',' g_unionElement
            	        	        {
            	        	        	Match(input,79,FOLLOW_79_in_g_elementSetSpecs1835); 
            	        	        	PushFollow(FOLLOW_g_unionElement_in_g_elementSetSpecs1837);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:320:1: g_unionElement : ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec );
    public void g_unionElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:4: ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec )
            int alt107 = 2;
            int LA107_0 = input.LA(1);
            
            if ( (LA107_0 == INT || LA107_0 == FROM || (LA107_0 >= NULL && LA107_0 <= BIT) || (LA107_0 >= BOOLEAN && LA107_0 <= SET) || (LA107_0 >= SIZE && LA107_0 <= OBJECT) || (LA107_0 >= RELATIVE_OID && LA107_0 <= WITH) || (LA107_0 >= BitStringLiteral && LA107_0 <= LID) || LA107_0 == INCLUDES || LA107_0 == PATTERN || LA107_0 == 74 || LA107_0 == 76 || LA107_0 == 80 || (LA107_0 >= 86 && LA107_0 <= 87)) )
            {
                alt107 = 1;
            }
            else if ( (LA107_0 == ALL) )
            {
                alt107 = 2;
            }
            else 
            {
                NoViableAltException nvae_d107s0 =
                    new NoViableAltException("320:1: g_unionElement : ( g_intersectionElement ( UnionMark g_intersectionElement )* | ALL EXCEPT g_elementSetSpec );", 107, 0, input);
            
                throw nvae_d107s0;
            }
            switch (alt107) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:4: g_intersectionElement ( UnionMark g_intersectionElement )*
                    {
                    	PushFollow(FOLLOW_g_intersectionElement_in_g_unionElement1851);
                    	g_intersectionElement();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:26: ( UnionMark g_intersectionElement )*
                    	do 
                    	{
                    	    int alt106 = 2;
                    	    int LA106_0 = input.LA(1);
                    	    
                    	    if ( (LA106_0 == UnionMark) )
                    	    {
                    	        alt106 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt106) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:321:27: UnionMark g_intersectionElement
                    			    {
                    			    	Match(input,UnionMark,FOLLOW_UnionMark_in_g_unionElement1854); 
                    			    	PushFollow(FOLLOW_g_intersectionElement_in_g_unionElement1856);
                    			    	g_intersectionElement();
                    			    	followingStackPointer_--;

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop106;
                    	    }
                    	} while (true);
                    	
                    	loop106:
                    		;	// Stops C# compiler whinging that label 'loop106' has no statements

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:322:4: ALL EXCEPT g_elementSetSpec
                    {
                    	Match(input,ALL,FOLLOW_ALL_in_g_unionElement1863); 
                    	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_unionElement1865); 
                    	PushFollow(FOLLOW_g_elementSetSpec_in_g_unionElement1867);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:325:1: g_intersectionElement : g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )* ;
    public void g_intersectionElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:4: ( g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )* )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:4: g_elementSetSpec ( EXCEPT g_elementSetSpec )? ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )*
            {
            	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1880);
            	g_elementSetSpec();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:21: ( EXCEPT g_elementSetSpec )?
            	int alt108 = 2;
            	int LA108_0 = input.LA(1);
            	
            	if ( (LA108_0 == EXCEPT) )
            	{
            	    alt108 = 1;
            	}
            	switch (alt108) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:22: EXCEPT g_elementSetSpec
            	        {
            	        	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_intersectionElement1883); 
            	        	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1885);
            	        	g_elementSetSpec();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:48: ( IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )? )*
            	do 
            	{
            	    int alt110 = 2;
            	    int LA110_0 = input.LA(1);
            	    
            	    if ( (LA110_0 == IntersectionMark) )
            	    {
            	        alt110 = 1;
            	    }
            	    
            	
            	    switch (alt110) 
            		{
            			case 1 :
            			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:49: IntersectionMark g_elementSetSpec ( EXCEPT g_elementSetSpec )?
            			    {
            			    	Match(input,IntersectionMark,FOLLOW_IntersectionMark_in_g_intersectionElement1890); 
            			    	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1892);
            			    	g_elementSetSpec();
            			    	followingStackPointer_--;

            			    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:83: ( EXCEPT g_elementSetSpec )?
            			    	int alt109 = 2;
            			    	int LA109_0 = input.LA(1);
            			    	
            			    	if ( (LA109_0 == EXCEPT) )
            			    	{
            			    	    alt109 = 1;
            			    	}
            			    	switch (alt109) 
            			    	{
            			    	    case 1 :
            			    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:326:84: EXCEPT g_elementSetSpec
            			    	        {
            			    	        	Match(input,EXCEPT,FOLLOW_EXCEPT_in_g_intersectionElement1895); 
            			    	        	PushFollow(FOLLOW_g_elementSetSpec_in_g_intersectionElement1897);
            			    	        	g_elementSetSpec();
            			    	        	followingStackPointer_--;

            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop110;
            	    }
            	} while (true);
            	
            	loop110:
            		;	// Stops C# compiler whinging that label 'loop110' has no statements

            
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:329:1: g_elementSetSpec : ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' );
    public void g_elementSetSpec() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:330:4: ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' )
            int alt111 = 7;
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
                alt111 = 1;
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
                alt111 = 2;
                }
                break;
            case SIZE:
            	{
                alt111 = 3;
                }
                break;
            case FROM:
            	{
                alt111 = 4;
                }
                break;
            case WITH:
            	{
                alt111 = 5;
                }
                break;
            case PATTERN:
            	{
                alt111 = 6;
                }
                break;
            case 76:
            	{
                alt111 = 7;
                }
                break;
            	default:
            	    NoViableAltException nvae_d111s0 =
            	        new NoViableAltException("329:1: g_elementSetSpec : ( g_valueElement | g_containedSubtype | g_SizeConstraint | g_permittedAlphabet | g_innerTypeConstraints | g_patternConstraint | '(' g_elementSetSpecs ')' );", 111, 0, input);
            
            	    throw nvae_d111s0;
            }
            
            switch (alt111) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:330:4: g_valueElement
                    {
                    	PushFollow(FOLLOW_g_valueElement_in_g_elementSetSpec1913);
                    	g_valueElement();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:331:4: g_containedSubtype
                    {
                    	PushFollow(FOLLOW_g_containedSubtype_in_g_elementSetSpec1918);
                    	g_containedSubtype();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 3 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:332:4: g_SizeConstraint
                    {
                    	PushFollow(FOLLOW_g_SizeConstraint_in_g_elementSetSpec1923);
                    	g_SizeConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 4 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:333:4: g_permittedAlphabet
                    {
                    	PushFollow(FOLLOW_g_permittedAlphabet_in_g_elementSetSpec1928);
                    	g_permittedAlphabet();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 5 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:334:4: g_innerTypeConstraints
                    {
                    	PushFollow(FOLLOW_g_innerTypeConstraints_in_g_elementSetSpec1933);
                    	g_innerTypeConstraints();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 6 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:335:4: g_patternConstraint
                    {
                    	PushFollow(FOLLOW_g_patternConstraint_in_g_elementSetSpec1938);
                    	g_patternConstraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 7 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:336:4: '(' g_elementSetSpecs ')'
                    {
                    	Match(input,76,FOLLOW_76_in_g_elementSetSpec1943); 
                    	PushFollow(FOLLOW_g_elementSetSpecs_in_g_elementSetSpec1945);
                    	g_elementSetSpecs();
                    	followingStackPointer_--;

                    	Match(input,77,FOLLOW_77_in_g_elementSetSpec1947); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:339:1: g_valueElement : value ( ( '<' )? '..' ( '<' )? value )? ;
    public void g_valueElement() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:4: ( value ( ( '<' )? '..' ( '<' )? value )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:4: value ( ( '<' )? '..' ( '<' )? value )?
            {
            	PushFollow(FOLLOW_value_in_g_valueElement1960);
            	value();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:10: ( ( '<' )? '..' ( '<' )? value )?
            	int alt114 = 2;
            	int LA114_0 = input.LA(1);
            	
            	if ( ((LA114_0 >= 88 && LA114_0 <= 89)) )
            	{
            	    alt114 = 1;
            	}
            	switch (alt114) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:12: ( '<' )? '..' ( '<' )? value
            	        {
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:12: ( '<' )?
            	        	int alt112 = 2;
            	        	int LA112_0 = input.LA(1);
            	        	
            	        	if ( (LA112_0 == 88) )
            	        	{
            	        	    alt112 = 1;
            	        	}
            	        	switch (alt112) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:13: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_g_valueElement1965); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	Match(input,89,FOLLOW_89_in_g_valueElement1969); 
            	        	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:24: ( '<' )?
            	        	int alt113 = 2;
            	        	int LA113_0 = input.LA(1);
            	        	
            	        	if ( (LA113_0 == 88) )
            	        	{
            	        	    alt113 = 1;
            	        	}
            	        	switch (alt113) 
            	        	{
            	        	    case 1 :
            	        	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:340:25: '<'
            	        	        {
            	        	        	Match(input,88,FOLLOW_88_in_g_valueElement1972); 
            	        	        
            	        	        }
            	        	        break;
            	        	
            	        	}

            	        	PushFollow(FOLLOW_value_in_g_valueElement1976);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:1: g_containedSubtype : ( INCLUDES )? type ;
    public void g_containedSubtype() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:21: ( ( INCLUDES )? type )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:21: ( INCLUDES )? type
            {
            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:21: ( INCLUDES )?
            	int alt115 = 2;
            	int LA115_0 = input.LA(1);
            	
            	if ( (LA115_0 == INCLUDES) )
            	{
            	    alt115 = 1;
            	}
            	switch (alt115) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:342:21: INCLUDES
            	        {
            	        	Match(input,INCLUDES,FOLLOW_INCLUDES_in_g_containedSubtype1987); 
            	        
            	        }
            	        break;
            	
            	}

            	PushFollow(FOLLOW_type_in_g_containedSubtype1990);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:344:1: g_SizeConstraint : SIZE g_constraint ;
    public void g_SizeConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:344:20: ( SIZE g_constraint )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:344:20: SIZE g_constraint
            {
            	Match(input,SIZE,FOLLOW_SIZE_in_g_SizeConstraint1998); 
            	PushFollow(FOLLOW_g_constraint_in_g_SizeConstraint2000);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:346:1: g_permittedAlphabet : FROM g_constraint ;
    public void g_permittedAlphabet() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:346:23: ( FROM g_constraint )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:346:23: FROM g_constraint
            {
            	Match(input,FROM,FOLLOW_FROM_in_g_permittedAlphabet2008); 
            	PushFollow(FOLLOW_g_constraint_in_g_permittedAlphabet2010);
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:348:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );
    public void g_innerTypeConstraints() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:349:4: ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' )
            int alt118 = 2;
            int LA118_0 = input.LA(1);
            
            if ( (LA118_0 == WITH) )
            {
                int LA118_1 = input.LA(2);
                
                if ( (LA118_1 == COMPONENT) )
                {
                    alt118 = 1;
                }
                else if ( (LA118_1 == COMPONENTS) )
                {
                    alt118 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d118s1 =
                        new NoViableAltException("348:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );", 118, 1, input);
                
                    throw nvae_d118s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d118s0 =
                    new NoViableAltException("348:1: g_innerTypeConstraints : ( WITH COMPONENT g_constraint | WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}' );", 118, 0, input);
            
                throw nvae_d118s0;
            }
            switch (alt118) 
            {
                case 1 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:349:4: WITH COMPONENT g_constraint
                    {
                    	Match(input,WITH,FOLLOW_WITH_in_g_innerTypeConstraints2020); 
                    	Match(input,COMPONENT,FOLLOW_COMPONENT_in_g_innerTypeConstraints2022); 
                    	PushFollow(FOLLOW_g_constraint_in_g_innerTypeConstraints2024);
                    	g_constraint();
                    	followingStackPointer_--;

                    
                    }
                    break;
                case 2 :
                    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:350:4: WITH COMPONENTS '{' ( '...' ',' )? g_namedConstraint ( ',' g_namedConstraint )* '}'
                    {
                    	Match(input,WITH,FOLLOW_WITH_in_g_innerTypeConstraints2029); 
                    	Match(input,COMPONENTS,FOLLOW_COMPONENTS_in_g_innerTypeConstraints2031); 
                    	Match(input,74,FOLLOW_74_in_g_innerTypeConstraints2033); 
                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:351:4: ( '...' ',' )?
                    	int alt116 = 2;
                    	int LA116_0 = input.LA(1);
                    	
                    	if ( (LA116_0 == 82) )
                    	{
                    	    alt116 = 1;
                    	}
                    	switch (alt116) 
                    	{
                    	    case 1 :
                    	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:351:6: '...' ','
                    	        {
                    	        	Match(input,82,FOLLOW_82_in_g_innerTypeConstraints2040); 
                    	        	Match(input,79,FOLLOW_79_in_g_innerTypeConstraints2042); 
                    	        
                    	        }
                    	        break;
                    	
                    	}

                    	PushFollow(FOLLOW_g_namedConstraint_in_g_innerTypeConstraints2049);
                    	g_namedConstraint();
                    	followingStackPointer_--;

                    	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:352:23: ( ',' g_namedConstraint )*
                    	do 
                    	{
                    	    int alt117 = 2;
                    	    int LA117_0 = input.LA(1);
                    	    
                    	    if ( (LA117_0 == 79) )
                    	    {
                    	        alt117 = 1;
                    	    }
                    	    
                    	
                    	    switch (alt117) 
                    		{
                    			case 1 :
                    			    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:352:24: ',' g_namedConstraint
                    			    {
                    			    	Match(input,79,FOLLOW_79_in_g_innerTypeConstraints2053); 
                    			    	PushFollow(FOLLOW_g_namedConstraint_in_g_innerTypeConstraints2055);
                    			    	g_namedConstraint();
                    			    	followingStackPointer_--;

                    			    
                    			    }
                    			    break;
                    	
                    			default:
                    			    goto loop117;
                    	    }
                    	} while (true);
                    	
                    	loop117:
                    		;	// Stops C# compiler whinging that label 'loop117' has no statements

                    	Match(input,75,FOLLOW_75_in_g_innerTypeConstraints2061); 
                    
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:357:1: g_namedConstraint : identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )? ;
    public void g_namedConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:358:4: ( identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )? )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:358:4: identifier ( g_constraint )? ( PRESENT | ABSENT | OPTIONAL )?
            {
            	PushFollow(FOLLOW_identifier_in_g_namedConstraint2073);
            	identifier();
            	followingStackPointer_--;

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:358:15: ( g_constraint )?
            	int alt119 = 2;
            	int LA119_0 = input.LA(1);
            	
            	if ( (LA119_0 == 76) )
            	{
            	    alt119 = 1;
            	}
            	switch (alt119) 
            	{
            	    case 1 :
            	        // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:358:16: g_constraint
            	        {
            	        	PushFollow(FOLLOW_g_constraint_in_g_namedConstraint2076);
            	        	g_constraint();
            	        	followingStackPointer_--;

            	        
            	        }
            	        break;
            	
            	}

            	// C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:358:31: ( PRESENT | ABSENT | OPTIONAL )?
            	int alt120 = 2;
            	int LA120_0 = input.LA(1);
            	
            	if ( (LA120_0 == OPTIONAL || (LA120_0 >= PRESENT && LA120_0 <= ABSENT)) )
            	{
            	    alt120 = 1;
            	}
            	switch (alt120) 
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
            	        	    RecoverFromMismatchedSet(input,mse,FOLLOW_set_in_g_namedConstraint2080);    throw mse;
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
    // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:360:1: g_patternConstraint : PATTERN value ;
    public void g_patternConstraint() // throws RecognitionException [1]
    {   
        try 
    	{
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:360:23: ( PATTERN value )
            // C:\\prj\\DataModeling\\tinyAsn1\\tinyAsn1\\asn1.g:360:23: PATTERN value
            {
            	Match(input,PATTERN,FOLLOW_PATTERN_in_g_patternConstraint2098); 
            	PushFollow(FOLLOW_value_in_g_patternConstraint2100);
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
    public static readonly BitSet FOLLOW_bitStringType_in_type404 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type406 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_booleanType_in_type411 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type413 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_enumeratedType_in_type418 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type420 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_integerType_in_type429 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type431 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_realType_in_type443 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type445 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_stringType_in_type450 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type452 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_referencedType_in_type457 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type459 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sequenceOfType_in_type464 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_choiceType_in_type469 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sequenceType_in_type480 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type482 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_setType_in_type496 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_setOfType_in_type508 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_objectIdentifier_in_type520 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_type522 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_relativeOID_in_type534 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BIT_in_bitStringType548 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_STRING_in_bitStringType550 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_bitStringType553 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType556 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitStringType558 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType561 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_bitStringType563 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitStringType566 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_bitStringType569 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringType571 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_bitStringType573 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_bitStringType576 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_bitStringType578 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_bitStringType581 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_bitStringType589 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BOOLEAN_in_booleanType604 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ENUMERATED_in_enumeratedType617 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_enumeratedType619 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_enumeratedTypeItems_in_enumeratedType621 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedType626 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_enumeratedType628 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004008800UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_enumeratedType630 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedType634 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_enumeratedTypeItems_in_enumeratedType636 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_enumeratedType643 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedTypeItems655 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000009000UL});
    public static readonly BitSet FOLLOW_76_in_enumeratedTypeItems659 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedTypeItems662 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_enumeratedTypeItems664 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_enumeratedTypeItems667 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_enumeratedTypeItems672 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_enumeratedTypeItems674 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000009000UL});
    public static readonly BitSet FOLLOW_76_in_enumeratedTypeItems678 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_enumeratedTypeItems681 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_enumeratedTypeItems683 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_enumeratedTypeItems686 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_INTEGER_in_integerType703 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_integerType707 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType710 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_integerType712 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType715 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_integerType717 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_integerType720 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_integerType723 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_integerType725 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_integerType727 = new BitSet(new ulong[]{0x4000000000002000UL,0x0000000000C00000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_integerType730 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_valuereference_in_integerType732 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_integerType735 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_integerType741 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_REAL_in_realType756 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_CHOICE_in_choiceType773 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_choiceType775 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_choiceList_in_choiceType777 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_choiceType780 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_choiceType782 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004008800UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_choiceType784 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_choiceListExtension_in_choiceType788 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_choiceType794 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_choiceType796 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_choiceType804 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceList815 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_choiceList817 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceList820 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_choiceList822 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_choiceList824 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceListExtension837 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionAlternative_in_choiceListExtension839 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_choiceListExtension842 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionAlternative_in_choiceListExtension844 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_83_in_extensionAdditionAlternative858 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_versionNumber_in_extensionAdditionAlternative860 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_choiceList_in_extensionAdditionAlternative863 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
    public static readonly BitSet FOLLOW_84_in_extensionAdditionAlternative865 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_extensionAdditionAlternative871 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_extensionAdditionAlternative873 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceType885 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_sequenceType887 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040800UL});
    public static readonly BitSet FOLLOW_sequenceOrSetBody_in_sequenceType889 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_sequenceType893 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setType905 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_setType907 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040800UL});
    public static readonly BitSet FOLLOW_sequenceOrSetBody_in_setType909 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_setType913 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_sequenceOrSetBody930 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_sequenceOrSetBody934 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody936 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_seqOrSetExtBody_in_sequenceOrSetBody944 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_82_in_seqOrSetExtBody956 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000004008000UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_seqOrSetExtBody958 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody962 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAdditionList_in_seqOrSetExtBody964 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody969 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_seqOrSetExtBody971 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_seqOrSetExtBody976 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_seqOrSetExtBody978 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_extensionAddition_in_extensionAdditionList997 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_extensionAdditionList1000 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000080000UL});
    public static readonly BitSet FOLLOW_extensionAddition_in_extensionAdditionList1002 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_componentType_in_extensionAddition1016 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_extensionAdditionGroup_in_extensionAddition1027 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_83_in_extensionAdditionGroup1037 = new BitSet(new ulong[]{0x4000000000002000UL});
    public static readonly BitSet FOLLOW_versionNumber_in_extensionAdditionGroup1039 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentTypeList_in_extensionAdditionGroup1042 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000100000UL});
    public static readonly BitSet FOLLOW_84_in_extensionAdditionGroup1044 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_componentType_in_componentTypeList1056 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_componentTypeList1060 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_componentType_in_componentTypeList1062 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_identifier_in_componentType1077 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_componentType1079 = new BitSet(new ulong[]{0x0000000180000002UL});
    public static readonly BitSet FOLLOW_OPTIONAL_in_componentType1082 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DEFAULT_in_componentType1086 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_componentType1088 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType1103 = new BitSet(new ulong[]{0x0000000200000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_sequenceOfType1105 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType1108 = new BitSet(new ulong[]{0x4005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceOfType1111 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType1115 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEQUENCE_in_sequenceOfType1120 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sequenceOfType1122 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_sequenceOfType1124 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_sequenceOfType1126 = new BitSet(new ulong[]{0x4005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_identifier_in_sequenceOfType1129 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_sequenceOfType1133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setOfType1145 = new BitSet(new ulong[]{0x0000000200000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_setOfType1147 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_setOfType1150 = new BitSet(new ulong[]{0x4005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_identifier_in_setOfType1153 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_setOfType1157 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SET_in_setOfType1162 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_setOfType1164 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_setOfType1166 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_OF_in_setOfType1168 = new BitSet(new ulong[]{0x4005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_identifier_in_setOfType1171 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_setOfType1175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCTET_in_stringType1191 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_STRING_in_stringType1193 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NumericString_in_stringType1197 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PrintableString_in_stringType1201 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VisibleString_in_stringType1205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IA5String_in_stringType1209 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TeletexString_in_stringType1213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_VideotexString_in_stringType1217 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GraphicString_in_stringType1221 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GeneralString_in_stringType1225 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UniversalString_in_stringType1229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BMPString_in_stringType1233 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UTF8String_in_stringType1237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_referencedType1249 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_referencedType1252 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_UID_in_referencedType1254 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OBJECT_in_objectIdentifier1268 = new BitSet(new ulong[]{0x0002000000000000UL});
    public static readonly BitSet FOLLOW_IDENTIFIER_in_objectIdentifier1270 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_RELATIVE_OID_in_relativeOID1278 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_signedNumber1289 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_signedNumber1296 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_constraint1307 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sizeConstraint_in_constraint1312 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_withComponentsConstraint_in_constraint1317 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_subTypeConstraint_in_constraint1322 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_valueConstraint1338 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_valueConstraint1340 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000003002000UL});
    public static readonly BitSet FOLLOW_88_in_valueConstraint1345 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000002000000UL});
    public static readonly BitSet FOLLOW_89_in_valueConstraint1349 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000001C00400UL});
    public static readonly BitSet FOLLOW_88_in_valueConstraint1352 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_valueConstraint1356 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_valueConstraint1360 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_sizeConstraint1371 = new BitSet(new ulong[]{0x0000000400000000UL});
    public static readonly BitSet FOLLOW_SIZE_in_sizeConstraint1373 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_sizeConstraint1375 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_sizeConstraint1377 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_permittedAlphabetConstraint1390 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_FROM_in_permittedAlphabetConstraint1392 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_permittedAlphabetConstraint1394 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_permittedAlphabetConstraint1396 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_subTypeConstraint1409 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_subTypeConstraint1411 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_subTypeConstraint1413 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_withComponentsConstraint1428 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_WITH_in_withComponentsConstraint1431 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_COMPONENTS_in_withComponentsConstraint1433 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_withComponentsConstraint1435 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_withComponentsConstraint1442 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_withComponentsConstraint1444 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint1451 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_withComponentsConstraint1455 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_namedConstraint_in_withComponentsConstraint1457 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_withComponentsConstraint1463 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_withComponentsConstraint1467 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_namedConstraint1479 = new BitSet(new ulong[]{0x0060000080000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_valueConstraint_in_namedConstraint1482 = new BitSet(new ulong[]{0x0060000080000002UL});
    public static readonly BitSet FOLLOW_set_in_namedConstraint1486 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_BitStringLiteral_in_value1506 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_bitStringValue_in_value1511 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OctectStringLiteral_in_value1516 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TRUE_in_value1521 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FALSE_in_value1526 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_StringLiteral_in_value1531 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_value1536 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_value1543 = new BitSet(new ulong[]{0x0000000000002000UL});
    public static readonly BitSet FOLLOW_INT_in_value1550 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_value1553 = new BitSet(new ulong[]{0x0000000000002002UL});
    public static readonly BitSet FOLLOW_INT_in_value1555 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MIN_in_value1565 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAX_in_value1570 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_objectIdentifierValue_in_value1575 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_74_in_bitStringValue1588 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringValue1590 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_bitStringValue1593 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_identifier_in_bitStringValue1595 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_bitStringValue1599 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_74_in_objectIdentifierValue1611 = new BitSet(new ulong[]{0x4000800000002000UL});
    public static readonly BitSet FOLLOW_objectIdentifierComponent_in_objectIdentifierValue1613 = new BitSet(new ulong[]{0x4000800000002000UL,0x0000000000000800UL});
    public static readonly BitSet FOLLOW_75_in_objectIdentifierValue1617 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_objectIdentifierComponent1628 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_76_in_objectIdentifierComponent1631 = new BitSet(new ulong[]{0x4000800000002000UL});
    public static readonly BitSet FOLLOW_INT_in_objectIdentifierComponent1634 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_definedValue_in_objectIdentifierComponent1638 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_objectIdentifierComponent1641 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_objectIdentifierComponent1651 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_modulereference_in_objectIdentifierComponent1656 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_objectIdentifierComponent1658 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_valuereference_in_objectIdentifierComponent1660 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_definedValue1673 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_modulereference_in_definedValue1679 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000200000UL});
    public static readonly BitSet FOLLOW_85_in_definedValue1681 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_valuereference_in_definedValue1683 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_lID1693 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_modulereference1701 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_UID_in_typereference1709 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_valuereference1719 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LID_in_identifier1729 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_versionNumber1737 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_g_constraint1757 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_subtypeConstraint_in_g_constraint1759 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000004002000UL});
    public static readonly BitSet FOLLOW_g_exceptionSpec_in_g_constraint1762 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_g_constraint1765 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_90_in_g_exceptionSpec1777 = new BitSet(new ulong[]{0x4005FFF87F602000UL,0x0000000000C10000UL});
    public static readonly BitSet FOLLOW_signedNumber_in_g_exceptionSpec1786 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_valuereference_in_g_exceptionSpec1791 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_type_in_g_exceptionSpec1798 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000008000000UL});
    public static readonly BitSet FOLLOW_91_in_g_exceptionSpec1800 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_exceptionSpec1802 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_elementSetSpecs_in_g_subtypeConstraint1817 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_unionElement_in_g_elementSetSpecs1826 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_elementSetSpecs1829 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_g_elementSetSpecs1831 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_elementSetSpecs1835 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_unionElement_in_g_elementSetSpecs1837 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_intersectionElement_in_g_unionElement1851 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_UnionMark_in_g_unionElement1854 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_intersectionElement_in_g_unionElement1856 = new BitSet(new ulong[]{0x8000000000000002UL});
    public static readonly BitSet FOLLOW_ALL_in_g_unionElement1863 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000001UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_unionElement1865 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_unionElement1867 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1880 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_intersectionElement1883 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1885 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IntersectionMark_in_g_intersectionElement1890 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1892 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000003UL});
    public static readonly BitSet FOLLOW_EXCEPT_in_g_intersectionElement1895 = new BitSet(new ulong[]{0x7F8DFFFC7F622000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpec_in_g_intersectionElement1897 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_valueElement_in_g_elementSetSpec1913 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_containedSubtype_in_g_elementSetSpec1918 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_SizeConstraint_in_g_elementSetSpec1923 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_permittedAlphabet_in_g_elementSetSpec1928 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_innerTypeConstraints_in_g_elementSetSpec1933 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_g_patternConstraint_in_g_elementSetSpec1938 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_76_in_g_elementSetSpec1943 = new BitSet(new ulong[]{0x7F8DFFFC7F62A000UL,0x0000000000C11414UL});
    public static readonly BitSet FOLLOW_g_elementSetSpecs_in_g_elementSetSpec1945 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000002000UL});
    public static readonly BitSet FOLLOW_77_in_g_elementSetSpec1947 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_value_in_g_valueElement1960 = new BitSet(new ulong[]{0x0000000000000002UL,0x0000000003000000UL});
    public static readonly BitSet FOLLOW_88_in_g_valueElement1965 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000002000000UL});
    public static readonly BitSet FOLLOW_89_in_g_valueElement1969 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000001C00400UL});
    public static readonly BitSet FOLLOW_88_in_g_valueElement1972 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_valueElement1976 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INCLUDES_in_g_containedSubtype1987 = new BitSet(new ulong[]{0x0005FFF87F600000UL,0x0000000000010000UL});
    public static readonly BitSet FOLLOW_type_in_g_containedSubtype1990 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SIZE_in_g_SizeConstraint1998 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_SizeConstraint2000 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FROM_in_g_permittedAlphabet2008 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_permittedAlphabet2010 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_g_innerTypeConstraints2020 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000008UL});
    public static readonly BitSet FOLLOW_COMPONENT_in_g_innerTypeConstraints2022 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_innerTypeConstraints2024 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WITH_in_g_innerTypeConstraints2029 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_COMPONENTS_in_g_innerTypeConstraints2031 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000000400UL});
    public static readonly BitSet FOLLOW_74_in_g_innerTypeConstraints2033 = new BitSet(new ulong[]{0x4000000000000000UL,0x0000000000040000UL});
    public static readonly BitSet FOLLOW_82_in_g_innerTypeConstraints2040 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008000UL});
    public static readonly BitSet FOLLOW_79_in_g_innerTypeConstraints2042 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_g_namedConstraint_in_g_innerTypeConstraints2049 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_79_in_g_innerTypeConstraints2053 = new BitSet(new ulong[]{0x4000000000000000UL});
    public static readonly BitSet FOLLOW_g_namedConstraint_in_g_innerTypeConstraints2055 = new BitSet(new ulong[]{0x0000000000000000UL,0x0000000000008800UL});
    public static readonly BitSet FOLLOW_75_in_g_innerTypeConstraints2061 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_identifier_in_g_namedConstraint2073 = new BitSet(new ulong[]{0x0060000080000002UL,0x0000000000001000UL});
    public static readonly BitSet FOLLOW_g_constraint_in_g_namedConstraint2076 = new BitSet(new ulong[]{0x0060000080000002UL});
    public static readonly BitSet FOLLOW_set_in_g_namedConstraint2080 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PATTERN_in_g_patternConstraint2098 = new BitSet(new ulong[]{0x7F80000000002000UL,0x0000000000C00400UL});
    public static readonly BitSet FOLLOW_value_in_g_patternConstraint2100 = new BitSet(new ulong[]{0x0000000000000002UL});

}
