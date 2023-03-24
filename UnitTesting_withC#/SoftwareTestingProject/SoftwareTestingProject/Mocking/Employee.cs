
// Employee abstract base class.
using System.Net.Sockets;
namespace SoftwareTestingProject.Mocking
{
    public abstract class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SocialSecurityNumber { get; }
        public Address HomeAddress { get; set; }

        // three-parameter constructor
        public Employee(string firstName, string lastName,
           string socialSecurityNumber, Address _address)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            HomeAddress= _address;
        }

        // return string representation of Employee object, using properties
        public override string ToString() => $"{FirstName} {LastName}\n" +
           $"social security number: {SocialSecurityNumber}";

        // abstract method overridden by derived classes
        public abstract decimal Earnings(); // no implementation here
    }

}