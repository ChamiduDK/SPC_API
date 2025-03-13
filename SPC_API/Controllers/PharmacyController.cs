using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC_API.Data;
using SPC_API.Model;
using SPC_API.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.Data;

namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private IMapper mapper;
        private PharmacyRepo repo;
        private readonly AppDBContext context;
        public PharmacyController(IMapper _mapper, PharmacyRepo _repo, AppDBContext _context)
        {
            mapper = _mapper;
            repo = _repo;
            context = _context;
        }
        [HttpPost]
        public ActionResult CreatePharmacy(DTOPharmacyWrite dTO)
        {
            var model = mapper.Map<Pharmacy>(dTO);
            if (repo.CreatePharmacy(model))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        public ActionResult<IEnumerable<DTOPharmacyRead>> GetPharmacies()
        {
            var pharmacies = repo.GetPharmacies();
            return Ok(mapper.Map<IEnumerable<DTOPharmacyRead>>(pharmacies));
        }
        [HttpGet("{id}", Name = "GetPharmacyById")]
        public ActionResult<DTOPharmacyRead> GetPharmacyById(int id)
        {
            var pharmacy = repo.GetPharmacyById(id);
            if (pharmacy != null)
                return Ok(mapper.Map<DTOPharmacyRead>(pharmacy));
            else
                return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePharmacy(int id, DTOPharmacyWrite dTO)
        {
            var pharmacy = mapper.Map<Pharmacy>(dTO);
            pharmacy.Id = id;
            if (repo.UpdatePharmacy(pharmacy))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePharmacy(int id)
        {
            var pharmacy = repo.GetPharmacyById(id);
            if (pharmacy != null)
            {
                repo.DeletePharmacy(pharmacy);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var pharmacy = await context.Pharmacies.FirstOrDefaultAsync(p => p.Email == request.Email && p.Password == request.Password);

            if (pharmacy == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            return Ok(new
            {
                pharmacyId = pharmacy.Id,
                userType = "Pharmacy"
            });
        }


        [HttpGet("CheckEmail")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            bool exists = await context.Pharmacies.AnyAsync(p => p.Email == email);
            return Ok(exists);
        }

    }
}
