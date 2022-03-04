using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private List<Employee> _employee = new List<Employee>
        {
            new Employee {Id = 1, LastName = "Jackson", FirstName = "Alberta", Department = "Finance", HireDate = Convert.ToDateTime("6/5/2007")},
            new Employee {Id = 2, LastName = "Bennett", FirstName = "Alicia", Department = "Human Resources", HireDate = Convert.ToDateTime("4/15/2001")},
            new Employee {Id = 3, LastName = "Avent", FirstName = "Donna", Department = "Revenue", HireDate = Convert.ToDateTime("4/20/2009")},
            new Employee {Id = 4, LastName = "Holder", FirstName = "Duane", Department = "Human Services", HireDate = Convert.ToDateTime("8/15/2020")}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_employee);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employee.Find(x => x.Id == id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            _employee.Add(employee);
            var _employeeRet = _employee.Find(x => x.Id == employee.Id);
            if (_employeeRet == null)
                return NotFound();

            return Ok(_employee);
        }

    }
}
