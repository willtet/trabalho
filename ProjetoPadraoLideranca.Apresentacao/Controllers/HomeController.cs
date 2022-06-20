using System.Web.Mvc;
using GetSenha451.Web;

namespace ProjetoPadraoLideranca.Apresentacao.Controllers
{
    [IsAuthorized]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
