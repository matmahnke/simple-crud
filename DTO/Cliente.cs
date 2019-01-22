using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Cliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int PontosFidelidade { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
