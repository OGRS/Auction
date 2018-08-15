using Auction.BLL.DTO;
using System.Collections.Generic;

namespace Auction.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetCategories();
        IEnumerable<CategoryDTO> GetCategoriesByParentId(int? id);
        CategoryDTO FindCategoryById(int? id);
        void CreateCategory(CategoryDTO category);
        void DeleteCategory(CategoryDTO category);
        void UpdateCategory(CategoryDTO category);
        void Dispose();
    }
}
