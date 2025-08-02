public static class Utilities
{
    public static string RolesToString()
    {
        string roles = string.Empty;

        foreach (Role role in Enum.GetValues(typeof(Role)))
        {
            if (role == Role.Unathorized) continue;
            roles += role.ToString() + ", ";
        }

        roles = roles.Substring(0, roles.Length - 2);

        return roles;
    }
    public static List<Role> GetRolesList()
    {
        List<Role> roles = new List<Role>();

        foreach (Role role in Enum.GetValues(typeof(Role)))
        {
            roles.Add(role);
        }

        return roles;
    }

    public static Dictionary<Role, List<User>> SortUsersByRoles(List<User> users)
    {
        Dictionary<Role, List<User>> usersByRoles = new Dictionary<Role, List<User>>();

        foreach (User user in users)
        {
            if (!usersByRoles.TryGetValue(user.Role, out List<User> value))
            {
                usersByRoles[user.Role] = new List<User>();
            }

            usersByRoles[user.Role].Add(user);
        }

        return usersByRoles;
    }
}
