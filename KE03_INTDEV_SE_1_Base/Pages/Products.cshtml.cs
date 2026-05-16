using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KE03_INTDEV_SE_1_Base.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductRepository _productRepository;
        public IEnumerable<Product> Products { get; set; }
        public string? SearchQuery { get; set; }
        public ProductsModel(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void OnGet(string? search)
        {
            SearchQuery = search;
            if (string.IsNullOrWhiteSpace(search))
            {
                Products = _productRepository.GetAllProducts();
            }
            else
            {
                Products = _productRepository.GetProductsFromSearch(search);
            }
        }
    }
}
