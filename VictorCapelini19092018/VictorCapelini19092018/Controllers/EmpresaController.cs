using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VictorCapelini19092018.Models;
using VictorCapelini19092018.Repositories;

namespace VictorCapelini19092018.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            this.empresaRepository = empresaRepository;
        }

        // GET: Empresa
        public ActionResult Index()
        {
            return View(empresaRepository.GetEmpresas());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View(empresaRepository.GetEmpresaId(id));
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                empresaRepository.CriaEmpresa(collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View(empresaRepository.GetEmpresaId(id));
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                empresaRepository.UpdateEmpresa(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View(empresaRepository.GetEmpresaId(id));
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                empresaRepository.DeletaEmpresa(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}