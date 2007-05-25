grammar asn1;
options {
	language=CSharp;
}

@header {
}

moduleDefinition :  	UID			//module id
			'DEFINITIONS'
			('EXPLICIT' 'TAGS' | 'IMPLICIT' 'TAGS' | 'AUTOMATIC' 'TAGS')?
			('EXTENSIBILITY' 'IMPLIED')?
			'::=' 'BEGIN'
			(exports)?
			(imports)?
			(
				typeAssigment
				|valueAssigment
			)*
			'END';
			
exports :
	 'EXPORTS' 'ALL' ';'
	| 'EXPORTS' (UID | LID) (',' (UID | LID))*  ';'
;			

imports :
	'IMPORTS' ((UID | LID) (',' (UID | LID))* 'FROM' UID)* ';'	
	;
	
valueAssigment	
	:	LID type '::=' value	
	;		
		
typeAssigment 
	:	UID '::=' type
	;	

type	: ('[' ('UNIVERSAL' | 'APPLICATION' | 'PRIVATE')? INT  ']' ( 'IMPLICIT' | 'EXPLICIT')? )?
(	(
	    bitStringType
	    |booleanType
	    |enumeratedType
	    |integerType
	    |octetStringType
	    |realType
	    |UID			// reference type 
	) constraint?
	|sequenceOfType
	|choiceType
        |sequenceType
)
	;


bitStringType
	:	'BIT' 'STRING' ('{' (LID '(' INT ')' (',' LID '(' INT ')' )* )? '}' )?
	;
	
booleanType
	:	'BOOLEAN'
	;
	
enumeratedType 
	:	'ENUMERATED' '{' (LID ( '(' signedNumber ')')? (',' LID ( '(' signedNumber ')')?)*)? '}'
	;	

integerType
	:	'INTEGER' ( '{' (LID '(' signedNumber ')' (',' LID '(' signedNumber ')')*)? '}')?
	;
	
realType 
	:	'REAL'
	;
	
choiceType
	:	'CHOICE' '{' (LID type (',' LID type)* )? '}'
	;

sequenceType
	:	'SEQUENCE' '{' (LID type ('OPTIONAL')?  (',' LID type ('OPTIONAL')? )*)?  '}' 
	;
	
sequenceOfType
	:	'SEQUENCE' ( '(' 'SIZE' constraint ')' )? 'OF' type
	;	

	
octetStringType
	:	'OCTET' 'STRING';
	
	
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
	:	'(' element ')'
	;

element
:	  value ( ('<')? '..' ('<')? value)?
	| 'SIZE' constraint
	;

value	:
		bitStringValue
	|	booleanValue
//	|	characterStringValue
	|	LID		//enumerated value
	|	('+'|'-')? INT ('.' INT?)? 
//	|	('+'|'-')? INT ('.' INT?)? ( ('E'|'e') ('+'|'-')? INT)?
	|	'MIN'
	|	'MAX'
	;	
	
bitStringValue
	:	Bstring
	|	Hstring
	;
		
booleanValue
	:	'TRUE'
	|	'FALSE'
	;


lID	:	LID;

		
Bstring	:
	'\'' ('0'|'1')* '\'B'
	;
Hstring	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;
/*

UnionMark  :  '|'	
|	'UNION'
	;

IntersectionMark  :	'^'	|	'INTERSECTION';
*/	
	
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
