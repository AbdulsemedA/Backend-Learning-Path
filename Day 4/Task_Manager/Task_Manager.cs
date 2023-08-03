namespace TaskManager
{
    class Task_Manager
    {
        public List<Task_Class> tasks = new List<Task_Class>();
        private const string FilePath = "tasks.csv";

        public void AddTask() {

            string? name, description;

            do {
                Console.Write("Enter task name: ");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));

            do {
                Console.Write("Enter task description: ");
                description = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(description));

            Console.WriteLine("Select task category (0: Personal, 1: Work, 2: Errands, 3: Others): ");
            if (Enum.TryParse(Console.ReadLine(), out TaskCategory category))
            {
                Task_Class newTask = new Task_Class
                {
                    Name = name,
                    Description = description,
                    Category = category,
                    IsCompleted = false
                };

                tasks.Add(newTask);
                File_Operations file = new File_Operations();
                file.SaveTasks(this);
                Console.WriteLine("Task added successfully!");

            }

        }

        public void ViewTasks()
        {
            Console.WriteLine("Tasks:");
            PrintTableHeader();

            foreach (Task_Class task in tasks)
            {
                PrintTaskDetails(task);
            }
        }

        public void ViewTasksByCategory(TaskCategory category)
        {
            Console.WriteLine($"Tasks in {category} category:");
            PrintTableHeader();

            var filteredTasks = tasks.Where(task => task.Category == category);

            foreach (Task_Class task in filteredTasks)
            {
                PrintTaskDetails(task);
            }
        }

        private void PrintTableHeader()
        {
            string separator = new string('-', 90);
            Console.WriteLine(separator);
            Console.WriteLine($"{"Name", -25}{"Description", -25}{"Category", -20}{"Completion Status", -10}");
            Console.WriteLine(separator);
        }

        private void PrintTaskDetails(Task_Class task)
        {
    
            string separator = new string('-', 90);
            string description = task.Description?.Length > 20 ? task.Description.Substring(0, 17) + "..." : task.Description ?? "N/A";
            Console.WriteLine($"{task.Name, -25}{description, -25}{task.Category, -20}{task.IsCompleted, -10}");
            Console.WriteLine(separator);
        }

        public Task_Class? GetTaskByName(string name)
        {
            return tasks.FirstOrDefault(task => task.Name == name);
        }

        public void UpdateTask()
        {
            ViewTasks();
            Console.Write("Enter the name of the task to update: ");
            string? taskName;

            do
            {
                taskName = Console.ReadLine();

                if (string.IsNullOrEmpty(taskName) || GetTaskByName(taskName) == null)
                {
                    Console.WriteLine("Invalid task name!");
                }

            } while (string.IsNullOrEmpty(taskName) || GetTaskByName(taskName) == null);
                        
            Console.Write("Enter the attribute to update (0: Name, 1: Description, 2: Completion Status): ");
            int range;
            string? attributeNum;
            do
            {
                attributeNum = Console.ReadLine();
                range = int.Parse(attributeNum ?? "0");

                if (string.IsNullOrEmpty(attributeNum) || 0 > range || range > 2)
                {
                    Console.WriteLine("Invalid attribute number!");
                }

            } while (string.IsNullOrEmpty(attributeNum) || 0 > range || range > 2);
                        

            Console.Write("Enter the new value(Use True or False for completion status): ");
            string? newValue;

            do 
            {
                newValue = Console.ReadLine();

                if (string.IsNullOrEmpty(newValue))
                {
                    Console.WriteLine("Invalid new value!");
                }
            } while (string.IsNullOrEmpty(newValue));

            Task_Class taskToUpdate = GetTaskByName(taskName)!;

            switch (attributeNum)
            {
                case "0":
                    taskToUpdate.Name = newValue;
                    break;

                case "1":
                    taskToUpdate.Description = newValue;
                    break;

                case "2":
                    taskToUpdate.IsCompleted = bool.Parse(newValue);
                    break;

                default:
                    Console.WriteLine("Invalid attribute choice!");
                    return;
            }

            Console.WriteLine("Task updated successfully!");
        }
    }
}