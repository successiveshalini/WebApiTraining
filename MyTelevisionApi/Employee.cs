namespace MyTelevisionApi
{
    public interface IEmployee
    {
        public string? City { get; set; }    
        public string? Name { get; set; }
        public string Description { get; set; }
        public string? Address { get; set; }
        public int Age { get; set; }
    }
    public class Employee:IEmployee
    {
        public string? City { get; set; }    
        public string? Name { get; set; }

        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string? Address { get; set; }
        public int Age { get; set; }
    }
}
