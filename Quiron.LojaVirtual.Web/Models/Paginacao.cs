using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Web.Models
{
    public class Paginacao
    {
        public int ItensTotal { get; set; }
        public int ItensporPagina { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPagina
        {
            get
            {
                return (int)Math.Ceiling((decimal) ItensTotal / ItensporPagina);
            }
        }
    }
}
