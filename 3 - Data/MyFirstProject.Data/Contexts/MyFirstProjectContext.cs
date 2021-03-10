using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstProject.Domain.Entities;
using MyFirstProject.Shared.Data;
using MyFirstProject.Shared.DomainObjects;

namespace MyFirstProject.Data.Contexts
{
    public class MyFirstProjectContext : DbContext, IUnitOfWork
    {
        public MyFirstProjectContext(DbContextOptions<MyFirstProjectContext> options)
            : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // APLICAR O FLUENT API
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyFirstProjectContext).Assembly);
            MapForgottenProperties(modelBuilder);

            modelBuilder.Ignore<Validation>();
        }

        private void MapForgottenProperties(ModelBuilder modelBuilder)
        {
            // CARREGA A LISTA DE ENTIDADES DA APLICAÇÃO
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // PEGA PROPRIEDADES TIPO STRING
                var properties = entity.GetProperties().Where(p => p.ClrType == typeof(string));

                foreach (var property in properties)
                {
                    // VERIFICA TIPO COLUNA VAZIA (SE FOI CONFIGURADO) E SE FOI SETADO UM TAMANHO PARA A PROPRIEDADE
                    if (string.IsNullOrEmpty(property.GetColumnType()) && !property.GetMaxLength().HasValue)
                    {
                        // property.SetMaxLength(100);

                        property.SetColumnType("VARCHAR(100)");
                    }
                }
            }
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}