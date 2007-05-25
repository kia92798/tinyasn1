lexer grammar asn1;
options {
  language=CSharp;

}

T14 : 'DEFINITIONS' ;
T15 : 'EXPLICIT' ;
T16 : 'TAGS' ;
T17 : 'IMPLICIT' ;
T18 : 'AUTOMATIC' ;
T19 : 'EXTENSIBILITY' ;
T20 : 'IMPLIED' ;
T21 : '::=' ;
T22 : 'BEGIN' ;
T23 : 'END' ;
T24 : '[' ;
T25 : 'UNIVERSAL' ;
T26 : 'APPLICATION' ;
T27 : 'PRIVATE' ;
T28 : ']' ;
T29 : 'BIT' ;
T30 : 'STRING' ;
T31 : '{' ;
T32 : '(' ;
T33 : ')' ;
T34 : ',' ;
T35 : '}' ;
T36 : 'BOOLEAN' ;
T37 : 'ENUMERATED' ;
T38 : 'INTEGER' ;
T39 : 'REAL' ;
T40 : 'CHOICE' ;
T41 : 'SEQUENCE' ;
T42 : 'OPTIONAL' ;
T43 : 'SIZE' ;
T44 : 'OF' ;
T45 : 'OCTET' ;
T46 : '+' ;
T47 : '-' ;
T48 : '..' ;
T49 : 'ALL' ;
T50 : 'EXCEPT' ;
T51 : '<' ;
T52 : '.' ;
T53 : 'MIN' ;
T54 : 'MAX' ;
T55 : 'TRUE' ;
T56 : 'FALSE' ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 132
Bstring	:
	'\'' ('0'|'1')* '\'B'
	;
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 135
Hstring	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;


// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 140
UnionMark  :  '|'	
|	'UNION'
	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 144
IntersectionMark  :	'^'	|	'INTERSECTION';
	
	
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 147
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 150
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 153
INT	:	( '0' | ('1'..'9') ('0'..'9')*);

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 159
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 162
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 166
LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;
