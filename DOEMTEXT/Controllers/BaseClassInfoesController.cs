using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOEMTEXT.Context;
using DOEMTEXT.Models;
using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.DTO;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseClassInfoesController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;

        public BaseClassInfoesController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Page")]
        public async Task<PageInfomation<BaseClassInfomation>> GetBaseClassByPage([FromBody] PageInfomation<BaseClassInfomation> infomation)
        {
            if (infomation.PageIndex == 0)
            {
                var list = await _context.BaseClassInfos.OrderBy(p => p.ClassId).Take(20).ToListAsync();
                var total = await _context.BaseClassInfos.ToListAsync();
                return new PageInfomation<BaseClassInfomation>()
                {
                    PageIndex = 1,
                    PageSize = 20,
                    DataTotal = list.Count,
                    Data = _mapper.Map<List<BaseClassInfomation>>(list)
                };
            }
            else
            {
                var list = await _context.BaseClassInfos.OrderBy(p => p.ClassId).Skip((infomation.PageIndex - 1) * infomation.PageSize).Take(20).ToListAsync();
                infomation.Data = _mapper.Map<List<BaseClassInfomation>>(list);
                return infomation;
            }
        }
        [HttpPost]
        public async Task<bool> AddBaseClass([FromBody] BaseClassInfomation infomation)
        {
            if (_context.BaseClassInfos.Find(infomation.ClassId) == null)
            {
                BaseClassInfo baseClassInfo = new BaseClassInfo()
                {
                    ClassId = infomation.ClassId,
                    ClassName = infomation.ClassName,
                    CollegeId = infomation.CollegeId,
                    Status = true,
                };
                await _context.BaseClassInfos.AddAsync(baseClassInfo);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        [HttpPost("自定义查询")]
        public async Task<List<BaseClassInfomation>> Get(List<QueryEntity>? queryEntity,[FromServices] IMapper mapper)
        {
            var data = await _context.BaseClassInfos.Where(ExpressionExtension<BaseClassInfo>.ExpressionSplice(queryEntity)).ToListAsync();
            return mapper.Map<List<BaseClassInfomation>>(data);
        }
        private bool BaseClassInfoExists(string id)
        {
            return _context.BaseClassInfos.Any(e => e.ClassId == id);
        }
    }
}
