using System;
using System.Collections;

namespace LearningLinq
{
    public class MyCollection<T>
    {
        private ArrayList _list = new ArrayList();
        public void Add(T item)
        {
            _list.Add(item);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public T this[int index]
        {
            get { return (T) _list[index]; }
        }
        
        /*
        public Product GetById(int id)
        {
            foreach (var item in _list)
            {
                var product = (Product) item;
                if (product.Id == id)
                {
                    return product;
                }

            }
            return null;
        }
        
        public void Sort()
        {
            for (int i = 0; i < _list.Count-1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var iProduct = (Product) _list[i];
                    var jProduct = (Product) _list[j];
                    if (iProduct.Id > jProduct.Id)
                    {
                        var temp = iProduct;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
            }
        }
        */
        public void Sort(IItemComparer<T> comparer)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var leftItem = (T)_list[i];
                    var rightItem = (T)_list[j];
                    if (comparer.Compare(leftItem, rightItem) > 0)
                    {
                        var temp = leftItem;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
            }
        }

        public void Sort(Func<T,T,int> compare)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var leftItem = (T)_list[i];
                    var rightItem = (T)_list[j];
                    if (compare(leftItem, rightItem) > 0)
                    {
                        var temp = leftItem;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
            }
        }


        public MyCollection<T> Filter(IItemFilterCriteria<T> criteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in _list)
            {
                var tItem = (T)item;
                if (criteria.IsSatisfiedBy(tItem))
                    result.Add(tItem);
            }
            return result;
        }

        //public MyCollection<T> Filter(Func<T,bool> criteria)
        public MyCollection<T> Filter(Predicate<T> criteria)
        {
            var result = new MyCollection<T>();
            foreach (var item in _list)
            {
                var tItem = (T) item;
                if (criteria(tItem))
                    result.Add(tItem);
            }
            return result;
        }

        //public int Min(IntAttributeSelectorDelegate<T> selector)
        public int Min(Func<T,int> selector)
        {
            var result = int.MaxValue;
            for (var i = 0; i < _list.Count; i++)
            {
                var tItem = (T) _list[i];
                var value = selector(tItem);
                if (value < result) result = value;
            }
            return result;
        }

        //public int Sum(IntAttributeSelectorDelegate<T> selector)
        public int Sum(Func<T,int> selector)
        {
            var result = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                var tItem = (T)_list[i];
                result += selector(tItem);
            }
            return result;
        }

        //public int Avg(IntAttributeSelectorDelegate<T> selector)
        public int Avg(Func<T,int> selector)
        {
            return Sum(selector)/_list.Count;
        }


        //public bool Any(FilterCriteriaDelegate<T> criteria)
        public bool Any(Predicate<T> criteria)
        {
            foreach (var item in _list)
            {
                var tItem = (T) item;
                if (criteria(tItem))
                    return true;
            }
            return false;
        }

        public bool All(Predicate<T> criteria)
        {
            foreach (var item in _list)
            {
                var tItem = (T)item;
                if (!criteria(tItem))
                    return false;
            }
            return true;
        }


    }
}