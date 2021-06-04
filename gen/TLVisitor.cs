//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ./TL.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="TLParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface ITLVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParse([NotNull] TLParser.ParseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] TLParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] TLParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] TLParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>buildInIdentifierFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBuildInIdentifierFunctionCall([NotNull] TLParser.BuildInIdentifierFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierFunctionCall([NotNull] TLParser.IdentifierFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>printlnFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintlnFunctionCall([NotNull] TLParser.PrintlnFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>printFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintFunctionCall([NotNull] TLParser.PrintFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assertFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssertFunctionCall([NotNull] TLParser.AssertFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>sizeFunctionCall</c>
	/// labeled alternative in <see cref="TLParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSizeFunctionCall([NotNull] TLParser.SizeFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] TLParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.ifStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStat([NotNull] TLParser.IfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.elseIfStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseIfStat([NotNull] TLParser.ElseIfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.elseStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStat([NotNull] TLParser.ElseStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.functionDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDecl([NotNull] TLParser.FunctionDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] TLParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] TLParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.idList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdList([NotNull] TLParser.IdListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExprList([NotNull] TLParser.ExprListContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolExpression([NotNull] TLParser.BoolExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>numberExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExpression([NotNull] TLParser.NumberExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] TLParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotExpression([NotNull] TLParser.NotExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>orExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpression([NotNull] TLParser.OrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unaryMinusExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryMinusExpression([NotNull] TLParser.UnaryMinusExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>powerExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPowerExpression([NotNull] TLParser.PowerExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>eqExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqExpression([NotNull] TLParser.EqExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>andExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpression([NotNull] TLParser.AndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>inExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInExpression([NotNull] TLParser.InExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>stringExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringExpression([NotNull] TLParser.StringExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionExpression([NotNull] TLParser.ExpressionExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpression([NotNull] TLParser.AddExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompExpression([NotNull] TLParser.CompExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nullExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullExpression([NotNull] TLParser.NullExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] TLParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultExpression([NotNull] TLParser.MultExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListExpression([NotNull] TLParser.ListExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ternaryExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTernaryExpression([NotNull] TLParser.TernaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="TLParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInputExpression([NotNull] TLParser.InputExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList([NotNull] TLParser.ListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="TLParser.indexes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexes([NotNull] TLParser.IndexesContext context);
}
