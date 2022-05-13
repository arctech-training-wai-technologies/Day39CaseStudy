using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService;

namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudBrandService
{
    readonly CrudBrandService _brandService;

    public UserInterfaceCrudBrandService()
    {
        _brandService = new CrudBrandService();
    }

    public void Add()
    {
        Console.WriteLine("Adding New Brand");
        Console.WriteLine("----------------");

        Console.Write("Enter Brand Name: ");
        var brandNameText = Console.ReadLine();

        var brand = new Brand { BrandName = brandNameText };

        _brandService.Add(brand);
    }

    public IEnumerable<Brand> GetAll()
    {
        return _brandService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Brand");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Brand Name to Update: ");
        var brandNameText = Console.ReadLine();

        var brand = _brandService.GetByName(brandNameText);

        if (brand == null)
        {
            Console.WriteLine($"Brand Name {brandNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found Brand: {brand}");

        Console.Write("Enter Brand Name to change: ");
        var changedBrandNameText = Console.ReadLine();

        brand.BrandName = changedBrandNameText;
        
        _brandService.Update(brand);
    }

    public void Delete()
    {
        Console.WriteLine("Deleting existing Brand");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Brand Id to delete: ");
        var brandIdText = Console.ReadLine();
        int brandId = int.Parse(brandIdText);

        _brandService.Delete(brandId);
    }

    public void Show()
    {
        var brands = _brandService.GetAll();

        Console.WriteLine("Brand List");
        Console.WriteLine("----------");

        Console.WriteLine(Brand.Header);
        Console.WriteLine("------------------");
        foreach (var brand in brands)
        {
            Console.WriteLine(brand);
        }
        Console.WriteLine("------------------");
    }
}
