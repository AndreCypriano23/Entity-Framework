using EFCore.Dominio;
using System.Collections.Generic;

namespace EFCore.WebAPI.Dominio
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //referenciando o N para N
        public List<HeroiBatalha> HeroisBatalhas { get; set; }
        //UM Herói pode ter várias armas, ou seja, uma lista de armas
        public List<Arma> Armas { get; set; }
        public IdentidadeSecreta Identidade { get; set; }//Heroi tem 1 identidadesecreta
        //nao precisei colocar IdentidadeId porque nem sempre o heroi terá uma
        //Identidade seceta então o EF já entende isso

    }

}
