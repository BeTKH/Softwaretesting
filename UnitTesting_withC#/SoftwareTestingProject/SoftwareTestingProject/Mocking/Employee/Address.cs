using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Address
    {
        public string House { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Address(string _street, string _city, string _state, string _zipCode, string _house)
        {
            House = _house;
            Street = _street;
            City = _city;
            State = _state;
            ZipCode = _zipCode;

        }
        public override string ToString()
        {
            return string.Format("{0} { 1}; {2}; {3}; {4}", House,Street,City,State,ZipCode);
        }
    }

