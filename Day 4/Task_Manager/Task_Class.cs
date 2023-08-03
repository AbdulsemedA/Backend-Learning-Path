using System;

namespace TaskManager
{
    enum TaskCategory
    {
        Personal,
        Work,
        Errands,
        Others
    }

    class Task_Class
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskCategory Category { get; set; }
        public bool IsCompleted { get; set; }
    }
}



