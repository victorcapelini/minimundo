using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VictorCapelini19092018.Controllers
{
    public class MovimentacaoController : Controller
    {
        // GET: Movimentacao
        public ActionResult Index()
        {
            return View();
        }

        
    }
}