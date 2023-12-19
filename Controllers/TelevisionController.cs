using Microsoft.AspNetCore.Mvc;
using MyTelevisionApi.Data;
using MyTelevisionApi.Model;

namespace MyTelevisionApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TelevisionController : Controller
    {
        private readonly MyTelevisionDBContext context;

        public TelevisionController(MyTelevisionDBContext context)
        { 
            this.context = context; 


        }
        [HttpGet]
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
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("RecordofLaptopupdate")]
        public IActionResult RecordofLaptopupdate([FromBody] MyTelivision model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var tel = context.MyTelivisions.Where(e => e.Id == model.Id).SingleOrDefault();
                if (tel == null)
                {
                    return BadRequest();
                }
                else
                {
                    tel.Name = model.Name;
                    tel.Description = model.Description;
                    tel.color = model.color;

                }


                context.Update(tel);
                context.SaveChanges();
                return Ok(tel);
            }
        }




    }
}
