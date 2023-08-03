using System;
namespace TaskManager
{
    class Program
    {
        // Main method
        static async Task Main()
        {
            // Create a new task manager
            Task_Manager taskManager = new Task_Manager();
            // Create a new file operations object
            File_Operations fileOperations = new File_Operations();
            // Load tasks from file
            await fileOperations.LoadTasksAsync(taskManager);

            // Display menu
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. View all tasks");
                Console.WriteLine("3. View tasks by category");
                Console.WriteLine("4. Update a task");
                Console.WriteLine("5. Exit");

                string option = Console.ReadLine()!;

                switch (option)
                {
                    case "1":
                        taskManager.AddTask();
                        break;

                    case "2":
                        taskManager.ViewTasks();
                        break;

                    // View tasks by category
                    case "3":
                        Console.WriteLine("Select task category (0: Personal, 1: Work, 2: Errands, 3: Others): ");
                        if (Enum.TryParse(Console.ReadLine(), out TaskCategory selectedCategory))
                        {
                            taskManager.ViewTasksByCategory(selectedCategory);
                        }
                        else
                        {
                            Console.WriteLine("Invalid category selection!");
                        }
                        break;

                    case "4":
                        taskManager.UpdateTask();
                        break;

                    case "5":
                        fileOperations.SaveTasks(taskManager);
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}