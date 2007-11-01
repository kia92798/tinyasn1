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
	OBJ_LST_ITEM1;
	OBJ_LST_ITEM2;
	DEFINED_VALUE;
	NUMERIC_VALUE;
	CONSTRAINT;
	EXCEPTION_SPEC;
	SET_OF_VALUES;
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
//	BIT_STRING_VALUE;
	CHAR_SEQUENCE_VALUE;
	EXPORTS_ALL;
	IMPORTS_FROM_MODULE;
	ASN1_FILE;
	OCTECT_STING;
	SIMPLIFIED_SIZE_CONSTRAINT;
	OBJECT_TYPE;
	NUMBER_LST_ITEM;
	DEFAULT_VALUE;
	VALUE_REFERENCE;
	COMPONENTS_OF;
	NAMED_VALUE;
	NAMED_VALUE_LIST;
	VALUE_LIST;
	CHOICE_VALUE;
	OBJECT_ID_VALUE;
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
	:	L_BRACKET definitiveObjIdComponent* R_BRACKET
	;

definitiveObjIdComponent
	:	identifier ( L_PAREN INT R_PAREN )?
	|	INT
	;	
	
moduleDefinition :  	modulereference	definitiveIdentifier?
			DEFINITIONS
			//			moduleTag?
			(EXPLICIT TAGS
			|IMPLICIT TAGS
			| AUTOMATIC TAGS)?
			(EXTENSIBILITY IMPLIED)?
			'::=' BEGIN
			exports?
			imports?
			(
				typeAssigment
				|valueAssigment
//				|valueSetAssigment
			)*
			END
//			->  ^(MODULE_DEF modulereference moduleTag? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* valueSetAssigment*)
			->  ^(MODULE_DEF modulereference EXPLICIT? IMPLICIT? AUTOMATIC? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* /* valueSetAssigment* */)
			;
/*
EXPLICIT TAGS (default)==> all tags in explicit mode (i.e. multiple tags per type are encoded in BER)
IMPLICIT TAGS 	==>	all tags are implicit
AUTOMATIC TAGS	==> the components of all its structured types (SEQUENCE,SET or CHOICE) are automatically tagged by the compiler starting 
	from 0 by one-increment. By default, every component is tagged in the implicit mode except if it is a CHOICE type, an open type or a parameter 
		that is a type.

EXTENSIBILITY ==> An ENUMERATED, SEQUENCE, SET or CHOICE type that does not include an
	extension marker is extensible if the module includes the EXTENSIBILITY
	IMPLIED clause in its header
*/			
			


	
			
exports :
	   EXPORTS ALL ';' -> EXPORTS_ALL
	 | EXPORTS ((typereference | valuereference) (COMMA (typereference | valuereference))*)?  ';' 
	 	-> ^(EXPORTS typereference* valuereference*)?
;			

imports :
	IMPORTS importFromModule*  ';'	-> importFromModule*
	;
	
importFromModule
	:	(typereference | valuereference) (COMMA (typereference | valuereference))* FROM modulereference definitiveIdentifier?
		-> ^(IMPORTS_FROM_MODULE modulereference typereference* valuereference*  )
	;	
	
	
valueAssigment	
	:	valuereference type '::=' value	 -> ^(VAL_ASSIG valuereference type value)
	;		

/*		
valueSetAssigment
	:	typereference type '::=' L_BRACKET setOfValues R_BRACKET    -> ^(VAL_SET_ASSIG typereference type setOfValues)
	;		
*/	
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
/*
* In a given context, two tags are considered to be diferent if they are of diferent classes or if their respective numbers are diferent.
* If tagging class is missing (i.e. no UNIVERSAL, or  APPLICATION, or PRIVATE) are of context-specific class --> The tags make sense only inside the scope
	of the Father (father may be SEQUENCE, SET etc) --> they do not polute the global space
* UNIVERSAL   ==> used by people designing/extending ASN.1 
* APPLICATION ==> to tag types that would be referenced several times in a speci?cation
* PRIVATE ==> use of PRIVATE class tags is not recommended since 1994
* EXPLICIT (Default)==> In BER, more than one tags are encoded. Eg in Afters ::= CHOICE { cheese [0] IA5String, dessert [1] IA5String }
			the two tags [0] and [UNIVERSAL 22] are encoded if the alternative cheese is chosen
* IMPLICIT ==> Only one tag is encoded ; a tag marked IMPLICIT overwrites the tag that follows it (recursively)
*/		

type	: typeTag?
(	 nULL													-> ^(TYPE_DEF typeTag? nULL)
	|bitStringType (sizeShortConstraint| constraint)*		-> ^(TYPE_DEF typeTag? bitStringType sizeShortConstraint* constraint*)
	|booleanType constraint*								-> ^(TYPE_DEF typeTag? booleanType constraint*)
	|enumeratedType constraint*								-> ^(TYPE_DEF typeTag? enumeratedType constraint*)
	|integerType constraint*								-> ^(TYPE_DEF typeTag? integerType constraint*)
    |realType constraint*									-> ^(TYPE_DEF typeTag? realType constraint*)
	|stringType (sizeShortConstraint| constraint)*			-> ^(TYPE_DEF typeTag? stringType sizeShortConstraint* constraint*)
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

sizeShortConstraint
	:	SIZE constraint										-> ^(SIMPLIFIED_SIZE_CONSTRAINT constraint)
	;

nULL:	NULL;

bitStringType
	:	BIT STRING (L_BRACKET (bitStringItem (COMMA bitStringItem )* )? R_BRACKET )?	-> ^(BIT_STRING_TYPE bitStringItem*)
	;

bitStringItem 
	:	identifier L_PAREN (INT|valuereference) R_PAREN		->  ^(NUMBER_LST_ITEM identifier INT? valuereference?)
	;	
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 
	:	ENUMERATED L_BRACKET en1=enumeratedTypeItems  ( COMMA ext='...' exceptionSpec? (COMMA en2=enumeratedTypeItems)? )? R_BRACKET
	-> ^(ENUMERATED_TYPE $en1 ($ext exceptionSpec? $en2?) ?)
	;

enumeratedTypeItems 
	:	 enumeratedLstItem (COMMA enumeratedLstItem)* ->enumeratedLstItem+
	;		
enumeratedLstItem	:	
	identifier ( L_PAREN (signedNumber|valuereference) R_PAREN)? -> ^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
;
integerType
	:	INTEGER ( L_BRACKET (integerTypeListItem (COMMA integerTypeListItem)*)? R_BRACKET)?	-> ^(INTEGER_TYPE integerTypeListItem*)
	;
	
integerTypeListItem 
	:	identifier L_PAREN (signedNumber|valuereference) R_PAREN	-> ^(NUMBER_LST_ITEM identifier signedNumber? valuereference?)
	;	
	
realType 
	:	REAL
	;
	
	
choiceType
	:	CHOICE L_BRACKET choiceItemsList choiceExtensionBody? R_BRACKET
	-> ^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
	;
	
choiceExtensionBody
	:	COMMA '...' exceptionSpec?  choiceListExtension?   (COMMA extMark2='...')?  
		-> ^(CHOICE_EXT_BODY exceptionSpec? choiceListExtension? $extMark2?)
	;	

choiceItemsList
	:	choiceItem (COMMA choiceItem)*	-> choiceItem+
	;
choiceItem
	:	identifier type				->  ^(CHOICE_ITEM identifier type)
	;	

choiceListExtension
	:	COMMA extensionAdditionAlternative (COMMA extensionAdditionAlternative)*	->	extensionAdditionAlternative+
	;	
	
extensionAdditionAlternative
	:	 '[[' versionNumber? choiceItemsList ']]'	-> ^(CHOICE_EXT_ITEM versionNumber? choiceItemsList)
		| choiceItem
	;	

sequenceType
	:	SEQUENCE L_BRACKET sequenceOrSetBody?  R_BRACKET -> ^(SEQUENCE_TYPE sequenceOrSetBody?)
	;
	
setType	:	SET L_BRACKET sequenceOrSetBody?  R_BRACKET -> ^(SET_TYPE sequenceOrSetBody?)
	;	
	
sequenceOrSetBody	:
		  componentTypeList ( COMMA seqOrSetExtBody)?		-> ^(SEQUENCE_BODY componentTypeList seqOrSetExtBody?)
		| seqOrSetExtBody								-> ^(SEQUENCE_BODY seqOrSetExtBody)
	;
	
seqOrSetExtBody
	:	'...' exceptionSpec? (COMMA extensionAdditionList)? (COMMA extMark2='...'   (COMMA componentTypeList )? )?
	->	^(SEQUENCE_EXT_BODY exceptionSpec? extensionAdditionList? $extMark2? componentTypeList?)
	;	
	
extensionAdditionList
	:	extensionAddition (COMMA extensionAddition)*		-> extensionAddition+
	;	

extensionAddition
	:	componentType
	       |extensionAdditionGroup
	;
extensionAdditionGroup
	:	'[[' versionNumber? componentTypeList ']]'	-> ^(SEQUENCE_EXT_GROUP versionNumber? componentTypeList)
	;

componentTypeList 
	:	componentType  (COMMA componentType )*		-> componentType+
	;
	
componentType
	:	identifier type (optOrDef=OPTIONAL | optOrDef=DEFAULT value)?	-> ^(SEQUENCE_ITEM identifier type $optOrDef? ^(DEFAULT_VALUE value)?)
		| COMPONENTS OF type											-> ^(COMPONENTS_OF type)
	;	
	
sequenceOfType
	:	SEQUENCE (sizeShortConstraint | constraint)? OF (identifier)? type			-> ^(SEQUENCE_OF_TYPE sizeShortConstraint? constraint? identifier? type)
	;
	
setOfType
	:	SET (sizeShortConstraint | constraint)? OF (identifier)? type				-> ^(SET_OF_TYPE sizeShortConstraint? constraint? identifier? type)
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

choiceValue :	identifier ':' value	->^(CHOICE_VALUE identifier value)
	;	

namedValue 	:	identifier value		->^(NAMED_VALUE identifier value)
	;
	
namedValueList	: namedValue (COMMA namedValue)* 		->^(NAMED_VALUE_LIST namedValue+)
	;
	
valueList 	:	
	value (COMMA value)* 			->^(VALUE_LIST value+)
;	

/*
To resolve another grammar Ambiguouity, we no more declare bitStringValue. The parser will only return valueList. Extra checking 
must be done during semantic checking.
bitStringValue
	:	L_BRACKET identifier (COMMA identifier)* R_BRACKET		->^(BIT_STRING_VALUE identifier+)
	;
*/	


/*
Grammar is ambiguous. For example
{ id 10} can be both objectIdentifierValue and namedValueList. The only way to resolve it is during Semantic checking. This parser
will always return objectIdentifierValue for such input
The same applies for {id}. It can be both objectIdentifierValue or valueList. It will be resolved during Semantic checking.
*/
value	:
		BitStringLiteral
//	|	bitStringValue
	|	OctectStringLiteral
	|	TRUE
	|	FALSE
	|	StringLiteral
	|	val=valuereference										->^(VALUE_REFERENCE $val)
	|	(s='+'|s='-')? intPart=INT ('.' decPart=INT?)? 					->^(NUMERIC_VALUE $intPart $s? $decPart?)
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	|	MIN
	|	MAX
	| L_BRACKET objectIdentifierValue R_BRACKET		->objectIdentifierValue
//	|	charSequenceValue
	|   choiceValue
	| L_BRACKET namedValueList R_BRACKET 				->namedValueList
	| L_BRACKET valueList R_BRACKET						->valueList
	;	
	

charSequenceValue	: 
	L_BRACKET INT (COMMA INT)* R_BRACKET							->^(CHAR_SEQUENCE_VALUE INT+)
;
	
objectIdentifierValue
	:	objectIdentifierComponent+  			->   ^(OBJECT_ID_VALUE objectIdentifierComponent+ )
	;	

objectIdentifierComponent
	:	identifier ( L_PAREN (INT | definedValue) R_PAREN )?	->^(OBJ_LST_ITEM1 identifier INT? definedValue?) //3 cases identifier or valuereference or identifier(number)
	| 	INT											->^(OBJ_LST_ITEM2 INT)
	|	modulereference '.' valuereference			->^(DEFINED_VALUE modulereference valuereference)
	;


definedValue
	:	valuereference							-> ^(DEFINED_VALUE valuereference)
		| modulereference '.' valuereference	-> ^(DEFINED_VALUE modulereference valuereference)
	;

/* ********************************************************************************************************************* */
/* *************************************** Constraints DEFINITION ****************************************************** */
/* ********************************************************************************************************************* */
constraint 
	:	L_PAREN setOfValues  exceptionSpec? R_PAREN			->^(CONSTRAINT setOfValues  exceptionSpec?)
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


setOfValues
	:	uset1=unionElement (COMMA extMark='...' ( COMMA uset2=unionElement)?)?			-> ^(SET_OF_VALUES $uset1 $extMark? $uset2?)
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
	: valueRangeExpression		//single value & range constraint. Single value can be applied to any type.
								//Range constraint can be applied to INTEGER and REAL
	| subtypeExpression      	//inclusion constraint, it can be applied to any type except CHARACTER STRING
	| sizeExpression			//applicable to BIT, OCTET, CHARACTER STRING and SEQUENCE OF, SET OF
								//The constraint that appears within a SIZE constraint must be a subset of INTEGER(0..MAX)
								//In other words, the constraint inside size can contain unions of single integer values, integer ranges
	| permittedAlphabetExpression
	| innerTypeExpression
	| patternExpression
	| L_PAREN unionElement R_PAREN	->	unionElement
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
	| WITH COMPONENTS L_BRACKET
			( '...' COMMA)?
			namedConstraintExpression  (COMMA namedConstraintExpression)* 
		R_BRACKET
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
versionNumber	:	INT ':'	->	INT;
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
L_BRACKET	:	'{';	
R_BRACKET	:	'}';	
L_PAREN		:	'(';
R_PAREN		:	')';
COMMA		:	',';

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



/* ********************** UNSUPPORTED ASN.1 FEATURES **********************************/

/*
definitiveIdentifier in module definition. (parsed but ignored)
valueSetAssigments

*/

