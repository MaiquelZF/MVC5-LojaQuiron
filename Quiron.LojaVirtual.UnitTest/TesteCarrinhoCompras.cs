using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "TEste2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 3);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "TEste2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId)
                .ToArray();

            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);
            Assert.AreEqual(resultado[1].Quantidade, 1);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "TEste2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto1, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count() , 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "TEste2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal();
            
            Assert.AreEqual(resultado, 450M);
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "TEste2",
                Preco = 50M
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.LimpparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);
        }
    }
}
