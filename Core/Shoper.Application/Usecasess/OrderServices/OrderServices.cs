using Shoper.Application.Dtos.OrderDtos;
using Shoper.Application.Dtos.OrderItemDtos;
using Shoper.Application.Interfaces;
using Shoper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shoper.Application.Usecasess.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IRepository<Order> _repository;
        private readonly IRepository<OrderItem> _repositoryOrderItem;


        public OrderServices(IRepository<Order> repository, IRepository<OrderItem> repositoryOrderItem)
        {
            _repository = repository;
            _repositoryOrderItem = repositoryOrderItem;
        }

        public async Task CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            var order = new Order
            {
                OrderDate = createOrderDto.OrderDate,
                TotalAmount = createOrderDto.TotalAmount,
                OrderStatus = createOrderDto.OrderStatus,
                BillingAddress = createOrderDto.BillingAddress,
                ShippingAddress = createOrderDto.ShippingAddress,
                PaymentMethod = createOrderDto.PaymentMethod,
                CustomerId = createOrderDto.CustomerId
            };
            await _repository.CreateAsync(order);

            foreach (var item in createOrderDto.OrderItems)
            {
                await _repositoryOrderItem.CreateAsync(new OrderItem
                {
                    OrderId = order.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice
                });
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(values);
        }

        public async Task<List<ResultOrderDto>> GetAllOrderAsync()
        {
            var values = await _repository.GetAllAsync();
            var orderitem = await _repositoryOrderItem.GetAllAsync();
            return values.Select(x => new ResultOrderDto
            {
                OrderId = x.OrderId,
                OrderDate = x.OrderDate,
                TotalAmount = x.TotalAmount,
                OrderStatus = x.OrderStatus,
                BillingAddress = x.BillingAddress,
                ShippingAddress = x.ShippingAddress,
                PaymentMethod = x.PaymentMethod,
                CustomerId = x.CustomerId,
                //OrderItems = x.OrderItems.Select(y => new ResultOrderItemDto
                //{
                //    OrderItemId = y.OrderItemId,
                //    Quantity = y.Quantity,
                //    TotalPrice = y.TotalPrice,
                //    ProductId = y.ProductId,
                //    OrderId = y.OrderId
                //}).ToList()
            }).ToList();
        }

        public async Task<GetByIdOrderDto> GetByIdOrderAsync(int id)
        {
            var values = await _repository.GetByIdAsync(id);
            return new GetByIdOrderDto
            {
                OrderId = values.OrderId,
                OrderDate = values.OrderDate,
                TotalAmount = values.TotalAmount,
                OrderStatus = values.OrderStatus,
                BillingAddress = values.BillingAddress,
                ShippingAddress = values.ShippingAddress,
                PaymentMethod = values.PaymentMethod,
                CustomerId = values.CustomerId,
                //Customer = values.Customer,
                //OrderItems = values.OrderItems
            };
        }

        public async Task UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var values = await _repository.GetByIdAsync(updateOrderDto.OrderId);
            values.OrderDate = updateOrderDto.OrderDate;
            values.TotalAmount = updateOrderDto.TotalAmount;
            values.OrderStatus = updateOrderDto.OrderStatus;
            values.BillingAddress = updateOrderDto.BillingAddress;
            values.ShippingAddress = updateOrderDto.ShippingAddress;
            values.PaymentMethod = updateOrderDto.PaymentMethod;
            values.CustomerId = updateOrderDto.CustomerId;
            await _repository.UpdateAsync(values);
        }
    }
}
