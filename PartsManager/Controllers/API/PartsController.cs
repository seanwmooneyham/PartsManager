using AutoMapper;
using PartsManager.DTOs;
using PartsManager.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PartsManager.Controllers.API
{
    public class PartsController : ApiController
    {
        private ApplicationDbContext _context;

        public PartsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/parts/

        public IHttpActionResult GetParts()
        {
            var partsDto = _context.Parts
                .Include(p => p.PartType)
                .Include(p => p.PartLocation)
                .ToList().Select(Mapper.Map<Part, PartDto>);

            return Ok(partsDto);

        }

        // GET /api/parts/id
        public IHttpActionResult GetPart(int id)
        {
            var movie = _context.Parts.SingleOrDefault(p => p.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Part, PartDto>(movie));
        }

        // POST /api/parts
        [HttpPost]
        public IHttpActionResult CreatePart(PartDto partDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<PartDto, Part>(partDto);
            _context.Parts.Add(movie);
            _context.SaveChanges();

            partDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), partDto);
        }


        // PUT api/parts/id
        [HttpPut]
        public IHttpActionResult UpdatePart(int id, PartDto partDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var partInDb = _context.Parts.SingleOrDefault(p => p.Id == id);

            if (partInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(partDto, partInDb);

            _context.SaveChanges();

            return Ok();
        }

        //  DELETE /api/parts/1
        [HttpDelete]
        public IHttpActionResult DeletePart(int id)
        {
            var partInDb = _context.Parts.SingleOrDefault(p => p.Id == id);

            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Parts.Remove(partInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
