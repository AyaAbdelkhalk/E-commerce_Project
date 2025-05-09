using Autofac;
using E_commerce.Application.DTOs.Category;
using E_commerce.Application.DTOs.Product;
using E_commerce.Application.DTOs.User;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;
using E_commerce.Application.Services.ProductServices;
using E_commerce.Application.Services.UserServices;
using E_commerce.Core.Models;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = AppAutoFac.Inject();

            var userservices = container.Resolve<IUserServices>();



            #region Test Add
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
            #endregion

            #region Test Add Category
            var categoryServices = container.Resolve<ICategoryServices>();
            CreateCategoryDto createCategoryDto = new CreateCategoryDto
            {
                Name = "ashtota",
                Description = "ashtota helwa thoghantota"
            };

            categoryServices.AddCategoryAsync(createCategoryDto).ContinueWith(task =>
            {
                if (task.Result.Succeeded)
                {
                    Console.WriteLine("Category added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add category: " + string.Join(", ", task.Result.Errors));
                }
            }).Wait();

            #endregion


            #region Test Add Product

            var productServices = container.Resolve<IProductServices>();



            CreateProductDto createProductDto = new CreateProductDto
            {
                Name = "New Product",
                Description = "This is a test product",
                Price = 99.99m,
                CategoryID = 3
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


            #region Test Login
            //LoginDTO loginDTO = new LoginDTO();
            //loginDTO.UserName = "johndoe325";
            //loginDTO.Password = "Password123";
            //userservices.Login(loginDTO).ContinueWith(task =>
            //{
            //    if (task.Result.Succeeded)
            //    {
            //        Console.WriteLine("Login successful.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Login failed: " + string.Join(", ", task.Result.Errors));
            //    }
            //}).Wait();
            #endregion



        }
    }
}
