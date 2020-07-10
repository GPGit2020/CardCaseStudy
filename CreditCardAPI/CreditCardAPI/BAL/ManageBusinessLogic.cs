using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardAPI.Model;

namespace CreditCardAPI.BAL
{
    public class ManageBusinessLogic
    {
        private readonly DatabaseContext _context;

        public ManageBusinessLogic(DatabaseContext context)
        {
            _context = context;
        }

        #region Users
        public UserDetail SaveUserDetails(UserDetail model)
        {
            UserDetail userDetail = _context.UserDetail.Find(model.ID);
            if (userDetail == null)
            {
                //Save here
                userDetail = new UserDetail();
                userDetail.CreatedOn = DateTime.Now;
                
                _context.UserDetail.Add(userDetail);
            }
            

            userDetail.AnnualSalary = model.AnnualSalary;
            userDetail.DOB = model.DOB;
            userDetail.FirstName = model.FirstName;
            userDetail.LastName = model.LastName;
            
            _context.SaveChanges();

            return userDetail;
        }
        #endregion

        #region Card Details
        public CardEligibilityDetail SaveCardDetails(CardEligibilityModel model)
        {
            CardEligibilityDetail cardDetail = _context.CardEligibilityDetail.Find(model.ID);
            if (cardDetail == null)
            {
                //Save here
                cardDetail = new CardEligibilityDetail();
                cardDetail.CreatedOn = DateTime.Now;               
                _context.CardEligibilityDetail.Add(cardDetail);
            }
            cardDetail.UserId = model.UserId;


            cardDetail.APROnCard = model.APROnCard;
            cardDetail.UserCardStatus = model.UserCardStatus;
            cardDetail.UserPromotionalMsg = model.UserPromotionalMsg;
            _context.SaveChanges();

            return cardDetail;
        }
        #endregion
    }
}
