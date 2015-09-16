using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Entidades;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Carrinho carrinho = null;

            if(controllerContext.HttpContext.Session != null)
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];

            if (carrinho ==null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
            }

            return carrinho;
        }
    }
}
