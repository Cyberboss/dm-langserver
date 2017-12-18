grammar DM;

tokens : { ID, PROC, IF, SWITCH, FOR, WHILE, VAR, DATUM, ATOM, OBJ, MOB, TURF, AREA, STATIC, GLOBAL, RETURN, SLASH, NEWLINE, INDENT, DEDENT, TAB, EQUALS, STAR, PLUS, MINUS, IN, SEMI, SQUOTE, DQUOTE, NULL, NUMBER, DOT, LPAREN, RPAREN, LCURL, RCURL, TRUE, FALSE, LBRACE, RBRACE, BSLASH, NOT, LTHAN, GTHAN, AND, OR, WS, LIST, COMMA }

@lexer::members {
  // A queue where extra tokens are pushed on (see the NEWLINE lexer rule).
  private java.util.LinkedList<Token> tokens = new java.util.LinkedList<>();
  // The stack that keeps track of the indentation level.
  private java.util.Stack<Integer> indents = new java.util.Stack<>();
  // The amount of opened braces, brackets and parenthesis.
  private int opened = 0;
  // The most recently produced token.
  private Token lastToken = null;
  @Override
  public void emit(Token t) {
    super.setToken(t);
    tokens.offer(t);
  }

  @Override
  public Token nextToken() {
    // Check if the end-of-file is ahead and there are still some DEDENTS expected.
    if (_input.LA(1) == EOF && !this.indents.isEmpty()) {
      // Remove any trailing EOF tokens from our buffer.
      for (int i = tokens.size() - 1; i >= 0; i--) {
        if (tokens.get(i).getType() == EOF) {
          tokens.remove(i);
        }
      }

      // First emit an extra line break that serves as the end of the statement.
      this.emit(commonToken(Python3Parser.NEWLINE, "\n"));

      // Now emit as much DEDENT tokens as needed.
      while (!indents.isEmpty()) {
        this.emit(createDedent());
        indents.pop();
      }

      // Put the EOF back on the token stream.
      this.emit(commonToken(Python3Parser.EOF, "<EOF>"));
    }

    Token next = super.nextToken();

    if (next.getChannel() == Token.DEFAULT_CHANNEL) {
      // Keep track of the last token on the default channel.
      this.lastToken = next;
    }

    return tokens.isEmpty() ? next : tokens.poll();
  }

  private Token createDedent() {
    CommonToken dedent = commonToken(Python3Parser.DEDENT, "");
    dedent.setLine(this.lastToken.getLine());
    return dedent;
  }

  private CommonToken commonToken(int type, String text) {
    int stop = this.getCharIndex() - 1;
    int start = text.isEmpty() ? stop : stop - text.length() + 1;
    return new CommonToken(this._tokenFactorySourcePair, type, DEFAULT_TOKEN_CHANNEL, start, stop);
  }

  // Calculates the indentation of the provided spaces, taking the
  // following rules into account:
  //
  // "Tabs are replaced (from left to right) by one to eight spaces
  //  such that the total number of characters up to and including
  //  the replacement is a multiple of eight [...]"
  //
  //  -- https://docs.python.org/3.1/reference/lexical_analysis.html#indentation
  static int getIndentationCount(String spaces) {
    int count = 0;
    for (char ch : spaces.toCharArray()) {
      switch (ch) {
        case '\t':
          count += 8 - (count % 8);
          break;
        default:
          // A normal space char.
          count++;
      }
    }

    return count;
  }

  boolean atStartOfInput() {
    return super.getCharPositionInLine() == 0 && super.getLine() == 1;
  }
}


NEWLINE
 : ( {atStartOfInput()}?   SPACES
   | ( '\r'? '\n' | '\r' ) SPACES?
   )
   {
     String newLine = getText().replaceAll("[^\r\n]+", "");
     String spaces = getText().replaceAll("[\r\n]+", "");
     int next = _input.LA(1);
     if (opened > 0 || next == '\r' || next == '\n' || next == '#') {
       // If we're inside a list or on a blank line, ignore all indents, 
       // dedents and line breaks.
       skip();
     }
     else {
       emit(commonToken(NEWLINE, newLine));
       int indent = getIndentationCount(spaces);
       int previous = indents.isEmpty() ? 0 : indents.peek();
       if (indent == previous) {
         // skip indents of the same size as the present indent-size
         skip();
       }
       else if (indent > previous) {
         indents.push(indent);
         emit(commonToken(Python3Parser.INDENT, spaces));
       }
       else {
         // Possibly emit more than 1 DEDENT token.
         while(!indents.isEmpty() && indents.peek() > indent) {
           this.emit(createDedent());
           indents.pop();
         }
       }
     }
   }
 ;
 
DOT: '.'
ID : [a-zA-Z_][a-zA-Z0-9_\-]* ;             // match lower-case identifiers
WS : [ \t\r\n]+ -> skip ;
NUMBER: [0-9]+
TRUE: 'TRUE';
FALSE: 'FALSE';
DQUOTE: '"';
SQUOTE: '\'';
LBRACE: '[';
RBRACE: ']';
SLASH: '/';
BSLASH: '\\';
NOT: '!';
DATUM: 'datum';
ATOM: 'atom';
PROC: 'proc';
NULL: 'null';
RETURN: 'return';
STATIC: 'static';
GLOBAL: 'global';
OBJ: 'obj';
MOB: 'mob';
TURF: 'turf';
AREA: 'area';
IN: 'in';
LPAREN: '(';
RPAREN: ')';
MINUS: '-';
PLUS: '+';
STAR: '*';
EQUALS: '=';
TAB: '\t';
VAR: 'var';
SWITCH: 'switch';
IF: 'if';
FOR: 'for';
WHILE: 'while';
AND: '&';
OR: '|';
LTHAN: '<';
GTHAN: '>';
LCURL: '{';
RCURL: '}';
SEMI: ';';
LIST: 'list';
COMMA: ',';

unquotable_associated_argument: ID EQUALS expression | expression;

associated_argument: string EQUALS expression | unquotable_associated_argument;

associated_arguments: associated_argument | associated_argument COMMA associated_arguments;

list_declaration : LIST LPAREN associated_arguments RPAREN

embedded_expression : LBRACE expression RBRACE;

inner_string: gibberish_text | gibberish_text embedded_expression inner_string;

string: DQUOTE inner_string unescaped_dquote | DQUOTE DQUOTE;

file_ref: SQUOTE ... SQUOTE;

number: NUMBER DOT NUMBER | NUMBER | TRUE | FALSE;

language : definition | definition language ;

definition : comment | var_def | datum_def | proc_def;

comment : SLASH SLASH ... NEWLINE | SLASH STAR ... STAR SLASH; 

var_def : VAR id_typepath_decl | VAR INDENT id_typepath_decl_block DEDENT;

id_typepath_decl_block : id_typepath_decl | id_typepath_decl NEWLINE id_typepath_decl_block;

id_typepath_decl : id_typepath | static_or_global SLASH id_typepath | static_or_global INDENT id_typepath_block DEDENT;

static_or_global : STATIC | GLOBAL;

id_typepath_block:  id_typepath | id_typepath NEWLINE id_typepath_block;

id_typepath: root_type SLASH custom_id_typepath | root_type INDENT custom_id_typepath_block DEDENT; 

custom_id_typepath_block: custom_id_typepath | custom_id_typepath NEWLINE custom_id_typepath_block;

custom_id_typepath: id_and_assignment | ID SLASH custom_id_typepath | ID custom_id_typepath_block;

id_and_assignment: ID | ID EQUALS expression;

expression : wrapped_expression | NOT wrapped_expression;

wrapped_expression : inner_expression | LPAREN inner_expression RPAREN;

value: number | string | proccall;

proccall: proc_invocation | ID DOT proccall;

proc_invocation: ID LPAREN arguments RPAREN

inner_expression: value | comparison | expression;

comparison: expression compare_op expression | value compare_op expression;

compare_op: EQUALS EQUALS | NOT EQUALS | AND AND | AND | OR OR | OR ;

root_type: DATUM | ATOM | OBJ | MOB | TURF | AREA;