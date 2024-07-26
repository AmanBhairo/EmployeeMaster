using CivicaEmployeeMaster.Dtos;
using CivicaEmployeeMaster.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CivicaEmployeeMaster.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        public DbSet<PasswordHint> PasswordHints { get; set; }
        public DbSet<SalaryHeadTotalByStoreProcedure> SalaryHeadTotals { get; set; }
        public EntityState GetEntryState<TEntity>(TEntity entity) where TEntity : class
        {
            return Entry(entity).State;
        }

        public void SetEntryState<TEntity>(TEntity entity, EntityState entityState) where TEntity : class
        {
            Entry(entity).State = entityState;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
             .HasOne(d => d.EmployeeDepartment)
             .WithMany(p => p.Employees)
             .HasForeignKey(d => d.DepartmentId)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("FK_Employee_EmployeeDepartment");

            modelBuilder.Entity<SalaryHeadTotalByStoreProcedure>().HasNoKey().ToView(null);
        }

        public virtual IQueryable<SalaryHeadTotalByStoreProcedure> GetEachEmployeeYearlySalarySlip(int employeeId, int Year)
        {
            var varemployeeId = new SqlParameter("@employeeId", employeeId);
            var year = new SqlParameter("@Year", Year);

            return Set<SalaryHeadTotalByStoreProcedure>().FromSqlRaw("dbo.GetEachEmployeeYearlySalarySlip @employeeId, @Year", varemployeeId, year);
        }
        public virtual IQueryable<SalaryHeadTotalByStoreProcedure> GetEmployeeYearlySalarySlip(int Year)
        {
            var year = new SqlParameter("@Year", Year);

            return Set<SalaryHeadTotalByStoreProcedure>().FromSqlRaw("dbo.GetEmployeeYearlySalarySlip @Year", year);
        }
        public virtual IQueryable<SalaryHeadTotalByStoreProcedure> GetTotalSalaryByMonth(int Month,int Year)
        {
            var month = new SqlParameter("@month", Month);

            var year = new SqlParameter("@Year", Year);

            return Set<SalaryHeadTotalByStoreProcedure>().FromSqlRaw("dbo.GetTotalSalaryByMonth @month, @Year", month, year);
        }

        public virtual IQueryable<SalaryHeadTotalByStoreProcedure> GetEachEmpSalaryByMonth(int EmployeeId,int Month, int Year)
        {
            var employeeId = new SqlParameter("@employeeId", EmployeeId);

            var month = new SqlParameter("@month", Month);

            var year = new SqlParameter("@Year", Year);

            return Set<SalaryHeadTotalByStoreProcedure>().FromSqlRaw("dbo.GetEachEmployeeMonthlySalarySlipBySp @employeeId, @month, @Year", employeeId, month, year);
        }
    }
}
