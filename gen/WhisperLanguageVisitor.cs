//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from ../whisper-grammar/WhisperLanguage.g4 by ANTLR 4.9.2

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
/// by <see cref="WhisperLanguageParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IWhisperLanguageVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParse([NotNull] WhisperLanguageParser.ParseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBlock([NotNull] WhisperLanguageParser.BlockContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] WhisperLanguageParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] WhisperLanguageParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>buildInIdentifierFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBuildInIdentifierFunctionCall([NotNull] WhisperLanguageParser.BuildInIdentifierFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierFunctionCall([NotNull] WhisperLanguageParser.IdentifierFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>printlnFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintlnFunctionCall([NotNull] WhisperLanguageParser.PrintlnFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>printFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPrintFunctionCall([NotNull] WhisperLanguageParser.PrintFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assertFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssertFunctionCall([NotNull] WhisperLanguageParser.AssertFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>sizeFunctionCall</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSizeFunctionCall([NotNull] WhisperLanguageParser.SizeFunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.ifStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStatement([NotNull] WhisperLanguageParser.IfStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.ifStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfStat([NotNull] WhisperLanguageParser.IfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.elseIfStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseIfStat([NotNull] WhisperLanguageParser.ElseIfStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.elseStat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseStat([NotNull] WhisperLanguageParser.ElseStatContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.functionDecl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDecl([NotNull] WhisperLanguageParser.FunctionDeclContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.forStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForStatement([NotNull] WhisperLanguageParser.ForStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.whileStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileStatement([NotNull] WhisperLanguageParser.WhileStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.idList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdList([NotNull] WhisperLanguageParser.IdListContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.exprList"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExprList([NotNull] WhisperLanguageParser.ExprListContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>boolExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolExpression([NotNull] WhisperLanguageParser.BoolExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>numberExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumberExpression([NotNull] WhisperLanguageParser.NumberExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] WhisperLanguageParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>notExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNotExpression([NotNull] WhisperLanguageParser.NotExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>orExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOrExpression([NotNull] WhisperLanguageParser.OrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unaryMinusExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryMinusExpression([NotNull] WhisperLanguageParser.UnaryMinusExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>powerExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPowerExpression([NotNull] WhisperLanguageParser.PowerExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>eqExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqExpression([NotNull] WhisperLanguageParser.EqExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>andExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAndExpression([NotNull] WhisperLanguageParser.AndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>inExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInExpression([NotNull] WhisperLanguageParser.InExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>stringExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringExpression([NotNull] WhisperLanguageParser.StringExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>expressionExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpressionExpression([NotNull] WhisperLanguageParser.ExpressionExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpression([NotNull] WhisperLanguageParser.AddExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>compExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompExpression([NotNull] WhisperLanguageParser.CompExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nullExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullExpression([NotNull] WhisperLanguageParser.NullExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionCallExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallExpression([NotNull] WhisperLanguageParser.FunctionCallExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultExpression([NotNull] WhisperLanguageParser.MultExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>listExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitListExpression([NotNull] WhisperLanguageParser.ListExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ternaryExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTernaryExpression([NotNull] WhisperLanguageParser.TernaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>inputExpression</c>
	/// labeled alternative in <see cref="WhisperLanguageParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInputExpression([NotNull] WhisperLanguageParser.InputExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.list_Alias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitList_Alias([NotNull] WhisperLanguageParser.List_AliasContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="WhisperLanguageParser.indexes"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIndexes([NotNull] WhisperLanguageParser.IndexesContext context);
}
