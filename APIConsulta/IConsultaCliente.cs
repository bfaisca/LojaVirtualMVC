using APIConsulta.Model;

namespace APIConsulta
{
    public interface IConsultaCliente
    {
        ClienteInfo ConsultarPorEmail(string chave, string email);
    }
}
