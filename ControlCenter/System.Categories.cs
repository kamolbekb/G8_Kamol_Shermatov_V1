using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    public void AddCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new Exception();
        }
        categories.Add(new Categories(categoryCounter++,category));
        SaveData();
        Console.WriteLine("Category added successfully!\nPress Any Key To Continue");
        
    }

    public void UpdateCategory(int id, string categoryName)
    {
        var category = categories.FirstOrDefault(c => c.Id == id);
        
        if (category == null)
        {
            throw new ArgumentException("Category not found", nameof(id));
        }
        if (!string.IsNullOrWhiteSpace(categoryName))
        {
            category.Category = categoryName;
            SaveData();
            Console.WriteLine("Successsfully updated\nPlease tap any key to continue)");
        }
    }

    public void DeleteCategory(int id)
    {
        var category = categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            Console.WriteLine($"Are you sure you want to delete the category '{category.Category}' and all associated meals? (yes/no)");
            if (Console.ReadLine()?.Trim().ToLower() == "yes")
            {
                menus.RemoveAll(m => m.CategoryId == id);
                categories.Remove(category);
                SaveData();
                Console.WriteLine("Category and associated meals deleted successfully!\nPress any Key to continue");
            }
            else
            {
                Console.WriteLine("Deletion canceled.");
            }
        }
        else
        {
            Console.WriteLine("Category not found!");
        }
        
    }

    public void GetCategories()
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("No available catigories...");
            return;
        }

        Console.WriteLine("Categories:\n");
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id}. {category.Category} ");
        }
        
    }
    
}