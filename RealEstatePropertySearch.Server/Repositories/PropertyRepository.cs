using RealEstatePropertySearch.Server.Data;
using RealEstatePropertySearch.Server.Entities;
using RealEstatePropertySearch.Server.Interfaces;

namespace RealEstatePropertySearch.Server.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public PropertyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<int> AddProperty(PropertyModel Propertymodel)
        {
            try
            {
                var Property = new Property
                {
                    Name = Propertymodel.Name,
                    Description = Propertymodel.Description,
                    CreateDate = DateTime.Now
                };

                var result = await Add(Property);
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

        public async Task<int> UpdateProperty(PropertyModel Propertymodel)
        {
            try
            {
                var Propertyitem = await GetById(Propertymodel.Id);
                Propertyitem.Name = Propertymodel.Name;
                Propertyitem.Description = Propertymodel.Description;
                Propertyitem.CreateDate = DateTime.Now;

                var result = await UpdateAsync(Propertyitem);
                return result;

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}


