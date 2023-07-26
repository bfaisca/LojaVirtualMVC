using Microsoft.AspNetCore.Mvc;
using LojaNet.BLL;
using LojaNet.Models;

namespace LojaNet.UI.WEB.Testes.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            var bll = new ClienteBLL();
            var lista = bll.ObterTodos();
            return View(lista);
        }

        public IActionResult Incluir(Cliente cliente)
        {
            try
            {
                var bll = new ClienteBLL();
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message); 
                return View(cliente);
            }          
          
        }
    }
}
