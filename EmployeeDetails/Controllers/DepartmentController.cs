using EmployeeDetails.Data;
using EmployeeDetails.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeDetails.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public DepartmentController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("GetAllDepartmentRecords")]
        public async Task<IActionResult> GetAllRecords()
        {
            var data = _employeeDbContext.departments.ToList();
            if (data.Count() == 0)
            {


                return BadRequest();
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
        public async Task<IActionResult> GetAllRecordsfromID(int id)
        {

            if (id == 0)

            {
                return NotFound();

            }
            else
            {

                var result = _employeeDbContext.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
                if (result == null)
                {

                    return NotFound(id);
                }
                else
                {
                    return Ok(result);

                }

            }
            

        }
        [HttpPost]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("InsertAllDepartmentRecords")]
        public async Task<IActionResult> InsertAllDepartmentRecords([FromBody] Department model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new Department()

                {
                    DepartmentId = model.DepartmentId,  
                    DepartmentNmae = model.DepartmentNmae,
                    EmployeeId = model.EmployeeId,  
                    

                };
                _employeeDbContext.departments.Add(result);
                _employeeDbContext.SaveChanges();
                return Ok(result);
            }

        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("DeletebyDepartmentid")]
        public async Task<IActionResult> DeletebydepartmentId([FromBody] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var Del = _employeeDbContext.departments.Where(x => x.DepartmentId == id).FirstOrDefault();
                _employeeDbContext.departments.Remove(Del); 
                _employeeDbContext.SaveChanges();
                return Ok(Del);

            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [Route("{id}")]   // by default [Route("{id:int"})]
        public async Task<IActionResult> UpdateDepartmentRequest([FromRoute] int id, UpdateDepartmentRequest updatedepartmentRequest)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Department = await _employeeDbContext.departments.FindAsync(id);

            if (Department != null)
            {
                if (updatedepartmentRequest.DepartmentNmae.Length!=0)
                {
                    Department.DepartmentNmae = updatedepartmentRequest.DepartmentNmae; 
                    

                }
                if (updatedepartmentRequest.EmployeeId == 0)
                {
                    Department.EmployeeId = updatedepartmentRequest.EmployeeId;

                }
                
                await _employeeDbContext.SaveChangesAsync();
                return Ok(Department);

            }
            else
            {
                return NotFound();
            }

        }
    }
}
