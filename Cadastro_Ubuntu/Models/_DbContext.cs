using Microsoft.EntityFrameworkCore;

namespace Cadastro_Ubuntu.Models
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Ubuntu> ubuntus
        {
            get; set;
        }
        public DbSet<UsuarioModel> Usuarios
        {
            get; set;
        }

    }
}


