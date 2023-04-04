using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareTestingProject.DependencyInjection
{
    public class TaxCalculator2: ITaxCalculator
    {
        private int taxableIncome;

        // constructor
        TaxCalculator2(int taxableIncome_)
        {
            this.taxableIncome = taxableIncome_;
        }

        // method
        override
        public double CalculateTax()
        {
            return taxableIncome * 0.15;
        }
    }
}
