using AutoMapper;
using DBStuff.Dto;
using DBStuff.Models;

namespace DBStuff.Profiles
{
    public class RecordProfile : Profile
    {
        public RecordProfile()
        {
            CreateMap<Record, RecordReadDTO>();
        }
    }
}