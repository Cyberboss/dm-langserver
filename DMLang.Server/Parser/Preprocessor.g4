lexer grammar Preprocessor;

SPACE : ' ';
TAB : '\t';
NEWLINE : '\n';
ID : [a-zA-Z_][a-zA-Z0-9_\-]* ;
HASHTAG : '#';
LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';
COMMA: ',';
BSLASH: '\\';
DEFINE: 'define';
INCLUDE: 'include';
DQSTRING : '"' ('\\\\' | '\\"' | ~[\r\n"])* '"';
SQSTRING : '\'' ('\\\\' | '\\\'' | ~[\r\n\'])* '\'' ;

CARRIAGE_RETURN : [\r]+ -> skip ;
BLOCK_COMMENT : '/*' .*? '*/' -> skip;
EOL_COMMENT : '//' .*? '/n' -> skip;

ANYTHING: '.';