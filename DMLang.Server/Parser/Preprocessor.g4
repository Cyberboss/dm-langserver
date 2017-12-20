grammar Preprocessor;


CARRIAGE_RETURN : [\r]+ -> skip ;
BLOCK_COMMENT : '/*' .*? '*/' -> skip;
EOL_COMMENT : '//' .*? '\n' -> skip;

SPACE : ' ';
TAB : '\t';
NEWLINE : '\n';
ID : [a-zA-Z_][a-zA-Z0-9_\-]+ ;
HASHTAG : '#';
LPAREN: '(';
RPAREN: ')';
COMMA: ',';
BSLASH: '\\';
DEFINE: 'define';
INCLUDE: 'include';
IFDEF: 'ifdef';
ENDIF: 'endif';
IFNDEF: 'ifndef';
UNDEF: 'undef';
ELSE: 'else';
ELSEIF: 'elif';
IF: 'if';
ERROR: 'error';
WARNING: 'warning';

PLUS: '+';
MINUS: '-';
STAR: '*';
SLASH: '/';
XOR: '^';
AND: '&';
OR: '|';
EQUALS: '=';
NOT: '!';

DQSTRING : '"' ('\\\\' | '\\"' | ~[\r\n"])* '"';
SQSTRING : '\'' ('\\\\' | '\\\'' | ~[\r\n\'])* '\'' ;

WS : [ \t\r\n]+ -> skip ;

ANYTHING: '.';

language: declaration | declaration language;

declaration: doc_comment HASHTAG statement | HASHTAG statement;
statement: include_statement | define_statement | undef_statement | warning_statement | error_statement | if_statement;

doc_comment: BLOCK_COMMENT doc_comment | EOL_COMMENT doc_comment | BLOCK_COMMENT | EOL_COMMENT;

undef_statement: UNDEF ID;
warning_statement: WARNING text;
error_statement: ERROR text;

text: ANYTHING BSLASH NEWLINE text | ANYTHING text | ANYTHING NEWLINE;

if_statement: if_start if_continuation;
if_start: IF if_condition | IFDEF ID;

if_condition: non_recursive_if_condition | non_recursive_if_condition lhrh_op if_condition;
non_recursive_if_condition: ID | LPAREN if_condition RPAREN;

if_continuation: language if_closure | if_closure;

if_closure: HASHTAG ENDIF | HASHTAG ELSEIF if_condition if_continuation | HASHTAG ELSE language HASHTAG ENDIF | HASHTAG ELSE HASHTAG ENDIF ;

lhrh_op: equals | not_equals | and | or | pow | AND | OR | XOR | STAR | PLUS | MINUS | SLASH;

equals: EQUALS EQUALS;
not_equals: NOT EQUALS;
and: AND AND;
or: OR OR;
pow: STAR STAR;

include_statement: HASHTAG INCLUDE DQSTRING;

define_statement: HASHTAG DEFINE define;
define: ID | ID arguments | ID arguments macro | ID macro;

arguments: LPAREN RPAREN | LPAREN argument_list RPAREN;

argument_list: ID | ID COMMA argument_list;

macro: macro_line NEWLINE | macro_line BSLASH NEWLINE macro_line;

macro_line: macro_content BSLASH NEWLINE macro_line | macro_content macro_line | macro_content NEWLINE;
macro_content: explicit_replacement | stringified_replacement | ID | ANYTHING;

explicit_replacement: HASHTAG HASHTAG ID;
stringified_replacement: HASHTAG ID;
