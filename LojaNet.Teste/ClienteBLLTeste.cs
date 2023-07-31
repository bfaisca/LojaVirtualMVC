using LojaNet.BLL;
using LojaNet.DAL;
using LojaNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaNet.Teste
{
    public class ClienteDALMock : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
        }

        public void Excluir(string Id)
        {
        }

        public void Incluir(Cliente cliente)
        {
        }

        public Cliente ObterPorEmail(string Email)
        {
            return null;
        }

        public Cliente ObterPorId(string Id)
        {
            return null;
        }

        public List<Cliente> ObterTodos()
        {
            return null;
        }
    }
    public class ClienteBLLTeste
    {
        [SetUp]
        public void Setup()
        {
        }
    
        [Test]
        public void IncluirNomeNotNullTeste()
        {
            bool ok = false;

            var cliente = new Cliente()
            {
                Nome = "Jose Teste",
                Email = "email@teste.com.br",
                Telefone = "12354325"
            };

            var dal = new ClienteDALMock();
            var bll = new ClienteBLL(dal);

            try
            {
                bll.Incluir(cliente);
                ok = true;

            }
            catch (ApplicationException)
            {

                ok = false;
            }

            Assert.IsTrue(ok, "Deveria ter disparado um Exception");
        }

        [Test] 
        public void IncluirNomeNullTeste()
        {
            bool ok = false;

            var cliente = new Cliente()
            {
                Nome = null,
                Email = "email@teste.com.br",
                Telefone = "12354325"
            };

            var dal = new ClienteDALMock();
            var bll = new ClienteBLL(dal);

            try
            {
                bll.Incluir(cliente);
            }
            catch (ApplicationException)
            {

                ok = true;
            }

            Assert.IsTrue(ok,"Deveria ter disparado um Exception");
        }
    }
}
