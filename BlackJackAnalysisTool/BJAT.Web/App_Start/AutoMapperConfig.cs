using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AutoMapper;
using BJAT.Data.Entities;
using BJAT.Web.Models;

namespace BJAT.Web
{
    public class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<User, UserRegisterModel>()
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
                    .ForMember(dest => dest.ReenterPassword, opt => opt.Ignore());

                config.CreateMap<UserRegisterModel, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));
            });
        }
    }
}