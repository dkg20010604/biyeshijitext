using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;

namespace DOEMTEXT.DTO.AUTOMapper
{
    public class DetailedClassInfoMapper : Profile
    {
        public DetailedClassInfoMapper()
        {
            CreateMap<DetailedClassInfo, DetailedClassInfomation>()
                .ForMember(p => p.ClassName, option => option.MapFrom(src => src.ClassNavigation.ClassName +
                src.Grade.ToString() +
                "0" + src.Class.ToString() +
                src.Nature +
                src.Additional))
                .ForMember(p => p.Headmaster, option => option.MapFrom(src => src.HeadmasterNavigation.AdminName))
                .ForMember(p => p.Instructor, option => option.MapFrom(src => src.InstructorNavigation.AdminName));
        }
    }
}
