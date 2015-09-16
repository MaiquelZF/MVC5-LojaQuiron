using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Produto
    {
        [HiddenInput(DisplayValue = false)]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a descrição")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Digite o Preço do Produto")]
        [Range(0.01, double.MaxValue, ErrorMessage ="Valor inválido")]
        public decimal Preco{ get; set; }

        [Required(ErrorMessage = "Digite a Categoria")]
        public string Categoria { get; set; }

        public byte[] Imagem { get; set; }
        public String ImagemMimeType { get; set; }

    }
}