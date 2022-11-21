

namespace Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAll();
        Category Add(Category category);
        Category GetById(int id);
        void Update(Category category);
        void Delate(Category category);
    }
}
