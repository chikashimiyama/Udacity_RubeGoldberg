using System;
using UnityEngine;

public interface IPlatformBehaviour
{
    event Action Entered;
    event Action Exited;
}

public class PlatformBehaviour : MonoBehaviour, IPlatformBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (!col.CompareTag("Throwable")) return;
        if(Entered != null)
            Entered.Invoke();
    }

    private void OnTriggerExit(Collider col)
    {
        if (!col.CompareTag("Throwable")) return;
        if(Exited != null)
            Exited.Invoke();
    }

    public event Action Entered;
    public event Action Exited;
}