using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    public void GetMenuFromJson(string relativePath)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
        menuPath = Path.Combine(basePath, relativePath);
        menus = new List<Menu>();
        
        LoadMenuFromFile();
    }
    
    public void AddMelsToMenu(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception();
        }
        int id = this.menus.Count>0?menus.Max(c => c.Id) + 1 : 1;
        menus.Add(new Menu{Id = id,Name = name});
        SaveMenuToFile();
    }

    public void SearchMeals(int id, string Name)
    {
        foreach (var Meal in menus)
        {
            if (Meal.Name == Name)
            {
                
            }
        }
    }
    public void UpdateMenu(int id, string menuName)
    {
        var menu = menus.FirstOrDefault(c => c.Id == id);
        if (menu == null)
        {
            throw new ArgumentException("Meal not found", nameof(id));
        }
        if (!string.IsNullOrWhiteSpace(menuName))
        {
            menu.Name = menuName;
        }
        
        SaveMenuToFile();
    }

    public void DeleteMealsFromMenu(int id)
    {
        var menu = menus.FirstOrDefault(c => c.Id == id);
        if (menu == null)
        {
            throw new ArgumentException("Menu not found", nameof(id));
        }

        menus.Remove(menu);
        
        SaveMenuToFile();
    }

    public void GetMenu()
    {
        if (menus.Count == 0)
        {
            Console.WriteLine("No available dishes...");
            return;
        }
        
        foreach (var menu in menus)
        {
            Console.WriteLine($"{menu.Id}. {menu.Name} ");
        }
        
    }
    
    private void LoadMenuFromFile()
    {
        if (File.Exists(menuPath))
        {
            string existingData = File.ReadAllText(categoryPath);
            if (!string.IsNullOrEmpty(existingData))
            {
                menus = JsonSerializer.Deserialize<List<Menu>>(existingData);
            }
        }
    }
    
    private void SaveMenuToFile()
    {
        string jsonString = JsonSerializer.Serialize(menus, new JsonSerializerOptions { WriteIndented = true });

       
        string directoryPath = Path.GetDirectoryName(menuPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        try
        {
            File.WriteAllText(menuPath, jsonString);
        }
        catch (IOException ex)
        {
            throw new Exception("An error occurred while writing the JSON file.", ex);
        }
    }
}