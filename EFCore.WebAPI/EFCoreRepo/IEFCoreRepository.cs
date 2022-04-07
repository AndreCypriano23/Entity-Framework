using EFCore.Dominio;
using EFCore.WebAPI.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreRepo
{
    public interface IEFCoreRepository
    {
        //Interface não tem construtor pq ela não pode ser instanciada

        //Vou colocar métodos genéricos, tipo um Add que eu vou add todas as minhas classes
        void Add<T>(T entity) where T : class; 
        void Update<T>(T entity) where T : class; 
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Heroi>> GetAllHerois(bool incluirBatalha = false);
        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);
        Task<Heroi[]> GetHeroisByNome(string nome, bool incluirBatalha = false);

        Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHerois = false);
        Task<Batalha> GetBatalhaById(int id, bool incluirHerois = false);
 

    }
}
