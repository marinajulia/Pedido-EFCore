using CursoEntityFramework1.Data.Configurations;
using CursoEntityFramework1.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoEntityFramework1.Data {
   public class ApplicationContext:DbContext {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging()//mostra os dados
                .UseSqlServer(@"Data Source=DESKTOP-8024PRG\SERVIDOR;Initial Catalog=CursoEFCore;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
