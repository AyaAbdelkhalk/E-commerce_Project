using Autofac;
using E_commerce.Application.DTOs.ProductDTOs;
using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Core.Models;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = AppAutoFac.Inject();

            var userservices = container.Resolve<IUserServices>();



            //#region Test Add
            //AddUserDTO addUserDTO = new AddUserDTO();
            //addUserDTO.FirstName = "John";
            //addUserDTO.LastName = "Doe";
            //addUserDTO.UserName = "johndoe325";
            //addUserDTO.Email = "aya143@gmail.com";
            //addUserDTO.Password = "Password123";
            //addUserDTO.PasswordConfirmed = "Password123";

            //userservices.AddNewUser(addUserDTO).ContinueWith(task =>
            //{
            //    if (task.Result.Succeeded)
            //    {
            //        Console.WriteLine("User added successfully.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Failed to add user: " + string.Join(", ", task.Result.Errors));
            //    }
            //}).Wait();
            //#endregion

            var productServices = container.Resolve<IProductServices>();

            #region Test Add Product

            var category = new Category
            {
                Name = "Electronics", // اختر اسم الفئة
                Description = "All kinds of electronic products"
            };


            CreateProductDto createProductDto = new CreateProductDto
            {
                Name = "New Product",
                Description = "This is a test product",
                Price = 99.99m,
                CategoryID = 1 // Assuming this category exists
            };

            string imagePath = @"D:\github\Testing\ImagesTest\camera.jpeg";

            productServices.AddProductAsync(createProductDto, imagePath).ContinueWith(task =>
            {
                if (task.Result.Succeeded)
                {
                    Console.WriteLine("Product added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add product: " + string.Join(", ", task.Result.Errors));
                }
            }).Wait();
            #endregion


        }
    }
}
