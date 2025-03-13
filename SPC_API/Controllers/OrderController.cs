using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPC_API.Data;
using SPC_API.DTO;
using SPC_API.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly OrderRepo _repo;
        private readonly AppDBContext _context;

        public OrderController(IMapper mapper, OrderRepo repo, AppDBContext context)
        {
            _mapper = mapper;
            _repo = repo;
            _context = context;
        }

        
        [HttpPost]
        public async Task<ActionResult<Order>> PostTender(Order order)
        {
            if (string.IsNullOrEmpty(order.PharmacyId))
            {
                return BadRequest("Pharmacy Id is required.");
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<DTOOrderRead>> GetOrder()
        {
            var orders = _repo.GetOrders();
            var mappedOrders = _mapper.Map<IEnumerable<DTOOrderRead>>(orders);
            return Ok(mappedOrders);
        }

        
        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult<DTOOrderRead> GetOrderById(int id)
        {
            var order = _repo.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            var mappedOrder = _mapper.Map<DTOOrderRead>(order);
            return Ok(mappedOrder);
        }

        
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, DTOOrderWrite dto)
        {
            var order = _mapper.Map<Order>(dto);
            order.OrderId = id;

            if (_repo.UpdateOrder(order))
            {
                return Ok();
            }

            return NotFound();
        }

        
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var order = _repo.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }

            _repo.DeleteOrder(order);
            return Ok();
        }

        
        [HttpGet("byPharmacy/{pharmacyId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByPharmacy(string pharmacyId)
        {
            if (string.IsNullOrEmpty(pharmacyId))
            {
                return BadRequest("Pharmacy ID is required.");
            }

            var orders = await _context.Orders
                .Where(o => o.PharmacyId == pharmacyId)
                .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found for this pharmacy.");
            }

            return Ok(orders);
        }

        [HttpGet("GetOrderHistory/{pharmacyId}")]
        public async Task<IActionResult> GetOrderHistory(string pharmacyId)
        {
            var orders = await _context.Orders
                                       .Where(o => o.PharmacyId == pharmacyId)
                                       .OrderByDescending(o => o.OrderDate)
                                       .ToListAsync();

            if (orders == null || !orders.Any())
            {
                return NotFound("No orders found.");
            }

            return Ok(orders); 
        }

    }
}
