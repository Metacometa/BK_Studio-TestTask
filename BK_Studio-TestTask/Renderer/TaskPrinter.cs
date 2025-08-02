public class TaskPrinter : ITaskPrinter
{
    private readonly ConsoleTheme theme;

    public TaskPrinter(ConsoleTheme theme)
    {
        this.theme = theme;
    }

    public void PrintTask(Task task)
    {
        Console.Write("Название: ");
        PrintColorized($"{task.Name}", theme.taskColor);

        PrintTaskStatus(task);

        PrintDescription(task);

        Console.WriteLine();
        PrintExecutors(task);
    }

    private void PrintDescription(Task task)
    {
        Console.Write("\n    Описание: ");
        if (task.Description == string.Empty)
        {
            Console.Write("[");
            PrintColorized("БЕЗ ОПИСАНИЯ", theme.executorColor);
            Console.Write($"]");
        }
        else
        {
            PrintColorized($"{task.Description}", ConsoleColor.White);
        }
    }

    private void PrintExecutors(Task task)
    {
        Console.Write($"    Исполнители: [");
        if (task.Executors.Count == 0)
        {
            PrintColorized("НЕ НАЗНАЧЕНЫ", theme.executorColor);
        }
        else
        {
            List<string> executors = new List<string>(task.Executors);
            for (int j = 0; j < executors.Count; ++j)
            {
                PrintColorized($"{executors[j]}", theme.executorColor);

                if (j < executors.Count - 1)
                {
                    Console.Write(", ");
                }
            }
        }
        Console.Write($"]");
    }

    private void PrintTaskStatus(Task task)
    {
        Console.Write("\n    Статус: ");
        switch (task.TaskStatus)
        {
            case TaskStatus.ToDo:
                PrintColorized("Получено", theme.toDoColor);
                break;
            case TaskStatus.InProgress:
                PrintColorized("Выполняется", theme.inProgressColor);
                break;
            case TaskStatus.Done:
                PrintColorized("Выполнено", theme.doneColor);
                break;
            default:
                break;
        }
    }

    private void PrintColorized(string input, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(input);
        Console.ResetColor();
    }
}
