namespace Core.Domain
{
    public class EmployeeBankAccount : BaseEntity
    {
        public string? AccountHolderName { get; set; }
        public string? AccountNumber { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? IFSCCode { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
