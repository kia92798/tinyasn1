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

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 356
UnionMark  :  '|'|'UNION';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 358
IntersectionMark  :	'^' | 'INTERSECTION';
	

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 361
DEFINITIONS :	 'DEFINITIONS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 363
EXPLICIT:	 'EXPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 365
TAGS 	:	'TAGS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 367
IMPLICIT:	'IMPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 369
AUTOMATIC	:	'AUTOMATIC';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 371
EXTENSIBILITY	:	'EXTENSIBILITY';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 373
IMPLIED :	'IMPLIED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 375
BEGIN	:	'BEGIN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 376
END	:	'END';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 378
EXPORTS	:	'EXPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 380
ALL	: 	'ALL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 382
IMPORTS	:	'IMPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 384
FROM	:	'FROM';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 386
UNIVERSAL	: 'UNIVERSAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 387
APPLICATION	: 'APPLICATION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 388
PRIVATE		:'PRIVATE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 389
BIT	: 'BIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 391
STRING	:	'STRING';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 393
BOOLEAN :	'BOOLEAN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 395
ENUMERATED	:'ENUMERATED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 397
INTEGER	:	'INTEGER';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 399
REAL	:	'REAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 401
CHOICE	:	'CHOICE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 403
SEQUENCE	:'SEQUENCE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 405
OPTIONAL	:'OPTIONAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 407
SIZE	:	'SIZE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 409
OF	:	'OF';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 411
OCTET	:	'OCTET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 413
MIN	: 	'MIN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 415
MAX	:	'MAX';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 417
TRUE	:	'TRUE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 419
FALSE	:	'FALSE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 421
ABSENT	:	'ABSENT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 423
PRESENT	:	'PRESENT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 425
WITH 	:	'WITH';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 426
COMPONENT	: 'COMPONENT';		
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 427
COMPONENTS 	: 'COMPONENTS';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 428
DEFAULT 	: 'DEFAULT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 429
NULL		:'NULL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 430
PATTERN		:'PATTERN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 431
OBJECT 		:'OBJECT';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 432
IDENTIFIER	:'IDENTIFIER';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 433
RELATIVE_OID	:'RELATIVE-OID';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 434
NumericString	:'NumericString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 435
PrintableString	:'PrintableString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 436
VisibleString	:'VisibleString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 437
IA5String	:'IA5String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 438
TeletexString	:'TeletexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 439
VideotexString	:'VideotexString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 440
GraphicString	:'GraphicString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 441
GeneralString	:'GeneralString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 442
UniversalString	:'UniversalString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 443
BMPString	:'BMPString';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 444
UTF8String	:'UTF8String';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 445
INCLUDES	:'INCLUDES';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 446
EXCEPT		:'EXCEPT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 448
SET		:'SET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 450
BitStringLiteral	:
	'\'' ('0'|'1')* '\'B'
	;
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 453
OctectStringLiteral	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;


// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 458
StringLiteral 	: 	STR+ ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 460
fragment
STR 	:	'"' ( options {greedy=false;} : .)* '"' ;
			
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 463
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 466
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 469
INT	:	( '0' | ('1'..'9') ('0'..'9')*);

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 475
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 478
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 482
COMMENT2
    :   '--' ( options {greedy=false;} : . )* ('--'|'\r'?'\n') {$channel=HIDDEN;}
    ;



