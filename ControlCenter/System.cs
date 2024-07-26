namespace Exam.ControlCenter;

public partial class System
{
    private List<Menu> menus = new List<Menu>();
    private List<Orders> orders = new List<Orders>();
    private List<Categories> categories = new List<Categories>();
    //private List<MenuCategories> MenuCategoriesList = new List<MenuCategories>();

    private string categoryPath;
    private string menuCategoryPath;
    private string menuPath;
    private string ordersPath;

    private string relativPathCategory = @"ControlCenter/CategoryList.json";
    private string relativPathMenu = "ControlCenter/MenuList.json";
    public void AttachMenuToCategory(int menuId, int categoryId)
    {
        var category = categories.FirstOrDefault(c => c.Id == categoryId);
        var menu = menus.FirstOrDefault(m => m.Id == menuId);    
        
        if (category == null || menu == null)
        {
            Console.WriteLine("Invalid category or menu ID.");
            return;
        }
        
        var menuCartegory = new MenuCategories
        {
            CategoryId = categoryId,
            Categories = category,
            MenuId = menuId,
            Menu = menu
        };
        
        //end it up
    }

}