using LUP.Parsing.AST;
using LUP.Parsing.AST.Expressions;
using LUP.Parsing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUP.Parsing.Grammars
{
    class SomeGrammar
    {
        private static readonly IReduceExpression p1 = Lambda(() =>
        {
            var index = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createGrammar", index);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p2 = Lambda(() =>
        {
            var index = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createList", "rule", index);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p3 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(2);
            var right = ReduceExpression.Call("addToList", "rule", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p4 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(3);
            var right = ReduceExpression.Call("createRule", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p5 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(2);
            var index2 = ReduceExpression.Index(4);
            var right = ReduceExpression.Call("createStartRule", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p6 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createList", "ruleSegment", index1);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p7 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(3);
            var right = ReduceExpression.Call("addToList", "ruleSegment", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p8 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createRuleExpr", index1);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p9 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(2);
            var right = ReduceExpression.Call("createRuleExpr", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p10 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createRuleExpr", index1);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p11 = Lambda(() =>
        {
            var right = ReduceExpression.Call("createRuleExpr");

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p12 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createList", "string", index1);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p13 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(2);
            var right = ReduceExpression.Call("addToList", "string", index1, index2);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression equal = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            return ReduceExpression.Equal(index1);
        });

        private static readonly IReduceExpression p16 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(3);
            var right = ReduceExpression.Call("createEqual", index1);

            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p17 = Lambda(() =>
        {
            var right = ReduceExpression.Call("emptyExpr");
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p18 = Lambda(() =>
        {
            var index = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createString", index);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p19 = Lambda(() =>
        {
            var index = ReduceExpression.Index(1);
            var toInt = ReduceExpression.Call("toInt", index);
            var right = ReduceExpression.Call("createNumber", toInt);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p20 = Lambda(() =>
        {
            var index = ReduceExpression.Index(2);
            var toInt = ReduceExpression.Call("toInt", index);
            var right = ReduceExpression.Call("createIndex", toInt);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p21 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(3);
            var right = ReduceExpression.Call("createCall", index1, index2);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p22 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(3);
            var index3 = ReduceExpression.Index(6);
            var right = ReduceExpression.Call("createCall", index1, index2, index3);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p23 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var right = ReduceExpression.Call("createList", "param", index1);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p24 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(1);
            var index2 = ReduceExpression.Index(3);
            var right = ReduceExpression.Call("addToList", "param", index1, index2);
            return ReduceExpression.Equal(right);
        });

        private static readonly IReduceExpression p25 = Lambda(() =>
        {
            var index1 = ReduceExpression.Index(2);
            return ReduceExpression.Equal(index1);
        });

        private static readonly IReduceExpression p26 = Lambda(() =>
        {
            return ReduceExpression.Equal(StringReduceValue.Empty);
        });

        private static readonly IReduceExpression p27 = Lambda(() =>
        {
            var call = ReduceExpression.Call("createList", "param");
            return ReduceExpression.Equal(call);
        });


        private static readonly GrammarRule[] rules =
        {
            new GrammarRule("GRAMMAR", p1, "RULES"),

            new GrammarRule("RULES", p2, "RULE"),
            new GrammarRule("RULES", p3, "RULES", "RULE"),

            new GrammarRule("RULE", p4, "ID", "COLON", "BODY", "SEMN"),
            new GrammarRule("RULE", p5, "START", "ID", "COLON", "BODY", "SEMN"),

            new GrammarRule("BODY", p6, "RULE_EXPR"),
            new GrammarRule("BODY", p7, "BODY", "AND", "RULE_EXPR"),

            new GrammarRule("RULE_EXPR", p8, "TOKENS"),
            new GrammarRule("RULE_EXPR", p9, "TOKENS", "PARAM"),
            new GrammarRule("RULE_EXPR", p10, "PARAM"),
            new GrammarRule("RULE_EXPR", p11),

            new GrammarRule("TOKENS", p12, "ID"),
            new GrammarRule("TOKENS", p13, "TOKENS", "ID"),

            new GrammarRule("PARAM", p25, "LBLOCK", "STATEMENT", "RBLOCK"),

            new GrammarRule("STATEMENT", equal, "EXPR"),
            new GrammarRule("STATEMENT", p16, "INDEX", "EQUAL", "VALUE_EXPR"),
            new GrammarRule("STATEMENT", p17),

            new GrammarRule("EXPR", equal, "MACROS_CALL"),

            new GrammarRule("VALUE_EXPR", equal, "EXPR"),
            new GrammarRule("VALUE_EXPR", p18, "STRING"),
            new GrammarRule("VALUE_EXPR", p19, "NUMBER"),
            new GrammarRule("VALUE_EXPR", p20, "INDEX", "NUMBER"),

            new GrammarRule("MACROS_CALL", p21, "ID", "LPAR", "ARGS", "RPAR"),
            new GrammarRule("MACROS_CALL", p22, "ID", "LGENER", "ID", "RGENER", "LPAR", "ARGS", "RPAR"),

            new GrammarRule("ARGS", p23, "VALUE_EXPR"),
            new GrammarRule("ARGS", p24, "ARGS", "COMMA", "VALUE_EXPR"),
            new GrammarRule("ARGS", p27),

            new GrammarRule("STRING", p25, "QUOTE", "STRING", "QUOTE"),
            new GrammarRule("STRING", p25, "QUOTE", "ID", "QUOTE"),
            new GrammarRule("STRING", p26, "QUOTE", "QUOTE"),
        };

        public static Grammar Grammar;

        static SomeGrammar()
        {
            HashSet<string> tokens = new();

            foreach (var rule in rules)
            {
                tokens.Add(rule.Result);

                foreach (var t in rule.Tokens)
                    tokens.Add(t);
            }

            Grammar = new Grammar(rules, tokens, "GRAMMAR");

            var generator = new StackMachineTableGenerator(Grammar);
            var table = generator.Generate();
            StackTableReader.Write(table, File.OpenWrite("grammarTable.tbl"));
        }


        private static IReduceExpression Lambda(Func<IReduceExpression> lambda)
        {
            return lambda.Invoke();
        }
    }
}
