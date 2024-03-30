using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.BackEnd.Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Teste.BackEnd.Infra.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Credit> Credits { get; set; }
    }
}
