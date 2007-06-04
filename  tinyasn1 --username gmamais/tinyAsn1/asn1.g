grammar asn1;
options {
	output=AST;
	language=CSharp;
}

tokens {
	MODULE_DEF;
	TYPE_ASSIG;
	VAL_ASSIG;
	VAL_SET_ASSIG;
	TYPE_DEF;
	TYPE_TAG;
	BIT_STRING_TYPE;
	BIT_STRING_ITEM;
	ENUMERATED_LST_ITEM;
	ENUMERATED_TYPE;
	INTEGER_TYPE;
	INTEGER_LST_ITEM;
	CHOICE_TYPE;
	CHOICE_EXT_BODY;
	CHOICE_ITEM;
	CHOICE_EXT_ITEM;
	SEQUENCE_TYPE;
	SET_TYPE;
	SEQUENCE_BODY;
	SEQUENCE_EXT_BODY;
	SEQUENCE_ITEM;
	SEQUENCE_EXT_GROUP;
	SEQUENCE_OF_TYPE;
	SET_OF_TYPE;
	STRING_TYPE;
	REFERENCED_TYPE;
	OBJ_LST_ITEM;
	DEFINED_VALUE;
	NUMERIC_VALUE;
	CONSTRAINT;
	EXCEPTION_SPEC;
	CONSTRAINT_BODY;
	UNION_ELEMENT;
	UNION_ELEMENT_ALL_EXCEPT;
	INTERSECTION_ELEMENT;
	VALUE_RANGE_EXPR;
	SUBTYPE_EXPR;
	SIZE_EXPR;
	PERMITTED_ALPHABET_EXPR;
	INNER_TYPE_EXPR;
	NAME_CONSTRAINT_EXPR;
	PATTERN_EXPR;
	MIN_VAL_INCLUDED;
	MAX_VAL_INCLUDED;
	MAX_VAL_PRESENT;
	BIT_STRING_VALUE;
	CHAR_SEQUENCE_VALUE;
	EXPORTS_ALL;
	IMPORTS_FROM_MODULE;
	ASN1_FILE;
	OCTECT_STING;
	SIMPLIFIED_SIZE_CONSTRAINT;
	OBJECT_TYPE;
	NUMBER_LST_ITEM;
}



@header {
	#pragma warning disable 0219
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
	:	moduleDefinition*	->^(ASN1_FILE moduleDefinition*)
	;	


definitiveIdentifier
	:	'{' definitiveObjIdComponent* '}'
	;

moduleDefinition :  	modulereference	definitiveIdentifier?
			DEFINITIONS
			moduleTag?
			EXTENSIBILITY IMPLIED?
			'::=' BEGIN
			exports?
			imports?
			(
				typeAssigment
				|valueAssigment
				|valueSetAssigment
			)*
			END
			->  ^(MODULE_DEF modulereference moduleTag? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* valueSetAssigment*)
			;

moduleTag 
	:	EXPLICIT TAGS -> EXPLICIT
	| 	IMPLICIT TAGS -> IMPLICIT
	|   AUTOMATIC TAGS -> AUTOMATIC
	;			
		
definitiveObjIdComponent
	:	identifier ( '(' INT ')' )?
	|	INT;		
			
exports :
	   EXPORTS ALL ';' -> EXPORTS_ALL
	 | EXPORTS ((typereference | valuereference) (',' (typereference | valuereference))*)?  ';' 
	 	-> ^(EXPORTS typereference* valuereference*)?
;			

imports :
	IMPORTS importFromModule*  ';'	-> importFromModule*
	;
	
importFromModule
	:	(typereference | valuereference) (',' (typereference | valuereference))* FROM modulereference definitiveIdentifier?
		-> ^(IMPORTS_FROM_MODULE modulereference typereference* valuereference*  )
	;	
	
	
valueAssigment	
	:	valuereference type '::=' value	 -> ^(VAL_ASSIG valuereference type value)
	;		
		
valueSetAssigment
	:	typereference type '::=' '{' constraintBody '}'    -> ^(VAL_SET_ASSIG typereference type constraintBody)
	;		
typeAssigment 
	:	typereference '::=' type -> ^(TYPE_ASSIG typereference type)
	;	
	
/* ********************************************************************************************************************* */
/* *************************************** TYPE DEFINITION ************************************************************* */
/* ********************************************************************************************************************* */

typeTag
	:	'[' (t=UNIVERSAL | t=APPLICATION | t=PRIVATE)? INT  ']' ( impOrExp=IMPLICIT | impOrExp=EXPLICIT)? 	
			-> ^(TYPE_TAG $t? INT $impOrExp?)
	;
		

type	: typeTag?
(	 nULL							-> ^(TYPE_DEF typeTag? nULL)
	|bitStringType (SIZE sc=constraint| gen=constraint)*	-> ^(TYPE_DEF typeTag? bitStringType ^(SIMPLIFIED_SIZE_CONSTRAINT $sc)* $gen*)
	|booleanType constraint*								-> ^(TYPE_DEF typeTag? booleanType constraint*)
	|enumeratedType constraint*								-> ^(TYPE_DEF typeTag? enumeratedType constraint*)
	|integerType constraint*								-> ^(TYPE_DEF typeTag? integerType constraint*)
    |realType constraint*									-> ^(TYPE_DEF typeTag? realType constraint*)
	|stringType (SIZE sc=constraint| gen=constraint)*		-> ^(TYPE_DEF typeTag? stringType ^(SIMPLIFIED_SIZE_CONSTRAINT $sc)* $gen*)
	|referencedType	constraint*								-> ^(TYPE_DEF typeTag? referencedType constraint*)
	|sequenceOfType 										-> ^(TYPE_DEF typeTag? sequenceOfType)
	|choiceType												-> ^(TYPE_DEF typeTag? choiceType)
    |sequenceType constraint*								-> ^(TYPE_DEF typeTag? sequenceType constraint*)
    |setType												-> ^(TYPE_DEF typeTag? setType)
    |setOfType												-> ^(TYPE_DEF typeTag? setOfType)
    |objectIdentifier constraint*							-> ^(TYPE_DEF typeTag? objectIdentifier constraint*)
    |relativeOID											-> ^(TYPE_DEF typeTag? relativeOID)
)
;

nULL:	NULL;

bitStringType
	:	BIT STRING ('{' (bitStringItem (',' bitStringItem )* )? '}' )?	-> ^(BIT_STRING_TYPE bitStringItem*)
	;

bitStringItem 
	:	identifier '(' (INT|valuereference) ')'		->  ^(NUMBER_LST_ITEM identifier INT? valuereference?)
	;	
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 
	:	ENUMERATED '{' en1=enumeratedTypeItems  ( ',' ext='...' exceptionSpec? (',' en2=enumeratedTypeItems)? )? '}'
	-> ^(ENUMERATED_TYPE $en1 ($ext exceptionSpec? $en2?) ?)
	;

enumeratedTypeItems 
	:	 enumeratedLstItem (',' enumeratedLstItem)* ->enumeratedLstItem+
	;		
enumeratedLstItem	:	
	identifier ( '(' (signedNumber|valuereference) ')')? -> ^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
;
integerType
	:	INTEGER ( '{' (integerTypeListItem (',' integerTypeListItem)*)? '}')?	-> ^(INTEGER_TYPE integerTypeListItem*)
	;
	
integerTypeListItem 
	:	identifier '(' (signedNumber|valuereference) ')'	-> ^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
	;	
	
realType 
	:	REAL
	;
	
	
choiceType
	:	CHOICE '{' choiceItemsList choiceExtensionBody? '}'
	-> ^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
	;
	
choiceExtensionBody
	:	',' '...' exceptionSpec?  choiceListExtension?   (',' extMark2='...')?  
		-> ^(CHOICE_EXT_BODY exceptionSpec? choiceListExtension? $extMark2?)
	;	

choiceItemsList
	:	choiceItem (',' choiceItem)*	-> choiceItem+
	;
choiceItem
	:	identifier type				->  ^(CHOICE_ITEM identifier type)
	;	

choiceListExtension
	:	',' extensionAdditionAlternative (',' extensionAdditionAlternative)*	->	extensionAdditionAlternative+
	;	
	
extensionAdditionAlternative
	:	 '[[' versionNumber? choiceItemsList ']]'	-> ^(CHOICE_EXT_ITEM versionNumber? choiceItemsList)
		| choiceItem
	;	

sequenceType
	:	SEQUENCE '{' sequenceOrSetBody?  '}' -> ^(SEQUENCE_TYPE sequenceOrSetBody?)
	;
	
setType	:	SET '{' sequenceOrSetBody?  '}' -> ^(SET_TYPE sequenceOrSetBody?)
	;	
	
sequenceOrSetBody	:
		  componentTypeList ( ',' seqOrSetExtBody)?		-> ^(SEQUENCE_BODY componentTypeList seqOrSetExtBody?)
		| seqOrSetExtBody								-> ^(SEQUENCE_BODY seqOrSetExtBody)
	;
	
seqOrSetExtBody
	:	'...' exceptionSpec? (',' extensionAdditionList)? (',' extMark2='...'   (',' componentTypeList )? )?
	->	^(SEQUENCE_EXT_BODY exceptionSpec? extensionAdditionList? $extMark2? componentTypeList?)
	;	
	
extensionAdditionList
	:	extensionAddition (',' extensionAddition)*		-> extensionAddition+
	;	

extensionAddition
	:	componentType
	       |extensionAdditionGroup
	;
extensionAdditionGroup
	:	'[[' versionNumber? componentTypeList ']]'	-> ^(SEQUENCE_EXT_GROUP versionNumber? componentTypeList)
	;

componentTypeList 
	:	componentType  (',' componentType )*		-> componentType+
	;
	
componentType
	:	identifier type (optOrDef=OPTIONAL | optOrDef=DEFAULT value)?	-> ^(SEQUENCE_ITEM identifier type $optOrDef? value?)
	;	
	
sequenceOfType
	:	SEQUENCE (SIZE sz=constraint | gen=constraint)? OF (identifier)? type			-> ^(SEQUENCE_OF_TYPE (SIMPLIFIED_SIZE_CONSTRAINT $sz)? $gen? identifier? type)
	;
	
setOfType
	:	SET (SIZE sz=constraint | gen=constraint)? OF (identifier)? type				-> ^(SET_OF_TYPE (SIMPLIFIED_SIZE_CONSTRAINT $sz)? $gen? identifier? type)
	;		

	
stringType	:
	 OCTET STRING	->	OCTECT_STING
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
	:	str1=UID ('.' str2=UID)?	-> ^(REFERENCED_TYPE $str1 $str2?)
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
	|	(s='+'|s='-')? intPart=INT ('.' decPart=INT?)? 					->^(NUMERIC_VALUE $intPart $s? $decPart?)
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	|	MIN
	|	MAX
//	|	objectIdentifierValue
	|	charSequenceValue
	;	
	
bitStringValue
	:	'{' identifier (',' identifier)* '}'		->^(BIT_STRING_VALUE identifier+)
	;

charSequenceValue	: 
	'{' INT (',' INT)* '}'							->^(CHAR_SEQUENCE_VALUE INT+)
;
	
objectIdentifierValue
	:	'{' objectIdentifierComponent+  '}'			->objectIdentifierComponent+
	;	
objectIdentifierComponent
	:	identifier ('(' (INT | definedValue) ')' )?	->^(OBJ_LST_ITEM identifier INT? definedValue?) //3 cases identifier or valuereference or identifier(number)
	| 	INT											->^(OBJ_LST_ITEM INT)
	|	modulereference '.' valuereference			->^(OBJ_LST_ITEM modulereference valuereference)
	;


definedValue
	:	valuereference							-> ^(DEFINED_VALUE valuereference)
		| modulereference '.' valuereference	-> ^(DEFINED_VALUE modulereference valuereference)
	;

/* ********************************************************************************************************************* */
/* *************************************** Constraints DEFINITION ****************************************************** */
/* ********************************************************************************************************************* */
constraint 
	:	'(' constraintBody  exceptionSpec? ')'			->^(CONSTRAINT constraintBody  exceptionSpec?)
	;

exceptionSpec 
	:	'!' 
	(
		 signedNumber
		|valuereference
				|type ':' value
	)
														->^(EXCEPTION_SPEC signedNumber? valuereference? type? value?)
	;


constraintBody
	:	uset1=unionElement (',' extMark='...' ( ',' uset2=unionElement)?)?			-> ^(CONSTRAINT_BODY $uset1 $extMark? $uset2?)
	;
	
unionElement
	:	intersectionSetElements (UnionMark intersectionSetElements)*			-> ^(UNION_ELEMENT intersectionSetElements)+
	|	ALL EXCEPT constraintExpression										-> ^(UNION_ELEMENT_ALL_EXCEPT constraintExpression)
	;	
	
intersectionSetElements
	:	intersectionItem (IntersectionMark intersectionItem)*	->intersectionItem+
	;	
	
intersectionItem 
	:	ex1=constraintExpression (EXCEPT ex2=constraintExpression)?			-> ^(INTERSECTION_ELEMENT $ex1 $ex2?)		
	;	

constraintExpression
	: valueRangeExpression
	| subtypeExpression
	| sizeExpression
	| permittedAlphabetExpression
	| innerTypeExpression
	| patternExpression
	| '(' constraintBody ')'	->	constraintBody
	;	
	
valueRangeExpression
	: minVal=value ( (minIncl='<')? '..' (maxIncl='<')? maxVal=value)?			
		-> ^(VALUE_RANGE_EXPR $minVal ^(MAX_VAL_PRESENT $maxVal)? ^(MIN_VAL_INCLUDED $minIncl)? ^(MAX_VAL_INCLUDED $maxIncl)? )
	;


subtypeExpression: bInlc=INCLUDES? type		-> ^(SUBTYPE_EXPR type $bInlc?)
	;

sizeExpression : SIZE constraint			-> ^(SIZE_EXPR constraint)
	;
	
permittedAlphabetExpression : FROM constraint	-> ^(PERMITTED_ALPHABET_EXPR constraint)
	;

innerTypeExpression 
	: WITH COMPONENT constraint											-> ^(INNER_TYPE_EXPR constraint)
	| WITH COMPONENTS '{'
			( '...' ',')?
			namedConstraintExpression  (',' namedConstraintExpression)* 
		'}'
		-> ^(INNER_TYPE_EXPR namedConstraintExpression+)
	;

namedConstraintExpression
	:	identifier (constraint)? (eNum=PRESENT|eNum=ABSENT | eNum=OPTIONAL)?		-> ^(NAME_CONSTRAINT_EXPR identifier constraint? $eNum?)
	;	

patternExpression : PATTERN value		-> ^(PATTERN_EXPR value)
	;
	


lID	:	LID;
modulereference	:	UID;
typereference	:	UID;
valuereference 	:	LID;		
identifier	:	LID;
versionNumber	:	INT;
objectIdentifier	:	OBJECT IDENTIFIER	->OBJECT_TYPE;
relativeOID	:	RELATIVE_OID;
signedNumber	:	(s='+'|s='-')? INT			->^(NUMERIC_VALUE INT $s?)
	;

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

EXT_MARK	: '...';

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

