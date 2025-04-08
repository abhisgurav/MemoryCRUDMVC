using Microsoft.AspNetCore.Mvc;
using MemoryCRUDMVC.EmployeeRepositories;
using MemoryCRUDMVC.Models;

namespace MemoryCRUDMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeRepository _repository = new EmployeeRepository();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Employees()
        {
            var employees = _repository.GetAll();
            return View(employees);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(employee);
                return RedirectToAction("Employees");
            }
            return View(employee);
        }

        public IActionResult Edit(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(employee);
                return RedirectToAction("Employees");
            }
            return View(employee);
        }

        public IActionResult Delete(int id)
        {
            var employee = _repository.GetById(id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Employees");
        }
    }
}
