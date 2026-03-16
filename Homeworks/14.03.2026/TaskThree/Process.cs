public class Process
{
    private Chain chain; 
    EventChain eventChain = new();
    public Process()
    {
        User user = Registration.Register();
        chain = eventChain.SendEmail;
        chain += eventChain.WriteDatabase;
        chain += eventChain.RefreshCount;
        chain?.Invoke(user);
    }

    private delegate void Chain(User user);
}