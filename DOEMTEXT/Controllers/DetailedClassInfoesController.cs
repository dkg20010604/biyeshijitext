using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DOEMTEXT.Context;
using DOEMTEXT.Models;
using AutoMapper;
using DOEMTEXT.DTO;
using DOEMTEXT.DTO.ModelsDTO;
using System.Linq.Expressions;
using static DOEMTEXT.DTO.ExpressionExtension<DOEMTEXT.Models.DetailedClassInfo>;

namespace DOEMTEXT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailedClassInfoesController : ControllerBase
    {
        private readonly StudentContext _context;
        private readonly IMapper _mapper;
        public DetailedClassInfoesController(StudentContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Page")]
        public async Task<PageInfomation<DetailedClassInfomation>> GetDetailedClassInfoesByPage(int _PageIndex)
        {
            var info = new PageInfomation<DetailedClassInfomation>()
            {
                PageIndex = _PageIndex,
                PageSize = 20
            };
            if(info.PageIndex == 0)
            {
                int total = _context.DetailedClassInfos.ToList().Count;
                var data = await _context.DetailedClassInfos.Include(p=>p.ClassNavigation).Include(p=>p.HeadmasterNavigation).Include(p=>p.InstructorNavigation).OrderBy(p => p.Id).Take(20).ToListAsync();
                return new PageInfomation<DetailedClassInfomation>()
                {
                    PageIndex = 1,
                    PageSize = 20,
                    DataTotal = total,
                    Data = _mapper.Map<List<DetailedClassInfomation>>(data)
                };
            }
            else
            {
                var data = await _context.DetailedClassInfos.OrderBy(p => p.Id).Skip((info.PageIndex - 1) * 20).Take(20).ToListAsync();
                info.Data = _mapper.Map<List<DetailedClassInfomation>>(data);
                return info;
            }
        }
        [HttpPost("Add")]
        public async Task<string> AddInfo(DetailedClassInfo? infomation)
        {
            var a = await _context.DetailedClassInfos.Where(p => p.ClassId == infomation.ClassId).ToListAsync();
            if (a.Count != 0)
            {
                return "已有数据";
            }
            try
            {
                await _context.DetailedClassInfos.AddAsync(infomation);
                _context.SaveChanges();
                return "成功";
            }
            catch (Exception)
            {

                throw;
            }
        }
        private bool DetailedClassInfoExists(int id)
        {
            return _context.DetailedClassInfos.Any(e => e.Id == id);
        }
    }
}
