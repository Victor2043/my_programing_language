
namespace Lucy.Comparation
{
    public class Comparations
    {

        public bool IsEquals(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft == intRight;

            if (left is float floatLeft && right is float floatRight)
                return floatLeft == floatRight;

            if (left is float fltLeft && right is int integerRight)
                return fltLeft == integerRight;

            if (left is int integerLeft && right is float fltRight)
                return integerLeft == fltRight;

            if (left is string strLeft && right is string strRight)
                return strLeft == strRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
        public bool IsNotEquals(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft != intRight;

            if (left is float floatLeft && right is float floatRight)
                return floatLeft != floatRight;

            if (left is float fltLeft && right is int integerRight)
                return fltLeft != integerRight;

            if (left is int integerLeft && right is float fltRight)
                return integerLeft != fltRight;

            if (left is string strLeft && right is string strRight)
                return strLeft != strRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
        public bool LessThan(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft < intRight;

            if (left is float floatLeft && right is float floatRight)
                return floatLeft < floatRight;

            if (left is float fltLeft && right is int integerRight)
                return fltLeft < integerRight;

            if (left is int integerLeft && right is float fltRight)
                return integerLeft < fltRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
        public bool GreaterThan(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft > intRight;

            if (left is int floatLeft && right is int floatRight)
                return floatLeft > floatRight;

            if (left is int fltLeft && right is int integerRight)
                return fltLeft > integerRight;

            if (left is int integerLeft && right is int fltRight)
                return integerLeft > fltRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
        public bool LessOrEqual(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft <= intRight;

            if (left is float floatLeft && right is float floatRight)
                return floatLeft <= floatRight;

            if (left is float fltLeft && right is int integerRight)
                return fltLeft <= integerRight;

            if (left is int integerLeft && right is float fltRight)
                return integerLeft <= fltRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
        public bool GreaterOrEqual(object? left, object? right)
        {
            if (left is int intLeft && right is int intRight)
                return intLeft >= intRight;

            if (left is float floatLeft && right is float floatRight)
                return floatLeft >= floatRight;

            if (left is float fltLeft && right is int integerRight)
                return fltLeft >= integerRight;

            if (left is int integerLeft && right is float fltRight)
                return integerLeft >= fltRight;

            throw new Exception($"Cannot compare values of types{left?.GetType()} and {right?.GetType()}.");
        }
    }
}
