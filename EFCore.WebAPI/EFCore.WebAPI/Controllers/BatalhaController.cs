using EFCore.Dominio;
using EFCore.Repo;
using EFCoreRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BatalhaController : Controller
    {
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalhas = await _repo.GetAllBatalhas(true);

                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        //GET: api/Batalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var batalhas = await _repo.GetBatalhaById(id, true);//true pq agora eu quero que me retorne a associação dos dois

                return Ok(batalhas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }


        //POST: api/Batalha
        [HttpPost]
        public async Task<IActionResult>Post(Batalha model)
        {
            try
            {
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Adicionou Batalha!");
                }

   
            }
            catch(Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não salvou!");

        }

        //PUT api/Batalha/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Batalha model)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Update(model);

                    if (await _repo.SaveChangesAsync())
                    {
                        return Ok("Atualizou!");
                    }

                }

                return Ok("Ñão encontrado!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Delete(batalha);

                    if(await _repo.SaveChangesAsync())
                    {
                        return Ok("Deletou!");
                    }
  
                }

                return Ok("Ñão encontrado!");

            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

        }


    }
}
