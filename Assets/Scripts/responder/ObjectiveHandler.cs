public class ObjectiveHandler
{
    private readonly IStarBehaviour[] starBehaviours_;
    private readonly IGoalBehaviour goalBehaviour_;
    private readonly IBallBehaviour ballBehaviour_;
    private readonly IPlatformBehaviour platformBehaviour_;
    private int gainedStars_;
    private readonly int requiredStars_;
    
    public ObjectiveHandler(IStarBehaviour[] starBehaviours, 
        IGoalBehaviour goalBehaviour, 
        IBallBehaviour ballBehaviour, 
        IPlatformBehaviour platformBehaviour)
    {
        starBehaviours_ = starBehaviours;
        goalBehaviour_ = goalBehaviour;
        ballBehaviour_ = ballBehaviour;
        platformBehaviour_ = platformBehaviour;
        requiredStars_ = starBehaviours_.Length;
        
        foreach (var star in starBehaviours)
        {
            star.Entered += StarOnEntered;
        }

        ballBehaviour_.FloorTouched += OnFloorTouched;
        goalBehaviour_.Reached += OnGoalReached;
        platformBehaviour_.Entered += OnPlatformEntered;
        platformBehaviour_.Exited += OnPlatformExited;
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
        // load new scene
    }
    
    private void OnFloorTouched()
    {
        // reset gained stars
        foreach (var star in starBehaviours_)
        {
            star.IsVisible = true;
        }
        gainedStars_ = 0;
    }

    private void OnPlatformEntered()
    {
        foreach (var starBehaviour in starBehaviours_)
            starBehaviour.IsVisible = false;

        ballBehaviour_.Warn = false;
    }

    private void OnPlatformExited()
    {
        foreach (var starBehaviour in starBehaviours_)
            starBehaviour.IsVisible = true;

        ballBehaviour_.Warn = true;
    }
}