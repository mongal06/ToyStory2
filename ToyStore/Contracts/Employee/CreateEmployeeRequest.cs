namespace Contracts.Requests
{
    public class CreateEmployeeRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int StoreID { get; set; }
        public string Position { get; set; } = null!;
        public DateTime HireDate { get; set; }
    }
}