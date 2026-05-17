using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using KE03_INTDEV_SE_1_Base.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public Cart Cart { get; set; }
        public CartDisplay ItemInCart { get; set; }
        public List<CartDisplay> Items { get; set; }
        public Product Product { get; set; }

        public CartModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            Items = new List<CartDisplay>();
        }

        public void OnGet()
        {
            Cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            if (Cart.Items.Any())
            {
                foreach (var item in Cart.Items)
                {
                    Product = _productRepository.GetProductById(item.ProductId);
                    ItemInCart = new CartDisplay(Product, item.Quantity);
                    Items.Add(ItemInCart);
                }
            }
        }
    }
}
