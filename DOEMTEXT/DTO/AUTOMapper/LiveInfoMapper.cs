using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;
namespace DOEMTEXT.DTO.AUTOMapper
{
    public class LiveInfoMapper : Profile
    {
        public LiveInfoMapper()
        {
            CreateMap<LiveInfo, LiveInfomation>()
                .ForMember(p => p.BuildId, option => option.MapFrom(src => src.Room.BuildId))
                .ForMember(p => p.Floor, option => option.MapFrom(src => src.Room.RoomNumber / 100))
                .ForMember(p => p.StudentName, option => option.MapFrom(src => src.StudentsInfo.StudentName))
                .ForMember(p => p.RoomNumber, option => option.MapFrom(src => src.Room.RoomNumber))
                .ForMember(p => p.CollgeName, option => option.MapFrom(src => src.StudentsInfo.College.CollegeName))
                .ForMember(p => p.ClassName, option => option.MapFrom(src => src.StudentsInfo.IdNavigation.ClassNavigation.ClassName+src.StudentsInfo.IdNavigation.Grade+src.StudentsInfo.IdNavigation.Class+src.StudentsInfo.IdNavigation.Nature+src.StudentsInfo.IdNavigation.Additional))
                .ForMember(p => p.Headmaster, option => option.MapFrom(src => src.StudentsInfo.IdNavigation.HeadmasterNavigation.AdminName))
                .ForMember(p => p.Instructor, option => option.MapFrom(src => src.StudentsInfo.IdNavigation.InstructorNavigation.AdminName));
        }
    }
}
