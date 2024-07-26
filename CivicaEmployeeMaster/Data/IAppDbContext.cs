using CivicaEmployeeMaster.Dtos;
using CivicaEmployeeMaster.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace CivicaEmployeeMaster.Data
{
    public interface IAppDbContext : IDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<PasswordHint> PasswordHints { get; set; }
        public DbSet<SalaryHeadTotalByStoreProcedure> SalaryHeadTotals { get; set; }
        public IQueryable<SalaryHeadTotalByStoreProcedure> GetEachEmployeeYearlySalarySlip(int employeeeId, int Year);
        public IQueryable<SalaryHeadTotalByStoreProcedure> GetEmployeeYearlySalarySlip(int Year);
        public IQueryable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByMonth(int Month, int Year);
        public IQueryable<SalaryHeadTotalByStoreProcedure> GetEachEmpSalaryByMonth(int EmployeeId, int Month, int Year);

    }
}
