grammar Speak;

program: line* EOF;

line: statement | ifBlock | whileBlock;

statement: (assignment|functionCall) ';';

ifBlock: 'if' expression block ('else' elseIfBlock)?;

elseIfBlock: block | ifBlock;

whileBlock: WHILE expression block;
 
WHILE: 'while';

assignment: IDENTIFIER '=' expression;

functionCall: IDENTIFIER '(' (expression (',' expression)*)? ')';

expression
    : constant                          #constantExpression
    | IDENTIFIER                        #identifierExpression    
    | functionCall                      #functionCallExpression
    | '(' expression ')'                #parenthesizedExpression
    | '!' expression                    #notExpression
    | expression multOp expression      #multiplicativeExpression
    | expression addOp expression       #additiveExpression
    | expression compareOp expression   #comparisonExpression
    | expression boolOp expression      #booleanExpression
    ;



multOp: '*' | '/' | '%';
addOp: '+' | '-';
compareOp: COMPARE_OPERATION;
boolOp: BOOL_OPERATION;

BOOL_OPERATION: 'and' | 'or' | 'xor';
COMPARE_OPERATION: '==' | '!=' | '>' | '<' | '>=' | '<='; 

constant: INTEGER | FLOAT | STRING | BOOL | NULL;

INTEGER: [0-9]+;
STRING: ('"' ~'"'*'"' )| ('\''~'\''*'\'');
FLOAT: [0-9]+ '.' [0-9]+;
BOOL: 'true' | 'false';
NULL: 'null';

block: '{' line* '}';

WS: [\t\r\n]+ -> skip;
IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;
