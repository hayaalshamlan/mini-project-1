namespace WebApplication1.Models
{
    public class BankBranch
    {
      
        public string Name { get; set; }
        public string LocationURL { get; set; }
        public string LocationName { get; set; }
        public string BranchManager { get; set; }
        public int EmployeeCount { get; set; }
        public int Id { get; set; }

        public List<Employee> Employees { get; set; } = new();
    }
}
