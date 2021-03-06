using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using whisper_language.gen;

namespace whisper_language
{
    class EvalVisitor : WhisperLanguageBaseVisitor<TLValue>
    {
        private static ReturnValue returnValue = new ReturnValue();

        private Scope scope;

        private Dictionary<string, Function> functions;

        private Dictionary<string, BuildInFunction> buildInfunction;

        public EvalVisitor(Scope scope, Dictionary<string, Function> functions, Dictionary<string, BuildInFunction> buildInfunction)
        {
            this.scope = scope;
            this.functions = functions;
            this.buildInfunction = buildInfunction;
        }


        override public TLValue VisitFunctionDecl(WhisperLanguageParser.FunctionDeclContext ctx)
        {
            ITerminalNode[] emptyList = { };
            List<ITerminalNode> param = (ctx.idList() != null ? ctx.idList().Identifier() : emptyList).ToList();
            IParseTree block = ctx.block();
            string id = ctx.Identifier().GetText() + param.Count;
            functions.Add(id, new Function(scope, param, block));
            return TLValue.VOID;
        }

        override
       public TLValue VisitList_Alias(WhisperLanguageParser.List_AliasContext ctx)
        {
            List<TLValue> list = new List<TLValue>();
            if (ctx.exprList() != null)
            {

                foreach (WhisperLanguageParser.ExpressionContext ex in ctx.exprList().expression())
                {
                    list.Add(this.Visit(ex));
                }
            }
            return new TLValue(list);
        }


        // '-' expression                           #unaryMinusExpression
        override
       public TLValue VisitUnaryMinusExpression(WhisperLanguageParser.UnaryMinusExpressionContext ctx)
        {
            TLValue v = this.Visit(ctx.expression());
            if (!v.IsNumber())
            {
                throw new EvalException(ctx);
            }
            return new TLValue(-1 * v.asDouble());
        }

        // '!' expression                           #notExpression
        override
       public TLValue VisitNotExpression(WhisperLanguageParser.NotExpressionContext ctx)
        {
            TLValue v = this.Visit(ctx.expression());
            if (!v.IsBoolean())
            {
                throw new EvalException(ctx);
            }
            return new TLValue(!v.asBoolean());
        }

        // expression '^' expression                #powerExpression
        override
       public TLValue VisitPowerExpression(WhisperLanguageParser.PowerExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(Math.Pow(lhs.asDouble(), rhs.asDouble()));
            }
            throw new EvalException(ctx);
        }

        // expression op=( '*' | '/' | '%' ) expression         #multExpression
        override
       public TLValue VisitMultExpression(WhisperLanguageParser.MultExpressionContext ctx)
        {
            switch (ctx.op.Type)
            {
                case WhisperLanguageLexer.Multiply:
                    return multiply(ctx);
                case WhisperLanguageLexer.Divide:
                    return divide(ctx);
                case WhisperLanguageLexer.Modulus:
                    return modulus(ctx);
                default:
                    throw new Exception("错误的操作符: " + ctx.op.Type);
            }
        }

        // expression op=( '+' | '-' ) expression               #addExpression
        override
       public TLValue VisitAddExpression(WhisperLanguageParser.AddExpressionContext ctx)
        {
            switch (ctx.op.Type)
            {
                case WhisperLanguageLexer.Add:
                    return add(ctx);
                case WhisperLanguageLexer.Subtract:
                    return subtract(ctx);
                default:
                    throw new Exception("错误的操作符: " + ctx.op.Type);
            }
        }

        // expression op=( '>=' | '<=' | '>' | '<' ) expression #compExpression
        override
       public TLValue VisitCompExpression(WhisperLanguageParser.CompExpressionContext ctx)
        {
            switch (ctx.op.Type)
            {
                case WhisperLanguageLexer.LT:
                    return lt(ctx);
                case WhisperLanguageLexer.LTEquals:
                    return ltEq(ctx);
                case WhisperLanguageLexer.GT:
                    return gt(ctx);
                case WhisperLanguageLexer.GTEquals:
                    return gtEq(ctx);
                default:
                    throw new Exception("错误的操作符: " + ctx.op.Type);
            }
        }

        // expression op=( '==' | '!=' ) expression             #eqExpression
        override
       public TLValue VisitEqExpression(WhisperLanguageParser.EqExpressionContext ctx)
        {
            switch (ctx.op.Type)
            {
                case WhisperLanguageLexer.Equals:
                    return eq(ctx);
                case WhisperLanguageLexer.NEquals:
                    return nEq(ctx);
                default:
                    throw new Exception("错误的操作符: " + ctx.op.Type);
            }
        }

        public TLValue multiply(WhisperLanguageParser.MultExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs == null || rhs == null)
            {
                //System.err.println("lhs " + lhs + " rhs " + rhs);
                throw new EvalException(ctx);
            }

            // number * number
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() * rhs.asDouble());
            }

            // string * number
            if (lhs.IsString() && rhs.IsNumber())
            {
                var str = "";
                int stop = rhs.asInt();
                for (int i = 0; i < stop; i++)
                {
                    str = str+lhs.ToString();
                };
                return new TLValue(str);
            }

            // list * number
            if (lhs.isList() && rhs.IsNumber())
            {
                List<TLValue> total = new List<TLValue>();
                int stop = rhs.asInt();
                for (int i = 0; i < stop; i++)
                {
                    total.AddRange(lhs.asList());
                }
                return new TLValue(total);
            }

            throw new EvalException(ctx);
        }

        private TLValue divide(WhisperLanguageParser.MultExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() / rhs.asDouble());
            }
            throw new EvalException(ctx);
        }

        private TLValue modulus(WhisperLanguageParser.MultExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() % rhs.asDouble());
            }
            throw new EvalException(ctx);
        }

        private TLValue add(WhisperLanguageParser.AddExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));

            if (lhs == null || rhs == null)
            {
                throw new EvalException(ctx);
            }

            // number + number
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() + rhs.asDouble());
            }

            // list + any
            if (lhs.isList())
            {
                List<TLValue> list = lhs.asList();
                list.Add(rhs);
                return new TLValue(list);
            }

            // string + any
            if (lhs.IsString())
            {
                return new TLValue(lhs.asString() + "" + rhs.ToString());
            }

            // any + string
            if (rhs.IsString())
            {
                return new TLValue(lhs.ToString() + "" + rhs.asString());
            }

            return new TLValue(lhs.ToString() + rhs.ToString());
        }

        private TLValue subtract(WhisperLanguageParser.AddExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() - rhs.asDouble());
            }
            if (lhs.isList())
            {
                List<TLValue> list = lhs.asList();
                list.Remove(rhs);
                return new TLValue(list);
            }
            throw new EvalException(ctx);
        }

        private TLValue gtEq(WhisperLanguageParser.CompExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() >= rhs.asDouble());
            }
            if (lhs.IsString() && rhs.IsString())
            {
                return new TLValue(lhs.asString().CompareTo(rhs.asString()) >= 0);
            }
            throw new EvalException(ctx);
        }

        private TLValue ltEq(WhisperLanguageParser.CompExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() <= rhs.asDouble());
            }
            if (lhs.IsString() && rhs.IsString())
            {
                return new TLValue(lhs.asString().CompareTo(rhs.asString()) <= 0);
            }
            throw new EvalException(ctx);
        }

        private TLValue gt(WhisperLanguageParser.CompExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() > rhs.asDouble());
            }
            if (lhs.IsString() && rhs.IsString())
            {
                return new TLValue(lhs.asString().CompareTo(rhs.asString()) > 0);
            }
            throw new EvalException(ctx);
        }

        private TLValue lt(WhisperLanguageParser.CompExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs.IsNumber() && rhs.IsNumber())
            {
                return new TLValue(lhs.asDouble() < rhs.asDouble());
            }
            if (lhs.IsString() && rhs.IsString())
            {
                return new TLValue(lhs.asString().CompareTo(rhs.asString()) < 0);
            }
            throw new EvalException(ctx);
        }

        private TLValue eq(WhisperLanguageParser.EqExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            if (lhs == null)
            {
                throw new EvalException(ctx);
            }
            return new TLValue(lhs.Equals(rhs));
        }

        private TLValue nEq(WhisperLanguageParser.EqExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));
            return new TLValue(!lhs.Equals(rhs));
        }

        // expression '&&' expression               #andExpression
        override
       public TLValue VisitAndExpression(WhisperLanguageParser.AndExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));

            if (!lhs.IsBoolean() || !rhs.IsBoolean())
            {
                throw new EvalException(ctx);
            }
            return new TLValue(lhs.asBoolean() && rhs.asBoolean());
        }

        // expression '||' expression               #orExpression
        override
       public TLValue VisitOrExpression(WhisperLanguageParser.OrExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));

            if (!lhs.IsBoolean() || !rhs.IsBoolean())
            {
                throw new EvalException(ctx);
            }
            return new TLValue(lhs.asBoolean() || rhs.asBoolean());
        }

        // expression '?' expression ':' expression #ternaryExpression
        override
       public TLValue VisitTernaryExpression(WhisperLanguageParser.TernaryExpressionContext ctx)
        {
            TLValue condition = this.Visit(ctx.expression(0));
            if (condition.asBoolean())
            {
                return this.Visit(ctx.expression(1));
            }
            else
            {
                return this.Visit(ctx.expression(2));
            }
        }

        // expression In expression                 #inExpression
        override
       public TLValue VisitInExpression(WhisperLanguageParser.InExpressionContext ctx)
        {
            TLValue lhs = this.Visit(ctx.expression(0));
            TLValue rhs = this.Visit(ctx.expression(1));

            if (rhs.isList())
            {
                foreach (TLValue val in rhs.asList())
                {
                    if (val.Equals(lhs))
                    {
                        return new TLValue(true);
                    }
                }
                return new TLValue(false);
            }
            throw new EvalException(ctx);
        }

        // Number                                   #numberExpression
        override
       public TLValue VisitNumberExpression(WhisperLanguageParser.NumberExpressionContext ctx)
        {

            return new TLValue(Double.Parse(ctx.GetText()));
        }

        // Bool                                     #boolExpression
        override
       public TLValue VisitBoolExpression(WhisperLanguageParser.BoolExpressionContext ctx)
        {
            return new TLValue(Boolean.Parse(ctx.GetText()));
        }

        // Null                                     #nullExpression
        override
       public TLValue VisitNullExpression(WhisperLanguageParser.NullExpressionContext ctx)
        {
            return TLValue.NULL;
        }

        private TLValue resolveIndexes(TLValue val, List<WhisperLanguageParser.ExpressionContext> indexes)
        {
            foreach (WhisperLanguageParser.ExpressionContext ec in indexes)
            {
                TLValue idx = this.Visit(ec);
                if (!idx.IsNumber() || (!val.isList() && !val.IsString()))
                {
                    throw new EvalException("Problem resolving indexes on " + val + " at " + idx, ec);
                }
                int i = idx.asInt();
                if (val.IsString())
                {
                    //字符串分片
                    val = new TLValue(val.asString().Substring(i, 1));
                }
                else
                {
                    val = val.asList()[i];
                }
            }
            return val;
        }

        private void setAtIndex(ParserRuleContext ctx, List<WhisperLanguageParser.ExpressionContext> indexes, TLValue val, TLValue newVal)
        {
            if (!val.isList())
            {
                throw new EvalException(ctx);
            }
            var idx = new TLValue();
            for (int i = 0; i < indexes.Count - 1; i++)
            {
                idx = this.Visit(indexes[i]);
                if (!idx.IsNumber())
                {
                    throw new EvalException(ctx);
                }
                val = val.asList()[idx.asInt()];
            }
            idx = this.Visit(indexes[indexes.Count - 1]);
            if (!idx.IsNumber())
            {
                throw new EvalException(ctx);
            }
            val.asList()[idx.asInt()] = newVal;
        }

        // functionCall indexes?                    #functionCallExpression
        override public TLValue VisitFunctionCallExpression(WhisperLanguageParser.FunctionCallExpressionContext ctx)
        {


            TLValue val = this.Visit(ctx.functionCall());
            if (ctx.indexes() != null)
            {
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                val = resolveIndexes(val, exps);
            }
            return val;
        }

        // list indexes?                            #listExpression
        override
       public TLValue VisitListExpression(WhisperLanguageParser.ListExpressionContext ctx)
        {
            TLValue val = this.Visit(ctx.list_Alias());
            if (ctx.indexes() != null)
            {
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                val = resolveIndexes(val, exps);
            }
            return val;
        }

        // Identifier indexes?                      #identifierExpression
        override
       public TLValue VisitIdentifierExpression(WhisperLanguageParser.IdentifierExpressionContext ctx)
        {
            String id = ctx.Identifier().GetText();
            TLValue val = scope.resolve(id);

            if (ctx.indexes() != null)
            {
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                val = resolveIndexes(val, exps);
            }
            return val;
        }

        // String indexes?                          #stringExpression
        override
       public TLValue VisitStringExpression(WhisperLanguageParser.StringExpressionContext ctx)
        {
            String text = ctx.GetText();
            //TODO 转义字符的处理

            text = text.Substring(1, text.Count() - 2).Replace("\\\\(.)", "$1");

            TLValue val = new TLValue(text);
            if (ctx.indexes() != null)
            {
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                val = resolveIndexes(val, exps);
            }
            return val;
        }

        // '(' expression ')' indexes?              #expressionExpression
        override
       public TLValue VisitExpressionExpression(WhisperLanguageParser.ExpressionExpressionContext ctx)
        {
            TLValue val = this.Visit(ctx.expression());
            if (ctx.indexes() != null)
            {
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                val = resolveIndexes(val, exps);
            }
            return val;
        }

        // Input '(' String? ')'                    #inputExpression
        override
           public TLValue VisitInputExpression(WhisperLanguageParser.InputExpressionContext ctx)
        {
            throw new Exception("未实现");
        }


        // assignment
        // : Identifier indexes? '=' expression
        // ;
        override
       public TLValue VisitAssignment(WhisperLanguageParser.AssignmentContext ctx)
        {
            TLValue newVal = this.Visit(ctx.expression());
            if (ctx.indexes() != null)
            {
                TLValue val = scope.resolve(ctx.Identifier().GetText());
                List<WhisperLanguageParser.ExpressionContext> exps = ctx.indexes().expression().ToList();
                setAtIndex(ctx, exps, val, newVal);
            }
            else
            {
                String id = ctx.Identifier().GetText();
                scope.assign(id, newVal);
            }
            return TLValue.VOID;
        }

        override
       public TLValue VisitBuildInIdentifierFunctionCall(WhisperLanguageParser.BuildInIdentifierFunctionCallContext ctx)
        {
            List<WhisperLanguageParser.ExpressionContext> param = ctx.exprList() != null ? ctx.exprList().expression().ToList() : new List<WhisperLanguageParser.ExpressionContext>();
            String id = ctx.BuildIdentifier().GetText();
            BuildInFunction function;
            if ((function = buildInfunction[id]) != null)
            {
                List<TLValue> args = new List<TLValue>(param.Count);
                foreach (WhisperLanguageParser.ExpressionContext param1 in param)
                {
                    args.Add(this.Visit(param1));
                }
                return function.invoke(args);
            }
            throw new EvalException(ctx);
        }

        // Identifier '(' exprList? ')' #identifierFunctionCall
        override
       public TLValue VisitIdentifierFunctionCall(WhisperLanguageParser.IdentifierFunctionCallContext ctx)
        {

            List<WhisperLanguageParser.ExpressionContext> param = ctx.exprList() != null ? ctx.exprList().expression().ToList() : new List<WhisperLanguageParser.ExpressionContext>();
            String id = ctx.Identifier().GetText() + param.Count();
            Function function;

            if ((function = functions[id]) != null)
            {
                List<TLValue> args = new List<TLValue>(param.Count());
                foreach (WhisperLanguageParser.ExpressionContext param1 in param)
                {
                    args.Add(this.Visit(param1));
                }
                return function.invoke(args, functions, buildInfunction);
            }
            else
            {
                throw new EvalException(ctx);
            }

        }

        // Println '(' expression? ')'  #printlnFunctionCall
        override
       public TLValue VisitPrintlnFunctionCall(WhisperLanguageParser.PrintlnFunctionCallContext ctx)
        {
            if (ctx.expression() != null)
            {
                Console.Write(this.Visit(ctx.expression()));
            }
            else
            {
                Console.WriteLine();
            }
            return TLValue.VOID;
        }

        // Print '(' expression ')'     #printFunctionCall
        override
       public TLValue VisitPrintFunctionCall(WhisperLanguageParser.PrintFunctionCallContext ctx)
        {
            return TLValue.VOID;
        }

        // Assert '(' expression ')'    #assertFunctionCall
        override
       public TLValue VisitAssertFunctionCall(WhisperLanguageParser.AssertFunctionCallContext ctx)
        {
            TLValue value = this.Visit(ctx.expression());

            if (!value.IsBoolean())
            {
                throw new EvalException(ctx);
            }

            if (!value.asBoolean())
            {
                var f = ctx.Start.InputStream.SourceName;

                FileInfo fileInfo = new FileInfo(f);

                throw new Exception("Assert failed:" + ctx.expression().GetText() + " (" + fileInfo.Name + ":" + ctx.Start.Line + ")");
            }

            return TLValue.VOID;
        }

        // Size '(' expression ')'      #sizeFunctionCall
        override
       public TLValue VisitSizeFunctionCall(WhisperLanguageParser.SizeFunctionCallContext ctx)
        {
            TLValue value = this.Visit(ctx.expression());

            if (value.IsString())
            {
                return new TLValue(value.asString().Count());
            }

            if (value.isList())
            {
                return new TLValue(value.asList().Count);
            }

            throw new EvalException(ctx);
        }

        // ifStatement
        //  : ifStat elseIfStat* elseStat? End
        //  ;
        //
        // ifStat
        //  : If expression Do block
        //  ;
        //
        // elseIfStat
        //  : Else If expression Do block
        //  ;
        //
        // elseStat
        //  : Else Do block
        //  ;
        override
       public TLValue VisitIfStatement(WhisperLanguageParser.IfStatementContext ctx)
        {

            // if ...
            if (this.Visit(ctx.ifStat().expression()).asBoolean())
            {
                return this.Visit(ctx.ifStat().block());
            }

            // else if ...
            for (int i = 0; i < ctx.elseIfStat().Count(); i++)
            {
                if (this.Visit(ctx.elseIfStat(i).expression()).asBoolean())
                {
                    return this.Visit(ctx.elseIfStat(i).block());
                }
            }

            // else ...
            if (ctx.elseStat() != null)
            {
                return this.Visit(ctx.elseStat().block());
            }

            return TLValue.VOID;
        }

        // block
        // : (statement | functionDecl)* (Return expression)?
        // ;
        override
       public TLValue VisitBlock(WhisperLanguageParser.BlockContext ctx)
        {

            scope = new Scope(scope, false); // create new local scope
            foreach (WhisperLanguageParser.FunctionDeclContext fdx in ctx.functionDecl())
            {
                this.Visit(fdx);
            }
            foreach (WhisperLanguageParser.StatementContext sx in ctx.statement())
            {
                this.Visit(sx);
            }
            WhisperLanguageParser.ExpressionContext ex;
            if ((ex = ctx.expression()) != null)
            {
                returnValue.value = this.Visit(ex);
                scope = scope.Parent;
                throw returnValue;
            }
            scope = scope.Parent;
            return TLValue.VOID;
        }

        // forStatement
        // : For Identifier '=' expression To expression OBrace block CBrace
        // ;
        override
       public TLValue VisitForStatement(WhisperLanguageParser.ForStatementContext ctx)
        {
            int start = this.Visit(ctx.expression(0)).asInt();
            int stop = this.Visit(ctx.expression(1)).asInt();
            for (int i = start; i <= stop; i++)
            {
                scope.assign(ctx.Identifier().GetText(), new TLValue(i));
                TLValue returnValue = this.Visit(ctx.block());
                if (returnValue != TLValue.VOID)
                {
                    return returnValue;
                }
            }
            return TLValue.VOID;
        }

        // whileStatement
        // : While expression OBrace block CBrace
        // ;
        override
       public TLValue VisitWhileStatement(WhisperLanguageParser.WhileStatementContext ctx)
        {
            while (this.Visit(ctx.expression()).asBoolean())
            {
                TLValue returnValue = this.Visit(ctx.block());
                if (returnValue != TLValue.VOID)
                {
                    return returnValue;
                }
            }
            return TLValue.VOID;
        }


    }
}
