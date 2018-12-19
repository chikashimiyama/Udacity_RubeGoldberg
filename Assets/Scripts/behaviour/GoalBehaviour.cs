using System;
using UnityEngine;

public interface IGoalBehaviour
{
    bool State { set; }
    event Action Reached;
}

public class GoalBehaviour: MonoBehaviour, IGoalBehaviour
{
#pragma warning disable 0649

    [SerializeField] private GameObject inactiveObject;
    [SerializeField] private GameObject activeObject;

#pragma warning restore 0649

    private bool state_;
    
    public bool State
    {
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

    private void OnTriggerEnter(Collider col)
    {
        if (!col.gameObject.CompareTag("Throwable")) return;
        
        if(Reached != null)
            Reached.Invoke();
    }
    
    public event Action Reached;
}