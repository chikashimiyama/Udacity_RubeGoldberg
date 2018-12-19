using System;
using UnityEngine;
using Valve.VR;

public interface IPlatformBehaviour
{
    bool ColliderState { set; }

    event Action TeleportStarted;
    event Action TeleportEnded;
    event Action Entered;
    event Action Exited;
}

public class PlatformBehaviour : MonoBehaviour, IPlatformBehaviour
{   
    private BoxCollider boxCollider_;

    [SteamVR_DefaultAction("teleport", "default")]
    public SteamVR_Action_Boolean teleport;
    
    private void Start()
    {
        boxCollider_ = GetComponentInParent<BoxCollider>();
    }

    private void Update()
    {
        if (teleport.GetStateDown(SteamVR_Input_Sources.LeftHand))
        {
            if (TeleportStarted != null) TeleportStarted.Invoke();
        }

        if (teleport.GetStateUp(SteamVR_Input_Sources.LeftHand))
        {
            if (TeleportEnded != null) TeleportEnded.Invoke();
        }
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

    public event Action TeleportStarted;
    public event Action TeleportEnded;
    public event Action Entered;
    public event Action Exited;
}