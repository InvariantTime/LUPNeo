using LUP.Parsing.AST;
using LUP.Parsing.Grammars.AST;

namespace LUP.Parsing.Grammars.Compiler
{
    class GrammarASTHandler : ASTHandler<GrammarAST>
    {
        private static readonly KeyValuePair<string, Type>[] types =
        {
            new("rule", typeof(GrammarRuleExpr)),
            new("ruleSegment", typeof(GrammarRuleSegmentExpr)),
            new("param", typeof(IGrammarParamExpr))
        };

        protected override void RegistHandlers(ReduceRegister register)
        {
            register.AddHandler(new RuleHandler());
            register.AddHandler(new RuleParamHandler());

            register.AddTypeMapRange(types);
        }


        public override void OnError(string message)
        {
            throw new Exception(message);
        }
    }
}
