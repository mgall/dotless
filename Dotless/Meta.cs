using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Dotless
{
    public static class Meta
    {

        public static PropertyInfo GetProperty<T>(this Expression<Func<T, object>> propertyTarget)
        {
            if (Null.Is(propertyTarget)) return null;

            var m = (propertyTarget.Body.NodeType == ExpressionType.Convert)
                    ? (propertyTarget.Body as UnaryExpression).Operand
                    : propertyTarget.Body;
            
            return (m as MemberExpression).Get(e=>e.Member) as PropertyInfo;
        }

        public static String GetPropertyName<T>(this Expression<Func<T, object>> propertyTarget)
        {
            return GetProperty(propertyTarget).Get(p=>p.Name);
        }


        public static object CreateGeneric<TCollection>(params Type[] types)
        {
            Type generic = typeof(TCollection);
            Type specific = generic.MakeGenericType(types);
            ConstructorInfo ci = specific.GetConstructor(Type.EmptyTypes);
            return ci.Invoke(Null.Params);
        }
    }
}
