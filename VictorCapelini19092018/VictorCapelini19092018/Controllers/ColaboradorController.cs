using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VictorCapelini19092018.Models;
using VictorCapelini19092018.Repositories;

namespace VictorCapelini19092018.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly IColaboradorRepository colaboradorRepository;
        private readonly IEmpresaRepository empresaRepository;
        private readonly IPessoaRepository pessoaRepository;


        public ColaboradorController(IColaboradorRepository colaboradorRepository, IEmpresaRepository empresaRepository, IPessoaRepository pessoaRepository)
        {
            this.colaboradorRepository = colaboradorRepository;
            this.empresaRepository = empresaRepository;
            this.pessoaRepository = pessoaRepository;
        }

        // GET: Colaborador
        public ActionResult Index()
        {
            return View(colaboradorRepository.GetColaboradores());
        }

        // GET: Colaborador/Details/5
        public ActionResult Details(int id)
        {
            return View(colaboradorRepository.GetColaboradorId(id));
        }

        // GET: Colaborador/Create
        public ActionResult Create()
        {
            ViewBag.Empresas = empresaRepository.GetEmpresas();
            ViewBag.Pessoas = pessoaRepository.GetPessoas();


            return View();
        }

        // POST: Colaborador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                colaboradorRepository.CriaColaborador(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Colaborador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Colaborador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Colaborador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Colaborador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}