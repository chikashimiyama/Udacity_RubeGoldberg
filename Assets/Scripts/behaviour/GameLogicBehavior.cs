using UnityEngine;
using UnityEngine.Serialization;

public class GameLogicBehavior : MonoBehaviour
{
#pragma warning disable CS0649

    [FormerlySerializedAs("platFormBehaviour_")] [SerializeField] private IPlatformBehaviour platformBehaviour_;
    [SerializeField] private StarBehaviour[] starBehaviours_;
    [SerializeField] private IBallBehaviour ballBehaviour_;
    [SerializeField] private GoalBehaviour goalBehaviour_;
    
#pragma warning restore CS0649

    private ObjectiveHandler objectiveHandler_;

    private void Start()
    {
        objectiveHandler_ = new ObjectiveHandler(starBehaviours_, goalBehaviour_, ballBehaviour_, platformBehaviour_);
        
    }
}