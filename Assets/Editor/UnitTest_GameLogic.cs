using System;
using NUnit.Framework;
using NSubstitute;

public class UnitTest_GameLogic
{
    private IStarBehaviour[] starBehaviourMocks_;
    private IGoalBehaviour goalBehaviourMock_;
    private IBallBehaviour ballBehaviourMock_;
    private IPlatformBehaviour platformBehaviourMock_;
    private ISceneLoader sceneLoaderMock_;
    

    [SetUp]
    public void SetUp()
    {
        starBehaviourMocks_ = new IStarBehaviour[1];
        starBehaviourMocks_[0] = Substitute.For<IStarBehaviour>();
        goalBehaviourMock_ = Substitute.For<IGoalBehaviour>();
        ballBehaviourMock_ = Substitute.For<IBallBehaviour>();
        platformBehaviourMock_ = Substitute.For<IPlatformBehaviour>();
        sceneLoaderMock_ = Substitute.For<ISceneLoader>();
        
        var unused = new GameLogic(starBehaviourMocks_, goalBehaviourMock_, ballBehaviourMock_,
            platformBehaviourMock_, sceneLoaderMock_);
    }

    [Test]
    public void Construction_StarOnEntered()
    {
        starBehaviourMocks_[0].Entered += Raise.Event<Action<IVisibilityBehaviour>>(starBehaviourMocks_);

        starBehaviourMocks_[0].Received(1).IsVisible = false;

        goalBehaviourMock_.Received(1).State = true;
    }

    [Test]
    public void Construction_OnGoalReached()
    {
        goalBehaviourMock_.Reached += Raise.Event<Action>();
        
        sceneLoaderMock_.Received(1).Load();
    }

    [Test]
    public void Construction_OnFloorTouched()
    {
        ballBehaviourMock_.FloorTouched += Raise.Event<Action>();
        
        starBehaviourMocks_[0].Received(1).IsVisible = true;
        ballBehaviourMock_.Reset();
    }

    [Test]
    public void Construction_OnPlatformEntered()
    {
        platformBehaviourMock_.Entered += Raise.Event<Action>();
        
        starBehaviourMocks_[0].Received(1).IsVisible = true;
        ballBehaviourMock_.Received(1).Warn = false;
    }

    [Test]
    public void Construction_OnPlatformExited()
    {
        platformBehaviourMock_.Exited += Raise.Event<Action>();
        
        starBehaviourMocks_[0].Received(1).IsVisible = false;
        ballBehaviourMock_.Received(1).Warn = true;
    }
}