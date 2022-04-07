namespace EFCore.WebAPI.Dominio
{
    public class IdentidadeSecreta
    {
        public int Id { get; set; }
        public string NomeReal { get; set; }//Do Batman é Bruce Wayne
        public int HeroiId { get; set; } // é um para um
        public Heroi Heroi { get; set; }
   

    }
}
