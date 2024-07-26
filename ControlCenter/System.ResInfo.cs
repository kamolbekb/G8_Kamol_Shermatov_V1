namespace Exam.ControlCenter;

public partial class System
{
    public void AddInfo(string info)
    {
        
        if (string.IsNullOrWhiteSpace(info))
        {
            throw new Exception();
        }
        
        RestaurantInfo restaurantInfo = RestaurantInfo.Instance;
        restaurantInfo.Info = info;
    }

    public void GetInfo()
    {
        RestaurantInfo restaurantInfo = RestaurantInfo.Instance;
        Console.WriteLine(restaurantInfo.Info);
    }

    public void DeleteInfo()
    {
        RestaurantInfo About = RestaurantInfo.Instance;
        About.Info = null;
    }
}