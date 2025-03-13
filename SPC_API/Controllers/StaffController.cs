using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC_API.Data;
using SPC_API.DTO;
using SPC_API.Model;

namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private IMapper mapper;
        private StaffRepo repo;
        public StaffController(IMapper _mapper, StaffRepo _repo)
        {
            mapper = _mapper;
            repo = _repo;
        }
        [HttpPost]
        public ActionResult CreateStaff(DTOStaffWrite dTO)
        {
            var model = mapper.Map<Staff>(dTO);
            if (repo.CreateStaff(model))
                return Ok();
            else
                return BadRequest();

        }
        [HttpGet]
        public ActionResult<IEnumerable<DTOStaffRead>> GetStaff()
        {
            var staff = repo.GetStaffs();
            return Ok(mapper.Map<IEnumerable<DTOStaffRead>>(staff));

        }
        [HttpGet("{id}", Name = "GetStaffByID")]
        public ActionResult<DTOStaffRead> GetStaffById(int id)
        {
            var staff = repo.GetStaffById(id);
            if (staff != null)
                return Ok(mapper.Map<DTOStaffRead>(staff));
            else
                return NotFound();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateStaffs(int id, DTOStaffWrite dTO)
        {
            var staff = mapper.Map<Staff>(dTO);
            staff.Id = id;
            if (repo.UpdateStaffs(staff))
                return Ok();
            else
                return NotFound();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteStaff(int id)
        {
            var staff = repo.GetStaffById(id);
            if (staff != null)
            {
                repo.DeleteStaff(staff);
                return Ok();
            }
            else
                return NotFound();
        }
    }

}

