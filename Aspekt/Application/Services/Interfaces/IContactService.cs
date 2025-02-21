using Aspekt.Application.DTOs;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Domain.Entities;

namespace Aspekt.Application.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
        Task Delete(int id);
        Task<ContactCreateResponse> Create(Contact contact);
        Task<Contact> Update(Contact contact);
        Task<List<ContactWithCompanyAndCountryDTO>> GetContactWithCompanyAndCountry();
        Task<List<Contact>> Filter(int? CompanyId, int? CountryId);
    }
}
