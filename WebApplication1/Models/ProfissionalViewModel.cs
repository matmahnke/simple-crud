using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.WEB;

namespace WebApplication1.Models
{
    public class ProfissionalViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [Display(Name="Nome de Guerra")]
        public string NomeGuerra { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        [Required]
        [Display(Name = "Valor Hora R$")]
        public decimal ValorHora { get; set; }
        public Etnia Etnia { get; set; }
        [Display(Name = "Virgem")]
        public bool EhVirgem { get; set; }
        [Display(Name = "Silicone Cima")]
        public bool TemSiliconeCima { get; set; }
        [Display(Name = "Silicone Baixo")]
        public bool TemSiliconeBaixo { get; set; }
        [Required]
        public double Altura { get; set; }
        [Required]
        public float Peso { get; set; }
    }
}