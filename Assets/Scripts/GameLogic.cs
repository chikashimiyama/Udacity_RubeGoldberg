using UnityEngine;

public class GameLogic : MonoBehaviour
{
#pragma warning disable CS0649

    [SerializeField] private StarBehaviour[] stars;

#pragma warning restore CS0649

    private StarHandler starHandler_;

    private void Start()
    {
        starHandler_ = new StarHandler(stars);
    }
}