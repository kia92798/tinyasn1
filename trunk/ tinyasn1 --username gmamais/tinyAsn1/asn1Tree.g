tree grammar asn1Tree;

options {
	tokenVocab=asn1; // reuse token types
	ASTLabelType=CommonTree; // $label will have type CommonTree
	language=CSharp;
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

moduleDefinitions 	:	moduleDefinition*;

moduleTag 
	:	EXPLICIT
	| 	IMPLICIT
	|   AUTOMATIC
	;			


moduleDefinition
	:	
	^(MODULE_DEF modulereference moduleTag? EXTENSIBILITY?	exports? imports? typeAssigment* valueAssigment* valueSetAssigment*)
	;	
	
exports :
	  ^(EXPORTS ALL)
	| ^(EXPORTS typereference* valuereference*)
	| EXPORTS
;			
	
imports :
	importFromModule+
	;
	
importFromModule
	:	^(IMPORTS typereference* valuereference* modulereference)
	;	
	
	
valueAssigment	
	:	^(VAL_ASSIG valuereference type value)
	;		
		
valueSetAssigment
	:	^(VAL_SET_ASSIG typereference type constraintBody)
	;		
typeAssigment 
	:	 ^(TYPE_ASSIG typereference type)
	;	
	

/* ********************************************************************************************************************* */
/* *************************************** TYPE DEFINITION ************************************************************* */
/* ********************************************************************************************************************* */

typeTag
	:	^(TYPE_TAG (UNIVERSAL | APPLICATION | PRIVATE)? INT ( IMPLICIT | EXPLICIT)?)
	;
	
sizeConstraint 
	:	^(SIZE constraint)
	;	
type	: typeTag?
(	 ^(TYPE_DEF typeTag? nULL)
	|^(TYPE_DEF typeTag? bitStringType sizeConstraint* constraint*)
	|^(TYPE_DEF typeTag? booleanType constraint*)
	|^(TYPE_DEF typeTag? enumeratedType constraint*)
	|^(TYPE_DEF typeTag? integerType constraint*)
    |^(TYPE_DEF typeTag? realType constraint*)
	|^(TYPE_DEF typeTag? stringType sizeConstraint* constraint*)
	|^(TYPE_DEF typeTag? referencedType constraint*)
	|^(TYPE_DEF typeTag? sequenceOfType)
	|^(TYPE_DEF typeTag? choiceType)
    |^(TYPE_DEF typeTag? sequenceType constraint*)
    |^(TYPE_DEF typeTag? setType)
    |^(TYPE_DEF typeTag? setOfType)
    |^(TYPE_DEF typeTag? objectIdentifier constraint*)
    |^(TYPE_DEF typeTag? relativeOID)
)
;

nULL:	NULL;

bitStringType
	:	^(BIT_STRING_TYPE bitStringItem*)
	;

bitStringItem 
	:	^(BIT_STRING_ITEM identifier INT? valuereference?)
	;	
	
booleanType
	:	BOOLEAN
	;
	
enumeratedType 	
	:   ^(ENUMERATED_TYPE enumeratedTypeItems ('...' exceptionSpec? enumeratedTypeItems? )?)
	;

enumeratedTypeItems 
	:	 enumeratedLstItem+
	;	
		
enumeratedLstItem	:	
	 ^(ENUMERATED_LST_ITEM identifier signedNumber? valuereference?)
;

integerType
	:	^(INTEGER_TYPE integerTypeListItem*)
	;
	
integerTypeListItem 
	:	^(INTEGER_LST_ITEM identifier signedNumber? valuereference?)
	;	
	
realType 
	:	REAL
	;
	
	
choiceType
	:	^(CHOICE_TYPE choiceItemsList choiceExtensionBody?)
	;
	
choiceExtensionBody
	:	^(CHOICE_EXT_BODY exceptionSpec? choiceListExtension? '...'?)
	;	

choiceItemsList
	:	choiceItem+
	;
choiceItem
	:	^(CHOICE_ITEM identifier type)
	;	

choiceListExtension
	:	extensionAdditionAlternative+
	;	
	
extensionAdditionAlternative
	:	 ^(CHOICE_EXT_ITEM versionNumber? choiceItemsList)
		| choiceItem
	;	

sequenceType
	:	^(SEQUENCE_TYPE sequenceOrSetBody?)
	;
	
setType	:	^(SET_TYPE sequenceOrSetBody?)
	;	
	
sequenceOrSetBody	:
		  ^(SEQUENCE_BODY componentTypeList seqOrSetExtBody?)
		| ^(SEQUENCE_BODY seqOrSetExtBody)
	;
	
seqOrSetExtBody
	:	^(SEQUENCE_EXT_BODY exceptionSpec? extensionAdditionList? ('...' componentTypeList?)? )
	;	
	
extensionAdditionList
	:	extensionAddition+
	;	

extensionAddition
	:	 componentType
	    |extensionAdditionGroup
	;
extensionAdditionGroup
	:	^(SEQUENCE_EXT_GROUP versionNumber? componentTypeList)
	;

componentTypeList 
	:	componentType+
	;
	
componentType
	:	^(SEQUENCE_ITEM identifier type (optOrDef=OPTIONAL | optOrDef=DEFAULT )? value?)
	;	
	
sequenceOfType
	:	^(SEQUENCE_OF_TYPE (SIZE constraint)? constraint? identifier? type)
	;
	
setOfType
	:	^(SET_OF_TYPE (SIZE constraint)? constraint? identifier? type)
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
	:	^(REFERENCED_TYPE UID UID?)
	;	

	
/* ********************************************************************************************************************* */
/* *************************************** VALUES DEFINITION *********************************************************** */
/* ********************************************************************************************************************* */

value	:
		BitStringLiteral
	|	bitStringValue+
	|	OctectStringLiteral
	|	TRUE
	|	FALSE
	|	StringLiteral
	|	valuereference		
	|	^(NUMERIC_VALUE (s='+'|s='-')? intPart=INT decPart=INT?)
	|	MIN
	|	MAX
	|	objectIdentifierComponent+
	|	charSequenceValue+
	;	
	
bitStringValue
	:	^(BIT_STRING_VALUE identifier)
	;

charSequenceValue	: 
	^(CHAR_SEQUENCE_VALUE INT)
;
	
objectIdentifierComponent
	:	^(OBJ_LST_ITEM identifier INT? definedValue?) //3 cases identifier or valuereference or identifier(number)
	| 	^(OBJ_LST_ITEM INT)
	|	^(OBJ_LST_ITEM modulereference valuereference)
	;


definedValue
	:	  ^(DEFINED_VALUE valuereference)
		| ^(DEFINED_VALUE modulereference valuereference)
	;

/* ********************************************************************************************************************* */
/* *************************************** Constraints DEFINITION ****************************************************** */
/* ********************************************************************************************************************* */
constraint 
	:	^(CONSTRAINT constraintBody  exceptionSpec?)
	;

exceptionSpec 
	:	^(EXCEPTION_SPEC (signedNumber |valuereference | (type value) ) )
	;


constraintBody
	:	^(CONSTRAINT_BODY uset1=unionSet+ ('...' uset2=unionSet*)?)
	;
	
unionSet
	:	^(UNION_SET intersectionSet)
	|	^(UNION_SET_ALL_EXCEPT constraintExpression)
	;	
	
intersectionSet
	:	intersectionItem+
	;	
	
intersectionItem 
	:	^(INTERSECTION_ELEMENT ex1=constraintExpression ex2=constraintExpression?)		
	;	

constraintExpression
	: valueRangeExpression
	| subtypeExpression
	| sizeExpression
	| permittedAlphabetExpression
	| innerTypeExpression
	| patternExpression
	| constraintBody
	;	
	
valueRangeExpression 
	:	 ^(VALUE_RANGE_EXPR minVal=value maxValuePresent? minValIncluded? maxValIncluded?)
	;
	
maxValuePresent
	:	^(MAX_VAL_PRESENT maxVal=value) 
	;

minValIncluded
	: ^(MIN_VAL_INCLUDED '<')	
	;
	
maxValIncluded
	:	^(MAX_VAL_INCLUDED '<')
	;	

subtypeExpression: ^(SUBTYPE_EXPR type bInlc=INCLUDES?)
	;

sizeExpression : ^(SIZE_EXPR constraint)
	;
	
permittedAlphabetExpression : ^(PERMITTED_ALPHABET_EXPR constraint)
	;

innerTypeExpression 
	:  ^(INNER_TYPE_EXPR constraint)
	| ^(INNER_TYPE_EXPR namedConstraintExpression+)
	;

namedConstraintExpression
	:	^(NAME_CONSTRAINT_EXPR identifier constraint? (eNum=PRESENT|eNum=ABSENT | eNum=OPTIONAL)?)
	;	

patternExpression : ^(PATTERN_EXPR value)
	;
	
	
	
lID	:	LID;
modulereference	:	UID;
typereference	:	UID;
valuereference 	:	LID;		
identifier	:	LID;
versionNumber	:	INT;
objectIdentifier	:	OBJECT IDENTIFIER;
relativeOID	:	RELATIVE_OID;
signedNumber	:	('+'|'-')? INT;	


