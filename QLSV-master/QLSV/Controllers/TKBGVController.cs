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
    public class TKBGVController : ControllerBase
    {
        QLSVDBContext _Context;
        public TKBGVController(QLSVDBContext Context)

        {
            _Context = Context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var sinhViens = _Context.TKBGV.ToList();
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
                var sinhVien = _Context.TKBGV.Where(x => x.Id == Id);
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
        public IActionResult Post([FromBody] MTKBGV request)
        {
            TKBGV tKBGV = new TKBGV();
          
            try
            {
                tKBGV.MaGV = request.MaGV;
                tKBGV.MaLop = request.MaLop;
                tKBGV.MaMH= request.MaMH;
                tKBGV.TenGV = request.TenGV;
                tKBGV.TenLop = request.TenLop;
                tKBGV.TenMH =request.TenMH;
                tKBGV.TimeDay = request.TimeDay;

                _Context.TKBGV.Add(tKBGV);
                _Context.SaveChanges();
                return CreatedAtAction(
           nameof(GetAll),
           new { id = tKBGV.Id }, tKBGV);
            }
            catch (Exception)
            {
                return StatusCode(500, "loi");
            }

        }
        [HttpPut("{Id}")]
        public IActionResult Update([FromRoute] int Id, [FromBody] MTKBGV request)
        {
            try
            {
                var tKBGV = _Context.TKBGV.FirstOrDefault(x => x.Id == Id);
                if (tKBGV == null)
                {
                    return NoContent();
                }
                else
                {
                    tKBGV.MaGV = request.MaGV;
                    tKBGV.MaLop = request.MaLop;
                    tKBGV.MaMH = request.MaMH;
                    tKBGV.TenGV = request.TenGV;
                    tKBGV.TenLop = request.TenLop;
                    tKBGV.TenMH = request.TenMH;
                    tKBGV.TimeDay = request.TimeDay;

                    _Context.SaveChanges();
                    return Ok(tKBGV);
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
                var tKBGV = _Context.TKBGV.FirstOrDefault(x => x.Id == Id);
                if (tKBGV == null)
                {

                    return StatusCode(StatusCodes.Status404NotFound);
                }
                _Context.Entry(tKBGV).State = EntityState.Deleted;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "loi");
            }
            var tKBGVs = _Context.TKBGV.ToList();

            return Ok(tKBGVs);
        }
    }
}

