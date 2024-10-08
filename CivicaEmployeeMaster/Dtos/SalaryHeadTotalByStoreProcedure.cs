﻿using System.ComponentModel.DataAnnotations;

namespace CivicaEmployeeMaster.Dtos
{
    public class SalaryHeadTotalByStoreProcedure
    {
        //[Key]
        //public int id { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal HRA { get; set; }
        public decimal Allowance { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal PfDeduction { get; set; }
        public decimal ProfTax { get; set; }
        public decimal GrossDeductions { get; set; }
        public decimal TotalSalary { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

    }
}
