using Catalog.Host.Models;

using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly Product[] _products;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
        _products = new[]
        {
            new Product
            {
                Id = 1,
                Title = "Product 1",
                Price = 11111,
                Description = "Product 1 Description",
            },
            new Product
            {
                Id = 2,
                Title = "Product 2",
                Price = 22222,
                Description = "Product 2 Description",
            },
            new Product
            {
                Id = 3,
                Title = "Product 3",
                Price = 33333,
                Description = "Product 3 Description",
            },
            new Product
            {
                Id = 4,
                Title = "Product 4",
                Price = 44444,
                Description = "Product 4 Description",
            },
            new Product
            {
                Id = 5,
                Title = "Product 5",
                Price = 55555,
                Description = "Product 5 Description",
            },
        };
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        if (_products != default)
        {
            return _products;
        }
        else
        {
            return default;
        }
    }
}
