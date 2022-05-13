using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService;

namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudProductService
{
    readonly CrudProductService _productService;

    public UserInterfaceCrudProductService()
    {
        _productService = new CrudProductService();
    }

    public void Add()
    {
        var product = new Product();

        Console.WriteLine("Adding New Product");
        Console.WriteLine("----------------");

        Console.Write("Enter Product Name: ");
        var productNameText = Console.ReadLine();
        product.ProductName = productNameText;

        Console.Write("Enter Brand Id: ");
        var brandIdText = Console.ReadLine();
        product.BrandId = int.Parse(brandIdText);

        Console.Write("Enter CategoryId: ");
        var categoryIdText = Console.ReadLine();
        product.CategoryId = int.Parse(categoryIdText);

        Console.Write("Enter Model Year: ");
        var modelYearText = Console.ReadLine();
        product.ModelYear = int.Parse(modelYearText);

        Console.Write("Enter List Price: ");
        var listPriceText = Console.ReadLine();
        product.ListPrice = int.Parse(listPriceText);

        _productService.Add(product);
    }

    public IEnumerable<Product> GetAll()
    {
        return _productService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Product Name to Update: ");
        var productNameText = Console.ReadLine();

        var product = _productService.GetByName(productNameText);

        if (product == null)
        {
            Console.WriteLine($"Product Name {productNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found Product: {product}");

        Console.Write("Enter Product Name to change: ");
        var changedProductNameText = Console.ReadLine();

        product.ProductName = changedProductNameText;
        
        _productService.Update(product);
    }

    public void Delete()
    {
        Console.WriteLine("Deleting existing Product");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Product Id to delete: ");
        var productIdText = Console.ReadLine();
        int productId = int.Parse(productIdText);

        _productService.Delete(productId);
    }

    public void Show()
    {
        var products = _productService.GetAll();

        Console.WriteLine("Product List");
        Console.WriteLine("----------");

        Console.WriteLine(Product.Header);
        Console.WriteLine("------------------");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }
        Console.WriteLine("------------------");
    }
}
