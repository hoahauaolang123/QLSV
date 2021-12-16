using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiaoVienController : ControllerBase
    {
        QLSVDBContext _Context;
        public GiaoVienController(QLSVDBContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var giaoViens = _Context.GiaoVien.ToList();
                if (giaoViens.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(giaoViens);
                }
               
            }
            catch (Exception)
            {
                return NoContent();
            }            
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] string Id)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.Where(x => x.MaGV == Id);
                if(giaoVien == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(giaoVien);
                }
                
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpGet("/thongtingiaoviendaymon/{Id}")]
        public IActionResult GetThongTinGiaoVienDayMon([FromRoute] string Id)
        {
            try
            {

                var giaoVien = from a in _Context.GiaoVien
                               join b in _Context.TKBGV on a.MaGV equals b.MaGV
                               where a.MaGV == Id
                               orderby b.TimeDay descending
                               select new
                               {
                                   TenGV = a.TenGV,
                                   MonDay = b.MonHoc,
                                   TimeDay = b.TimeDay,                              
                               };
                return Ok(giaoVien);
                               
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MGiaoVien request)
        {
            GiaoVien giaoVien = new GiaoVien();
          //  giaoVien.IdGV = request.IdGV;
            
            try
            {
                var checkMaGV = _Context.GiaoVien.Find(request.MaGV);
                if(checkMaGV != null)
                {
                    return Ok("trùng mã");
                }
                else
                {
                    giaoVien.MaGV = request.MaGV;
                    giaoVien.TenGV = request.TenGV;
                    _Context.GiaoVien.Add(giaoVien);
                    _Context.SaveChanges();
                    return CreatedAtAction(
               nameof(GetAll),
               new { maGV = giaoVien.MaGV }, giaoVien);
                }
            }
           
            catch(Exception)
            {
                return StatusCode(500, "loi");
            }
          
        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] string Id, [FromBody] MGiaoVien request)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.FirstOrDefault(x => x.MaGV == Id);
                if (giaoVien == null)
                {
                    return NoContent();
                }
                else
                {
                    giaoVien.MaGV=request.MaGV; ;
                    giaoVien.TenGV=request.TenGV;
                    _Context.SaveChanges();
                    return Ok(giaoVien);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete([FromRoute] string Id)
        {
            try
            {
                var giaoVien = _Context.GiaoVien.FirstOrDefault(x => x.MaGV == Id);
                if (giaoVien == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(giaoVien).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var giaoViens= _Context.GiaoVien.ToList();

            return Ok(giaoViens);
        }
    }
   
}
