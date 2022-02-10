using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CustomerProfileRepository : ICustomerProfileRepository
    {
        private readonly StoreContext _context;
        public CustomerProfileRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCustomerProfileAsync(CustomerProfile profile)
        {
            _context.CustomerProfiles.Add(profile);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerProfileAsync(CustomerProfile profile)
        {
            _context.CustomerProfiles.Remove(profile);
            await _context.SaveChangesAsync();

        }

        public async Task<CustomerProfile> GetCustomerProfileByIdAsync(int id)
        {
            return await _context.CustomerProfiles.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<CustomerProfile>> GetCustomerProfilesAsync()
        {
            return await _context.CustomerProfiles.ToListAsync();
        }

        public async Task<int> UpdateCustomerProfileAsync(CustomerProfile profile)
        {
            _context.CustomerProfiles.Update(profile);
            return await _context.SaveChangesAsync();
        }
    }
}