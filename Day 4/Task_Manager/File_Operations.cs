using System;

namespace TaskManager
{
    class File_Operations
    {
        const string FilePath = "tasks.csv";
        public async Task LoadTasksAsync(Task_Manager taskManager)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string[] lines = await File.ReadAllLinesAsync(FilePath);

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            TaskCategory category;
                            if (Enum.TryParse(parts[2], out category))
                            {
                                bool isCompleted;
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


        public void SaveTasks(Task_Manager taskManager)
        {
            if (taskManager.tasks.Count == 0)
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (Task_Class task in taskManager.tasks)
                {
                    string line = $"{task.Name},{task.Description},{task.Category},{task.IsCompleted}";
                    writer.WriteLine(line);
                }
            }
        }
        
    }
}