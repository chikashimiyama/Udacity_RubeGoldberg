using System;
using UnityEngine;

public interface IStarBehaviour : IVisibilityBehaviour, IEnterable
{     
}

public class StarBehaviour : MonoBehaviour, IStarBehaviour {

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
        
        Entered.Invoke(this);
    }

    public event Action<IVisibilityBehaviour> Entered;
}
