using Business.Abstract;
using Core.Utilities.Extensions;
using Core.Utilities.Results.ComplexTypes;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _categoryService.GetAll();

            return View(result.Data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_CategoryAddPartial");
        }
        
        [HttpPost]
        public async IActionResult Add(CategoryAddDto categoryAddDto)
        {
            var categoryAjaxModel = new CategoryAddAjaxViewModel
            {
                CategoryAddPartial = await this.RenderViewToStringAsync("_CategoryAddPartial", categoryAddDto),

            };

        }
    }
}
