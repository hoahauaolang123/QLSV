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
    public class LopController : ControllerBase
    {
        QLSVDBContext _Context;
        public LopController(QLSVDBContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lops = _Context.Lop.ToList();
                if (lops.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(lops);
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
                var lop = _Context.Lop.Where(x => x.MaLop == Id);
                if (lop == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(lop);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpGet("/thongtinhoc/{Id}")]
        public IActionResult GetThongTinHoc([FromRoute] string Id)
        {
            var lists = from a in _Context.Lop
                        join b in _Context.TKBGV on a.MaLop equals b.MaLop
                        where a.MaLop == Id
                        orderby b.TimeDay descending
                        select new
                        {
                            tenlop = a.TenLop,
                            MonHoc = b.MonHoc,
                            TimeHoc = b.TimeDay
                        };
            return Ok(lists);
        }
        [HttpPost]
        public IActionResult Post([FromBody] MLop request)
        {
            Lop lop = new Lop();
            //  giaoVien.IdGV = request.IdGV;
            lop.MaLop = request.MaLop;
            lop.TenLop = request.TenLop;
          
            try
            {

                _Context.Lop.Add(lop);
                _Context.SaveChanges();


                //   _Context.SaveChanges();

                return CreatedAtAction(
           nameof(GetAll),
           new { id = lop.MaLop }, lop);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }

        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] string Id, [FromBody] MLop request)
        {
            try
            {
                var lop = _Context.Lop.Find(Id);
                if (lop == null)
                {
                    return NoContent();
                }
                else
                {
                    lop.MaLop = request.MaLop; 
                    lop.TenLop = request.TenLop;

                    _Context.SaveChanges();
                    return Ok(lop);
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
                var lop = _Context.Lop.FirstOrDefault(x => x.MaLop == Id);
                if (lop == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(lop).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var lops = _Context.Lop.ToList();

            return Ok();
        }
    }
}
