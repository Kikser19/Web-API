using Aspekt.Application.Response_Models.Company_Response;
using Aspekt.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspekt.Infrastructure.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAll(int? PageNumber, int? PageSize);
        Task<CompanyCreateResponse> Create(Company company);
        Task<Company> GetById(int id);
        Task Delete(Company company);
        Task<Company> Update(Company company);
    }
}
