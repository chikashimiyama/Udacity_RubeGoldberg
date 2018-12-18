using System;
using UnityEngine;

public class StarBehaviour : MonoBehaviour, IVisibilityBehaviour, IEnterable {

    public bool IsVisible
    {
        set
        {
            gameObject.SetActive(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Entered == null)
            return;
        
        Entered.Invoke();
    }

    public event Action Entered;
}
