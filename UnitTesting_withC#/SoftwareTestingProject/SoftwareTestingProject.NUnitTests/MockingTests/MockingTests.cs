using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using System;
using SoftwareTestingProject.Mocking;
using Assert = NUnit.Framework.Assert;

namespace UnitTestEmployee
{
    [TestClass]
    public class EmployeeUnitTest
    {
        [TestMethod]//T1
        public void TestEmployeeObj()
        {

            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            Employee mockEmp = Mock.Create<Employee>("John", "Schmidt", "123 - 234 - 2345", addr_);

            

            Assert.AreEqual("John", mockEmp.FirstName);
            Assert.AreEqual("Schmidt", mockEmp.LastName);
            Assert.AreEqual("123 - 234 - 2345", mockEmp.SocialSecurityNumber);
            Assert.AreEqual(addr_, mockEmp.HomeAddress);
        }


        [TestMethod]//T2
        public void TestEmployeeToString()
        {

            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            Employee employee = Mock.Create<Employee>("John", "Schmidt", "123 - 234 - 2345", addr_);

            string expectedValue = $"John Schmidt\nsocial security number: 123 - 234 - 2345";
            Assert.AreEqual(expectedValue, employee.ToString());
        }

        [TestMethod]//T3
        public void TestAddressObj()
        {

            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");

            Assert.AreEqual("35th Str", addr_.Street);
            Assert.AreEqual("Fargo", addr_.City);
            Assert.AreEqual("ND", addr_.State);
            Assert.AreEqual("58104", addr_.ZipCode);
            Assert.AreEqual("2900", addr_.House);
        }


       

        [TestMethod] //T5
        public void TestSalariedEmployeeObj()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            SalariedEmployee mockSalEmp = Mock.Create<SalariedEmployee>("John", "Schmidt", "123 - 234 - 2345", 1200m, addr_);

            Assert.AreEqual("John", mockSalEmp.FirstName);
            Assert.AreEqual("Schmidt", mockSalEmp.LastName);
            Assert.AreEqual("123 - 234 - 2345", mockSalEmp.SocialSecurityNumber);
            Assert.AreEqual(1200m, mockSalEmp.WeeklySalary);
            Assert.AreEqual(addr_, mockSalEmp.HomeAddress);
        }


        [TestMethod] //T6
        public void TestSalariedEmployeeF1()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            SalariedEmployee mockSalEmp = Mock.Create<SalariedEmployee>("John", "Schmidt", "123 - 234 - 2345", 1200m, addr_);

            try
            {
                mockSalEmp.WeeklySalary = -1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("WeeklySalary must be > 0"));
            }
        }

        [TestMethod]//T7
        public void TestSalariedEmpToString()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            SalariedEmployee mockSalEmp = Mock.Create<SalariedEmployee>("John", "Schmidt", "123 - 234 - 2345", 1200m, addr_);

            string expectedValue = $"salaried employee: John Schmidt\nsocial security number: 123 - 234 - 2345\nweekly salary: $1,200.00";
            Assert.AreEqual(expectedValue, mockSalEmp.ToString());
        }

        [TestMethod] //T8
        public void TestHourlyEmployeeObject()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            HourlyEmployee mockHrlyEmp = Mock.Create<HourlyEmployee>("John", "Schmidt", "123 - 234 - 2345", 27m, 44m, addr_);

            Assert.AreEqual("John", mockHrlyEmp.FirstName);
            Assert.AreEqual("Schmidt", mockHrlyEmp.LastName);
            Assert.AreEqual("123 - 234 - 2345", mockHrlyEmp.SocialSecurityNumber);
            Assert.AreEqual(27m, mockHrlyEmp.Wage);
            Assert.AreEqual(44m, mockHrlyEmp.Hours);
        }

        [TestMethod]//T9
        public void TestHourlyEmployeeF1()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            HourlyEmployee mockHrlyEmp = Mock.Create<HourlyEmployee>("John", "Schmidt", "123 - 234 - 2345", 27m, 44m, addr_);

            try
            {
                mockHrlyEmp.Wage = -1.0m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Wage must be >= 0"));
            }
        }

        [TestMethod]//T10
        public void TestHourlyEmployeeF2()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            HourlyEmployee mockHrlyEmp = Mock.Create<HourlyEmployee>("John", "Schmidt", "123 - 234 - 2345", 27m, 44m, addr_);

            try
            {
                mockHrlyEmp.Hours = -1m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Hours must be >= 0"));
            }
        }

        [TestMethod] //T11
        public void TestHourlyEmployeeF3()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            HourlyEmployee mockHrlyEmp = Mock.Create<HourlyEmployee>("John", "Schmidt", "123 - 234 - 2345", 27m, 44m, addr_);

            try
            {
                mockHrlyEmp.Hours = 169m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("Hours must be >= 0 and <= 168"));
            }
        }

        [TestMethod] //T12
        public void TestHourlyEmployeeToString()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            HourlyEmployee mockHrlyEmp = Mock.Create<HourlyEmployee>("John", "Schmidt", "123 - 234 - 2345", 27m, 44m, addr_);

            string expectedValue = $"hourly employee: John Schmidt\nsocial security number: 123 - 234 - 2345\nhourly wage: $27.00\nhours worked: 44.00";
            Assert.AreEqual(expectedValue, mockHrlyEmp.ToString());
        }

        [TestMethod] //T13
        public void comissionEmployeeObj()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            Assert.AreEqual("John", mockComEmp.FirstName);
            Assert.AreEqual("Schmidt", mockComEmp.LastName);
            Assert.AreEqual("123 - 234 - 2345", mockComEmp.SocialSecurityNumber);
            Assert.AreEqual(70000m, mockComEmp.GrossSales);
            Assert.AreEqual(0.15m, mockComEmp.CommissionRate);
        }

        [TestMethod] //T14
        public void ComissionEmployeeF1()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            try
            {
                mockComEmp.GrossSales = -1;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("GrossSales must be >= 0"));
            }
        }

        [TestMethod] //T15
        public void ComissionEmployeeF2()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            try
            {
                mockComEmp.CommissionRate = 1.1m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("CommissionRate must be > 0 and < 1"));
            }
        }


        [TestMethod] //T16
        public void ComissionEmployeeF3()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            try
            {
                mockComEmp.CommissionRate = 1.9m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("CommissionRate must be > 0 and < 1"));
            }
        }


        [TestMethod] //T17 - false comission rate = 0
        public void ComissionEmployeeF4()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            try
            {
                mockComEmp.CommissionRate = 0.0m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("CommissionRate must be > 0 and < 1"));
            }
        }

        [TestMethod] //T18 - false comission rate < 0
        public void ComissionEmployeeF5()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            try
            {
                mockComEmp.CommissionRate = -0.15m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(ex.Message.Contains("CommissionRate must be > 0 and < 1"));
            }
        }


        [TestMethod] //T19 
        public void ComissionEmployeeToString()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            CommissionEmployee mockComEmp = Mock.Create<CommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, addr_);

            string expectedValue = $"commission employee: John Schmidt\nsocial security number: 123 - 234 - 2345\ngross sales: $70,000.00\ncommission rate: 0.15";
            Assert.AreEqual(expectedValue, mockComEmp.ToString());
        }

        [TestMethod] //T20
        public void BasePlusComissionEmployeeObj()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            BasePlusCommissionEmployee mockBasePlusComEmp = Mock.Create<BasePlusCommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, 5000m, addr_);

            Assert.AreEqual("John", mockBasePlusComEmp.FirstName);
            Assert.AreEqual("Schmidt", mockBasePlusComEmp.LastName);
            Assert.AreEqual("123 - 234 - 2345", mockBasePlusComEmp.SocialSecurityNumber);
            Assert.AreEqual(70000m, mockBasePlusComEmp.GrossSales);
            Assert.AreEqual(0.15m, mockBasePlusComEmp.CommissionRate);
            Assert.AreEqual(5000m, mockBasePlusComEmp.BaseSalary);


        }

    

        [TestMethod] //T22
        public void BasePlusComissionEmployeeToString()
        {
            Address addr_ = new Address("35th Str", "Fargo", "ND", "58104", "2900");
            BasePlusCommissionEmployee mockBasePlusComEmp = Mock.Create<BasePlusCommissionEmployee>("John", "Schmidt", "123 - 234 - 2345", 70000m, 0.15m, 5000m, addr_);

            string expVal = $"base-salaried commission employee: John Schmidt\nsocial security number: 123 - 234 - 2345\ngross sales: $70,000.00\ncommission rate: 0.15\nbase salary: $5,000.00";
            Assert.AreEqual(expVal, mockBasePlusComEmp.ToString());
        }
    }
}
