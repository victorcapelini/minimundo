using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VictorCapelini19092018.Repositories;

namespace VictorCapelini19092018.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMovimentacaoRepository movimentacaoRepository;

        public PessoaController(IPessoaRepository pessoaRepository, IMovimentacaoRepository movimentacaoRepository)
        {
            this.pessoaRepository = pessoaRepository;
            this.movimentacaoRepository = movimentacaoRepository;
        }

        // GET: Pessoa
        public ActionResult Index()
        {
            return View(pessoaRepository.GetPessoas());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int id)
        {
            return View(pessoaRepository.GetPessoaId(id));
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                pessoaRepository.CriaPessoa(collection);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int id)
        {
            return View(pessoaRepository.GetPessoaId(id));
        }

        // POST: Pessoa/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                pessoaRepository.UpdatePessoa(id, collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int id)
        {
            return View(pessoaRepository.GetPessoaId(id));
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                pessoaRepository.DeletaPessoa(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Movimentacoes(int id)
        {
            return View(movimentacaoRepository.GetMovimentacaoPorPessoa(id));
        }
    }
}