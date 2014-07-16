namespace LearningLinq
{
    /*
    public interface IProductFilterCriteria
    {
        bool IsSatisfiedBy(Product product);
    }
     * */

    public interface IItemFilterCriteria<T>
    {
        bool IsSatisfiedBy(T item);
    }
}