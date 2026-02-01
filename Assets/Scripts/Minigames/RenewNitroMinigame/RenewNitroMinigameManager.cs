public class RenewNitroMinigameManager : Minigame
{
    
    public void CancelSubscription()
    {
        EndMinigame(Gamestate.CreateScoreArray(addiction: -0.3f));
    }
    public void RenewSubscription()
    {
        EndMinigame(Gamestate.CreateScoreArray(addiction: 0.1f));
    }
    public void UpgradeSubscription()
    {
        EndMinigame(Gamestate.CreateScoreArray(addiction: 0.2f));
    }

}
