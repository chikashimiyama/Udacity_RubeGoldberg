using System;
using NUnit.Framework;
using NSubstitute;

public class UnitTest_GameLogic
{
    private IStarBehaviour[] starBehaviourMocks_;
    private IGoalBehaviour goalBehaviourMock_;
    private IBallBehaviour ballBehaviourMock_;
    private IPlatformBehaviour platformBehaviourMock_;
    private ISoundEffectBehaviour soundEffectBehaviourMock_;
    private ISceneLoader sceneLoaderMock_;

    [SetUp]
    public void SetUp()
    {
        starBehaviourMocks_ = new IStarBehaviour[1];
        starBehaviourMocks_[0] = Substitute.For<IStarBehaviour>();
        goalBehaviourMock_ = Substitute.For<IGoalBehaviour>();
        ballBehaviourMock_ = Substitute.For<IBallBehaviour>();
        platformBehaviourMock_ = Substitute.For<IPlatformBehaviour>();
        soundEffectBehaviourMock_ = Substitute.For<ISoundEffectBehaviour>();
        sceneLoaderMock_ = Substitute.For<ISceneLoader>();

        var unused = new GameLogic(starBehaviourMocks_, goalBehaviourMock_, ballBehaviourMock_,
            platformBehaviourMock_, soundEffectBehaviourMock_, sceneLoaderMock_);
    }

    [Test]
    public void Construction_StarOnEntered()
    {
        starBehaviourMocks_[0].Entered += Raise.Event<Action<IVisibilityBehaviour>>(starBehaviourMocks_);

        starBehaviourMocks_[0].Received(1).IsVisible = false;

        goalBehaviourMock_.Received(1).State = true;
        soundEffectBehaviourMock_.Received(1).PlayStar();
    }

    [Test]
    public void Construction_OnGoalReached_star_collected()
    { 
        starBehaviourMocks_[0].Entered += Raise.Event<Action<IVisibilityBehaviour>>(starBehaviourMocks_);
        goalBehaviourMock_.Reached += Raise.Event<Action>();

        sceneLoaderMock_.Received(1).Load();
        soundEffectBehaviourMock_.Received(1).PlayClear();
        {
            ballBehaviourMock_.FloorTouched += Raise.Event<Action>();
            soundEffectBehaviourMock_.DidNotReceive().PlayFail();
        }
    }
    
    [Test]
    public void Construction_OnGoalReached_star_uncollected()
    {
        goalBehaviourMock_.Reached += Raise.Event<Action>();

        sceneLoaderMock_.DidNotReceive().Load();
        soundEffectBehaviourMock_.DidNotReceive().PlayClear();
    }

    [Test]
    public void Construction_OnFloorTouched()
    {
        ballBehaviourMock_.FloorTouched += Raise.Event<Action>();

        starBehaviourMocks_[0].Received(1).IsVisible = true;
        ballBehaviourMock_.Reset();
        soundEffectBehaviourMock_.Received(1).PlayFail();
    }

    [Test]
    public void Construction_OnTeleportStart()
    {
        platformBehaviourMock_.TeleportStarted += Raise.Event<Action>();

        platformBehaviourMock_.Received(1).ColliderState = false;
    }
    
    [Test]
    public void Construction_OnTeleportEnded()
    {
        platformBehaviourMock_.TeleportEnded += Raise.Event<Action>();

        platformBehaviourMock_.Received(1).ColliderState = true;
    }

    [Test]
    public void Construction_OnPlatformEntered()
    {
        platformBehaviourMock_.Entered += Raise.Event<Action>();

        starBehaviourMocks_[0].Received(1).Availability = true;
        ballBehaviourMock_.Received(1).Warn = false;
    }

    [Test]
    public void Construction_OnPlatformExited()
    {
        platformBehaviourMock_.Exited += Raise.Event<Action>();

        starBehaviourMocks_[0].Received(1).Availability = false;
        ballBehaviourMock_.Received(1).Warn = true;
    }
}