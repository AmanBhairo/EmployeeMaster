using CivicaEmployeeMaster.Dtos;
using CivicaEmployeeMaster.Models;

namespace CivicaEmployeeMaster.Data.Contract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        IEnumerable<Employee> GetPaginatedEmployees(int page, int pageSize, string? search, string sortOrder);
        int TotalEmployees(string? search);
        Employee? GetEmployeeById(int id);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        bool EmployeesExists(int employeeId, string email);

        public bool InsertEmployee(Employee employee);
        public bool EmployeeExist(string email);
        IEnumerable<SalaryHeadTotal> GetTotalSalaryByDepartmentAndYear(int year);
        IEnumerable<SalaryHeadTotal> GetTotalSalaryByYear(int year);
        IEnumerable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByYearByStoreProcedure(int year);
        IEnumerable<SalaryHeadTotal> GetTotalSalaryByMonth(int month, int year);
        IEnumerable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByMonthByStoreProcedure(int month, int year);
        IEnumerable<TotalProfTax> GetTotalProfTaxByMonth(int month, int year);
        IEnumerable<SalaryHeadTotal> GetTotalSalaryByMonthYearAndId(int employeeId,int month, int year);
        IEnumerable<SalaryHeadTotal> GetTotalSalaryByYearAndId(int employeeId, int year);
        IEnumerable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByYearAndIdByStoreProcedure(int employeeId, int year);
        IEnumerable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByMonthYearAndIdByStoreProcedure(int employeeId, int month, int year);
    }
}
