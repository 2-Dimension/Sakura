using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Sakura.Extensions
{
    public static class MethodInfoExtension
    {
        //Reference: https://stackoverflow.com/questions/940675/getting-a-delegate-from-methodinfo
        public static Delegate CreateDelegate(this MethodInfo method, object firstArgument = null)
        {
            Func<Type[], Type> getType;
            var types = method.GetParameters().Select(p => p.ParameterType);
            var isAction = method.ReturnType.Equals((typeof(void)));
            if (isAction)
                getType = Expression.GetActionType;
            else
            {
                getType = Expression.GetFuncType;
                types = types.Concat(new[] { method.ReturnType });
            }

            if (firstArgument == null)
                return Delegate.CreateDelegate(getType(types.ToArray()), method);
            return Delegate.CreateDelegate(getType(types.ToArray()), firstArgument, method);
        }
    }
}