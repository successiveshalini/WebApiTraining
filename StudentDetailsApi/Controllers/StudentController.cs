using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SimpleWebApiProject.Data;
using SimpleWebApiProject.Model;

namespace SimpleWebApiProject.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentDbContext context;
        public StudentController(StudentDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllDetails")]
        public IActionResult GetAllRecords()
        {
            var data = context.StudentDetails.ToList();


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
        [Route("GetAllStudentDetailsfromID/{ID}")]
        public IActionResult GetAllStudentRecordsfromID(int ID)
        {

            if (ID == 0)

            {
                return NotFound();

            }
            else
            {

                var result = context.StudentDetails.Where(e => e.StudentId == ID).SingleOrDefault();
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
        [Route("InsertAllStudentDetails")]
        public IActionResult InsertAllRescords([FromBody] StudentDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new StudentDetails()
                {
                    Name = model.Name,
                    Age = model.Age,
                    EmailAddress = model.EmailAddress,
                    Phone = model.Phone,
                    Address = model.Address,
                };
                context.StudentDetails.Add(result);
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
                var stu = context.StudentDetails.Where(e => e.StudentId == id).SingleOrDefault();
                context.StudentDetails.Remove(stu);
                context.SaveChanges();
                return Ok(stu);

            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]   
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, UpdateStudentRequest updateStudentRequest)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Student = await context.StudentDetails.FindAsync(id);
            long CurrentPhone = Student.Phone;
            int Age = Student.Age;

            if (Student != null)
            {
                if (updateStudentRequest.Name.Length != 0)
                {
                    Student.Name = updateStudentRequest.Name;


                }
                if (updateStudentRequest.EmailAddress.Length != 0)
                {
                    Student.EmailAddress = updateStudentRequest.EmailAddress;

                }
                if (updateStudentRequest.Address.Length != 0)
                {
                    Student.Address = updateStudentRequest.Address;

                }
                if (updateStudentRequest.Phone == 0)
                {
                    Student.Phone = CurrentPhone;
                }
                else
                {
                    Student.Phone = updateStudentRequest.Phone;
                }
                if (updateStudentRequest.Age == 0)
                {
                    Student.Age = Age;

                }
                else
                {
                    Student.Age = updateStudentRequest.Age;
                }
                await context.SaveChangesAsync();   
                return Ok(Student);

            }
            else
            {
                return Ok(Student);
            }
        }
    }
}
