using DataAccessLayer.Mappings;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class PutsContext : DbContext
    {
        public PutsContext() : base("PutsDB")
        {
            //Database.SetInitializer(new PutsDbStrategy());
        }
        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DbConfiguration.SetConfiguration(new PutsDbConfiguration());
            //Exemplo de Configuracao Global
            //Exemplo de customizacao de chave primaria
            //modelBuilder.Properties().Where(c=> c.Name == "Codigo" && c.PropertyType == typeof(int)).Configure(c=> c.IsKey().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity));
            //Exemplo de configuração padrão pra todas as strings
            modelBuilder.Properties().Where(c=> c.PropertyType == typeof(string)).Configure(c=> c.IsRequired().IsUnicode(false));

            //Exemplo de adição de classes de mapeamento de tabela
            //modelBuilder.Configurations.Add(new ClienteMapConfig());
            //modelBuilder.Configurations.Add(new ProfissionalMapConfig());
            //Exemplo de adição de classes de mapeamento de tabela POR ASSEMBLY
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
       
            base.OnModelCreating(modelBuilder);
        }
    }
    public class PutsDbStrategy : DropCreateDatabaseAlways<PutsContext>
    {

    }
}
