using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.Models;

namespace DOEMTEXT.DTO.AUTOMapper
{
    public class BaseClassInfoMapper : Profile
    {
        public BaseClassInfoMapper()
        {
            CreateMap<BaseClassInfo, BaseClassInfomation>();
        }
    }
}
