using Auction.BLL.DTO;
using Auction.BLL.Infrastructure;
using Auction.BLL.Interfaces;
using Auction.DAL.Entities;
using Auction.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace Auction.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork Database;

        public CategoryService(IUnitOfWork uow) => Database = uow;

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public IEnumerable<CategoryDTO> GetCategoriesByParentId(int? id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(Database.Categories.Find(c => c.ParentId == id));
        }

        public CategoryDTO FindCategoryById(int? id)
        {
            if (id == 0)
                throw new ValidationException("id", "");
            var category = Database.Categories.FindById(id.Value);
            if (category == null)
                throw new ValidationException("Category not found.", "");

            return new CategoryDTO { Id = category.Id, Name = category.Name, ParentId = category.ParentId };
        }

        public void CreateCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category { Name = categoryDTO.Name };

            if (categoryDTO.ParentId != null)
                category.ParentId = categoryDTO.ParentId;    

            Database.Categories.Create(category);
            Database.Save();
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            Category category = Database.Categories.FindById(categoryDTO.Id);

            if (category == null)
                throw new ValidationException("Category not found.", "");

            category = new Category { Name = categoryDTO.Name };

            if (categoryDTO.ParentId != null)
                category.ParentId = categoryDTO.ParentId;

            Database.Categories.Update(category);
            Database.Save();
        }

        public void DeleteCategory(CategoryDTO categoryDTO)
        {
            Category category = Database.Categories.FindById(categoryDTO.Id);

            if (category == null)
                throw new ValidationException("Category not found.", "");

            Database.Categories.Remove(category);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
