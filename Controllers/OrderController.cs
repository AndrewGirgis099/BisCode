using BisWork.Core.Entities.Order.order;
using BisWork.Core.Repository.Contract;
using BisWork.Core.Servecies.Controct;
using BisWork.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StackExchange.Redis;
using System.Security.Claims;

namespace BisWork.Controllers
{

    public class OrderController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderServices _orderServices;

        public OrderController(IUnitOfWork unitOfWork , IOrderServices orderServices)
        {
            _unitOfWork = unitOfWork;
            _orderServices = orderServices;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<ActionResult<order>> CreateOrder(OrderDto orderDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);

            var order = await _orderServices.CreateOrderAsync(email,orderDto.BasketId);
            if (order is null) return NotFound("There is a proplem With Your Product");
            return Ok(order);
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IReadOnlyCollection<Order>>> GetOrdersForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orders = await _orderServices.GetOrderForSepcificUserAsync(buyerEmail);
            if (orders is null) return NotFound( "There is no orders for this user");
            return Ok(orders);

        }


        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var order = await _orderServices.GetOrderByIdForSpecificUserAsync(buyerEmail, id);
            if (order is null) return NotFound( "there is no order for this user ");
            return Ok(order);
        }
    }
}
