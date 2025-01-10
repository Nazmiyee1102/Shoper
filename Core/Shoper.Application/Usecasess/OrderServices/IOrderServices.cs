using Shoper.Application.Dtos.OrderDtos;
using Shoper.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecasess.OrderServices
{
    public interface IOrderServices
    {
        Task<List<ResultOrderDto>> GetAllOrderAsync();

        Task<GetByIdOrderDto> GetByIdOrderAsync(int id);

        Task CreateOrderAsync(CreateOrderDto createOrderDto);

        Task UpdateOrderAsync(UpdateOrderDto updateOrderDto);

        Task DeleteOrderAsync(int id);
    }
}
