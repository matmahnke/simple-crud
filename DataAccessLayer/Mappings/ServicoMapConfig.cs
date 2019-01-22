using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class ServicoMapConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoMapConfig()
        {
            this.ToTable("SERVICOS");
            this.Property(s => s.Valor).HasPrecision(10, 2);

            this.HasRequired(c => c.Profissional).WithMany(c => c.Servicos).WillCascadeOnDelete(false);
            this.HasRequired(c => c.Quarto).WithMany(c => c.Servicos).WillCascadeOnDelete(false);
            this.HasRequired(c => c.Cliente).WithMany(c => c.Servicos).WillCascadeOnDelete(false);

        }
    }
}
