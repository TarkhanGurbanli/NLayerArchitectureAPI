using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        //Get api/products/GetProductsWithCategory

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();

            var productsDTOs = _mapper.Map<List<ProductDTO>>(products.ToList());

            return CreateActionResult<List<ProductDTO>>(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDTOs));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productDTO));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));

            var productDTO = _mapper.Map<ProductDTO>(product);

            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productDTO));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productUpdateDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productUpdateDto));

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var products = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(products);

            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
    }
}
