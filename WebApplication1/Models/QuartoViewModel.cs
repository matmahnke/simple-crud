using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.WEB;

namespace WebApplication1.Models
{
    public class QuartoViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessageResourceType=typeof(ResourceErrorMessages),
                  ErrorMessageResourceName="ErroCodigoQuartoRequired")]
        [Display(Name="Código",Description="Favor, digite o seu código")]
        public string CodigoQuarto { get; set; }
        [Display(Name = "Hidromassagem")]
        public bool TemHidromassagem { get; set; }
        [Display(Name = "Frigobar")]
        public bool TemFrigobar { get; set; }
    }
}