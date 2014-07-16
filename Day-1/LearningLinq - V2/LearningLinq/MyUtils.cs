using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace LearningLinq
{
    public static class MyUtils
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, IItemFilterCriteria<T> criteria)
        {
            //var result = new IEnumerable<T>();
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria.IsSatisfiedBy(tItem))
                    yield return tItem;
            }
            //return result;
        }

        //public IEnumerable<T> Filter(Func<T,bool> criteria)
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Predicate<T> criteria)
        {
            //var result = new IEnumerable<T>();
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria(tItem))
                    //result.Add(tItem);
                    yield return tItem;
            }
            //return result;
        }

        public static int Count<T>(this IEnumerable<T> list)
        {
            var count = 0;
            foreach (var item in list)
            {
                count++;
            }
            return count;
        }

        //public int Min(IntAttributeSelectorDelegate<T> selector)
        public static int Min<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            var result = int.MaxValue;
            foreach (var item in list)
            {
                var tItem = (T)item;
                var value = selector(tItem);
                if (value < result) result = value;
            }

            return result;
        }

        //public int Sum(IntAttributeSelectorDelegate<T> selector)
        public static int Sum<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            var result = 0;
            foreach (var item in list)
            {
                var tItem = (T)item;
                result += selector(tItem);
            }
            return result;
        }

        //public int Avg(IntAttributeSelectorDelegate<T> selector)
        public static int Avg<T>(this IEnumerable<T> list, Func<T, int> selector)
        {
            return list.Sum(selector) / list.Count();
        }


        //public bool Any(FilterCriteriaDelegate<T> criteria)
        public static bool Any<T>(this IEnumerable<T> list, Predicate<T> criteria)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (criteria(tItem))
                    return true;
            }
            return false;
        }

        public static bool All<T>(this IEnumerable<T> list, Predicate<T> criteria)
        {
            foreach (var item in list)
            {
                var tItem = (T)item;
                if (!criteria(tItem))
                    return false;
            }
            return true;
        }

        public static Dictionary<TKey, List<T>> GroupBy<T, TKey>(this IEnumerable<T> list, Func<T, TKey> keySelector)
        {
            var result = new Dictionary<TKey, List<T>>();
            foreach (var item in list)
            {
                var tItem = (T)item;
                var key = keySelector(tItem);
                if (!result.ContainsKey(key))
                    result[key] = new List<T>();
                result[key].Add(tItem);
            }
            return result;
        }

    }
}
