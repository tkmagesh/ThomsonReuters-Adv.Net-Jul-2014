using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LearningLinq
{
    public class MyCollection<T> :IEnumerable<T>, IEnumerator<T>
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


        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        private int _index = -1;
        public T Current
        {
            get { return (T) _list[_index]; }
        }

        public void Dispose()
        {
            _index = -1;
        }

        object IEnumerator.Current
        {
            get
            {

                return (T)_list[_index];
            }
        }

        public bool MoveNext()
        {
            _index++;
            if (_index >= _list.Count)
            {
                Reset();
                return false;
            }
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }
    }

    
}