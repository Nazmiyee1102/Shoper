using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Application.Dtos.OrderItemDtos;
using Shoper.Application.Usecasess.OrderItemServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemServices _orderItemServices;
        public OrderItemsController(IOrderItemServices orderItemServices)
        {
            _orderItemServices = orderItemServices;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOrderItemAsync()
        {
            var result = await _orderItemServices.GetAllOrderItemAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrderItemAsync(int id)
        {
            var result = await _orderItemServices.GetByIdOrderItemAsync(id);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            await _orderItemServices.CreateOrderItemAsync(createOrderItemDto);
            return Ok("Ekleme İşlemi Başarılı");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto)
        {
            await _orderItemServices.UpdateOrderItemAsync(updateOrderItemDto);
            return Ok("Güncelleme İşlemi Başarılı");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItemAsync(int id)
        {
            await _orderItemServices.DeleteOrderItemAsync(id);
            return Ok("Silme İşlemi Başarılı");
        }
    }
}
