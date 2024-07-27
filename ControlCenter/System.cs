
using System.Text.Json;

namespace Exam.ControlCenter;

public partial class System
{
    private List<Menu> menus = new List<Menu>();
    private List<Orders> orders = new List<Orders>();
    private List<Categories> categories = new List<Categories>();
    private RestaurantInfo Info = RestaurantInfo.Instance;
    
    private const string categoryPath = @"CategoryList.json";
    private const string menuPath = @"MenuList.json";
    private const string ordersPath = @"OrderList.json";
    private const string infoPath = @"RestaurantInfo.txt";
   
    
    private int categoryCounter = 1;
    private int menuCounter = 1;
    private int orderCounter = 1;

    public System()
    {
        LoadData();
    }
    
    private void SaveData()
    {
        File.WriteAllText(categoryPath, JsonSerializer.Serialize(categories));
        File.WriteAllText(menuPath, JsonSerializer.Serialize(menus));
        File.WriteAllText(ordersPath, JsonSerializer.Serialize(orders));
        File.WriteAllText(infoPath, Info.Info);
    }

    private void LoadData()
    {
        if (File.Exists(categoryPath))
        {
            categories = JsonSerializer.Deserialize<List<Categories>>(File.ReadAllText(categoryPath)) ?? new List<Categories>();
            categoryCounter = categories.Any() ? categories.Max(c => c.Id) + 1 : 1;
        }

        if (File.Exists(menuPath))
        {
            menus = JsonSerializer.Deserialize<List<Menu>>(File.ReadAllText(menuPath)) ?? new List<Menu>();
            menuCounter = menus.Any() ? menus.Max(m => m.Id) + 1 : 1;
        }

        if (File.Exists(ordersPath))
        {
            orders = JsonSerializer.Deserialize<List<Orders>>(File.ReadAllText(ordersPath)) ?? new List<Orders>();
            orderCounter = orders.Any() ? orders.Max(m => m.Id) + 1 : 1; 
        }
        
        if (File.Exists(infoPath))
        {
            Info.Info = File.ReadAllText(infoPath);
        }
        
    }
}