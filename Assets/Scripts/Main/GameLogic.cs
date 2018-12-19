public class GameLogic
{
    private readonly IStarBehaviour[] starBehaviours_;
    private readonly IGoalBehaviour goalBehaviour_;
    private readonly IBallBehaviour ballBehaviour_;
    private readonly ISoundEffectBehaviour soundEffectBehaviour_;
    private readonly ISceneLoader sceneLoader_;
    private readonly IPlatformBehaviour platformBehaviour_;
    private int gainedStars_;
    private readonly int requiredStars_;
    
    public GameLogic(IStarBehaviour[] starBehaviours, 
        IGoalBehaviour goalBehaviour, 
        IBallBehaviour ballBehaviour, 
        IPlatformBehaviour platformBehaviour,
        ISoundEffectBehaviour soundEffectBehaviour,
        ISceneLoader sceneLoader)
    {
        starBehaviours_ = starBehaviours;
        goalBehaviour_ = goalBehaviour;
        ballBehaviour_ = ballBehaviour;
        sceneLoader_ = sceneLoader;
        platformBehaviour_ = platformBehaviour;
        soundEffectBehaviour_ = soundEffectBehaviour;
        requiredStars_ = starBehaviours_.Length;
        
        foreach (var star in starBehaviours)
        {
            star.Entered += StarOnEntered;
        }

        ballBehaviour_.FloorTouched += OnFloorTouched;
        goalBehaviour_.Reached += OnGoalReached;

        platformBehaviour_.TeleportStarted += OnTeleportStarted;
        platformBehaviour_.TeleportEnded += OnTeleportEnded;
        platformBehaviour_.Entered += OnPlatformEntered;
        platformBehaviour_.Exited += OnPlatformExited;
    }

    private void StarOnEntered(IVisibilityBehaviour star)
    {
        star.IsVisible = false;
        gainedStars_++;
        if (gainedStars_ == requiredStars_)
            goalBehaviour_.State = true;
        soundEffectBehaviour_.PlayStar();
    }

    private void OnGoalReached()
    {
        ballBehaviour_.FloorTouched -= OnFloorTouched;
        soundEffectBehaviour_.PlayClear();
        sceneLoader_.Load();
    }
    
    private void OnFloorTouched()
    {
        foreach (var star in starBehaviours_)
        {
            star.IsVisible = true;
        }
        gainedStars_ = 0;
        ballBehaviour_.Reset();
        goalBehaviour_.State = false;
        soundEffectBehaviour_.PlayFail();
    }

    private void OnTeleportStarted()
    {
        platformBehaviour_.ColliderState = false;
    }

    private void OnTeleportEnded()
    {
        platformBehaviour_.ColliderState = true;
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