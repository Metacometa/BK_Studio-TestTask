public class EventBus
{
    private static EventBus instance;
    public static EventBus Instance { 
        get
        {
            if (instance == null)
                instance = new EventBus();

            return instance;
        }
    }

    public event Action? UserAuth;

    public void TriggerUserAuth()
    {
        UserAuth?.Invoke();
    }
}
