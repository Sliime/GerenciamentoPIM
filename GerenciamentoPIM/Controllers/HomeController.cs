using GerenciamentoPIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoPIM.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Cadastrar(Aluno aluno)
        {

            if (ModelState.IsValid)
            {
                aluno.Cadastrar(aluno);

                return Index();
            }

            return View();
        }
    }
}