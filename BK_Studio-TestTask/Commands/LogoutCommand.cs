public class LogoutCommand : ICommand
{
    public string Description { get; private set; }
    public string Prompt { get; }

    private readonly IAuthService authService;

    public LogoutCommand(IAuthService authService, string description, string prompt)
    {
        this.authService = authService;
        Description = description;
        Prompt = prompt;
    }

    public void Execute(string[] args)
    {
       authService.Logout();
    }
}
