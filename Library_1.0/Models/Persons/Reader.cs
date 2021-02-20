using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Models.Persons
{
    enum ReaderRate{
        Neutral,
        Fail,
        Satisfactory,
        Good,
        Very_Good,
        Excellent
    }
    class Reader : Human
    {
        private string _email;
        private string _phone;
        public string Address { get; set; }
        public ReaderRate Rate { get; set; }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (new Regex(@"^[^@]{3,}@[^@]{3,}$").IsMatch(value))
                    _email = value;
                else
                    throw new Exception("Email address is invalid");
            }
        }
        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                if (new Regex(@"^\+\d{12}$").IsMatch(value))
                    _phone = value;
                else
                    throw new Exception("Phone is invalid");
            }
        }
        
        public Reader(string name, string surname, DateTime birthDate, Gender gender,
            string email, string phone, string address, ReaderRate rate) :
            base(name, surname, birthDate, gender)
        {
            Email = email;
            Phone = phone;
            Address = address;
            Rate = rate;
        }
        public override string ToString()
        {
            return base.ToString() +
                $"\n\tEmail:{Email};" +
                $"\n\tPhone:{Phone};" +
                $"\n\tAddress:{Address};" +
                $"\n\tRate:{Rate};";
        }
    }
}
