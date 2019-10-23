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
        public Aluno imus = new Aluno();

        public ActionResult Index()
        {
           var lista = imus.Consultar();
            return View(lista);
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

        public ActionResult Create(Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                imus.Cadastrar(aluno);

                return RedirectToAction("Index");
            }

            return View();
        }


    }
}