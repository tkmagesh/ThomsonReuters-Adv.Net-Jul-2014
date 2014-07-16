namespace LearningLinq
{
    public class ProductComparerByUnit : IItemComparer<Product>
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Units < p2.Units) return -1;
            if (p1.Units > p2.Units) return 1;
            return 0;
        }
    }
}