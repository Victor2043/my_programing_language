
namespace Lucy.Operation
{
    public class Operations 
    {
        public object? Add(object? leftValue, object? rightValue)
        {
            if (leftValue is int integerLeftValue && rightValue is int integerRightValue)
                return integerLeftValue + integerRightValue;

            if (leftValue is int floatLeftValue && rightValue is int floatRightValue)
                return floatLeftValue + floatRightValue;

            if (leftValue is int intLeftValue && rightValue is float fltRightValue)
                return intLeftValue + fltRightValue;

            if (leftValue is float fltLeftValue && rightValue is int intRightValue)
                return fltLeftValue + intRightValue;

            if (leftValue is string strLeftValue && rightValue is int strRightValue)
                return $"{strLeftValue}{strRightValue}";


            return new NotImplementedException();
        }
        public object? Subtract(object leftValue, object rightValue)
        {
            if (leftValue is int integerLeftValue && rightValue is int integerRightValue)
                return integerLeftValue - integerRightValue;

            if (leftValue is int floatLeftValue && rightValue is int floatRightValue)
                return floatLeftValue - floatRightValue;

            if (leftValue is int intLeftValue && rightValue is float fltRightValue)
                return intLeftValue - fltRightValue;

            if (leftValue is float fltLeftValue && rightValue is int intRightValue)
                return fltLeftValue - intRightValue;

            return new NotImplementedException();
        }
        public object? Multiply(object leftValue, object rightValue)
        {
            if (leftValue is int integerLeftValue && rightValue is int integerRightValue)
                return integerLeftValue * integerRightValue;

            if (leftValue is int floatLeftValue && rightValue is int floatRightValue)
                return floatLeftValue * floatRightValue;

            if (leftValue is int intLeftValue && rightValue is float fltRightValue)
                return intLeftValue * fltRightValue;

            if (leftValue is float fltLeftValue && rightValue is int intRightValue)
                return fltLeftValue * intRightValue;

            return new NotImplementedException();
        }
        public object? Divide(object leftValue, object rightValue)
        {
            if (leftValue is int integerLeftValue && rightValue is int integerRightValue)
                return integerLeftValue / integerRightValue;

            if (leftValue is int floatLeftValue && rightValue is int floatRightValue)
                return floatLeftValue / floatRightValue;

            if (leftValue is int intLeftValue && rightValue is float fltRightValue)
                return intLeftValue / fltRightValue;

            if (leftValue is float fltLeftValue && rightValue is int intRightValue)
                return fltLeftValue / intRightValue;

            return new NotImplementedException();
        }
    }
}
