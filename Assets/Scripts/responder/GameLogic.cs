public class GameLogic
{
    private readonly IStarBehaviour[] starBehaviours_;
    private readonly IGoalBehaviour goalBehaviour_;
    private readonly IBallBehaviour ballBehaviour_;
    private readonly ISceneLoader sceneLoader_;
    private int gainedStars_;
    private readonly int requiredStars_;
    
    public GameLogic(IStarBehaviour[] starBehaviours, 
        IGoalBehaviour goalBehaviour, 
        IBallBehaviour ballBehaviour, 
        IPlatformBehaviour platformBehaviour,
        ISceneLoader sceneLoader)
    {
        starBehaviours_ = starBehaviours;
        goalBehaviour_ = goalBehaviour;
        ballBehaviour_ = ballBehaviour;
        sceneLoader_ = sceneLoader;
        
        requiredStars_ = starBehaviours_.Length;
        
        foreach (var star in starBehaviours)
        {
            star.Entered += StarOnEntered;
        }

        ballBehaviour_.FloorTouched += OnFloorTouched;
        goalBehaviour_.Reached += OnGoalReached;
        platformBehaviour.Entered += OnPlatformEntered;
        platformBehaviour.Exited += OnPlatformExited;
    }

    private void StarOnEntered(IVisibilityBehaviour star)
    {
        star.IsVisible = false;
        gainedStars_++;
        if (gainedStars_ == requiredStars_)
            goalBehaviour_.State = true;
    }

    private void OnGoalReached()
    {
        sceneLoader_.Load();
    }
    
    private void OnFloorTouched()
    {
        // reset gained stars
        foreach (var star in starBehaviours_)
        {
            star.IsVisible = true;
        }
        gainedStars_ = 0;
        ballBehaviour_.Reset();
    }

    private void OnPlatformEntered()
    {
        foreach (var starBehaviour in starBehaviours_)
            starBehaviour.IsVisible = true;

        ballBehaviour_.Warn = false;
    }

    private void OnPlatformExited()
    {
        foreach (var starBehaviour in starBehaviours_)
            starBehaviour.IsVisible = false;

        ballBehaviour_.Warn = true;
    }
}