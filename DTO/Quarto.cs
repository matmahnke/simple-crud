using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Quarto
    {
        public int ID { get; set; }
        public string CodigoQuarto { get; set; }
        public bool TemHidromassagem { get; set; }
        public bool TemFrigobar { get; set; }
        public bool EstaOcupado { get; set; }

        public virtual ICollection<Servico> Servicos { get; set; }
    }
}
