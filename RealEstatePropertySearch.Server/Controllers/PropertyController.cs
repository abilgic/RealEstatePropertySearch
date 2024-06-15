using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstatePropertySearch.Server.Data;
using RealEstatePropertySearch.Server.Entities;
using RealEstatePropertySearch.Server.Interfaces;
using RealEstatePropertySearch.Server.Models;

namespace RealEstatePropertySearch.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[EnableCors("AllowOrigin")]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        public PropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> Get(int id)
        {
            var result = await _propertyRepository.GetById(id);

            return result;
        }
        [HttpGet]
        public async Task<IEnumerable<Property>> Get()
        {
            var result = await _propertyRepository.GetAll();
            return result;
        }

        [HttpPut]
        public async Task<bool> Put([FromBody] PropertyModel model)
        {


            var result = await _propertyRepository.UpdateProperty(model);
            return result > 0;
        }

        [HttpPost]
        public bool Post([FromBody] PropertyModel model)
        {



            var result =  _propertyRepository.AddProperty(model).Result;
            return result > 0;

        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _propertyRepository.DeleteProperty(id);
            return result > 0;
        }
    }

}


