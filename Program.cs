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
                            system.GetMenu();
                            Console.WriteLine();
                            Console.WriteLine("Choose an option");
                            int choise = int.Parse(Console.ReadLine());
                            system.AddOrders(choice);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("You are viewing orders of our clients.");
                            system.GetOrdersList();
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
                    Console.WriteLine("3. Create A Menu Based on Categories (Create/Read/Update/Delete)");
                    Console.WriteLine("4. Manage Orders (Create/Read/Update/Delete)");
                    Console.WriteLine("0. Exit to previous menu");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 0:
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input!\nPress any key to back to previous menu.");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
        }
    }
}

