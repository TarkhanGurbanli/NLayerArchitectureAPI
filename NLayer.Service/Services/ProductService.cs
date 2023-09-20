using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositorys;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IGenericRepository<Product> repository, IProductRepository productRepository, IMapper mapper) : base(unitOfWork, repository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDTO>>> GetProductsWithCategory()
        {
            var product = await _productRepository.GetProductsWithCategory();

            var productDto = _mapper.Map<List<ProductWithCategoryDTO>>(product);

            return CustomResponseDTO<List<ProductWithCategoryDTO>>.Success(200, productDto);
        }
    }
}
