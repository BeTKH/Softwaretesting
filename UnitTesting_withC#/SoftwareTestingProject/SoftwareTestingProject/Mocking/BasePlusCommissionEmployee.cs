
// BasePlusCommissionEmployee class that extends CommissionEmployee.
using System;
using SoftwareTestingProject.Mocking;

public class BasePlusCommissionEmployee : CommissionEmployee
{
   private decimal baseSalary; // base salary per week

   // six-parameter constructor
   public BasePlusCommissionEmployee(string firstName, string lastName,
      string socialSecurityNumber, decimal grossSales,
      decimal commissionRate, decimal baseSalary, Address address)
      : base(firstName, lastName, socialSecurityNumber,
           grossSales, commissionRate, address)
   {
      BaseSalary = baseSalary; // validates base salary
   }

   // property that gets and sets 
   // BasePlusCommissionEmployee's base salary
   public decimal BaseSalary
   {
      get
      {
         return baseSalary;
      }
      set
      {
         if (value < 0) // validation
         {
            throw new ArgumentOutOfRangeException(nameof(value),
               value, $"{nameof(LastName)} must be >= 0");
         }

         baseSalary = value;
      }
   }

   // calculate earnings
   public override decimal Earnings() => BaseSalary + base.Earnings();

   // return string representation of BasePlusCommissionEmployee
   public override string ToString() =>
      $"base-salaried {base.ToString()}\nbase salary: {BaseSalary:C}";
}

