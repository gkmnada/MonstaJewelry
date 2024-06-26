﻿using CatalogAPI.Dtos.StatisticDto;

namespace CatalogAPI.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCountAsync();
        Task<long> GetProductCountAsync();
        Task<List<GetProductCountByCategoryDto>> GetProductCountByCategoryAsync();
    }
}
