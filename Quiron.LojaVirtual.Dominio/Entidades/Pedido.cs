using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        [Required(ErrorMessage="Informe seu nome")]
        public String NomeCliente { get; set; }

        [Display(Name = "Cep:")]
        public string Cep { get; set; }

        [Required(ErrorMessage ="Informe seu Endereço")]
        [Display(Name = "Enderço:")]
        public String Endereco { get; set; }

        [Display(Name = "Complemento:")]
        public String Complemento { get; set; }

        [Required(ErrorMessage = "Informe sua Cidade")]
        [Display(Name = "Cidade:")]
        public String Cidade { get; set; }

        [Required(ErrorMessage = "Informe seu Bairro")]
        [Display(Name = "Bairro:")]
        public String Bairro { get; set; }

        [Required(ErrorMessage = "Informe seu Estado")]
        [Display(Name = "Estado:")]
        public String Estado { get; set; }

        [Display(Name = "EMail:")]
        [Required(ErrorMessage = "Informe seu E-Mail")]
        [EmailAddress(ErrorMessage ="E-Mail inválido")]
        public string Email { get; set; }

        public bool EmbrulhaPresente { get; set; }

    }
}
