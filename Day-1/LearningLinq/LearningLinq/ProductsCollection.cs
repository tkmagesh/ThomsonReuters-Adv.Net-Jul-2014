﻿using System.Collections;

namespace LearningLinq
{
    public class ProductsCollection
    {
        private ArrayList _list = new ArrayList();
        public void Add(Product product)
        {
            _list.Add(product);
        }

        public int Count
        {
            get { return _list.Count; }
        }

        public Product this[int index]
        {
            get { return _list[index] as Product; }
        }
        

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

        public void Sort(IProductComparer comparer)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var iProduct = (Product)_list[i];
                    var jProduct = (Product)_list[j];
                    if (comparer.Compare(iProduct, jProduct) > 0)
                    {
                        var temp = iProduct;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
            }
        }

        public void Sort(CompareProductDelegate compare)
        {
            for (int i = 0; i < _list.Count - 1; i++)
            {
                for (var j = i + 1; j < _list.Count; j++)
                {
                    var iProduct = (Product)_list[i];
                    var jProduct = (Product)_list[j];
                    if (compare(iProduct, jProduct) > 0)
                    {
                        var temp = iProduct;
                        _list[i] = _list[j];
                        _list[j] = temp;
                    }
                }
            }
        }


        public ProductsCollection Filter(IProductFilterCriteria criteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = item as Product;
                if (criteria.IsSatisfiedBy(product))
                    result.Add(product);
            }
            return result;
        }

        public ProductsCollection Filter(FilterCriteriaDelegate criteria)
        {
            var result = new ProductsCollection();
            foreach (var item in _list)
            {
                var product = item as Product;
                if (criteria(product))
                    result.Add(product);
            }
            return result;
        }

        public int Min(IntAttributeSelectorDelegate selector)
        {
            var result = int.MaxValue;
            for (var i = 0; i < _list.Count; i++)
            {
                var product = (Product) _list[i];
                var value = selector(product);
                if (value < result) result = value;
            }
            return result;
        }

        public int Sum(IntAttributeSelectorDelegate selector)
        {
            var result = 0;
            for (var i = 0; i < _list.Count; i++)
            {
                var product = (Product)_list[i];
                result += selector(product);
            }
            return result;
        }

        public int Avg(IntAttributeSelectorDelegate selector)
        {
            return Sum(selector)/_list.Count;
        }


        public bool Any(FilterCriteriaDelegate criteria)
        {
            foreach (var item in _list)
            {
                var product = (Product) item;
                if (criteria(product))
                    return true;
            }
            return false;
        }

        public bool All(FilterCriteriaDelegate criteria)
        {
            foreach (var item in _list)
            {
                var product = (Product)item;
                if (!criteria(product))
                    return false;
            }
            return true;
        }


    }
}