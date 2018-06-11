using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //Expression<Fubnc<T>> 에대한 확장메서드를 선언하는 부분 
    //확장메서드를 사용하는 이유에 대해서 명확하게 알것 

    public static class ExpressionHelpers
    {
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();

        }


        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
          
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)expression.Member;
          
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
            Console.WriteLine(target);
            propertyInfo.SetValue(target, value);
        }

      
    }
}
