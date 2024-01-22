using ConsumeWebApi.Data;
using ConsumeWebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace ConsumeWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductDbContext context;
        public ProductController(ProductDbContext context)
        {
            this.context = context;

        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAllProductRecords()
        {
            var data = context.ProductLists.ToList();


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
        [Route("GetAllProductRecordsfromID/{ID}")]
        public IActionResult GetAllProductRecordsfromID(int ID)
        {

            if (ID == 0)

            {
                return NotFound();

            }
            else
            {

                var result = context.ProductLists.Where(e => e.Id == ID).SingleOrDefault();
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
        [Route("InsertAllProductRescords")]
        public IActionResult InsertAllRescords([FromBody] ProductList model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new ProductList()
                {
                    ProductNmae = model.ProductNmae,
                    Price = model.Price,
                    Quantities = model.Quantities,
                };
                context.ProductLists.Add(result);
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
                var pro = context.ProductLists.Where(e => e.Id == id).SingleOrDefault();
                context.ProductLists.Remove(pro);
                context.SaveChanges();
                return Ok(pro);

            }

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        
        //[Route("{id}")]   // by default [Route("{id:int"})]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequest updateProductRequest)  // updateStudentRequest contains the fields which will be given by the user 
        {
            var Product = await context.ProductLists.FindAsync(id);

            if (Product != null)
            {
                if (updateProductRequest.ProductNmae.Length != 0)
                {
                    Product.ProductNmae = updateProductRequest.ProductNmae;

                }
                if (updateProductRequest.Price == 0)
                {
                    Product.Price = updateProductRequest.Price; 
                }
                if (updateProductRequest.Quantities == 0)
                {
                    Product.Quantities = updateProductRequest.Quantities;   

                }
                await context.SaveChangesAsync();
                return Ok(Product);

            }
            else
            {
                return NotFound();
            }

        }
    }
}
