using AutoMapper;
using Viacep.Application.Models;
using Viacep.Domain.Entities;

namespace Viacep.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserCredentials>();
        }
    }
}
