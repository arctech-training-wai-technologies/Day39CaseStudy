using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;

namespace Day39CaseStudy.Services.DbService;

public class CrudProductService
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

        return context.Products.ToList();
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

    internal void Delete(int brandId)
    {
        using var context = new SampleStoreDbContext();

        var product = context.Products.Find(brandId);

        context.Products.Remove(product);
        context.SaveChanges();
    }
}
