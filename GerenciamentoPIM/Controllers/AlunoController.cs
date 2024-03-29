﻿using GerenciamentoPIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GerenciamentoPIM.Controllers
{
    public class AlunoController : Controller
    {
       public Tarefas imus = new Tarefas();


        // GET: Aluno
        public ActionResult Index()
        {
            
            //imus.Disciplina = "testandoqqqqqqqqqqqqqqqqqqqss";
            //imus.Nome = "imus";
            //imus.Cadastrar(imus);


            return View();
        }

        // GET: Aluno/Details/5
        public JsonResult Details()
        {
           var lista = imus.Consultar();

            return Json(lista, JsonRequestBehavior.AllowGet);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Create(Tarefas aluno)
        {
            if (ModelState.IsValid)
            {
                imus.Cadastrar(aluno);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete()
        {

            return View();
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
