using EmployeeDetails.Data;
using EmployeeDetails.Model;
using EmployeeDetails.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetails.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    
    public class ProductController : Controller
    {
        private readonly IProductRepository1 _productRepository;
   
        

        public ProductController(IProductRepository1 productRepository)
        { 
            _productRepository = productRepository;
          




        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("InsertAllProductRecords")]
        public async Task<IActionResult> InsertAllProductRecords([FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new ProductModel()
                {
                    ProductName = model.ProductName,    
                    ProductDescription = model.ProductDescription,  
                    Productprice = model.Productprice,  

                };
                _productRepository.AddProduct(result);
              
                return Ok(result);
            }

        }


    }
            

            
        
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[HttpGet("")]
        
        //public IActionResult GetName()
        //{
        //    var name = _productRepository.GetName();
        //    return Ok(name);
          
            
        //}
    }

