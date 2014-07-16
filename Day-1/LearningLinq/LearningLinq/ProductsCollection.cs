using System.Collections;

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

    }

    public delegate bool FilterCriteriaDelegate(Product product);
}