using System;
using System.Web;
using System.Web.Mvc;
using System.Data;
using TexoITTeste.Manager;
using TexoITTeste.ViewModel;

namespace TexoITTeste.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cidade
        public ActionResult Import()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(HttpPostedFileBase upload)
        {
            managerCidade mngCidade = new managerCidade();

            try
            {
                DataTable csvTable = mngCidade.CreateImport(upload);
                return View(csvTable);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("File", ex.Message.ToString());
            }

            return View();
        }


        public ActionResult Index()
        {
            ViewData["Message"] = "";
            ViewData["MessageSucess"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult Index(CidadeViewModel Model)
        {
            ViewData["Message"] = "";
            ViewData["MessageSucess"] = "";
            try
            {
                managerCidade mngCidade = new managerCidade();

                Model = mngCidade.Search(Model);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Search", ex.Message.ToString());
            }
            return View(Model);
        }


        public ActionResult Create()
        {
            ViewData["COLOR"] = "VERDE";
            ViewData["Message"] = "";
            ViewData["SubTitle"] = "Criar Cidade";
            CidadeViewModel Model = new CidadeViewModel();
            return View(Model);
        }

        [HttpPost]
        public ActionResult Create(CidadeViewModel Model)
        {
            ViewData["COLOR"] = "VERDE";
            ViewData["Message"] = "Registrado Adicionado";
            ViewData["SubTitle"] = "Criar Cidade";

            try
            {
                managerCidade mngCidade = new managerCidade();
                Model = mngCidade.Create(Model);
            }
            catch (Exception Ex)
            {
                ViewData["COLOR"] = "VERM";
                ViewData["Message"] = Ex.Message.ToString();
            }
            return View(Model);
        }

        public ActionResult Edit(string ukey)
        {
            ViewData["COLOR"] = "VERDE";
            ViewData["Message"] = "";
            ViewData["SubTitle"] = "Alterar Cidade";

            CidadeViewModel Model = new CidadeViewModel();

            try
            {
                managerCidade mngCidade = new managerCidade();

                Model = mngCidade.SearchEdit(ukey);
            }
            catch(Exception ex)
            {
                ViewData["COLOR"] = "VERDE";
                ViewData["Message"] = ex.Message.ToString();
            }


            return View(Model);
        }

        [HttpPost]
        public ActionResult Edit(CidadeViewModel Model)
        {
            ViewData["COLOR"] = "VERDE";
            ViewData["Message"] = "Registrado Editado";
            ViewData["SubTitle"] = "Alterar Cidade";

            try
            {
                managerCidade mngCidade = new managerCidade();
                Model = mngCidade.Edit(Model);
            }
            catch(Exception Ex)
            {
                ViewData["COLOR"] = "VERM";
                ViewData["Message"] = Ex.Message.ToString();
            }
            return View(Model);
        }

        public ActionResult Delete(string ukey)
        {

            ViewData["Message"] = "";
            ViewData["MessageSucess"] = "";

            try
            {
                managerCidade mngCidade = new managerCidade();

                mngCidade.Delete(ukey);
                ViewData["MessageSucess"] = "Registro deletado";

            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ModelState.AddModelError("Delete", ex.Message.ToString());
            }
            return View("Index");
        }
    }
}
