using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;

namespace DOEMTEXT.DTO.AUTOMapper
{
    public class StudentMapper : Profile
    {
        public StudentMapper()
        {
            CreateMap<StudentsInfo, ModelsDTO.StudentsInformation>()
                .ForMember(p => p.Headmaster, option => option.MapFrom(src => src.IdNavigation.HeadmasterNavigation.AdminName))
                .ForMember(p => p.Instructor, option => option.MapFrom(src => src.IdNavigation.InstructorNavigation.AdminName))
                .ForMember(p => p.CollegeName, option => option.MapFrom(src => src.College.CollegeName))
                .ForMember(p => p.ClassName, option => option.MapFrom(src => src.IdNavigation.ClassNavigation.ClassName + src.IdNavigation.Grade + src.IdNavigation.Class + src.IdNavigation.Additional));
        }
    }
}
