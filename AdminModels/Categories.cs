namespace Exam;

public class Categories
{
    public int Id { get; set; }
    public string Category { get; set;}

    public Categories(int id, string category)
    {
        Id = id;
        Category = category;
    }
}