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

type	: ('[' (UNIVERSAL | APPLICATION | PRIVATE)? INT  ']' ( IMPLICIT | EXPLICIT)? )?
(	
	 NULL
	|bitStringType
	|booleanType g_constraint*
	|enumeratedType g_constraint*
//	|integerType valueConstraint*
//        |realType (valueConstraint | withComponentsConstraint)*
//	|stringType (sizeConstraint |permittedAlphabetConstraint)*
//	|typereference	constraint*
	|integerType g_constraint*
        |realType g_constraint*
	|stringType g_constraint*
	|referencedType	g_constraint*
	|sequenceOfType
	|choiceType
        |sequenceType
        | setType
        | setOfType
        | objectIdentifier
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
	
/*
REAL 	::= [UNIVERSAL 10] SEQUENCE {
	f mantissa INTEGER (ALL EXCEPT 0),
	base INTEGER (2|10),
	exponent INTEGER g
	}
*/	
	
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
	:	SEQUENCE sizeConstraint? OF type
	|	SEQUENCE SIZE valueConstraint OF type
	;
	
setOfType
	:	SET sizeConstraint? OF type
	|	SET SIZE valueConstraint OF type
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

objectIdentifier
	:	OBJECT IDENTIFIER;

relativeOID	:	RELATIVE_OID;

	
signedNumber
	:	('+'|'-')? INT;
	

constraint
	:	valueConstraint
	|	sizeConstraint
	|	withComponentsConstraint
	|	subTypeConstraint
	;
	

	
valueConstraint 
	: '(' value ( ('<')? '..' ('<')? value)? ')'
	;

sizeConstraint
	:	'(' SIZE valueConstraint ')'
	;	
	
permittedAlphabetConstraint
	:	'(' FROM valueConstraint ')'
	;
	
subTypeConstraint 
	:	'(' type ')'
	;		
	
withComponentsConstraint 
	:	'('  WITH COMPONENTS '{'
			( '...' ',')?
			namedConstraint  (',' namedConstraint)*
		'}'
		')'
	;	

namedConstraint
	:	identifier (valueConstraint)? (PRESENT|ABSENT | OPTIONAL)?;	

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
	;	
	
bitStringValue
	:	'{' identifier (',' identifier)* '}'
	;		


lID	:	LID;

modulereference	:	UID;

typereference	:	UID;
	
valuereference 	:	LID;		

identifier	:	LID;

versionNumber	:	INT;



/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
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


g_namedConstraint
	:	identifier (g_constraint)? (PRESENT|ABSENT | OPTIONAL)?;	

g_patternConstraint : PATTERN value;
	

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

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;



