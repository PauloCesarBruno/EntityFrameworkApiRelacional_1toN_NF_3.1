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
    public class LivroController : ControllerBase
    {
        private readonly IEFWebApiRepository _repo;

        public LivroController(IEFWebApiRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<LivroController>
        [HttpGet]
        public async Task<IActionResult> GetLivro()
        {
            try
            {
                var results = await _repo.GetLivro();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
        }

        // GET api/<LivroController>/5
        [HttpGet("{Livroid}")]
        public async Task<IActionResult> Get(int LivroId)
        {
            try
            {
                var results = await _repo.GetLivroId(LivroId);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
        }

        // POST api/<LivroController>
        [HttpPost]
        public async Task<IActionResult> Post(Livro model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Livro/{model.LivroId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
            return BadRequest();
        }

        // PUT api/<LivroController>/5
        [HttpPut("{Livroid}")]
        public async Task<IActionResult> Put(int LivroId, Livro model)
        {
            try
            {
                var results = await _repo.GetLivroId(LivroId);
                if (results == null) return NotFound();

                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Livro/{model.LivroId}", model);
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falha no Banco de Dados !!! {ex.Message}");
            }
            return BadRequest();
        }

        // DELETE api/<LivroController>/5
        [HttpDelete("{Livroid}")]
        public async Task<IActionResult> Delete(int LivroId)
        {
            try
            {
                var results = await _repo.GetLivroId(LivroId);
                if (results == null) return NotFound();

                _repo.Delete(results);

                if (await _repo.SaveChangesAsync())
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
