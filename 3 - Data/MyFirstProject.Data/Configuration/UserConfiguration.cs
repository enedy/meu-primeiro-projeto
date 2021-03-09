using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstProject.Domain.Entities;

namespace MyFirstProject.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User"); // NOME DA TABELA
            builder.HasKey(p => p.Id); // DEFINICAO PK
            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)"); // DEFINICAO DO NOME
            builder.Property(p => p.Password).HasColumnType("VARCHAR(50)"); // DEFINICAO DA SENHA
            builder.Property(p => p.Status).HasColumnType("INT");
            // OwnsOne = PARTE DE UM OBJETO
            builder.OwnsOne(navigationExpression: p => p.Document, buildAction: ba =>
           {
               ba.Property(p => p.Number).HasColumnName("Number").HasColumnType("VARCHAR(14)");
               ba.Property(p => p.Type).HasColumnName("DocumentType").HasConversion<int>(); // CONVERTE PARA INTEIRO O ENUM

               // INDICE
               ba.HasIndex(x => x.Number);
           });
            // OwnsOne = PARTE DE UM OBJETO
            builder.OwnsOne(navigationExpression: p => p.Email, buildAction: ba =>
           {
               ba.Property(p => p.Address).HasColumnName("EmailAdress").HasColumnType("VARCHAR(50)");
           });

            // INDICES
            builder.HasIndex(i => i.Name).HasDatabaseName("idx_user_name");
            builder.HasIndex(i => new { i.Name, i.Status }).HasDatabaseName("idx_user_name_status");
        }
    }
}