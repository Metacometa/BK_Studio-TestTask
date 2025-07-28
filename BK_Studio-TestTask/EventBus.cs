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
    public void TriggerAuthSuccessful()
    {
        authSuccessful?.Invoke();
    }


    public event Action? authFailed;
    public void TriggerAuthFailed()
    {
        authFailed?.Invoke();
    }
}