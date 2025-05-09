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
    public class OrderService
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

        public async Task<int> CheckoutAsync(int userId)
        {
            var cartItems = await _cartItemRepository.GetCartItemByUserIdAsync(userId);
            if (cartItems == null || !cartItems.Any())
                throw new InvalidOperationException("Cart is empty.");

            var order = new Order
            {
                UserID = userId,
                OrderDate = DateTime.UtcNow,
                Status = Status.Pending,
                OrderDetails = new List<OrderDetail>(),
                TotalAmount = 0
            };

            foreach (var item in cartItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductID);
                if (product == null || product.UnitsInStock < item.Quantity)
                    throw new InvalidOperationException("Product stock insufficient or product not found.");

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
            //await _cartItemRepository.ClearCartByUserIdAsync(userId));

            return order.OrderID;
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

        public async Task CancelOrderAsync(int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
                throw new ArgumentException("Order not found.");

            if (order.Status == Status.Shipped)
                throw new InvalidOperationException("Cannot cancel a shipped order.");

            order.Status = Status.Denied;
            order.DateProcessed = DateTime.UtcNow;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
