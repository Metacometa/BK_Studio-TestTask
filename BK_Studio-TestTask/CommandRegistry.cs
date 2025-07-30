using System.Collections.Generic;

public class CommandRegistry : ICommandRegistry
{
    private Dictionary<string, ICommand> commands;
    private Dictionary<string, HashSet<Role>> allowedRoles;

    public CommandRegistry()
    {
        commands = new Dictionary<string, ICommand>();
        allowedRoles = new Dictionary<string, HashSet<Role>>();
    }

    public void Register(string name, Role[] roles, ICommand command)
    {
        if (commands.ContainsKey(name))
        {
            throw new InvalidOperationException($"Внутренняя ошибка: попытка переопределить реестр комманды {name}");
        }

        commands[name] = command;
        allowedRoles[name] = new HashSet<Role>(roles);
    }

    public ICommand GetCommand(string name, Role role)
    {
        if (commands.TryGetValue(name, out ICommand result))    
        {
            if (IsAppropriateRole(name, role) == false)
            {
                throw new KeyNotFoundException($"Ошибка ввода: у вас недостаточно прав для команды \"{name}\"");
            }

            return result;
        }
        else
        {
            throw new KeyNotFoundException("Ошибка ввода: неверная команда");
        }
    }

    private bool IsAppropriateRole(string name, Role role)
    {
        if (allowedRoles.TryGetValue(name, out HashSet<Role> result))
        {
            return result.Contains(role);
        }
        else
        {
            return false;
        }
    }
}
