using LojaNet.BLL;
using LojaNet.Models;
using LojaNet.DAL;


namespace LojaNet.UI.WEB.Testes
{
    public static class AppConteiner
    {
        public static IClienteDados ObterClienteBLL()
        {
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            return bll;
        }

        public static IProdutosDados ObterProdutoBLL()
        {
            var dal = new ProdutoDAL();
            var bll =  new ProdutoBLL(dal);
            return bll;
        }
    }
}
