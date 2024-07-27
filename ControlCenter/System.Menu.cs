using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    public void AddMelsToMenu(string name)
    {
        GetCategories();
        Console.Write("Enter Caetegory ID to add new meal in:");
        if(int.TryParse(Console.ReadLine(),out int categoryId)&& categories.Any(c=>c.Id==categoryId))
        {
            menus.Add(new Menu(menuCounter++,name,categoryId));
            SaveData();
            Console.WriteLine("Meal successfully added!\nPlease press any button to continue)");
        }
        else
        {
            Console.WriteLine("Invalid category ID!");
        }
    }
    public void UpdateMenu(int id, string menuName, int categoryId)
    {
        var menu = menus.FirstOrDefault(m => m.Id == id);
        if (menu != null && categories.Any(c => c.Id == categoryId))
        {
            menu.Name = menuName;
            menu.CategoryId = categoryId;
            SaveData();
            Console.WriteLine("\nMenu Updated Successfully!\nPress any button to continue");
        }
        else
        {
            Console.WriteLine("Menu or category not found");
        }
    }

    public void DeleteMealsFromMenu(int id)
    {
        var menu = menus.FirstOrDefault(m => m.Id == id);
        if (menu != null)
        {
            menus.Remove(menu);
            SaveData();
            Console.WriteLine("\nMenu deleted successfully!\nPress any button to continue");
        }
        else
        {
            Console.WriteLine("Menu not found");
        }
    }

    public void GetMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var menu in menus)
        {
            var categoryName = categories.FirstOrDefault(c => c.Id == menu.CategoryId)?.Category ?? "Unknown";
            Console.WriteLine($"{menu.Name} (Category: {categoryName})");
        }
    }
}