using static Core.Domain.Enums;

namespace Core.Domain
{
    public class Employee : BaseEntity
    {
        public string? EmployeeName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<DocumentUpload>? DocumentUploads { get; set; }

        public SalaryTypeEnum salaryType { get; set; }
        public bool IsBankSalary { get; set; }

        public ICollection<EmployeeBankAccount>? EmployeeBankAccounts { get; set; }
    }
}
