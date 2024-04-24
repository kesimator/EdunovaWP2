﻿using EdunovaAPP.Data;
using EdunovaAPP.Extensions;
using EdunovaAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EdunovaAPP.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class GrupaController : ControllerBase
    {

        private readonly EdunovaContext _context;

        public GrupaController(EdunovaContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var lista = _context.Grupe
                    .Include(g=>g.Smjer)
                    .Include(g=>g.Predavac)
                    .Include(g=>g.Polaznici)
                    .ToList();
                if (lista == null || lista.Count == 0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(lista.MapGrupaReadList());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        [HttpGet]
        [Route("{sifra:int}")]
        public IActionResult GetBySifra(int sifra)
        {
            // kontrola ukoliko upit nije valjan
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var p = _context.Grupe.Include(i=> i.Smjer).Include(i=> i.Predavac)
                    .Include(i=> i.Polaznici).FirstOrDefault(x=> x.Sifra == sifra);
                if (p == null)
                {
                    return new EmptyResult();
                }
                return new JsonResult(p.MapGrupaInsertUpdatedToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }


        [HttpPost]
        public IActionResult Post(GrupaDTOInsertUpdate dto)
        {
            if (!ModelState.IsValid || dto == null)
            {
                return BadRequest();
            }

            var smjer = _context.Smjerovi.Find(dto.smjer);

            if (smjer == null)
            {
                return BadRequest();
            }

            var predavac = _context.Predavaci.Find(dto.predavac);

            if (predavac == null)
            {
                return BadRequest();
            }

            var entitet = dto.MapGrupaInsertUpdateFromDTO(new Grupa());

            entitet.Smjer = smjer;
            entitet.Predavac = predavac;

            try
            {
                _context.Grupe.Add(entitet);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, entitet.MapGrupaReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }
        }

        [HttpPut]
        [Route("{sifra:int}")]
        public IActionResult Put(int sifra, GrupaDTOInsertUpdate dto)
        {
            if (sifra <= 0 || !ModelState.IsValid || dto == null)
            {
                return BadRequest();
            }


            try
            {
                var entitet = _context.Grupe.Include(i=> i.Smjer).Include(i=> i.Predavac)
                    .Include(i=> i.Polaznici).FirstOrDefault(x=> x.Sifra == sifra);
                if (entitet == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                var smjer = _context.Smjerovi.Find(dto.smjer);

                if (smjer == null)
                {
                    return BadRequest();
                }

                var predavac = _context.Predavaci.Find(dto.predavac);

                if (predavac == null)
                {
                    return BadRequest();
                }

                entitet = dto.MapGrupaInsertUpdateFromDTO(entitet);

                entitet.Smjer = smjer;
                entitet.Predavac = predavac;

                _context.Grupe.Update(entitet);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, entitet.MapGrupaReadToDTO());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }

        [HttpDelete]
        [Route("{sifra:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int sifra)
        {
            if (!ModelState.IsValid || sifra <= 0)
            {
                return BadRequest();
            }

            try
            {
                var entitetIzbaze = _context.Grupe.Find(sifra);

                if (entitetIzbaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, sifra);
                }

                _context.Grupe.Remove(entitetIzbaze);
                _context.SaveChanges();

                return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }



    }
}