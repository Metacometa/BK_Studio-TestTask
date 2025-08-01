public class RolePrinter : IRolePrinter
{
    private readonly ConsoleTheme theme;

    public RolePrinter(ConsoleTheme theme)
    {
        this.theme = theme;
    }

    public void PrintRoles()
    {
        List<Role> roles = Utilities.GetRolesList();
        roles.Remove(Role.Unathorized);

        for (int i = 0; i < roles.Count; ++i)
        {
            Role role = roles[i];

            PrintRole(role);

            if (i != roles.Count - 1)
            {
                Console.Write(" | ");
            }
        }
    }

    public void PrintRole(Role role)
    {
        ConsoleColor color = GetRoleColor(role);

        Console.ForegroundColor = color;
        Console.Write(role.ToString());
        Console.ResetColor();
    }

    public ConsoleColor GetRoleColor(Role role)
    {
        switch (role)
        {
            case Role.Manager:
                return theme.managerColor;
            case Role.Employee:
                return theme.employeeColor;
            default:
                return ConsoleColor.Gray;
        }
    }
}
