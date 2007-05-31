lexer grammar asn1;
options {
  language=CSharp;

}

T73 : '::=' ;
T74 : '{' ;
T75 : '}' ;
T76 : '(' ;
T77 : ')' ;
T78 : ';' ;
T79 : ',' ;
T80 : '[' ;
T81 : ']' ;
T82 : '...' ;
T83 : '[[' ;
T84 : ']]' ;
T85 : '.' ;
T86 : '+' ;
T87 : '-' ;
T88 : '<' ;
T89 : '..' ;
T90 : '!' ;
T91 : ':' ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 371
UnionMark  :  '|'|'UNION';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 373
IntersectionMark  :	'^' | 'INTERSECTION';
	

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 376
DEFINITIONS :	 'DEFINITIONS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 378
EXPLICIT:	 'EXPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 380
TAGS 	:	'TAGS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 382
IMPLICIT:	'IMPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 384
AUTOMATIC	:	'AUTOMATIC';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 386
EXTENSIBILITY	:	'EXTENSIBILITY';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 388
IMPLIED :	'IMPLIED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 390
BEGIN	:	'BEGIN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 391
END	:	'END';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 393
EXPORTS	:	'EXPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 395
ALL	: 	'ALL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 397
IMPORTS	:	'IMPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 399
FROM	:	'FROM';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 401
UNIVERSAL	: 'UNIVERSAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 402
APPLICATION	: 'APPLICATION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 403
PRIVATE		:'PRIVATE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 404
BIT	: 'BIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 406
STRING	:	'STRING';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 408
BOOLEAN :	'BOOLEAN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 410
ENUMERATED	:'ENUMERATED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 412
INTEGER	:	'INTEGER';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 414
REAL	:	'REAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 416
CHOICE	:	'CHOICE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 418
SEQUENCE	:'SEQUENCE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 420
OPTIONAL	:'OPTIONAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 422
SIZE	:	'SIZE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 424
OF	:	'OF';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 426
OCTET	:	'OCTET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 428
MIN	: 	'MIN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 430
MAX	:	'MAX';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 432
TRUE	:	'TRUE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 434
FALSE	:	'FALSE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 436
ABSENT	:	'ABSENT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 438
PRESENT	:	'PRESENT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 440
WITH 	:	'WITH';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 441
COMPONENT	: 'COMPONENT';		
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 442
COMPONENTS 	: 'COMPONENTS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 443
DEFAULT 	: 'DEFAULT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 444
NULL		:'NULL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 445
PATTERN		:'PATTERN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 446
OBJECT 		:'OBJECT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 447
IDENTIFIER	:'IDENTIFIER';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 448
RELATIVE_OID	:'RELATIVE-OID';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 449
NumericString	:'NumericString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 450
PrintableString	:'PrintableString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 451
VisibleString	:'VisibleString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 452
IA5String	:'IA5String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 453
TeletexString	:'TeletexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 454
VideotexString	:'VideotexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 455
GraphicString	:'GraphicString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 456
GeneralString	:'GeneralString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 457
UniversalString	:'UniversalString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 458
BMPString	:'BMPString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 459
UTF8String	:'UTF8String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 460
INCLUDES	:'INCLUDES';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 461
EXCEPT		:'EXCEPT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 463
SET		:'SET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 465
BitStringLiteral	:
	'\'' ('0'|'1')* '\'B'
	;
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 468
OctectStringLiteral	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;


// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 473
StringLiteral 	: 	STR+ ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 475
fragment
STR 	:	'"' ( options {greedy=false;} : .)* '"' ;
			
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 478
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 481
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 484
INT	:	( '0' | ('1'..'9') ('0'..'9')*);

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 490
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 493
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 497
COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;



