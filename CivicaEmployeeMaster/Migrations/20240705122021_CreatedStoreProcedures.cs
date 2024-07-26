using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CivicaEmployeeMaster.Migrations
{
    public partial class CreatedStoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetEachEmployeeYearlySalarySlip
	@employeeId INT,
    @Year INT
AS
BEGIN
 
    SET NOCOUNT ON;
    DECLARE @CurrentMonth INT = MONTH(GETDATE());
	IF @year > YEAR(GETDATE())
    BEGIN
        SELECT NULL AS TotalSalary, NULL AS TotalSalary, NULL AS GrossSalary,NULL AS PfDeduction,NULL AS Allowance, NULL AS GrossDeductions, NULL AS HRA, NULL AS ProfTax 
    END
    ELSE
    SELECT
        e.Id,
		CASE WHEN YEAR(GETDATE()) > @Year THEN 12 
		ELSE @CurrentMonth
		END AS Month,
        YEAR(e.DateOfJoining) AS [Year],
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.TotalSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.TotalSalary * @CurrentMonth
                ELSE e.TotalSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS TotalSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.BasicSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.BasicSalary * @CurrentMonth
                ELSE e.BasicSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS BasicSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossSalary * @CurrentMonth
                ELSE e.GrossSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.PfDeduction * 12 
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.PfDeduction * @CurrentMonth
                ELSE e.PfDeduction * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS PfDeduction,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.Allowance * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.Allowance * @CurrentMonth
                ELSE e.Allowance * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS Allowance,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossDeductions * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossDeductions * @CurrentMonth
                ELSE e.GrossDeductions * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossDeductions,  
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.HRA * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.HRA * @CurrentMonth
                ELSE e.HRA * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS HRA,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.ProfTax * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.ProfTax * @CurrentMonth
                ELSE e.ProfTax * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS ProfTax
    FROM
        Employees e
    WHERE
        e.Id = @employeeId AND YEAR(e.DateOfJoining) <= @Year
    GROUP BY
        e.Id, YEAR(e.DateOfJoining)
    ORDER BY
        [Year];
END
            ");
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetEmployeeYearlySalarySlip
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @CurrentMonth INT = MONTH(GETDATE());
	IF @year > YEAR(GETDATE())
    BEGIN
        SELECT NULL AS TotalSalary, NULL AS TotalSalary, NULL AS GrossSalary,NULL AS PfDeduction,NULL AS Allowance, NULL AS GrossDeductions, NULL AS HRA, NULL AS ProfTax 
    END
    ELSE
    SELECT
        e.Id,
        YEAR(e.DateOfJoining) AS [Year],
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.TotalSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.TotalSalary * @CurrentMonth
                ELSE e.TotalSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS TotalSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.BasicSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.BasicSalary * @CurrentMonth
                ELSE e.BasicSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS BasicSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossSalary * @CurrentMonth
                ELSE e.GrossSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.PfDeduction * 12 
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.PfDeduction * @CurrentMonth
                ELSE e.PfDeduction * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS PfDeduction,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.Allowance * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.Allowance * @CurrentMonth
                ELSE e.Allowance * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS Allowance,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossDeductions * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossDeductions * @CurrentMonth
                ELSE e.GrossDeductions * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossDeductions,  
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.HRA * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.HRA * @CurrentMonth
                ELSE e.HRA * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS HRA,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.ProfTax * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.ProfTax * @CurrentMonth
                ELSE e.ProfTax * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS ProfTax
    FROM
        Employees e
    WHERE
        YEAR(e.DateOfJoining) <= @Year
    GROUP BY
        e.Id, YEAR(e.DateOfJoining)
    ORDER BY
        [Year];
END
                ");
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetTotalSalaryByMonth
    @month INT,
    @year INT
AS
BEGIN
    SET NOCOUNT ON;
 
    IF EXISTS (
        SELECT 1
        FROM Employees e
        WHERE YEAR(e.DateOfJoining) <= @year 
          AND (MONTH(e.DateOfJoining) <= @month OR YEAR(e.DateOfJoining) < @year)
    )
    BEGIN
        SELECT 
            @year AS Year,
            @month AS Month,
            SUM(e.TotalSalary) AS TotalSalary,
            SUM(e.BasicSalary) AS BasicSalary,
            SUM(e.GrossSalary) AS GrossSalary,
            SUM(e.PfDeduction) AS PfDeduction,
            SUM(e.Allowance) AS Allowance, 
            SUM(e.GrossDeductions) AS GrossDeductions,
            SUM(e.HRA) AS HRA,
            SUM(e.ProfTax) AS ProfTax
        FROM 
            Employees e
        WHERE 
            YEAR(e.DateOfJoining) <= @year 
            AND (MONTH(e.DateOfJoining) <= @month OR YEAR(e.DateOfJoining) < @year)
    END
    ELSE
    BEGIN
        -- Return an empty result set
        SELECT 
            @year AS Year,
            @month AS Month,
            NULL AS TotalSalary,
            NULL AS BasicSalary,
            NULL AS GrossSalary,
            NULL AS PfDeduction,
            NULL AS Allowance, 
            NULL AS GrossDeductions,
            NULL AS HRA,
            NULL AS ProfTax
        WHERE 1 = 0; -- This condition ensures no rows are returned
    END
END
                ");
            migrationBuilder.Sql(@"
                CREATE OR ALTER PROCEDURE GetEachEmployeeMonthlySalarySlipBySp
	@employeeId INT,
    @Year INT,
	@Month INT
AS
BEGIN
 
    SET NOCOUNT ON;
    DECLARE @CurrentMonth INT = MONTH(GETDATE());
	IF @year > YEAR(GETDATE()) or (@year >= YEAR(GETDATE()) AND @Month >Month(GETDATE()))
    BEGIN
        SELECT NULL AS TotalSalary, NULL AS TotalSalary, NULL AS GrossSalary,NULL AS PfDeduction,NULL AS Allowance, NULL AS GrossDeductions, NULL AS HRA, NULL AS ProfTax 
    END
    ELSE
    SELECT
        e.Id,
		CASE WHEN YEAR(GETDATE()) > @Year THEN 12 
		ELSE @CurrentMonth
		END AS Month,
        YEAR(e.DateOfJoining) AS [Year],
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.TotalSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.TotalSalary * @CurrentMonth
                ELSE e.TotalSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS TotalSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.BasicSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.BasicSalary * @CurrentMonth
                ELSE e.BasicSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS BasicSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossSalary * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossSalary * @CurrentMonth
                ELSE e.GrossSalary * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossSalary,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.PfDeduction * 12 
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.PfDeduction * @CurrentMonth
                ELSE e.PfDeduction * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS PfDeduction,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.Allowance * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.Allowance * @CurrentMonth
                ELSE e.Allowance * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS Allowance,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.GrossDeductions * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.GrossDeductions * @CurrentMonth
                ELSE e.GrossDeductions * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS GrossDeductions,  
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.HRA * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.HRA * @CurrentMonth
                ELSE e.HRA * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS HRA,
        SUM(CASE
                WHEN YEAR(GETDATE()) > @Year THEN e.ProfTax * 12  
                WHEN DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1 > 12 THEN e.ProfTax * @CurrentMonth
                ELSE e.ProfTax * (DATEDIFF(MONTH, e.DateOfJoining, GETDATE()) + 1)
            END) AS ProfTax
    FROM
        Employees e
    WHERE
        e.Id = @employeeId AND YEAR(e.DateOfJoining) <= @Year AND MONTH(e.DateOfJoining) <=@Month
    GROUP BY
        e.Id, YEAR(e.DateOfJoining)
    ORDER BY
        [Year];
END
            ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetEachEmployeeYearlySalarySlip");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetEmployeeYearlySalarySlip");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetTotalSalaryByMonth");
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS GetEachEmployeeMonthlySalarySlipBySp");
        }
    }
}
