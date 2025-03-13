using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPC_API.Data;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly TenderRepo repo;
        private readonly AppDBContext context;

        public TenderController(IMapper _mapper, TenderRepo _repo, AppDBContext _context)
        {
            mapper = _mapper;
            repo = _repo;
            context = _context;
        }

        
        [HttpPost]
        public async Task<ActionResult<Tender>> PostTender(Tender tender)
        {
            if (string.IsNullOrEmpty(tender.SupplierId))
            {
                return BadRequest("Supplier ID is required.");
            }

            context.Tenders.Add(tender);
            await context.SaveChangesAsync();

            
            return CreatedAtAction(nameof(GetTenderById), new { id = tender.Id }, tender);
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<DTOTenderRead>> GetTender()
        {
            var tender = repo.GetTenders();
            return Ok(mapper.Map<IEnumerable<DTOTenderRead>>(tender));
        }

        
        [HttpGet("{id}", Name = "GetTenderById")]
        public ActionResult<DTOTenderRead> GetTenderById(int id)
        {
            var tenders = repo.GetTenderById(id);
            if (tenders != null)
                return Ok(mapper.Map<DTOTenderRead>(tenders));
            else
                return NotFound();
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateTender(int id, DTOTenderWrite dTO)
        {
            var tender = mapper.Map<Tender>(dTO);
            tender.Id = id;
            if (repo.UpdateTender(tender))
                return Ok();
            else
                return NotFound();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteTender(int id)
        {
            var tender = repo.GetTenderById(id);
            if (tender != null)
            {
                repo.DeleteTender(tender);
                return Ok();
            }
            else
                return NotFound();
        }

        // GET: api/Tender/{supplierId}
        [HttpGet("bySupplier/{supplierId}")]
        public async Task<ActionResult<IEnumerable<Tender>>> GetTendersBySupplier(string supplierId)
        {
            if (string.IsNullOrEmpty(supplierId))
            {
                return BadRequest("Supplier ID is required.");
            }

            var tenders = await context.Tenders
                .Where(t => t.SupplierId == supplierId)
                .ToListAsync();

            if (tenders == null || tenders.Count == 0)
            {
                return NotFound("No tenders found for this supplier.");
            }

            return Ok(tenders);
        }
    }
}

