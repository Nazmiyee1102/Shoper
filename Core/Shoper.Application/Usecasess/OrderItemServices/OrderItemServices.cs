using Shoper.Application.Dtos.OrderItemDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecasess.OrderItemServices
{
    public class OrderItemServices : IOrderItemServices
    {
        private readonly IRepository<OrderItem> _orderItemRepository;

        public OrderItemServices(IRepository<OrderItem> orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task CreateOrderItemAsync(CreateOrderItemDto createOrderItemDto)
        {
            await _orderItemRepository.CreateAsync(new OrderItem
           {
               Quantity = createOrderItemDto.Quantity,
               TotalPrice = createOrderItemDto.TotalPrice,
               ProductId = createOrderItemDto.ProductId,
               OrderId = createOrderItemDto.OrderId
           });
        }

        public async Task DeleteOrderItemAsync(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            await _orderItemRepository.DeleteAsync(orderItem);
        }

        public async Task<List<ResultOrderItemDto>> GetAllOrderItemAsync()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return orderItems.Select(x => new ResultOrderItemDto
            {
                OrderItemId = x.OrderItemId,
                Quantity = x.Quantity,
                TotalPrice = x.TotalPrice,
                ProductId = x.ProductId,
                OrderId = x.OrderId
            }).ToList();
        }

        public async Task<GetByIdOrderItemDto> GetByIdOrderItemAsync(int id)
        {
            var values = await _orderItemRepository.GetByIdAsync(id);
            return new GetByIdOrderItemDto
            {
                OrderItemId = values.OrderItemId,
                Quantity = values.Quantity,
                TotalPrice = values.TotalPrice,
                ProductId = values.ProductId,
                OrderId = values.OrderId
            };
        }

        public async Task UpdateOrderItemAsync(UpdateOrderItemDto updateOrderItemDto)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(updateOrderItemDto.OrderItemId);
            orderItem.OrderId = updateOrderItemDto.OrderId;
            orderItem.ProductId = updateOrderItemDto.ProductId;
            orderItem.Quantity = updateOrderItemDto.Quantity;
            orderItem.TotalPrice = updateOrderItemDto.TotalPrice;
            await _orderItemRepository.UpdateAsync(orderItem);
        }
    }
}
