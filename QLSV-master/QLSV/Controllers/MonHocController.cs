using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV.Data;
using QLSV.Model;
using System;
using System.Linq;

namespace QLSV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        QLSVDBContext _Context;
        public MonHocController(QLSVDBContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var monHocs = _Context.MonHoc.ToList();
                if (monHocs.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(monHocs);
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
                var monHoc = _Context.MonHoc.Where(x => x.MaMH == Id);
                if (monHoc == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(monHoc);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MMonHoc request)
        {
            MonHoc monHoc = new MonHoc();
            //  giaoVien.IdGV = request.IdGV;
           monHoc.MaMH = request.MaMH;
           monHoc.TenMH = request.TenMH;
            try
            {

                _Context.MonHoc.Add(monHoc);
                _Context.SaveChanges();


                //   _Context.SaveChanges();

                return CreatedAtAction(
           nameof(GetAll),
           new { id = monHoc.MaMH }, monHoc);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }

        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] string Id, [FromBody] MMonHoc request)
        {
            try
            {
                var monHoc = _Context.MonHoc.Find(Id);
                if (monHoc == null)
                {
                    return NoContent();
                }
                else
                {
                    monHoc.MaMH = request.MaMH; ;
                    monHoc.TenMH = request.TenMH;
            
                    _Context.SaveChanges();
                    return Ok(monHoc);
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
                var monHoc = _Context.MonHoc.FirstOrDefault(x => x.MaMH == Id);
                if (monHoc == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(monHoc).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var giaoViens = _Context.MonHoc.ToList();

            return Ok(giaoViens);
        }
    }
}
