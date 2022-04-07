using EFCore.WebAPI.Dominio;

namespace EFCore.Dominio
{
    public class Arma
    {
        //A arma terá relação de 1 para 1 com o herói que tem a arma
        public int Id { get; set; }
        public string Nome { get; set; }
        public Heroi Heroi { get; set; }
        public int HeroiId { get; set; }
    }
}
