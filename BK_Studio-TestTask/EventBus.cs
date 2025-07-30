public class EventBus
{
    private static EventBus instance;
    public static EventBus Instance
    {
        get
        {
            if (instance == null)
                instance = new EventBus();

            return instance;
        }
    }

    public event Action? authSuccessful;
    public event Action? authFailed;
    public event Action? logout;
    public event Action? error;
    public event Action? newMessage;

    public void TriggerAuthSuccessful()
    {
        authSuccessful?.Invoke();
    }

    public void TriggerAuthFailed()
    {
        authFailed?.Invoke();
    }

    public void TriggerLogout()
    {
        logout?.Invoke();
    }

    public void TriggerError()
    {
        error?.Invoke();
    }

    public void TriggerNewMessage()
    {
        newMessage?.Invoke();
    }
}