using E_commerce.Application.DTOs.Order;
using E_commerce.Application.Helper;
using E_commerce.Application.Hepler;
using E_commerce.Application.Interfaces;
using E_commerce.Core.Enum;
using E_commerce.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, ICartItemRepository cartItemRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<Response<OrderDisDto>> CheckoutAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(userId);
            if (cartItems == null || !cartItems.Any())
                return new Response<OrderDisDto>() { Data = null, Succeeded = false, Errors = new List<string> { "Cart is empty." } };

            var order = new Order
            {
                UserID = SessionManager.CurrentUser.UserID,
                OrderDate = DateTime.UtcNow,
                Status = Status.Pending,
                OrderDetails = new List<OrderDetail>(),
                TotalAmount = 0
            };

            foreach (var item in cartItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductID);
                if (product == null || product.UnitsInStock < item.Quantity)
                    return new Response<OrderDisDto>()
                    {
                        Data = null,
                        Succeeded = false,
                        Errors = new List<string>
                            { $"Product with ID {item.ProductID} not found or insufficient stock." }
                    };

                var orderDetail = new OrderDetail
                {
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    Price = product.Price
                };

                product.UnitsInStock -= item.Quantity;
                await _productRepository.UpdateAsync(product);

                order.TotalAmount += orderDetail.Quantity * orderDetail.Price;
                order.OrderDetails.Add(orderDetail);
            }

            await _orderRepository.AddAsync(order);

            var orderDisDto = new OrderDisDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                DateProcessed = order.DateProcessed,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    Quantity = od.Quantity,
                    Price = od.Price
                }).ToList()
            };

            return new Response<OrderDisDto>() { Data = orderDisDto, Succeeded = true, Errors = null };
        }

        public async Task ProcessOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Order not found.");

            if (order.Status == Status.Pending)
            {
                bool canApprove = order.OrderDetails.All(od => od.Product.UnitsInStock >= od.Quantity);
                order.Status = canApprove ? Status.Approved : Status.Denied;
            }
            else if (order.Status == Status.Approved)
            {
                order.Status = Status.Shipped;
                order.DateProcessed = DateTime.UtcNow;
            }

            await _orderRepository.UpdateAsync(order);
        }

        public async Task<Response<string>> CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return new Response<string>() { Data = null, Succeeded = false, Errors = new List<string> { "Order not found." } };
            else if (order.Status == Status.Shipped)
                return new Response<string>() { Data = null, Succeeded = false, Errors = new List<string> { "Cannot cancel a shipped order." } };
            foreach (var orderDetail in order.OrderDetails)
            {
                var product = await _productRepository.GetByIdAsync(orderDetail.ProductID);
                if (product != null)
                {
                    product.UnitsInStock += orderDetail.Quantity;
                    await _productRepository.UpdateAsync(product);
                }
            }
            await _orderRepository.DeleteAsync(orderId);
            return new Response<string>() { Data = "Order cancelled successfully.", Succeeded = true, Errors = null };
        }

        public async Task<Response<string>> ApproveOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return new Response<string> { Succeeded = false, Errors = new List<string> { "Order not found." } };

            if (order.Status != Status.Pending)
                return new Response<string> { Succeeded = false, Errors = new List<string> { "Only pending orders can be approved." } };
            order.Status = Status.Approved;
            await _orderRepository.UpdateAsync(order);

            return new Response<string> { Succeeded = true, Data = "Order approved successfully." };
        }

        public async Task<Response<string>> DenyOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                return new Response<string> { Succeeded = false, Errors = new List<string> { "Order not found." } };

            if (order.Status != Status.Pending)
                return new Response<string> { Succeeded = false, Errors = new List<string> { "Only pending orders can be approved." } };
            order.Status = Status.Denied;
            await _orderRepository.UpdateAsync(order);

            return new Response<string> { Succeeded = true, Data = "Order denied  successfully." };
        }

        public async Task<List<OrderDisDto>> GetOrderHistoryByUserIdAsync(int userId)
        {
            var orders = await _orderRepository.GetOrdersByUserIdAsync(userId);

            return orders.Select(order => new OrderDisDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                DateProcessed = order.DateProcessed,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    Quantity = od.Quantity,
                    Price = od.Price
                }).ToList()
            }).ToList();
        }

        public async Task<List<OrderDisDto>> GetOrdersByStatusAsync(Status? status = null)
        {
            var orders = await _orderRepository.GetOrdersByStatusAsync(status);
            return orders.Select(order => new OrderDisDto
            {
                OrderID = order.OrderID,
                UserID = order.UserID,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                Status = order.Status.ToString(),
                DateProcessed = order.DateProcessed,
                OrderDetails = order.OrderDetails.Select(od => new OrderDetailDto
                {
                    ProductID = od.ProductID,
                    Quantity = od.Quantity,
                    Price = od.Price
                }).ToList()
            }).ToList();
        }


    }
}
