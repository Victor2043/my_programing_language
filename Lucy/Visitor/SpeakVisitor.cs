using Antlr4.Runtime.Misc;
using Lucy.Antlr;
using Lucy.Comparation;
using Lucy.Operations;

namespace Lucy.Visitor
{
    public class SpeakVisitor : SpeakBaseVisitor<object>
    {
        private Dictionary<string, object?> Variables { get; } = new();
        private readonly Comparations _Comparations = new Comparations();
        private readonly Operations _Operations = new Operations();

        public SpeakVisitor()
        {
            Variables["show"] = new Func<object?[], object?>(Show);
        }

        public override object? VisitAssignment(SpeakParser.AssignmentContext context)
        {
            var varName = context.IDENTIFIER().GetText();

            var value = Visit(context.expression());

            Variables[varName] = value;

            return null;
        }

        public override object? VisitFunctionCall(SpeakParser.FunctionCallContext context)
        {
            var name = context.IDENTIFIER().GetText();
            var args = context.expression().Select(Visit).ToArray();

            if (!Variables.ContainsKey(name))
                throw new Exception($"Function {name} is not defined.");

            if (Variables[name] is not Func<object?[], object?> func)
                throw new Exception($"Variable {name} is not a function.");

            return func(args);
        }

        public override object? VisitConstant(SpeakParser.ConstantContext context)
        {
            if (context.INTEGER() is { } i)
                return int.Parse(i.GetText());

            if (context.FLOAT() is { } f)
                return float.Parse(f.GetText());

            if (context.STRING() is { } s)
                return s.GetText()[1..^1];

            if (context.BOOL() is { } b)
                return b.GetText() == "true";

            if (context.NULL() is { } n)
                return null;

            return null;

        }


        public override object? VisitAdditiveExpression(SpeakParser.AdditiveExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            var operation = context.addOp().GetText();

            return operation switch
            {
                "+" => _Operations.Add(left, right),
                "-" => _Operations.Subtract(left, right),
                "*" => _Operations.Multiply(left, right),
                "/" => _Operations.Divide(left, right),
                _ => throw new NotImplementedException(operation),
            };
        }

        public override object? VisitMultiplicativeExpression(SpeakParser.MultiplicativeExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            var operation = context.multOp().GetText();

            return operation switch
            {
                "*" => _Operations.Multiply(left, right),
                "/" => _Operations.Divide(left, right),
                _ => throw new NotImplementedException(operation),
            };
        }


        public override object? VisitIdentifierExpression(SpeakParser.IdentifierExpressionContext context)
        {
            var varName = context.IDENTIFIER().GetText();

            if (!Variables.ContainsKey(varName))
                throw new Exception($"Variable {varName} is not defined.");

            return Variables[varName];
        }

       
        public override object? VisitWhileBlock([NotNull] SpeakParser.WhileBlockContext context)
        {
            Func<object?, bool> condition = context.WHILE().GetText() == "while" ? IsTrue : IsFalse;

            while (condition(Visit(context.expression())))
            {
                Visit(context.block());
            }

            return null;
        }

        private bool IsTrue(object? value)
        {
            if (value is bool b)
                return b;

            if (value is int i)
                return i != 0;

            throw new Exception("Value is not boolean.");
        }

        private bool IsFalse(object? value) => !IsTrue(value);

        public override object? VisitComparisonExpression([NotNull] SpeakParser.ComparisonExpressionContext context)
        {
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            var op = context.compareOp().GetText();

            return op switch
            {
                "==" => _Comparations.IsEquals(left, right),
                "!=" => _Comparations.IsNotEquals(left, right),
                "<" => _Comparations.LessThan(left, right),
                ">" => _Comparations.GreaterThan(left, right),
                "<=" => _Comparations.LessOrEqual(left, right),
                ">=" => _Comparations.GreaterOrEqual(left, right)

            };
        }


        private object? Show(object?[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }

            return null;
        }
    }
}
