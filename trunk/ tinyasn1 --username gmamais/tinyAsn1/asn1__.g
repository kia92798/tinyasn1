lexer grammar asn1;
options {
  language=CSharp;

}

T44 : '::=' ;
T45 : '{' ;
T46 : '}' ;
T47 : '(' ;
T48 : ')' ;
T49 : ';' ;
T50 : ',' ;
T51 : '[' ;
T52 : ']' ;
T53 : '+' ;
T54 : '-' ;
T55 : '<' ;
T56 : '..' ;
T57 : '.' ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 185
DEFINITIONS :	 'DEFINITIONS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 187
EXPLICIT:	 'EXPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 189
TAGS 	:	'TAGS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 191
IMPLICIT:	'IMPLICIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 193
AUTOMATIC	:	'AUTOMATIC';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 195
EXTENSIBILITY	:	'EXTENSIBILITY';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 197
IMPLIED :	'IMPLIED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 199
BEGIN	:	'BEGIN';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 200
END	:	'END';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 202
EXPORTS	:	'EXPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 204
ALL	: 	'ALL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 206
IMPORTS	:	'IMPORTS';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 208
FROM	:	'FROM';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 210
UNIVERSAL	: 'UNIVERSAL';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 211
APPLICATION	: 'APPLICATION';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 212
PRIVATE		:'PRIVATE';
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 213
BIT	: 'BIT';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 215
STRING	:	'STRING';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 217
BOOLEAN :	'BOOLEAN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 219
ENUMERATED	:'ENUMERATED';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 221
INTEGER	:	'INTEGER';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 223
REAL	:	'REAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 225
CHOICE	:	'CHOICE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 227
SEQUENCE	:	'SEQUENCE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 229
OPTIONAL	:	'OPTIONAL';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 231
SIZE	:	'SIZE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 233
OF	:	'OF';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 235
OCTET	:	'OCTET';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 237
MIN	: 'MIN';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 239
MAX	:	'MAX';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 241
TRUE	:	'TRUE';

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 243
FALSE	:	'FALSE';



// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 247
Bstring	:
	'\'' ('0'|'1')* '\'B'
	;
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 250
Hstring	:
	'\'' ('0'..'9'|'a'..'f'|'A'..'F')* '\'H'
	;

	
// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 255
UID  :   ('A'..'Z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 258
LID  :   ('a'..'z') ('a'..'z'|'A'..'Z'|'0'..'9'|'-')*
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 261
INT	:	( '0' | ('1'..'9') ('0'..'9')*);

//Real
//    :   ('+'|'-')?('0'..'9')+ '.' ('0'..'9')+
//	;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 267
WS  :   (' ' | '\t' | '\r' | '\n')+ {$channel=HIDDEN;}
    ;    

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 270
COMMENT
    :   '/*' ( options {greedy=false;} : . )* '*/' {$channel=HIDDEN;}
    ;

// $ANTLR src "C:\prj\DataModeling\tinyAsn1\tinyAsn1\asn1.g" 274
LINE_COMMENT
    : '--' ~('\n'|'\r')* '\r'? '\n' {$channel=HIDDEN;}
    ;

