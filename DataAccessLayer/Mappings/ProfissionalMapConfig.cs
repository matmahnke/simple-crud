using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class ProfissionalMapConfig : EntityTypeConfiguration<Profissional>
    {
        public ProfissionalMapConfig()
        {
            this.ToTable("PROFISSIONAIS");
            this.Property(p => p.DataNascimento).HasColumnType("datetime2");
            this.Property(p => p.Nome).HasMaxLength(60);
            this.Property(p => p.NomeGuerra).HasMaxLength(30);
            this.Property(p => p.ValorHora).HasPrecision(7, 2);
        }
    }
}
