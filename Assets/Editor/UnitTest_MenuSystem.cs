using NUnit.Framework;
using NSubstitute;

public class UnitTest_MenuSystem
{
    private IMenuBehaviour menuBehaviour_;
    private IMenuSystem menuSystem_;
    
    [SetUp]
    public void SetUp()
    {
        menuBehaviour_ = Substitute.For<IMenuBehaviour>();
        menuSystem_ = new MenuSystem(menuBehaviour_);
    }

    [Test]
    public void ShiftLeft()
    {
        menuBehaviour_.NumberOfObjects().Returns(2);
        
        menuSystem_.ShiftLeft();
        menuSystem_.ShiftLeft();
        menuSystem_.ShiftLeft();

        menuBehaviour_.Received(2).Show(1);
        menuBehaviour_.Received(1).Show(0);
    }

    [Test]
    public void ShiftRight()
    {
        menuBehaviour_.NumberOfObjects().Returns(2);
        
        menuSystem_.ShiftRight();
        menuSystem_.ShiftRight();
        menuSystem_.ShiftRight();

        menuBehaviour_.Received(2).Show(1);
        menuBehaviour_.Received(1).Show(0);
    }
}