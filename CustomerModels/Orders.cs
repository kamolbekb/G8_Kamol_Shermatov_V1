namespace Exam;

public class Orders
{
    public int Id { get; set; }
    
    public List<int> MenuIds { get; set; } = new List<int>();

    public Orders(int id)
    {
        Id = id;
    }
}