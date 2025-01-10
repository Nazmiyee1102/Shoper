using Shoper.Application.Dtos.OrderItemDtos;
using Shoper.Application.Dtos.OrderItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecasess.OrderItemServices
{
    public interface IOrderItemServices
    {
        Task<List<ResultOrderItemDto>> GetAllOrderItemAsync();

        Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id);

        Task CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto);

        Task UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto);

        Task DeleteOrderItemAsync(int id);

    }
}
