using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            Produto produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 3);

            CarrinhoController controller = new CarrinhoController();

            //Act

            controller.Adicionar(carrinho, 2, "");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);

            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);

        }

        [TestMethod]
        public void Adicionar_prod_Carrinho()
        {
            //Preparação (Arrange) e o estimulo (Act), das verificações.

            //Arrange
            Carrinho carrinho = new Carrinho();

            //A
            CarrinhoController controller = new CarrinhoController();

            //Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }

        [TestMethod]
        public void Posso_Ver_O_Meu_Carrinho()
        {
            //Preparação (Arrange) e o estimulo (Act), das verificações.

            //Arrange
            Carrinho carrinho = new Carrinho();

            //A
            CarrinhoController controller = new CarrinhoController();

            //Act
            CarrinhoViewModel resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;


            //Assert
            Assert.AreSame(resultado.Carrinho, carrinho);

            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
        }
    }
}
