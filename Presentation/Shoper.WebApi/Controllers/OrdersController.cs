using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Application.Dtos.OrderDtos;
using Shoper.Application.Usecasess.OrderServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderServices;
        public OrdersController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            var values = await _orderServices.GetAllOrderAsync();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderAsync(int id)
        {
            var values = await _orderServices.GetByIdOrderAsync(id);
            return Ok(values);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            await _orderServices.CreateOrderAsync(createOrderDto);
            return Ok("Sipariş Eklendi!");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            await _orderServices.UpdateOrderAsync(updateOrderDto);
            return Ok("Sipariş Güncellendi!");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            await _orderServices.DeleteOrderAsync(id);
            return Ok("Sipariş Başarıyla Silindi!");
        }
    }
}
