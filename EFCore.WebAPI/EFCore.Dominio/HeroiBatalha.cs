using EFCore.Dominio;

namespace EFCore.WebAPI.Dominio
{
    public class HeroiBatalha
    {
        // tenho que colocar as tabelas e os ids dela
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }
        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }
        
    }
}
