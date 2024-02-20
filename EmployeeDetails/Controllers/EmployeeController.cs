using EmployeeDetails.Data;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeDetails.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController (EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllEmployeeRecords")]
        public async Task<IActionResult> GetAllEmployeeRecords()
        {
            var data = _employeeDbContext.employees.ToList();
            if (data.Count() == 0)
            {


                return NotFound();
            }
            else
            { 
                return Ok(data);    
            }
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllRecordsfromid/{id}")]
        public async Task <IActionResult> GetAllRecordsfromID(int id)
        {

            if (id == 0)

            {
                return NotFound();

            }
            else
            {

                var result = _employeeDbContext.employees.Where(x => x.id == id).FirstOrDefault();
                if (result == null)
                {

                    return BadRequest();
                }
                else
                {
                    return Ok(result);

                }

            }
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("InsertAllEmployeeRecords")]
        public async Task<IActionResult> InsertAllEmployeeRecords([FromBody] Employee model )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new Employee()

                {
                    Nmae = model.Nmae,  
                    Email = model.Email,    
                    department = model.department,

                };
                _employeeDbContext.employees.Add(result);
                _employeeDbContext.SaveChanges();
                return Ok(result);
            }

        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("DeletebyEmployeeid")]
        public async Task< IActionResult> DeletebyEmployeeid([FromBody] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var Del = _employeeDbContext.employees.Where(x => x.id == id).SingleOrDefault();
                _employeeDbContext.employees.Remove(Del);
                _employeeDbContext.SaveChanges();
                return Ok(Del);

            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [Route("{id}")]   // by default [Route("{id:int"})]
        public async Task<IActionResult> UpdateEmployeeRequest([FromRoute] int id, UpdateEmployeeRequest updateemployeeRequest)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Employee = await _employeeDbContext.employees.FindAsync(id);

            if (Employee != null)
            {
                if (updateemployeeRequest.Nmae.Length != 0)
                {
                    Employee.Nmae = updateemployeeRequest.Nmae; 

                }
                if (updateemployeeRequest.Email != null)
                {
                    Employee.Email = updateemployeeRequest.Email;
                    

                }
                if (updateemployeeRequest.department.Length != 0)
                { 
                    Employee.department = updateemployeeRequest.department; 

                }

                await _employeeDbContext.SaveChangesAsync();
                return Ok(Employee);

            }
            else
            {
                return NotFound();
            }

        }
    }




}

