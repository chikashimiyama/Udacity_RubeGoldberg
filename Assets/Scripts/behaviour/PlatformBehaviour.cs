using System;
using UnityEngine;

public interface IPlatformBehaviour
{
    bool ColliderState { set; }
    event Action Entered;
    event Action Exited;
}


public class PlatformBehaviour : MonoBehaviour, IPlatformBehaviour
{
    
    
    private BoxCollider boxCollider_;

    private void Start()
    {
        boxCollider_ = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Camera")) return;
        if(Entered != null)
            Entered.Invoke();
    }

    private void OnTriggerExit(Collider col)
    {
        if (!col.CompareTag("Camera")) return;
        if(Exited != null)
            Exited.Invoke();
    }

    public bool ColliderState
    {
        set { boxCollider_.enabled = value; }
    }

    public event Action Entered;
    public event Action Exited;
}