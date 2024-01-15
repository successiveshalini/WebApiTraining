﻿using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]   // by default [Route("{id:int"})]
        public async Task<IActionResult> UpdateTelevision([FromRoute] int id, UpdateTelevisionRequest updateTelevisionRequest)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Television = await context.MyTelivisions.FindAsync(id);
            if (Television != null)
            {
                if (updateTelevisionRequest.Name.Length != 0)
                {
                    Television.Name = updateTelevisionRequest.Name;

                }
                if (updateTelevisionRequest.Description.Length != 0)
                {
                    Television.Description = updateTelevisionRequest.Description;
                }
                if (updateTelevisionRequest.color.Length != 0)
                {
                    Television.color = updateTelevisionRequest.color;

                }
                await context.SaveChangesAsync();
                return Ok(Television);

            }
            else
            { 
                return NotFound();  
            }

        }
    }
}
