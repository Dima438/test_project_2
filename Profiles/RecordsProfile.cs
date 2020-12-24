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
            CreateMap<RecordCreateDTO, Record>();
            CreateMap<RecordUpdateDTO, Record>();
            CreateMap<Record, RecordUpdateDTO>();
        }
    }
}