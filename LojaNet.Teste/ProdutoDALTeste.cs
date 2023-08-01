using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.Teste
{
    public class ProdutoDALTeste
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Incluir()
        {
            var p = new Produto()
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "ProdutoTeste",
                Preco = 100,
                Estoque = 2
            };

            var dal = new ProdutoDAL();
            dal.Incluir(p);

            var produto = dal.ObterPorId(p.Id);

            Assert.IsTrue(produto != null, "Erro na inclusão");


        }
        [Test]
        public void Listar()
        {
            var dal = new ProdutoDAL();
            var lista = dal.ObterTodos();

            foreach (var p in lista)
            {
                Console.WriteLine(p.Id);
                Console.WriteLine(p.Nome);
                Console.WriteLine(p.Preco);
                Console.WriteLine(p.Estoque);
            }

            Assert.IsTrue(lista.Count > 0, "A lista não pode ser vazia");
        }
    }
}
