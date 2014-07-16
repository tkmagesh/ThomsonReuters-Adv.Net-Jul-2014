namespace LearningLinq
{
    public class CostlyProductCriteria : IProductFilterCriteria
    {
        private int _baseCost;

        public CostlyProductCriteria(int baseCost)
        {
            _baseCost = baseCost;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Cost > _baseCost;
        }
    }
}