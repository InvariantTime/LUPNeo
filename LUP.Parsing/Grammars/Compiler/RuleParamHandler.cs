using LUP.Parsing.AST;
using LUP.Parsing.Grammars.AST;

namespace LUP.Parsing.Grammars.Compiler
{
    class RuleParamHandler
    {
        [GrammarCall("createEqual")]
        public IGrammarParamExpr CreateEqual(IGrammarParamExpr right)
        {
            return new GrammarEqualExpr(right);
        }


        [GrammarCall("emptyExpr")]
        public IGrammarParamExpr CreateEmpty()
        {
            return GrammarEmptyExpr.Instance;
        }


        [GrammarCall("createCall")]
        public IGrammarParamExpr CreateCall(string name, ListExpression<IGrammarParamExpr> args)
        {
            return new GrammarCallExpr(name, args);
        }


        [GrammarCall("createCall")]
        public IGrammarParamExpr CreateCall(string name, string generic, ListExpression<IGrammarParamExpr> args)
        {
            return new GrammarCallExpr(name, args, generic);
        }


        [GrammarCall("createNumber")]
        public IGrammarParamExpr CreateInt(int number)
        {
            return new GrammarIntExpr(number);
        }


        [GrammarCall("createIndex")]
        public IGrammarParamExpr CreateIndex(int index)
        {
            return new GrammarIntExpr(index, true);
        }


        [GrammarCall("createString")]
        public IGrammarParamExpr CreateString(string str)
        {
            return new GrammarStringExpr(str);
        }
    }
}
