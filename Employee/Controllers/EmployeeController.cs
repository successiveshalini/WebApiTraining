using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewCrudOperationApi.Data;
using NewCrudOperationApi.Model;

namespace NewCrudOperationApi.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("/[controller]")]
    [ApiController]
    public class TelevisionController : Controller
    {
        private readonly EmployeeDbContext _mployeeDbContext;
        public TelevisionController(EmployeeDbContext employeeDbContext)
        {
            
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllRecords")]
        public IActionResult GetAllRecords()
        {
            var data = context.MyTelivisions.ToList();


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
        [Route("GetAllRecordsfromID/{ID}")]
        public IActionResult GetAllRecordsfromID(int ID)
        {

            if (ID == 0)

            {
                return NotFound();

            }
            else
            {

                var result = context.MyTelivisions.Where(e => e.Id == ID).SingleOrDefault();
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
        [Route("InsertAllRescords")]
        public IActionResult InsertAllRescords([FromBody] MyTelivision model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new MyTelivision()
                {


                    Name = model.Name,
                    Description = model.Description,
                    color = model.color
                };
                context.MyTelivisions.Add(result);
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
                var del = context.MyTelivisions.Where(e => e.Id == id).SingleOrDefault();
                context.MyTelivisions.Remove(del);
                context.SaveChanges();
                return Ok(del);

            }

        }

    }
    
