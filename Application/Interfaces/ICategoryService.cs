using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
