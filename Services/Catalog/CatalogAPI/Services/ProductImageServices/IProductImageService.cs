﻿using CatalogAPI.Dtos.ProductImageDto;

namespace CatalogAPI.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> ListProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetProductImageDto> GetProductImageAsync(string id);
        Task<GetProductImageDto> GetProductImageWithProductAsync(string id);
    }
}
