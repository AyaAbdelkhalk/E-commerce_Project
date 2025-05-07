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



        }
    }
}
