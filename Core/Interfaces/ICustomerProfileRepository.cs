using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ICustomerProfileRepository
    {
        Task<CustomerProfile> GetCustomerProfileByIdAsync(int id);
        Task<IReadOnlyList<CustomerProfile>> GetCustomerProfilesAsync();

        Task<int> CreateCustomerProfileAsync(CustomerProfile profile);

        Task<int> UpdateCustomerProfileAsync(CustomerProfile profile);

        Task DeleteCustomerProfileAsync(CustomerProfile profile);

    }
}