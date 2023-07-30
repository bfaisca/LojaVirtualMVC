using Microsoft.AspNetCore.Mvc;
using LojaNet.BLL;
using LojaNet.Models;

namespace LojaNet.UI.WEB.Testes.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteBLL bll;

        public ClienteController()
        {
            this.bll = new ClienteBLL();
        }

        public IActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }

        public IActionResult Incluir(Cliente cliente)
        {
            try
            {
                bll.Incluir(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message); 
                return View(cliente);
            }                   
        }
        public IActionResult Detalhes(string Id)
        {
            try
            {
                var cliente = bll.ObterPorId(Id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Alterar(string Id)
        {
            try
            {
                var cliente = bll.ObterPorId(Id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Cliente cliente)
        {
            try
            {
                bll.Alterar(cliente);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(cliente);
            }

        }

        public IActionResult Excluir(string id)
        {
            try
            {
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Excluir(string id,IFormCollection form)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var cliente = bll.ObterPorId(id);
                return View(cliente);
            }

        }

    }
}
