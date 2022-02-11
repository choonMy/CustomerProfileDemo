using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerProfileRepository _customerProfileRepo;
        public CustomerController(ICustomerProfileRepository customerProfileRepo)
        {
            _customerProfileRepo = customerProfileRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerProfile>>> GetCustomerProfiles()
        {
            return Ok(await _customerProfileRepo.GetCustomerProfilesAsync());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerProfile>> GetCustomerProfileById(int id)
        {
            var customerProfile = await _customerProfileRepo.GetCustomerProfileByIdAsync(id);
            if (customerProfile == null) return NotFound();

            return customerProfile;

        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomerProfile(CustomerProfileDto profile)
        {
            var result = await _customerProfileRepo.CreateCustomerProfileAsync(new CustomerProfile
            {
                Name = profile.Name,
                Surname = profile.Surname,
                Email = profile.Email,
                Mobile = profile.Mobile,
                Occupation = profile.Occupation
            });

            if (result == 0) return BadRequest();

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<CustomerProfile>> UpdateCustomerProfile(CustomerProfileDto profile)
        {
            var existingProfile = await _customerProfileRepo.GetCustomerProfileByIdAsync(profile.Id);
            if (existingProfile == null) return BadRequest();
            existingProfile.Email = profile.Email;
            existingProfile.Name = profile.Name;
            existingProfile.Surname = profile.Surname;
            existingProfile.Occupation = profile.Occupation;
            existingProfile.Mobile = profile.Mobile;

            var result = await _customerProfileRepo.UpdateCustomerProfileAsync(existingProfile);

            if (result == 0) return BadRequest();

            return Ok();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCustomerProfile(int id)
        {
            var existingProfile = await _customerProfileRepo.GetCustomerProfileByIdAsync(id);
            if (existingProfile == null) return BadRequest();

            await _customerProfileRepo.DeleteCustomerProfileAsync(existingProfile);
            return Ok();
        }

    }
}