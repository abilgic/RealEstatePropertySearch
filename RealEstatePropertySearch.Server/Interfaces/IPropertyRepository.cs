
using RealEstatePropertySearch.Server.Entities;
using RealEstatePropertySearch.Server.Models;

namespace RealEstatePropertySearch.Server.Interfaces
{
    public interface IPropertyRepository : IGenericRepository<Property>
    {
        Task<IEnumerable<Property>> GetList();
        Task<Property> GetProperty(int Id);
        Task<int> AddProperty(PropertyModel propertymodel);
        Task<int> UpdateProperty(PropertyModel propertymodel);
        Task<int> DeleteProperty(int Id);
    }
}
