using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.WEB;

namespace WebApplication1.Models
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado.")]
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage="Favor, digite um e-mail válido.")]
        [Required(ErrorMessage = "O email deve ser informado.")]
        public string Email { get; set; }
    }
}