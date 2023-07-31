using LojaNet.BLL;
using LojaNet.DAL;

namespace LojaNet.Teste
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ObterClientePorEmailNullTest() 
        { 
            string email = null;
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            bool ok = false;

            try
            {
                var cliente = bll.ObterPorEmail(email);

            }
            catch (ApplicationException ex)
            {
                if (ex.Message.Contains("O email deve ser informado"))
                {
                    ok = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no Servidor. Parametro não informado " + ex) ;
            }

            Assert.IsTrue(ok,"Deveria ter disparado um ApplicationException");
        }

        [Test]
        public void ObterClientePorEmailTest()
        {
            string email = "bmlfaisca@gmail.com";
            var dal = new ClienteDAL();
            var bll = new ClienteBLL(dal);
            var cliente = bll.ObterPorEmail(email);

            Assert.IsTrue(cliente!=null,"Deveria ter retornado uma instancia de cliente");
        }
    }
}