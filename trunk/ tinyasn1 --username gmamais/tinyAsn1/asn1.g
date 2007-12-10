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
//	NUMERIC_VALUE;
	CONSTRAINT;
	EXCEPTION_SPEC;
//	SET_OF_VALUES;
	UNION_ELEMENT2;
	UNION_SET_ALL_EXCEPT;
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
	UNION_SET;
	INTERSECTION_SET;
	NUMERIC_VALUE2;
	SELECTION_TYPE;
	WITH_COMPONENT_CONSTR;
	WITH_COMPONENTS_CONSTR;
	EXCEPTION_SPEC_CONST_INT;
	EXCEPTION_SPEC_VAL_REF;
	EXCEPTION_SPEC_TYPE_VALUE;
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


@lexer::members {
System.Collections.Generic.List<IToken> tokens = new System.Collections.Generic.List<IToken>();
public override void Emit(IToken tok) {
//        state.token = token;
        token = tok;
       	tokens.Add(tok);
}
public override IToken NextToken() {
    	base.NextToken();
        if ( tokens.Count==0 ) {
            return Token.EOF_TOKEN;
        }
        IToken ret = tokens[0];
        tokens.Remove(ret);
        return ret;
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
	
moduleDefinition :  	a=modulereference	definitiveIdentifier?
			d=DEFINITIONS
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
			->  ^(MODULE_DEF[$d] modulereference EXPLICIT? IMPLICIT? AUTOMATIC? EXTENSIBILITY? exports? imports? typeAssigment* valueAssigment* /* valueSetAssigment* */)
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
	   a=EXPORTS ALL ';' -> EXPORTS_ALL[$a]
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
	:	valuereference type a='::=' value	 -> ^(VAL_ASSIG[$a] valuereference type value)
	;		

/*		
valueSetAssigment
	:	typereference type '::=' L_BRACKET setOfValues R_BRACKET    -> ^(VAL_SET_ASSIG typereference type setOfValues)
	;		
*/	
typeAssigment 
	:	SPECIAL_COMMENT* typereference a='::=' type -> ^(TYPE_ASSIG[$a] typereference type SPECIAL_COMMENT*)
	;	
	
/* ********************************************************************************************************************* */
/* *************************************** TYPE DEFINITION ************************************************************* */
/* ********************************************************************************************************************* */

typeTag
	:	a='[' (t=UNIVERSAL | t=APPLICATION | t=PRIVATE)? (INT|val=valuereference)  ']' ( impOrExp=IMPLICIT | impOrExp=EXPLICIT)? 	
			-> ^(TYPE_TAG[$a] $t? INT? ^(VALUE_REFERENCE[val.start] $val)? $impOrExp?)
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

/*
Note on constraints

(1) If Type is (literally) a SEQUENCE OF or SET OF type, the Constraint
applies on the type appearing after the keywords SEQUENCE OF or SET OF
FOR THIS REASON sequenceOfType AND setOfType ARE NOT FOLLOWED BY A constraint*
If Type is a reference to a SEQUENCE OF or SET OF type,
the Constraint applies to the SEQUENCE OF or SET OF type, and not to
the type that follows these keywords.		
(2) If several Constraints appear one after the other after Type, the possible
values for this type are those of the intersection of constraints .

*/
type	: typeTag?
(	 nULL													-> ^(TYPE_DEF typeTag? nULL)
	|bitStringType constraint*								-> ^(TYPE_DEF typeTag? bitStringType constraint*)
	|booleanType constraint*								-> ^(TYPE_DEF typeTag? booleanType constraint*)
	|enumeratedType constraint*								-> ^(TYPE_DEF typeTag? enumeratedType constraint*)
	|integerType constraint*								-> ^(TYPE_DEF typeTag? integerType constraint*)
    |realType constraint*									-> ^(TYPE_DEF typeTag? realType constraint*)
	|stringType constraint*									-> ^(TYPE_DEF typeTag? stringType constraint*)
	|referencedType	constraint*								-> ^(TYPE_DEF typeTag? referencedType constraint*)
	|sequenceOfType 										-> ^(TYPE_DEF typeTag? sequenceOfType)
	|choiceType	constraint*											-> ^(TYPE_DEF typeTag? choiceType)
    |sequenceType constraint*								-> ^(TYPE_DEF typeTag? sequenceType constraint*)
    |setType	constraint*											-> ^(TYPE_DEF typeTag? setType)
    |setOfType												-> ^(TYPE_DEF typeTag? setOfType)
    |objectIdentifier constraint*							-> ^(TYPE_DEF typeTag? objectIdentifier constraint*)
    |relativeOID	constraint*								-> ^(TYPE_DEF typeTag? relativeOID constraint*)
    |selectionType											-> ^(TYPE_DEF typeTag? selectionType)
)
;

selectionType	:	
	identifier a='<' type											->^(SELECTION_TYPE[$a] identifier type)
;

sizeShortConstraint
	:	a=SIZE constraint										-> ^(SIMPLIFIED_SIZE_CONSTRAINT[$a] constraint)
	;

nULL:	NULL;

bitStringType
	:	a=BIT STRING (L_BRACKET (bitStringItem (COMMA bitStringItem )* )? R_BRACKET )?	-> ^(BIT_STRING_TYPE[$a] bitStringItem*)
	;

bitStringItem 
	:	identifier a=L_PAREN (INT|valuereference) R_PAREN		->  ^(NUMBER_LST_ITEM[$a] identifier INT? valuereference?)
	;	
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 
	:	a=ENUMERATED L_BRACKET en1=enumeratedTypeItems  ( COMMA ext=EXT_MARK exceptionSpec? (COMMA en2=enumeratedTypeItems)? )? R_BRACKET
	-> ^(ENUMERATED_TYPE[$a] $en1 ($ext exceptionSpec? $en2?) ?)
	;

enumeratedTypeItems 
	:	 enumeratedLstItem (COMMA enumeratedLstItem)* ->enumeratedLstItem+
	;		
enumeratedLstItem	:	
	identifier ( L_PAREN (INT|valuereference) R_PAREN)? -> ^(NUMBER_LST_ITEM identifier INT? valuereference?)
;
integerType
	:	a=INTEGER ( L_BRACKET (integerTypeListItem (COMMA integerTypeListItem)*)? R_BRACKET)?	-> ^(INTEGER_TYPE[$a] integerTypeListItem*)
	;
	
integerTypeListItem 
	:	identifier a=L_PAREN (INT|valuereference) R_PAREN	-> ^(NUMBER_LST_ITEM[$a] identifier INT? valuereference?)
	;	
	
realType 
	:	REAL
	;
	
	
choiceType
	:	a=CHOICE L_BRACKET choiceItemsList choiceExtensionBody? R_BRACKET
	-> ^(CHOICE_TYPE[$a] choiceItemsList choiceExtensionBody?)
	;
	
choiceExtensionBody
	:	COMMA a=EXT_MARK exceptionSpec?  choiceListExtension?   (COMMA extMark2=EXT_MARK)?  
		-> ^(CHOICE_EXT_BODY[$a] exceptionSpec? choiceListExtension? $extMark2?)
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
	:	 a='[[' versionNumber? choiceItemsList ']]'	-> ^(CHOICE_EXT_ITEM[$a] versionNumber? choiceItemsList)
		| choiceItem
	;	

sequenceType
	:	a=SEQUENCE L_BRACKET sequenceOrSetBody?  R_BRACKET -> ^(SEQUENCE_TYPE[$a] sequenceOrSetBody?)
	;
	
setType	:	a=SET L_BRACKET sequenceOrSetBody?  R_BRACKET -> ^(SET_TYPE[$a] sequenceOrSetBody?)
	;	
	
sequenceOrSetBody	:
		  componentTypeList ( COMMA seqOrSetExtBody)?		-> ^(SEQUENCE_BODY componentTypeList seqOrSetExtBody?)
		| seqOrSetExtBody								-> ^(SEQUENCE_BODY seqOrSetExtBody)
	;
	
seqOrSetExtBody
	:	a=EXT_MARK exceptionSpec? (COMMA extensionAdditionList)? (COMMA extMark2=EXT_MARK   (COMMA componentTypeList )? )?
	->	^(SEQUENCE_EXT_BODY[$a] exceptionSpec? extensionAdditionList? $extMark2? componentTypeList?)
	;	
	
extensionAdditionList
	:	extensionAddition (COMMA extensionAddition)*		-> extensionAddition+
	;	

extensionAddition
	:	componentType
	       |extensionAdditionGroup
	;
extensionAdditionGroup
	:	a='[[' versionNumber? componentTypeList ']]'	-> ^(SEQUENCE_EXT_GROUP[$a] versionNumber? componentTypeList)
	;

componentTypeList 
	:	componentType  (COMMA componentType )*		-> componentType+
	;
	
componentType
	:	identifier type (optOrDef=OPTIONAL | optOrDef=DEFAULT value)?	-> ^(SEQUENCE_ITEM identifier type $optOrDef? ^(DEFAULT_VALUE value)?)
		| a=COMPONENTS OF type											-> ^(COMPONENTS_OF[$a] type)
	;	
	
sequenceOfType
	:	a=SEQUENCE (sizeShortConstraint | constraint)? OF (identifier)? type			-> ^(SEQUENCE_OF_TYPE[$a] sizeShortConstraint? constraint? identifier? type)
	;
	
setOfType
	:	a=SET (sizeShortConstraint | constraint)? OF (identifier)? type				-> ^(SET_OF_TYPE[$a] sizeShortConstraint? constraint? identifier? type)
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
	|GeneralizedTime
	|UTCTime
	;
	
referencedType
	:	str1=UID ('.' str2=UID)?	-> ^(REFERENCED_TYPE[$str1] $str1 $str2?)
	;	

	
/* ********************************************************************************************************************* */
/* *************************************** VALUES DEFINITION *********************************************************** */
/* ********************************************************************************************************************* */

choiceValue :	identifier a=':' value	->^(CHOICE_VALUE[$a] identifier value)
	;	

namedValue 	:	a=identifier value		->^(NAMED_VALUE[a.start] identifier value)
	;
	
/*	
namedValueList	: a=namedValue (COMMA namedValue)* 		->^(NAMED_VALUE_LIST[a.start] namedValue+)
	;
*/	
/*	
valueList 	:	
	a=value (COMMA value)* 			->^(VALUE_LIST[a.start] value+)
;	
*/
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
	|	NULL
	|	PLUS_INFINITY
	|   MINUS_INFINITY
	|	val=valuereference										->^(VALUE_REFERENCE[val.start] $val)
	|   INT
	| 	FloatingPointLiteral
//	|	(s='+'|s='-')? intPart=INT ('.' decPart=INT?)? 					->^(NUMERIC_VALUE $intPart $s? $decPart?)
	| a=L_BRACKET MANTISSA mant=INT COMMA BASE bas=INT COMMA EXPONENT exp=INT R_BRACKET -> ^(NUMERIC_VALUE2[$a] $mant $bas $exp)
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	| a=L_BRACKET objectIdentifierComponent+ R_BRACKET		->^(OBJECT_ID_VALUE[$a] objectIdentifierComponent+ )
	|   choiceValue
	| a=L_BRACKET namedValue (COMMA namedValue)* R_BRACKET 				->^(NAMED_VALUE_LIST[$a] namedValue+)
	| a=L_BRACKET value (COMMA value)* R_BRACKET						->^(VALUE_LIST[$a] value+)
	;	
	
	
/*
a CharacterStringValue is
	a string literal
or value list of 4 INT
or value list of 2 INT	
or value list that contains any of the following 
		a string literal
	or value list of 4 INT
	or value list of 2 INT	
		
restrictedCharacterStringValue	:
		StringLiteral
	|	characterStringList
	|	quadruple
	|	tuple
	;

characterStringList  	:	
	L_BRACKET charsDefn ( COMMA charsDefn)* R_BRACKET
	;

charsDefn	:
		StringLiteral
	|	quadruple
	|	tuple
	|	definedValue
	;
	
quadruple 	:	L_BRACKET INT COMMA INT COMMA INT COMMA INT R_BRACKET	;
tuple		:   L_BRACKET INT COMMA INT R_BRACKET	;
*/	
/*
objectIdentifierValue
	:	objectIdentifierComponent+  			->   ^(OBJECT_ID_VALUE objectIdentifierComponent+ )
	;	
*/
objectIdentifierComponent
	:	identifier ( L_PAREN (INT | definedValue) R_PAREN )?	->^(OBJ_LST_ITEM1 identifier INT? definedValue?) //3 cases identifier or valuereference or identifier(number)
	| 	a=INT											->^(OBJ_LST_ITEM2[$a] INT)
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
	:	a=L_PAREN uset1=unionSet (COMMA extMark=EXT_MARK ( COMMA uset2=unionSet)?)?  exceptionSpec? R_PAREN			
						->^(CONSTRAINT[$a] $uset1 $extMark? $uset2?  exceptionSpec?)
	;

exceptionSpec 
	:	'!' 
	(
		 INT											-> ^(EXCEPTION_SPEC  ^(EXCEPTION_SPEC_CONST_INT INT))
		|val=valuereference									-> ^(EXCEPTION_SPEC  ^(EXCEPTION_SPEC_VAL_REF ^(VALUE_REFERENCE[val.start] $val)))
		|type ':' value									-> ^(EXCEPTION_SPEC  ^(EXCEPTION_SPEC_TYPE_VALUE type value))
	)
														
	;


/*
setOfValues
	:	uset1=unionSet (COMMA extMark='...' ( COMMA uset2=unionSet)?)?			-> ^(SET_OF_VALUES $uset1 $extMark? $uset2?)
	;
*/	
unionSet
	:	intersectionSet (UnionMark intersectionSet)*			-> ^(UNION_SET intersectionSet+ )
	|	a=ALL EXCEPT constraintExpression							-> ^(UNION_SET_ALL_EXCEPT[$a] constraintExpression)
	;	
	
//	UNION_ELEMENT2 is synonymous to INTERSECTION_SET
intersectionSet
	:	intersectionItem (IntersectionMark intersectionItem)*	-> ^(INTERSECTION_SET   intersectionItem+)
	;	
	
intersectionItem 
	:	ex1=constraintExpression (EXCEPT ex2=constraintExpression)?			-> ^(INTERSECTION_ELEMENT $ex1 $ex2?)		
	;	

//The grammar is unambigues since (NULL) can be interpreted as both single value constraint and Type inclusion constraint

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
	| L_PAREN unionSet R_PAREN	->	unionSet
	;	
	
valueRangeExpression
	: minVal=lowerEndValue ( (minIncl='<')? DOUBLE_DOT (maxIncl='<')? maxVal=upperEndValue)?			
		-> ^(VALUE_RANGE_EXPR $minVal ^(MAX_VAL_PRESENT $maxVal)? ^(MIN_VAL_INCLUDED $minIncl)? ^(MAX_VAL_INCLUDED $maxIncl)? )
	;

lowerEndValue
	:	value
	| MIN
	;

upperEndValue 
	:	value
	| MAX
	;		


subtypeExpression: bInlc=INCLUDES? type		-> ^(SUBTYPE_EXPR type $bInlc?)
	;

sizeExpression : a=SIZE constraint			-> ^(SIZE_EXPR[$a] constraint)
	;
	
permittedAlphabetExpression : a=FROM constraint	-> ^(PERMITTED_ALPHABET_EXPR[$a] constraint)
	;

innerTypeExpression 
	: a=WITH COMPONENT constraint											-> ^(WITH_COMPONENT_CONSTR[$a] constraint)
	| a=WITH COMPONENTS L_BRACKET
			( EXT_MARK COMMA)?
			namedConstraintExpression  (COMMA namedConstraintExpression)* 
		R_BRACKET
		-> ^(WITH_COMPONENTS_CONSTR[$a] EXT_MARK? namedConstraintExpression+)
	;

namedConstraintExpression
	:	(identifier | MANTISSA| BASE|EXPONENT) (constraint)? (eNum=PRESENT|eNum=ABSENT | eNum=OPTIONAL)?		
						-> ^(NAME_CONSTRAINT_EXPR identifier? MANTISSA? BASE? EXPONENT? constraint? $eNum?)
	;	

patternExpression : a=PATTERN value		-> ^(PATTERN_EXPR[$a] value)
	;
	


lID	:	LID;
modulereference	:	UID;
typereference	:	UID;
valuereference 	:	LID;		
identifier	:	LID;
versionNumber	:	INT ':'	->	INT;
objectIdentifier	:	a=OBJECT IDENTIFIER	->OBJECT_TYPE[$a];
relativeOID	:	RELATIVE_OID;
//signedNumber	:	(s='+'|s='-')? INT			->^(NUMERIC_VALUE INT $s?)
//	;

/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */
/* ***************************************************************************************************************** */

PLUS_INFINITY : 'PLUS-INFINITY';
MINUS_INFINITY	: 'MINUS-INFINITY';		
GeneralizedTime  :	'GeneralizedTime';
UTCTime  :	'UTCTime';
MANTISSA	: 'mantissa';
BASE		: 'base';
EXPONENT	: 'exponent';
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
DOUBLE_DOT  : '..';

BitStringLiteral	:
	'\'' ('0'|'1'|' ' | '\t' | '\r' | '\n')* '\'B'
	;
	

OctectStringLiteral	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F'|' ' | '\t' | '\r' | '\n')* '\'H'
	;

StringLiteral 	: 	STR+ ;

fragment
STR 	:	'"' ( options {greedy=false;} : .)* '"' ;
			
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;


fragment	
INT	:	('+'|'-')? ( '0' | ('1'..'9') ('0'..'9')*);

/*
fragment
FloatingPointLiteral
    :   INT (DOT ('0'..'9')*)? Exponent?
	;
*/

	
fragment
DIGITS
	:	('0'..'9')+;

FloatingPointLiteral
    :
    d=INT r=DOUBLE_DOT
    	  {
    	  $d.Type = INT;
    	  Emit($d);$d.Line = input.Line;
          $r.Type = DOUBLE_DOT;
    	  Emit($r);$r.Line = input.Line;
    	  }
    |	  INT DOT (DIGITS)? (Exponent)? 
    | 	d = INT { $d.Type = INT; Emit($d);$d.Line = input.Line;}
    ;

	
	
DOT	:	 '.';	





fragment
Exponent : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;


WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

SPECIAL_COMMENT
    :   '--@' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') 
    ;

COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;



/* ********************** UNSUPPORTED ASN.1 FEATURES **********************************/

/*
definitiveIdentifier in module definition. (parsed but ignored)
valueSetAssigments

*/

