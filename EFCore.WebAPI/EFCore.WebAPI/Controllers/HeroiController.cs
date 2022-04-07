using EFCore.Dominio;
using EFCore.Repo;
using EFCore.WebAPI.Dominio;
using EFCoreRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class HeroiController : Controller
    {
        private readonly IEFCoreRepository _repo;

        public HeroiController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var herois = await _repo.GetAllHerois(true);

                return Ok(herois);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
           
        }

        [HttpGet("{id}", Name = "GetHeroi")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id, true);//true pq agora eu quero que me retorne a associação dos dois

                return Ok(heroi);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

       [HttpPost]
       public async Task<IActionResult> Post(Heroi model)
       {
            try
            {
                
                _repo.Add(model);
                if (await _repo.SaveChangesAsync())
                {
                    return Ok("Adicionou Herói!");
                }
             
                return Ok("Adicionou Heroi!");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
       }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if(heroi != null)
                {
                    _repo.Update(model);

                    if(await _repo.SaveChangesAsync())
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetHeroiById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);

                    if (await _repo.SaveChangesAsync())
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
