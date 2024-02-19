using System.ComponentModel.DataAnnotations;

namespace NewCrudOperationApi.Model
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }   
        public string? Email { get; set; }
        public string? Designation {  get; set; }    
        public string? Department { get; set; }
    }
}
