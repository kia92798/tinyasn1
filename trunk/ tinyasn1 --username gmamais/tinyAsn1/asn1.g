grammar asn1;
options {
	language=CSharp;
}

@header {
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
	| EXPORTS (typereference | valuereference) (',' (typereference | valuereference))*  ';'
;			

imports :
	IMPORTS ((typereference | valuereference) (',' (typereference | valuereference))* FROM modulereference)* ';'	
	;
	
	
valueAssigment	
	:	valuereference type '::=' value	
	;		
		
typeAssigment 
	:	typereference '::=' type
	;	

type	: ('[' (UNIVERSAL | APPLICATION | PRIVATE)? INT  ']' ( IMPLICIT | EXPLICIT)? )?
(	
	 bitStringType
	|booleanType
	|enumeratedType
	|integerType singleValueOrRangeConstraint?
        |realType (singleValueOrRangeConstraint | withComponentsConstraint)?
	|stringType (sizeConstraint |permittedAlphabetConstraint)*
	|typereference	constraint?
	|sequenceOfType
	|choiceType
        |sequenceType
)
	;


bitStringType
	:	BIT STRING ('{' (identifier '(' INT ')' (',' identifier '(' INT ')' )* )? '}' )?
	;
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 
	:	ENUMERATED '{' (identifier ( '(' signedNumber ')')? (',' identifier ( '(' signedNumber ')')?)*)? '}'
	;	

integerType
	:	INTEGER ( '{' (identifier '(' signedNumber ')' (',' identifier '(' signedNumber ')')*)? '}')?
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
	:	CHOICE '{' (identifier type (',' identifier type)* )? '}'
	;

sequenceType
	:	SEQUENCE '{' (identifier type (OPTIONAL)?  (',' identifier type (OPTIONAL)? )*)?  '}' 
	;
	
sequenceOfType
	:	SEQUENCE sizeConstraint? OF type
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
	
	
	
namedNumber
	:	LID '(' signedNumber ')'
	;

signedNumber
	:	('+'|'-')? INT;
	
/*	
constraint
	:	'(' unionSet (',' '..' (',' unionSet)?)? ')'
	;	

unionSet
	:	intersectionSet (UnionMark intersectionSet)* 	
	|	'ALL'  'EXCEPT' element 
	;
	
intersectionSet
	:	element ( 'EXCEPT' element)? (IntersectionMark element ( 'EXCEPT' element)?)*
	;

element
:	  value ( ('<')? '..' ('<')? value)?
	| '(' unionSet ')'
	| 'SIZE' constraint
	;
*/

constraint
	:	singleValueOrRangeConstraint
	|	sizeConstraint
	|	withComponentsConstraint
	;
	
	
singleValueOrRangeConstraint 
	: '(' value ( ('<')? '..' ('<')? value)? ')'
	;

sizeConstraint
	:	'(' SIZE singleValueOrRangeConstraint ')'
	;	
	
permittedAlphabetConstraint
	:	'(' FROM singleValueOrRangeConstraint ')'
	;	
	
withComponentsConstraint 
	:	'('  WITH COMPONENTS '{'
			( '...' ',')?
			namedConstraint  (',' namedConstraint)*
		'}'
		')'
	;	

namedConstraint
	:	identifier (singleValueOrRangeConstraint)? (PRESENT|ABSENT | OPTIONAL)?;	

value	:
		bitStringValue
	|	booleanValue
	|	StringLiteral
	|	valuereference		
	|	('+'|'-')? INT ('.' INT?)? 
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	|	MIN
	|	MAX
	;	
	
bitStringValue
	:	Bstring
	|	Hstring
	;
		
booleanValue
	:	TRUE
	|	FALSE
	;


lID	:	LID;

modulereference	:	UID;

typereference	:	UID;
	
valuereference 	:	LID;		

identifier	:	LID;

		
/*

UnionMark  :  '|'	
|	'UNION'
	;

IntersectionMark  :	'^'	|	'INTERSECTION';
*/	

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
COMPONENTS 	:	'COMPONENTS';

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

Bstring	:
	'\'' ('0'|'1')* '\'B'
	;
Hstring	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;


StringLiteral 	: 	'"' (options {greedy=false;} : .)* '"' ;
	
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

LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;

