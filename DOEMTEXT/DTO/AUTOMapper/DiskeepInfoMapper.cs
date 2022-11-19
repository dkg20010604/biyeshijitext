using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;

namespace DOEMTEXT.DTO.AUTOMapper
{
    public class DiskeepInfoMapper : Profile
    {
        public DiskeepInfoMapper()
        {
            CreateMap<Diskeep, DiskeepInformation>()
                .ForMember(p => p.StudentName, option => option.MapFrom(src => src.Student.StudentName))
                .ForMember(p => p.CollegeName, option => option.MapFrom(src => src.Student.College.CollegeName))
                .ForMember(p => p.ClassName, option => option.MapFrom(src => src.Student.IdNavigation.ClassNavigation.ClassName
                + src.Student.IdNavigation.Grade.ToString()
                + "0" + src.Student.IdNavigation.Class.ToString()
                + src.Student.IdNavigation.Nature.ToString()
                + src.Student.IdNavigation.Additional));
        }
    }
}
