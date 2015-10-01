using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _repositorio;

        //Procedimento de CACHE para não ir toda a vez no Banco buscar as informações.
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {   
            _repositorio = new CategoriaRepositorio();

            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSEO = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }
    }
}