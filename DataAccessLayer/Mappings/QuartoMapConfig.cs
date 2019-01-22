using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class QuartoMapConfig : EntityTypeConfiguration<Quarto>
    {
        public QuartoMapConfig()
        {
            this.ToTable("QUARTOS");
            this.Property(q => q.CodigoQuarto).HasMaxLength(5);
        }
    }
}
