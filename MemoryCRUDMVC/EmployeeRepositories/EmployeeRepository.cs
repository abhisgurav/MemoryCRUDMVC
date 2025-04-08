using MemoryCRUDMVC.Models;

namespace MemoryCRUDMVC.EmployeeRepositories
{
    public class EmployeeRepository
    {
        private static List<Employee> employees = new List<Employee>();
        private static int nextId = 1;

        //public List<Employee> GetAll() => employees;
        public List<Employee> GetAll() => employees ?? new List<Employee>(); // ✅ Avoid null reference


        public Employee GetById(int id) => employees.FirstOrDefault(e => e.Id == id);

        public void Add(Employee employee)
        {
            employee.Id = nextId++;
            employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Salary = employee.Salary;
            }
        }

        public void Delete(int id) => employees.RemoveAll(e => e.Id == id);
    }
}
