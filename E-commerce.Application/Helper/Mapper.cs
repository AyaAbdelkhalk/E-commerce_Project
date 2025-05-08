using E_commerce.Application.DTOs.Order;
using E_commerce.Application.DTOs.Product;
using E_commerce.Application.DTOs.User;
using E_commerce.Core.Enum;
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

            #region Order Mapping 

            TypeAdapterConfig<Order, OrderDisDto>
                .NewConfig()
                // .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDate, src => src.OrderDate)
                .Map(dest => dest.TotalAmount, src => src.TotalAmount)
                .Map(dest => dest.Status, src => src.Status.ToString()) // Enum to string
                .Map(dest => dest.DateProcessed, src => src.DateProcessed)
                .Map(dest => dest.OrderDetails, src => src.OrderDetails);

            TypeAdapterConfig<OrderDetail, OrderDetailDto>
                .NewConfig()
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.ProductName, src => src.Product.Name) // navigation property
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.Quantity, src => src.Quantity);

            TypeAdapterConfig<CreateOrderDto, Order>
                .NewConfig()
                // .Map(dest => dest.UserID, src => src.UserID)
                .Map(dest => dest.OrderDetails, src => src.Items);

            TypeAdapterConfig<CreateOrderDetailDto, OrderDetail>
                .NewConfig()
                .Map(dest => dest.ProductID, src => src.ProductID)
                .Map(dest => dest.Quantity, src => src.Quantity);

            TypeAdapterConfig < UpdateOrderStatusDto, Order>
                 .NewConfig()
                 .Map(dest => dest.Status, src => Enum.Parse<Status>(src.NewStatus))
                 .Map(dest => dest.DateProcessed, src => src.DateProcessed);

            #endregion

        }

    }
}
