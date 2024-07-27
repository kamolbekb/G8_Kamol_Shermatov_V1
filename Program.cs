using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Exam;

public class Program
{
    public static void Main(string[] args)
    {
        
        bool exitMain = false;
        var system = new ControlCenter.System();
        while (!exitMain)
        {
            bool exit = false;
            Console.Clear();
            Console.WriteLine("Welcome to Samarkand Restaurant!");
            Console.WriteLine("Are you a Customer (C) or Admin of Restaurant Samarkand (S)?");
            string userType = Console.ReadLine()?.ToUpper();
            if (userType == "C")
            {
                Console.WriteLine("Enter your name: ");
                
                Customer customer = new Customer();
                customer.Name = Console.ReadLine();
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {customer.Name}\n");
                    Console.WriteLine();
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. About Us");
                    Console.WriteLine("2. Order Meal");
                    Console.WriteLine("3. Show Orders");
                    Console.WriteLine("0. To Exit To Previous Menu");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());
                
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("What we reach in field of restaurant business: ");
                            system.GetInfo();
                            
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You are ordering meals.");
                            system.AddOrder();
                                    
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You are viewing orders of our clients.");
                            system.GetOrdersList();

                            Console.WriteLine("Press any button to continue");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 0:
                            Console.Clear();
                            
                            Console.WriteLine("Exiting to previous menu...");
                            exit = true;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input. Please enter a number between 0 and 4.");
                            return;
                    }
                }
            }
            else if (userType == "S")
            {
                Console.WriteLine("Enter your name: ");
                Admin admin = new Admin();
                admin.Name = Console.ReadLine();
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {admin.Name}\n");
                    Console.WriteLine();
                    
                    Console.WriteLine("Choose an action:");
                    Console.WriteLine("1. Info About Us (Create/Read/Update/Delete)");
                    Console.WriteLine("2. Categories (Create/Read/Update/Delete)");
                    Console.WriteLine("3. Menu Based on Categories (Create/Read/Update/Delete)");
                    Console.WriteLine("4. Manage Orders (Create/Read/Update/Delete)");
                    Console.WriteLine("0. Exit to previous menu");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("You are managing Info About (CRUD operations).");
                            system.GetInfo();
                            Console.WriteLine();
                            
                            Console.WriteLine("Chose action:");
                            Console.WriteLine("1.Add New Info");
                            Console.WriteLine("2.Update Existing info");
                            Console.WriteLine("3.Delete existing");
                            Console.WriteLine("0.Exit menu");
                            
                            string str = Console.ReadLine();
                            switch (str)
                            {
                                case "1":
                                    Console.Clear();
                                    
                                    Console.WriteLine("Write down new info");
                                    string app = Console.ReadLine();
                                    system.AddInfo(app);
                                    
                                    Console.WriteLine("Added successfuelly");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.Clear();
                                    
                                    system.GetInfo();
                                    Console.WriteLine();
                                    
                                    Console.WriteLine("Rewrite new info:");
                                    string newInfo = Console.ReadLine();
                                    system.AddInfo(newInfo);
                                   
                                    Console.Clear();
                                    Console.WriteLine("Successsfully added\nPlease tap any button to continue)");
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.Write("Please write (SURE) if you want to confirm deleting info: ");
                                    string answa = Console.ReadLine()?.ToUpper();
                                    if (answa=="SURE")
                                    {
                                        system.DeleteInfo();
                                        Console.Clear();
                                        Console.WriteLine("Successfully deleted\nPlease tap any button to continue)");
                                    }

                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "0":
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid value!");
                                    break;
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("You are managing Categories (CRUD operations).");
                            system.GetCategories();
                            Console.WriteLine();
                            
                            Console.WriteLine("Chose action:");
                            Console.WriteLine("1.Add New Category");
                            Console.WriteLine("2.Update Existing Category");
                            Console.WriteLine("3.Delete Category");
                            Console.WriteLine("0.Exit menu");
                            
                            string choiseCt = Console.ReadLine();
                            switch (choiseCt)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Please enter name for new Category");
                                    string nameCt = Console.ReadLine();
                                    system.AddCategory(nameCt);
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.Clear();
                                    
                                    system.GetCategories();
                                    Console.WriteLine();
                                    
                                    Console.WriteLine("Update existing category:");
                                    
                                    Console.Write("Enter ID of the Category to update: ");
                                    int updateId = int.Parse(Console.ReadLine());
                                    Console.Write("Enter new name: ");
                                    string newName = Console.ReadLine();
                                    system.UpdateCategory(updateId,newName);
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.Write("Please write (SURE) if you want to confirm deleting category: ");
                                    string answa = Console.ReadLine()?.ToUpper();
                                    if (answa=="SURE")
                                    {
                                        system.GetCategories();
                                        Console.WriteLine();
                                        Console.Write("Enter id of category you want to delete:");
                                        int dltCt = int.Parse(Console.ReadLine());
                                        system.DeleteCategory(dltCt);
                                        
                                        Console.Clear();
                                        Console.WriteLine("Successfully deleted\nPlease tap any button to continue)");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "0":
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid value!");
                                    break;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You are managing Meals associated to Categories(CRUD operations).");
                            system.GetCategories();
                            Console.WriteLine();
                            
                            Console.WriteLine("Chose action:");
                            Console.WriteLine("1.Add New Meal to Category");
                            Console.WriteLine("2.Update Existing Meal");
                            Console.WriteLine("3.Delete Meal");
                            Console.WriteLine("4.List Meals");
                            Console.WriteLine("0.Exit menu");
                            
                            string choiseMenu = Console.ReadLine();
                            switch (choiseMenu)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("Please enter name for new Meal");
                                    string nameMenu = Console.ReadLine();
                                    system.AddMelsToMenu(nameMenu);
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.Clear();
                                    system.GetMenu();
                                    
                                    Console.Write("Enter menu ID to update: ");
                                    if (int.TryParse(Console.ReadLine(), out int updateMenuId))
                                    {
                                        Console.Write("Enter new meal name: ");
                                        string newMealName = Console.ReadLine();
                                        Console.Write("Enter new category ID: ");
                                        if (int.TryParse(Console.ReadLine(), out int newCategoryId))
                                        {
                                            system.UpdateMenu(updateMenuId, newMealName, newCategoryId);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid category ID format!");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID format!");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.Write("Enter menu ID to delete: ");
                                    if (int.TryParse(Console.ReadLine(), out int deleteMenuId))
                                    {
                                        system.DeleteMealsFromMenu(deleteMenuId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID format!");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "4":
                                    Console.Clear();
                                    system.GetMenu();
                                    
                                    Console.WriteLine("\nPress any button to continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "0":
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid value!");
                                    break;
                            }
                            break;
                        case 4:
                             Console.Clear();
                            Console.WriteLine("You are managing Orders (CRUD operations).");
                            Console.WriteLine();
                            
                            Console.WriteLine("Chose action:");
                            Console.WriteLine("1.Add New order");
                            Console.WriteLine("2.Update Existing order");
                            Console.WriteLine("3.Delete order");
                            Console.WriteLine("4.Show actual Orders");
                            Console.WriteLine("0.Exit menu");
                            
                            string choiseOrd = Console.ReadLine();
                            switch (choiseOrd)
                            {
                                case "1":
                                    Console.Clear();
                                    system.AddOrder();
                                    
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "2":
                                    Console.Clear();
                                    system.GetOrdersList();
                                    
                                    Console.Write("\nEnter order ID to update: ");
                                    if (int.TryParse(Console.ReadLine(), out int updateOrderId))
                                    {
                                        system.UpdateOrders(updateOrderId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID format!");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.Write("Enter order ID to delete: ");
                                    if (int.TryParse(Console.ReadLine(), out int deleteOrderId))
                                    {
                                        system.DeleteOrder(deleteOrderId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID format!");
                                    }
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "4":
                                    Console.Clear();
                                    system.GetOrdersList();
                                    Console.WriteLine("\nPress any button to continue");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case "0":
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Invalid value!");
                                    break;
                            }
                            break;
                        case 0:
                            Console.Clear();
                            
                            Console.WriteLine("Exiting to previous menu...");
                            exit = true;
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input!\nPress any button to back to previous menu.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}

