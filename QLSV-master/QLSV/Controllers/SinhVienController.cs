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
    public class SinhVienController : ControllerBase
    {
        QLSVDBContext _Context;
        public SinhVienController(QLSVDBContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var sinhViens = _Context.SinhVien.ToList();
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
        public IActionResult GetById([FromRoute] string Id)
        {
            try
            {
                var sinhVien = _Context.SinhVien.Where(x => x.MaSV == Id);
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
        public IActionResult Post([FromBody] MSinhVien request)
        {
            SinhVien sinhVien = new SinhVien();
         
            try
            {
                
                var checkMaSV = _Context.SinhVien.Find(request.MaSV);
                if (checkMaSV !=null)
                {
                     return Ok("trung mã");
                }
                else
                {
                    sinhVien.MaSV = request.MaSV;
                    sinhVien.TenSV = request.TenSV;
                    sinhVien.Email = request.Email;
                    sinhVien.Sdt = request.Sdt;
                    sinhVien.Diachi = request.Diachi;
                  
                    _Context.SinhVien.Add(sinhVien);
                    _Context.SaveChanges();
                    return CreatedAtAction(
                       nameof(GetAll),
                       new { maSV = sinhVien.MaSV }, sinhVien);
                }
              

                //   _Context.SaveChanges();

        
            }
            catch (Exception)
            {
                return StatusCode(500, "loi");
            }

        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] string Id, [FromBody] MSinhVien request)
        {
            try
            {
                var sinhVien = _Context.SinhVien.FirstOrDefault(x => x.MaSV == Id);
                if (sinhVien == null)
                {
                    return NoContent();
                }
                else
                {

                    sinhVien.TenSV = request.TenSV;
                    sinhVien.Email = request.Email;
                    sinhVien.Sdt = request.Sdt;
                    sinhVien.Diachi = request.Diachi;
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
        public IActionResult Delete([FromRoute] string Id)
        {
            try
            {
                var sinhVien = _Context.SinhVien.FirstOrDefault(x => x.MaSV == Id);
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
            var sinhViens = _Context.SinhVien.ToList();

            return Ok(sinhViens);
        }
    }
}

