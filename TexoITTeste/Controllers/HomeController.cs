using TexoITTeste.Models;
using TexoITTeste.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
         
            return View();
        }
        #endregion

    }
}