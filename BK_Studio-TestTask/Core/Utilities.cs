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
}
