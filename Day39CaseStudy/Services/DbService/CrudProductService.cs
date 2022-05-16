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
                .ThenBy(p => p.ProductId)
            .ToList();

        // p1 => this will generate SQL as follows
        /*
        Select products.*, brands.*, categories.* from production.products
        inner join production.brands on products.brand_id = brands.brand_id
        inner join production.categories on products.category_id = categories.category_id
        order by
            products.brand_id, products.product_id
        */

        var p2 =
            (from product in context.Products
             join brand in context.Brands on product.BrandId equals brand.BrandId
             join category in context.Categories on product.CategoryId equals category.CategoryId
             orderby product.BrandId, product.ProductId
             select product).ToList();

        // p2 => this will generate SQL as follows
        //       since only product is select, product.brand and product.category will remain null
        /*
        Select products.* from production.products
        inner join production.brands on products.brand_id = brands.brand_id
        inner join production.categories on products.category_id = categories.category_id
        order by
            products.brand_id, products.product_id
        */


        var p3 =
            (from product in context.Products
             join brand in context.Brands on product.BrandId equals brand.BrandId
             join category in context.Categories on product.CategoryId equals category.CategoryId
             orderby product.BrandId, product.ProductId
             select new Product
             {
                 ProductId = product.ProductId,
                 ProductName = product.ProductName,
                 BrandId = product.BrandId,
                 CategoryId = product.CategoryId,
                 ModelYear = product.ModelYear,
                 ListPrice = product.ListPrice,
                 Brand = brand,
                 Category = category
             }).ToList();

        // p3 => this will generate SQL as follows
        /*
        Select 
            product.ProductId, product.ProductName, product.BrandId, product.CategoryId, product.ModelYear, product.ListPrice,
            brand.*, category.*
        from production.products
        inner join production.brands on products.brand_id = brands.brand_id
        inner join production.categories on products.category_id = categories.category_id
        order by
            products.brand_id, products.product_id
        */

        // do not use tolist in between
        var p4 =
            (from product in context.Products.ToList()
             join brand in context.Brands on product.BrandId equals brand.BrandId
             join category in context.Categories on product.CategoryId equals category.CategoryId
             where product.ProductName.Contains("PO")
             orderby product.BrandId, product.ProductId
             select product);
        // p4 => this will generate SQL as follows
        /*
            -- Select * from Products
            -- select * from Brands
            -- select * from Category

            -- Load all in memory, then join the enumerables and apply filter. 
            -- Problem is that all 50000 products (assume) would be loaded in memory 
            -- resulting in out of memory exception and server crash
         */
        return p2;
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
