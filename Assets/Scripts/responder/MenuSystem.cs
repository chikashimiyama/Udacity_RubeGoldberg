public interface IMenuSystem
{
    void ShiftRight();
    void ShiftLeft();
}

public class MenuSystem : IMenuSystem
{
    private readonly IMenuBehaviour menuBehaviour_;
    private int index_ = 0;
    
    public MenuSystem(IMenuBehaviour menuBehaviour)
    {
        menuBehaviour_ = menuBehaviour;
        menuBehaviour_.LeftButtonPressed += ShiftLeft;
        menuBehaviour_.RightButtonPressed += ShiftRight;
    }

    public void ShiftLeft()
    {
        index_--;
        if (index_ < 0)
            index_ = menuBehaviour_.NumberOfObjects() - 1;

        menuBehaviour_.Show(index_);
    }

    public void ShiftRight()
    {
        index_++;
        if (index_ > menuBehaviour_.NumberOfObjects() - 1)
            index_ = 0;

        menuBehaviour_.Show(index_);
    }
}