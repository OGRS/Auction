using Auction.BLL.DTO;
using Auction.BLL.Interfaces;
using Auction.PL.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Auction.PL.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService serv)
            => categoryService = serv;

        [HttpGet]
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult GetCategories(int? id = null)
        {
            IEnumerable<CategoryDTO> categoryDTOs = categoryService.GetCategoriesByParentId(id);
            if (categoryDTOs == null)
                return NotFound();

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryModel>()).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<CategoryModel>>(categoryDTOs);

            return Ok(categories);
        }

        [HttpPost]
        public IHttpActionResult CreateCetegory([FromBody]CategoryModel category)
        {
            var categoryDTO = new CategoryDTO { Name = category.Name, ParentId = category.ParentId };
            categoryService.CreateCategory(categoryDTO);
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, [FromBody]CategoryModel category)
        {
            if (id == category.Id)
            {
                var categoryDTO = new CategoryDTO { Name = category.Name, ParentId = category.ParentId };
                categoryService.UpdateCategory(categoryDTO);
                return Ok();
            }
            return BadRequest();   
        }

        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var categoryDTO = categoryService.FindCategoryById(id);
            if (categoryDTO == null)
                return NotFound();

            categoryService.DeleteCategory(categoryDTO);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            categoryService.Dispose();
            base.Dispose(disposing);
        }
    }
}
