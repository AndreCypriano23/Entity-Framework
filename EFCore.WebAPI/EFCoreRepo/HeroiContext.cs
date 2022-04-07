using EFCore.Dominio;
using EFCore.WebAPI.Dominio;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Repo
{
    public class HeroiContext : DbContext
    {
    
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options)
        {   
            
        }

        public DbSet<Heroi> Herois { get; set; }
        public DbSet<Batalha> Batalhas { get; set; } 
        public DbSet<Arma> Armas { get; set; }
        //Essa tabela HeroiBatalhas tem uma chave primaria composta de heroi e batalhas
        public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }//tem que avisar que é N p N no EF

        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //referenciar aqui as chaves compostas de N para N
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });//A chave é composta
            });
        }

        //string de conexão
        //optionsBuilder.UseSqlServer("Server=DESKTOP-3T92CQT\SQLEXPRESS;DataBase=HeroiApp;Uid=ModalGr;Pwd=");
        //optionsBuilder.UseSqlServer(@"Password=123456;Persist Security Info=False;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-3T92CQT\SQLEXPRESS");

    }
}
