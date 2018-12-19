using System;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;

public class UnitTest_MenuSystem
{
    private IMenuBehaviour menuBehaviour_;
    private ISpawnableBehaviour spawnableBehaviour_;
    private MenuSystem menuSystem_;
    
    [SetUp]
    public void SetUp()
    {
        menuBehaviour_ = Substitute.For<IMenuBehaviour>();
        spawnableBehaviour_ = Substitute.For<ISpawnableBehaviour>();
        menuSystem_ = new MenuSystem(menuBehaviour_, spawnableBehaviour_);
    }

    [Test]
    public void Construct_SwipeUpdated_shift_left()
    {
        menuBehaviour_.NumberOfObjects().Returns(2);

        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(-0.51f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(-0.51f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(-0.51f);

        menuBehaviour_.Received(2).Show(1);
        menuBehaviour_.Received(1).Show(0);
    }
    
    [Test]
    public void Construct_SwipeUpdated_shift_right()
    {
        menuBehaviour_.NumberOfObjects().Returns(2);

        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);

        menuBehaviour_.Received(2).Show(1);
        menuBehaviour_.Received(1).Show(0);
    }
    
    [Test]
    public void Construct_SwipeUpdated_no_neutral_position()
    {
        menuBehaviour_.NumberOfObjects().Returns(2);

        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);
       
        menuBehaviour_.Received(1).Show(1);
        menuBehaviour_.DidNotReceive().Show(0);
    }

    [Test]
    public void Construct_SpawnPressed()
    {
        menuBehaviour_.Position.Returns(new Vector3(3f,4f,5f));
        menuBehaviour_.NumberOfObjects().Returns(2);
        menuBehaviour_.SwipeUpdated += Raise.Event<Action<float>>(0.51f);

        menuBehaviour_.SpawnPressed += Raise.Event<Action>();
        
        spawnableBehaviour_.Received(1).SpawnAt(0, new Vector3(3f, 4f, 5f));
    }
    
    [Test]
    public void Construct_SpawnPressed_empty()
    {
        menuBehaviour_.SpawnPressed += Raise.Event<Action>();
        
        spawnableBehaviour_.DidNotReceive().SpawnAt(0, Arg.Any<Vector3>());
    }
}