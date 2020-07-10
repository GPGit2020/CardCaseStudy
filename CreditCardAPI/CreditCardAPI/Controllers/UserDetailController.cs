using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCardAPI.BAL;
using CreditCardAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardEligibilityToolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private ManageBusinessLogic _manageBusiness;
        public UserDetailController(ManageBusinessLogic manageBusiness)
        {
            _manageBusiness = manageBusiness;
        }

        #region User Details

        [HttpPost]
        [Route("UserProfile")]
        public IActionResult UserProfile(UserDetailsModel model)
        {
            var userDetails = new UserDetail()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DOB = model.DOB,
                AnnualSalary = model.AnnualSalary,
            };

            try
            {
                var result = _manageBusiness.SaveUserDetails(userDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Card Details

        [HttpPost]
        [Route("ManageCard")]
        public IActionResult ManageCard(CardEligibilityModel model)
        {
            try
            {
                var result = _manageBusiness.SaveCardDetails(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}