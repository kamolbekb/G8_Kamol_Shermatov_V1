using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    public void GetOrdersFromJson(string relativePath)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        
        ordersPath = Path.Combine(basePath, relativePath);
        orders= new List<Orders>();
        
        LoadOrdersFromFile();
    }
    
    public void AddOrders(int mealId)
    {
        string name=null;
        foreach (var VARIABLE in menus)
        {
            if (VARIABLE.Id == mealId)
            {
                name=VARIABLE.Name;
            }
        }
        int id = this.orders.Count>0?orders.Max(c => c.Id) + 1 : 1;
        orders.Add(new Orders{Id = id,Name = name});
        SaveOrderToFile();
    }

    public void UpdateOrders(int id, string name)
    {
        var order = orders.FirstOrDefault(c => c.Id == id);
        if (order == null)
        {
            throw new ArgumentException("Order not found", nameof(id));
        }
        if (!string.IsNullOrWhiteSpace(name))
        {
            order.Name = name;
        }
        
        SaveOrderToFile();
    }

    public void DeleteOrder(int id)
    {
        var order = orders.FirstOrDefault(c => c.Id == id);
        if (order == null)
        {
            throw new ArgumentException("Order not found", nameof(id));
        }

        orders.Remove(order);
        
        SaveOrderToFile();
    }

    public void GetOrdersList()
    {
        if (menus.Count == 0)
        {
            Console.WriteLine("No available orders...");
            return;
        }
        
        foreach (var order in orders)
        {
            Console.WriteLine($"{order.Id}. {order.Name} ");
        }
        
    }
    
    private void LoadOrdersFromFile()
    {
        if (File.Exists(ordersPath))
        {
            string existingData = File.ReadAllText(categoryPath);
            if (!string.IsNullOrEmpty(existingData))
            {
                orders = JsonSerializer.Deserialize<List<Orders>>(existingData);
            }
        }
    }
    
    private void SaveOrderToFile()
    {
        string jsonString = JsonSerializer.Serialize(menus, new JsonSerializerOptions { WriteIndented = true });

       
        string directoryPath = Path.GetDirectoryName(ordersPath);
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        try
        {
            File.WriteAllText(ordersPath, jsonString);
        }
        catch (IOException ex)
        {
            throw new Exception("An error occurred while writing the JSON file.", ex);
        }
    }
}