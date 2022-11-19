using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;

namespace DOEMTEXT.DTO.AUTOMapper
{
    public class CollegeMapper : Profile
    {
        public CollegeMapper()
        {
            CreateMap<CollegeInfo,CollegeInfomation>();
        }
    }
}
