using System.Security.Cryptography.X509Certificates;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
        public CategoryDto AddNewCategory(CreateCategoryDto newCategory)
        {
            if (string.IsNullOrEmpty(newCategory.Name))
            {
                throw new Exception("Name is empty");
            }
            var categoryWithTheSameName =_categoryRepository.GetAll()
                .Where(x => x.Name.ToLower() == newCategory.Name.ToLower());    
            if (categoryWithTheSameName != null) 
            {
                throw new Exception("Category already exsist!");
            }
            var category = _mapper.Map<Category>(newCategory);
            _categoryRepository.Add(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public void Delete(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Delate(category);
        }

        public CategoryDto GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public void Update(int id, UpdateCategoryDto updateCategory)
        {
            if (string.IsNullOrEmpty(updateCategory.Name))
            {
                throw new Exception("Name is empty");
            }

            var categoryWithTheSameName = _categoryRepository.GetAll()
             .Where(x => x.Name.ToLower() == updateCategory.Name.ToLower());
            if (categoryWithTheSameName != null)
            {
                throw new Exception("Category already exsist!");
            }
            var oldCategory = _categoryRepository.GetById(id);
            var newCategory = _mapper.Map(updateCategory, oldCategory);
            _categoryRepository.Update(newCategory);
        }
    }
}