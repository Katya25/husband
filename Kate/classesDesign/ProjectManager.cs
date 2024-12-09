enum Priority { Low, Medium, High }
enum Status { Pending, InProgress, Completed }

public class Task
{
    public string name { get; private set; }
    public string description { get; private set; }

    public Priority priority { get; private set; }
    public Status status {get; set;}

    public Task (string name, string description, Priority priority)
    {
        this.name = name;
        this.description = description;
        this.priority = priority;
        this.status = Task.Pending;
    }
}

public class ProjectManager
{
     private Dictionary<string, Task> tasksByName = new Dictionary<string, Task>();
    private Dictionary<Priority, HashSet<Task>> tasksByPriority = new Dictionary<Priority, HashSet<Task>>();
    private Dictionary<Status, HashSet<Task>> tasksByStatus = new Dictionary<Status, HashSet<Task>>();

    public ProjectManager()
    {
        // Инициализируем словари для группировки задач
        foreach (Priority priority in Enum.GetValues(typeof(Priority)))
        {
            tasksByPriority[priority] = new HashSet<Task>();
        }

        foreach (Status status in Enum.GetValues(typeof(Status)))
        {
            tasksByStatus[status] = new HashSet<Task>();
        }
    }

    public void AddTask(string name, string description, Priority priority)
    {
        if (tasksByName.ContainsKey(name))
        {
            Console.WriteLine($"Task with name '{name}' already exists.");
            return;
        }

        var newTask = new Task(name, description, priority);
        tasksByName[name] = newTask;
        tasksByPriority[priority].Add(newTask);
        tasksByStatus[Status.Pending].Add(newTask);
    }

    public void CompleteTask(string taskName)
    {
        if (!tasksByName.ContainsKey(taskName))
        {
            Console.WriteLine($"Task with name '{taskName}' not found.");
            return;
        }

        var task = tasksByName[taskName];
        tasksByStatus[task.TaskStatus].Remove(task); // Удаляем из текущего статуса
        task.TaskStatus = Status.Completed;
        tasksByStatus[Status.Completed].Add(task); // Добавляем в новый статус
    }

    // Получить все задачи по статусу
    public IEnumerable<Task> FilterTasksByStatus(Status status)
    {
        return tasksByStatus[status];
    }

    // Получить все задачи по приоритету
    public IEnumerable<Task> FilterTasksByPriority(Priority priority)
    {
        return tasksByPriority[priority];
    }

}

class Program
{
    static void Main()
    {
        var projectManager = new ProjectManager();

        // Добавляем задачи
        projectManager.AddTask("Fix Bug #123", "Fix a critical bug in the login system", Priority.High);
        projectManager.AddTask("Write Documentation", "Write user manual for the app", Priority.Low);
        projectManager.AddTask("Develop New Feature", "Add search functionality to the app", Priority.Medium);

        // Завершаем задачу
        projectManager.CompleteTask("Fix Bug #123");

        // Получаем все завершенные задачи
        Console.WriteLine("Completed tasks:");
        var completedTasks = projectManager.FilterTasksByStatus(Status.Completed);
        foreach (var task in completedTasks)
        {
            Console.WriteLine(task.Name);
        }

        // Получаем все задачи с высоким приоритетом
        Console.WriteLine("\nHigh priority tasks:");
        var highPriorityTasks = projectManager.FilterTasksByPriority(Priority.High);
        foreach (var task in highPriorityTasks)
        {
            Console.WriteLine(task.Name);
        }
    }
}