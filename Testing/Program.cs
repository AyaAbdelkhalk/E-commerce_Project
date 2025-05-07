using Autofac;
using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Application.Interfaces;
using E_commerce.Application.Services;

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


        }
    }
}
