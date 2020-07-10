using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CreditCardAPI.Model
{
    public class CardEligibilityDetail
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey("UserDetail")]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string UserCardStatus { get; set; }

        public decimal APROnCard { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string UserPromotionalMsg{ get; set; }

        public DateTime CreatedOn { get; set; }


        public virtual UserDetail UserDetail { get; set; }
    }
}
