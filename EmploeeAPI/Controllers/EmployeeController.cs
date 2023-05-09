using EmploeeAPI.Models;
using EmployeeMarket.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmploeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(DbManager.GetAllEmployees());
        }

        [HttpGet]
        [Route("EmployeeById")]
        public ActionResult Get(int id)
        {
            return new JsonResult(DbManager.EmployeeById(id));
        }

        [HttpGet]
        [Route("HighestSalaryByCity")]
        public ActionResult GetGetHighestSalaryByCity()
        {
            return new JsonResult(DbManager.GetHighestSalaryByCity());
        }

        [HttpGet]
        [Route("emp")]
        public ActionResult GetEmployeesId(EmployeeDTO emp)
        {
            if (DbManager.InsertOneEmployee(new Employee(emp)))
                return Ok(new { status = true, Message = "Succesfully inserted.", Employee = DbManager.EmployeesId(new Employee(emp)) });
            return StatusCode(StatusCodes.Status500InternalServerError, new { status = false, Message = "Failed inserted." });
        }

        [HttpPost]
        [Route("InsertOneEmployee")]
        public ActionResult InsertEmployee(EmployeeDTO emp)
        {
            if (DbManager.InsertOneEmployee(new Employee(emp)))
                return StatusCode(StatusCodes.Status500InternalServerError, new { status = true, Message = "Succesfully inserted." });
            return Ok(new { status = true, Message = "Succesfully inserted." });
        }

        [HttpDelete]
        [Route("DeleteStock/{id}")]
        public IActionResult DeleteStockById(int id)
        {
            var emp = DbManager.EmployeeById(id);
            if (emp == null)
            {
                return BadRequest($"Employee Doesn't exist of id {id}");
            }
            if (DbManager.DeleteEmployeeById(id))
                return StatusCode(StatusCodes.Status202Accepted, new { status = true, Message = "Succesfully deleted." });

            return StatusCode(StatusCodes.Status500InternalServerError, new { Sucess = true, message = "Failed to Delete." });
        }
    }
}