using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NarvaezEsteban_ExamenProgreso1.Models;

    public class UsuarioContext : DbContext
    {
        public UsuarioContext (DbContextOptions<UsuarioContext> options)
            : base(options)
        {
        }

        public DbSet<NarvaezEsteban_ExamenProgreso1.Models.Celular> Celular { get; set; } = default!;
    }
