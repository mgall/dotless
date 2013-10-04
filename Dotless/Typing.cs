using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dotless
{
    public static class Typing
    {

        public static Type StringType = typeof(string);

        public static Type BoolType = typeof(bool);

        public static Type Int16Type = typeof(Int16);
        public static Type UInt16Type = typeof(UInt16);

        public static Type Int32Type = typeof(Int32);
        public static Type UInt32Type = typeof(UInt32);

        public static Type Int64Type = typeof(Int64);
        public static Type UInt64Type = typeof(UInt64);

        public static Type FloatType = typeof(float);

        public static Type DoubleType = typeof(double);

        public static Type DecimalType = typeof(decimal);

        public static Type DatetimeType = typeof(DateTime);

        #region [ Runtime Type Check ]

        public static bool Is(this Type target, Type type) {
            return target == type;
        }

        public static bool Is(this Type target, params Type[] types)
        {
            foreach (var type in types)
                if (type == target) return true;

            return false;
        }

        public static bool Is(this object target, params Type[] types)
        {
            var tarT = target.GetType();
            foreach (var type in types)
                if (type == tarT) return true;

            return false;
        }

        #endregion

        #region [ Compile Type Check ]

        public static bool Is<T>(this object target)
        {
            return (target is T);
        }

        public static bool Is<T1, T2>(this object target)
        {
            return (target is T1)
                || (target is T2);
        }

        public static bool Is<T1, T2, T3>(this object target)
        {
            return (target is T1)
                || (target is T2)
                || (target is T3);
        }

        public static bool Is<T1, T2, T3, T4>(this object target)
        {
            return (target is T1)
                || (target is T2)
                || (target is T3)
                || (target is T4);
        }

        public static bool Is<T1, T2, T3, T4, T5>(this object target)
        {
            return (target is T1)
                || (target is T2)
                || (target is T3)
                || (target is T4)
                || (target is T5);
        } 

        #endregion

        public static bool IsNumber(this Type target)
        {
            return Is(target, 
                Int32Type, DoubleType, FloatType, Int16Type, Int64Type, 
                DecimalType, UInt32Type, UInt32Type, UInt32Type
                );
        }


        public static T? To<T>(this object source) where T : struct
        {
            if (source == null) return null;

            var tt = typeof(T);
            return (tt == source.GetType()) ? source as T?:
                   (tt.IsEnum)              ? ToEnum<T>(source) :
                   (tt == BoolType)         ? ToBoolean(source) as T? :
                   (Typing.IsNumber(tt))    ? ToNumber<T>(source) :
                   (T?)Convert.ChangeType(source, tt);
        }

        private static T? ToEnum<T>(object source) where T: struct
        {
            if (source.GetType() != StringType)
                return (T?)Convert.ChangeType(Typing.To<Int32>(source), typeof(T?));

            T result;
            return Enum.TryParse<T>(source as string, true, out result) 
                    ? result
                    : (T?)null;
        }

        private static bool? ToBoolean(object source)
        {
            var st = source.GetType();
            if (source == null) return null; 
            if (st.IsEnum)    source = (int)source;
            try { return Convert.ToBoolean(source); }
            catch { return null;  }
        }

        private static T? ToNumber<T>(object source) where T: struct
        {
            if (source == null) return null;

            var st = source.GetType();
            if (st == typeof(T)) return source as T?;
            if (st.IsEnum) return source as T?;

            try {
                return (st == Int16Type)   ? Convert.ToInt16(source)   as T? :
                       (st == Int32Type)   ? Convert.ToInt32(source)   as T? :
                       (st == Int64Type)   ? Convert.ToInt64(source)   as T? :
                       (st == FloatType)   ? Convert.ToDouble(source)  as T? :
                       (st == DoubleType)  ? Convert.ToDouble(source)  as T? :
                       (st == DecimalType) ? Convert.ToDecimal(source) as T? :
                       (st == UInt16Type)  ? Convert.ToUInt16(source)  as T? :
                       (st == UInt32Type)  ? Convert.ToUInt32(source)  as T? :
                       (st == UInt64Type)  ? Convert.ToUInt64(source)  as T? :
                       (T?)null;
            } catch { return null; }
        }

    }
}
