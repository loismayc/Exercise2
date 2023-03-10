using Exercise2.Models;

namespace Exercise2
{
    public class Program
    {
        static List<TodoList> myLists = new List<TodoList>();
        static TodoList listOnSelect;

        static void Main(string[] args)
        {
            MainMenu();

            static void MainMenu()
            {
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1 - Display All Lists");
                Console.WriteLine("2 - Show Items");
                Console.WriteLine("3 - Create New List");
                Console.WriteLine("4 - Select List");
                Console.WriteLine("5 - Quit\n========================");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DisplayAllLists();
                        MainMenu();
                        break;

                    case 2:
                        ShowItems();
                        MainMenu();

                        break;

                    case 3:
                        CreateNewList();
                        MainMenu();

                        break;

                    case 4:
                        SelectList();
                        MainMenu();

                        break;

                    case 5:
                        //exit
                        Console.WriteLine("\nGoodbye ^_^");
                        return;
                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }

            static void DisplayAllLists()
            {
                if (myLists.Count == 0)
                {
                    Console.WriteLine("No lists found");
                    return;
                }

                foreach (TodoList list in myLists)
                {
                    Console.WriteLine($"{list.id} - {list.name} ({list.todoItems.Count} items)");
                }
            }

            static void ShowItems()
            {
                Console.WriteLine("Enter list id:");
                int id = int.Parse(Console.ReadLine());

                TodoList list = myLists.Find(l => l.id == id);

                if (list == null)
                {
                    Console.WriteLine("List not found");
                    return;
                }

                if (list.todoItems.Count == 0)
                {
                    Console.WriteLine($"No items found for list {list.name}.");
                    return;
                }

                foreach (TodoItem item in list.todoItems)
                {
                    Console.WriteLine($"{item.id} - {item.content} ({item.status})");
                }
            }

            static void CreateNewList()
            {
                Console.WriteLine("Enter list name:");
                string name = Console.ReadLine();

                int id = 1;

                if (myLists.Count > 0)
                {
                    id = myLists[myLists.Count - 1].id + 1;
                }

                TodoList list = new TodoList(id, name);
                myLists.Add(list);

                Console.WriteLine("List created successfully.");
            }

            static void SelectList()
            {
                Console.WriteLine("Enter list id:");
                int id = int.Parse(Console.ReadLine());

                listOnSelect = myLists.Find(l => l.id == id);

                if (listOnSelect == null)
                {
                    Console.WriteLine("List not found.");
                    return;
                } while (true)
                {

                    Console.WriteLine("\nSelect an option: ");
                    Console.WriteLine("1 - Display All Items");
                    Console.WriteLine("2 - Create New Item");
                    Console.WriteLine("3 - Delete Item");
                    Console.WriteLine("4 - Update Item");
                    Console.WriteLine("5 - Go Back\n==================");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            DisplayAllItems();
                            break;
                        case 2:
                            CreateNewItem();
                            break;
                        case 3:
                            DeleteItem();
                            break;
                        case 4:
                            UpdateItem();
                            break;
                        case 5:
                            return;
                    }
                }

                static void DisplayAllItems()
                {
                    if (listOnSelect.todoItems.Count == 0)
                    {
                        Console.WriteLine("No items found for list.");
                        return;
                    }

                    foreach (TodoItem item in listOnSelect.todoItems)
                    {
                        Console.WriteLine($"{item.id} - {item.content} ({item.status})");
                    }
                }

                static void CreateNewItem()
                {
                    Console.WriteLine("Enter item content:");
                    string content = Console.ReadLine();

                    int id = 1;

                    if (listOnSelect.todoItems.Count > 0)
                    {
                        id = listOnSelect.todoItems[listOnSelect.todoItems.Count - 1].id + 1;
                    }

                    TodoItem item = new TodoItem(id, content);
                    listOnSelect.todoItems.Add(item);

                    Console.WriteLine("Item created successfully.");
                }

                static void DeleteItem()
                {
                    Console.WriteLine("Enter item id to delete:");
                    int id = int.Parse(Console.ReadLine());

                    TodoItem item = listOnSelect.todoItems.Find(i => i.id == id);

                    if (item == null)
                    {
                        Console.WriteLine("Invalid id.");
                        return;
                    }

                    listOnSelect.todoItems.Remove(item);
                }

                static void UpdateItem()
                {
                    Console.WriteLine("Enter item id:");
                    int id = int.Parse(Console.ReadLine());

                    TodoItem item = listOnSelect.todoItems.Find(i => i.id == id);

                    if (item == null)
                    {
                        Console.WriteLine("Invalid id.");
                        return;
                    }

                    if (item.Update())
                    {
                        Console.WriteLine("Item updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Item already done.");
                    }

                }
            }
        }
    }
}