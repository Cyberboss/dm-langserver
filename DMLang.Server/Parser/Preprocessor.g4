lexer grammar Preprocessor;

CARRIAGE_RETURN : [\r]+ -> skip ;
BLOCK_COMMENT : '/*' .*? '*/' -> skip;
EOL_COMMENT : '//' .*? '/n' -> skip;

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
ANYTHING: '.';
DEFINE: 'define';
INCLUDE: 'include';
DQSTRING : ~('\r' | '\n' | '"')+ ;
SQSTRING : ~('\r' | '\n' | '\'')+ ;
