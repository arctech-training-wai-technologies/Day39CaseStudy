using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.Services.DbService;

public class CrudProductService : ICrudService<Product>
{
    public void Add(Product product)
    {
        using var context = new SampleStoreDbContext();

        context.Products.Add(product);
        context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        using var context = new SampleStoreDbContext();


        var p1 = context.Products
            .Include("Brand")
            .Include("Category")
            .OrderBy(p => p.BrandId)
                .ThenBy(p=> p.ProductId)
            .ToList();

        /*
        Select * from production.products
        inner join production.brands on products.brand_id = brands.brand_id
        inner join production.categories on products.category_id = categories.category_id
        order by
            products.brand_id, products.product_id
        */

        //var p2 = 
        //    (from product in context.Products
        //    join brand in context.Brands on product.BrandId equals brand.BrandId
        //    join category in context.Categories on product.CategoryId equals category.CategoryId
        //    orderby product.BrandId, product.ProductId
        //    select product).ToList();

        var getProducts = from p2 in context.Products
            join b in context.Brands
                on p2.BrandId equals b.BrandId
            join cat in context.Categories
                on p2.CategoryId equals cat.CategoryId
            orderby
                p2.BrandId, p2.ProductId
            select p2;

        var p = getProducts.ToList();

        return p;
    }

    public void Update(Product product)
    {
        using var context = new SampleStoreDbContext();

        context.Products.Update(product);
        context.SaveChanges();
    }

    public Product GetByName(string productName)
    {
        using var context = new SampleStoreDbContext();

        var product = context.Products.SingleOrDefault(b => b.ProductName == productName);
        return product;
    }

    public void Delete(int productId)
    {
        using var context = new SampleStoreDbContext();

        var product = context.Products.Find(productId);

        if (product == null)
        {
            Console.WriteLine($"ProductId {productId} not found");
            return;
        }

        context.Products.Remove(product);
        context.SaveChanges();
    }
}
