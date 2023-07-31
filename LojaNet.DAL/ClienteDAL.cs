using LojaNet.Models;
using System.Data;

namespace LojaNet.DAL
{
    public class ClienteDAL : IClienteDados
    {
        public void Alterar(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteAlterar",
             "@Id", cliente.Id,
             "@Nome", cliente.Nome,
             "@Email", cliente.Email,
             "@Telefone", cliente.Telefone
             );
        }

        public void Excluir(string Id)
        {
            Cliente cliente = ObterPorId(Id);
            SerializadorHelper.Serializar(@"C:\\dados\Cliente " + Id,cliente);
            DbHelper.ExecuteNonQuery("ClienteExcluir", "@Id", Id);
        }

        public void Incluir(Cliente cliente)
        {
            DbHelper.ExecuteNonQuery("ClienteIncluir",
                "@Id", cliente.Id,
                "@Nome", cliente.Nome,
                "@Email", cliente.Email,
                "@Telefone", cliente.Telefone
                );
        }

        public Cliente ObterPorEmail(string email)
        {
            if(string.IsNullOrEmpty(email))
            {
                throw new ApplicationException("O email deve ser informado");
            }

            Cliente cliente = new Cliente();

            using (var reader = DbHelper.ExecuteReader("ObterClientePorEmail", "@Email", email))
            {
                if (reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;
        }

        public Cliente ObterPorId(string id)
        {
            Cliente cliente = new Cliente();

            using (var reader = DbHelper.ExecuteReader("ObterClientePorId","@Id",id))
            {
                if (reader.Read())
                {
                    cliente = ObterClienteReader(reader);
                }
            }
            return cliente;
        }

        public List<Cliente> ObterTodos()
        {
            var lista = new List<Cliente>();
            using (var reader = DbHelper.ExecuteReader("ClienteListar"))
            {
                while (reader.Read())
                {
                    Cliente cliente = ObterClienteReader(reader);

                    lista.Add(cliente);
                }
            }

            return lista;
        }

        private static Cliente ObterClienteReader(IDataReader reader)
        {
            var cliente = new Cliente();
            cliente.Id = reader["Id"].ToString();
            cliente.Nome = reader["Nome"].ToString();
            cliente.Email = reader["Email"].ToString();
            cliente.Telefone = reader["Telefone"].ToString();
            return cliente;
        }
    }
}
