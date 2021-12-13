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
    public class ThongTinSinhVienController : ControllerBase
    {
        QLSVDBContext _Context;
        public ThongTinSinhVienController( QLSVDBContext Context)

        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var sinhViens = _Context.ThongTinSinhVien.ToList();
                if (sinhViens.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(sinhViens);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpGet("{Id}")]
        public IActionResult GetById([FromRoute] int Id)
        {
            try
            {
                var sinhVien = _Context.ThongTinSinhVien.Where(x => x.Id == Id);
                if (sinhVien == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(sinhVien);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] MThongTinSinhVien request)
        {
            ThongTinSinhVien sinhVien = new ThongTinSinhVien();
            sinhVien.MaSV = request.MaSV;
            sinhVien.MaLop = request.MaLop;
            sinhVien.TenLop = request.TenLop;
            sinhVien.Email = request.Email;
            sinhVien.Sdt = request.Sdt;
            sinhVien.Diachi= request.DiaChi;
            try
            {

                _Context.ThongTinSinhVien.Add(sinhVien);
                _Context.SaveChanges();
                return CreatedAtAction(
           nameof(GetAll),
           new { id = sinhVien.Id }, sinhVien);
            }
            catch (Exception)
            {
                return StatusCode(500, "loi");
            }

        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] MThongTinSinhVien request)
        {
            try
            {
                var sinhVien = _Context.ThongTinSinhVien.FirstOrDefault(x => x.Id == Id);
                if (sinhVien == null)
                {
                    return NoContent();
                }
                else
                {
                    sinhVien.MaSV = request.MaSV;
                    sinhVien.MaLop = request.MaLop;
                    sinhVien.TenLop = request.TenLop;
                    sinhVien.Email = request.Email;
                    sinhVien.Sdt = request.Sdt;
                    sinhVien.Diachi = request.DiaChi;
                    _Context.SaveChanges();
                    return Ok(sinhVien);
                }

            }
            catch (Exception)
            {
                return NoContent();
            }
        }
        [HttpDelete("Delete/{Id}")]
        public IActionResult Delete([FromRoute] int Id)
        {
            try
            {
                var sinhVien = _Context.ThongTinSinhVien.FirstOrDefault(x => x.Id == Id);
                if (sinhVien == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(sinhVien).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var sinhViens = _Context.ThongTinSinhVien.ToList();

            return Ok(sinhViens);
        }
    }
}

