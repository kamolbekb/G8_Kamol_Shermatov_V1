namespace Exam;

public sealed class RestaurantInfo
{
    private static RestaurantInfo instanse = null;
    public string Info { get; set; }

    private RestaurantInfo()
    {
    }

    public static RestaurantInfo Instance
    {
        get
        {
            if (instanse is null)
                instanse = new RestaurantInfo();
            return instanse;
        }
    }
}