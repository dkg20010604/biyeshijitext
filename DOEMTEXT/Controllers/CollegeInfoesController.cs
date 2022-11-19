using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOEMTEXT.Context;
using DOEMTEXT.Models;
using AutoMapper;
using DOEMTEXT.DTO.ModelsDTO;
using DOEMTEXT.DTO.APIHelp;
using System.Collections.Generic;
using System.Linq;
using static DOEMTEXT.DTO.ExpressionExtension<DOEMTEXT.Models.CollegeInfo>;
using DOEMTEXT.DTO;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeInfoesController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _IMapper;
        public CollegeInfoesController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _IMapper = mapper;
        }
        //[HttpPost]
        //public async Task<APIHelp<CollegeInfomation>> AddCollege([FromBody] CollegeInfomation infomation)
        //{
        //    if (_context.CollegeInfos.Find(infomation.CollegeId) != null)
        //        return new APIHelp<CollegeInfomation>()
        //        {
        //            code = 400,
        //            Messege = "主键重复",
        //            Data = _IMapper.Map<CollegeInfomation>(_context.CollegeInfos.Find(infomation.CollegeId)) 
        //        };
        //    await _context.CollegeInfos.AddAsync(new CollegeInfo()
        //    {
        //        CollegeId = infomation.CollegeId,
        //        CollegeName = infomation.CollegeName,
        //    });
        //    try
        //    {
        //        _context.SaveChanges();
        //    }
        //    catch
        //    {
        //        return new APIHelp<CollegeInfomation>()
        //        {
        //            code = 400,
        //            Messege = "未知错误"
        //        };
        //    }
        //    return new APIHelp<CollegeInfomation>()
        //    {
        //        code = 200,
        //        Messege = "成功添加",
        //        Data = infomation
        //    };
        //}
        // GET: api/CollegeInfoes
        [HttpGet]
        public async Task<List<CollegeInfomation>> GetCollegeInfos()
        {
            var list = await _context.CollegeInfos.ToListAsync();
            var collegelist = _IMapper.Map<List<CollegeInfomation>>(list);
            return collegelist;
        }

        [HttpPost]
        public async Task<List<CollegeInfomation>> GetCollegeInfos([FromServices] IMapper mapper,List<QueryEntity>? queryEntities)
        {
            var a = ExpressionSplice(queryEntities);
            var data = await _context.CollegeInfos.Where(a).ToListAsync();
            return mapper.Map<List<CollegeInfomation>>(data);
        }


        // DELETE: api/CollegeInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollegeInfo(string id)
        {
            var collegeInfo = await _context.CollegeInfos.FindAsync(id);
            if (collegeInfo == null)
            {
                return NotFound();
            }

            _context.CollegeInfos.Remove(collegeInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
