using AutoMapper;
using BisWork.Core.Entities.Basket;
using BisWork.Core.Repository.Contract;
using BisWork.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BisWork.Controllers
{
   
    public class Basketcontroller : BaseController
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public Basketcontroller(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasket(CustomerBasketDto Basket)
        {
            var mappedBasket = _mapper.Map<CustomerBasketDto , CustomerBasket>(Basket);
            var createOrUpdateBasket = await _basketRepository.UpdateBasketAsync(mappedBasket);
            if (createOrUpdateBasket is null) return BadRequest();
            return Ok(createOrUpdateBasket);
        }

        [HttpDelete]
        public async Task DeleteBasket(string id)
        {
             await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
