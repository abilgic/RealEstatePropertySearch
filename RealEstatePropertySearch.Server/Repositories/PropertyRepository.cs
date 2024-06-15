using RealEstatePropertySearch.Server.Data;
using RealEstatePropertySearch.Server.Entities;
using RealEstatePropertySearch.Server.Interfaces;
using RealEstatePropertySearch.Server.Models;

namespace RealEstatePropertySearch.Server.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> AddProperty(PropertyModel model)
        {
            try
            {
                Property property = new Property
                {
                    PropertyType = model.PropertyType,
                    Location = model.Location,
                    Price = model.Price,
                    NumberOfRooms = model.NumberOfRooms
                };

                var result = await Add(property);
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Property>> GetList()
        {
            return await GetAll();
        }

        public async Task<int> DeleteProperty(int Id)
        {
            try
            {
                var Propertyitem = await GetById(Id);

                var result = await Remove(Propertyitem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Property> GetProperty(int Id)
        {
            var Propertyitem = await GetById(Id);
            return Propertyitem;
        }

        public async Task<int> UpdateProperty(PropertyModel model)
        {
            try
            {
                var Propertyitem = await GetById(model.Id);

                Propertyitem.PropertyType = model.PropertyType;
                Propertyitem.Location = model.Location;
                Propertyitem.Price = model.Price;
                Propertyitem.NumberOfRooms = model.NumberOfRooms;

                var result = await Update(Propertyitem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}


