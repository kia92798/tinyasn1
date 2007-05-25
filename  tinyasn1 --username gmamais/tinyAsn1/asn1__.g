lexer grammar asn1;
options {
  language=CSharp;

}

T12 : 'DEFINITIONS' ;
T13 : 'EXPLICIT' ;
T14 : 'TAGS' ;
T15 : 'IMPLICIT' ;
T16 : 'AUTOMATIC' ;
T17 : 'EXTENSIBILITY' ;
T18 : 'IMPLIED' ;
T19 : '::=' ;
T20 : 'BEGIN' ;
T21 : 'END' ;
T22 : 'EXPORTS' ;
T23 : 'ALL' ;
T24 : ';' ;
T25 : ',' ;
T26 : 'IMPORTS' ;
T27 : 'FROM' ;
T28 : '[' ;
T29 : 'UNIVERSAL' ;
T30 : 'APPLICATION' ;
T31 : 'PRIVATE' ;
T32 : ']' ;
T33 : 'BIT' ;
T34 : 'STRING' ;
T35 : '{' ;
T36 : '(' ;
T37 : ')' ;
T38 : '}' ;
T39 : 'BOOLEAN' ;
T40 : 'ENUMERATED' ;
T41 : 'INTEGER' ;
T42 : 'REAL' ;
T43 : 'CHOICE' ;
T44 : 'SEQUENCE' ;
T45 : 'OPTIONAL' ;
T46 : 'SIZE' ;
T47 : 'OF' ;
T48 : 'OCTET' ;
T49 : '+' ;
T50 : '-' ;
T51 : '<' ;
T52 : '..' ;
T53 : '.' ;
T54 : 'MIN' ;
T55 : 'MAX' ;
T56 : 'TRUE' ;
T57 : 'FALSE' ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 155
Bstring	:
	'\'' ('0'|'1')* '\'B'
	;
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 158
Hstring	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;
/*

UnionMark  :  '|'	
|	'UNION'
	;

IntersectionMark  :	'^'	|	'INTERSECTION';
*/	
	
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 170
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 173
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 176
INT	:	( '0' | ('1'..'9') ('0'..'9')*);

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 182
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 185
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 189
LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;
