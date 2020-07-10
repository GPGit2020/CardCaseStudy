using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.Model
{
    
    public class UserDetail 
    {
        [Key]
        public int ID { get; set; }
       

        [Column(TypeName ="nvarchar(150)")]
        public string FirstName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string LastName { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime DOB { get; set; }

        [Column(TypeName = "decimal")]
        public decimal AnnualSalary { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }



    }
}
