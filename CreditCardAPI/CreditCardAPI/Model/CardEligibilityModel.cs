using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.Model
{
    public class CardEligibilityModel
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string UserCardStatus { get; set; }
        public decimal APROnCard { get; set; }
        public string UserPromotionalMsg { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
