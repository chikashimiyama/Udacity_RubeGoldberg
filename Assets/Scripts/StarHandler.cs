
public class StarHandler
{
    private readonly IVisibilityBehaviour[] stars_;
    private readonly ISwapableObject goal_;
   
    private int gainedStars_;
    private readonly int requiredStars_;

    public StarHandler(IVisibilityBehaviour[] star)
    {
        stars_ = star;
        requiredStars_ = stars_.Length;
    }

    private void OnStarEntered(IVisibilityBehaviour star)
    {
        // if the ball enters the collider of the star, star becomes invisible
        star.IsVisible = false;
        gainedStars_++;
        if (gainedStars_ == requiredStars_)
            goal_.State = true;
    }
    
    public void Reset()
    {
        // all stars become visible and reset the counter
        foreach (var star in stars_)
        {
            star.IsVisible = false;
        }
        gainedStars_ = 0;
    }
}