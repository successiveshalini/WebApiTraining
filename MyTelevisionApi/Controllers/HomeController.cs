using Microsoft.AspNetCore.Mvc;

namespace MyTelevisionApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IEmployee _employee;

        public HomeController(ILogger<HomeController> logger, IEmployee employee)
        {
            _logger = logger;
            _employee = employee;
        }
        [HttpGet(Name = "HomeController")]
        public IEnumerable<HomeController> Get() 
        {
            _employee.Name = "Patna";
            _employee.Address = "Sharsa";
            _employee.Age = 23;
            return Get();


            

        }
        public IActionResult Index()
        {
            var Emp = new Employee()

            {
                City = _employee.City,
                Name = _employee.Name,
                Address = _employee.Address,    
                Age = _employee.Age,    
            };
            return View(Emp);

              

        }
            
        }
    }

