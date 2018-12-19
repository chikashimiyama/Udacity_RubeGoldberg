using UnityEngine;

public class GameLogicBehavior : MonoBehaviour
{
#pragma warning disable 0649

    [SerializeField] private StarBehaviour[] starBehaviours_;
    [SerializeField] private GoalBehaviour goalBehaviour_;
    [SerializeField] private BallBehaviour ballBehaviour_;
    [SerializeField] private PlatformBehaviour platformBehaviour_;
    [SerializeField] private SoundEffectBehaviour soundEffectBehaviour_;
    [SerializeField] private MenuBehaviour menuBehaviour_;
    [SerializeField] private SpawnableBehaviour spawnableBehaviour_;
    [SerializeField] private string nextLevel_;
    
#pragma warning restore 0649

    private GameLogic gameLogic_;
    private MenuSystem menuSystem_;
    
    private void Start()
    {
        var sceneLoader = new SceneLoader(nextLevel_);
        menuSystem_ = new MenuSystem(menuBehaviour_, spawnableBehaviour_);
        gameLogic_ = new GameLogic(starBehaviours_, goalBehaviour_, ballBehaviour_, platformBehaviour_, 
            soundEffectBehaviour_, sceneLoader);
    }
}