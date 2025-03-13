using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPC_API.Data;
using SPC_API.DTO;
using SPC_API.Model;


namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IMapper mapper;
        private SupplierRepo repo;
        private readonly AppDBContext context;

        // Corrected constructor
        public SupplierController(IMapper _mapper, SupplierRepo _repo, AppDBContext _context)
        {
            mapper = _mapper;
            repo = _repo;
            context = _context;
        }

        [HttpPost]
        public ActionResult CreateSupplier(DTOSupplierWrite dTO)
        {
            var model = mapper.Map<Supplier>(dTO);
            if (repo.CreateSupplier(model))
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet]
        public ActionResult<IEnumerable<DTOSupplierRead>> GetSuppliers()
        {
            var suppliers = repo.GetSuppliers();
            return Ok(mapper.Map<IEnumerable<DTOSupplierRead>>(suppliers));
        }

        [HttpGet("{id}", Name = "GetSupplierById")]
        public ActionResult<DTOSupplierRead> GetSupplierById(int id)
        {
            var supplier = repo.GetSupplierById(id);
            if (supplier != null)
                return Ok(mapper.Map<DTOSupplierRead>(supplier));
            else
                return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSupplier(int id, DTOSupplierWrite dTO)
        {
            var supplier = mapper.Map<Supplier>(dTO);
            supplier.Id = id;
            if (repo.UpdateSupplier(supplier))
                return Ok();
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSupplier(int id)
        {
            var supplier = repo.GetSupplierById(id);
            if (supplier != null)
            {
                // Call Delete method (assumed method name)
                repo.DeleteSupplier(supplier);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] DTOSupplierLogin loginDto)
        {
            // Check if supplier exists
            var supplier = await context.Suppliers
                .FirstOrDefaultAsync(s => s.Email == loginDto.Email && s.Password == loginDto.Password);

            if (supplier == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { message = "Login successful", supplierId = supplier.Id });
        }

        [HttpGet("CheckEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            bool exists = await context.Suppliers.AnyAsync(s => s.Email == email);
            return Ok(exists);
        }

    }
}
