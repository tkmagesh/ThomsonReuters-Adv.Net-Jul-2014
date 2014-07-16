namespace LearningLinq
{
    public interface IProductFilterCriteria
    {
        bool IsSatisfiedBy(Product product);
    }
}