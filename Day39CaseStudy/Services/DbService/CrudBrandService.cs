using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;

namespace Day39CaseStudy.Services.DbService;

public class CrudBrandService
{
    public void Add(Brand brand)
    {
        using var context = new SampleStoreDbContext();

        context.Brands.Add(brand);
        context.SaveChanges();
    }

    public IEnumerable<Brand> GetAll()
    {
        using var context = new SampleStoreDbContext();

        return context.Brands.ToList();
    }

    public void Update(Brand brand)
    {
        using var context = new SampleStoreDbContext();

        context.Brands.Update(brand);
        context.SaveChanges();
    }

    public Brand GetByName(string brandName)
    {
        using var context = new SampleStoreDbContext();

        var brand = context.Brands.SingleOrDefault(b => b.BrandName == brandName);
        return brand;
    }

    internal void Delete(int brandId)
    {
        using var context = new SampleStoreDbContext();

        var brand = context.Brands.Find(brandId);

        context.Brands.Remove(brand);
        context.SaveChanges();
    }
}
