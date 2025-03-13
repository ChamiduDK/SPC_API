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
    public class DrugController : Controller
    {
        private IMapper mapper;
        private DrugRepo repo;
        public DrugController(IMapper _mapper, DrugRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }
        [HttpPost]
        public ActionResult CreateDrug(DTODrugWrite dTO)
        {
            var model = mapper.Map<Drug>(dTO);
            if (repo.CreateDrug(model))
                return Ok();
            else
                return BadRequest();

        }
        [HttpGet]
        public ActionResult<IEnumerable<DTODrugRead>> GetDrug()
        {
            var drug = repo.GetDrugs();
            return Ok(mapper.Map<IEnumerable<DTODrugRead>>(drug));

        }
        [HttpGet("{id}", Name = "GetDrugByID")]
        public ActionResult<DTODrugRead> GetDrugById(int id)
        {
            var drugs = repo.GetDrugById(id);
            if (drugs != null)
                return Ok(mapper.Map<DTODrugRead>(drugs));
            else
                return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateDrug(int id, DTODrugWrite dTO)
        {
            var drug = mapper.Map<Drug>(dTO);
            drug.Id = id;
            if (repo.UpdateDrug(drug))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDrug(int id)
        {
            var drug = repo.GetDrugById(id);
            if (drug != null)
            {
                repo.DeleteDrug(drug);
                return Ok();
            }
            else
                return NotFound();
        }
    }

}
