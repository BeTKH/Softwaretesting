
// SalariedEmployee class that extends Employee.
using System;
using SoftwareTestingProject.Mocking;

public class SalariedEmployee : Employee
{
   private decimal weeklySalary;

   // four-parameter constructor
   public SalariedEmployee(string firstName, string lastName,
      string socialSecurityNumber, decimal weeklySalary,Address _address)
      : base(firstName, lastName, socialSecurityNumber, _address)
   {
      WeeklySalary = weeklySalary; // validate salary via property
   }

   // property that gets and sets salaried employee's salary
   public decimal WeeklySalary
   {
      get
      {
         return weeklySalary;
      }
      set
      {
         if (value < 0) // validation
         {
            throw new ArgumentOutOfRangeException(nameof(value),
               value, $"{nameof(WeeklySalary)} must be > 0");
         }

         weeklySalary = value;
      }
   }

   // calculate earnings; override abstract method Earnings in Employee
   public override decimal Earnings() => WeeklySalary;

   // return string representation of SalariedEmployee object
   public override string ToString() =>
      $"salaried employee: {base.ToString()}\n" +
      $"weekly salary: {WeeklySalary:C}";
}

