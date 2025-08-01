using System.Collections.Generic;
using System.ComponentModel;

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
            throw new InvalidOperationException($"[ОШИБКА]: Попытка переопределить реестр команды \"{name}\"");
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
                throw new WarningException($"[ПРЕДУПРЕЖДЕНИЕ]: У вас недостаточно прав для команды \"{name}\"");
            }

            return result;
        }
        else
        {
            throw new WarningException("[ПРЕДУПРЕЖДЕНИЕ]: Неверная команда");
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

    public List<ICommand> GetCommandsByRole(Role role)
    {
        List<ICommand> filteredCommands = new List<ICommand>();

        foreach (var item in allowedRoles)
        {
            if (item.Value.Contains(role))
            {
                ICommand filteredCommand = commands[item.Key];
                filteredCommands.Add(filteredCommand);   
            }
        }

        return filteredCommands;
    }
}
