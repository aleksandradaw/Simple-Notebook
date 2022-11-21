namespace Application.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetAllCategories();
        CategoryDto GetById(int id);
        CategoryDto AddNewCategory(CreateCategoryDto newCategory);
        void Update(int id, UpdateCategoryDto updateCategory);
        void Delete(int id);
    
    }
}
