using Microsoft.EntityFrameworkCore;
using Projeto_semana1_modulo03.Models;

namespace Projeto_semana1_modulo03.Context
{
    public class ContextApp:DbContext
    {
        public ContextApp(DbContextOptions<ContextApp> options):base(options){ } 

        public DbSet<Postagem> Postagems { get; set; }
    }
}
