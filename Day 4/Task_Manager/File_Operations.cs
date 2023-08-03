using System;

namespace TaskManager
{
    class File_Operations
    {
        const string FilePath = "tasks.csv";
        
        // Load tasks from file
        public async Task LoadTasksAsync(Task_Manager taskManager)
        {
            try
            {
                // Check if file exists
                if (File.Exists(FilePath))
                {
                    string[] lines = await File.ReadAllLinesAsync(FilePath);

                    // Read each line and create a task object
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        
                        // Check if the line has 4 parts
                        if (parts.Length == 4)
                        {
                            TaskCategory category;
                            
                            // Check if the category is valid
                            if (Enum.TryParse(parts[2], out category))
                            {
                                bool isCompleted;
                                
                                // Check if the IsCompleted value is valid
                                if (bool.TryParse(parts[3], out isCompleted))
                                {
                                    Task_Class task = new Task_Class
                                    {
                                        Name = parts[0],
                                        Description = parts[1],
                                        Category = category,
                                        IsCompleted = isCompleted
                                    };

                                    taskManager.tasks.Add(task);
                                }
                                else
                                {
                                    Console.WriteLine($"Error parsing 'IsCompleted' value: {parts[3]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Error parsing 'Category' value: {parts[2]}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid line format: {line}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }
        }


        // Save tasks to file
        public void SaveTasks(Task_Manager taskManager)
        {
            // Check if there are any tasks
            if (taskManager.tasks.Count == 0)
            {
                return;
            }

            // Create a new file or overwrite the existing file
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Task_Class task in taskManager.tasks)
                {
                    // Create a line with task details
                    string line = $"{task.Name},{task.Description},{task.Category},{task.IsCompleted}";
                    writer.WriteLine(line);
                }
            }
        }
        
    }
}