using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public Product? product { get; set; }

        public ProductModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OnGet(int id)
        {
            product = _productRepository.GetProductById(id);
        }
    }
}
