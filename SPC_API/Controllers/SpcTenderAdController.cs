using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC_API.Data;
using SPC_API.Model;
using SPC_API.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpcTenderAdController : ControllerBase
    {
        private IMapper mapper;
        private SpcTenderAdRepo repo;
        private readonly AppDBContext context;
        public SpcTenderAdController(IMapper _mapper, SpcTenderAdRepo _repo, AppDBContext _context)
        {
            mapper = _mapper;
            repo = _repo;
            context = _context;
        }
        [HttpPost]
        public ActionResult CreateSpcTenderAd(DTOSpcTenderAdWrite dTO)
        {
            var model = mapper.Map<SpcTenderAd>(dTO);
            if (repo.CreateSpcTenderAd(model))
                return Ok();
            else
                return BadRequest();
        }
        [HttpGet]
        public ActionResult<IEnumerable<DTOSpcTenderAdRead>> GetSpcTenderAds()
        {
            var spcTenderAds = repo.GetSpcTenderAds();
            return Ok(mapper.Map<IEnumerable<DTOSpcTenderAdRead>>(spcTenderAds));
        }
        [HttpGet("{id}", Name = "GetSpcTenderAdById")]
        public ActionResult<DTOSpcTenderAdRead> GetSpcTenderAdById(int id)
        {
            var spcTenderAd = repo.GetSpcTenderAdById(id);
            if (spcTenderAd != null)
                return Ok(mapper.Map<DTOSpcTenderAdRead>(spcTenderAd));
            else
                return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateSpcTenderAd(int id, DTOSpcTenderAdWrite dTO)
        {
            var spcTenderAd = mapper.Map<SpcTenderAd>(dTO);
            spcTenderAd.Id = id;
            if (repo.UpdateSpcTenderAd(spcTenderAd))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSpcTenderAd(int id)
        {
            var spcTenderAd = repo.GetSpcTenderAdById(id);
            if (spcTenderAd == null)
                return NotFound();

            if (repo.DeleteSpcTenderAd(spcTenderAd))
                return Ok();
            else
                return NotFound();
        }

    }
}

