namespace LearningLinq
{
    public class ProductCompareByCost : IProductComparer
    {
        public int Compare(Product p1, Product p2)
        {
            if (p1.Cost < p2.Cost) return -1;
            if (p1.Cost > p2.Cost) return 1;
            return 0;
        }
    }
}