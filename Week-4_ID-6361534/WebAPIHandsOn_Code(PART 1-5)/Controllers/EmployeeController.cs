using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApp;
using SimpleWebApp.Models; 

[ApiController]
[CustomAuthFilter] // custom authorization filter
[Route("api/emp")]
[AllowAnonymous] // allows unauthenticated access
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee
        {
            Id = 1,
            Name = "John",
            Salary = 50000,
            Permanent = true,
            Department = new Department { Id = 1, Name = "HR" },
            Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } },
            DateOfBirth = new DateTime(1990, 5, 20)
        },
        new Employee
        {
            Id = 2,
            Name = "Alice",
            Salary = 60000,
            Permanent = false,
            Department = new Department { Id = 2, Name = "IT" },
            Skills = new List<Skill> { new Skill { Id = 2, Name = "SQL" } },
            DateOfBirth = new DateTime(1992, 3, 14)
        }
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<Employee>> GetStandard()
    {
        // throw new Exception("Something went wrong!");

        return Ok(employees);
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody] Employee employee)
    {
        return Created("", employee);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Employee> UpdateEmployee([FromBody] Employee updatedEmp)
    {
        if (updatedEmp.Id <= 0)
            return BadRequest("Invalid employee id");

        var existingEmp = employees.FirstOrDefault(e => e.Id == updatedEmp.Id);

        if (existingEmp == null)
            return BadRequest("Invalid employee id");

        // Update fields
        existingEmp.Name = updatedEmp.Name;
        existingEmp.Salary = updatedEmp.Salary;
        existingEmp.Permanent = updatedEmp.Permanent;
        existingEmp.Department = updatedEmp.Department;
        existingEmp.Skills = updatedEmp.Skills;
        existingEmp.DateOfBirth = updatedEmp.DateOfBirth;

        return Ok(existingEmp);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult DeleteEmployee(int id)
    {
        if (id <= 0)
            return BadRequest("Invalid employee id");

        var emp = employees.FirstOrDefault(e => e.Id == id);

        if (emp == null)
            return BadRequest("Invalid employee id");

        employees.Remove(emp);

        return Ok($"Employee with ID {id} deleted successfully.");
    }
}
