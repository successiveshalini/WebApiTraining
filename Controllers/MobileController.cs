using Microsoft.AspNetCore.Mvc;
using MyMobileApi1.Data;
using MyMobileApi1.Model;

namespace MyMobileApi1.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class MobileController:ControllerBase
    {
        private MobileDetailsDBContext context;

        public MobileController(MobileDetailsDBContext context)
        { 
            this.context = context; 
        }
        [HttpGet]
        [Route("GetAllRecords")]
        public IActionResult GetAllRecords()
        { 
            var data = context.MobileDetails.ToList();
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
        [Route("GetAllREcordsfromID/{ID}")]
        public IActionResult GetAllRecordsfromID(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var result = context.MobileDetails.Where(e => e.Id == id).SingleOrDefault();
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
        [ProducesResponseType(StatusCodes.Status302Found)]
        [Route("InsertAllRecord")]
        public IActionResult InsertAllRescors([FromBody] MobileDetails model)
           {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new MobileDetails()
                {
                    
                    Name = model.Name,
                    Description = model.Description,
                    price = model.price,
                    color = model.color,    
                };
                context.MobileDetails.Add(result);
                context.SaveChanges();
                return Ok(result);
            }
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("DeletebyID")]
        public IActionResult DeletebyID([FromRoute] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var del = context.MobileDetails.Where(e => e.Id == id).SingleOrDefault();
                context.MobileDetails.Remove(del);
                context.SaveChanges();
                return Ok(del);

            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("Recordofmobileupdate")]
        public IActionResult Recordofmobileupdate([FromBody] MobileDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var mob = context.MobileDetails.Where(e => e.Id == model.Id).SingleOrDefault();
                if (mob == null)
                {
                    return BadRequest();
                }
                else
                {
                    mob.Name = model.Name;
                    mob.Description = model.Description;
                    mob.price = model.price;
                    mob.color = model.color;

                }

                context.Update(mob);
                context.SaveChanges();
                return Ok(mob);
            }
        }
        [HttpPut]
        [Route("Updatebyid")]
        public IActionResult Updatebyid([FromBody] MobileDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var mob = context.MobileDetails.Where(e => e.Id == model.Id).SingleOrDefault();
                if (mob == null)
                {
                    return BadRequest();
                }
                else
                {
                    mob.Name = model.Name;
                    mob.Description = model.Description;
                    mob.price = model.price;
                    mob.color = model.color;


                }
                context.Update(mob);
                context.SaveChanges();
                return Ok(mob);
            }
        }



    }
}
