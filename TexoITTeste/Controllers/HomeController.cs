using TexoITTeste.Models;
using TexoITTeste.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TexoITTeste.Manager;

namespace TexoITTeste.Controllers
{
    public class HomeController : Controller
    {

        EFContext db = new EFContext();

        #region Home
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Texo IT - Teste";
            ViewData["Message"] = "";

            DashBoardViewModel Model = new DashBoardViewModel();
            try
            {
                managerCidade mngCidade = new managerCidade();
                Model = mngCidade.DashBoard();
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }

            return View(Model);
        }
        #endregion

    }
}