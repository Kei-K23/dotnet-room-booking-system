using AutoMapper;
using RoomBookAPI.Models;
using RoomBookAPI.Dto;

namespace RoomBookAPI.Mapping
{
    public class AuthMapping : Profile
    {
        public AuthMapping()
        {
            CreateMap<RegisterDto, User>();
        }
    }
}