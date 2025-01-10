using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoper.Application.Dtos.CustomerDtos;
using Shoper.Application.Usecasess.CustomerServices;

namespace Shoper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomer()
        {
            var customers = await _customerServices.GetAllCustomerAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdCustomer(int id)
        {
            var customer = await _customerServices.GetByIdCustomerAsync(id);
            return Ok(customer);
        }

        [HttpPost]//create işlemleri genellikle post ile yapılır.
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            await _customerServices.CreateCustomerAsync(createCustomerDto);
            return Ok("Müşteri Ekleme İşlemi Başarılı");
        }


        [HttpPut]//update işlemleri genellikle put ile yapılır.
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            await _customerServices.UpdateCustomerAsync(updateCustomerDto);
            return Ok("Müşteri Güncelleme İşlemi Başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerServices.DeleteCustomerAsync(id);
            return Ok("Müşteri Başarıyla Silindi!");
        }

    }
}
