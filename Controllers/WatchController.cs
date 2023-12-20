using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWatchApi.Data;
using MyWatchApi.Model;
using System.Security.Cryptography.X509Certificates;

namespace MyWatchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private WatchDetailsDBContext context;

        public WatchController(WatchDetailsDBContext context)
        { 
            this.context = context; 

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllRecords")]
        public IActionResult GetAllRecords()
        {
            var data = context.watchDetails.ToList();
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
        [Route("GetAllRecordsformID/{ID}")]
        public IActionResult GetAllRecordsformID(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var result = context.watchDetails.Where(e => e.Id == id).SingleOrDefault();
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
        [Route("alpha/{name}")]
        public IActionResult InsertAllRecords([FromBody] WatchDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new WatchDetails()
                {
                    Name = model.Name,  
                    Description = model.Description,    
                    Price = model.Price,
                    Color = model.Color,  
                };
                context.watchDetails.Add(result);
                context.SaveChanges();
                return Ok(result);
            }

        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("DeletebyID")]
        public IActionResult DeletebyID([FromBody] int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else
            {
                var del = context.watchDetails.Where(e => e.Id == id).SingleOrDefault();
                context.watchDetails.Remove(del);
                context.SaveChanges();
                return Ok(del);

            }

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("RecordofWatchupdate")]
        public IActionResult RecordofWatchupdate([FromBody] WatchDetails model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var wat = context.watchDetails.Where(e => e.Id == model.Id).SingleOrDefault();
                if (wat == null)
                {
                    return BadRequest();
                }
                else
                {
                    wat.Name = model.Name;  
                    wat.Description = model.Description;  
                    wat.Price = model.Price;
                    wat.Color = model.Color;     

                }
                context.Update(wat);
                context.SaveChanges();
                return Ok(wat);
            }
        }

    }
}
