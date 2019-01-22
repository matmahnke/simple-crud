using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappings
{
    class UsuarioMapConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapConfig()
        {
            this.ToTable("USUARIOS");
            this.Property(p => p.UserName).HasMaxLength(50);
            this.Property(p => p.Senha).HasMaxLength(50);
        }
    }
}
