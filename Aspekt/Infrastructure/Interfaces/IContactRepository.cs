using Aspekt.Application.DTOs;
using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Infrastructure.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Delete(Contact contact);
        Task<ContactCreateResponse> Create(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<List<ContactWithCompanyAndCountryDTO>> GetContactWithCompanyAndCountry();
        Task<List<Contact>> Filter(int? CompanyId, int? CountryId);
    }
}
