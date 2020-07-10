using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.Model
{
    public class UserDetailsModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public decimal AnnualSalary { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
