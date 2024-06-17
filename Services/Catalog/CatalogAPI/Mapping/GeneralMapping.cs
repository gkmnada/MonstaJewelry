using AutoMapper;
using CatalogAPI.Dtos.BannerDto;
using CatalogAPI.Dtos.CategoryDto;
using CatalogAPI.Dtos.ExclusiveSelectionsDto;
using CatalogAPI.Dtos.FooterDto;
using CatalogAPI.Dtos.ProductDetailDto;
using CatalogAPI.Dtos.ProductDto;
using CatalogAPI.Dtos.ProductImageDto;
using CatalogAPI.Dtos.SliderDto;
using CatalogAPI.Entities;

namespace CatalogAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ReverseMap();
            CreateMap<Product, CreateProductWithDetailDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageDto>().ReverseMap();

            CreateMap<Slider, ResultSliderDto>().ReverseMap();
            CreateMap<Slider, CreateSliderDto>().ReverseMap();
            CreateMap<Slider, UpdateSliderDto>().ReverseMap();
            CreateMap<Slider, GetSliderDto>().ReverseMap();

            CreateMap<Banner, ResultBannerDto>().ReverseMap();
            CreateMap<Banner, CreateBannerDto>().ReverseMap();
            CreateMap<Banner, UpdateBannerDto>().ReverseMap();
            CreateMap<Banner, GetBannerDto>().ReverseMap();
            CreateMap<Banner, ResultBannerWithCategoryDto>().ReverseMap();

            CreateMap<ExclusiveSelections, ResultExclusiveSelectionsDto>().ReverseMap();
            CreateMap<ExclusiveSelections, CreateExclusiveSelectionsDto>().ReverseMap();
            CreateMap<ExclusiveSelections, UpdateExclusiveSelectionsDto>().ReverseMap();
            CreateMap<ExclusiveSelections, GetExclusiveSelectionsDto>().ReverseMap();

            CreateMap<Footer, ResultFooterDto>().ReverseMap();
            CreateMap<Footer, CreateFooterDto>().ReverseMap();
            CreateMap<Footer, UpdateFooterDto>().ReverseMap();
            CreateMap<Footer, GetFooterDto>().ReverseMap();
            CreateMap<Footer, ResultFooterWithCategoryDto>().ReverseMap();
        }
    }
}
