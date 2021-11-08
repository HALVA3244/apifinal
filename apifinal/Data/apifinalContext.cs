using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using apifinal.models;

namespace apifinal.Data
{
    public class apifinalContext : DbContext
    {
        public apifinalContext (DbContextOptions<apifinalContext> options)
            : base(options)
        {
        }

        public DbSet<apifinal.models.catedraticos> catedraticos { get; set; }

        public DbSet<apifinal.models.cursos> cursos { get; set; }

        public DbSet<apifinal.models.reportes> reportes { get; set; }
    }
}
