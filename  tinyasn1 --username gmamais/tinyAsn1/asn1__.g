lexer grammar asn1;
options {
  language=CSharp;

}

T120 : '{' ;
T121 : '}' ;
T122 : '::=' ;
T123 : '(' ;
T124 : ')' ;
T125 : ';' ;
T126 : ',' ;
T127 : '[' ;
T128 : ']' ;
T129 : '...' ;
T130 : '[[' ;
T131 : ']]' ;
T132 : '.' ;
T133 : '+' ;
T134 : '-' ;
T135 : '!' ;
T136 : ':' ;
T137 : '<' ;
T138 : '..' ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 432
UnionMark  :  '|'|'UNION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 433
IntersectionMark  :	'^' | 'INTERSECTION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 434
DEFINITIONS :	 'DEFINITIONS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 435
EXPLICIT:	 'EXPLICIT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 436
TAGS 	:	'TAGS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 437
IMPLICIT:	'IMPLICIT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 438
AUTOMATIC	:	'AUTOMATIC';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 439
EXTENSIBILITY	:	'EXTENSIBILITY';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 440
IMPLIED :	'IMPLIED';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 441
BEGIN	:	'BEGIN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 442
END	:	'END';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 443
EXPORTS	:	'EXPORTS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 444
ALL	: 	'ALL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 445
IMPORTS	:	'IMPORTS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 446
FROM	:	'FROM';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 447
UNIVERSAL	: 'UNIVERSAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 448
APPLICATION	: 'APPLICATION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 449
PRIVATE		:'PRIVATE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 450
BIT	: 'BIT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 451
STRING	:	'STRING';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 452
BOOLEAN :	'BOOLEAN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 453
ENUMERATED	:'ENUMERATED';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 454
INTEGER	:	'INTEGER';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 455
REAL	:	'REAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 456
CHOICE	:	'CHOICE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 457
SEQUENCE	:'SEQUENCE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 458
OPTIONAL	:'OPTIONAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 459
SIZE	:	'SIZE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 460
OF	:	'OF';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 461
OCTET	:	'OCTET';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 462
MIN	: 	'MIN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 463
MAX	:	'MAX';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 464
TRUE	:	'TRUE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 465
FALSE	:	'FALSE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 466
ABSENT	:	'ABSENT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 467
PRESENT	:	'PRESENT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 468
WITH 	:	'WITH';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 469
COMPONENT	: 'COMPONENT';		
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 470
COMPONENTS 	: 'COMPONENTS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 471
DEFAULT 	: 'DEFAULT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 472
NULL		:'NULL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 473
PATTERN		:'PATTERN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 474
OBJECT 		:'OBJECT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 475
IDENTIFIER	:'IDENTIFIER';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 476
RELATIVE_OID	:'RELATIVE-OID';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 477
NumericString	:'NumericString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 478
PrintableString	:'PrintableString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 479
VisibleString	:'VisibleString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 480
IA5String	:'IA5String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 481
TeletexString	:'TeletexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 482
VideotexString	:'VideotexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 483
GraphicString	:'GraphicString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 484
GeneralString	:'GeneralString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 485
UniversalString	:'UniversalString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 486
BMPString	:'BMPString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 487
UTF8String	:'UTF8String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 488
INCLUDES	:'INCLUDES';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 489
EXCEPT		:'EXCEPT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 490
SET		:'SET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 492
BitStringLiteral	:
	'\'' ('0'|'1')* '\'B'
	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 496
OctectStringLiteral	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 500
StringLiteral 	: 	STR+ ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 502
fragment
STR 	:	'"' ( options {greedy=false;} : .)* '"' ;
			
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 505
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 508
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 511
INT	:	( '0' | ('1'..'9') ('0'..'9')*);


// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 514
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 517
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 521
COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;

