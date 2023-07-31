﻿using APIConsulta.Model;
using LojaNet.DAL;
using Microsoft.AspNetCore.Mvc;

namespace APIConsulta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : IConsultaCliente
    {
       
        [HttpGet(Name = "GetCliente")]
        public ClienteInfo ConsultarPorEmail(string chave, string email)
        {
            ClienteInfo clienteInfo = new ClienteInfo();
            if(chave != "12345")
            {
                return null;
            }

            var bll = new ClienteDAL();
            var cliente = bll.ObterPorEmail(email);

            if(cliente == null)
            {
                return null;
            }
            else
            {
                clienteInfo = new ClienteInfo()
                {
                    Nome = cliente.Nome,
                    Email = cliente.Email,
                    Telefone = cliente.Telefone
                };
            }

            return clienteInfo;



        }
    }
}
