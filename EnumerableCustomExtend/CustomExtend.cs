using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableCustomExtend
{
    /// <summary>
    /// 自定义扩展
    /// </summary>
    public static class CustomExtend
    {
        /// <summary>
        /// 自定义Distinct扩展方法
        /// </summary>
        /// <typeparam name="T">要去重的对象类</typeparam>
        /// <typeparam name="C">自定义去重的字段类型</typeparam>
        /// <param name="source">要去重的对象</param>
        /// <param name="getfield">获取自定义去重字段的委托</param>
        /// <returns></returns>
        public static IEnumerable<T> MyDistinct<T, C>(this IEnumerable<T> source, Func<T, C> getfield)
        {
            return source.Distinct(new Compare<T, C>(getfield));
        }
        /// <summary>
        /// 自定义Intersect扩展方法
        /// </summary>
        /// <typeparam name="T">要取交集的类</typeparam>
        /// <typeparam name="C">自定义字段类型</typeparam>
        /// <param name="first">第一个集合</param>
        /// <param name="second">第二个集合</param>
        /// <param name="getfield">获取自定义比较字段的委托</param>
        /// <returns></returns>
        public static IEnumerable<T> MyIntersect<T, C>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, C> getfield)
        {
            return first.Intersect(second, new Compare<T, C>(getfield));
        }

        /// <summary>
        /// 自定义Except扩展方法
        /// </summary>
        /// <typeparam name="T">要取差集的类</typeparam>
        /// <typeparam name="C">自定义字段类型</typeparam>
        /// <param name="first">第一个集合</param>
        /// <param name="second">第二个集合</param>
        /// <param name="getfield">获取自定义比较字段的委托</param>
        /// <returns></returns>
        public static IEnumerable<T> MyExcept<T,C>(this IEnumerable<T> first,IEnumerable<T> second,Func<T,C> getfield )
        {
            return first.Except(second,new Compare<T,C>(getfield));
        }

        /// <summary>
        /// 自定义Union扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="C"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="getfield"></param>
        /// <returns></returns>
        public static IEnumerable<T> MyUnion<T, C>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, C> getfield)
        {
            return first.Union(second, new Compare<T, C>(getfield));
        }
    }

    /// <summary>
    /// 自定义比较类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="C"></typeparam>
    public class Compare<T, C> : IEqualityComparer<T>
    {
        private Func<T, C> _getField;
        public Compare(Func<T, C> getfield)
        {
            this._getField = getfield;
        }
        public bool Equals(T x, T y)
        {
            return EqualityComparer<C>.Default.Equals(_getField(x), _getField(y));
        }
        public int GetHashCode(T obj)
        {
            return EqualityComparer<C>.Default.GetHashCode(this._getField(obj));
        }
    }

    class PersonCompare: IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.Name == y.Name && x.Age == y.Age;
        }

        public int GetHashCode(Person obj)
        {
            return (obj == null) ? 0 : obj.ToString().GetHashCode();
        }

    }
}
