using LUP.Parsing;
using LUP.Parsing.AST.Expressions;
using LUP.Parsing.Grammars;
using System.Text;

namespace LUP.Parsing.Parsers
{
    class StackMachine
    {
        private readonly StackMachineTable table;
        private readonly Stack<StackValue> stack;

        private int tokenIndex;

        public StackMachine(StackMachineTable table)
        {
            this.table = table;
            stack = new();

            stack.Push(new(0));
        }

        //TODO: syntax exceptions
        public TokenHandleResult Handle(Token token)
        {
            try
            {
                var value = stack.Peek();

                if (value.Type == StackValueTypes.Token)
                    throw new Exception("unexpected token on stack");

                int state = value.State;
                var action = table.GetAction(state, token.Type);
                switch (action.Type)
                {
                    case MachineActionTypes.Accept:
                        return TokenHandleResult.Success;

                    case MachineActionTypes.Shift:
                        stack.Push(new(new KeyToken(token, tokenIndex, true)));
                        tokenIndex++;

                        stack.Push(new(action.State));
                        return TokenHandleResult.Shift;

                    case MachineActionTypes.Reduce:
                        if (action.Rule == null)
                            throw new InvalidOperationException("Rule cannot be null");

                        KeyToken[] reducedTokens = new KeyToken[action.Rule.Tokens.Length];

                        for (int i = 0; i < reducedTokens.Length; i++)
                        {
                            stack.Pop();
                            var t = stack.Pop();

                            if (t.Type == StackValueTypes.State)
                                throw new InvalidOperationException("unexpected state value on stack");

                            reducedTokens[reducedTokens.Length - i - 1] = t.Token;
                        }

                        state = table.GetGoto(stack.Peek().State, action.Rule.Result);

                        if (state == -1)
                            throw new Exception();

                        var resultToken = new KeyToken(new()
                        {
                            Type = action.Rule.Result
                        }, tokenIndex);
                        tokenIndex++;

                        stack.Push(new(resultToken));
                        tokenIndex++;

                        stack.Push(new(state));
                        return new(resultToken, action.Rule.Expression, reducedTokens);

                    case MachineActionTypes.Error:
                        throw new Exception($"invalid token encountered: {token.Value}");

                    default: throw new Exception("Invalid action");
                }
            }
            catch (Exception e)
            {
                return new(e.Message);
            }
        }
    }

    struct TokenHandleResult
    {
        public static TokenHandleResult Shift = new(HandleCodes.Shift);

        public static TokenHandleResult Success = new(HandleCodes.Success);

        public string Error { get; }

        public HandleCodes Code { get; }

        public KeyToken Result { get; }

        public KeyToken[]? Reduced { get; }

        public IReduceExpression? Param { get; }

        public TokenHandleResult(HandleCodes code)
        {
            Code = code;
            Error = string.Empty;
        }


        public TokenHandleResult(string error)
        {
            Error = error;
            Code = HandleCodes.Error;
        }


        public TokenHandleResult(KeyToken result, IReduceExpression? param, KeyToken[] tokens)
        {
            Code = HandleCodes.Reduce;
            Error = string.Empty;

            Param = param;
            Result = result;
            Reduced = tokens;
        }
    }


    enum HandleCodes
    {
        Success,

        Error,

        Shift,

        Reduce
    }
}