using Aspekt.Application.DTOs;
using Aspekt.Application.Response_Models.Contact_Response;
using Aspekt.Domain.Entities;
using Aspekt.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Aspekt.Infrastructure.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ContactRepository(ApplicationDbContext _applicationDbContext)
        {
            this._applicationDbContext = _applicationDbContext;
        }

        public async Task<ContactCreateResponse> Create(Contact contact)
        {
            _applicationDbContext.Contacts.Add(contact);
            await _applicationDbContext.SaveChangesAsync();
            return new ContactCreateResponse(contact);
        }

        public async Task Delete(Contact contact)
        {
            _applicationDbContext.Remove(contact);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> Filter(int? companyId, int? countryId)
        {
            var contactsQuery = _applicationDbContext.Contacts.AsQueryable();

            if (companyId.HasValue)
            {
                contactsQuery = contactsQuery.Where(c => c.CompanyId == companyId.Value);
            }
            if (countryId.HasValue)
            {
                contactsQuery = contactsQuery.Where(c => c.CountryId == countryId.Value);
            }

            return await contactsQuery.ToListAsync();
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _applicationDbContext.Contacts.ToListAsync();

        }

        public async Task<Contact> GetById(int id)
        {
            return await _applicationDbContext.Contacts.FindAsync(id);
        }

        public async Task<List<ContactWithCompanyAndCountryDTO>> GetContactWithCompanyAndCountry()
        {
            var contacts = await _applicationDbContext.Contacts
                .Where(c => c.CompanyId > 0) 
                .Join(_applicationDbContext.Companies,
                      c => c.CompanyId,
                      co => co.CompanyId,
                      (c, co) => new { c, co })
                .Join(_applicationDbContext.Countries,
                      temp => temp.c.CountryId,
                      coun => coun.CountryId,
                      (temp, coun) => new ContactWithCompanyAndCountryDTO
                      {
                          ContactName = temp.c.ContactName,
                          CompanyName = temp.co.CompanyName,
                          CountryName = coun.CountryName
                      })
                .ToListAsync();

            return contacts;
        }


        public async Task<Contact> Update(Contact contact)
        {
            _applicationDbContext.Update(contact);
            await _applicationDbContext.SaveChangesAsync();
            return contact;
        }
    }
}
