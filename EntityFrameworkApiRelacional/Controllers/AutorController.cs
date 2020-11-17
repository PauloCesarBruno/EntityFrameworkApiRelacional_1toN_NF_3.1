using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkApiRelacional.Models;
using EntityFrameworkApiRelacionalRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntityFrameworkApiRelacional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IEFWebApiRepository _repo;

        public AutorController(IEFWebApiRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<AutorController>
        [HttpGet]
        public async Task<IActionResult> GetAutors()
        {
            try
            {
                var results = await _repo.GetAutors();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
        }

        // GET api/<AutorController>/5
        [HttpGet("{Autorid}")]
        public async Task<IActionResult> Get(int AutorId)
        {
            try
            {
                var results = await _repo.GetAutorId(AutorId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
        }

        // POST api/<AutorController>
        [HttpPost]
        public async Task<IActionResult> Post(Autor model)
        {
            try
            {
                _repo.Add(model);
                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Autor/{model.AutorId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
            return BadRequest();
        }

        // PUT api/<AutorController>/5
        [HttpPut("{Autorid}")]
        public async Task<IActionResult> Put(int AutorId, Autor model)
        {
            try
            {
                var results = await _repo.GetAutorId(AutorId);
                if (results == null) return NotFound();

                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Autor/{model.AutorId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
            return BadRequest();
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{Autorid}")]
        public async Task<IActionResult> Delete(int AutorId)
        {
            try
            {
                var results = await _repo.GetAutorId(AutorId);
                if (results == null) return NotFound();

                _repo.Delete(results);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
            return BadRequest();
        }
    }
}
