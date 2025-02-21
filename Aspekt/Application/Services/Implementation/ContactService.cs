using Aspekt.Application.DTOs;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Application.Services.Interfaces;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure.Interfaces;

namespace Aspekt.Application.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepositry;
        public ContactService(IContactRepository _contactRepositry)
        {
            this._contactRepositry = _contactRepositry;
        }

        public async Task<ContactCreateResponse> Create(Contact contact)
        {
            return await _contactRepositry.Create(contact);
        }

        public async Task Delete(int id)
        {
            var contact = await _contactRepositry.GetById(id);
            await _contactRepositry.Delete(contact);
        }

        public async Task<List<Contact>> Filter(int? CompanyId, int? CountryId)
        {
            return await _contactRepositry.Filter(CompanyId, CountryId); 
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _contactRepositry.GetAll();   
        }

        public async Task<Contact> GetById(int id)
        {
            return await _contactRepositry.GetById(id);
        }

        public async Task<List<ContactWithCompanyAndCountryDTO>> GetContactWithCompanyAndCountry()
        {
            return await _contactRepositry.GetContactWithCompanyAndCountry();
        }

        public async Task<Contact> Update(Contact contact)
        {
            return await _contactRepositry.Update(contact);
        }
    }
}
