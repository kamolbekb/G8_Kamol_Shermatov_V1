namespace Exam;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int CategoryId { get; set; }

    public Menu(int id, string name, int categoryId)
    {
        Id = id;
        Name = name;
        CategoryId = categoryId;
    }
}