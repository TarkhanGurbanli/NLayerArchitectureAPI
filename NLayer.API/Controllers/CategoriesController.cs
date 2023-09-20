using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoriesController(IMapper mapper, ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProducts(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categoires = await _categoryService.GetAllAsync();

            var categoryDtos = _mapper.Map<List<CategoryDTO>>(categoires.ToList());

            return CreateActionResult<List<CategoryDTO>>(CustomResponseDTO<List<CategoryDTO>>.Success(200, categoryDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return CreateActionResult(CustomResponseDTO<CategoryDTO>.Success(200, categoryDTO));
        }


        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));

            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return CreateActionResult(CustomResponseDTO<CategoryDTO>.Success(201, categoryDTO));
        }


        [HttpPut]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDTO));

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            await _categoryService.RemoveAsync(category);

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
    }
}
