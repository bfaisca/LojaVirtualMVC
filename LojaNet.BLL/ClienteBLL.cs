using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaNet.Models;
using LojaNet.DAL;

namespace LojaNet.BLL
{
    public class ClienteBLL : IClienteDados
    {
        private ClienteDAL dal;

        public ClienteBLL()
        {
            this.dal = new ClienteDAL();
        }

        public void Alterar(Cliente cliente)
        {
            ValidarCliente(cliente);

            if (string.IsNullOrEmpty(cliente.Id))
            {
                throw new ApplicationException("O ID deve ser informado!");
            }

            dal.Alterar(cliente);
        }

        public void Incluir(Cliente cliente)
        {
            ValidarCliente(cliente);
            if (string.IsNullOrEmpty(cliente.Id))
            {
                cliente.Id = Guid.NewGuid().ToString();
            }

            dal.Incluir(cliente);
        }

        private static void ValidarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
            {
                throw new ApplicationException("O nome deve ser informado!");
            }
        }
        public void Excluir(string Id)
        {
            if (string.IsNullOrEmpty(Id))
            {
                throw new ApplicationException("O ID deve ser informado!");
            }

            dal.Excluir(Id);
        }

        public Cliente ObterPorEmail(string Email)
        {
            return dal.ObterPorEmail(Email);
        }

        public Cliente ObterPorId(string Id)
        {
            return dal.ObterPorId(Id);
        }

        public List<Cliente> ObterTodos()
        {
            var lista = dal.ObterTodos();
            return lista;
        }
    }
}
