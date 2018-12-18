using UnityEngine;

public class GoalBehaviour: ISwapableObject
{
#pragma warning disable CS0649

    [SerializeField] private GameObject inactiveObject;
    [SerializeField] private GameObject activeObject;

#pragma warning restore CS0649

    
    private bool state_;
    
    public bool State
    {
        get
        {
            return state_;
        }
        set
        {
            state_ = value;
            if (state_)
            {
                activeObject.SetActive(true);
                inactiveObject.SetActive(false);
            }
            else
            {
                activeObject.SetActive(false);
                inactiveObject.SetActive(true);
            }
        }
    }
}