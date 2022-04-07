using EFCore.Dominio;
using EFCore.Repo;
using EFCore.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo
{
    public class EFCoreRepository : IEFCoreRepository
    {
        private readonly HeroiContext _context;

        //Eu vou receber como parametro a instancia aqui do objeto 
        public EFCoreRepository(HeroiContext contexto)
        {
            _context = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity)  ;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<IEnumerable<Heroi>> GetAllHerois(bool incluirBatalha = false)
        {
            //JOIN ENTRE HEROIS E IDENTIDADESSECRETAS E HEROIS E ARMAS
            //ENTÃO OS HEROIS VIRAM COM AS ARMAS E IDENTIDADES
            //No lambida o h significa heroi
            IQueryable<Heroi> query = _context.Herois
                .Include(h => h.Identidade)
                .Include(h => h.Armas);

            //Só que a Batalha é N p N, e agora?
            query.Include(h => h.HeroisBatalhas)
                .ThenInclude(Heroib => Heroib.Batalha);

            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.ToArrayAsync();

        }

        public async Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois
              .Include(h => h.Identidade)
              .Include(h => h.Armas);

            //Só que a Batalha é N p N, e agora?
            query.Include(h => h.HeroisBatalhas)
                .ThenInclude(Heroib => Heroib.Batalha);

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois
             .Include(h => h.Identidade)
             .Include(h => h.Armas);

            if (incluirBatalha)
            {
                query.Include(h => h.HeroisBatalhas)
                    .ThenInclude(Heroib => Heroib.Batalha);

            }

            query = query.AsNoTracking()
                .Where(h => h.Nome.Contains(nome))
                .OrderBy(h => h.Id); 

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHerois = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

           
            query.Include(h => h.HeroisBatalhas)
                .ThenInclude(Heroib => Heroib.Heroi);

            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.ToArrayAsync();

        }

        public async Task<Batalha> GetBatalhaById(int id, bool incluirHerois)
        {
            IQueryable<Batalha> query = _context.Batalhas;


            query.Include(h => h.HeroisBatalhas)
                .ThenInclude(Heroib => Heroib.Heroi);

            query = query.AsNoTracking().OrderBy(h => h.Id);
            return await query.FirstOrDefaultAsync();
        }

    }
}
