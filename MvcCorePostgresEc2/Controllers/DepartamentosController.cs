using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEc2.Models;
using MvcCorePostgresEc2.Repositories;

namespace MvcCorePostgresEc2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamento repo;
        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            List<Departamento> departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        public async Task<IActionResult> Details(int id)
        {
            Departamento dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int DeptNo, string Nombre, string Localidad)
        {
            await this.repo.CreateDepartamentoAsync(DeptNo, Nombre, Localidad);
            return RedirectToAction("Index");
        }
    }
}
