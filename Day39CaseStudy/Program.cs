// See https://aka.ms/new-console-template for more information
using Day39CaseStudy.Services;
using Day39CaseStudy.Services.UserInterface;

Console.WriteLine("Hello, World!");
/*
Requirement: 
1. Create a CRUD Screen for Brand & Product
2. Display a report of brand wise products
 */


var menuService = new MenuService();
var uiBrandService = new UserInterfaceCrudBrandService();

do
{
    var menuOptions = menuService.Show();

    switch (menuOptions)
    {
        case MenuOptions.Exit:
            return;
        case MenuOptions.BrandAdd:
            uiBrandService.Add();
            break;
        case MenuOptions.BrandUpdate:
            uiBrandService.Update();
            break;
        case MenuOptions.BrandDelete:
            uiBrandService.Delete();
            break;
        case MenuOptions.BrandShow:
            uiBrandService.Show();
            break;
        case MenuOptions.ProductAdd:
            break;
        case MenuOptions.ProductUpdate:
            break;
        case MenuOptions.ProductDelete:
            break;
        case MenuOptions.ProductShow:
            break;
        default:
            break;
    }

} while (true);