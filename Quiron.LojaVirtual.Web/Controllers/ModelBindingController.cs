using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar([Bind(Include ="Nome")] Produto product)
        {
            var produto = new Produto();
                        
            //Esse carinha tb atualizaria (só teria que ter cuidado com a validação dos campos obrigatórios da classe.
            //UpdateModel(produto);

            produto.Nome = Request.Form["Nome"];
            produto.Preco = Decimal.Parse(Request.Form["Preco"]);


            return RedirectToAction("Index");
        }
    }
}