using E_commerce.Application.DTOs.ProductDTOs;
using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Helper
{

    public static class Mapper
    {
        public static void RegisterMapsterConfiguration()
        {
            //<source, destination>
            #region User Mapping
            TypeAdapterConfig<AddUserDTO, User>
                    .NewConfig()
                    .Map(dest => dest.Password, src => src.Password);

            TypeAdapterConfig<User, UserDetails>
                .NewConfig();

            #endregion

            #region Product Mapping
            TypeAdapterConfig<CreateProductDto, Product>
            .NewConfig()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Price, src => src.Price)
            .Map(dest => dest.UnitsInStock, src => src.UnitsInStock)
            .Map(dest => dest.CategoryID, src => src.CategoryID)
            .Map(dest => dest.ImagePath, src => src.ImagePath);

                    // Product → ProductListDto
                    TypeAdapterConfig<Product, ProductListDto>
                        .NewConfig()
                        .Map(dest => dest.CategoryName, src => src.Category.Name);

                    // Product → ProductDetailsDto
                    TypeAdapterConfig<Product, ProductDetailsDto>
                        .NewConfig()
                        .Map(dest => dest.CategoryName, src => src.Category.Name);

                    // UpdateProductDto → Product
                    TypeAdapterConfig<UpdateProductDto, Product>
                        .NewConfig();

            #endregion

        }

    }
}
