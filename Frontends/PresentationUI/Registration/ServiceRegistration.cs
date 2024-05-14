﻿using BusinessLayer.Basket;
using BusinessLayer.Catalog.BannerServices;
using BusinessLayer.Catalog.CategoryServices;
using BusinessLayer.Catalog.ProductDetailServices;
using BusinessLayer.Catalog.ProductImageService;
using BusinessLayer.Catalog.ProductServices;
using BusinessLayer.Catalog.SliderServices;
using BusinessLayer.Comment.CommentServices;
using BusinessLayer.Discount.DiscountServices;
using PresentationUI.Abstract;
using PresentationUI.Concrete;
using PresentationUI.Handlers;
using PresentationUI.Services.Abstract;
using PresentationUI.Services.Concrete;
using PresentationUI.Settings;

namespace PresentationUI.Registration
{
    public static class ServiceRegistration
    {
        public static void ApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
            services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

            var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

            services.AddHttpClient<IUserService, UserService>(options =>
            {
                options.BaseAddress = new Uri(values.IdentityApi);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Discount.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ISliderService, SliderService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBannerService, BannerService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductDetailService, ProductDetailService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductImageService, ProductImageService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ICommentService, CommentService>(options =>
            {
                options.BaseAddress = new Uri($"{values.OcelotApi}/{values.Comment.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
        }
    }
}