grammar asn1;
options {
	language=CSharp;
}

@header {
}

@members {
public override void ReportError(RecognitionException e) {
	base.ReportError(e);
        throw e;
}

}

/* ********************************************************************************************************************* */
/* ************************************* MODULE DEFINITION ************************************************************* */
/* ********************************************************************************************************************* */

moduleDefinitions 
	:	moduleDefinition*;

moduleDefinition :  	modulereference	definitiveIdentifier?
			DEFINITIONS
			(EXPLICIT TAGS | IMPLICIT TAGS | AUTOMATIC TAGS)?
			(EXTENSIBILITY IMPLIED)?
			'::=' BEGIN
			(exports)?
			(imports)?
			(
				typeAssigment
				|valueAssigment
				|valueSetAssigment
			)*
			END;
definitiveIdentifier
	:	'{' definitiveObjIdComponent* '}'
	;
		
definitiveObjIdComponent
	:	identifier ( '(' INT ')' )?
	|	INT;		
			
exports :
	 EXPORTS ALL ';'
	| EXPORTS ((typereference | valuereference) (',' (typereference | valuereference))*)?  ';'
;			

imports :
	IMPORTS ((typereference | valuereference) (',' (typereference | valuereference))* FROM modulereference definitiveIdentifier?)*  ';'	
	;
	
	
valueAssigment	
	:	valuereference type '::=' value	
	;		
		
valueSetAssigment
	:	typereference type '::=' '{' g_elementSetSpecs '}'
	;		
typeAssigment 
	:	typereference '::=' type
	;	
	
/* ********************************************************************************************************************* */
/* *************************************** TYPE DEFINITION ************************************************************* */
/* ********************************************************************************************************************* */
	

type	: ('[' (UNIVERSAL | APPLICATION | PRIVATE)? INT  ']' ( IMPLICIT | EXPLICIT)? )?
(	
	 NULL
	|bitStringType (SIZE valueConstraint| g_constraint)*
	|booleanType g_constraint*
	|enumeratedType g_constraint*
	|integerType g_constraint*
        |realType g_constraint*
	|stringType (SIZE valueConstraint| g_constraint)*
	|referencedType	g_constraint*
	|sequenceOfType 
	|choiceType
        |sequenceType g_constraint*	//WITH COMPONENTS
        | setType
        | setOfType
        | objectIdentifier g_constraint*
        |relativeOID
)
	;


bitStringType
	:	BIT STRING ('{' (identifier '(' (INT|valuereference) ')' (',' identifier '(' (INT|valuereference) ')' )* )? '}' )?
	;
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 
	:	ENUMERATED '{' enumeratedTypeItems  ( ',' '...' g_exceptionSpec? (',' enumeratedTypeItems)? )? '}'
	;

enumeratedTypeItems 
	:	identifier ( '(' (signedNumber|valuereference) ')')? (',' identifier ( '(' (signedNumber|valuereference) ')')?)*
	;		

integerType
	:	INTEGER ( '{' (identifier '(' (signedNumber|valuereference) ')' (',' identifier '(' (signedNumber|valuereference) ')')*)? '}')?
	;
	
realType 
	:	REAL
	;
	
	
choiceType
	:	CHOICE '{' choiceList (',' '...' g_exceptionSpec?  choiceListExtension?   (',' '...')?  )? '}'
	;

choiceList
	:	identifier type (',' identifier type)*
	;

choiceListExtension
	:	',' extensionAdditionAlternative (',' extensionAdditionAlternative)*
	;	
extensionAdditionAlternative
	:	 '[[' versionNumber? choiceList ']]'
		| identifier type
	;	

sequenceType
	:	SEQUENCE '{' sequenceOrSetBody?  '}' 
	;
	
setType	:	SET '{' sequenceOrSetBody?  '}' 
	;	
	
sequenceOrSetBody	:
		  componentTypeList ( ',' seqOrSetExtBody)?
		| seqOrSetExtBody
	;
	
seqOrSetExtBody
	:	'...' g_exceptionSpec? (',' extensionAdditionList)? (',' '...'   (',' componentTypeList )? )?
	;	
	
extensionAdditionList
	:	extensionAddition (',' extensionAddition)*
	;	

extensionAddition
	:	componentType
	       |extensionAdditionGroup
	;
extensionAdditionGroup
	:	'[[' versionNumber? componentTypeList ']]'
	;

componentTypeList 
	:	componentType  (',' componentType )*
	;
	
componentType
	:	identifier type (OPTIONAL | DEFAULT value)?
	;	
	
sequenceOfType
	:	SEQUENCE sizeConstraint? OF (identifier)? type
	|	SEQUENCE SIZE valueConstraint OF (identifier)? type
	;
	
setOfType
	:	SET sizeConstraint? OF (identifier)? type
	|	SET SIZE valueConstraint OF (identifier)? type
	;		

	
stringType	:
	 OCTET STRING
	|NumericString
	|PrintableString
	|VisibleString
	|IA5String
	|TeletexString
	|VideotexString
	|GraphicString
	|GeneralString
	|UniversalString
	|BMPString
	|UTF8String
	;
	
referencedType
	:	UID ('.' UID)?
	;	

	
/* ********************************************************************************************************************* */
/* *************************************** VALUES DEFINITION *********************************************************** */
/* ********************************************************************************************************************* */

value	:
		BitStringLiteral
	|	bitStringValue
	|	OctectStringLiteral
	|	TRUE
	|	FALSE
	|	StringLiteral
	|	valuereference		
	|	('+'|'-')? INT ('.' INT?)? 
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	|	MIN
	|	MAX
	|	objectIdentifierValue
	|	charSequenceValue
	;	
	
bitStringValue
	:	'{' identifier (',' identifier)* '}'
	;

charSequenceValue	: 
	'{' INT (',' INT)* '}'
;
	
objectIdentifierValue
	:	'{' objectIdentifierComponent+  '}'
	;	
objectIdentifierComponent
	:	identifier ('(' (INT | definedValue) ')' )?	//3 cases identifier or valuereference or identifier(number)
	| 	INT
	|	modulereference '.' valuereference	//external ref
	;


definedValue
	:	valuereference
		| modulereference '.' valuereference
	;

/* ********************************************************************************************************************* */
/* *************************************** Constraints DEFINITION ****************************************************** */
/* ********************************************************************************************************************* */
g_constraint 
	:	'(' g_subtypeConstraint  g_exceptionSpec? ')'
	;

g_exceptionSpec 
	:	'!' 
	(
		 signedNumber
		|valuereference
				|type ':' value
	)
	;


g_subtypeConstraint
	: g_elementSetSpecs;

g_elementSetSpecs
	:	g_unionElement (',' '...' ( ',' g_unionElement)?)?;
	
g_unionElement
	:	g_intersectionElement (UnionMark g_intersectionElement)*
	|	ALL EXCEPT g_elementSetSpec
	;	
	
g_intersectionElement
	:	g_elementSetSpec (EXCEPT g_elementSetSpec)? (IntersectionMark g_elementSetSpec (EXCEPT g_elementSetSpec)?)*
	;	

g_elementSetSpec
	: g_valueElement
	| g_containedSubtype
	| g_SizeConstraint
	| g_permittedAlphabet
	| g_innerTypeConstraints
	| g_patternConstraint
	| '(' g_elementSetSpecs ')'
	;	
	
g_valueElement
	: value ( ('<')? '..' ('<')? value)?	
	;
g_containedSubtype: INCLUDES? type;

g_SizeConstraint : SIZE g_constraint;

g_permittedAlphabet : FROM g_constraint;

g_innerTypeConstraints 
	: WITH COMPONENT g_constraint
	| WITH COMPONENTS '{'
			( '...' ',')?
			g_namedConstraint  (',' g_namedConstraint)*
		'}'
	;


valueConstraint 
	: '(' g_valueElement ')'
	;

sizeConstraint
	:	'(' SIZE valueConstraint ')'
	;	

g_namedConstraint
	:	identifier (g_constraint)? (PRESENT|ABSENT | OPTIONAL)?;	

g_patternConstraint : PATTERN value;
	


lID	:	LID;
modulereference	:	UID;
typereference	:	UID;
valuereference 	:	LID;		
identifier	:	LID;
versionNumber	:	INT;
objectIdentifier	:	OBJECT IDENTIFIER;
relativeOID	:	RELATIVE_OID;
signedNumber	:	('+'|'-')? INT;

/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
		


UnionMark  :  '|'|'UNION';
IntersectionMark  :	'^' | 'INTERSECTION';
DEFINITIONS :	 'DEFINITIONS';
EXPLICIT:	 'EXPLICIT';
TAGS 	:	'TAGS';
IMPLICIT:	'IMPLICIT';
AUTOMATIC	:	'AUTOMATIC';
EXTENSIBILITY	:	'EXTENSIBILITY';
IMPLIED :	'IMPLIED';
BEGIN	:	'BEGIN';
END	:	'END';
EXPORTS	:	'EXPORTS';
ALL	: 	'ALL';
IMPORTS	:	'IMPORTS';
FROM	:	'FROM';
UNIVERSAL	: 'UNIVERSAL';
APPLICATION	: 'APPLICATION';
PRIVATE		:'PRIVATE';
BIT	: 'BIT';
STRING	:	'STRING';
BOOLEAN :	'BOOLEAN';
ENUMERATED	:'ENUMERATED';
INTEGER	:	'INTEGER';
REAL	:	'REAL';
CHOICE	:	'CHOICE';
SEQUENCE	:'SEQUENCE';
OPTIONAL	:'OPTIONAL';
SIZE	:	'SIZE';
OF	:	'OF';
OCTET	:	'OCTET';
MIN	: 	'MIN';
MAX	:	'MAX';
TRUE	:	'TRUE';
FALSE	:	'FALSE';
ABSENT	:	'ABSENT';
PRESENT	:	'PRESENT';
WITH 	:	'WITH';
COMPONENT	: 'COMPONENT';		
COMPONENTS 	: 'COMPONENTS';
DEFAULT 	: 'DEFAULT';
NULL		:'NULL';
PATTERN		:'PATTERN';
OBJECT 		:'OBJECT';
IDENTIFIER	:'IDENTIFIER';
RELATIVE_OID	:'RELATIVE-OID';
NumericString	:'NumericString';
PrintableString	:'PrintableString';
VisibleString	:'VisibleString';
IA5String	:'IA5String';
TeletexString	:'TeletexString';
VideotexString	:'VideotexString';
GraphicString	:'GraphicString';
GeneralString	:'GeneralString';
UniversalString	:'UniversalString';
BMPString	:'BMPString';
UTF8String	:'UTF8String';
INCLUDES	:'INCLUDES';
EXCEPT		:'EXCEPT';
SET		:'SET';

BitStringLiteral	:
	'\'' ('0'|'1')* '\'B'
	;

OctectStringLiteral	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;

StringLiteral 	: 	STR+ ;

fragment
STR 	:	'"' ( options {greedy=false;} : .)* '"' ;
			
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

INT	:	( '0' | ('1'..'9') ('0'..'9')*);


WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;

