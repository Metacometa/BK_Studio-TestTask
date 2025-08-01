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
}
