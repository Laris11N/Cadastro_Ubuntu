#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cadastro_Ubuntu.Models;

namespace Cadastro_Ubuntu.Data
{
    public class DefaultConnection : DbContext
    {
        public DefaultConnection (DbContextOptions<DefaultConnection> options)
            : base(options)
        {
        }

        public DbSet<Ubuntu> Ubuntu { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
