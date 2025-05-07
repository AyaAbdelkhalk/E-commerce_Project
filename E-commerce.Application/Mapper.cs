using E_commerce.Application.DTOs.UserDTOs;
using E_commerce.Core.Models;
using Mapster;

namespace E_commerce.Application
{
    public class Mapper
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



        }
    }
}
