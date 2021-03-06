
using System.Linq.Expressions;

namespace com.brgs.orm.AzureHelpers.ExpressionHelpers
{
    internal class ExpressionTypeGreaterThanHelper
    {
        private readonly bool _orEqual;
        public BinaryExpression Body { get; private set; }
        public MemberExpression Left { get { return (MemberExpression) Body.Left; } }
        public ConstantExpression Right { get { return (ConstantExpression) Body.Right; } }
        public string PropertyName { get { return Left.Member.Name; } }
        public object Value { get { return Right.Value; } }
        public ExpressionTypeGreaterThanHelper(Expression predicate, bool orEqual = false)
        {
            Body = (BinaryExpression) predicate;
            _orEqual = orEqual;

        }        

        public override string ToString()
        {
            if(!_orEqual)
            {
                return $"{PropertyName} gt {Value}";
            } 
            return $"{PropertyName} ge {Value}";

        }
    }

}