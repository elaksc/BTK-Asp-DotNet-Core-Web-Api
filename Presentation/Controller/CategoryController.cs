using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _serviceManager.CategoryService.GetAllCategoriesAsync(false));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneCategoryByIdAsync(int id)
        {
            return Ok(await _serviceManager.CategoryService.GetOneCategoryByIdAsync(id, false));
        }



    }
}
