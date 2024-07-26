using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    public void GetCategoryFromJson(string relativePath)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
        categoryPath = Path.Combine(basePath, relativePath);
        categories = new List<Categories>();
        
        LoadCategoriesFromFile();
    }
    
    public void AddCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            throw new Exception();
        }
        int id = categories.Count>0?categories.Max(c => c.Id) + 1 : 1;
        categories.Add(new Categories{Id = id,Category = category});
        SaveCategoryToFile();
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
        }
        
        SaveCategoryToFile();
    }

    public void DeleteCategory(int id)
    {
        var category = categories.FirstOrDefault(c => c.Id == id);
        if (category == null)
        {
            throw new ArgumentException("Category not found", nameof(id));
        }

        categories.Remove(category);
        
        SaveCategoryToFile();
    }

    public void GetCategories()
    {
        if (categories.Count == 0)
        {
            Console.WriteLine("No available catigories...");
            return;
        }
        
        foreach (var category in categories)
        {
            Console.WriteLine($"{category.Id}. {category.Category} ");
        }
        
    }
    
    private void LoadCategoriesFromFile()
    {
        if (File.Exists(categoryPath))
        {
            string existingData = File.ReadAllText(categoryPath);
            if (!string.IsNullOrEmpty(existingData))
            {
                categories = JsonSerializer.Deserialize<List<Categories>>(existingData);
            }
        }
    }
    
    
    private void SaveCategoryToFile()
    {
        string jsonString = JsonSerializer.Serialize(categories, new JsonSerializerOptions { WriteIndented = true });

       
        string directoryPath = Path.GetDirectoryName(categoryPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        try
        {
            File.WriteAllText(categoryPath, jsonString);
        }
        catch (IOException ex)
        {
            throw new Exception("An error occurred while writing the JSON file.", ex);
        }
    }
}