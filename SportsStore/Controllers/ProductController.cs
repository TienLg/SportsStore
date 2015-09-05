using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repo;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            repo = productRepository;
        }
        //
        // GET: /Product/
        public ViewResult List(string category, int page = 1)
        {
            IEnumerable<Product> products = repo.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID);
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = products
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = products.Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repo.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
	}
}