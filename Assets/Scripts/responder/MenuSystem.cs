enum SwipeState
{
    Standby,
    Detected
}

public class MenuSystem
{
    private readonly IMenuBehaviour menuBehaviour_;
    private readonly ISpawnableBehaviour spawnableBehaviour_;
    private int index_ = 0;
    private float SWIPE_THRESHOLD = 0.5f;
    private SwipeState swipeState_ = SwipeState.Standby;

    public MenuSystem(IMenuBehaviour menuBehaviour, ISpawnableBehaviour spawnableBehaviour)
    {
        menuBehaviour_ = menuBehaviour;
        spawnableBehaviour_ = spawnableBehaviour;
        menuBehaviour_.SwipeUpdated += OnSwipeUpdated;
        menuBehaviour_.SpawnPressed += OnSpawnPressed;
    }

    private void OnSwipeUpdated(float pos)
    {
        if (swipeState_ == SwipeState.Standby)
        {
            if (SWIPE_THRESHOLD < pos)
            {
                ShiftRight();
                swipeState_ = SwipeState.Detected;
            }
            else if (pos < -SWIPE_THRESHOLD)
            {
                ShiftLeft();
                swipeState_ = SwipeState.Detected;
            }
        }
        else
        {
            if (pos == 0f)
                swipeState_ = SwipeState.Standby;
        }
    }

    private void OnSpawnPressed()
    {
        var index = index_ - 1;
        if (index < 0)
            return; 
        
        
        spawnableBehaviour_.SpawnAt(index, menuBehaviour_.SpawnPosition );
        menuBehaviour_.Show(0); // hide
    }

    private void ShiftLeft()
    {
        index_--;
        if (index_ < 0)
            index_ = menuBehaviour_.NumberOfObjects() - 1;

        menuBehaviour_.Show(index_);
    }

    private void ShiftRight()
    {
        index_++;
        if (index_ > menuBehaviour_.NumberOfObjects() - 1)
            index_ = 0;

        menuBehaviour_.Show(index_);
    }
}