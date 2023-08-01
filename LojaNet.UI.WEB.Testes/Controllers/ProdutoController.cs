using LojaNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaNet.UI.WEB.Testes.Controllers
{
    public class ProdutoController : Controller
    {
        private IProdutosDados bll;

        public ProdutoController()
        {
            bll = AppConteiner.ObterProdutoBLL();
        }
        public IActionResult Index()
        {
            var lista = bll.ObterTodos();
            return View(lista);
        }

        public IActionResult Incluir(Produto produto)
        {
            try
            {
                bll.Incluir(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }
        }
        public IActionResult Detalhes(string Id)
        {
            try
            {
                var produto = bll.ObterPorId(Id);
                return View(produto);
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
                var produto = bll.ObterPorId(Id);
                return View(produto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                bll.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(produto);
            }

        }

        public IActionResult Excluir(string id)
        {
            try
            {
                var produto = bll.ObterPorId(id);
                return View(produto);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Excluir(string id, IFormCollection form)
        {
            try
            {
                bll.Excluir(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var produto = bll.ObterPorId(id);
                return View(produto);
            }

        }
    }
}
