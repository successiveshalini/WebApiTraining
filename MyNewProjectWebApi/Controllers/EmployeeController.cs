using Microsoft.AspNetCore.Mvc;
using MyNewProjectApi.Data;
using MyNewProjectApi.Model;
using System.Collections.Concurrent;
using System.Net.Cache;
using System.Numerics;

namespace MyNewProjectApi.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext context;
        public EmployeeController(EmployeeDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllEmployeeRecords")]
        public IActionResult GetAllEmployeeRecord()
        {
            var data = context.EmployeeDetails.ToList();


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
        [Route("GetAllEmployeeRecordsfromID/{ID}")]
        public IActionResult GetAllEmployeeRecordsfromID(int ID)
        {

            if (ID == 0)

            {
                return NotFound();

            }
            else
            {

                var result = context.EmployeeDetails.Where(e => e.EmployeeId == ID).SingleOrDefault();
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
        [Route("InsertAllEmployeeRescords")]
        public IActionResult InsertAllEmployeeRescords([FromBody] EmployeeDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new EmployeeDetails()
                {


                    Name = model.Name,
                    Age = model.Age,
                    EmailAddress = model.EmailAddress,
                    Amount = model.Amount,
                    Address = model.Address,

                };
                context.EmployeeDetails.Add(result);
                context.SaveChanges();
                return Ok(result);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status100Continue)]
        [Route("DeletebyID")]
        public IActionResult DeletebyID([FromBody] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var Emp = context.EmployeeDetails.Where(e => e.EmployeeId == id).SingleOrDefault();
                context.EmployeeDetails.Remove(Emp);
                context.SaveChanges();
                return Ok(Emp);

            }

        }
        [HttpPut]
        [Route("{Id}")]   // by default [Route("{id:int"})]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<IActionResult> UpdateEmployeeRecord([FromRoute] int id, [FromBody] UpdateEmployeeRecord UpdateEmployeeRecord)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Employee = await context.EmployeeDetails.FindAsync(id);
            decimal currentAmount = Employee.Amount;
            int currentAge = (int)Employee.Age;
            if (Employee != null)
            {
                if (UpdateEmployeeRecord.Name.Length != 0)
                { 
                    Employee.Name = UpdateEmployeeRecord.Name;  

                }
                if (UpdateEmployeeRecord.EmailAddress.Length != 0)
                {
                    Employee.EmailAddress = UpdateEmployeeRecord.EmailAddress;

                }
                if (UpdateEmployeeRecord.Amount == 0)
                {
                    Employee.Amount = currentAmount;

                }
                else
                { 
                    Employee.Amount = UpdateEmployeeRecord.Amount;  
                }
                if (UpdateEmployeeRecord.Address.Length != 0)
                {
                    Employee.Address = UpdateEmployeeRecord.Address;

                }
                if (UpdateEmployeeRecord.Age == 0)
                {
                    Employee.Age = currentAge;

                }
                else
                { 
                    Employee.Age = UpdateEmployeeRecord.Age;    
                }

                return Ok(Employee);
            }
            else
            {
                return NotFound();
            }

        }
    }
}

