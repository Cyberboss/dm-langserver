﻿//This for a preproccessed DM grammar
grammar DM;

tokens { INDENT, DEDENT }

@lexer::members {
	// A queue where extra tokens are pushed on (see the NEWLINE lexer rule).
	System.Collections.Generic.LinkedList<IToken> tokens = new System.Collections.Generic.LinkedList<IToken>();
	// The stack that keeps track of the indentation level.
	System.Collections.Generic.Stack<int> indents = new System.Collections.Generic.Stack<int>();
	// The amount of opened braces, brackets and parenthesis.
	int opened;
	// The most recently produced token.
	IToken lastToken;
	public override void Emit(IToken t)
	{
		Token = t;
		tokens.AddLast(t);
	}

	IToken TokensElementAt(int n)
	{
		var current = tokens.First;
		for (var I = 0; I < n; ++I)
			current = current.Next;
		return current.Value;
	}

	public override IToken NextToken()
	{
		// Check if the end-of-file is ahead and there are still some DEDENTS expected.
		if (_input.La(1) == Eof && indents.Count > 0)
		{
			// Remove any trailing EOF tokens from our buffer.
			for (int i = tokens.Count - 1; i >= 0; i--)
			{
				var tok = TokensElementAt(i);

				if (tok.Type == Eof)
				{
					tokens.Remove(tok);
				}
			}

			// First emit an extra line break that serves as the end of the statement.
			Emit(commonToken(DMParser.NEWLINE, "\n"));

			// Now emit as much DEDENT tokens as needed.
			while (indents.Count > 0)
			{
				Emit(createDedent());
				indents.Pop();
			}

			// Put the EOF back on the token stream.
			Emit(commonToken(DMParser.Eof, "<EOF>"));
		}

		var next = NextToken();

		if (next.Channel == TokenConstants.DefaultChannel)
		{
			// Keep track of the last token on the default channel.
			this.lastToken = next;
		}

		var res = tokens.Count == 0 ? next : tokens.First.Value;
		if (tokens.Count > 0)
			tokens.RemoveFirst();
		return res;
	}

	IToken createDedent()
	{
		CommonToken dedent = commonToken(DMParser.DEDENT, "");
		dedent.Line = lastToken.Line;
		return dedent;
	}

	CommonToken commonToken(int type, string text)
	{
		int stop = CharIndex - 1;
		int start = text == string.Empty ? stop : stop - text.Length + 1;
		return new CommonToken(this._tokenFactorySourcePair, type, DefaultTokenChannel, start, stop);
	}

	// Calculates the indentation of the provided spaces, taking the
	// following rules into account:
	//
	// "Tabs are replaced (from left to right) by one to eight spaces
	//  such that the total number of characters up to and including
	//  the replacement is a multiple of eight [...]"
	//
	//  -- https://docs.python.org/3.1/reference/lexical_analysis.html#indentation
	static int getIndentationCount(string spaces)
	{
		int count = 0;
		foreach (var ch in spaces.ToCharArray())
		{
			switch (ch)
			{
				case '\t':
					count += 8 - (count % 8);
					break;
				default:
					// A normal space char.
					count++;
					break;
			}
		}

		return count;
	}

	bool atStartOfInput()
	{
		return Column == 0 && Line == 1;
	}
}

NEWLINE
 : ( {atStartOfInput()}?   SPACES
   | ( '\r'? '\n' | '\r' | '\f' ) SPACES?
   )
{
	string newLine = new System.Text.RegularExpressions.Regex("[^\r\n\f]+").Replace(Text, "");
	string spaces = new System.Text.RegularExpressions.Regex("[\r\n\f]+").Replace(Text, "");
	int next = _input.La(1);
	if (opened > 0 || next == '\r' || next == '\n' || next == '\f' || next == '#')
	{
		// If we're inside a list or on a blank line, ignore all indents, 
		// dedents and line breaks.
		Skip();
	}
	else
	{
		Emit(commonToken(NEWLINE, newLine));
		int indent = getIndentationCount(spaces);
		int previous = indents.Count == 0 ? 0 : indents.Peek();
		if (indent == previous)
		{
			// skip indents of the same size as the present indent-size
			Skip();
		}
		else if (indent > previous)
		{
			indents.Push(indent);
			Emit(commonToken(DMParser.INDENT, spaces));
		}
		else
		{
			// Possibly emit more than 1 DEDENT token.
			while (indents.Count > 0 && indents.Peek() > indent)
			{
				Emit(createDedent());
				indents.Pop();
			}
		}
	}
}
;

SDOT: '......';
FDOT: '.....';
DDOT: '..';
DOT: '.';
NUMBER: [0-9]+;
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
CONST: 'const';
OBJ: 'obj';
MOB: 'mob';
GOTO: 'goto';
TURF: 'turf';
AREA: 'area';
IN: 'in';
NEW: 'new';
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
THROW: 'throw';
AND: '&';
OR: '|';
LTHAN: '<';
VERB: 'verb';
GTHAN: '>';
LCURL: '{';
RCURL: '}';
SEMI: ';';
LIST: 'list';
COMMA: ',';
COLON: ':';
XOR: '^';
ELSE: 'else';
SPAWN: 'spawn';
WORLD: 'world';
STEP: 'step';
TO: 'to';
CATCH: 'catch';
QUESTION: '?';
ID : [a-zA-Z_][a-zA-Z0-9_\-]+ ;

ESCAPED_NEWLINE: '\\' [ \t\r]+ '\n' -> skip;

fragment SPACES
 : [ \t]+
;

fragment LINE_JOINING
 : '\\' SPACES? ( '\r'? '\n' | '\r' | '\f')
;

SKIP_
 : ( SPACES | LINE_JOINING ) -> skip
;

ANYCHAR: .;

language : definition | definition language ;
definition : definition_type | definition_type;

definition_type: root_var_def | datum_def | proc_def;

optional_slash : SLASH | ;

string_text: BSLASH LBRACE string_text | embedded_expression string_text | . string_text | ~BSLASH DQUOTE;

root_var_def: optional_slash var_def;
var_def : VAR id_typepath_decl list_access | VAR id_typepath_decl | VAR optional_slash LCURL id_typepath_decl_block RCURL ;
id_typepath_decl_block : id_typepath_decl id_typepath_decl_block| id_typepath_decl;
id_typepath_decl : id_typepath | static_or_global SLASH id_typepath | var_qualifier optional_slash LCURL id_typepath_block RCURL;
var_qualifier: static_or_global | CONST;
static_or_global : STATIC | GLOBAL;
id_typepath_block:  id_typepath id_typepath_block | id_typepath;
id_typepath: root_type_no_list SLASH custom_id_typepath | root_type_no_list optional_slash LCURL custom_id_typepath_block RCURL; 
custom_id_typepath_block: custom_id_typepath custom_id_typepath_block | custom_id_typepath;
custom_id_typepath: id_and_assignment end_of_line | ID SLASH custom_id_typepath | ID optional_slash LCURL custom_id_typepath_block RCURL;
id_and_assignment: assignment | id_specifier;

end_of_line: NEWLINE | SEMI;

full_typepath: SLASH typepath;
typepath: root_type SLASH id_typepath_oneline;
id_typepath_oneline: ID SLASH id_typepath_oneline | ID;

datum_def : optional_slash root_type datum_inner_def;
datum_inner_def: proc_def | SLASH ID datum_inner_def | optional_slash LCURL datum_def_block RCURL;
datum_def_block: datum_def_contents | datum_def_contents datum_def_block;
datum_def_contents: var_def | proc_def | custom_id_typepath_block;

// TODO VERBS AND PROC OVERRIDES

proc_def: PROC SLASH proc_id_def | PROC optional_slash LCURL proc_id_def_block RCURL;
proc_id_def_block: proc_id_def proc_id_def_block | proc_id_def;
proc_id_def: ID LPAREN RPAREN block | ID LPAREN arguments_def RPAREN block;
arguments_def: argument_def COMMA arguments_def | argument_def;
argument_def: argument_decl EQUALS expression | argument_decl;
argument_decl: VAR full_typepath | typepath | ID;

block: LCURL statements RCURL | LCURL RCURL | statement;
statements: statement statements | statement;
statement: statement_content end_of_line;
statement_content: control_flow | var_def | assignment_statement | proccall_statement | return_statement | throw_statement | label_statement | goto_statement | inline_adjust;
proccall_statement: proccall;
assignment_statement: id_specifier assignment_op expression;

label_statement: ID COLON;
goto_statement: GOTO ID;

inline_adjust: left_inline_adjust | right_inline_adjust;
left_inline_adjust: id_specifier inline_adjuster;
right_inline_adjust: inline_adjuster id_specifier;
inline_adjuster: PLUS PLUS | MINUS MINUS;

throw_statement: THROW expression;
return_statement: RETURN expression | RETURN;

control_flow: if_statement | switch_statement | while_statement | for_statement | spawn_statement | new_statement;

new_statement: NEW full_typepath proc_arguments | NEW full_typepath | NEW proc_arguments | NEW ID | NEW;

spawn_statement: spawn_invocation block;
spawn_invocation: SPAWN LPAREN RPAREN | SPAWN LPAREN expression RPAREN;

if_statement: if_check root_if_continuation;
root_if_continuation: block if_continuation | block;
if_check: IF LPAREN expression RPAREN;
if_continuation: ELSE block | ELSE if_check block if_continuation | root_if_continuation;

switch_statement: SWITCH LPAREN expression RPAREN root_switch_block;
const_if_check: IF LPAREN constexpr RPAREN;
root_switch_block: const_if_check block switch_block | const_if_check block;
switch_block: ELSE block | root_switch_block;

while_statement: WHILE LPAREN expression RPAREN block;

for_statement: FOR LPAREN for_expression RPAREN block;
for_expression: for_in | for_standard;
for_in: argument_def IN expression;
for_standard: for_optional_argument_def SEMI optional_expression SEMI optional_expression;
for_optional_argument_def: argument_def | ;
optional_expression: expression | ;

proccall: DDOT proc_arguments | id_specifier datum_access proc_invocation | proc_invocation ;
proc_invocation: ID proc_arguments;
proc_arguments: LPAREN arguments RPAREN | ID LPAREN RPAREN;
unquotable_associated_argument: ID EQUALS expression | expression;
arguments: unquotable_associated_argument | unquotable_associated_argument COMMA arguments;

associated_argument: string_entry EQUALS expression | unquotable_associated_argument;
associated_arguments: associated_argument | associated_argument COMMA associated_arguments;
list_declaration : LIST LPAREN associated_arguments RPAREN;

id_specifier: DOT | inner_id_specifier;
inner_id_specifier: ID datum_access inner_id_specifier | root_type | ID | WORLD | GLOBAL;
datum_access: DOT | COLON;

expression : wrapped_expression | NOT wrapped_expression;
wrapped_expression : inner_expression | LPAREN expression RPAREN;
inner_expression: operation | value_range | ternery | list_access | inline_adjust | non_recursive_inner_expression;

non_recursive_expression: non_recursive_wrapped_expression | NOT non_recursive_wrapped_expression;
non_recursive_wrapped_expression : non_recursive_inner_expression | LPAREN expression RPAREN;
non_recursive_inner_expression: assignment | list_declaration | value | new_statement | inline_adjust;

list_access: non_recursive_expression LBRACE expression RBRACE;
operation: non_recursive_expression lhrh_op expression | value lhrh_op expression;
value_range: non_recursive_expression TO expression STEP expression | non_recursive_expression TO expression;
ternery: non_recursive_expression QUESTION expression COLON expression;

lhrh_op: equals | not_equals | and | or | pow | AND | OR | XOR | STAR | PLUS | MINUS | SLASH | EQUALS;

value: constexpr | proccall | proctype;
constexpr: number | string_entry;
proctype: SDOT | FDOT;

assignment: id_specifier EQUALS expression;
assignment_op: or_equals | and_equals | xor_equals | mult_equals | minus_equals | plus_equals | slash_equals | EQUALS;

embedded_expression : LBRACE expression RBRACE;
inner_string: string_text | string_text embedded_expression inner_string;
inner_string_entry: DQUOTE inner_string | DQUOTE DQUOTE;
string_entry: LCURL inner_string_entry RCURL | inner_string_entry ;

file_ref: SQUOTE inner_file_ref;
inner_file_ref: ~BSLASH SQUOTE | . inner_file_ref;
number: NUMBER DOT NUMBER | NUMBER;

equals: EQUALS EQUALS;
not_equals: NOT EQUALS;
and: AND AND;
or: OR OR;
pow: STAR STAR;

or_equals: OR EQUALS;
and_equals: AND EQUALS;
xor_equals: XOR EQUALS;
mult_equals: STAR EQUALS;
minus_equals: MINUS EQUALS;
plus_equals: PLUS EQUALS;
slash_equals: SLASH EQUALS;

root_type: root_type_no_list | LIST;
root_type_no_list: DATUM | ATOM | OBJ | MOB | TURF | AREA | WORLD;
