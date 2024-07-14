using LicenseManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LisenceManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NarposmainlicensedbContext _dataContext;
        public CustomerController(NarposmainlicensedbContext context)
        {
            _dataContext = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Musteri>>> GetCustomer(int id)
        {
            var musteri = _dataContext.Musteris.FirstOrDefault(c => c.Id == id);
            return Ok(musteri);
        }
    }
}
