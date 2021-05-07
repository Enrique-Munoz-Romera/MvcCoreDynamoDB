using Microsoft.AspNetCore.Mvc;
using MvcCoreDynamoDB.Models;
using MvcCoreDynamoDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreDynamoDB.Controllers
{
    public class CochesController : Controller
    {
        ServiceDynamoDB Service;

        public CochesController(ServiceDynamoDB service) { this.Service = service; }

        public async Task<IActionResult> Index()
        {
            return View(await this.Service.GetCoches());
        }

        public async Task<IActionResult> Details(int id)
        {
            return View(await this.Service.FindCoche(id));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return RedirectToAction("Index","Coches");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Coche car)
        {
            return RedirectToAction("Index", "Coches");
        }
    }
}
