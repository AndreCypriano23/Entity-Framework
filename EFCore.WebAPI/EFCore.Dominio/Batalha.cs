using EFCore.WebAPI.Dominio;
using System;
using System.Collections.Generic;

namespace EFCore.Dominio
{
    public class Batalha
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim{ get; set; }
        //referenciando o N para N
        public List<HeroiBatalha> HeroisBatalhas { get; set; }

    }
}
