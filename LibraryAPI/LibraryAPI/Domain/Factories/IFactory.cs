namespace LibraryAPI.Domain.Factories
{
    public interface IFactory<T>
    {
        T Create();
    }
}
