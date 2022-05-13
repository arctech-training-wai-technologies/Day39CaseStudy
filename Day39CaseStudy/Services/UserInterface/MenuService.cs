namespace Day39CaseStudy.Services.UserInterface;

public enum MenuOptions
{
    Exit = 0,
    BrandAdd = 1,
    BrandUpdate = 2,
    BrandDelete = 3,
    BrandShow = 4,
    ProductAdd = 5,
    ProductUpdate = 6,
    ProductDelete = 7,
    ProductShow = 8,
}

public class MenuService
{
    public MenuOptions Show()
    {
        Console.WriteLine("=== Main Menu ===");
        Console.WriteLine("| Brand          |");
        Console.WriteLine("| 1) Add         |");
        Console.WriteLine("| 2) Update      |");
        Console.WriteLine("| 3) Delete      |");
        Console.WriteLine("| 4) Show        |");
        Console.WriteLine("| Product        |");
        Console.WriteLine("| 5) Add         |");
        Console.WriteLine("| 6) Update      |");
        Console.WriteLine("| 7) Delete      |");
        Console.WriteLine("| 8) Show        |");
        Console.WriteLine("| 0) Exit        |");
        Console.Write("Select an option: ");
        var selectedMenu = Console.ReadKey();
        Console.WriteLine();
        
        var selectedMenuOption = (MenuOptions)(selectedMenu.KeyChar - '0');
        return selectedMenuOption;
    }
}
